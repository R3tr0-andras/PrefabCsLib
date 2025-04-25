using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefabCsLib
{
    public class PrefabBuilder<T> where T : IPrefab
    {
        private T _instance;

        public PrefabBuilder(T emptyInstance)
        {
            _instance = emptyInstance;
        }

        public T Instance => _instance;

        public void ApplyChanges(Action<T> configure)
        {
            configure(_instance);
        }

        public void SaveAsPrefab()
        {
            PrefabManager.RegisterPrefab(_instance);
        }
    }
}
