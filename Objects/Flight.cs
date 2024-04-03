using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Objects
{
    public class Flight
    {
        public  string TypeId { get;}
        private long _id;
        private long _orginId;
        private long _targetId;
        private DateTime _takeoffTime;
        private DateTime _landingTime;
        private float _longitude;
        private float _latitude;
        private float _amsl;
        private long _planeId;
        private List<long> _crewIds;
        private List<long> _loadIds;
        public Flight(long id, long orginId, long targetId, string takeoffTime, string landingTime, float longitude, 
            float latitude, float amsl, long planeId, List<long> crewIds, List<long> loadIds)
        {
            TypeId = "FL";
            _id = id;
            _orginId = orginId;
            _targetId = targetId;
            _takeoffTime = DateTime.ParseExact(takeoffTime, "HH:mm", null);
            _landingTime = DateTime.ParseExact(landingTime, "HH:mm", null);
            _longitude = longitude;
            _latitude = latitude;
            _amsl = amsl;
            _planeId = planeId;
            _crewIds = crewIds;
            _loadIds = loadIds;
        }
        public Flight()
        {
            TypeId = "FL";
            _id = -1;
            _orginId = -1;
            _targetId = -1;
            _takeoffTime = DateTime.MinValue;
            _landingTime = DateTime.MinValue;
            _longitude = float.MinValue;
            _latitude = float.MinValue;
            _amsl = float.MinValue;
            _planeId = -1;
            _crewIds = null;
            _loadIds = null ;
        }
        public long Id { set {  _id = value; }get { return _id; } }
        public long OrginId { set { _orginId = value; }get { return _orginId; } }
        public long TargetId {  set { _targetId = value; } get {  return _targetId; } }
        public DateTime TakeOffTime {  set { _takeoffTime = value; } get { return _takeoffTime; } }
        public DateTime LandingTime { set { _landingTime = value; } get { return _landingTime; } }
        public float Longitude { set { _longitude = value; } get { return _longitude; } }
        public float Latitude { set { _latitude = value; } get { return _latitude; } }
        public float Amsl { set { _amsl = value; } get { return _amsl; } }
        public long PlaneId { set { _planeId = value; } get { return _planeId; } }
        public List<long> CrewIds { set { _crewIds = value; } get { return _crewIds; } }
        public List<long> LoadIds { set { _loadIds = value; } get { return _loadIds; } }

        public override string ToString()
        {
            return $"{TypeId} ID: {_id}, Origin ID: {_orginId}, Target ID: {_targetId}, Takeoff Time: {_takeoffTime}, " +
                $"Landing Time: {_landingTime}, Longitude: {_longitude}, Latitude: {_latitude}, AMSL: {_amsl}," +
                $" Plane ID: {_planeId}, Crew IDs: [{string.Join(", ", _crewIds)}], Load IDs: [{string.Join(", ", _loadIds)}]";
        }
    }
}
