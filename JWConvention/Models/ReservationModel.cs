using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWConvention.Models
{
    public class ReservationModel
    {
        public List<JW_Rooms> _roomList { get; set; }
        public JW_Hotels _hotel { get; set; }
        public string _roomType { get; set; }
        public string _packageType { get; set; }
        public DateTime _fromDate { get; set; }
        public DateTime _toDate { get; set; }
        public bool _isArrival { get; set; }
        public bool _isDeparture { get; set; }
    }
}