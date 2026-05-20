using ConnectFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace ConnectFlow.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult MySQL()
        {
            return View();
        }

        public IActionResult Sap()
        {
            return View();
        }

        public IActionResult Apis()
        {
            return View();
        }

        public IActionResult Consultoria()
        {
            return View();
        }
        [Route("Creditos")]
        public IActionResult Creditos()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Acessibilidade(Configuracao model)
        {
            if (model.NotificacoesEmail)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("connectflow.solucoes@gmail.com", "ConnectFlow Solutions");
                    mail.To.Add("seu-email-pessoal@hotmail.com");
                    mail.Subject = "Teste de Acessibilidade";
                    mail.Body = "<h1>Funciona!</h1><p>O envio de e-mail pelo seu sistema está operacional.</p>";
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("connectflow.solucoes@gmail.com", "xlpzypnqthigtmre");

                    smtp.Send(mail);

                    return Content("E-MAIL ENVIADO COM SUCESSO!");
                }
                catch (Exception ex)
                {
                
                    return Content("ERRO AO ENVIAR: " + ex.Message);
                }
            }

            return RedirectToAction("Consultoria");
        }
    }
}