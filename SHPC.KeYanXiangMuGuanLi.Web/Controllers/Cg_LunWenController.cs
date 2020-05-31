using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FAP.Client;
using FAP.Model;
using FAP.SHPC.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SHPC.KeYanXiangMuGuanLi.Engine.DTOs;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using SHPC.KeYanXiangMuGuanLi.Engine.Services;
using SHPC.KeYanXiangMuGuanLi.Web.Utils;

namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class Cg_LunWenController : KeYanControllerBase
    {
        public Cg_LunWenController(
        FAPContext fapContext,
      FAP.Client.Service.OrganizationService organizationService,
      FAP.Client.Service.PrivilegeService privilegeService,
      FAP.Client.Service.MessageService messageService,
      FAP.Client.Service.LoggerService loggerService,
      KeYanGuanLiContext dbContext,
      IHttpContextAccessor httpContext,
      IMemoryCache memoryCache,
      IConfiguration configuration,
      ILogger<Cg_LunWenController> logger,
      IMapper mapper)
      : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }

        /// <summary>
        /// 保存 论文
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgLunWen(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var lunwen = entity.cgLunWen;
            var canyuzes = entity.canyuzes;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var banquan = entity.banquanlist;
            var zhengshu = entity.zhengshulist;
            var baozhi = entity.baozhilist;
            var jilu = entity.jilu;
            try
            {
                if (lunwen.Id == Guid.Empty)
                {
                    lunwen.Id = Guid.NewGuid();
                    lunwen.UserId = currentUser.Id;
                    lunwen.UserName = currentUser.Name;
                    lunwen.Status = status;
                    lunwen.CreateDate = lunwen.LastUpdateDate = DateTime.Now;
                    lunwen.YuanNeiBenRenShuMingPaiXu = lunwen.BenRenShuMingPaiXu;
                    lunwen.BuMenId = OrgHelper.GetBuMenId(currentUser);
                    lunwen.BuMenMingCheng = OrgHelper.GetBuMenMingCheng(currentUser);
                    _dbContext.CgLunWen.Add(lunwen);
                    //作者
                    if (canyuzes != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = lunwen.Id;
                            cgCanYuZhe.Name = canyuzes[i].name;
                            if (canyuzes[i].isbenyuan == "是")
                            {
                                cgCanYuZhe.IsBenYuan = 0;
                            }
                            else
                            {
                                cgCanYuZhe.IsBenYuan = 1;
                            }
                            cgCanYuZhe.PaiXu = i;
                            cgCanYuZhe.IsTongXunZuoZe = 1;
                            cgCanYuZhe.Status = 0;
                            cgCanYuZhe.CreateDate = cgCanYuZhe.LastUpdateDate = DateTime.Now;
                            _dbContext.CgCanYuZhe.Add(cgCanYuZhe);
                        }
                    }

                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = lunwen.Id;
                            fm[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊封面;
                            fm[i].CreateDateTime = fm[i].LastUpdateTime = DateTime.Now;
                            fm[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(fm[i]);
                        }
                    }
                    if (file != null)
                    {
                        for (int i = 0; i < file.Count; i++)
                        {
                            file[i].Id = Guid.NewGuid();
                            file[i].ChengGuoId = lunwen.Id;
                            file[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊目录;
                            file[i].CreateDateTime = file[i].LastUpdateTime = DateTime.Now;
                            file[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(file[i]);
                        }
                    }
                    if (article != null)
                    {
                        for (int i = 0; i < article.Count; i++)
                        {
                            article[i].Id = Guid.NewGuid();
                            article[i].ChengGuoId = lunwen.Id;
                            article[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文章页面;
                            article[i].CreateDateTime = article[i].LastUpdateTime = DateTime.Now;
                            article[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(article[i]);
                        }

                    }
                    if (wenjian != null)
                    {
                        for (int i = 0; i < wenjian.Count; i++)
                        {
                            wenjian[i].Id = Guid.NewGuid();
                            wenjian[i].ChengGuoId = lunwen.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }
                    if (banquan != null)
                    {
                        for (int i = 0; i < banquan.Count; i++)
                        {
                            banquan[i].Id = Guid.NewGuid();
                            banquan[i].ChengGuoId = lunwen.Id;
                            banquan[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.版权页面;
                            banquan[i].CreateDateTime = banquan[i].LastUpdateTime = DateTime.Now;
                            banquan[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(banquan[i]);
                        }
                    }
                    if (zhengshu != null)
                    {
                        for (int i = 0; i < zhengshu.Count; i++)
                        {
                            zhengshu[i].Id = Guid.NewGuid();
                            zhengshu[i].ChengGuoId = lunwen.Id;
                            zhengshu[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.证书;
                            zhengshu[i].CreateDateTime = zhengshu[i].LastUpdateTime = DateTime.Now;
                            zhengshu[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(zhengshu[i]);
                        }
                    }
                    if (baozhi != null)
                    {
                        for (int i = 0; i < baozhi.Count; i++)
                        {
                            baozhi[i].Id = Guid.NewGuid();
                            baozhi[i].ChengGuoId = lunwen.Id;
                            baozhi[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.报纸;
                            baozhi[i].CreateDateTime = baozhi[i].LastUpdateTime = DateTime.Now;
                            baozhi[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(baozhi[i]);
                        }
                    }

                }
                else
                {
                    var query_lunwen = _dbContext.CgLunWen.SingleOrDefault(x => x.Id == lunwen.Id);
                    query_lunwen.LunWenMingCheng = lunwen.LunWenMingCheng;
                    query_lunwen.LunWenLeiBie = lunwen.LunWenLeiBie;
                    query_lunwen.FaBiaoQiKan = lunwen.FaBiaoQiKan;
                    query_lunwen.DangNianQiHao = lunwen.DangNianQiHao;
                    query_lunwen.LunWenRenDingJiFenLeiXing = lunwen.LunWenRenDingJiFenLeiXing;
                    query_lunwen.ShouLuQiangKuang = lunwen.ShouLuQiangKuang;
                    query_lunwen.FaBiaoNianDu = lunwen.FaBiaoNianDu;
                    query_lunwen.BenRenShuMingPaiXu = lunwen.BenRenShuMingPaiXu;
                    query_lunwen.YuanNeiBenRenShuMingPaiXu = lunwen.YuanNeiBenRenShuMingPaiXu;
                    query_lunwen.IsBiaoZhuXueYuan = lunwen.IsBiaoZhuXueYuan;
                    query_lunwen.LunWenZiShu = lunwen.LunWenZiShu;
                    query_lunwen.IsYuHangYeLianHeFaBiao = lunwen.IsYuHangYeLianHeFaBiao;
                    query_lunwen.IsYuDiFangLianHeFaBiao = lunwen.IsYuDiFangLianHeFaBiao;
                    query_lunwen.IsYuGuoJiLianHeFaBiao = lunwen.IsYuGuoJiLianHeFaBiao;
                    query_lunwen.IsKuaXueKeLunWen = lunwen.IsKuaXueKeLunWen;
                    query_lunwen.LunWenHuoJiangJiBie = lunwen.LunWenHuoJiangJiBie;
                    query_lunwen.LunWenHuoJiangShiJian = lunwen.LunWenHuoJiangShiJian;
                    query_lunwen.KeYanKaoHeDeFen = lunwen.KeYanKaoHeDeFen;
                    query_lunwen.LastUpdateDate = DateTime.Now;
                    query_lunwen.HuoJiangMingCheng = lunwen.HuoJiangMingCheng;
                    query_lunwen.ShiJiDeFen = lunwen.ShiJiDeFen;
                    query_lunwen.ZaiTiLeiXing = lunwen.ZaiTiLeiXing;
                    query_lunwen.ZaiTiMingCheng = lunwen.ZaiTiMingCheng;
                    query_lunwen.GuoJiBiaoZhunHao = lunwen.GuoJiBiaoZhunHao;
                    query_lunwen.ChuBanSe = lunwen.ChuBanSe;
                    query_lunwen.Status = status;
                    query_lunwen.SuoShuNianDu = lunwen.SuoShuNianDu;

                    //作者
                    var query_cyz = _dbContext.CgCanYuZhe.Where(x => x.CgId == lunwen.Id);
                    _dbContext.CgCanYuZhe.RemoveRange(query_cyz);

                    if (canyuzes != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = lunwen.Id;
                            cgCanYuZhe.Name = canyuzes[i].name;
                            if (canyuzes[i].isbenyuan == "是")
                            {
                                cgCanYuZhe.IsBenYuan = 0;
                            }
                            else
                            {
                                cgCanYuZhe.IsBenYuan = 1;
                            }
                            cgCanYuZhe.PaiXu = i;
                            cgCanYuZhe.IsTongXunZuoZe = 1;
                            cgCanYuZhe.Status = 0;
                            cgCanYuZhe.CreateDate = cgCanYuZhe.LastUpdateDate = DateTime.Now;
                            _dbContext.CgCanYuZhe.Add(cgCanYuZhe);
                        }
                    }


                    //附件
                    var query_fj = _dbContext.FuJian.Where(x => x.ChengGuoId == lunwen.Id);
                    _dbContext.FuJian.RemoveRange(query_fj);

                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = lunwen.Id;
                            fm[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊封面;
                            fm[i].CreateDateTime = fm[i].LastUpdateTime = DateTime.Now;
                            fm[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(fm[i]);
                        }
                    }
                    if (file != null)
                    {
                        for (int i = 0; i < file.Count; i++)
                        {
                            file[i].Id = Guid.NewGuid();
                            file[i].ChengGuoId = lunwen.Id;
                            file[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊目录;
                            file[i].CreateDateTime = file[i].LastUpdateTime = DateTime.Now;
                            file[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(file[i]);
                        }
                    }
                    if (article != null)
                    {
                        for (int i = 0; i < article.Count; i++)
                        {
                            article[i].Id = Guid.NewGuid();
                            article[i].ChengGuoId = lunwen.Id;
                            article[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文章页面;
                            article[i].CreateDateTime = article[i].LastUpdateTime = DateTime.Now;
                            article[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(article[i]);
                        }

                    }
                    if (wenjian != null)
                    {
                        for (int i = 0; i < wenjian.Count; i++)
                        {
                            wenjian[i].Id = Guid.NewGuid();
                            wenjian[i].ChengGuoId = lunwen.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }
                    if (banquan != null)
                    {
                        for (int i = 0; i < banquan.Count; i++)
                        {
                            banquan[i].Id = Guid.NewGuid();
                            banquan[i].ChengGuoId = lunwen.Id;
                            banquan[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.版权页面;
                            banquan[i].CreateDateTime = banquan[i].LastUpdateTime = DateTime.Now;
                            banquan[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(banquan[i]);
                        }
                    }
                    if (zhengshu != null)
                    {
                        for (int i = 0; i < zhengshu.Count; i++)
                        {
                            zhengshu[i].Id = Guid.NewGuid();
                            zhengshu[i].ChengGuoId = lunwen.Id;
                            zhengshu[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.证书;
                            zhengshu[i].CreateDateTime = zhengshu[i].LastUpdateTime = DateTime.Now;
                            zhengshu[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(zhengshu[i]);
                        }
                    }
                    if (baozhi != null)
                    {
                        for (int i = 0; i < baozhi.Count; i++)
                        {
                            baozhi[i].Id = Guid.NewGuid();
                            baozhi[i].ChengGuoId = lunwen.Id;
                            baozhi[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.报纸;
                            baozhi[i].CreateDateTime = baozhi[i].LastUpdateTime = DateTime.Now;
                            baozhi[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(baozhi[i]);
                        }
                    }

                }
                var result = _dbContext.SaveChanges() > 0;
                if (result)
                {
                    SaveCgjl(lunwen, jilu, canyuzes, status);
                }
                singleResult.Result = result;



            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }

        /// <summary>
        /// 保存成功记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="canyuzes"></param>
        /// <param name="jiLu"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgjl(CgLunWen entity, JiLu jiLu, List<canyuze> canyuzes, int status)
        {
            var rendingleixing = "";
            var rendingfanwei = "";
            #region 认定类型
            if (entity.LunWenRenDingJiFenLeiXing == 0)
            {
                rendingleixing = "刊登在《中国社会科学》和《中国科学》刊物上的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 1)
            {
                rendingleixing = "刊登在《人民日报》等国家级报纸上的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 2)
            {
                rendingleixing = "《新华文摘》收录的论文全文、“ＳＣＩ”和“ＥＩ”收录的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 3)
            {
                rendingleixing = "刊登在CSSCI来源期刊上的论文、《中国人民大学报刊复印资料》全文收录的论文、刊登在《解放日报》等省部级报纸上的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 4)
            {
                rendingleixing = "“ISTP”和“ISR”收录的学术论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 5)
            {
                rendingleixing = "刊登在全国中文核心期刊上的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 6)
            {
                rendingleixing = "刊登在公安部主管及公安部部属院校正式出版期刊上的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 7)
            {
                rendingleixing = "刊登在其他正式出版的期刊及公安部内部资料上的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 8)
            {
                rendingleixing = "正式出版的论文集收录的论文，《新华文摘》、《高等学校文科学报文摘》和《中国社会科学文摘》收录的文摘、省部级单位内部编印的论文集收录的论文";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 9)
            {
                rendingleixing = "刊登在市局内部资料上的论文、局级单位内部编印的论文集收录的论文 ";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 10)
            {
                rendingleixing = "公安院校内部编印的论文集收录的论文 ";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 11)
            {
                rendingleixing = "其他正式出版的文摘期刊收录的文摘，正式出版的论文集收录的文摘";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 12)
            {
                rendingleixing = "正式出版的各类文摘收录的论文题录";
            }
            else if (entity.LunWenRenDingJiFenLeiXing == 13)
            {
                rendingleixing = "报科研处并经专家评审合格的结合本职工作的论文或报告";
            }
            #endregion

            #region 认定范围
            if (entity.ShouLuQiangKuang == "0")
            {
                rendingfanwei = "SCI（科学引文索引）";
            }
            else if (entity.ShouLuQiangKuang == "1")
            {
                rendingfanwei = "SSCI（社会科学引文索引）";
            }
            else if (entity.ShouLuQiangKuang == "2")
            {
                rendingfanwei = "EI（工程索引）";
            }
            else if (entity.ShouLuQiangKuang == "3")
            {
                rendingfanwei = "CPCI（国际会议录索引）";
            }
            else if (entity.ShouLuQiangKuang == "4")
            {
                rendingfanwei = "A & HCI（艺术与人文科学索引）";
            }
            else if (entity.ShouLuQiangKuang == "5")
            {
                rendingfanwei = "CSCD（中国科技期刊引证报告）";
            }
            else if (entity.ShouLuQiangKuang == "6")
            {
                rendingfanwei = "CSSCI（中文社会科学引文索引）";
            }
            else if (entity.ShouLuQiangKuang == "7")
            {
                rendingfanwei = "北大中文核心期刊";
            }
            else if (entity.ShouLuQiangKuang == "8")
            {
                rendingfanwei = "其他期刊";
            }
            #endregion

            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var str = "";
            try
            {
                if (canyuzes != null)
                {
                    canyuzes.ForEach(x =>
                    {
                        str = str + x.name + ',';
                    });
                }
                if (_dbContext.CgJiLu.Any(x => x.CgId == entity.Id))
                {
                    //判断是否是退回修改
                    var query_jilu = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == entity.Id);
                    if (query_jilu.Status == -2 && query_jilu.IsKeYanChuShenHe == 1)
                    {
                        query_jilu.Status = 3;
                    }
                    else if (currentUser.Name != query_jilu.UserName)
                    {
                        query_jilu.Status = query_jilu.Status;
                    }
                    else if (query_jilu.Status == 0)
                    {
                        query_jilu.Status = status;
                    }
                    else if (query_jilu.Status == 4)
                    {
                        query_jilu.Status = query_jilu.Status;
                    }
                    else
                    {
                        query_jilu.Status = 1;
                    }
                    // query_jilu.UserId = currentUser.Id;
                    query_jilu.CgLeiXingMingCheng = "论文";

                    query_jilu.LastUpdateDate = DateTime.Now;
                    query_jilu.StartDate = entity.FaBiaoNianDu;
                    query_jilu.HuoJiangLeiXing = entity.LunWenHuoJiangJiBie;
                    query_jilu.CgMingCheng = entity.LunWenMingCheng;
                    // query_jilu.ShenHeFen = entity.ShenHeDeFen;
                    query_jilu.ShuMingPaiXu = entity.BenRenShuMingPaiXu;
                    query_jilu.XiangMuZuChengYuan = str;
                    query_jilu.RenDingLeiXing = rendingleixing;
                    query_jilu.RenDingFanWei = rendingfanwei;
                    query_jilu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    query_jilu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;

                }
                else
                {
                    CgJiLu cgJiLu = new CgJiLu();
                    cgJiLu.Id = Guid.NewGuid();
                    cgJiLu.CgId = entity.Id;
                    cgJiLu.UserId = currentUser.Id;
                    cgJiLu.CgLeiXingMingCheng = "论文";
                    cgJiLu.Status = status;
                    cgJiLu.CreateDate = cgJiLu.LastUpdateDate = DateTime.Now;
                    cgJiLu.UserName = currentUser.Name;
                    cgJiLu.BumenId = OrgHelper.GetBuMenId(currentUser);
                    cgJiLu.Bumen = OrgHelper.GetBuMenMingCheng(currentUser);
                    cgJiLu.StartDate = entity.FaBiaoNianDu;
                    // cgJiLu.EndDate = entity.JiHuaWanChengShiJian;
                    cgJiLu.HuoJiangLeiXing = entity.LunWenHuoJiangJiBie;
                    cgJiLu.CgMingCheng = entity.LunWenMingCheng;
                    //cgJiLu.ShenHeFen = entity.ShenHeDeFen;
                    cgJiLu.ShuMingPaiXu = entity.BenRenShuMingPaiXu;
                    cgJiLu.XiangMuZuChengYuan = str;
                    cgJiLu.RenDingLeiXing = rendingleixing;
                    cgJiLu.RenDingFanWei = rendingfanwei;
                    cgJiLu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    cgJiLu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;
                    //cgJiLu.RenDingLeiXing = entity.LunWenRenDingJiFenLeiXing;

                    _dbContext.CgJiLu.Add(cgJiLu);
                }
                singleResult.Result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }

        /// <summary>
        /// 获取 论文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<Cg_LunWenDto> GetCgLunWenById(Guid id)
        {
            SingleResult<Cg_LunWenDto> singleResult = new SingleResult<Cg_LunWenDto>();
            try
            {
                if (_dbContext.CgLunWen.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgLunWen.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = _mapper.Map<Cg_LunWenDto>(query);
                }
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;

        }
        /// <summary>
        /// 消除 审核意见
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SingleResult<bool> DelShenHe(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgShenHe.Any(x => x.CgId == id))
                {
                    var delrange = _dbContext.CgShenHe.Where(x => x.CgId == id);
                    _dbContext.CgShenHe.RemoveRange(delrange);
                }
                singleResult.Result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 论文统计 不带分页
        /// </summary>
        /// <returns></returns>
        public ListResult<Cg_LunWenDto> GetLunWenS()
        {
            ListResult<Cg_LunWenDto> listResult = new ListResult<Cg_LunWenDto>();
            try
            {
                //var query = _dbContext.CgLunWen.GroupBy(x => x.LunWenMingCheng.Trim()).Select(x => x.First());
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "论文" && x.Status != -1).Select(x=>x.CgId);
                var query = _dbContext.CgLunWen.Where(x =>query_ids.Contains(x.Id));

                listResult.Results = _mapper.Map<List<Cg_LunWenDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }
        /// <summary>
        /// 论文统计 不带分页
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<Cg_LunWenDto> GetLunWenSByFenYe(int skip, int take)
        {
            ListResult<Cg_LunWenDto> listResult = new ListResult<Cg_LunWenDto>();
            try
            {
                //var query = _dbContext.CgLunWen.GroupBy(x => x.LunWenMingCheng.Trim()).Select(x => x.First());
                // var query = _dbContext.CgLunWen.Where(x => x.Status == 1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "论文" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgLunWen.Where(x => query_ids.Contains(x.Id));

                listResult.Results = _mapper.Map<List<Cg_LunWenDto>>(query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
                listResult.TotalRows = query.Count();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }
        /// <summary>
        /// 论文筛选
        /// </summary>
        /// <param name="applyName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isHuoJiang"></param>
        /// <param name="cgName"></param>
        /// <param name="isChuBan"></param>
        /// <param name="renDingFanWei"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<Cg_LunWenDto> GetLunWenByBase(string applyName, string startTime, string endTime, string isHuoJiang, string cgName, string isChuBan, string renDingFanWei,int skip,int take)
        {
            ListResult<Cg_LunWenDto> listResult = new ListResult<Cg_LunWenDto>();
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "论文" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgLunWen.Where(x => query_ids.Contains(x.Id));
                //var query = _dbContext.CgLunWen.Where(x => x.Status != -1);
                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(cgName))
                {
                    query = query.Where(x => x.LunWenMingCheng.Contains(cgName));
                }
                else if (!string.IsNullOrEmpty(renDingFanWei))
                {
                    query = query.Where(x => x.LunWenRenDingJiFenLeiXing== int.Parse(renDingFanWei));
                }
                else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.FaBiaoNianDu >= Convert.ToDateTime(startTime));
                }
                else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.FaBiaoNianDu <= Convert.ToDateTime(endTime));
                }
                else if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.FaBiaoNianDu <= Convert.ToDateTime(endTime) && x.FaBiaoNianDu >= Convert.ToDateTime(startTime));
                }
                else if (isHuoJiang == "是")
                {
                    query = query.Where(x => x.LunWenHuoJiangJiBie != null);
                }
                else if (isHuoJiang == "否")
                {
                    query = query.Where(x => x.LunWenHuoJiangJiBie == null);
                }
                else if (isChuBan == "是")
                {
                    query = query.Where(x => x.ChuBanSe != null);
                }
                else if (isChuBan == "否")
                {
                    query = query.Where(x => x.ChuBanSe == null);
                }
                listResult.Results = _mapper.Map<List<Cg_LunWenDto>>(query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
                listResult.TotalRows = query.Count();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <returns></returns>
        public SingleResult<bool> updateBuMen()
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var query_ky = _dbContext.CgKeYanXiangMu.Where(x => x.Status == 1);
            var query_lw = _dbContext.CgLunWen.Where(x => x.Status == 1);
            var query_jc = _dbContext.CgJiaoCai.Where(x => x.Status == 1);
            var query_rj = _dbContext.CgRuanJianYuZhuanLi.Where(x => x.Status == 1);
            var query_zz = _dbContext.CgZuZhuo.Where(x => x.Status == 1);
            var query_qt = _dbContext.CgQiTa.Where(x => x.Status == 1);
            try
            {
                foreach (var item in query_ky)
                {
                    var id = _organizationService.GetUser(item.UserId.Value);
                    var bumenid = OrgHelper.GetBuMenId(id);
                    var bumenMingCheng = OrgHelper.GetBuMenMingCheng(id);
                    item.BuMenId = bumenid;
                    item.BuMenMingCheng = bumenMingCheng;
                }
                foreach (var item in query_lw)
                {
                    var id = _organizationService.GetUser(item.UserId.Value);
                    var bumenid = OrgHelper.GetBuMenId(id);
                    var bumenMingCheng = OrgHelper.GetBuMenMingCheng(id);
                    item.BuMenId = bumenid;
                    item.BuMenMingCheng = bumenMingCheng;
                }
                foreach (var item in query_jc)
                {
                    var id = _organizationService.GetUser(item.UserId.Value);
                    var bumenid = OrgHelper.GetBuMenId(id);
                    var bumenMingCheng = OrgHelper.GetBuMenMingCheng(id);
                    item.BuMenId = bumenid;
                    item.BuMenMingCheng = bumenMingCheng;
                }
                foreach (var item in query_rj)
                {
                    var id = _organizationService.GetUser(item.UserId.Value);
                    var bumenid = OrgHelper.GetBuMenId(id);
                    var bumenMingCheng = OrgHelper.GetBuMenMingCheng(id);
                    item.BuMenId = bumenid;
                    item.BuMenMingCheng = bumenMingCheng;
                }
                foreach (var item in query_zz)
                {
                    var id = _organizationService.GetUser(item.UserId.Value);
                    var bumenid = OrgHelper.GetBuMenId(id);
                    var bumenMingCheng = OrgHelper.GetBuMenMingCheng(id);
                    item.BuMenId = bumenid;
                    item.BuMenMingCheng = bumenMingCheng;
                }
                foreach (var item in query_qt)
                {
                    var id = _organizationService.GetUser(item.UserId.Value);
                    var bumenid = OrgHelper.GetBuMenId(id);
                    var bumenMingCheng = OrgHelper.GetBuMenMingCheng(id);
                    item.BuMenId = bumenid;
                    item.BuMenMingCheng = bumenMingCheng;
                }
                singleResult.Result = _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误", ex);
            }
            return singleResult;
        }

        /// <summary>
        /// 论文
        /// </summary>
        public class LunWen
        {
            /// <summary>
            /// 部门名称
            /// </summary>
            public string BuMenMingCheng { get; set; }
            /// <summary>
            /// 成果_论文
            /// </summary>
            public CgLunWen CgLunWen { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ListResult<ZiDian> GetLunWenByRenDingFanWei()
        {
            ListResult<ZiDian> listResult = new ListResult<ZiDian>();
            try
            {
                var query = _dbContext.ZiDian.Where(x => x.YiJiMingCheng == "LunWenRenDingJiFenLeiXing" && x.ZhuangTai == 1);
                listResult.Results = query.OrderBy(x => x.FenZhi).ToList();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }

    }
}