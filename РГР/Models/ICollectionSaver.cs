using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public interface ICollectionSaver
    {
        void Save(IEnumerable<Full_Elements> collection, string path);
    }
}
