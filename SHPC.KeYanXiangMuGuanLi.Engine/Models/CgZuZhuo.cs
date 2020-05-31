using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgZuZhuo
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string ZuZuoMingCheng { get; set; }
        public string Isbn { get; set; }
        public int? LeiBie { get; set; }
        public string ChuBanSe { get; set; }
        public int? ChuBanSeJiBie { get; set; }
        public DateTime? ChuBanShiJian { get; set; }
        public string FengMianBenRenShuMingPaiXu { get; set; }
        public string YuanNeiBenRenShuMingPaiXu { get; set; }
        public int? IsBiaoZhuXueYuan { get; set; }
        public string QuanShuZiShu { get; set; }
        public string GongGaoZhangJie { get; set; }
        public string GongGaoZiShu { get; set; }
        public int? ZuZhuoHuoJiangJiBie { get; set; }
        public DateTime? ZuZhuoHuoJiangShiJian { get; set; }
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
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
