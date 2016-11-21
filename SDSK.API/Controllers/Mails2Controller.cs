using Epam.Sdesk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDSK.API.Controllers
{

    
    public class Mails2Controller : ApiController
    {
        static public List<Attachement> attachs = new List<Attachement>()
        {
            new Attachement()
            {
                Id = 1,
                FileName = "File1",
                FileExtention = "doc",
                Path = @"C:\Users\",
                StatusId = 1,
                MailId = 1
            },
            new Attachement()
            {
                Id = 2,
                FileName = "File2",
                FileExtention = "exe",
                Path = @"C:\Users\",
                StatusId = 1,
                MailId = 2
            },
            new Attachement()
            {
                Id = 3,
                FileName = "File3",
                FileExtention = "png",
                Path = @"C:\Users\",
                StatusId = 1,
                MailId = 1
            },
            new Attachement()
            {
                Id = 4,
                FileName = "File3",
                FileExtention = "png",
                Path = @"C:\Users\",
                StatusId = 2,
                MailId = 1
            }
        };
        static public List<Mail> mails = new List<Mail>()
        {
            new Mail()
            {
                Id = 1,
                Body = "111 Email",
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
                Body = "222 Email",
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
                Body = "333 Email",
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

        //[VersionedRoute("api/mails", 2)]
        [VersionedRoute("api/mails", 2)]
        public IHttpActionResult Get()
        {
            if (mails == null)
                return NotFound();
            var model = mails;
            return Ok(model);
        }

        [VersionedRoute("api/mails/{id}", 2)]
        public IHttpActionResult Get(long id)
        {
            var model = mails.FirstOrDefault(m => m.Id == id);
            if (model == null)
                return NotFound();
            return Ok(model);
        }


        [VersionedRoute("api/mails", 2)]
        public IHttpActionResult Post([FromBody]Mail model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
            mails.Add(model);
            return CreatedAtRoute("DefaultApi", model.Id, model);
        }


        [VersionedRoute("api/mails/{id}", 2)]
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

        [VersionedRoute("api/mails/{id}", 2)]
        public IHttpActionResult Delete(long id)
        {
            var model = mails.FirstOrDefault(m => m.Id == id);
            if (model != null)
                mails.Remove(model);
            return StatusCode(HttpStatusCode.NoContent);
        }


       // [Route]
        [HttpGet]
       [VersionedRoute("api/mails/{id}/attachments", 2)]
        public IHttpActionResult Index(long id, string extention = null, int status = 0)
        {
            var model = attachs.Where(x => x.MailId == id);
            if (extention != null)
                model = model.Where(x => x.FileExtention == extention);
            if (status != 0)
                model = model.Where(x => x.StatusId == status);
            return Ok(model);
        }
        [HttpGet]
        [Route("{attId:int}", Name = "GetAttachmentById2")]
        [VersionedRoute("api/mails/{id}/attachments/{attId}", 2)]
        public IHttpActionResult Get(long id, int attId)
        {
            var model = attachs.FirstOrDefault(m => m.Id == attId);
            if (model == null)
                return NotFound();
            return Ok(model);
        }

        [Route]
        [HttpPost]
        [VersionedRoute("api/mails/{id}/attachments", 2)]
        public IHttpActionResult Post(long id, [FromBody]Attachement model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
            model.Id = attachs[attachs.Count - 1].Id + 1;
            attachs.Add(model);
            return CreatedAtRoute("GetAttachmentById2", new { attId = model.Id }, model);
        }

        [VersionedRoute("api/mails/{id}/attachments/{attId}", 2)]
        public IHttpActionResult Put(long id, int attId, [FromBody]Attachement model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
            var updatingAttach = attachs.Where(m => m.MailId == id).FirstOrDefault(m => m.Id == attId);
            if (updatingAttach == null)
                return NotFound();
            int updatingindex = attachs.IndexOf(updatingAttach);
            attachs[updatingindex] = model;
            return StatusCode(HttpStatusCode.NoContent);
        }

        [VersionedRoute("api/mails/{id}/attachments/{attId}", 2)]
        public IHttpActionResult Delete(long id, int attId)
        {
            var model = attachs.Where(m => m.MailId == id).FirstOrDefault(m => m.Id == attId);
            if (model != null)
                attachs.Remove(model);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }

}
