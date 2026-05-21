using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Week03; // <--- THIS IS THE KEY ADJUSTMENT. It allows this file to see FeatureCollection.

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            // Skip words like "aa" per requirements
            if (word[0] == word[1])
                continue;

            string reverse = $"{word[1]}{word[0]}";

            if (seen.Contains(reverse))
            {
                // The order of words in the string doesn't matter per requirements
                pairs.Add($"{word} & {reverse}");
            }

            seen.Add(word);
        }

        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // Column 4 is index 3
            var degree = fields[3];
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        if (word1 == null || word2 == null)
            return false;

        // Ignore spaces and case per requirements
        word1 = word1.Replace(" ", "").ToLowerInvariant();
        word2 = word2.Replace(" ", "").ToLowerInvariant();

        if (word1.Length != word2.Length)
            return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c) || counts[c] == 0)
                return false;

            counts[c]--;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Now this works because we added 'using Week03;'
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();

        if (featureCollection?.features != null)
        {
            foreach (var feature in featureCollection.features)
            {
                // Format: "Place - Mag 1.23"
                string summary = $"{feature.properties.place} - Mag {feature.properties.mag}";
                summaries.Add(summary);
            }
        }

        return summaries.ToArray();
    }
}