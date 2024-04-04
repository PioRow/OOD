using OOD.Visitors;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOD.Objects
{
    public class Airport:IMyObject, IReportable
    {
        public string TypeId { get; }
        private long _id;
        private string _name;
        private string _code;
        private float _longitude;
        private float _latiitude;
        private float _amsl;
        private string _country;
        public Airport(long id,string name, string code, float longitude, float latiitude, float amsl, string country)
        {
            TypeId = "AI";
            _id= id;
            _name = name;
            _code = code;
            _longitude = longitude;
            _latiitude = latiitude;
            _amsl = amsl;
            _country = country;
        }
        public Airport()
        {
            TypeId = "AI";
            _id = -1;
            _name = String.Empty;
            _code = String.Empty;
            _longitude = float.MinValue;
            _latiitude = float.MinValue;
            _amsl = float.MinValue;
            _country = String.Empty;
        }

        public long Id { get {  return _id; }set { _id = value; } }
        public string Name { get { return _name; }set { _name = value; } }
        public string Code { get { return _code; } set {  _code = value; } }
        public float Longitude { get { return _longitude; } set { _longitude = value; } }
        public float Latitude { get { return _latiitude; }set { _latiitude = value; } }
        public float Amsl { get { return _amsl; } set { _amsl = value; } }
        public string Country { get { return _country; } set { _country = value; } }
        public override string ToString()
        {
            return $"{TypeId} ID: {_id}, Name: {_name}, Code: {_code}, Longitude: {_longitude}, Latitude: {_latiitude}" +
                $", AMSL: {_amsl}, Country: {_country}";
        }

        public string accept(IMediaVisitor visitor)
        {
            return visitor.visit(this);
        }
    }
}
