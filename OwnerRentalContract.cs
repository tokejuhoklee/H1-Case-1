using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Case1
{
    public class OwnerRentalContract
    {
        public int RentalId { get; set; }
        public string ContractText { get; set; }
        public string CustommerConsultant { get; set; }
        public string Customer { get; set; }
        public string RentalAdministrator { get; set; }
        public string Price { get; set; }
        public string RentalOwner { get; set; }
        public DateTime DateOfContract { get; set; }
        public DateTime DateStartRent { get; set; }
        public DateTime DateEndRent { get; set; }

}
}
