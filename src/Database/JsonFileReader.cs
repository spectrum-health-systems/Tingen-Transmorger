using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TingenTransmorger.Database;

internal static class JsonFileReader
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    public static List<Dictionary<string, object?>>? ReadJsonList(string dir, string fileName)
    {
        var path = Path.Combine(dir, fileName);
        if (!File.Exists(path)) return null;
        var json = File.ReadAllText(path, Encoding.UTF8);
        return JsonSerializer.Deserialize<List<Dictionary<string, object?>>>(json);
    }

    public static object? ReadJsonObject(string dir, string fileName)
    {
        var path = Path.Combine(dir, fileName);
        if (!File.Exists(path)) return null;
        var json = File.ReadAllText(path, Encoding.UTF8);
        return JsonSerializer.Deserialize<object>(json);
    }

    public static void WriteDatabaseFiles(string tmpDir, string masterDbDir, Dictionary<string, object?> database)
    {
        var jsonPath = Path.Combine(tmpDir, "transmorger.json");
        var json = JsonSerializer.Serialize(database, _jsonOptions);
        File.WriteAllText(jsonPath, json, Encoding.UTF8);

        var dbTempPath = Path.Combine(tmpDir, "transmorger.db");
        var db = JsonSerializer.Serialize(database);
        File.WriteAllText(dbTempPath, db, Encoding.UTF8);

        var masterDbPath = Path.Combine(masterDbDir, "transmorger.db");
        File.Copy(dbTempPath, masterDbPath, true);
    }
}
