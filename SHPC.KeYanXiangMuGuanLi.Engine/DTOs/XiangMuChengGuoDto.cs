using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using SHPC.KeYanXiangMuGuanLi.Engine.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
   public class XiangMuChengGuoDto: XiangMuChengGuo
    {
        public string ChengGuoLeiXingName { get; set; }
        public List<FuJian> fuJians { get; set; }
    }
}
