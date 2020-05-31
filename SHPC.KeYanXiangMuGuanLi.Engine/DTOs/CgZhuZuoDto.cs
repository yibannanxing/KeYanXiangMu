using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class CgZhuZuoDto: CgZuZhuo
    {
        public List<CgCanYuZhe> cgCanYuZhes { get; set; }
        public List<FuJian> fuJians { get; set; }
        /// <summary>
        /// 组员
        /// </summary>
        public string zuyuans { get; set; }
        /// <summary>
        /// 获奖级别
        /// </summary>
        public string ZuZhuoHuoJiangJiBieName { get; set; }
        /// <summary>
        ///著作类别
        /// </summary>
        public string ZhuZuoLeiBieName { get; set; }
        /// <summary>
        /// 出版社级别
        /// </summary>
        public string ChuBanSheJiBieName { get; set; }
        /// <summary>
        /// 出版时间
        /// </summary>
        public string ChuBanShiJianName { get; set; }
        /// <summary>
        /// 是否标注学院
        /// </summary>
        public string IsBiaoZhuXueYuanName { get; set; }
        /// <summary>
        /// 著作获奖时间
        /// </summary>
        public string ZhuZhuoHuoJiangShiJianName { get; set; }

    }
}
