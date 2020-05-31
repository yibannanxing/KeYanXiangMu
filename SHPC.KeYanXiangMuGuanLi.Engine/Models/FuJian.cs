using System;
using System.Collections.Generic;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class FuJian
    {
        public Guid Id { get; set; }
        public Guid? ChengGuoId { get; set; }
        public int? WenJianLeiXing { get; set; }
        public string WenJianMingCheng { get; set; }
        public string FuWuQiWenJianMingCheng { get; set; }
        public string LuJing { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string PaiXu { get; set; }
        public int? Status { get; set; }
    }
}
