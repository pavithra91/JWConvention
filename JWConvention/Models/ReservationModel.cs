using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWConvention.Models
{
    public class ReservationModel
    {
        public string BookingID { get; set; }


        public List<JW_Rooms> _roomList { get; set; }
        public List<JW_Hotels> _hotelList { get; set; }
        public JW_Hotels _hotel { get; set; }
        public JW_Rooms _room { get; set; }


        public string _roomType { get; set; }
        public string _Occupancy { get; set; }
        public string _BedPerferance { get; set; }

        public string _packageType { get; set; }
        public string _fromDate { get; set; }
        public string _toDate { get; set; }
        public bool _isArrival { get; set; }
        public bool _isDeparture { get; set; }
        public string _ArrivalDate { get; set; }
        public string _DepartureDate { get; set; }
        public string _ArrivalTime { get; set; }
        public string _DepartureTime { get; set; }
        public string _ArrivalFlightNumber { get; set; }
        public string _DepartureFlightNumber { get; set; }

        public string Remarks { get; set; }


        public float PackageCost { get; set; }
        public float AdditionalACCost { get; set; }
        public float TotalCost { get; set; }
        public bool isAdvancedPayment { get; set; }
        public string FullPayment { get; set; }
        public string HalfPayment { get; set; }


        public string _hotelCode { get; set; }

        public DelegateModel _delegate { get; set; }

        public AddtionalAccommodation _additional { get; set; }

        public List<AddtionalAccommodation> _additionalList { get; set; }
    }


    public class AddtionalAccommodation
    {
        public string _addtionalDate { get; set; }
        public string _addtionalHotel { get; set; }
        public string _addtionalRoom { get; set; }
        public string _addtionalBasis { get; set; }
        public string _addtionalOccupancy { get; set; }
        public int _addtionalNoOfNights { get; set; }
        public int _addtionalNoOfRooms { get; set; }
        public float _Cost { get; set; }
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