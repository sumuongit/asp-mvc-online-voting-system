using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineVotingSystem.Controllers
{
    public class VoterController : Controller
    {
        OnlineVotingSystemEntities db = new OnlineVotingSystemEntities();
        // GET: Voter
        public ActionResult Index()
        {
            var voters = db.Voters.ToList();
            return View(voters);
        }
        public ActionResult StartVote()
        {
            var voters = db.Voters.Where(x => x.IsSelected == false).ToList();
            foreach(var aVoter in voters)
            {
                aVoter.IsSelected = true;
                //db.SaveChanges();
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Voter");
        }


        public ActionResult EndVote()
        {
            var voters = db.Voters.Where(x => x.IsSelected == true).ToList();
            foreach (var aVoter in voters)
            {
                aVoter.IsSelected = false;
                //db.SaveChanges();
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Voter");
        }
        

        public ActionResult SendNotification()
        {
            var voters = db.Voters.Where(x => x.IsMailSent == false).ToList();
            var voter = db.Voters.FirstOrDefault(u => u.UniqueIdentification == null);

            if (voter == null)
            {
                TempData["Message"] = "Notification Sent Already.";
                return RedirectToAction("Index", "Voter");
            }

            //**************************************************************
            //FOR SENDING EMAIL
            //**************************************************************
          
            foreach (var voterObject in voters)
            {
                voterObject.UniqueIdentification = Guid.NewGuid();

                string url = Url.Action("Index", "VotingPanel", new System.Web.Routing.RouteValueDictionary(new { id = voterObject.UniqueIdentification }), "http", Request.Url.Host);

                var fromEmail = new MailAddress("bcs24batch@logicbd.org", "Online Voting!!");
                var toEmail = new MailAddress(voterObject.Email);
                var fromEmailPassword = "B24b#123%";
                string subject = "Executive Committee Election of 24 th BCS Association 2019";

                string body = "<br/><br/>Executive Committee Election of 24 th BCS (Admin) Association 2019" +
                    "<br/><br/>Welcome to Online Voting System. To cast your vote online please click on the link below. " +
                    " <br/><br/> Link: <a href='" + url + "'>" + url + "</a> " +
                    "<br/><br/>If you have any problem in accessing the link please contact.";

                var smtp = new SmtpClient
                {
                    Host = "logicbd.org",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
                };

                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    try
                    {
                        smtp.Send(message);
                        voterObject.IsMailSent = true;
                        db.SaveChanges();
                        TempData["Message"] = "Notification Sent Successfully.";
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "Sending Mail Notification Failed";
                    }

                //**************************************************************
                //FOR SENDING SMS
                //**************************************************************
                //string result = "";
                //WebRequest request = null;
                //HttpWebResponse response = null;
                //try
                //{
                //    string smsText = "Executive Committee Election of 24 th BCS (Admin) Association 2019 \r\n" +
                //        "Welcome to Online Voting System. To cast your vote online please click on the link below. \r\n " +
                //        "Link: " + url + "\r\n " +
                //        "If you have any problem in accessing the link please visit your email to find this link.";
                //    String to = voterObject.MobileNo; //Recipient Phone Number multiple number must be separated by comma
                //    String token = "41b9a5c4a1063abae96083b72edf6925"; //generate token from the control panel
                //    String message = System.Uri.EscapeUriString(smsText); //do not use single quotation (') in the message to avoid forbidden result
                //    String urlSms = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                //    request = WebRequest.Create(urlSms);

                //    // Send the 'HttpWebRequest' and wait for response.
                //    response = (HttpWebResponse)request.GetResponse();
                //    Stream stream = response.GetResponseStream();
                //    Encoding ec = Encoding.GetEncoding("utf-8");
                //    StreamReader reader = new
                //    StreamReader(stream, ec);
                //    result = reader.ReadToEnd();
                //    Console.WriteLine(result);
                //    reader.Close();
                //    stream.Close();
                //}
                //catch (Exception exp)
                //{
                //    //Console.WriteLine(exp.ToString());
                //    TempData["Message"] = "Sending SMS Notification Failed.";
                //}
                //finally
                //{
                //    if (response != null)
                //        response.Close();
                //}
            }

            //**************************************************************

            return RedirectToAction("Index", "Voter");
         }
    }
}