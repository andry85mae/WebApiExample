using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiExample.Models;
using WebApiExample.Utility;

namespace WebApiExample.Controllers
{
    [RoutePrefix("api/attribute")]
    public class AttributeRoutingController : ApiController
    {

        [HttpGet]
        [Route("custom")]
        public async Task<HttpResponseMessage> GetSampleAttributeValue()
        {
            return Request.CreateResponse(HttpStatusCode.OK, 2);
        }

        [HttpGet]
        [Route("value/{val:int:min(1):range(1,10)}")]
        public async Task<HttpResponseMessage> GetValue(int val)
        {
            return Request.CreateResponse(HttpStatusCode.OK, val - 2);
        }

        [HttpGet]
        [Route("optional/{val:int=10}")]
        public async Task<HttpResponseMessage> GetOptional(int val)
        {
            return Request.CreateResponse(HttpStatusCode.OK, val);
        }


        [HttpPost]
        [Route("create")]
        public async Task<HttpResponseMessage> Create(Phone p)
        {

            StoreWarehouse.Phones.Add(p);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("createandcheck")]
        public async Task<HttpResponseMessage> CreateAndCheck([FromUri] bool replace, [FromBody] Phone p)
        {

            Phone phone = StoreWarehouse.Phones.FirstOrDefault(x => x.Name == p.Name);
            if (phone != null)
            {
                if (replace == true)
                {
                    StoreWarehouse.Phones.Remove(phone);
                    StoreWarehouse.Phones.Add(p);
                }
                else
                {
                    StoreWarehouse.Phones.Add(p);
                }
            }
            else
            {
                StoreWarehouse.Phones.Add(p);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpGet]
        [Route("getallphone")]
        public async Task<HttpResponseMessage> GetAllPhone()
        {
            return Request.CreateResponse(HttpStatusCode.OK, StoreWarehouse.Phones);
        }
    }
}
