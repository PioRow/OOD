using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class Plane
    {
        protected long _id;
        protected string _serial;
        protected string _code;
        protected string _model;
        public Plane(long id, string serial, string code, string model)
        {
            _id = id;
            _serial = serial;
            _code = code;
            _model = model;
        }
        public Plane()
        {
            _id = -1;
            _serial = String.Empty;
            _code=String.Empty;
            _model = String.Empty;
        }
        public long Id { get { return _id; } set { _id = value; } }
        public string Serial { get { return _serial; } set { _serial = value; } }
        public string Code { get { return _code; } set { _code = value; } }
        public string Model { get { return _model; } set { _model = value; } }

    }
}
