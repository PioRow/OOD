using OOD.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public interface IReportable
    {
       public string accept(IMediaVisitor visitor);
    }
}
