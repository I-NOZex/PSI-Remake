using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSIProject.Models.Locations;
using PSIProject.Models.Users;
using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    public enum AuctionStatus : byte {
        Inactive = 0,
        Active = 1,
        Ended = 2,
        Canceled = 3,
        Reported = 4
    }

    public class Auction {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Title_Auction", ResourceType = typeof(Resources))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Description_Auction", ResourceType = typeof(Resources))]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "PostalCode_Auction", ResourceType = typeof(Resources))]
        public int PostalCodeID { get; set; }

        public string UserID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Category_Auction", ResourceType = typeof(Resources))]
        public int CategoryID { get; set; }

        [NotMapped]
        public string TagsHolder { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "ArticleStatus_Auction", ResourceType = typeof(Resources))]
        public string ArticleStatus { get; set; }

        [NotMapped]
        public HttpFileCollection PicturesHolder { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "DeliveryCondition_Auction", ResourceType = typeof(Resources))]
        public string DeliveryCondition { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "StartDate_Auction", ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateType")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeBegin { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "EndDate_Auction", ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateType")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeEnd { get; set; }

        [RegularExpression(@"\d{9},\d{2}", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CurrencyFormat")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "StartingPrice_Auction", ResourceType = typeof(Resources))]
        [DataType(DataType.Currency, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CurrencyType")]
        public decimal StartingPrice { get; set; }

        [Display(Name = "MinPrice_Auction", ResourceType = typeof(Resources))]
        [DataType(DataType.Currency, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CurrencyType")]
        public decimal? MinPrice { get; set; }

        [Display(Name = "DirectSell_Auction", ResourceType = typeof(Resources))]
        public Boolean DirectSell { get; set; }

        [Display(Name = "BuyNowPrice_Auction", ResourceType = typeof(Resources))]
        [DataType(DataType.Currency, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CurrencyType")]
        public decimal? BuyNowPrice { get; set; }

        //[Display(Name = "Ultima Licitação")]
        //public int BidID { get; set; }

        [StringLength(500, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "ShipmentCondition_Auction", ResourceType = typeof(Resources))]
        public string ShipmentCondition { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Extended_Auction", ResourceType = typeof(Resources))]
        public Boolean Extended { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Status_Auction", ResourceType = typeof(Resources))]
        public byte Status { get; set; }

        [ForeignKey("PostalCodeID")]
        public virtual PostalCode PostalCode { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}