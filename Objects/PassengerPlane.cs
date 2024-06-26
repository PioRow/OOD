﻿using OOD.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class PassengerPlane : Plane, IMyObject, IReportable
    {
        public string TypeId { get; }
        private short _firstClassSize;
        private short _secondClassSize;
        private short _economyClassSize;

        public PassengerPlane(long id, string serial, string code, string model, short firstClassSize, short secondClassSize, short economyClassSize)
            : base(id, serial, code, model)
        {
            TypeId = "PP";
            _firstClassSize = firstClassSize;
            _secondClassSize = secondClassSize;
            _economyClassSize = economyClassSize;
        }
        public PassengerPlane() : base()
        {
            TypeId = "PP";
            _firstClassSize = -1;
            _secondClassSize = -1;
            _economyClassSize = -1;
        }
        public short FistClassSize { get { return _firstClassSize; }set { _firstClassSize = value; } }
        public short SecondClassSize { get { return _secondClassSize; } set { _secondClassSize = value; } }
        public short EconomyClassSize { get { return _economyClassSize; } set { _economyClassSize = value; } }
        public override string ToString()
        {
            return $"{TypeId} "+base.ToString()+ $"First Class Size: {_firstClassSize}, Second Class Size: {_secondClassSize}," +
                $" Economy Class Size: {_economyClassSize}";
        }
        public string accept(IMediaVisitor visitor)
        {
            return visitor.visit(this);
        }

    }
}
