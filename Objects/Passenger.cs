using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class Passenger : Person
    {
        private string _class;
        private long _miles;
        public string TypeId {  get; }
        public Passenger(long id, string name, long age, string phone, string email, string @class, long miles)
            : base(id, name, age, phone, email)
        {
            TypeId = "P";
            _class = @class;
            _miles = miles;
        }
        public Passenger() : base()
        {
            TypeId = "P";
            _class =String.Empty;
            _miles=-1;
        }
        public string Class { get { return _class; } set {  _class = value; } }
        public long Miles { get { return _miles;}set { _miles = value; } }
        public override string ToString()
        {
            return base.ToString()+ $" class:{_class}, miles:{_miles}";
        }
    }
}
