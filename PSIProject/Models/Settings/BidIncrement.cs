using PSIProject.Properties;
using System.ComponentModel.DataAnnotations;


namespace PSIProject.Models.Settings {
    public class BidIncrement {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "LowValue_BidIncrement", ResourceType = typeof(Resources))]
        [Range(0, 999999999, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Range")]
        [DataType(DataType.Currency)]
        public decimal Min { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "MaxValue_BidIncrement", ResourceType = typeof(Resources))]
        [Range(0, 999999999, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Range")]
        [DataType(DataType.Currency)]
        public decimal Max { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "ValueToAdd_BidIncrement", ResourceType = typeof(Resources))]
        [Range(0, 999999999, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Range")]
        [DataType(DataType.Currency)]
        public decimal Increment { get; set; }
    }
}