using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Chat.Core.DAL
{
    public sealed class ChatUser : BaseEntity
    {
        public ChatUser()
        {
            Messages = new List<Message>();
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string PassWord { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
