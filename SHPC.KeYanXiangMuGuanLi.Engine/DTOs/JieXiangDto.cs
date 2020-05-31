using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class JieXiangDto : JieXiang
    {
        public List<JieXiangZuYuan> jieXiangZuYuans { get; set; }
        public List<JieXiangJingFei> jieXiangJingFeis { get; set; }
    }


}
