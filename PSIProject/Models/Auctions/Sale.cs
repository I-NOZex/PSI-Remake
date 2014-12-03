using System.ComponentModel.DataAnnotations;
using PSIProject.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    
    public class Sale {
        
        public int ID { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display( Name = "Auction_Sale", ResourceType = typeof(Resources))]
        public int AuctionID { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display( Name = "Seller_Sale", ResourceType = typeof(Resources))]
        public string SellerID { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display( Name = "Buyer_Sale", ResourceType = typeof(Resources))]
        public string BuyerID { get; set; }

        [Required( ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display( Name = "ConfirmSale_Sale", ResourceType = typeof(Resources))]
        public int ConfirmSaleID { get; set; }

        public virtual Auction Auction { get; set; }
        
        [ForeignKey("SellerID")]
        public virtual ApplicationUser Seller { get; set; }
        
        [ForeignKey("BuyerID")]
        public virtual ApplicationUser Buyer { get; set; }
        
        public virtual ConfirmSale ConfirmSale { get; set; }
    }
}