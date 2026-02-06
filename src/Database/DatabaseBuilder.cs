using System.Text.Json;

namespace TingenTransmorger.Database;

internal static class DatabaseBuilder
{
    public static void Build(string tmpDir, string masterDbDir)
    {
        // Read cached JSON files
        var participantDetails = JsonFileReader.ReadJsonList(tmpDir, "Visit_Details-Participant_Details.json");
        var meetingDetails = JsonFileReader.ReadJsonList(tmpDir, "Visit_Details-Meeting_Details.json");
        var messageDeliveryStats = JsonFileReader.ReadJsonList(tmpDir, "Message_Delivery-Message_Delivery_Stats.json");

        var patients = PatientsBuilder.Build(tmpDir, participantDetails, messageDeliveryStats);
        var providers = ProvidersBuilder.Build(tmpDir, participantDetails, meetingDetails);

        var database = new Dictionary<string, object?>
        {
            ["Summary"] = SummaryBuilder.Build(tmpDir),
            ["Patients"] = patients,
            ["Providers"] = providers,
            ["MeetingDetail"] = MeetingDetailBuilder.Build(tmpDir, meetingDetails, patients, providers),
            ["MeetingError"] = MeetingErrorBuilder.Build(tmpDir, patients, providers),
        };

        JsonFileReader.WriteDatabaseFiles(tmpDir, masterDbDir, database);
    }
}
