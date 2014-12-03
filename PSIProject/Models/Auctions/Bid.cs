using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSIProject.Models.Users;
using PSIProject.Models.Settings;
using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    public class Bid {
        public int ID { get; set; }

        
        [Display(Name = "Name_Auction", ResourceType = typeof(Resources))]
        public int AuctionID { get; set; }

        [Display(Name = "Name_User", ResourceType = typeof(Resources))]
        public string UserID { get; set; }

        [RegularExpression(@"\d{9},\d{2}", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CurrencyFormat")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Name_BidValueInc", ResourceType = typeof(Resources))]
        [DataType(DataType.Currency, ErrorMessageResourceType=typeof(Resources), ErrorMessageResourceName="CurrencyType")]
        public decimal BidValueInc { get; set; }

        public virtual Auction Auction { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}