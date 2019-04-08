using OrderRequest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OrderRequest.Controllers
{
    public class OrderRequestDataManager
    {
        private int OrderRequestId = 0;
        /*
         * This method will returns a json string that contains the complete information about all the requests
         */
        public IEnumerable<OrderPizzaRequest> Get()
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\OrderRequest.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\OrderRequest.txt";
            System.Console.WriteLine("path: " + path);

            string[] fileLines = File.ReadAllLines(path);
            List<OrderPizzaRequest> requestList = new List<OrderPizzaRequest>();
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                var OrderRequest = new OrderPizzaRequest();
                int id = 0;
                int.TryParse(lineInfo[0], out id);
                OrderRequest.Id = id;
                OrderRequest.RequestStatus = lineInfo[1];
                OrderRequest.RequestClient = GetRequestClientInfo(lineInfo[2]);
                OrderRequest.RequestDetail = GetRequestDetails(lineInfo[3]);
                OrderRequest.RequestDate = lineInfo[4];
                requestList.Add(OrderRequest);
                OrderRequestId = id;
            }

            return requestList;
        }

        // GET: api/OrderRequest/5
        public OrderPizzaRequest Get(int id)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\OrderRequest.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\OrderRequest.txt";
            string[] fileLines = File.ReadAllLines(path);
            OrderPizzaRequest OrderRequest = new OrderPizzaRequest();
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                if (id.ToString().Equals(lineInfo[0]))
                {
                    OrderRequest.Id = id;
                    OrderRequest.RequestStatus = lineInfo[1];
                    OrderRequest.RequestClient = GetRequestClientInfo(lineInfo[2]);
                    OrderRequest.RequestDetail = GetRequestDetails(lineInfo[3]);
                    OrderRequest.RequestDate = lineInfo[4];
                }
            }

            return OrderRequest;
        }

        // POST: api/OrderRequest
        public void Post(OrderPizzaRequest value)
        {
            //Order Request Input
            //string OrderRequestpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\OrderRequest.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string OrderRequestpath = rootPath + "\\Content\\OrderRequest.txt";
            OrderRequestId++;
            string newOrderRequestLine = string.Format("{0}|{1}|{2}|{3}|{4}",
                OrderRequestId,
                value.RequestStatus,
                value.RequestClient.Code,
                value.RequestDetail.Code,
                DateTime.Now.ToString("yyyyMMddHHmmSS"));

            File.AppendAllText(OrderRequestpath, newOrderRequestLine);

            //Order Request Client
            //string requestClientpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\RequestClient.txt");
            string requestClientpath = rootPath + "\\Content\\RequestClient.txt";
            string newRequestClientLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                value.RequestClient.Code,
                value.RequestClient.Name,
                value.RequestClient.LastName,
                value.RequestClient.Direction,
                value.RequestClient.CI,
                value.RequestClient.Cellphone);

            File.AppendAllText(requestClientpath, newRequestClientLine);

            //Order Request detail
            //string requestDetailpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\RequestDetail.txt");
            string requestDetailpath = rootPath + "\\Content\\RequestDetail.txt";
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
        }

        // PUT: api/OrderRequest/5
        public void Put(int id, string value)
        {
        }

        // DELETE: api/OrderRequest/5
        public void Delete(int id)
        {
        }

        private RequestDetail GetRequestDetails(string code)
        {
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\RequestDetail.txt";
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\RequestDetail.txt");
            string[] fileLines = File.ReadAllLines(path);
            RequestDetail requestDetail = null;

            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                if (code.Equals(lineInfo[0]))
                {
                    requestDetail = new RequestDetail();
                    requestDetail.Code = lineInfo[0];
                    requestDetail.Flavor1 = lineInfo[1];
                    requestDetail.Flavor2 = lineInfo[2];
                    requestDetail.Flavor3 = lineInfo[3];
                    requestDetail.Flavor4 = lineInfo[4];
                    requestDetail.Size = lineInfo[5];
                    requestDetail.OtherInfo = lineInfo[6];
                    requestDetail.Price = lineInfo[7];
                }
            }

            return requestDetail;
        }

        private RequestClient GetRequestClientInfo(string code)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\RequestClient.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\RequestClient.txt";

            string[] fileLines = File.ReadAllLines(path);
            RequestClient requestClient = null;

            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                if (code.Equals(lineInfo[0]))
                {
                    requestClient = new RequestClient();
                    requestClient.Code = lineInfo[0];
                    requestClient.Name = lineInfo[1];
                    requestClient.LastName = lineInfo[2];
                    requestClient.Direction = lineInfo[3];
                    requestClient.CI = lineInfo[4];
                    requestClient.Cellphone = lineInfo[5];
                }
            }

            return requestClient;
        }
    }
}