using System.ComponentModel.DataAnnotations;
using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    
    public class Picture {

        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Path_Picture", ResourceType = typeof(Resources))]
        public string Path { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Auction_Picture", ResourceType = typeof(Resources))]
        public int AuctionID { get; set; }

        [Display(Name = "Order_Picture", ResourceType = typeof(Resources))]
        public int? Order { get; set; }

        public virtual Auction Auction { get; set; }
    }
}