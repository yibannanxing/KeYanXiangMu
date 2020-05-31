using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class XiangMuChengGuo
    {
        public Guid Id { get; set; }
        public Guid? XiangMuId { get; set; }
        public Guid? ZuoZeId { get; set; }
        public string ZuoZeMingCheng { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string ChengGuoMingCheng { get; set; }
        public int? ChengGuoLeiXing { get; set; }
        public string NianQi { get; set; }
        public string ChuBanSe { get; set; }
        public int PaiXu { get; set; }
        public int Stadus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
