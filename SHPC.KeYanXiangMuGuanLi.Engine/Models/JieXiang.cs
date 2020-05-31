using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class JieXiang
    {
        public Guid Id { get; set; }
        public Guid LiXiangId { get; set; }
        public string FuZeRenMingCheng { get; set; }
        public string BuMenMingCheng { get; set; }
        public string ZhiWuMingCheng { get; set; }
        public string ZuanyYe { get; set; }
        public string DianHua { get; set; }
        public string ZuiZhongChengGuo1 { get; set; }
        public string ZuiZhongChengGuo2 { get; set; }
        public int WanChengZhuangTai { get; set; }
        public double ZuiZhongChengGuoZiShu { get; set; }
        public string FaBiaoChuBan { get; set; }
        public double HeZunJingFei { get; set; }
        public double ShiJiJingFei { get; set; }
        public double JieYu { get; set; }
        public string ZongJie1 { get; set; }
        public string ZongJie2 { get; set; }
        public string ZongJie3 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string XiangMuMingCheng { get; set; }
        public DateTime? JieXiangTime { get; set; }
        public int? JieXiangLeiXing { get; set; }
        public int? XiangMuLeiXing { get; set; }
    }
}
