using PSIProject.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSIProject.Models.Auctions {
    public class Tag {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Name_Tag", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; }
    }
}