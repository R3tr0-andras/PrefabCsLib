using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefabCsLib
{
    public interface IPrefab
    {
        string PrefabId { get; }
        IPrefab Clone();
    }
}
