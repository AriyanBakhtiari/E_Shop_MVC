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
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        public double Wallet { get; set; }
        public bool IsAdmin { get; set; }



        
        public List<Orders> Orders { get; set; }
    }
}
