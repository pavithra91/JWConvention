using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWConvention.Models
{
    public class ReservationModel
    {
        public List<JW_Rooms> _roomList { get; set; }
        public List<JW_Hotels> _hotelList { get; set; }
        public JW_Hotels _hotel { get; set; }
        public string _roomType { get; set; }
        public string _packageType { get; set; }
        public DateTime _fromDate { get; set; }
        public DateTime _toDate { get; set; }
        public bool _isArrival { get; set; }
        public bool _isDeparture { get; set; }

        public string _hotelCode { get; set; }

        public DelegateModel _delegate { get; set; }
    }

    public class DelegateModel
    {
        public string GroupId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string DelegateAddress { get; set; }
        public string ContactNo { get; set; }
        public string EmailAddress { get; set; }
    }
}