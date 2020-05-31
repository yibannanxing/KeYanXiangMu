using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    [NotMapped]
    public class CgKeYanXiangMuDto : CgKeYanXiangMu
    {
        public List<CgCanYuZhe> cgCanYuZhes { get; set; }
        public List<FuJian> fuJians { get; set; }

        /// <summary>
        /// 组员
        /// </summary>
        public string zuyuans { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        public string xiangMuLeiBieName { get; set; }
        /// <summary>
        /// 获奖类型
        /// </summary>
        public string HuoJiangLeiXingName { get; set; }
        /// <summary>
        /// 项目级别
        /// </summary>
        public string XiangMuJieBieName { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public string XiangMuZhuangTaiName { get; set; }
        /// <summary>
        /// 批准立项时间
        /// </summary>
        public String PiZunLiXiangShiJianName { get; set; }
        /// <summary>
        /// 批准结项时间
        /// </summary>
        public String PiZunJieXiangShiJianName { get; set; }
        /// <summary>
        /// 是否由院科主管
        /// </summary>
        public string IsYouYuanKeZhuGuanName {get; set; }
        /// <summary>
        /// 是否为本人指导
        /// </summary>
        public string IsWeiBenRenZhiDaoName { get; set; }
        /// <summary>
        /// 项目获奖时间
        /// </summary>
        public string XiangMuHuoJiangShiJianName { get; set; }
        /// <summary>
        /// 项目采纳级别
        /// </summary>
        public string XiangMuCaiNaJiBieName { get; set; }
        /// <summary>
        /// 项目成果采纳时间
        /// </summary>
        public string XiangMuChengGuoCaiNaShiJianName { get; set; }

}
}
