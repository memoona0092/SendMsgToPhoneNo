using Nexmo.Api.Request;
using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendMsgToPhoneNo.Models;

namespace SendMsgToPhoneNo.Controllers
{
    public class SendSMSController : Controller
    {
     
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        //this Function will use to send the msg
        [HttpPost]
        public ActionResult SendMessage(TxtMessage message)
        {
            //this is api key i used vonage 
            var credentials = Credentials.FromApiKeyAndSecret(
                         "2bcfad0f",
                         "BrMNj4ubzrUTVjNp"
                        );

            var nexmoClient = new NexmoClient(credentials);
            var response = nexmoClient.SmsClient.SendAnSms(new Nexmo.Api.Messaging.SendSmsRequest()
            {
                To = message.To,
                From = "Nexmo",
                Text = message.ContentMsg
            });

            return View();
        }
    }
}
