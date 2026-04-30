// 260430_code
// 260430_documentation

using System.IO;
using System.Windows;
using TingenTransmorger.Core;
using TingenTransmorger.Database;

namespace TingenTransmorger;
/// <summary>Entry class for Tingen Transmorger.</summary>
/// <remarks>
/// The MainWindow class is the entry point for the Tingen Transmorger application, and is split into multiple partial
/// classes. Initially this was done to keep the code organized and maintainable, but over time it has
/// become somewhat of a monster. Eventually this class should be refactored to separate classes.<br/>
/// <br/>
/// The MainWindow.xaml.cs partial class is responsible for the main application flow.
/// </remarks>
public partial class MainWindow : Window
{
    private TransmorgerDatabase? _tmDb;
    private readonly Configuration? _config = Configuration.Load();
    private const string _databaseName      = "transmorger.db";

    /// <summary>Transmorger entry method.</summary>
    public MainWindow()
    {
        InitializeComponent();

        _ = StartApp();
    }

    /// <summary>Start Transmorger.</summary>
    private async Task StartApp()
    {
        string localDbPath  = Path.Combine(_config.Directory["LocalDb"], _databaseName);
        string masterDbPath = Path.Combine(_config.Directory["MasterDb"], _databaseName);

        SetUi(_config);
        Framework.Verify(_config);
        TransmorgerDatabase.Update(localDbPath, masterDbPath);
        _tmDb = LocalDatabase(localDbPath);
        SetDatabaseDateRangeUi(_tmDb);
    }

    private static TransmorgerDatabase LocalDatabase(string localDbPath)
    {
        var tmDb = new TransmorgerDatabase();

        try
        {
            tmDb = TransmorgerDatabase.Load(localDbPath);
        }
        catch (Exception ex)
        {
            StopApp($"The database could not be loaded: {ex.Message}{Environment.NewLine}{Environment.NewLine}The application will now exit.");
        }

        if (tmDb is null)
        {
            StopApp("The database could not be loaded. The application will now exit.");
        }

        return tmDb;
    }

    /// <summary>Stop Transmorger.</summary>
    /// <remarks>
    /// If you pass a message to <paramref name="msgExit"/>, it will be displayed to the user in a MessageBox
    /// before Transmorger exits.<br/>
    /// <br/>
    /// This method is public because it is called from other methods outside the <see cref="MainWindow"/> class.
    /// </remarks>
    /// <param name="msgExit">Optional exit message to display.</param>
    public static void StopApp(string msgExit = "")
    {
        if (!string.IsNullOrEmpty(msgExit))
        {
            MessageBox.Show(msgExit, "Exiting Tingen Transmorger", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        Environment.Exit(0);
    }

    private async Task RebuildDatabase()
    {
        var flowControl = await Database.TransmorgerDatabase.RebuildDatabaseCheck(_config.Directory["Reports"], _config.Directory["Tmp"], _config.Directory["MasterDb"], this);

        /* If EnterAdminMode returns false, it means the user either failed to authenticate or chose to exit from
         * the admin mode dialog. In that case, we should stop the app instead of continuing to load the database
         * and show the main UI.
         */
        if (!flowControl)
        {
            return;
        }
    }

    /* EVENT HANDLERS */
    private void btnSearchToggle_Clicked(object? sender, RoutedEventArgs e) => SetSearchToggleUi();
    private void rbtnSearchBy_Checked(object sender, RoutedEventArgs e) => ClearUi();
    private void txbxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => UpdateSearchResults();
    private void btnUserPhoneDetail_Clicked(object sender, RoutedEventArgs e) => ShowMessageDetails("phone");
    private void btnUserEmailDetail_Clicked(object sender, RoutedEventArgs e) => ShowMessageDetails("email");
    private void lstbxSearchResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => Display();
    private void dgMeetingResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => MeetingSelected();
    private void btnCopyMeetingList_Click(object sender, RoutedEventArgs e) => CopyMeetingList();
    private void btnCopyGeneralMeetingDetail_Click(object sender, RoutedEventArgs e) => CopyGeneralMeetingDetails();
    private void btnCopyPatientMeetingDetail_Click(object sender, RoutedEventArgs e) => CopyPatientMeetingDetails();
    private void btnCopyProviderMeetingDetail_Click(object sender, RoutedEventArgs e) => CopyProviderMeetingDetails();
    private async void btnRebuildDatabase_Click(object sender, RoutedEventArgs e) => await RebuildDatabase();

    private void btnBuildReleaseNotes_Click(object sender, RoutedEventArgs e)
    {

    }
}