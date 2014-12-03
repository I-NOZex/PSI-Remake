using PSIProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PSIProject.Models.Users {
    public class Session {

        public int ID { get; set; }

        [Display(Name = "User_User", ResourceType = typeof(Resources))]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "LoginDate_User", ResourceType = typeof(Resources))]
        public DateTime LoginDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "LastActivity_User", ResourceType = typeof(Resources))]
        public DateTime LastActivity { get; set; }
    }
}