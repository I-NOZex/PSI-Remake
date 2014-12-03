using PSIProject.Properties;
using System.ComponentModel.DataAnnotations;

namespace PSIProject.Models.Settings {
    public enum TextTypes : int {
        Faq = 0,
        Help = 1,
        ToS = 2,
        Other = 3
    }

    public class Text {

        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TitleTextRequired")]
        [Display(Name = "TitleText", ResourceType = typeof(Resources))]
        [StringLength(150, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TitleTextLength")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Description_Text", ResourceType = typeof(Resources))]
        [StringLength(1000, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Type_Text", ResourceType = typeof(Resources))]
        public int TextType { get; set; }


    }
}