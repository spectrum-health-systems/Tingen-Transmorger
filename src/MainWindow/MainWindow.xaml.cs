// 260430_code
// 260430_documentation

using System.IO;
using System.Windows;
using TingenTransmorger.Core;
using TingenTransmorger.Database;

namespace TingenTransmorger;
/// <summary>Entry class for Tingen Transmorger.</summary>
/// <remarks>
/// MainWindow.xaml.cs partial class is responsible for:
/// <list type="bullet">
/// <item>Initializing Transmorger</item>
/// <item>Starting Transmorger</item>
/// <item>Stopping Transmorger</item>
/// </list>
/// In addition, this partial class contains the event handlers for MainWindow.xaml.
/// </remarks>
public partial class MainWindow : Window
{
    private TransmorgerDatabase? _tmDb;
    private readonly Configuration? _config = Configuration.Load();
    private const string _databaseName = "transmorger.db";

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

        SetInitialUi(_config);
        Framework.Verify(_config);
        TransmorgerDatabase.Update(localDbPath, masterDbPath, this);
        _tmDb = TransmorgerDatabase.LocalDatabase(localDbPath);
        SetDatabaseDateRangeUi(_tmDb);
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
    private async void btnRebuildDatabase_Click(object sender, RoutedEventArgs e) => await TransmorgerDatabase.RebuildDatabaseCheck(_config.Directory["Reports"], _config.Directory["Tmp"], _config.Directory["MasterDb"], this);

    private void btnBuildReleaseNotes_Click(object sender, RoutedEventArgs e)
    {

    }
}