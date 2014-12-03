using System;

using System.ComponentModel.DataAnnotations;
using PSIProject.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    public class ReportedAuction {
        public int ID {get;set;}

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Auction_ReportedAuction", ResourceType = typeof(Resources))]
        public int AuctionID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "ReportedBy_ReportedAuction", ResourceType = typeof(Resources))]
        public string UserID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateType")]
        [Display(Name = "Date_ReportedAuctions", ResourceType = typeof(Resources))]
        public DateTime Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Motive_ReportedAuction", ResourceType = typeof(Resources))]
        public string Motive { get; set; }

        public virtual Auction Auction { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}