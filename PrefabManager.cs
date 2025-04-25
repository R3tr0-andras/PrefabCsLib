using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefabCsLib
{
    public static class PrefabManager
    {
    
    private static readonly Dictionary<string, IPrefab> _prefabs = new();

    public static void RegisterPrefab(IPrefab prefab)
    {
        _prefabs[prefab.PrefabId] = prefab;
    }

    public static IPrefab Instantiate(string prefabId)
    {
        if (_prefabs.TryGetValue(prefabId, out var prefab))
            return prefab.Clone();

        throw new KeyNotFoundException($"Prefab with ID '{prefabId}' not found.");
    }
}
}
