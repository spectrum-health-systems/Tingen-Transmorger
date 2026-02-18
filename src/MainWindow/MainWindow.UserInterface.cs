// 260212_code
// 260212_documentation


using System.Windows;
using System.Windows.Controls;

/* I've moved the MainWindow partial classes to MainWindow/ to keep the code organized, but I'm leaving the namespace as
 * TingenTransmorger instead of TingenTransmorger.MainWindow to avoid confusion with the MainWindow class.
 */
namespace TingenTransmorger;

/* Partial class MainWindow.UserInterface.cs.
 */
public partial class MainWindow : Window
{
    /// <summary>Setup the initial user interface so the right panel is blank.</summary>
    private void SetupInitialUi()
    {
        rbtnSearchByName.IsChecked                       = true;
        spnlPatientProviderDetailsComponents.Visibility  = Visibility.Collapsed;
        spnlMeetingComponents.Visibility                 = Visibility.Collapsed;
        spnlMeetingDetailsComponents.Visibility          = Visibility.Collapsed;
    }

    /// <summary>Clears user interface components.</summary>
    private void ClearUi()
    {
        txbxSearchBox.Text = string.Empty; // This will fire off the TextChanged event

        /* The lstbxSearchResults control is cleared in SearchTextChanged(), which avoids a weird loop with ClearUi().
         */
        //lstbxSearchResults.Items.Clear();

        spnlPatientProviderDetailsComponents.Visibility  = Visibility.Collapsed;
        spnlMeetingComponents.Visibility                 = Visibility.Collapsed;
        spnlMeetingDetailsComponents.Visibility          = Visibility.Collapsed;
    }

    private void ShowPhoneDetails()
    {
        var messageHistoryWindow = new Database.MessageHistoryWindow(_smsFailures, _smsDeliveries)
        {
            Owner = this
        };

        messageHistoryWindow.ShowDialog();
    }

    /// <summary>Updates the btnPhoneDetails button appearance based on SMS failure and delivery records.</summary>
    private void UpdatePhoneDetailsButton()
    {
        //////bool hasFailures   = _smsFailures.Count > 0;
        //////bool hasDeliveries = _smsDeliveries.Count > 0;

        //////btnPhoneDetails.IsEnabled = true;

        //////if (hasFailures && hasDeliveries)
        //////{
        //////    btnPhoneDetails.Background = System.Windows.Media.Brushes.Yellow;
        //////}
        //////else if (hasDeliveries)
        //////{
        //////    btnPhoneDetails.Background = System.Windows.Media.Brushes.Green;
        //////}
        //////else if (hasFailures)
        //////{
        //////    btnPhoneDetails.Background = System.Windows.Media.Brushes.Red;
        //////}
        //////else
        //////{
        //////    No records: gray background, disabled
        //////    btnPhoneDetails.Background = System.Windows.Media.Brushes.Gray;
        //////    btnPhoneDetails.IsEnabled = false;
        //////}
    }

    /// <summary>Updates the btnPhoneDetails button appearance based on SMS failure and delivery records.</summary>
    private void UpdatePhoneEmailDetailsButton(bool hasFailures, bool hasDeliveries, Button theButton)
    {
        //bool hasFailures   = _smsFailures.Count > 0;
        //bool hasDeliveries = _smsDeliveries.Count > 0;

        theButton.IsEnabled = true;

        if (hasFailures && hasDeliveries)
        {
            theButton.Background = System.Windows.Media.Brushes.Yellow;
        }
        else if (hasDeliveries)
        {
            theButton.Background = System.Windows.Media.Brushes.Green;
        }
        else if (hasFailures)
        {
            theButton.Background = System.Windows.Media.Brushes.Red;
        }
        else
        {
            // No records: gray background, disabled
            theButton.Background = System.Windows.Media.Brushes.Gray;
            theButton.IsEnabled = false;
        }
    }


    /// <summary>Handles the email details button click event.</summary>
    private void ShowEmailDetails()
    {
        var emailHistoryWindow = new Database.MessageHistoryWindow(_emailFailures, _emailDeliveries)
        {
            Owner = this
        };

        emailHistoryWindow.ShowDialog();
    }



    /// <summary>Updates the btnEmailDetails button appearance based on email failure and delivery records.</summary>
    private void UpdateEmailDetailsButton()
    {
        bool hasFailures = _emailFailures.Count > 0;
        bool hasDeliveries = _emailDeliveries.Count > 0;

        if (!hasFailures && !hasDeliveries)
        {
            // No records: gray background, disabled
            btnEmailDetails.Background = System.Windows.Media.Brushes.Gray;
            btnEmailDetails.IsEnabled = false;
        }
        else if (hasFailures && hasDeliveries)
        {
            // Both: yellow background, enabled
            btnEmailDetails.Background = System.Windows.Media.Brushes.Yellow;
            btnEmailDetails.IsEnabled = true;
        }
        else if (hasFailures)
        {
            // Only failures: red background, enabled
            btnEmailDetails.Background = System.Windows.Media.Brushes.Red;
            btnEmailDetails.IsEnabled = true;
        }
        else
        {
            // Only deliveries: green background, enabled
            btnEmailDetails.Background = System.Windows.Media.Brushes.Green;
            btnEmailDetails.IsEnabled = true;
        }
    }

    private void SetupPatientDetailUi(string patientName, string patientId)
    {

        lblPatientProviderKey.Content      = "PATIENT";
        lblPatientProviderNameValue.Content   = patientName;
        lblPatientProviderIdValue.Content     = patientId;
        spnlPatientProviderDetailsComponents.Visibility = Visibility.Visible;
        spnlPatientPhoneComponents.Visibility   = Visibility.Visible;
        spnlPatientEmailComponents.Visibility   = Visibility.Visible;
    }

    private void DisplaySomeDeets(string searchMode, string selectedItem)
    {
        var lastParenIndex = selectedItem.LastIndexOf('(');
        var name           = selectedItem.Substring(0, lastParenIndex).Trim();
        var id             = selectedItem.Substring(lastParenIndex + 1).TrimEnd(')').Trim();

        switch (btnSearchToggle.Content.ToString())
        {
            case "Patient Search":
                DisplayPatientDetails(name, id);
                break;

            case "Provider Search":
                DisplayProviderDetails(name, id);
                break;
        }
    }


    private void SetSearchToggleContent(string buttonContent)
    {
        switch (buttonContent)
        {
            case "Patient Search":
                btnSearchToggle.Content = "Provider Search";
                break;

            case "Provider Search":
                btnSearchToggle.Content = "Patient Search";
                break;
        }

        ClearUi();

    }


    /// <summary>Display search results..</summary>
    /// <remarks>
    ///     This method is called when the user types in the search text box. It filters and displays results based on
    ///     the current search mode and search type (by name or ID).
    /// </remarks>
    /// <param name="searchText">Contents of the search box.</param>
    private void DisplaySearchResults(string searchType, string searchText)
    {



        List<string> searchResults;

        if (searchType.Contains("patient", StringComparison.OrdinalIgnoreCase))
        {
            searchResults = rbtnSearchByName.IsChecked == true
                ? Database.SearchFor.PatientByName(searchText, TmDb)
                : Database.SearchFor.PatientById(searchText, TmDb);
        }
        else if (searchType.Contains("provider", StringComparison.OrdinalIgnoreCase))
        {
            searchResults =(rbtnSearchByName.IsChecked == true)
                ? Database.SearchFor.ProviderByName(searchText, TmDb)
                : Database.SearchFor.ProviderById(searchText, TmDb);
        }
        else
        {
            // Bad
            searchResults = new List<string>();
        }

        lstbxSearchResults.Items.Clear();

        foreach (string result in searchResults)
        {
            lstbxSearchResults.Items.Add(result);
        }
    }
}