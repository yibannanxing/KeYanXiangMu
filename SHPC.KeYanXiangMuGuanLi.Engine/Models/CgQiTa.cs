using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgQiTa
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public string MingCheng { get; set; }
        public string ChengGuoNianDu { get; set; }
        public string KeYanChengGuoJianJie { get; set; }
        public string KeYanKaoHeDeFen { get; set; }
        public string ShenHeJiaKouFen { get; set; }
        public string JiaKouFenShuoMing { get; set; }
        public string ShenHeDeFen { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string HuoJiangMingCheng { get; set; }
        public string ShiJiDeFen { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
