using OrderService.Models;
using PizzaOrders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace PizzaOrders.Controllers
{
    public class OrdersController : ApiController
    {
        public static OrderServiceContext _context = new OrderServiceContext();
        //private readonly OrderServiceContext _context;

        // GET: api/orders
        //[HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            var orders = _context.Get();

            return orders;
        }

        // GET: api/orders/1
        //[HttpGet("{orderId}")]
        public Order GetOrder(string orderId)
        {
            var order = _context.GetById(orderId);

            /*if (order == null)
            {
                return NotFound();
            }*/

            return order;
        }


        // POST: api/orders
        //[HttpPost]
        public Order PostOrder(Order order)
        {
            order.CreationDateTime = DateTime.Now.ToString();
            order.OrderStatus = OrderStatus.Created;
            _context.PostOrder(order);

            return order;
        }

        // DELETE: api/orders/:orderId
        //[HttpDelete("{orderId}")]
        public void RemoveOrderMenuItem(long orderId)
        {
            /*var order = await _context.Orders.FindAsync(orderId);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();*/
        }

        /*
        // GET: api/orders/:orderId/items
        //[HttpGet("{orderId}/items")]
        public IEnumerable<OrderItem> GetOrderMenuItems(long orderId)
        {
            return await _context.OrderItems.Where(item => item.OrderId == orderId).ToListAsync();
        }
        */

       /* // POST: api/orders/:orderId/items
        //[HttpPost("{orderId}/items")]
        public OrderItem PostOrderMenuItem(long orderId, OrderItem orderItem)
        {
            orderItem.OrderId = orderId;
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostOrderMenuItem), new { id = orderItem.OrderItemId }, orderItem);
        }

        // GET: api/orders/:orderId/items/:itemId
        //[HttpGet("{orderId}/items/{itemId}")]
        public OrderItem GetOrderMenuItem(long orderId, long itemId)
        {
            return await _context.OrderItems.Where(item => item.OrderId == orderId && item.OrderItemId == itemId).FirstAsync();
        }

        // PUT: api/orders/:orderId/items/:itemId
        //[HttpPut("{orderId}/items/{itemId}")]
        public async void PutOrderItem(long orderId, long itemId, OrderItem orderItem)
        {
            if (itemId != orderItem.OrderItemId)
            {
                return BadRequest();
            }

            var existentOrderItem = _context.Entry(orderItem);
            existentOrderItem.State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/orders/:orderId/items/:itemId
        //[HttpDelete("{orderId}/items/{itemId}")]
        public void RemoveOrderMenuItem(long orderId, long itemId)
        {
            var orderItem = await _context.OrderItems.Where(item => item.OrderId == orderId && item.OrderItemId == itemId).FirstAsync();

            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();


        }*/
    }
}
