using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSIProject.Properties;

namespace PSIProject.Models.Users {
    public class Message {

        public int ID { get; set; }

        [Display(Name = "Sender_User", ResourceType = typeof(Resources))]
        public string SenderID { get; set; }

        [Display(Name = "Receiver_User", ResourceType = typeof(Resources))]
        public string ReceiverID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date_User", ResourceType = typeof(Resources))]
        public DateTime Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(500, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [Display(Name = "TextMessage_User", ResourceType = typeof(Resources))]
        public string TextMessage { get; set; }

        [Display(Name = "MessageOrigin_User", ResourceType = typeof(Resources))]
        public int MessageOriginID { get; set; }

        [Display(Name = "MessageRead_User", ResourceType = typeof(Resources))]
        public Boolean MessageRead { get; set; }

        [ForeignKey("SenderID")]
        public virtual ApplicationUser Sender { get; set; }
        [ForeignKey("ReceiverID")]
        public virtual ApplicationUser Receiver { get; set; }
        public virtual Message MessageOrigin { get; set; }
    }
}