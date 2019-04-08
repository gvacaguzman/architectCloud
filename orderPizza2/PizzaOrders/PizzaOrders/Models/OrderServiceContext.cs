using OrderService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PizzaOrders.Models
{
    public class OrderServiceContext
    {
        /*public OrderServiceContext(DbContextOptions<OrderServiceContext> options)
            : base(options)
        { }*/

        public List<Order> Orders { get; set; }
        public OrderItem OrderItems { get; set; }
        public Restaurant Restaurants { get; set; }
        public MenuItem MenuItems { get; set; }

        private string orderId = "0";
        /*
         * This method will returns a json string that contains the complete information about all the requests
         */
        public IEnumerable<Order> Get()
        {
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\Orders.txt";
            System.Console.WriteLine("path: " + path);

            string[] fileLines = File.ReadAllLines(path);
            
            List<Order> requestList = new List<Order>();
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                var order = new Order();
                var id = lineInfo[0];
                order.OrderId = id;
                OrderStatus orderStatus = OrderStatus.Created;
                Enum.TryParse(lineInfo[1], out orderStatus);
                order.OrderStatus = orderStatus;
                order.CreationDateTime = lineInfo[2];
                requestList.Add(order);
                orderId = id;
            }

            return requestList;
        }

        public void PostOrder(Order order)
        {
            /*//Delivery Request Input
            string orderspath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\Orders.txt");
            orderId;
            string newOrdersLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                ordersId,
                value.RequestStatus,
                value.RequestClient.Code,
                value.RequestDetail.Code,
                value.DeliveryMan.Code,
                DateTime.Now.ToString("yyyyMMddHHmmSS"));

            File.AppendAllText(deliveryRequestpath, newDeliveryRequestLine);

            //Delivery Request Client
            string requestClientpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\RequestClient.txt");
            string newRequestClientLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                value.RequestClient.Code,
                value.RequestClient.Name,
                value.RequestClient.LastName,
                value.RequestClient.Direction,
                value.RequestClient.CI,
                value.RequestClient.Cellphone);

            File.AppendAllText(requestClientpath, newRequestClientLine);

            //Delivery Request detail
            string requestDetailpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\RequestDetail.txt");
            string newRequestDetailLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                value.RequestDetail.Code,
                value.RequestDetail.Flavor1,
                value.RequestDetail.Flavor2,
                value.RequestDetail.Flavor3,
                value.RequestDetail.Flavor4,
                value.RequestDetail.Size,
                value.RequestDetail.OtherInfo,
                value.RequestDetail.Price);

            File.AppendAllText(requestDetailpath, newRequestDetailLine);

            //Delivery Delivery Man
            string deliveryManpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\DeliveryMan.txt");
            string newDeliveryManLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                value.DeliveryMan.Code,
                value.DeliveryMan.Name,
                value.DeliveryMan.LastName,
                value.DeliveryMan.Direction,
                value.DeliveryMan.CI,
                value.DeliveryMan.Cellphone,
                value.DeliveryMan.MotorcicleCode);

            File.AppendAllText(deliveryManpath, newDeliveryManLine);
            */
        }

        public Order GetById(string orderId)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\Orders.txt");
            string[] fileLines = File.ReadAllLines(path);
            Order order = null;
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                order = new Order();
                string id = lineInfo[0];
                if (orderId.Equals(id))
                {
                    OrderStatus orderStatus = OrderStatus.Created;
                    Enum.TryParse(lineInfo[1], out orderStatus);
                    order.OrderStatus = orderStatus;
                    order.CreationDateTime = lineInfo[2];
                    orderId = id;
                }
            }

            return order;
        }
    }
}