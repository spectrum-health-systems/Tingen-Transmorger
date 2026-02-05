using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TingenTransmorger.Database;
/// <summary>
/// Interaction logic for DatabaseSummaryWindow.xaml
/// </summary>
public partial class DatabaseSummaryWindow : Window
{
    private readonly TransmorgerDatabase? _db;

    public DatabaseSummaryWindow(TransmorgerDatabase? db = null)
    {
        InitializeComponent();
        _db = db;

        // If database provided, populate the panels
        if (_db != null)
        {
            PopulateSummaries();
        }
    }

    private void PopulateSummaries()
    {
        try
        {
            var visitJson = _db.GetSummaryVisitStatsJson();
            var mfJson = _db.GetSummaryMessageFailureJson();

            if (!string.IsNullOrWhiteSpace(visitJson))
            {
                var doc = System.Text.Json.JsonDocument.Parse(visitJson);
                pnlVisitStats.Children.Clear();
                AddJsonObjectToPanel(doc.RootElement, pnlVisitStats);
            }

            if (!string.IsNullOrWhiteSpace(mfJson))
            {
                var doc = System.Text.Json.JsonDocument.Parse(mfJson);
                pnlMessageFailure.Children.Clear();
                AddJsonObjectToPanel(doc.RootElement, pnlMessageFailure);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load summaries: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void AddJsonObjectToPanel(System.Text.Json.JsonElement element, Panel panel)
    {
        if (element.ValueKind != System.Text.Json.JsonValueKind.Object)
        {
            return;
        }

        foreach (var prop in element.EnumerateObject())
        {
            // If value is primitive, display label + value
            if (prop.Value.ValueKind == System.Text.Json.JsonValueKind.String || prop.Value.ValueKind == System.Text.Json.JsonValueKind.Number || prop.Value.ValueKind == System.Text.Json.JsonValueKind.True || prop.Value.ValueKind == System.Text.Json.JsonValueKind.False || prop.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
            {
                var grid = new Grid { Margin = new Thickness(0, 4, 0, 4) };
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(220) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                var lbl = new TextBlock { Text = prop.Name + ":", FontWeight = FontWeights.SemiBold, VerticalAlignment = VerticalAlignment.Center };
                Grid.SetColumn(lbl, 0);
                grid.Children.Add(lbl);

                var val = prop.Value.ValueKind == System.Text.Json.JsonValueKind.String ? prop.Value.GetString() : prop.Value.GetRawText();
                var tb = new TextBox { Text = val ?? string.Empty, IsReadOnly = true, BorderThickness = new Thickness(0), Background = Brushes.Transparent };
                Grid.SetColumn(tb, 1);
                grid.Children.Add(tb);

                panel.Children.Add(grid);
            }
            else if (prop.Value.ValueKind == System.Text.Json.JsonValueKind.Object)
            {
                var header = new TextBlock { Text = prop.Name, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 8, 0, 4) };
                panel.Children.Add(header);
                var inner = new StackPanel { Margin = new Thickness(8, 0, 0, 0) };
                panel.Children.Add(inner);
                AddJsonObjectToPanel(prop.Value, inner);
            }
            else if (prop.Value.ValueKind == System.Text.Json.JsonValueKind.Array)
            {
                var header = new TextBlock { Text = prop.Name + " (array)", FontWeight = FontWeights.Bold, Margin = new Thickness(0, 8, 0, 4) };
                panel.Children.Add(header);
                var inner = new StackPanel { Margin = new Thickness(8, 0, 0, 0) };
                panel.Children.Add(inner);
                int i = 0;
                foreach (var item in prop.Value.EnumerateArray())
                {
                    if (item.ValueKind == System.Text.Json.JsonValueKind.Object)
                    {
                        AddJsonObjectToPanel(item, inner);
                    }
                    else
                    {
                        var tb = new TextBlock { Text = item.GetRawText(), Margin = new Thickness(0, 2, 0, 2) };
                        inner.Children.Add(tb);
                    }
                    i++;
                }
            }
        }
    }
}
