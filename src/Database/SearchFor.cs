// 260212_code
// 260409_documentation

/* The database namespace needs to be refactored */

namespace TingenTransmorger.Database;

/// <summary>Provides methods for searching patients and providers in the Transmorger database.</summary>
internal static class SearchFor
{
    /// <summary>Searches for patients whose name contains the specified text.</summary>
    /// <param name="searchText">The text to search for within patient names.</param>
    /// <param name="tmDb">The database instance to search.</param>
    /// <returns>A list of matching patient entries formatted as <c>Name (Id)</c>, sorted by name.</returns>
    internal static List<string> PatientByName(string searchText, TransmorgerDatabase tmDb)
    {
        //TODO: Find a way to do this without passing the entire database.
        List<(string name, string id)> allEntries = tmDb.GetPatients();

        return SearchResult(searchText, allEntries, true);
    }

    /// <summary>Searches for patients whose ID contains the specified text.</summary>
    /// <param name="searchText">The text to search for within patient IDs.</param>
    /// <param name="tmDb">The database instance to search.</param>
    /// <returns>A list of matching patient entries formatted as <c>Name (Id)</c>, sorted by name.</returns>
    internal static List<string> PatientById(string searchText, TransmorgerDatabase tmDb)
    {
        //TODO: Find a way to do this without passing the entire database.
        List<(string name, string id)> allEntries = tmDb.GetPatients();

        return SearchResult(searchText, allEntries, false);
    }

    /// <summary>Searches for providers whose name contains the specified text.</summary>
    /// <param name="searchText">The text to search for within provider names.</param>
    /// <param name="tmDb">The database instance to search.</param>
    /// <returns>A list of matching provider entries formatted as <c>Name (Id)</c>, sorted by name.</returns>
    internal static List<string> ProviderByName(string searchText, TransmorgerDatabase tmDb)
    {
        //TODO: Find a way to do this without passing the entire database.
        List<(string name, string id)> allEntries = tmDb.GetProviders();

        return SearchResult(searchText, allEntries, true);
    }

    /// <summary>Searches for providers whose ID contains the specified text.</summary>
    /// <param name="searchText">The text to search for within provider IDs.</param>
    /// <param name="tmDb">The database instance to search.</param>
    /// <returns>A list of matching provider entries formatted as <c>Name (Id)</c>, sorted by name.</returns>
    internal static List<string> ProviderById(string searchText, TransmorgerDatabase tmDb)
    {
        //TODO: Find a way to do this without passing the entire database.
        List<(string name, string id)> allEntries = tmDb.GetProviders();

        return SearchResult(searchText, allEntries, false);
    }

    /// <summary>Filters and formats a list of name/ID entries based on the given search text.</summary>
    /// <param name="searchText">The text to match against either names or IDs.</param>
    /// <param name="allEntries">The full list of name and ID tuples to search.</param>
    /// <param name="searchByName">If <see langword="true"/>, searches by name; otherwise searches by ID.</param>
    /// <returns>A list of matching entries formatted as <c>Name (Id)</c>, sorted by name.</returns>
    internal static List<string> SearchResult(string searchText, List<(string name, string id)> allEntries, bool searchByName)
    {
        var nameAndId = new List<(string name, string id)>();

        nameAndId = searchByName
            ? [.. allEntries.Where(p => p.name.Contains(searchText, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.name)]
            : [.. allEntries.Where(p => p.id.Contains(searchText, StringComparison.OrdinalIgnoreCase)).OrderBy(p => p.name)];

        List<string> resultList = [];

        foreach (var (name, id) in nameAndId)
        {
            resultList.Add($"{name} ({id})");
        }

        return resultList;
    }
}