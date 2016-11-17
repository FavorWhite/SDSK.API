using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Epam.Sdesk.Model;

namespace SDSK.API.Controllers
{
    public class JiraitemsController : ApiController
    {
        static List<JiraItem> jiraItems= new List<JiraItem>()
        {
            new JiraItem()
            {
                JiraItemId = 1,
                JiraNumber = 1,
                JiraSourceId = 1,
                RequestIdType = 1
            },
            new JiraItem()
            {
                JiraItemId = 2,
                JiraNumber = 2,
                JiraSourceId = 2,
                RequestIdType = 2
            },
            new JiraItem()
            {
                JiraItemId = 3,
                JiraNumber = 3,
                JiraSourceId = 3,
                RequestIdType = 3
            }
        };
       [Route("api/jiraitems/{id:jiraid}")]
       [HttpGet]
        public IHttpActionResult Get(string id)
        {
            id = id.Substring(5);
            int val;
            var isNumber = Int32.TryParse(id, out val);
            if (isNumber)
            {
            var model = jiraItems.FirstOrDefault(j => j.JiraItemId == val);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            return NotFound();
            
        }
        public IHttpActionResult Get(int id = 1)
        {
            var model = jiraItems.FirstOrDefault(j => j.JiraItemId == id);
            if (model == null)
                return NotFound();
            return Ok(model);
        }

    }
}
