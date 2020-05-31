using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class JieXiangZuYuan
    {
        public Guid Id { get; set; }
        public Guid? LiXiangId { get; set; }
        public Guid? JieXiangId { get; set; }
        public string XingMing { get; set; }
        public string BuMen { get; set; }
        public string ZhiWu { get; set; }
        public string YanJiuZhuanChang { get; set; }
        public string ZuanYe { get; set; }
        public string FenGongQingKuang { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
