using PSIProject.Models.Locations;
using PSIProject.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSIProject.Models.Users {
    public class ExternalLoginConfirmationViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Email_AccountViewModels", ResourceType = typeof(Resources))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        public string Provider { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Code_AccountViewModels", ResourceType = typeof(Resources))]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser_AccountViewModels", ResourceType = typeof(Resources))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Email_AccountViewModels", ResourceType = typeof(Resources))]
        public string Email { get; set; }
    }

    public class LoginViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Email_AccountViewModels", ResourceType = typeof(Resources))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailAddressType")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        [Display(Name = "Password_AccountViewModels", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [Display(Name = "RememberMe_AccountViewModels", ResourceType = typeof(Resources))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [Display(Name = "Name_AccountViewModels", ResourceType = typeof(Resources))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailAddressType")]
        [Display(Name = "Email_AccountViewModels", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        [Display(Name = "Password_AccountViewModels", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        [Display(Name = "ConfirmPassword_AccountViewModels", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Photo_AccountViewModels", ResourceType = typeof(Resources))]
        public string Photo { get; set; }


        //public int PostalCodeID { get; set; }
        //[ForeignKey("PostalCodeID")]
        //public virtual PostalCode PostalCode { get; set; }
    }

    public class ResetPasswordViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailAddressType")]
        [Display(Name = "Email_AccountViewModels", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Length")]
        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        [Display(Name = "Password_AccountViewModels", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        [Display(Name = "PasswordConfirmation_AccountViewModels", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceType=typeof(Resources), ErrorMessageResourceName = "PasswordType")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Required")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailAddressType")]
        [Display(Name = "Email_AccountViewModels", ResourceType = typeof(Resources))]
        public string Email { get; set; }
    }
}
