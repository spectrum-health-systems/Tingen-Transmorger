// 260212_code
// 260212_documentation

namespace TingenTransmorger.Database;

/// <summary>Database searches.</summary>
internal static class SearchFor
{
    /// <summary>Patient/provider search.</summary>
    /// <param name="searchType">The type of search.</param>
    /// <param name="searchText">The text to search for.</param>
    /// <param name="tmDb">The Transmorger database instance.</param>
    /// <param name="searchByName">Indicates whether to search by name (true) or ID (false).</param>
    internal static List<string> PatientOrProvider(string searchType, string searchText, TransmorgerDatabase tmDb, bool searchByName)
    {
        //TODO: Find a way to do this without passing the entire database.
        List<(string name, string id)> allPeople = searchType == "Patient Search"
            ? tmDb.GetPatients()
            : tmDb.GetProviders();

        var nameAndId = new List<(string name, string id)>();

        nameAndId = searchByName
            ? [.. allPeople.Where(p => p.name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.name)]
            : [.. allPeople.Where(p => p.id.Contains(searchText, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.name)];

        List<string> resultList = [];

        foreach (var (name, id) in nameAndId)
        {
            resultList.Add($"{name} ({id})");
        }

        return resultList;
    }
}