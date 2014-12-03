using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSIProject.Properties;

namespace PSIProject.Models.Auctions {
    public class Category {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Name_Category", ResourceType = typeof(Resources))]
        public string CategoryName { get; set; }

        [Display(Name = "Parent_Category", ResourceType = typeof(Resources))]
        public int? ParentCategoryID { get; set; }

        public virtual Category ParentCategory { get; set; }
    }
}