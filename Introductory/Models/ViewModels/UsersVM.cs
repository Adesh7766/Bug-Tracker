using System.ComponentModel.DataAnnotations.Schema;

namespace Introductory.Models.ViewModels
{
    public class UsersVM
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int UserGroupId { get; set; }
        public string ValidFrom { get; set; }
        public string ValidTo { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }


        [ForeignKey("UserGroupId")]
        public virtual UserGroup UserGroup { get; set; }
    }

    public class SignInVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

