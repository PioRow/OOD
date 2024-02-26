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
        private long _id;
        private long _orginId;
        private long _targetId;
        private string _takeoffTime;
        private string _landingTime;
        private float _longitude;
        private float _latitude;
        private float _amsl;
        private long _planeId;
        private List<long> _crewIds;
        private List<long> _loadIds;
        public Flight(long id, long orginId, long targetId, string takeoffTime, string landingTime, float longitude, 
            float latitude, float amsl, long planeId, List<long> crewIds, List<long> loadIds)
        {
            _id = id;
            _orginId = orginId;
            _targetId = targetId;
            _takeoffTime = takeoffTime;
            _landingTime = landingTime;
            _longitude = longitude;
            _latitude = latitude;
            _amsl = amsl;
            _planeId = planeId;
            _crewIds = crewIds;
            _loadIds = loadIds;
        }
        public Flight()
        {
            _id = -1;
            _orginId = -1;
            _targetId = -1;
            _takeoffTime = String.Empty;
            _landingTime = String.Empty;
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
        public string TakeOffTime {  set { _takeoffTime = value; } get { return _takeoffTime; } }
        public string LandingTime { set { _landingTime = value; } get { return _landingTime; } }
        public float Longitude { set { _longitude = value; } get { return _longitude; } }
        public float Latitude { set { _latitude = value; } get { return _latitude; } }
        public float Amsl { set { _amsl = value; } get { return _amsl; } }
        public long PlaneId { set { _planeId = value; } get { return _planeId; } }
        public List<long> CrewIds { set { _crewIds = value; } get { return _crewIds; } }
        public List<long> LoadIds { set { _loadIds = value; } get { return _loadIds; } }
    }
}
