using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string Aadhar { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
