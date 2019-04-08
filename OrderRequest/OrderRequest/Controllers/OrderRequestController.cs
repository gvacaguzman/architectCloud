using OrderRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderRequest.Controllers
{
    public class OrderRequestController : ApiController
    {
        public static OrderRequestDataManager OrderRequestDataManager = new OrderRequestDataManager();

        // GET: api/OrderRequest
        public IEnumerable<OrderPizzaRequest> Get()
        {
            return OrderRequestDataManager.Get();
        }

        // GET: api/OrderRequest/5
        public OrderPizzaRequest Get(int id)
        {
            return OrderRequestDataManager.Get(id);
        }

        // POST: api/OrderRequest
        public void Post([FromBody]OrderPizzaRequest value)
        {
            OrderRequestDataManager.Post(value);
        }

        // PUT: api/OrderRequest/5
        public void Put(int id, [FromBody]OrderPizzaRequest value)
        {
        }

        // DELETE: api/OrderRequest/5
        public void Delete(int id)
        {
        }
    }
}
