using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgCanYuZhe
    {
        public Guid Id { get; set; }
        public Guid CgId { get; set; }
        public string Name { get; set; }
        public int? IsBenYuan { get; set; }
        public int? IsTongXunZuoZe { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public int? PaiXu { get; set; }
    }
}
