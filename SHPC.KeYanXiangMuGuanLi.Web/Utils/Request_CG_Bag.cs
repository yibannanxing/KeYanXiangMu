using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHPC.KeYanXiangMuGuanLi.Web.Utils
{
    public class Request_CG_Bag
    {
        /// <summary>
        /// 科研项目
        /// </summary>
        public CgKeYanXiangMu cgKeYanXiangMu { get; set;}
        /// <summary>
        /// 著作
        /// </summary>
        public CgZuZhuo cgZuZhuo { get; set; }
        /// <summary>
        /// 教材
        /// </summary>
        public CgJiaoCai cgJiaoCai { get; set; }
        /// <summary>
        /// 论文
        /// </summary>
        public CgLunWen cgLunWen { get; set; }
        /// <summary>
        /// 软件与专利
        /// </summary>
        public CgRuanJianYuZhuanLi CgRuanJianYuZhuanLi { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public CgQiTa cgQiTa { get; set; }
        /// <summary>
        /// 审核意见
        /// </summary>
        public CgShenHeYiJian CgShenHeYiJian { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        public CgShenHe CgShenHe { get; set; }
        /// <summary>
        /// 记录
        /// </summary>
        public JiLu jilu { get; set; }
    

        public List<canyuze> canyuzes { get; set; }
        public List<canyuze> zhuanlis { get; set; }
        public List<FuJian> fengmianList { get; set; }
        public List<FuJian> fileList { get; set; }
        public List<FuJian> articleList { get; set; }
        public List<FuJian> wenjianList { get; set; }
        public List<FuJian> banquanlist { get; set; }
        public List<FuJian> zhengshulist { get; set; }
        public List<FuJian> baozhilist { get; set; }
    }
    /// <summary>
    /// 参与者
    /// </summary>
    public class canyuze {
        public string name { get; set; }
        public string isbenyuan { get; set; }
    }
    public class JiLu {
        public int ZhuanJiZhiWu { get; set; }
        public int JiaoGuanZhiWu { get; set; }
    }
}
