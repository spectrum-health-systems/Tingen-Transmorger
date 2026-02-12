// 260212_code
// 260212_documentation

using System.Windows;
using TingenTransmorger.Core;
using TingenTransmorger.Database;

/* I've moved the MainWindow partial classes to MainWindow/ to keep the code organized, but I'm leaving the namespace as
 * TingenTransmorger instead of TingenTransmorger.MainWindow to avoid confusion with the MainWindow class.
 */
namespace TingenTransmorger;

/// <summary>Admin mode logic.</summary>
/// <remarks>This is a partial class that handles the admin mode functionality of the MainWindow.</remarks>
public partial class MainWindow : Window
{
    /// <summary>Handles admin mode operations. </summary>
    /// <remarks>Currently admin mode is focused on rebuilding the Transmorger database.</remarks>
    /// <param name="config">The Transmorger configuration object.</param>
    /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if the database
    /// rebuild was initiated; otherwise, <see langword="false"/> if the user declined to proceed.</returns>
    private async Task<bool> EnterAdminMode(string importDir, string tmpDirImport, string masterDbDir)
    {
        SetAdminModeTheme();
        Hide();

        var msgboxContent                = Catalog.msgbox_DatabaseRebuildCheck();
        MessageBoxResult rebuildResponse = MessageBox.Show(msgboxContent[1], msgboxContent[0], MessageBoxButton.YesNo, MessageBoxImage.Error);

        if (rebuildResponse == MessageBoxResult.No)
        {
            MainWindow.StopApp();
        }

        ////// Show the rebuild window
        //var rebuildWindow = new DatabaseRebuildWindow();
        //rebuildWindow.SetParentWindow(this);
        //rebuildWindow.Show();

        return await TransmorgerDatabase.Rebuild(importDir, tmpDirImport, masterDbDir, this);

    }


    //////private async Task<bool> RebuildDatabase(string importDir, string tmpDir, string masterDbDir)
    //////{

    //////    // Show the rebuild window
    //////    var rebuildWindow = new DatabaseRebuildWindow();
    //////    rebuildWindow.SetParentWindow(this);
    //////    rebuildWindow.Show();

    //////    // Run rebuild on background thread
    //////    await Task.Run(() =>
    //////    {
    //////        // Process reports with progress updates
    //////        rebuildWindow.UpdateTask("Processing VisitStats workbooks...");
    //////        rebuildWindow.UpdateProgress(10);
    //////        TeleHealthReport.ReportProcessor.ProcessVisitStats(importDir, tmpDir, (status) => rebuildWindow.UpdateStatus(status));

    //////        rebuildWindow.UpdateTask("Processing VisitDetails workbooks...");
    //////        rebuildWindow.UpdateProgress(30);
    //////        TeleHealthReport.ReportProcessor.ProcessVisitDetails(importDir, tmpDir, (status) => rebuildWindow.UpdateStatus(status));

    //////        rebuildWindow.UpdateTask("Processing MessageFailure workbooks...");
    //////        rebuildWindow.UpdateProgress(50);
    //////        TeleHealthReport.ReportProcessor.ProcessMessageFailure(importDir, tmpDir, (status) => rebuildWindow.UpdateStatus(status));

    //////        rebuildWindow.UpdateTask("Processing MessageDelivery workbooks...");
    //////        rebuildWindow.UpdateProgress(70);
    //////        TeleHealthReport.ReportProcessor.ProcessMessageDelivery(importDir, tmpDir, (status) => rebuildWindow.UpdateStatus(status));

    //////        rebuildWindow.UpdateTask("Building Transmorger database...");
    //////        rebuildWindow.UpdateProgress(90);
    //////        TransmorgerDatabase.Build(tmpDir, masterDbDir);

    //////        rebuildWindow.Complete();
    //////    });
    //////    return true;
    //////}

    /// <summary>Sets the theme for admin mode.</summary>
    private void SetAdminModeTheme()
    {
        this.Background = System.Windows.Media.Brushes.Red;
    }



}
