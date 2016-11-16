using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class MailsController : ApiController
    {

        static public List<Mail> mails = new List<Mail>()
        {
            new Mail()
            {
                Id = 1,
                Body = "1 Email",
                Subject = "Test 1 Email",
                Priority = Priority.Medium,
                To = "test@test.com",
                Cc = "test@test.com",
                Sender = "mailsender@mailsender.com",
                Received = DateTime.Now,
                Saved = DateTime.Now,
                AttachementId = 1
            },
            new Mail()
            {
                Id = 2,
                Body = "2 Email",
                Subject = "Test 2 Email",
                Priority = Priority.Medium,
                To = "test@test.com",
                Cc = "test@test.com",
                Sender = "mailsender@mailsender.com",
                Received = DateTime.Now,
                Saved = DateTime.Now,
                AttachementId = 2
            },
            new Mail()
            {
                Id = 3,
                Body = "3 Email",
                Subject = "Test 3 Email",
                Priority = Priority.Medium,
                To = "test@test.com",
                Cc = "test@test.com",
                Sender = "mailsender@mailsender.com",
                Received = DateTime.Now,
                Saved = DateTime.Now,
                AttachementId = 3
            }
        };
        // GET: api/Mails
        public IEnumerable<Mail> Get()
        {
            return mails;
        }

        // GET: api/Mails/5
        public Mail Get(int id)
        {
            return mails.FirstOrDefault(m => m.Id == id);
        }

        // POST: api/Mails
        public void Post([FromBody]Mail value)
        {
            mails.Add(value);
        }

        // PUT: api/Mails/5
        public void Put(int id, [FromBody]Mail value)
        {
            var updatingMail = mails.Find(m => m.Id == id);
            int updatingindex = mails.IndexOf(updatingMail);
            mails[updatingindex] = value;
        }

        // DELETE: api/Mails/5
        public void Delete(int id)
        {
            mails.Remove(mails.FirstOrDefault(m => m.Id == id));
        }
    }
}
