using System;
using System.Collections.Generic;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Services
{
    public class MeiJuUtils
    {
        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static string TryConvertEnumToStr(Type type, object objVal)
        {
            string value = string.Empty;
            value = Enum.GetName(type, objVal);
            return value;
        }
        /// <summary>
        /// 项目状态
        /// </summary>
        public enum XiangMuZhuangTaiName
        {
            暂存,
            提交,
            未审批,
            通过,
            未通过,
            延期,
            归档,
            已删除,
            进行中,
            未完成,
            已结束,
        }
        /// <summary>
        /// 项目类型
        /// </summary>
        public enum XiangMuLeiXingName
        {
            重点项目,
            一般项目
        }
        /// <summary>
        /// 立项类型
        /// </summary>
        public enum LiXiangLeiXingName
        {
            学生,
            一般,
            专项,
            校外
        }
        /// <summary>
        /// 附件类型
        /// </summary>
        public enum FuJianLeiXingName
        {
            文章,
            项目,
            专利,
            科研成果
        }
        /// <summary>
        /// 研究类型
        /// </summary>
        public enum YanJiuLeiXingName
        {
            基础研究 = 0,
            应用研究 = 1,
            综合研究 = 2,
            其他 = 3
        }
        /// <summary>
        /// 预期成果类型
        /// </summary>
        public enum YuQiChengGuoLeiXingName
        {
            著作 = 0,
            论文 = 1,
            研究报告 = 2,
            软件 = 3,
            技术产品 = 4,
            期刊 = 5,
            专利 = 6,
            其他 = 7
        }
        /// <summary>
        /// 成果类型
        /// </summary>
        public enum ChengGuoLeiXingName
        {
            //著作 = 0,
            //论文 = 1,
            //研究报告 = 2,
            //软件 = 3,
            //技术产品 = 4,
            //期刊 = 5,
            //专利 = 6,
            //其他 = 7
            科研项目 = 0,
            著作 = 1,
            论文 = 2,
            教材 = 3,
            软件 = 4,
            专利 = 5,
            奖项 = 6,
            其他 = 7,
        }
        public enum chengGuoFuJianLeiXing
        {
            期刊封面,
            期刊目录,
            文章页面,
            文件附件,
            版权页面,
            证书,
            报纸,
        }

        public enum HuoJiangLeiXing
        {
            国家级一等奖,
            国家级二等奖,
            国家级三等奖,
            国家级优秀奖,
            省部级一等奖,
            省部级二等奖,
            省部级三等奖,
            省部级优秀奖,
            局级一等奖,
            局级二等奖,
            局级三等奖,
            局级优秀奖,
            院级一等奖,
            院级二等奖,
            院级三等奖,
            院级优秀奖,
            未获奖,
        }

        public enum ZhuanJiZhiWu
        {
            教授,
            副教授,
            讲师,
            助教,
            研究员,
            副研究员,
            助理研究员,
            研究实习员,
            其他正高,
            其他副高,
            其他中级,
            其他初级,
            无
        }

        public enum JiaoGuanZhiWu
        {
            特级教官,
            高级教官,
            中级教官,
            初级教官,
            无
        }

        public enum xiangMuLeiBieName
        {
            重点项目,
            一般项目,
            青年项目,
            学生项目
        }

        public enum LunWenLeiBie
        {
            科研,
            教学
        }

        public enum LunWenZaiTi
        {
            期刊,
            报纸,
            论文集,
        }

        public enum ShiFou
        {
            是,
            否
        }
        /// <summary>
        /// 出版社级别
        /// </summary>
        public enum ChuBanShe
        {
            国家级,
            省部级
        }
        /// <summary>
        /// 著作级别
        /// </summary>
        public enum ZhuZhuo
        {
            专著,
            编著,
            译著,
            译
        }
        /// <summary>
        /// 参编情况
        /// </summary>
        public enum CanBianQingKuang
        {
            主编,
            副主编,
            供稿人
        }
        /// <summary>
        /// 软件与专利类别
        /// </summary>
        public enum RuanJianLeiBie
        {
            发明专利,
            实用新型专利,
            外观设计专利,
            软件著作权
        }
        /// <summary>
        /// 应用级别
        /// </summary>
        public enum YingYongJieBie
        {
            国家应用,
            省部应用,
            局应用,
            院应用
        }
        /// <summary>
        /// 项目级别
        /// </summary>
        public enum XiangMuJiBie
        {
            国家级,
            省部级,
            局级,
            院级
        }
        /// <summary>
        /// 项目状态
        /// </summary>
        public enum XiangMuZhuangTai
        {
            立项,
            已结项,
            已结项未按时上交材料,
            已结项退回修改,
            撤项,
            获奖
        }
        public enum XiangMuCaiNaJiBie
        {
            国家采纳,
            省部采纳,
            局采纳,
            本院采纳,
            未采纳
        }

    }
}
