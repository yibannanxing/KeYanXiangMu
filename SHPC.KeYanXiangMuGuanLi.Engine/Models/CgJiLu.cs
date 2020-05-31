using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgJiLu
    {
        public Guid Id { get; set; }
        public Guid? CgId { get; set; }
        public string CgLeiXingMingCheng { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public Guid? BumenId { get; set; }
        public string Bumen { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? HuoJiangLeiXing { get; set; }
        public string CgMingCheng { get; set; }
        public string ShangJiShenHeRen { get; set; }
        public string XiangMuLaiYuan { get; set; }
        public string YuanNeiXiangMuBianHao { get; set; }
        public string ShuMingPaiXu { get; set; }
        public string XiangMuZuChengYuan { get; set; }
        public string RenDingLeiXing { get; set; }
        public string RenDingFanWei { get; set; }
        public int? IsKeYanChuShenHe { get; set; }
        public int? ZhuanJiZhiWu { get; set; }
        public int? JiaoGuanZhiWu { get; set; }
        public string ShenHeFen { get; set; }
        public string SuoShuNianDu { get; set; }
    }
}
