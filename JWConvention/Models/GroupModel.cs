using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWConvention.Models
{
    public class GroupModel
    {
        public List<JW_GroupID> groupList { get; set; }
        public string GroupID { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class InquiryModel
    {
        public string TourName { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Message { get; set; }
    }
}