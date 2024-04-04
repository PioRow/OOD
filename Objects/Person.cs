using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class Person : IMyObject
    {
        protected long _id;
        protected string _name;
        protected long _age;
        protected string _phone;
        protected string _email;
        public Person(long id, string name, long age, string phone, string email)
        {
            _id = id;
            _name = name;
            _age = age;
            _phone = phone;
            _email = email;
        }
        public string TypeId => "";
        public Person()
        {
            _id = -1L;
            _name = String.Empty;
            _age = -1L;
            _phone = String.Empty;
            _email = String.Empty;

        }
        public long Id { get { return _id; }set { _id = value; } }
        public string Name { get { return _name;}set { _name = value; } }
        public long Age { get { return _age; } set { _age = value; } }
        public string Phone { get { return _phone;}set{ _phone = value; } }
        public string Email { get { return _email;}set{ _email = value; } }
        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Age: {_age}, Phone: {_phone}, Email: {_email}";
        }
    }
}
