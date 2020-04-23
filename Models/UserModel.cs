using System;

namespace DemoApi.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        // [Required(ErrorMessage = "Please Enter FirstName")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Please Enter LastName")]
        public string LastName { get; set; }
        // [Required(ErrorMessage = "Please Enter Cell Number")]
        public string PhoneNumber { get; set; }
        //[Required(ErrorMessage = "Please Enter Email")]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }
    }
}
