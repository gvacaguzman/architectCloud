using DeliveryPizzaRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveryPizzaRequest.Controllers
{
    public class DeliveryRequestController : ApiController
    {
        public static DeliveryRequestDataManager deliveryRequestDataManager = new DeliveryRequestDataManager();

        // GET: api/DeliveryRequest
        public IEnumerable<DeliveryRequest> Get()
        {
            return deliveryRequestDataManager.Get();
        }

        // GET: api/DeliveryRequest/5
        public DeliveryRequest Get(int id)
        {
            return deliveryRequestDataManager.Get(id);
        }

        // POST: api/DeliveryRequest
        public void Post([FromBody]DeliveryRequest value)
        {
            deliveryRequestDataManager.Post(value);
        }

        // PUT: api/DeliveryRequest/5
        public void Put(int id, [FromBody]DeliveryRequest value)
        {
        }

        // DELETE: api/DeliveryRequest/5
        public void Delete(int id)
        {
        }
    }
}
