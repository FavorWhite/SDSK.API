using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class AttachmentsController : ApiController
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

        // [Route]
        [HttpGet]
        [VersionedRoute("api/mails/{id}/attachments", 1)]
        public IHttpActionResult Index(long id, string extention = null, int status = 0)
        {
            var model = attachs.Where(x => x.MailId == id);
            if (extention != null)
                model = model.Where(x => x.FileExtention == extention);
            if (status != 0)
                model = model.Where(x => x.StatusId == status);
            return Ok(model);
        }

        [Route(Name = "GetAttachmentById")]
        [HttpGet]
        [VersionedRoute("api/mails/{id}/attachments/{attId}", 1)]
        public IHttpActionResult Get(long id, int attId)
        {
            var model = attachs.FirstOrDefault(m => m.Id == attId);
            if (model == null)
                return NotFound();
            return Ok(model);
        }

       
        [HttpPost]
        [VersionedRoute("api/mails/{id}/attachments", 1)]
        public IHttpActionResult Post(long id, [FromBody]Attachement model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest();
            model.Id = attachs[attachs.Count - 1].Id + 1;
            attachs.Add(model);
            return CreatedAtRoute("GetAttachmentById", new { attId = model.Id }, model);
        }

        [VersionedRoute("api/mails/{id}/attachments/{attId}", 1)]
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

        [VersionedRoute("api/mails/{id}/attachments/{attId}", 1)]
        public IHttpActionResult Delete(long id, int attId)
        {
            var model = attachs.Where(m => m.MailId == id).FirstOrDefault(m => m.Id == attId);
            if (model != null)
                attachs.Remove(model);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
