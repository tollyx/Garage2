using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Garage2.Models {
    public class Member {
        public int Id { get; set; }
        public string Name { set; get; }
        [DisplayName("Phone number")]
        public string PhoneNumber { set; get; }
        [DisplayName("E-mail")]
        public string Email { set; get; }
        [DisplayName("Registered since")]
        public DateTime RegisterDate { set; get; }
    }
}