using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class Cg_LunWenDto : CgLunWen
    {
        public List<CgCanYuZhe> cgCanYuZhes { get; set; }
        public List<FuJian> fuJians { get; set; }

        /// <summary>
        /// 获奖级别
        /// </summary>
        public string lunWenHuoJiangJiBieName { get; set; }
        /// <summary>
        /// 组员
        /// </summary>
        public string zuyuans { get; set; }
        /// <summary>
        /// 论文类别
        /// </summary>
        public string LunWenLeiBieMingCheng { get; set; }
        /// <summary>
        /// 论文载体
        /// </summary>
        public string LunWenZaiTiMingCheng { get; set; }
        /// <summary>
        /// 取字典
        /// </summary>
        public string ShouLuQingKuangMingCheng { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public string FaBiaoShiJianName { get; set; }
        /// <summary>
        /// 是否标注上海公安学院
        /// </summary>
        public string IsBiaoZhuShangHaiGongAnXueYuan { get; set; }
        /// <summary>
        /// 是否与行业联合发表
        /// </summary>
        public string IsYuHangYe { get; set; }
        /// <summary>
        /// 是否与地方
        /// </summary>
        public string IsYuDiFang { get; set; }
        /// <summary>
        /// 是否与境外
        /// </summary>
        public string IsJingWai { get; set; }
        /// <summary>
        /// 是否跨学科
        /// </summary>
        public string IsKuaXueKe { get; set; }
        /// <summary>
        /// 获奖时间
        /// </summary>
        public string LunWenHuoJiangTime { get; set; }
    }
}
