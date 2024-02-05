using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Taskmanagement.Models
{
    public class user
    {
        public int uid { get; set; }

        [Required(ErrorMessage = "Please Enter Username !!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password !!")]
        public string Passworord { get; set; }

    }
}