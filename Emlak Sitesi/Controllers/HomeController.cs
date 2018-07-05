using Emlak_Sitesi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace Emlak_Sitesi.Controllers
{
    public class HomeController : Controller
    {
        public void DosyayaYaz()
        {
            Ilan İlan = new Ilan()
            {
                ID = Guid.NewGuid(),
                Baslik = "BAŞLIK",
                AdresAciklama = "ADRESS",
                BuyuklukM = 5,
                EmlakTipi = "aRSA",
                EklemeTarihi = DateTime.Now,
                IlaniVeren = "öMER sELİM",
                Fiyat = "1213",
                Ilce = "fİKİRTEPE",
                SatisTipi = "SATILIK",
                IlansAciklama = "İLAN AÇIKLAMASI",
                OdaSayisi = "",
                YayindaMi = true,
                MetaAbstract = "",
                MetaDescription = "",
                Metakeywords = ""
            };

            var json = new JavaScriptSerializer().Serialize(İlan);

            string path = Server.MapPath("~/wwwroot/");



            StreamWriter notDefteri = new StreamWriter(path + "Note.JSON", true);
            notDefteri.Write(json);
            notDefteri.Close();
        }
        public ActionResult Index()
        {
            string path = Server.MapPath("/wwwroot");
            var json = System.IO.File.ReadAllText(path + "/ilan.txt");
            var result = JsonConvert.DeserializeObject<List<Ilan>>(json);
            List<Ilan> data = result.ToList();
            data = data.OrderByDescending(x => x.EklemeTarihi).ToList();
            return View(data);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            ViewBag.msg = "";
            Form form = new Form();
            return View(form);
        }
        [HttpPost]
        public ActionResult Iletisim(Form Form)
        {
            try
            {
                if (string.IsNullOrEmpty(Form.Tel) || string.IsNullOrEmpty(Form.AdSoyad) || string.IsNullOrEmpty(Form.Konu) || string.IsNullOrEmpty(Form.Mesaj))
                {
                    ModelState.AddModelError(string.Empty, "Hata");
                    return View(Form);
                }

                //MailMessage ePosta = new MailMessage();
                //ePosta.From = new MailAddress("destek@fikirtepekentselemlak.com");
                //ePosta.To.Add("info@fikirtepekentselemlak.com");
                //ePosta.Subject = Form.Konu;
                //ePosta.Body = Form.Mesaj;

                //SmtpClient smtp = new SmtpClient();
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential("destek@fikirtepekentselemlak.com", "");
                //smtp.Port = 587;
                //smtp.Host = "mail.fikirtepekentselemlak.com";
                //smtp.Send(ePosta);

                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential =
                    new NetworkCredential("destek@fikirtepekentselemlak.com", "");
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("destek@fikirtepekentselemlak.com");
                smtpClient.Port = 587;
                smtpClient.Host = "mail.fikirtepekentselemlak.com";
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;

                message.From = fromAddress;
                message.Subject = Form.Konu;
                message.IsBodyHtml = true;
                message.Body = $"<h2>{Form.Mesaj}</h2></br>İsim:{Form.AdSoyad}<br>Email:{Form.Email}<br>Telefon:{Form.Tel}";
                message.To.Add("info@fikirtepekentselemlak.com");
                smtpClient.Send(message);


                ViewBag.msg = $"SAYIN {Form.AdSoyad.ToUpper()} MESAJINIZ İLETİLMİŞTİR.MESAJINIZ DOĞRULTUSUNDA EN KISA ZAMANDA GERİ DÖNÜŞ SAĞLANACAKTIR.İYİ GÜNLER DİLERİZ...";
                return View();
            }

            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                ModelState.AddModelError(string.Empty, "Hata:" + ex.Message);
                return View(Form);
            }
        }

        public ActionResult Properties(Guid ID)
        {
            string path = Server.MapPath("/wwwroot");
            var json = System.IO.File.ReadAllText(path + "/ilan.txt");
            var result = JsonConvert.DeserializeObject<List<Ilan>>(json);
            Ilan Ilan = result.FirstOrDefault(x => x.ID == ID);
            ViewBag.Title = $"{Ilan.Baslik} at fikirtepekentselemlak.com - {Ilan.ID}";
            List<Ilan> Ilanlarlar = result.Where(x => x.EmlakTipi == Ilan.EmlakTipi && x.ID != Ilan.ID).Take(6).ToList();

            if (Ilanlarlar.Count <= 0)
                ViewBag.Ilanlar = result.Take(6).ToList();
            else
                ViewBag.Ilanlar = Ilanlarlar;

            return View(Ilan);
        }
    }
}
