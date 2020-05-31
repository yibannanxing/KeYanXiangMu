using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHPC.KeYanXiangMuGuanLi.Web.Utils
{

    public class JieXiang_RequestBag
    {
        /// <summary>
        /// 
        /// </summary>
        public JieXiang JieXiang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<JieXiangZuYuan> jiexiangzuyuans { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<jxJingFei>  jxJingFeis { get; set; }

       // public jiexiangjingfei jiexiangjingfei { get; set; }

    }

    public class jiexiangjingfei
    {

        // ziliaofei: null,
        //ziliaokaizhi: null,

        //diaoyanchailvfei: null,
        //diaoyanchailvkaizhi: null,

        //cailiaofei: null,
        //cailiaokaizhi: null,

        //zhizuofei: null,
        //zhizuokaizhi: null,

        //ruanjiankaifafei: null,
        //ruanjiankaifakaizhi: null,

        //zixunfei: null,
        //zixunkaizhi: null,

        //qita: null,
        //qitakaizhi: null,

        public string ziliaofei { get; set; }
        public string ziliaokaizhi { get; set; }
        public string diaoyanchailvfei { get; set; }
        public string diaoyanchailvkaizhi { get; set; }
        public string cailiaofei { get; set; }
        public string cailiaokaizhi { get; set; }
        public string zhizuofei { get; set; }
        public string zhizuokaizhi { get; set; }
        public string ruanjiankaifafei { get; set; }
        public string ruanjiankaifakaizhi { get; set; }
        public string zixunfei { get; set; }
        public string zixunkaizhi { get; set; }
        public string qita { get; set; }
        public string qitakaizhi { get; set; }

    }

    public class jxJingFei {
        public string name { get; set; }
        public string jine { get; set; }
        public string kaizhi { get; set; }
    }
}
