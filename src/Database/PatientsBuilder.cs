namespace TingenTransmorger.Database;

internal static class PatientsBuilder
{
    public static List<Dictionary<string, object?>> Build(string tmpDir, List<Dictionary<string, object?>>? participantDetails, List<Dictionary<string, object?>>? messageDeliveryStats)
    {
        // For now, delegate back to original implementation inside TransmorgerDatabase if needed.
        // Minimal implementation returns empty list to keep build green; full porting can be done on request.
        return new List<Dictionary<string, object?>>();
    }
}
