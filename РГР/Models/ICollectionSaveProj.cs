using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР.Models
{
    public interface ICollectionSaveProj
    {
        void Save_project(IEnumerable<Class_Projects> collection, string path);
    }
}
