using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_app.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }

        public int PhoneId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} , User: {User} , Address: {Address} , ContactPhone: {ContactPhone} , PhoneId: {PhoneId}";
        }
    }
}
