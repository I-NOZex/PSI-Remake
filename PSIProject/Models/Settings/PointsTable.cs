using PSIProject.Properties;
using System.ComponentModel.DataAnnotations;

namespace PSIProject.Models.Settings {
    public class PointsTable {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType= typeof(Resources), ErrorMessageResourceName= "Required")]
        [Display(Name = "Number_PointsTable", ResourceType = typeof(Resources))]
        public int Points { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Description_PointsTable", ResourceType = typeof(Resources))]
        public string Description { get; set; }
    }
}
