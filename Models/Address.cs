using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookPS02.Model
{
    public class Address
    {
        [Display(Name = "Twoja ulubiona ulica")]
        [StringLength(60, MinimumLength = 3), Required(ErrorMessage = "Pole jest obowiązkowe")]
        public string Street { get; set; }
        [Display(Name="Zip Code")]
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
    }
}
