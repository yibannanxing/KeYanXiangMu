using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgRuanJianYuZhuanLi
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string MingCheng { get; set; }
        public int? LeiXing { get; set; }
        public string BenRenShuMingPaiXu { get; set; }
        public string YuanNeiBenRenShuMingPaiXu { get; set; }
        public string YingYongJiBie { get; set; }
        public int? IsHangYeLianHeZhuanLi { get; set; }
        public string KeYanKaoHeDeFen { get; set; }
        public Guid? ZiDianId { get; set; }
        public int? Status { get; set; }
        public string ShenHeJiaKouFen { get; set; }
        public string JiaKouFenShuoMing { get; set; }
        public string ShenHeDeFen { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string HuoJiangMingCheng { get; set; }
        public string ShiJiDeFen { get; set; }
        public string ZhuanLiHao { get; set; }
        public DateTime? ZhuanLiShenQingRi { get; set; }
        public DateTime? ShouQuanGongGaoRi { get; set; }
        public string ZhengShuHao { get; set; }
        public DateTime? KaiFaWanChengRiQi { get; set; }
        public string QuanLiQuDeFangShi { get; set; }
        public string QuanLiFanWei { get; set; }
        public string DengJiHao { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
