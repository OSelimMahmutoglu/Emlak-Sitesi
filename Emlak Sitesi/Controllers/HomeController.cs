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
                Fiyat = 1213,
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
            return View(result);
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
    }
}