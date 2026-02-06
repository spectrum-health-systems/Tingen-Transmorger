// 260206_code
// 260206_documentation

using System.IO;
using System.Text.Json;
using System.Windows;
using TingenTransmorger.Core;
using TingenTransmorger.Database;

namespace TingenTransmorger;

/// <summary>
/// Entry class for Tingen Transmorger.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// The Transmorger database.
    /// </summary>
    /// <remarks>
    /// Defined here so it can be used throughout the application.
    /// </remarks>
    public TransmorgerDatabase TransMorgDb { get; set; }

    /// <summary>
    /// Entry method for Tingen Transmorger.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        StartApp();
    }

    /// <summary>
    /// Starts the application.
    /// </summary>
    private void StartApp()
    {
        var config = Configuration.Load();

        Framework.Verify(config);

        if (config.Mode.Trim().ToLower() == "admin")
        {
            TeleHealthReport.ReportProcessor.Process(config.AdminDirectories["Import"], config.AdminDirectories["Tmp"]);
            TransmorgerDatabase.Build(config.AdminDirectories["Tmp"], config.StandardDirectories["MasterDb"]);
        }

        var localDbPath = Path.Combine(config.StandardDirectories["LocalDb"], "transmorger.db");

        TransMorgDb = TransmorgerDatabase.Load(localDbPath);

        rbtnByName.IsChecked = true;
        spnlPatientDetails.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    /// Stops the application.
    /// </summary>
    /// <param name="msgExit">
    /// An optional exit message to display to the user.
    /// </param>
    /// <remarks>
    /// <para>
    /// If you pass a message to <paramref name="msgExit"/>, it will be displayed to the user in a MessageBox before the
    /// application exits.
    /// </para>
    /// <para>This method is public because it is called from other methods outside the <see cref="MainWindow"/> class.</para>
    /// </remarks>
    public static void StopApp(string msgExit = "")
    {
        if (!string.IsNullOrEmpty(msgExit))
        {
            MessageBox.Show(msgExit, "Exiting Tingen Transmorger", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        Environment.Exit(0);
    }

    /*
     * EVENTS
     */

    /// <summary>The search toggle button was clicked.</summary>
    /// <remarks>
    /// <para>
    /// The search toggle button cycles through the three search modes:
    /// - Patient Search
    /// - Provider Search
    /// - Meeting Search.
    /// </para>
    /// <para>This method handles the click event for the search toggle button and updates the button's content accordingly.</para>
    /// </remarks>
    private void SearchToggleClicked()
    {
        switch (btnSearchToggle.Content)
        {
            case "Patient Search":
                btnSearchToggle.Content = "Provider Search";
                break;

            case "Provider Search":
                btnSearchToggle.Content = "Meeting Search";
                break;

            case "Meeting Search":
                btnSearchToggle.Content = "Patient Search";
                break;
        }

        // Clear search box and results when toggling
        txbxSearch.Text = string.Empty;
        lstbxSearchResults.Items.Clear();

        // Clear and hide details panel
        //txtDetailsPlaceholder.Visibility = Visibility.Visible;
        spnlPatientDetails.Visibility = Visibility.Collapsed;
    }

    /// <summary>Handles the search text changed event.</summary>
    /// <remarks>
    /// <para>
    /// This method is called when the user types in the search text box.
    /// It filters and displays results based on the current search mode and search type (by name or ID).
    /// </para>
    /// </remarks>
    private void SearchTextChanged()
    {
        // Clear previous results
        lstbxSearchResults.Items.Clear();

        // Only search for patients when in Patient Search mode
        if (btnSearchToggle.Content.ToString() != "Patient Search")
        {
            return;
        }

        var searchText = txbxSearch.Text?.Trim();

        // Don't search if text is empty or too short
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return;
        }

        // Get all patients from the database
        var allPatients = TransMorgDb.GetPatients();

        // Filter patients based on search type
        var filteredPatients = new List<(string PatientName, string PatientId)>();

        if (rbtnByName.IsChecked == true)
        {
            // Search by name - case insensitive
            filteredPatients = allPatients
                .Where(p => p.PatientName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.PatientName)
                .ToList();
        }
        else if (rbtnById.IsChecked == true)
        {
            // Search by ID
            filteredPatients = allPatients
                .Where(p => p.PatientId.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.PatientName)
                .ToList();
        }

        // Display results in the format "PatientName (PatientId)"
        foreach (var patient in filteredPatients)
        {
            lstbxSearchResults.Items.Add($"{patient.PatientName} ({patient.PatientId})");
        }
    }

    /// <summary>Handles the selection changed event for the search results list.</summary>
    /// <remarks>
    /// <para>
    /// This method is called when the user selects a patient from the search results.
    /// It retrieves the full patient details and displays them in the details panel.
    /// </para>
    /// </remarks>
    private void SearchResultSelected()
    {
        // Hide placeholder and show patient details section
        //txtDetailsPlaceholder.Visibility = Visibility.Collapsed;
        spnlPatientDetails.Visibility = Visibility.Visible;

        // Get the selected item
        var selectedItem = lstbxSearchResults.SelectedItem as string;
        if (string.IsNullOrWhiteSpace(selectedItem))
        {
            return;
        }

        // Parse the selected item to extract PatientName and PatientId
        // Format is "PatientName (PatientId)"
        var lastParenIndex = selectedItem.LastIndexOf('(');
        if (lastParenIndex == -1)
        {
            return;
        }

        var patientName = selectedItem.Substring(0, lastParenIndex).Trim();
        var patientId = selectedItem.Substring(lastParenIndex + 1).TrimEnd(')').Trim();

        // Get patient details from database
        var patientDetails = TransMorgDb.GetPatientDetails(patientName, patientId);
        if (patientDetails == null)
        {
            return;
        }

        // Display patient name and ID
        lblPatientNameValue.Content = patientName;
        lblPatientIdValue.Content = patientId;

        // Display phone numbers
        var phoneNumbers = new List<string>();
        if (patientDetails.Value.TryGetProperty("PhoneNumbers", out var phoneNumbersArray))
        {
            if (phoneNumbersArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var phoneEntry in phoneNumbersArray.EnumerateArray())
                {
                    if (phoneEntry.TryGetProperty("Number", out var numberElem))
                    {
                        var number = numberElem.GetString();
                        if (!string.IsNullOrWhiteSpace(number))
                        {
                            phoneNumbers.Add(number);
                        }
                    }
                }
            }
        }

        if (phoneNumbers.Count == 0)
        {
            phoneNumbers.Add("No phone numbers on file");
        }


        // Display email addresses
        var emailAddresses = new List<string>();
        if (patientDetails.Value.TryGetProperty("EmailAddresses", out var emailAddressesArray))
        {
            if (emailAddressesArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var emailEntry in emailAddressesArray.EnumerateArray())
                {
                    if (emailEntry.TryGetProperty("Address", out var addressElem))
                    {
                        var address = addressElem.GetString();
                        if (!string.IsNullOrWhiteSpace(address))
                        {
                            emailAddresses.Add(address);
                        }
                    }
                }
            }
        }

        if (emailAddresses.Count == 0)
        {
            emailAddresses.Add("No email addresses on file");
        }

    }

    /*
     * EVENT HANDLERS
     */
    private void btnSearchToggle_Click(object? sender, RoutedEventArgs e) => SearchToggleClicked();

    private void txbxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => SearchTextChanged();

    private void rbtnSearch_Checked(object sender, RoutedEventArgs e) => SearchTextChanged();

    private void lstbxSearchResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => SearchResultSelected();
}