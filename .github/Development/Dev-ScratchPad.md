/// <summary>
/// Entry class for processing TeleHealth reports.
/// </summary>
/// <remarks>
/// <para>
/// Processes TeleHealth Excel reports and converts them to JSON format.
/// </para>
/// <para>
/// This processor handles four types of reports:
/// <list type="bullet">
///     <item>Visit Stats - Summary and Meeting Errors</item>
///     <item>Visit Details - Meeting Details and Participant Details</item>
///     <item>Message Failure - Summary, SMS Stats, and Email Stats</item>
///     <item>Message Delivery - Message Delivery Stats</item>
/// </list>
/// </para>
/// </remarks>

    /// <summary>
    /// Processes Visit Stats reports with progress callback support.
    /// </summary>
    /// <param name="importDir">Directory containing source Excel files.</param>
    /// <param name="tmpDir">Temporary data directory.</param>
    /// <param name="statusCallback">Optional callback to report status messages.</param>



















        //internal static void Process(string importDir, string tmpDir)
    //{
    //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    //    Directory.CreateDirectory(tmpDir);

    //    ProcessWorkbook.VisitStats(importDir, tmpDir);
    //    ProcessWorkbook.VisitDetails(importDir, tmpDir);
    //    ProcessWorkbook.MessageFailure(importDir, tmpDir);
    //    ProcessWorkbook.MessageDelivery(importDir, tmpDir);
    //}