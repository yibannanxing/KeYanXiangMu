using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHPC.KeYanXiangMuGuanLi.Web.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class Xiangmu_Request_Bag
    {
        /// <summary>
        /// 
        /// </summary>
        public XiangMu XiangMu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<JingFei> JingFeis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<XiangMuZuYuan> XiangMuZuYuans { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public XiangMuFangAn XiangMuFangAn { get; set; }
    }
}
