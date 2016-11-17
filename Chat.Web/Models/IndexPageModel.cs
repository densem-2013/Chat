using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chat.Web.Models
{
    public class IndexPageModel
    {
        [Display(Name = "New Message:")]
        public string NewMessageText { get; set; }

        [Display(Name = "Chat Messages:")]
        public List<MessageModel> Messages { get; set; } 
    }
}