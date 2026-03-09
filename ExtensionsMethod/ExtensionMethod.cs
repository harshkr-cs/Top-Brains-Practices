
public static class StringArrayExtensions
{
    public static string[] DistinctById(this string[] items)
    {
        if (items == null || items.Length == 0)
            return Array.Empty<string>();

        HashSet<string> seenIds = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (var item in items)
        {
            int separatorIndex = item.IndexOf(':');
            if (separatorIndex == -1)
                continue; // skip invalid format

            string id = item.Substring(0, separatorIndex);
            string name = item.Substring(separatorIndex + 1);

            if (seenIds.Add(id)) // true only if id not already present
            {
                result.Add(name);
            }
        }

        return result.ToArray();
    }
}