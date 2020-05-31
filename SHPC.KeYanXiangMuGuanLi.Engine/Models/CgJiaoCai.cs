using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgJiaoCai
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string JiaoCaiMingCheng { get; set; }
        public string Isbn { get; set; }
        public string ChuBanShe { get; set; }
        public int? ChuBanSheJiBie { get; set; }
        public DateTime? ChuBanShiJian { get; set; }
        public int? CanBianQingKuang { get; set; }
        public int? IsBiaoZhuXueYuan { get; set; }
        public string QuanShuZiShu { get; set; }
        public string CanBianZhangJie { get; set; }
        public string CanBianZiShu { get; set; }
        public int? JiaoCaiHuoJiangJiBie { get; set; }
        public DateTime? JiaoCaiHuoJiangShiJian { get; set; }
        public string KeYanKaoHeDeFen { get; set; }
        public int? Status { get; set; }
        public Guid? ZiDianId { get; set; }
        public string ShenHeJiaKouFen { get; set; }
        public string JiaKouFenShuoMing { get; set; }
        public string ShenHeDeFen { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string HuoJiangMingCheng { get; set; }
        public string ShiJiDenFen { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
