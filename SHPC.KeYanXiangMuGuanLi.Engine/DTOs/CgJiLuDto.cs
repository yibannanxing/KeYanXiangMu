using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class CgJiLuDto :CgJiLu
    {
        public string HuoJiangLeiXingName { get; set; }
        public CgJiaoCai cgJiaoCai { get; set; }
        public CgKeYanXiangMuDto cgKeYanXiangMuDto { get; set; }
        public CgLunWen cgLunWen { get; set; }
        public CgQiTa cgQiTa { get; set; }
        public CgRuanJianYuZhuanLi cgRuanJianYuZhuan { get; set; }
        public CgZuZhuo cgZuZhuo { get; set; }

        public List<CgShenHe> cgShenHes { get; set;}

    }
}
