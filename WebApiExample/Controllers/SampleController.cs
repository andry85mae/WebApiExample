using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiExample.Controllers
{
    public class SampleController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> GetSampleValue()
        {
            return Request.CreateResponse(HttpStatusCode.OK, 1);
        }

        
    }
}
