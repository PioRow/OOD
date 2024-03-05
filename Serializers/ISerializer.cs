using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Serializers
{
    public interface ISerializer
    {
        public void serialize(string file, ICollection<object> Objects);
    }

}
