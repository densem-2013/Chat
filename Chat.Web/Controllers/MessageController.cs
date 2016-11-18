using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Chat.Core.DAL;
using Chat.Core.Infrastructure;
using Chat.Web.Models;

namespace Chat.Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IRepository<Message> _repoMessage;

        public MessageController(IRepository<Message> repoMessage)
        {
            _repoMessage = repoMessage;
        }

        public ActionResult Index(int id)
        {
            return View(GetPageModel(id));
        }

        [HttpPost]
        public ActionResult SendMessage(IndexPageModel model)
        {
            int userid = model.UserId;
            
            _repoMessage.Insert(new Message { Text = model.NewMessageText, DateTime = DateTime.Now, ChatUserId = userid });

            return Redirect($"/Message/Index/{userid}");
        }

        private IndexPageModel GetPageModel(int userid)
        {
            List<Message> messages =
                  _repoMessage.Table.Include("ChatUser").OrderByDescending(m => m.DateTime).ToList();

            List<MessageModel> mesmodels = messages.Select(mm => new MessageModel
            {
                UserName = $"{mm.ChatUser.LastName} {mm.ChatUser.FirstName}",
                MessageText = mm.Text,
                CreateTime = mm.DateTime.ToLocalTime()
            }).ToList();

            return new IndexPageModel
            {
                UserId = userid,
                NewMessageText = "",
                Messages = mesmodels
            };
        }
    }
}