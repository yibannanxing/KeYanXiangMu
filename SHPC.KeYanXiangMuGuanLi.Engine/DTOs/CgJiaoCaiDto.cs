using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class CgJiaoCaiDto : CgJiaoCai
    {
        public List<FuJian> fuJians { get; set; }

        public string jiaoCaiHuoJiangJiBieName { get; set; }
        /// <summary>
        /// 出版社级别
        /// </summary>
        public string ChuBanSheJiBieName { get; set; }
        /// <summary>
        /// 出版时间
        /// </summary>
        public string ChuBanShiJianName { get; set; }
        /// <summary>
        /// 参编情况
        /// </summary>
        public string CanBianQingKuangName { get; set; }
        /// <summary>
        /// 是否标注上海公安学院
        /// </summary>
        public string IsBiaoZhuXueYuanName { get; set; }
        /// <summary>
        /// 教材获奖时间
        /// </summary>
        public string JiaoCaiHuoJiangShiJianName { get; set; }
    }
}
