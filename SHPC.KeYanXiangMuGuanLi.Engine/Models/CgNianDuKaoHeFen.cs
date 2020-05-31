using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class CgNianDuKaoHeFen
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string UserName { get; set; }
        public Guid? BuMenId { get; set; }
        public string BuMenMingCheng { get; set; }
        public string ZhuanJiZhiWu { get; set; }
        public string JiaoGuanZhiWu { get; set; }
        public string NianDu { get; set; }
        public string KeYanFen { get; set; }
        public string KaoHeFen { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
