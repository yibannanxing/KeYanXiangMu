using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class XiangMu
    {
        public Guid Id { get; set; }
        public string XiangMuMingCheng { get; set; }
        public int XiangMuLeiXing { get; set; }
        public int LiXiangLeiXing { get; set; }
        public Guid ShenQingRenId { get; set; }
        public string ShenQingRenName { get; set; }
        public Guid ShenQingRenBuMenId { get; set; }
        public string ShenQingRenBuMenMingCheng { get; set; }
        public string XingBie { get; set; }
        public string MinZu { get; set; }
        public DateTime ChuShengNianYue { get; set; }
        public string YanJiuZhuanChang { get; set; }
        public string ShouKeKeMu { get; set; }
        public string ShouKeDuiXiang { get; set; }
        public string SuoShuQuDui { get; set; }
        public string XueShengLianXiDianHua { get; set; }
        public string ZhiDaoLaoShi { get; set; }
        public int YanJiuLeiXing { get; set; }
        public string XingZhengZhiWu { get; set; }
        public string JiaoGuanZhiWu { get; set; }
        public string ZhunJiZhiWu { get; set; }
        public string ZuiHouXueLi { get; set; }
        public string LianXiDianHua { get; set; }
        public int KeTiZuChengYuanRenSu { get; set; }
        public int YuQiChengGuoLeiXing { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime? YanQiDate { get; set; }
        public bool? IsYanQi { get; set; }
        public double JingFeiZongE { get; set; }
        public int Status { get; set; }
    }
}
