using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
   public class XiangMuZuYuanDto: XiangMuZuYuan
    {
        public string XingBieMingCheng { get; set; }
    }
}
