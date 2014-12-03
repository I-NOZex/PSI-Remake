using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

namespace PSIProject.Models.Users {

    public class Friend {
       
        public int ID { get; set; }

        [Display(Name = "User_User", ResourceType = typeof(Resources))]
        public string UserID { get; set; }

        [Display(Name = "Friend_User", ResourceType = typeof(Resources))]
        public string FriendID { get; set; }

        [Display(Name = "Status_User", ResourceType = typeof(Resources))]
        public Boolean Status { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("FriendID")]
        public virtual ApplicationUser UserFriend { get; set; }

    }
}