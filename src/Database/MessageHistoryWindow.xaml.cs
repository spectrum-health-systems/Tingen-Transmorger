// 260409_code
// 260409_documentation

/* The database namespace needs to be refactored */

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TingenTransmorger.Database;

/// <summary>Specifies the type of message history to display.</summary>
public enum MessageHistoryType
{
    SMS,
    Email
}

/// <summary>A window that displays the message delivery and failure history for a patient contact.</summary>
public partial class MessageHistoryWindow : Window
{
    private List<(string PhoneNumber, string ErrorMessage, string ScheduledStartTime)> _smsFailures;
    private List<(string PhoneNumber, string DeliveryStatus, string MessageType, string ErrorMessage, string DateSent, string TimeSent)> _messageDeliveries;
    private MessageHistoryType _messageType;

    /// <summary>Initializes a new instance of <see cref="MessageHistoryWindow"/> for SMS message history.</summary>
    /// <param name="smsFailures">The list of SMS delivery failures to display.</param>
    /// <param name="messageDeliveries">The list of SMS delivery records to display.</param>
    public MessageHistoryWindow(List<(string PhoneNumber, string ErrorMessage, string ScheduledStartTime)> smsFailures, List<(string PhoneNumber, string DeliveryStatus, string MessageType, string ErrorMessage, string DateSent, string TimeSent)> messageDeliveries)
    {
        InitializeComponent();
        _messageType = MessageHistoryType.SMS;
        ConfigureForMessageType();
        SetMessageData(smsFailures, messageDeliveries);
    }

    /// <summary>Initializes a new instance of <see cref="MessageHistoryWindow"/> for email message history.</summary>
    /// <param name="emailFailures">The list of email delivery failures to display.</param>
    /// <param name="emailDeliveries">The list of email delivery records to display.</param>
    /// <param name="messageType">The <see cref="MessageHistoryType"/> value identifying this as an email window.</param>
    public MessageHistoryWindow(List<(string EmailAddress, string ErrorMessage, string ScheduledStartTime)> emailFailures, List<(string EmailAddress, string DeliveryStatus, string MessageType, string ErrorMessage, string DateSent, string TimeSent)> emailDeliveries, MessageHistoryType messageType)
    {
        InitializeComponent();
        _messageType = messageType;
        ConfigureForMessageType();
        SetEmailData(emailFailures, emailDeliveries);
    }

    /// <summary>Handles the Copy All Successes button click event, copying only non-failure rows to the clipboard.</summary>
    private void btnCopyAllSuccessMessageHistory_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var items = dgMessages.Items.Cast<object>().Where(i => i != null).ToList();
            var successes = new List<MessageHistoryRow>();

            foreach (var item in items)
            {
                if (item is MessageHistoryRow mr)
                {
                    if (!string.Equals(mr.Type, "Failure", StringComparison.OrdinalIgnoreCase) && !string.Equals(mr.Status, "Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        successes.Add(mr);
                    }
                }
                else
                {
                    var t          = item.GetType();
                    var statusProp = t.GetProperty("Status");
                    var typeProp   = t.GetProperty("Type");
                    var statusVal  = statusProp?.GetValue(item)?.ToString() ?? string.Empty;
                    var typeVal    = typeProp?.GetValue(item)?.ToString() ?? string.Empty;

                    if (!string.Equals(typeVal, "Failure", StringComparison.OrdinalIgnoreCase) && !string.Equals(statusVal, "Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        successes.Add(new MessageHistoryRow
                        {
                            Sent              = t.GetProperty("Sent")?.GetValue(item)?.ToString() ?? string.Empty,
                            ScheduleStartTime = t.GetProperty("ScheduleStartTime")?.GetValue(item)?.ToString() ?? string.Empty,
                            Status            = statusVal,
                            MessageType       = t.GetProperty("MessageType")?.GetValue(item)?.ToString() ?? string.Empty,
                            ErrorDetails      = t.GetProperty("ErrorDetails")?.GetValue(item)?.ToString() ?? string.Empty,
                            PhoneNumber       = t.GetProperty("PhoneNumber")?.GetValue(item)?.ToString() ?? string.Empty,
                            Type              = typeVal,
                        });
                    }
                }
            }

            if (successes.Count == 0)
            {
                MessageBox.Show(this, "No success rows found to copy.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            var contactHeader = _messageType == MessageHistoryType.SMS ? "Phone Number" : "Email Address";
            var headerNames = new[] { "Sent / Start Time", "Status", "Message Type", "Error/Details", contactHeader, "Type" };
            var rowList = successes.Select(r => new[] {
                r.SentOrStartTime ?? string.Empty,
                r.Status ?? string.Empty,
                r.MessageType ?? string.Empty,
                r.ErrorDetails ?? string.Empty,
                (_messageType == MessageHistoryType.SMS ? r.PhoneNumber : r.EmailAddress) ?? string.Empty,
                r.Type ?? string.Empty
            }).ToList();

            var colCaps = new[] { 30, 20, 30, 120, 20, 15 };
            var widths = new int[headerNames.Length];
            for (int c = 0; c < headerNames.Length; c++)
            {
                int max = headerNames[c].Length;
                foreach (var r in rowList)
                    max = Math.Max(max, (r[c]?.Length) ?? 0);
                widths[c] = Math.Min(max, colCaps[c]);
            }

            static string Truncate(string s, int w)
            {
                if (s == null)
                    return string.Empty;
                if (s.Length <= w)
                    return s;
                if (w <= 3)
                    return s.Substring(0, w);
                return s.Substring(0, w - 3) + "...";
            }

            var sb = new StringBuilder();
            for (int c = 0; c < headerNames.Length; c++)
            {
                sb.Append(headerNames[c].PadRight(widths[c]));
                if (c < headerNames.Length - 1)
                    sb.Append("  ");
            }
            sb.AppendLine();

            foreach (var r in rowList)
            {
                for (int c = 0; c < r.Length; c++)
                {
                    var cell = Escape(Truncate(r[c] ?? string.Empty, widths[c]));
                    sb.Append(cell.PadRight(widths[c]));
                    if (c < r.Length - 1)
                        sb.Append("  ");
                }
                sb.AppendLine();
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show(this, "Success message history rows copied to clipboard.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to copy message history: {ex.Message}", "Copy Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    /// <summary>Handles the Copy All Errors button click event, copying only failure rows to the clipboard.</summary>
    private void btnCopyAllErrorMessageHistory_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var items = dgMessages.Items.Cast<object>().Where(i => i != null).ToList();
            var failures = new List<MessageHistoryRow>();

            foreach (var item in items)
            {
                if (item is MessageHistoryRow mr)
                {
                    if (string.Equals(mr.Type, "Failure", StringComparison.OrdinalIgnoreCase) || string.Equals(mr.Status, "Failed", StringComparison.OrdinalIgnoreCase))
                        failures.Add(mr);
                }
                else
                {
                    // try reflection fallback: look for Status or Type property
                    var t = item.GetType();
                    var statusProp = t.GetProperty("Status");
                    var typeProp = t.GetProperty("Type");
                    var statusVal = statusProp?.GetValue(item)?.ToString() ?? string.Empty;
                    var typeVal = typeProp?.GetValue(item)?.ToString() ?? string.Empty;
                    if (string.Equals(typeVal, "Failure", StringComparison.OrdinalIgnoreCase) || string.Equals(statusVal, "Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        // map reflected values into MessageHistoryRow minimally
                        failures.Add(new MessageHistoryRow
                        {
                            Sent = t.GetProperty("Sent")?.GetValue(item)?.ToString() ?? string.Empty,
                            ScheduleStartTime = t.GetProperty("ScheduleStartTime")?.GetValue(item)?.ToString() ?? string.Empty,
                            Status = statusVal,
                            MessageType = t.GetProperty("MessageType")?.GetValue(item)?.ToString() ?? string.Empty,
                            ErrorDetails = t.GetProperty("ErrorDetails")?.GetValue(item)?.ToString() ?? string.Empty,
                            PhoneNumber = t.GetProperty("PhoneNumber")?.GetValue(item)?.ToString() ?? string.Empty,
                            Type = typeVal,
                        });
                    }
                }
            }

            if (failures.Count == 0)
            {
                MessageBox.Show(this, "No failure rows found to copy.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var contactHeader = _messageType == MessageHistoryType.SMS ? "Phone Number" : "Email Address";
            var headerNames = new[] { "Sent / Start Time", "Status", "Message Type", "Error/Details", contactHeader, "Type" };
            var rowList = failures.Select(r => new[] {
                r.SentOrStartTime ?? string.Empty,
                r.Status ?? string.Empty,
                r.MessageType ?? string.Empty,
                r.ErrorDetails ?? string.Empty,
                (_messageType == MessageHistoryType.SMS ? r.PhoneNumber : r.EmailAddress) ?? string.Empty,
                r.Type ?? string.Empty
            }).ToList();

            var colCaps = new[] { 30, 20, 30, 120, 20, 15 };
            var widths = new int[headerNames.Length];
            for (int c = 0; c < headerNames.Length; c++)
            {
                int max = headerNames[c].Length;
                foreach (var r in rowList)
                    max = Math.Max(max, (r[c]?.Length) ?? 0);
                widths[c] = Math.Min(max, colCaps[c]);
            }

            static string Truncate(string s, int w)
            {
                if (s == null)
                    return string.Empty;
                if (s.Length <= w)
                    return s;
                if (w <= 3)
                    return s.Substring(0, w);
                return s.Substring(0, w - 3) + "...";
            }

            var sb = new StringBuilder();
            for (int c = 0; c < headerNames.Length; c++)
            {
                sb.Append(headerNames[c].PadRight(widths[c]));
                if (c < headerNames.Length - 1)
                    sb.Append("  ");
            }
            sb.AppendLine();

            foreach (var r in rowList)
            {
                for (int c = 0; c < r.Length; c++)
                {
                    var cell = Escape(Truncate(r[c] ?? string.Empty, widths[c]));
                    sb.Append(cell.PadRight(widths[c]));
                    if (c < r.Length - 1)
                        sb.Append("  ");
                }
                sb.AppendLine();
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show(this, "Failure message history rows copied to clipboard.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to copy message history: {ex.Message}", "Copy Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    /// <summary>Handles the Copy Top Ten button click event, copying the first ten rows to the clipboard.</summary>
    private void btnCopyTopTenMessageHistory_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var items = dgMessages.Items.Cast<object>().Where(i => i != null).Take(10).ToList();

            var contactHeader = _messageType == MessageHistoryType.SMS ? "Phone Number" : "Email Address";
            var headerNames = new[] { "Sent / Start Time", "Status", "Message Type", "Error/Details", contactHeader, "Type" };
            var rowList = new List<string[]>();

            foreach (var item in items)
            {
                if (item is MessageHistoryRow mr)
                {
                    rowList.Add(new[] {
                        mr.SentOrStartTime ?? string.Empty,
                        mr.Status ?? string.Empty,
                        mr.MessageType ?? string.Empty,
                        mr.ErrorDetails ?? string.Empty,
                        (_messageType == MessageHistoryType.SMS ? mr.PhoneNumber : mr.EmailAddress) ?? string.Empty,
                        mr.Type ?? string.Empty
                    });
                }
                else
                {
                    var values = new List<string>();
                    foreach (var col in dgMessages.Columns)
                    {
                        if (col is DataGridBoundColumn boundColumn && boundColumn.Binding is System.Windows.Data.Binding binding && !string.IsNullOrEmpty(binding.Path?.Path))
                        {
                            var prop = item.GetType().GetProperty(binding.Path.Path);
                            var val = prop?.GetValue(item)?.ToString() ?? string.Empty;
                            values.Add(val);
                        }
                        else
                        {
                            values.Add(item.ToString() ?? string.Empty);
                        }
                    }
                    rowList.Add(values.ToArray());
                }
            }

            if (rowList.Count == 0)
            {
                Clipboard.SetText(string.Empty);
                MessageBox.Show(this, "No message history rows to copy.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var colCaps = new[] { 30, 20, 30, 120, 20, 15 };
            var widths = new int[headerNames.Length];
            for (int c = 0; c < headerNames.Length; c++)
            {
                int max = headerNames[c].Length;
                foreach (var r in rowList)
                    max = Math.Max(max, (r[c]?.Length) ?? 0);
                widths[c] = Math.Min(max, colCaps[c]);
            }

            static string Truncate(string s, int w)
            {
                if (s == null)
                    return string.Empty;
                if (s.Length <= w)
                    return s;
                if (w <= 3)
                    return s.Substring(0, w);
                return s.Substring(0, w - 3) + "...";
            }

            var sb = new StringBuilder();
            for (int c = 0; c < headerNames.Length; c++)
            {
                sb.Append(headerNames[c].PadRight(widths[c]));
                if (c < headerNames.Length - 1)
                    sb.Append("  ");
            }
            sb.AppendLine();

            foreach (var r in rowList)
            {
                for (int c = 0; c < r.Length; c++)
                {
                    var cell = Escape(Truncate(r[c] ?? string.Empty, widths[c]));
                    sb.Append(cell.PadRight(widths[c]));
                    if (c < r.Length - 1)
                        sb.Append("  ");
                }
                sb.AppendLine();
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show(this, "Top 10 message history rows copied to clipboard.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to copy message history: {ex.Message}", "Copy Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    /// <summary>Configures the window title, label, and contact column header to match the current message type.</summary>
    private void ConfigureForMessageType()
    {
        Title = _messageType == MessageHistoryType.SMS ? "SMS Message History" : "Email Message History";

        lblMessageHistoryTitle.Content = _messageType == MessageHistoryType.SMS ? "Message History - Phone" : "Message History - Email";

        var contactColumn = dgMessages.Columns[4] as DataGridTextColumn; // Phone Number / Email Address column
        if (contactColumn != null)
        {
            contactColumn.Header = _messageType == MessageHistoryType.SMS ? "Phone Number" : "Email Address";
            contactColumn.Binding = new System.Windows.Data.Binding(_messageType == MessageHistoryType.SMS ? "PhoneNumber" : "EmailAddress");
        }
    }

    /// <summary>Populates the message grid with combined SMS failure and delivery records, sorted by descending timestamp.</summary>
    /// <param name="smsFailures">The list of SMS delivery failures.</param>
    /// <param name="messageDeliveries">The list of SMS delivery records.</param>
    public void SetMessageData(
        List<(string PhoneNumber, string ErrorMessage, string ScheduledStartTime)> smsFailures,
        List<(string PhoneNumber, string DeliveryStatus, string MessageType, string ErrorMessage, string DateSent, string TimeSent)> messageDeliveries)
    {
        _smsFailures = smsFailures;
        _messageDeliveries = messageDeliveries;

        var combinedMessages = new List<MessageHistoryRow>();

        foreach (var failure in smsFailures)
        {
            var formattedStartTime = FormatStartTime(failure.ScheduledStartTime);

            var isOptedOut = !string.IsNullOrWhiteSpace(failure.ErrorMessage)
                && (failure.ErrorMessage.Contains("is opted out", StringComparison.OrdinalIgnoreCase)
                    || failure.ErrorMessage.Contains("opted out", StringComparison.OrdinalIgnoreCase)
                    || failure.ErrorMessage.Contains("opt-out", StringComparison.OrdinalIgnoreCase));

            combinedMessages.Add(new MessageHistoryRow
            {
                IsFailure = true,
                Sent = "---",
                ScheduleStartTime = FormatStartTime(formattedStartTime),
                Status = "Failed",
                MessageType = "SMS",
                ErrorDetails = isOptedOut ? "Opted out" : FormatErrorDetails(failure.ErrorMessage),
                PhoneNumber = failure.PhoneNumber ?? string.Empty,
                EmailAddress = string.Empty,
                Type = "Failure",
                SortTimestamp = ParseTimestamp(failure.ScheduledStartTime)
            });
        }

        foreach (var delivery in messageDeliveries)
        {
            var sent = CombineDateAndTime(delivery.DateSent, delivery.TimeSent);
            var formattedSent = FormatStartTime(sent);

            combinedMessages.Add(new MessageHistoryRow
            {
                IsFailure = false,
                Sent = formattedSent,
                ScheduleStartTime = "---", // Show --- for successful deliveries
                Status = delivery.DeliveryStatus ?? string.Empty,
                MessageType = delivery.MessageType ?? string.Empty,
                ErrorDetails = FormatErrorDetails(delivery.ErrorMessage),
                PhoneNumber = delivery.PhoneNumber ?? string.Empty,
                EmailAddress = string.Empty,
                Type = "Delivery",
                SortTimestamp = ParseTimestamp(sent)
            });
        }

        var sortedMessages = combinedMessages
            .OrderByDescending(m => m.SortTimestamp)
            .ToList();

        dgMessages.ItemsSource = sortedMessages;
        UpdateSummary(sortedMessages);
    }

    /// <summary>Populates the message grid with combined email failure and delivery records, sorted by descending timestamp.</summary>
    /// <param name="emailFailures">The list of email delivery failures.</param>
    /// <param name="emailDeliveries">The list of email delivery records.</param>
    public void SetEmailData(
        List<(string EmailAddress, string ErrorMessage, string ScheduledStartTime)> emailFailures,
        List<(string EmailAddress, string DeliveryStatus, string MessageType, string ErrorMessage, string DateSent, string TimeSent)> emailDeliveries)
    {
        _smsFailures = null;
        _messageDeliveries = null;

        var combinedMessages = new List<MessageHistoryRow>();

        foreach (var failure in emailFailures)
        {
            var formattedStartTime = FormatStartTime(failure.ScheduledStartTime);

            combinedMessages.Add(new MessageHistoryRow
            {
                IsFailure = true,
                Sent = "---",
                ScheduleStartTime = FormatStartTime(formattedStartTime),
                Status = "Failed",
                MessageType = "Email",
                ErrorDetails = FormatErrorDetails(failure.ErrorMessage),
                PhoneNumber = string.Empty,
                EmailAddress = failure.EmailAddress ?? string.Empty,
                Type = "Failure",
                SortTimestamp = ParseTimestamp(failure.ScheduledStartTime)
            });
        }

        foreach (var delivery in emailDeliveries)
        {
            var sent = CombineDateAndTime(delivery.DateSent, delivery.TimeSent);
            var formattedSent = FormatStartTime(sent);

            combinedMessages.Add(new MessageHistoryRow
            {
                IsFailure = false,
                Sent = formattedSent,
                ScheduleStartTime = "---",
                Status = delivery.DeliveryStatus ?? string.Empty,
                MessageType = delivery.MessageType ?? string.Empty,
                ErrorDetails = FormatErrorDetails(delivery.ErrorMessage),
                PhoneNumber = string.Empty,
                EmailAddress = delivery.EmailAddress ?? string.Empty,
                Type = "Delivery",
                SortTimestamp = ParseTimestamp(sent)
            });
        }

        var sortedMessages = combinedMessages
            .OrderByDescending(m => m.SortTimestamp)
            .ToList();

        dgMessages.ItemsSource = sortedMessages;
        UpdateSummary(sortedMessages);
    }

    /// <summary>Updates the summary text block with total, success, and failure counts.</summary>
    /// <param name="messages">The full list of message rows currently displayed.</param>
    private void UpdateSummary(List<MessageHistoryRow> messages)
    {
        try
        {
            var total = messages.Count;
            var failures = messages.Count(m => m.IsFailure);
            var successes = total - failures;

            txbkMessageSummary.Inlines.Clear();
            txbkMessageSummary.Inlines.Add(new Run(total.ToString()) { Foreground = Brushes.Black, FontWeight = FontWeights.SemiBold });
            txbkMessageSummary.Inlines.Add(new Run(" Total messages / ") { Foreground = Brushes.Black });
            txbkMessageSummary.Inlines.Add(new Run(successes.ToString()) { Foreground = Brushes.Green, FontWeight = FontWeights.SemiBold });
            txbkMessageSummary.Inlines.Add(new Run(" Successful / ") { Foreground = Brushes.Green });
            txbkMessageSummary.Inlines.Add(new Run(failures.ToString()) { Foreground = Brushes.Red, FontWeight = FontWeights.SemiBold });
            txbkMessageSummary.Inlines.Add(new Run(" Failures") { Foreground = Brushes.Red });
        }
        catch
        {
            // ignore if UI element not available or count fails
        }
    }

    /// <summary>Handles the Close button click event.</summary>
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    /// <summary>Combines separate date and time strings into a single datetime string.</summary>
    /// <param name="date">The date portion.</param>
    /// <param name="time">The time portion.</param>
    /// <returns>A combined date-time string, or just the date if <paramref name="time"/> is empty.</returns>
    private string CombineDateAndTime(string? date, string? time)
    {
        if (string.IsNullOrWhiteSpace(date))
            return string.Empty;

        if (string.IsNullOrWhiteSpace(time))
            return date;

        return $"{date} {time}";
    }

    /// <summary>Parses a timestamp string into a <see cref="DateTime"/> for sorting.</summary>
    /// <param name="timestamp">The timestamp string to parse.</param>
    /// <returns>The parsed <see cref="DateTime"/>, or <see cref="DateTime.MinValue"/> if parsing fails.</returns>
    private DateTime ParseTimestamp(string timestamp)
    {
        if (string.IsNullOrWhiteSpace(timestamp))
            return DateTime.MinValue;

        if (DateTime.TryParse(timestamp, out var result))
            return result;

        return DateTime.MinValue;
    }

    /// <summary>Formats a datetime string for display in the grid.</summary>
    /// <param name="startTime">The raw datetime string to format.</param>
    /// <returns>A formatted string in <c>MM/dd/yy hh:mm tt</c> form, or <c>---</c> if the value is empty or unparseable.</returns>
    private string FormatStartTime(string? startTime)
    {
        if (string.IsNullOrWhiteSpace(startTime))
            return "---";

        if (DateTime.TryParse(startTime, out var dt))
        {
            return dt.ToString("MM/dd/yy hh:mm tt");
        }

        return string.IsNullOrWhiteSpace(startTime) ? "---" : startTime;
    }

    /// <summary>Normalizes an error details string for display, replacing empty or placeholder values with <c>---</c>.</summary>
    /// <param name="errorDetails">The raw error details string.</param>
    /// <returns>The original string, or <c>---</c> if the value is empty or an empty JSON object.</returns>
    private string FormatErrorDetails(string? errorDetails)
    {
        if (string.IsNullOrWhiteSpace(errorDetails))
            return "---";

        if (errorDetails.Trim() == "{}")
            return "---";

        return errorDetails;
    }

    /// <summary>Handles the Copy All button click event, copying all message rows to the clipboard as formatted text.</summary>
    private void btnCopyAllMessageHistory_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgMessages.ItemsSource is IEnumerable<MessageHistoryRow> rows)
            {
                var contactHeader = _messageType == MessageHistoryType.SMS ? "Phone Number" : "Email Address";
                var headerNames = new[] { "Sent / Start Time", "Status", "Message Type", "Error/Details", contactHeader, "Type" };

                var rowList = rows.Select(r => new[] {
                    r.SentOrStartTime ?? string.Empty,
                    r.Status ?? string.Empty,
                    r.MessageType ?? string.Empty,
                    r.ErrorDetails ?? string.Empty,
                    (_messageType == MessageHistoryType.SMS ? r.PhoneNumber : r.EmailAddress) ?? string.Empty,
                    r.Type ?? string.Empty
                }).ToList();

                var colCaps = new[] { 30, 20, 30, 120, 20, 15 };

                var widths = new int[headerNames.Length];
                for (int c = 0; c < headerNames.Length; c++)
                {
                    int max = headerNames[c].Length;
                    foreach (var r in rowList)
                        max = Math.Max(max, (r[c]?.Length) ?? 0);
                    widths[c] = Math.Min(max, colCaps[c]);
                }

                static string Truncate(string s, int w)
                {
                    if (s == null)
                        return string.Empty;
                    if (s.Length <= w)
                        return s;
                    if (w <= 3)
                        return s.Substring(0, w);
                    return s.Substring(0, w - 3) + "...";
                }

                var sb = new StringBuilder();

                // Header line
                for (int c = 0; c < headerNames.Length; c++)
                {
                    sb.Append(headerNames[c].PadRight(widths[c]));
                    if (c < headerNames.Length - 1)
                        sb.Append("  ");
                }
                sb.AppendLine();

                foreach (var r in rowList)
                {
                    for (int c = 0; c < r.Length; c++)
                    {
                        var cell = Escape(Truncate(r[c] ?? string.Empty, widths[c]));
                        sb.Append(cell.PadRight(widths[c]));
                        if (c < r.Length - 1)
                            sb.Append("  ");
                    }
                    sb.AppendLine();
                }

                Clipboard.SetText(sb.ToString());
                MessageBox.Show(this, "Message history copied to clipboard.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var headerCols = dgMessages.Columns.Select(c => c.Header?.ToString() ?? string.Empty).ToArray();
            var valuesMatrix = new List<string[]>();
            foreach (var item in dgMessages.Items)
            {
                if (item == null)
                    continue;

                var values = new List<string>();
                foreach (var col in dgMessages.Columns)
                {
                    if (col is DataGridBoundColumn boundColumn && boundColumn.Binding is System.Windows.Data.Binding binding && !string.IsNullOrEmpty(binding.Path?.Path))
                    {
                        var prop = item.GetType().GetProperty(binding.Path.Path);
                        var val = prop?.GetValue(item)?.ToString() ?? string.Empty;
                        values.Add(val);
                    }
                    else
                    {
                        values.Add(item.ToString() ?? string.Empty);
                    }
                }
                valuesMatrix.Add(values.ToArray());
            }

            if (headerCols.Length == 0)
            {
                Clipboard.SetText(string.Empty);
                return;
            }

            var widths2 = new int[headerCols.Length];
            for (int c = 0; c < headerCols.Length; c++)
            {
                int max = headerCols[c].Length;
                foreach (var r in valuesMatrix)
                    max = Math.Max(max, (r[c]?.Length) ?? 0);
                // apply some generic caps
                int cap = 120;
                if (c == 0)
                    cap = 30; // time
                if (c == headerCols.Length - 1)
                    cap = 15; // type
                if (c == headerCols.Length - 2)
                    cap = 20; // phone
                widths2[c] = Math.Min(max, cap);
            }

            var sbFallback = new StringBuilder();
            for (int c = 0; c < headerCols.Length; c++)
            {
                sbFallback.Append(headerCols[c].PadRight(widths2[c]));
                if (c < headerCols.Length - 1)
                    sbFallback.Append("  ");
            }
            sbFallback.AppendLine();

            foreach (var r in valuesMatrix)
            {
                for (int c = 0; c < r.Length; c++)
                {
                    var cell = Escape(r[c] ?? string.Empty);
                    var truncated = cell.Length > widths2[c] ? cell.Substring(0, widths2[c] - 3) + "..." : cell;
                    sbFallback.Append(truncated.PadRight(widths2[c]));
                    if (c < r.Length - 1)
                        sbFallback.Append("  ");
                }
                sbFallback.AppendLine();
            }

            Clipboard.SetText(sbFallback.ToString());
            MessageBox.Show(this, "Message history copied to clipboard.", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Failed to copy message history: {ex.Message}", "Copy Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    /// <summary>Replaces tab, carriage-return, and newline characters with spaces to make a string safe for clipboard output.</summary>
    /// <param name="s">The string to escape.</param>
    /// <returns>The escaped string, or <see cref="string.Empty"/> if the input is null or empty.</returns>
    private static string Escape(string? s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        return s.Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
    }
}

/// <summary>Represents a single row in the message history grid.</summary>
public class MessageHistoryRow
{
    /// <summary>Gets or sets a value indicating whether this row represents a delivery failure.</summary>
    public bool IsFailure { get; set; }
    /// <summary>Gets or sets the formatted sent datetime, or <c>---</c> for failure rows.</summary>
    public string Sent { get; set; } = string.Empty;
    /// <summary>Gets or sets the formatted scheduled start time, or <c>---</c> for delivery rows.</summary>
    public string ScheduleStartTime { get; set; } = string.Empty;
    /// <summary>Gets or sets the delivery status.</summary>
    public string Status { get; set; } = string.Empty;
    /// <summary>Gets or sets the message type (e.g. SMS or Email).</summary>
    public string MessageType { get; set; } = string.Empty;
    /// <summary>Gets or sets the error or details text, or <c>---</c> if none.</summary>
    public string ErrorDetails { get; set; } = string.Empty;
    /// <summary>Gets or sets the recipient phone number.</summary>
    public string PhoneNumber { get; set; } = string.Empty;
    /// <summary>Gets or sets the recipient email address.</summary>
    public string EmailAddress { get; set; } = string.Empty;
    /// <summary>Gets or sets whether this row represents a failure or a delivery.</summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>Gets or sets the timestamp used to sort rows in descending order.</summary>
    public DateTime SortTimestamp { get; set; }

    /// <summary>Gets the best available timestamp string for display: the sent time if present, otherwise the scheduled start time.</summary>
    public string SentOrStartTime =>
        !string.IsNullOrWhiteSpace(Sent) && Sent != "---"
            ? Sent
            : (string.IsNullOrWhiteSpace(ScheduleStartTime) ? "---" : ScheduleStartTime);
}
