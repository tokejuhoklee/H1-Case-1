using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Case1
{
    public class Apartments
    {
        public int ApartmentId { get; set; }
        public int ApartmentSuperindendantContractId { get; set; }
        public int IndependantOverseerId { get; set; }
        public int Area { get; set; }
        public int AddressId { get; set; }
        public int Size { get; set; }
        public int Rooms { get; set; }
        public int NumberOfBeds { get; set; }
        public string RentalQuality { get; set; }
        public string Etc { get; set; }
    }
}
