using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD.Objects;
namespace OOD.Factories
{
    public interface IFTRFactory
    {
        public object Produce(string[] values); 
    }
    

}
