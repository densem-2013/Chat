using System;
using System.ComponentModel.DataAnnotations;

namespace Chat.Core.DAL
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public virtual ChatUser ChatUser { get; set; }
    }
}
