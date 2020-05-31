using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgShenHe
    {
        public Guid Id { get; set; }
        public Guid? CgId { get; set; }
        public int? JieDian { get; set; }
        public Guid? ShenPiRenId { get; set; }
        public string ShenPiRenName { get; set; }
        public Guid? ShenPiRenBuMenId { get; set; }
        public string ShenPiRenBuMenMingCheng { get; set; }
        public DateTime? ShenPiShiJian { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string ShenHeYiJian { get; set; }
        public string ShangJiShenHeRen { get; set; }
    }
}
