using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

namespace PSIProject.Models.Locations {
    public class Locality {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Name_Locality", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        public int CountyID { get; set; }

        public virtual County County { get; set; }

        public virtual ICollection<PostalCode> PostalCodes { get; set; }
    }
}