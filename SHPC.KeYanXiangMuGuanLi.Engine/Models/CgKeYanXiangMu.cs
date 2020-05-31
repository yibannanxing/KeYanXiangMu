using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgKeYanXiangMu
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string PiZunLiXiangBuMen { get; set; }
        public DateTime? LiXiangShiJian { get; set; }
        public DateTime? JiHuaWanChengShiJian { get; set; }
        public DateTime? GongBuJieXiangShiJian { get; set; }
        public int? XiangMuJiBie { get; set; }
        public int? XiangMuLeiBie { get; set; }
        public string XiangMuMingCheng { get; set; }
        public string YuanNeiXiangMuBianHao { get; set; }
        public string YuanWaiXiangMuBianHao { get; set; }
        public string XiangMuZiZuZongE { get; set; }
        public string BenRenShuMingPaiXu { get; set; }
        public string YuanNeiBenRenShuMingPaiXu { get; set; }
        public int? XiangMuZhuangTai { get; set; }
        public int? IsYuanKeYanZuGuanBmgl { get; set; }
        public string IsBenRenZhiDao { get; set; }
        public int? XiangMuHuoJiangJiBie { get; set; }
        public DateTime? XiangMuHuoJiangTime { get; set; }
        public string XiangMuHuoJiangZhengShuId { get; set; }
        public string XiangMuHuoJiangMingCheng { get; set; }
        public int? XiangMuChengGuoCaiNaJiBie { get; set; }
        public DateTime? XiangMuChengGuoCaiNaTime { get; set; }
        public string KeYanKaoHeDeFen { get; set; }
        public string ShiJiDeFen { get; set; }
        public int? Status { get; set; }
        public Guid? ZiDianId { get; set; }
        public string ShenHeJiaKouFen { get; set; }
        public string JiaKouFenShuoMing { get; set; }
        public string ShenHeDeFen { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string XiangMuLaiYuan { get; set; }
        public int? XueShengJieXiangDengJi { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
