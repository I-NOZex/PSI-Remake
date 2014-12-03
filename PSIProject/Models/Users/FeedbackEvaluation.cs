using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PSIProject.Models.Settings;
using PSIProject.Properties;

namespace PSIProject.Models.Users {
    public class FeedbackEvaluation {

        public int ID { get; set; }

        [Display(Name = "Feedback_User", ResourceType = typeof(Resources))]
        public int FeedbackID { get; set; }

        [Display(Name = "FeedbackItem_User", ResourceType = typeof(Resources))]
        public int FeedbackItemID { get; set; }

        [Display(Name = "Evaluation_User", ResourceType = typeof(Resources))]
        public int Evaluation { get; set; }

        //[Display(Name = "Tipo")]
        //public string Type { get; set; }

        public virtual Feedback Feedback { get; set; }
        public virtual FeedbackItem FeedbackItem { get; set; }
    }
}