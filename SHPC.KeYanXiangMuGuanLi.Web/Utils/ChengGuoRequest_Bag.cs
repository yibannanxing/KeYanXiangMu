using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHPC.KeYanXiangMuGuanLi.Web.Utils
{
    public class ChengGuoRequest_Bag
    {
        public XiangMuChengGuo  xiangMuChengGuo { get; set; }
      
        public List<FuJian> fengmianList { get; set; }
        public List<FuJian> fileList { get; set; }
        public List<FuJian> articleList { get; set; }
        public List<FuJian> wenjianList { get; set; }
    }
}
