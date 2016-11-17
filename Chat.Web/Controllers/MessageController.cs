using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Chat.Core.DAL;
using Chat.Core.Infrastructure;
using Chat.Web.Models;

namespace Chat.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IRepository<Message> _repository;

        public MessageController(IRepository<Message> repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            List<Message> messages =
                _repository.Select(null, mes => mes.OrderByDescending(m => m.DateTime),
                    new List<Expression<Func<Message, object>>> {mes => mes.ChatUser}).ToList();

            List<MessageModel> mesmodels = messages.Select(mm => new MessageModel
            {
                UserName = $"{mm.ChatUser.LastName} {mm.ChatUser.FirstName}",
                MessageText = mm.Text,
                CreateTime = mm.DateTime.ToLocalTime()
            }).ToList();

            IndexPageModel indPage = new IndexPageModel
            {
                NewMessageText = "",
                Messages = mesmodels
            };
            return View(indPage);
        }

        [HttpPost]
        public ActionResult SendMessage(IndexPageModel model)
        {
            _repository.Insert(new Message {Text = model.NewMessageText, DateTime = DateTime.Now});
            return View("Index");
        }

    }
}