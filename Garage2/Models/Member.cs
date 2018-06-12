using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Member {
        public int Id { get; set; }
        public string Name { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public DateTime RegisterDate { set; get; }
    }
}