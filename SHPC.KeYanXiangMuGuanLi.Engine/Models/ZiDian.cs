using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class ZiDian
    {
        public Guid Id { get; set; }
        public string BiaoMingCheng { get; set; }
        public string YiJiMingCheng { get; set; }
        public string ErJiMingCheng { get; set; }
        public int FenZhi { get; set; }
        public int ZhuangTai { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
