using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _init_empty_database
{
    class DBclasses
    {
    }
    public class Address
    {
        public int AddressId { get; set; }
        public int ZipCodeId { get; set; }
        public string Adresse { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public int PersonId { get; set; }
        public string Notes { get; set; }
    }

    public class CustomerConsultant
    {
        public int CustomerConsultantId { get; set; }
        public int PersonId { get; set; }
        public string Etc { get; set; }
    }

    public class CustomerRentalContract
    {
        public int CustomerId { get; set; }
        public int CustomerConsultantId { get; set; }
        public int RentalConsultantId { get; set; }
        public DateTime DateOfContract { get; set; }
        public DateTime DateStartRent { get; set; }
        public DateTime DateEndRent { get; set; }
        public double Price { get; set; }
        public double PriceModifyer { get; set; }
        public string CustomerRentalContractText { get; set; }
    }

    public class District
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int RentalConsultantId { get; set; }
    }

    public class IndependantOverseer
    {
        public int IndependantOverseerId { get; set; }
        public int PersonId { get; set; }
        public string Etc { get; set; }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }

    public class RentalConsultant
    {
        public int RentalConsultantId { get; set; }
        public int PersonId { get; set; }
    }

    public class Residence
    {
        public int ResidenceId { get; set; }
        public int ResidenceOwnerContractId { get; set; }
        public int IndependantOverseerId { get; set; }
        public int AddressId { get; set; }
        public int Area { get; set; }
        public int Size { get; set; }
        public int Rooms { get; set; }
        public int NumberOfBeds { get; set; }
        public string RentalQuality { get; set; }
        public string Etc { get; set; }
        public double BasePrice { get; set; }
        public string ResidenceType { get; set; }
    }

    public class ResidenceOwner
    {
        public int ResidenceOwnerId { get; set; }
        public int PersonId { get; set; }
        public string Etc { get; set; }
    }

    public class ResidenceOwnerContract
    {
        public int ResidenceOwnerContractId { get; set; }
        public int ResidenceOwnerId { get; set; }
        public int RentalConsultantId { get; set; }
        public DateTime DateOfContract { get; set; }
        public DateTime DateStartRent { get; set; }
        public DateTime DateEndRent { get; set; }
        public double Price { get; set; }
        public string ResidenceOwnerContractText { get; set; }
    }

    public class Vacancy
    {
        public DateTime Year { get; set; }
        public DateTime Week { get; set; }
        public int ResidenceId { get; set; }
        public double UdlejningsPris { get; set; }
        public int ResidenceOwnerContractId { get; set; }
    }

    public class PostnrBy
    {
        public int Postnr { get; set; }
        public string Bynavn { get; set; }

        // Constructor to insert 2 string into: int, string object
        public PostnrBy(string Postnr,string Bynavn)
        {
            this.Postnr = int.Parse(Postnr);
            this.Bynavn = Bynavn;
        }
    }
}
