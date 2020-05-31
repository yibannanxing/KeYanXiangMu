using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgLunWen
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string LunWenMingCheng { get; set; }
        public int? LunWenLeiBie { get; set; }
        public string FaBiaoQiKan { get; set; }
        public string DangNianQiHao { get; set; }
        public int? LunWenRenDingJiFenLeiXing { get; set; }
        public string ShouLuQiangKuang { get; set; }
        public DateTime? FaBiaoNianDu { get; set; }
        public string BenRenShuMingPaiXu { get; set; }
        public string YuanNeiBenRenShuMingPaiXu { get; set; }
        public int? IsBiaoZhuXueYuan { get; set; }
        public string LunWenZiShu { get; set; }
        public int? IsYuHangYeLianHeFaBiao { get; set; }
        public int? IsYuDiFangLianHeFaBiao { get; set; }
        public int? IsYuGuoJiLianHeFaBiao { get; set; }
        public int? IsKuaXueKeLunWen { get; set; }
        public int? LunWenHuoJiangJiBie { get; set; }
        public DateTime? LunWenHuoJiangShiJian { get; set; }
        public string KeYanKaoHeDeFen { get; set; }
        public int? Status { get; set; }
        public Guid? ZiDianId { get; set; }
        public string ShenHeJiaKouFen { get; set; }
        public string JiaKouFenShuoMing { get; set; }
        public string ShenHeDeFen { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string HuoJiangMingCheng { get; set; }
        public string ShiJiDeFen { get; set; }
        public int? ZaiTiLeiXing { get; set; }
        public string ZaiTiMingCheng { get; set; }
        public string GuoJiBiaoZhunHao { get; set; }
        public string ChuBanSe { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
