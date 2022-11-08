using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Shop.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "نام کاربری")]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "رمز کاربری")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "تاریخ ثبت نام")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "کیف پول")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public double Wallet { get; set; }
        public bool IsAdmin { get; set; }



        
        public List<Orders> Orders { get; set; }
    }
}
