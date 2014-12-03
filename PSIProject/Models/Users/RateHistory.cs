using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

namespace PSIProject.Models.Users
{
    public class RateHistory
    {

        public int ID { get; set; }

        [Display(Name = "User_User", ResourceType = typeof(Resources))]
        public string UserID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date_User", ResourceType = typeof(Resources))]
        public DateTime Date { get; set; }

        [Display(Name = "PointsSeller_User", ResourceType = typeof(Resources))]
        public int PointsSeller { get; set; }

        [Display(Name = "PointsBuyer_User", ResourceType = typeof(Resources))]
        public int PointsBuyer { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Description_User", ResourceType = typeof(Resources))]
        public string Description { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}