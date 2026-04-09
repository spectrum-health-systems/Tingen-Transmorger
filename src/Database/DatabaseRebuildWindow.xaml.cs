// 260212_code
// 260409_documentation

/* The database namespace needs to be refactored */

using System.Windows;

namespace TingenTransmorger.Database;

/// <summary>A progress window displayed during a database rebuild operation.</summary>
public partial class DatabaseRebuildWindow : Window
{

    private Window? _parentWindow;

    /// <summary>Initializes a new instance of <see cref="DatabaseRebuildWindow"/>.</summary>
    public DatabaseRebuildWindow()
    {
        InitializeComponent();
    }

    /// <summary>Sets the parent window to be restored when this window is closed.</summary>
    /// <param name="parentWindow">The parent <see cref="Window"/> to restore on close.</param>
    public void SetParentWindow(Window parentWindow) => _parentWindow = parentWindow;

    /// <summary>Updates the current task label on the UI thread.</summary>
    /// <param name="rebuildTask">The description of the task currently being performed.</param>
    public void UpdateTask(string rebuildTask) => Dispatcher.Invoke(() => txbkCurrentTask.Text = rebuildTask);

    /// <summary>Updates the progress bar value on the UI thread.</summary>
    /// <param name="percentage">The completion percentage, from 0 to 100.</param>
    public void UpdateProgress(double percentage) => Dispatcher.Invoke(() => pbarProgress.Value = percentage);

    /// <summary>Updates the status label on the UI thread.</summary>
    /// <param name="rebuildStatus">The current status message to display.</param>
    public void UpdateStatus(string rebuildStatus) => Dispatcher.Invoke(() => txbkStatus.Text = rebuildStatus);

    /// <summary>Marks the rebuild as complete and reveals the close button on the UI thread.</summary>
    public void Complete() => Dispatcher.Invoke(() =>
    {
        txbkCurrentTask.Text = "Database rebuild complete!";
        txbkStatus.Text      = "You can now close this window.";
        pbarProgress.Value   = 100;
        btnClose.Visibility  = Visibility.Visible;
    });

    /// <summary>Restores the parent window and closes this window.</summary>
    private void CloseClick()
    {
        _parentWindow?.Show();

        Close();
    }

    /* EVENT HANDLERS */

    /// <summary>Handles the Close button click event.</summary>
    private void btnClose_Click(object sender, RoutedEventArgs e) => CloseClick();
}