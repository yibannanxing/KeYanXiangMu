using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class XiangMuDto:XiangMu
    {
        public string XiangMuLeiXingName { get; set; }
        public string LiXiangLeiXingName { get; set; }
        public string YanJiuLeiXingName { get; set; }
        public string YuQiChengGuoLeiXingName { get; set; }
        public string XiangMuZhuangTaiName { get; set; }
        public XiangMuFangAn XiangMuFangAn { get; set; }
        public List<JingFei> JingFeis { get; set; }
        public List<XiangMuZuYuan> XiangMuZuYuans { get; set; }
    }
}
