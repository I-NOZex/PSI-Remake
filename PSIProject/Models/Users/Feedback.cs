using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PSIProject.Models.Auctions;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSIProject.Models.Settings;
using PSIProject.Properties;

namespace PSIProject.Models.Users {

    public enum AuctionUserTypes : byte {
        Buyer = 0,
        Seller = 1
    }

    public class Feedback {

        public int ID { get; set; }

        [Display(Name = "Auction_User", ResourceType = typeof(Resources))]
        public int AuctionID { get; set; }

        
        [Display(Name = "Classifier_User", ResourceType = typeof(Resources))]
        public string ClassifierID { get; set; }

        [Display(Name = "AuctionUserType_User", ResourceType = typeof(Resources))]
        public byte AuctionUserType { get; set; }

        [Display(Name = "Classified_User", ResourceType = typeof(Resources))]
        public string ClassifiedID { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Description_User", ResourceType = typeof(Resources))]
        public string Description { get; set; }

        [ForeignKey("ClassifierID")]
        public virtual ApplicationUser Classifier { get; set; }
        [ForeignKey("ClassifiedID")]
        public virtual ApplicationUser Classified { get; set; }
        public virtual ICollection<FeedbackEvaluation> FeedbackEvaluations { get; set; }
        public virtual Auction Auction { get; set; } 
    }
}