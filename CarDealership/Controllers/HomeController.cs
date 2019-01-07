using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

        public ActionResult Index()
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:64097/api/Car/GetCars");

            request.UserAgent = userAgent;

            //if we were dealing with an api with a key, a header would go here adding the key and the password

            //need to cast the request to a response and save to response variable
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK)
            {
                //stream reader for data

                StreamReader data = new StreamReader(response.GetResponseStream());

                string JsonData = data.ReadToEnd();

                JObject dataObject = JObject.Parse("{cars:" + JsonData + "}");

                ViewBag.Cars = dataObject;
            }

            return View();
        }



        public ActionResult Edit(int CarID)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:64097/api/Car/GetCar/" + CarID);

            request.UserAgent = userAgent;

            //if we were dealing with an api with a key, a header would go here adding the key and the password

            //need to cast the request to a response and save to response variable
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK)
            {
                //stream reader for data

                StreamReader data = new StreamReader(response.GetResponseStream());

                string JsonData = data.ReadToEnd();

                JObject dataObject = JObject.Parse("{cars:" + JsonData + "}");

                ViewBag.Car = dataObject;
            }

            return View();
        }

    }
}