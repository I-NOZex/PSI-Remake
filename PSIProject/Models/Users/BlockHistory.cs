using PSIProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PSIProject.Models.Users
{
    enum duration : int
    {
        Permanent = -1,
        Unblocked = 0,
        Day = 1,
        Week = 7,
        TwoWeeks = 14,
        Month = 30,
    }

    public class BlockHistory
    {
        //[Key]
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "User_User", ResourceType = typeof(Resources))]
        public string UserID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Date_User", ResourceType = typeof(Resources))]
        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateType")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "IsBlocked_User", ResourceType = typeof(Resources))]
        public bool IsBlocked { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "Reason_User", ResourceType = typeof(Resources))]
        public string Reason { get; set; }

        [Display(Name = "Duration_User", ResourceType = typeof(Resources))]
        public int Duration { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }
    }
}