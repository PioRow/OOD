using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class Cargo
    {
        public  string TypeId { get;}
        private long _id;
        private float _weight;
        private string _code;
        private string _description;
        public Cargo(long id, float weight, string code, string description)
        {
            TypeId = "CA";
            _id = id;
            _weight = weight;
            _code = code;
            _description = description;
        }
        public Cargo()
        {
            TypeId = "CA";
            _id = -1;
            _weight=float.MinValue;
            _code = string.Empty;
            _description = string.Empty;
        }
        public long Id {  get { return _id; }set { _id = value; } }
        public float Weight { get { return _weight; } set { _weight = value; } }
        public string Code { get { return _code; } set { _code = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public override string ToString()
        {
            return $"{TypeId} ID: {_id}, Weight: {_weight}, Code: {_code}, Description: {_description}";
        }

    }
}
