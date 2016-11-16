using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    [RoutePrefix("api/mails/{id}/attachments")]
    public class AttachmentsController : ApiController
    {
        static public List<Attachement> attachs= new List<Attachement>()
        {
            new Attachement()
            {
                Id = 1,
                FileName = "someFile1",
                FileExtention = "x",
                Path = @"C:\Users\",
                StatusId = 1,
                MailId = 1
            },
            new Attachement()
            {
                Id = 1,
                FileName = "someFile2",
                FileExtention = "x",
                Path = @"C:\Users\",
                StatusId = 1,
                MailId = 2
            },
            new Attachement()
            {
                Id = 1,
                FileName = "someFile3",
                FileExtention = "x",
                Path = @"C:\Users\",
                StatusId = 1,
                MailId = 3
            }
        };
        // GET: api/Attachments
        public IEnumerable<Attachement> Get()
        {
            return attachs;
        }

        // GET: api/Attachments/5
        public Attachement Get(string extention= null, int status =0)
        {
            var model;
            if (extention == null));
            return attachs.FirstOrDefault(m => m.Id == id);
        }
        //        GET api/mails/{id}/attachements/{attId}? extention = { ext }
        //GET api/mails/{id}/attachements/{attId}? extention = { ext }? status = { status }

        // GET: api/Attachments/5
       [Route ("{attId:int}")]
        public Attachement Get(int attId)
        {
            return attachs.FirstOrDefault(m => m.Id == attId);
        }
        // POST: api/Attachments
        public void Post([FromBody]Attachement value)
        {
            attachs.Add(value);
        }

        // PUT: api/Attachments/5
        public void Put(int attId, [FromBody]Attachement value)
        {
            var updatingMail = attachs.Find(m => m.Id == attId);
            int updatingindex = attachs.IndexOf(updatingMail);
            attachs[updatingindex] = value;
        }

        // DELETE: api/Attachments/5
        public void Delete(long id)
        {
            attachs.Remove(attachs.FirstOrDefault(m => m.Id == id));
        }
    }
}
