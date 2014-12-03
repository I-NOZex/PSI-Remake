using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSIProject.Models.Locations;
using PSIProject.Models.Users;
using PSIProject.Models.Settings;
using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    public class ConfirmSale {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "ConfirmationCode_ConfirmSale", ResourceType = typeof(Resources))]
        public string ConfirmationCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Buyer_ConfirmSale", ResourceType = typeof(Resources))]
        public string BuyerID { get; set; }

        [Display(Name = "BuyerConfirmed_ConfirmSale", ResourceType = typeof(Resources))]
        public Boolean BuyerConfirmed { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateType")]
        [Display(Name = "BuyerDateConfirmation_ConfirmSale", ResourceType = typeof(Resources))]
        public DateTime? BuyerDateConfirmation { get; set; }

        [Display(Name = "Seller_ConfirmSale", ResourceType = typeof(Resources))]
        public string SellerID { get; set; }

        [Display(Name = "SellerConfirmed_ConfirmSale", ResourceType = typeof(Resources))]
        public Boolean SellerConfirmed { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateType")]
        [Display(Name = "SellerDateConfirmation_ConfirmSale", ResourceType = typeof(Resources))]
        public DateTime? SellerDateConfirmation { get; set; }

        [ForeignKey("BuyerID")]
        public virtual ApplicationUser Buyer { get; set; }
        [ForeignKey("SellerID")]
        public virtual ApplicationUser Seller { get; set; }
    }
}