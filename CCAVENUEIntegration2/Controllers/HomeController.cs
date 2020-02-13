using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CCAVENUEIntegration2.Models;
using CCA.Util;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CCAVENUEIntegration2.Controllers
{
    public class HomeController : Controller
    {
        private WebRequest request;
        private Stream dataStream;
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IActionResult Index()
        {
            //MyWebRequest();
            return View();
        }


        //[Route("Home/{hotelname:regex(\\w+-\\w+)}")]
        [Route("Home/{hotelname:regex(\\w+-hotel$)}")]
        [HttpGet]
        public IActionResult CitySearch(string hotelname)
        {
            string strhotelname = hotelname;
            return View();
        }

        public void MyWebRequest()

        {
            request = WebRequest.Create("https://test.ccavenue.com/transaction/transaction.do?command=initiateTransaction");
            // Create POST data and convert it to a byte array.
            string postData = "enc_request=4bbb60b13b2460f7d545a17129a61b847ae4b28ffdb0e90f2da12a057b4c81f410044efd16de73c5290e071254154962eb36de919e284b20dbd83c4251cf010407d0a241955cad66baa9647b51393036e12a9f99234326316a864dadabe0b6dbfbbf27c20d08af2a9f1617dc5aa5a145d52cd98b2aae1ff86c7079ed17543f4b3fcb777d0e42bc4720821b398565a9a2c013a37e47b283a359140fa4cd6950cb859cc2aa2b97b94fe4c0d4d755f8e02e7061dd97cf41fdb6a470e0b8777a5b4cdc417862d845004eeb386100b916d2cd&access_code=AVGA87GI77BH26AGHB";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();


            // Get the original response.
            WebResponse response = request.GetResponse();

            var status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();



        }
        [HttpGet]
        public IActionResult CheckOut() { return View(); }

        [HttpPost]
        public IActionResult ShowPaymentPage()
        {
            var queryParameter = new CCACrypto();
            Random rand = new Random(100);
            int orderID = rand.Next(000000000, 999999999);
            string orderAmount = "20000";
            return View("CcAvenue", new CcAvenueViewModel(queryParameter.Encrypt(PreparePaymentgatewayParameter(Convert.ToString(orderID), orderAmount), configuration["CCAvenueWorkingKey"]), configuration["CCAvenueAccess_code"], configuration["CCavenueURL"]));
        }
        [HttpPost]
        public IActionResult PaymentCofirmation(string encResp)
        {
            var decryption = new CCACrypto();
            var response = decryption.Decrypt(encResp, configuration["CCAvenueWorkingKey"]);
            return View("PaymentCofirmation");
        }
        [HttpPost]
        public IActionResult PaymentCancel(string encResp)
        {
            var decryption = new CCACrypto();
            var decryptedParameters = decryption.Decrypt(encResp, configuration["CCAvenueWorkingKey"]);
            return View("PaymentCanceled");
        }
        private string PreparePaymentgatewayParameter(string orderId, string amount)
        {
            var queryParameters = new Dictionary<string, string>
                {
                {"order_id", orderId},
                {"merchant_id", configuration["CCAvenueMerchentID"]},
                {"amount", amount},
                {"currency",configuration["CCAvenueCurrency"] },
                {"tid",System.DateTime.Now.Ticks.ToString() },
                {"redirect_url",configuration["CCAvenuePaymentConfirmationURL"] },
                {"cancel_url",configuration["CCAvenueCancelURL"]},
                {"request_type",configuration["CCAvenueRequestType"] },
                {"response_type",configuration["CCAvenueResponseType"] },
                {"version",configuration["CCAvenueVersion"] }
                }.Select(item => string.Format("{0}={1}", item.Key, item.Value));
            return string.Join("&", queryParameters);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}




