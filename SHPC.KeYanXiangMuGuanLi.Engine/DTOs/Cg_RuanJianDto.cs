using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class Cg_RuanJianDto :CgRuanJianYuZhuanLi
    {

        public List<CgCanYuZhe> cgCanYuZhes { get; set; }
        public List<CgCanYuZhe> cgzhuanlis { get; set; }
        public List<FuJian> fuJians { get; set; }
        /// <summary>
        /// 发明人
        /// </summary>
        public string famingren { get; set; }
        /// <summary>
        /// 专利权人
        /// </summary>
        public string zhuanliren { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        public string LeiBieName { get; set; }
        /// <summary>
        /// 开发完成日期
        /// </summary>
        public string KaiFaWanChengRiQiName { get; set; }
        /// <summary>
        /// 应用级别
        /// </summary>
        public string YingYongJiBieName { get; set; }
        /// <summary>
        /// 是否联合行业
        /// </summary>
        public string IsLianHeHangYeName { get; set; }
        /// <summary>
        /// 专利申请日
        /// </summary>
        public string ZhuanLiShenQingRiName { get; set; }
        /// <summary>
        /// 授权公告日
        /// </summary>
        public string ShouQuanGongGaoRiName { get; set; }

    }
}
