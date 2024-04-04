using OOD.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class CargoPlane:Plane,IMyObject, IReportable
    {
        private float _load;
        public string TypeId { get; }
        public CargoPlane(long id, string serial, string code, string model,float load) 
            : base(id, serial, code, model)
        {
            TypeId = "CA";
            _load = load;
        }
        public CargoPlane() : base() 
        {
            TypeId = "CA";
            _load = float.MinValue;
        }
        public float Load { get { return _load; }set { _load = value; } }
        public override string ToString()
        {
            return $"{TypeId} "+base.ToString()+$" Load:{_load}";
        }

        public string accept(IMediaVisitor visitor)
        {
            return visitor.visit(this);
        }
    }
}
