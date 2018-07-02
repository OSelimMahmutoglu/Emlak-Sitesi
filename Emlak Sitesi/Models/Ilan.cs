using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Emlak_Sitesi.Models
{
    public class Ilan
    {
        public Guid ID { get; set; }
        public string Baslik { get; set; }
        public string AdresAciklama { get; set; }
        public string Fiyat { get; set; }
        public string MetrekareFiyati { get; set; }
        public double BuyuklukM { get; set; }
        public string IlansAciklama { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string MetaAbstract { get; set; }
        public string MetaDescription { get; set; }
        public string Metakeywords { get; set; }
        public string OdaSayisi { get; set; }
        public bool YayindaMi { get; set; }
        public string Ilce { get; set; }
        public string IlaniVeren { get; set; }
        public string EmlakTipi { get; set; }
        public string SatisTipi { get; set; }
    }
    

}