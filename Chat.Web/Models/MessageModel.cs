using System;
using System.ComponentModel.DataAnnotations;

namespace Chat.Web.Models
{
    public class MessageModel
    {
        [Display(Name = "User:")]
        public string UserName { get; set; }

        [Display(Name = "Said:")]
        public string MessageText { get; set; }

        [Display(Name = "Time:")]
        public DateTime CreateTime { get; set; }
    }
}