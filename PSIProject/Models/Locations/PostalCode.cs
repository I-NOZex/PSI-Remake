using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

using PSIProject.Models.Users;

namespace PSIProject.Models.Locations {
    //[Table("PostalCode")]
    public class PostalCode {
        public int ID { get; set; }

        [RegularExpression(@"\d{4}-\d{3}", ErrorMessageResourceType=typeof(Resources), ErrorMessageResourceName="PostalCodeFormat")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(8, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Name_PostalCode", ResourceType = typeof(Resources))]
        public string ZipCode { get; set; }

        public int LocalityID { get; set; }
        public virtual Locality Locality { get; set; }

    }
}