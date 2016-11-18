using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Core.DAL
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public int ChatUserId { get; set; }
        [ForeignKey("ChatUserId")]
        public virtual ChatUser ChatUser { get; set; }
    }
}
