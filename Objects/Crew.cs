﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public  class Crew:Person,IMyObject
    {
        public  string TypeId { get; }
        private short _practice;
        private string _role;

        public Crew(long id, string name, long age, string phone, string email,short practice,string role) 
            : base(id, name, age, phone, email)
        {
            TypeId = "C";
            _practice = practice;
            _role = role;
        }
        public Crew():base()
        {
            TypeId = "C";
            _practice = -1;
            _role = String.Empty;
        }
        public short Practice { get { return _practice; } set {_practice=value;} }
        public string Role { get { return _role; }set { _role=value;} }
        public override string ToString()
        {
            return $"{TypeId} "+base.ToString()+$" practice:{_practice}, role{_role}";
        }

    }
}
