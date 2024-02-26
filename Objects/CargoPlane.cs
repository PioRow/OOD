using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class CargoPlane:Plane
    {
        private float _load;

        public CargoPlane(long id, string serial, string code, string model,float load) 
            : base(id, serial, code, model)
        {
            _load = load;
        }
        public CargoPlane() : base() 
        {
            _load = float.MinValue;
        }
        public float Load { get { return _load; }set { _load = value; } }
    }
}
