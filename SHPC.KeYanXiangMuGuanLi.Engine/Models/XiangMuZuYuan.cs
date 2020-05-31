using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class XiangMuZuYuan
    {
        public Guid Id { get; set; }
        public Guid XiangMuId { get; set; }
        public Guid XiangMuZuChengYuanId { get; set; }
        public string XiangMuZuChengYuanXingMing { get; set; }
        public int XingBie { get; set; }
        public DateTime ChuShengNianYue { get; set; }
        public string ZhiWuMingCheng { get; set; }
        public string YanJiuZhuanChang { get; set; }
        public string XueLi { get; set; }
        public string SuoSuBuMenId { get; set; }
        public string SuoSuBuMenMingCheng { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
