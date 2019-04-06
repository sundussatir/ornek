using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public DateTime KitapBasimTarihi { get; set; }
        public int YazarId { get; set; }
        public int KitapTuruId { get; set; }
        public virtual Yazar Yazari { get; set; }
        public virtual KitapTuru KitabinTuru { get; set; }
    }
}