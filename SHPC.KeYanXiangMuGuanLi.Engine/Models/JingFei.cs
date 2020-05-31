using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class JingFei
    {
        public Guid Id { get; set; }
        public Guid XiangMuId { get; set; }
        public string MingCheng { get; set; }
        public double? JinE { get; set; }
        public int PaiXu { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
