using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class XiangMuFangAn
    {
        public Guid XiangMuId { get; set; }
        public string ZuiZhongChengGuo { get; set; }
        public string XiangMuChengGuo { get; set; }
        public string XiangMuXuanTi { get; set; }
        public string XiangMuFangAn1 { get; set; }
        public string YanJiuJiChu { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
