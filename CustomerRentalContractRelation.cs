using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Case1
{
    public class CustomerRentalContractRelation
    {
        public int CustomerConsultantId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerRentalContractText { get; set; }
        public DateTime DateOfContract { get; set; }
        public DateTime DateStartRent { get; set; }
        public DateTime DateEndRent { get; set; }
        public double Price { get; set; }
    }
}
