// 260219_code
// 260219_documentation

using System.Windows;

namespace TingenTransmorger;

/* The MainWindow.Details partial class contains logic related to displaying details in the UI.
 */
public partial class MainWindow : Window
{
    private void DisplayDetails()
    {
        var selectedItem = lstbxSearchResults.SelectedItem as string;

        /* This is here so we don't try and get details when there are not search results.
        */
        if (lstbxSearchResults.Items.Count == 0)
        {
            return;
        }

        var lastParenIndex = selectedItem.LastIndexOf('(');
        var name           = selectedItem.Substring(0, lastParenIndex).Trim();
        var id             = selectedItem.Substring(lastParenIndex + 1).TrimEnd(')').Trim();

        if (btnSearchToggle.Content.ToString().Contains("patient", StringComparison.OrdinalIgnoreCase))
        {
            DisplayPatientDetails(name, id);
        }
        else if (btnSearchToggle.Content.ToString().Contains("provider", StringComparison.OrdinalIgnoreCase))
        {
            DisplayProviderDetails(name, id);
        }
    }
}