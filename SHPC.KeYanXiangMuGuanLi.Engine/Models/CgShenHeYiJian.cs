using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgShenHeYiJian
    {
        public Guid Id { get; set; }
        public Guid ShenHeId { get; set; }
        public string ShenHeYiJian { get; set; }
        public int? Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
