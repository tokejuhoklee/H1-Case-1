using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Case1
{
    public class ApartmentSuperindendantContractRelation
    {
        public int ApartmentSuperindendantContractId { get; set; }
        public int ApartmentSuperindendantId { get; set; }
        public int RentalConsultantId { get; set; }
        public DateTime DateOfContract { get; set; }
        public DateTime DateStartRent { get; set; }
        public DateTime DateEndRent { get; set; }
        // Could also br a file
        public string ApartmentSuperindendantContractText { get; set; }
        public double Price { get; set; }
    }
}
