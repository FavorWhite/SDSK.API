using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        public IHttpActionResult Get()
        {
            if (mails == null)
                return NotFound();
            var model = mails;
            return Ok(model);
        }
        public IHttpActionResult Get(long id)
        {
            var model = mails.FirstOrDefault(m => m.Id == id);
            if (model == null)
                return NotFound();
            return Ok(model);
        }
        public IHttpActionResult Post([FromBody]Mail model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
            mails.Add(model);
            return CreatedAtRoute("DefaultApi", model.Id, model);
        }

        public IHttpActionResult Put(long id, [FromBody]Mail model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
            var updatingMail = mails.FirstOrDefault(m => m.Id == id);
            if (updatingMail == null)
                return NotFound();
            int updatingindex = mails.IndexOf(updatingMail);
            mails[updatingindex] = model;
            return StatusCode(HttpStatusCode.NoContent);
        }
        public IHttpActionResult Delete(long id)
        {
            var model = mails.FirstOrDefault(m => m.Id == id);
            if (model!=null)
                mails.Remove(model);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
