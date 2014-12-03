using PSIProject.Properties;
using System.ComponentModel.DataAnnotations;

namespace PSIProject.Models.Settings {
    public class FeedbackItem {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Description_FeedbackItem", ResourceType = typeof(Resources))]
        public string Description { get; set; }
    }
}