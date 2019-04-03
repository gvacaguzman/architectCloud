using DeliveryPizzaRequest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DeliveryPizzaRequest.Controllers
{
    public class DeliveryRequestDataManager
    {
        private int deliveryRequestId = 0;
        /*
         * This method will returns a json string that contains the complete information about all the requests
         */
        public IEnumerable<DeliveryRequest> Get()
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\DeliveryRequest.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\DeliveryRequest.txt";
            System.Console.WriteLine("path: " + path);

            string[] fileLines = File.ReadAllLines(path);
            List<DeliveryRequest> requestList = new List<DeliveryRequest>();
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                var deliveryRequest = new DeliveryRequest();
                int id = 0;
                int.TryParse(lineInfo[0], out id);
                deliveryRequest.Id = id;
                deliveryRequest.RequestStatus = lineInfo[1];
                deliveryRequest.RequestClient = GetRequestClientInfo(lineInfo[2]);
                deliveryRequest.RequestDetail = GetRequestDetails(lineInfo[3]);
                deliveryRequest.DeliveryMan = GetDeliveryManDetails(lineInfo[4]);
                deliveryRequest.RequestDate = lineInfo[5];
                requestList.Add(deliveryRequest);
                deliveryRequestId = id;
            }

            return requestList;
        }

        // GET: api/DeliveryRequest/5
        public DeliveryRequest Get(int id)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\DeliveryRequest.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\DeliveryRequest.txt";
            string[] fileLines = File.ReadAllLines(path);
            DeliveryRequest deliveryRequest = new DeliveryRequest();
            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                if (id.ToString().Equals(lineInfo[0]))
                {
                    deliveryRequest.Id = id;
                    deliveryRequest.RequestStatus = lineInfo[1];
                    deliveryRequest.RequestClient = GetRequestClientInfo(lineInfo[2]);
                    deliveryRequest.RequestDetail = GetRequestDetails(lineInfo[3]);
                    deliveryRequest.DeliveryMan = GetDeliveryManDetails(lineInfo[4]);
                    deliveryRequest.RequestDate = lineInfo[5];
                }
            }

            return deliveryRequest;
        }

        // POST: api/DeliveryRequest
        public void Post(DeliveryRequest value)
        {
            //Delivery Request Input
            //string deliveryRequestpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\DeliveryRequest.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string deliveryRequestpath = rootPath + "\\Content\\DeliveryRequest.txt";
            deliveryRequestId++;
            string newDeliveryRequestLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                deliveryRequestId,
                value.RequestStatus,
                value.RequestClient.Code,
                value.RequestDetail.Code,
                value.DeliveryMan.Code,
                DateTime.Now.ToString("yyyyMMddHHmmSS"));

            File.AppendAllText(deliveryRequestpath, newDeliveryRequestLine);

            //Delivery Request Client
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

            //Delivery Request detail
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

            //Delivery Delivery Man
            //string deliveryManpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\DeliveryMan.txt");
            string deliveryManpath = rootPath + "\\Content\\DeliveryMan.txt";
            string newDeliveryManLine = string.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                value.DeliveryMan.Code,
                value.DeliveryMan.Name,
                value.DeliveryMan.LastName,
                value.DeliveryMan.Direction,
                value.DeliveryMan.CI,
                value.DeliveryMan.Cellphone,
                value.DeliveryMan.MotorcicleCode);

            File.AppendAllText(deliveryManpath, newDeliveryManLine);
        }

        // PUT: api/DeliveryRequest/5
        public void Put(int id, string value)
        {
        }

        // DELETE: api/DeliveryRequest/5
        public void Delete(int id)
        {
        }

        private DeliveryMan GetDeliveryManDetails(string code)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Content\DeliveryMan.txt");
            string rootPath;
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("HOME")))
                rootPath = Environment.GetEnvironmentVariable("HOME") + "\\site\\wwwroot\\bin";
            else if (HttpContext.Current != null)
                rootPath = HttpContext.Current.Server.MapPath("~");
            else
                rootPath = ".";
            string path = rootPath + "\\Content\\DeliveryMan.txt";
            string[] fileLines = File.ReadAllLines(path);
            DeliveryMan deliveryMan = null;

            for (int i = 1; i < fileLines.Length; i++)
            {
                string[] lineInfo = fileLines[i].Split('|');

                if (code.Equals(lineInfo[0]))
                {
                    deliveryMan = new DeliveryMan();
                    deliveryMan.Code = lineInfo[0];
                    deliveryMan.Name = lineInfo[1];
                    deliveryMan.LastName = lineInfo[2];
                    deliveryMan.Direction = lineInfo[3];
                    deliveryMan.CI = lineInfo[4];
                    deliveryMan.Cellphone = lineInfo[5];
                    deliveryMan.MotorcicleCode = lineInfo[6];
                }
            }

            return deliveryMan;
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