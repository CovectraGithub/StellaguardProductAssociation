using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellaguardProductAssociation.Models
{
    public class ProductAssociationHistoryModels
    {
        public List<SupplierChain> SupplierChainList { get; set; }

        public MessageDisplay Message { get; set; }

       // public ModulePermissions Permissions { get; set; }
        public string Keyword { get; set; }
    }

    public class SupplierChain
    {
        public byte SupplierId { get; set; }

        [Display(Name = "SupplierName_Display_Name")]
        public string SupplierName { get; set; }

        [Display(Name = "SupplierType_Display_Name")]
        public string SupplierType { get; set; }

        public string SupplierLocation { get; set; }
        //public string SupplierCNPJ { get; set; }
        //public short SupplierContactId { get; set; }

        public List<BranchAddressDetails> ContactAddressList { get; set; }


    }

    public class BranchAddressDetails
    {
        [Display(Name = "BranchContactAddressId_Display_Name")]
        public short BranchContactAddressId { get; set; }

        public byte SupplierId { get; set; }

     
        public string Address1 { get; set; }

        [Display(Name = "Address2_Display_Name")]
        public string Address2 { get; set; }

        [Display(Name = "City_Display_Name")]
        public string City { get; set; }

        [Display(Name = "Zip_Display_Name")]
        public string Zip { get; set; }

        [Display(Name = "PhoneNumber1_Display_Name")]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "PhoneNumber2_Display_Name")]
        public string PhoneNumber2 { get; set; }

        [Display(Name = "CellNumber_Display_Name")]
        public string CellNumber { get; set; }

        [Display(Name = "Email_Display_Name")]
        public string Email { get; set; }

        [Display(Name = "Email_Display_Name")]
        public string SGLN { get; set; }

        [Display(Name = "Email_Display_Name")]
        public string CNPJNumber { get; set; }

        [Display(Name = "Email_Display_Name")]
        public string LocationName { get; set; }

        public bool IsActive { get; set; }
        public short StateId { get; set; }
        [Display(Name = "StateName_Display_Name")]
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public byte CountryId { get; set; }
    }
}