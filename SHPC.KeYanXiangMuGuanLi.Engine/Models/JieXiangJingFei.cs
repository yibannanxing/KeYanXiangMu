using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class JieXiangJingFei
    {
        public Guid Id { get; set; }
        public Guid? LiXiangId { get; set; }
        public Guid? JieXiangId { get; set; }
        public string JingFeiMingCheng { get; set; }
        public double? JinE { get; set; }
        public string KaiZhiShuoMing { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
