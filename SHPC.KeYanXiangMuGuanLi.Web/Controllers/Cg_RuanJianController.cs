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
using SHPC.KeYanXiangMuGuanLi.Engine.DTOs;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using SHPC.KeYanXiangMuGuanLi.Engine.Services;
using SHPC.KeYanXiangMuGuanLi.Web.Utils;

namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class Cg_RuanJianController : KeYanControllerBase
    {
        public Cg_RuanJianController(
         FAPContext fapContext,
       FAP.Client.Service.OrganizationService organizationService,
       FAP.Client.Service.PrivilegeService privilegeService,
       FAP.Client.Service.MessageService messageService,
       FAP.Client.Service.LoggerService loggerService,
       KeYanGuanLiContext dbContext,
       IHttpContextAccessor httpContext,
       IMemoryCache memoryCache,
       IConfiguration configuration,
       ILogger<Cg_RuanJianController> logger,
       IMapper mapper)
       : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 保存 软件
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgRuanJian(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var ruanjian = entity.CgRuanJianYuZhuanLi;
            var canyuzes = entity.canyuzes;
            var zhuanlis = entity.zhuanlis;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var zhengshu = entity.zhengshulist;
            var jilu = entity.jilu;
            try
            {
                if (ruanjian.Id == Guid.Empty)
                {
                    ruanjian.Id = Guid.NewGuid();
                    ruanjian.UserId = currentUser.Id;
                    ruanjian.UserName = currentUser.Name;
                    ruanjian.Status = status;
                    ruanjian.CreateDate = ruanjian.LastUpdateDate = DateTime.Now;
                    ruanjian.YuanNeiBenRenShuMingPaiXu = ruanjian.BenRenShuMingPaiXu;
                    ruanjian.BuMenId = OrgHelper.GetBuMenId(currentUser);
                    ruanjian.BuMenMingCheng = OrgHelper.GetBuMenMingCheng(currentUser);
                    _dbContext.CgRuanJianYuZhuanLi.Add(ruanjian);
                    //作者
                    if (canyuzes != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = ruanjian.Id;
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
                    if (zhuanlis != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = ruanjian.Id;
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
                            cgCanYuZhe.Status = 1;
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
                            fm[i].ChengGuoId = ruanjian.Id;
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
                            file[i].ChengGuoId = ruanjian.Id;
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
                            article[i].ChengGuoId = ruanjian.Id;
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
                            wenjian[i].ChengGuoId = ruanjian.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }
                    if (zhengshu != null)
                    {
                        for (int i = 0; i < zhengshu.Count; i++)
                        {
                            zhengshu[i].Id = Guid.NewGuid();
                            zhengshu[i].ChengGuoId = ruanjian.Id;
                            zhengshu[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.证书;
                            zhengshu[i].CreateDateTime = zhengshu[i].LastUpdateTime = DateTime.Now;
                            zhengshu[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(zhengshu[i]);
                        }
                    }

                }
                else
                {
                    var query_ruanjian = _dbContext.CgRuanJianYuZhuanLi.SingleOrDefault(x => x.Id == ruanjian.Id);
                    query_ruanjian.MingCheng = ruanjian.MingCheng;
                    query_ruanjian.LeiXing = ruanjian.LeiXing;
                    query_ruanjian.BenRenShuMingPaiXu = ruanjian.BenRenShuMingPaiXu;
                    query_ruanjian.YuanNeiBenRenShuMingPaiXu = ruanjian.YuanNeiBenRenShuMingPaiXu;
                    query_ruanjian.IsHangYeLianHeZhuanLi = ruanjian.IsHangYeLianHeZhuanLi;
                    query_ruanjian.KeYanKaoHeDeFen = ruanjian.KeYanKaoHeDeFen;
                    query_ruanjian.LastUpdateDate = DateTime.Now;
                    query_ruanjian.HuoJiangMingCheng = ruanjian.HuoJiangMingCheng;
                    query_ruanjian.ShiJiDeFen = ruanjian.ShiJiDeFen;
                    query_ruanjian.ZhuanLiHao = ruanjian.ZhuanLiHao;
                    query_ruanjian.ZhuanLiShenQingRi = ruanjian.ZhuanLiShenQingRi;
                    query_ruanjian.ShouQuanGongGaoRi = ruanjian.ShouQuanGongGaoRi;
                    query_ruanjian.DengJiHao = ruanjian.DengJiHao;
                    query_ruanjian.KaiFaWanChengRiQi = ruanjian.KaiFaWanChengRiQi;
                    query_ruanjian.QuanLiQuDeFangShi = ruanjian.QuanLiQuDeFangShi;
                    query_ruanjian.QuanLiFanWei = ruanjian.QuanLiFanWei;
                    query_ruanjian.Status = status;
                    query_ruanjian.SuoShuNianDu = ruanjian.SuoShuNianDu;


                    var query_cyz = _dbContext.CgCanYuZhe.Where(x => x.CgId == ruanjian.Id);
                    _dbContext.CgCanYuZhe.RemoveRange(query_cyz);
                    if (canyuzes != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = ruanjian.Id;
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
                    if (zhuanlis != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = ruanjian.Id;
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
                            cgCanYuZhe.Status = 1;
                            cgCanYuZhe.CreateDate = cgCanYuZhe.LastUpdateDate = DateTime.Now;
                            _dbContext.CgCanYuZhe.Add(cgCanYuZhe);
                        }
                    }

                    //附件
                    var query_fj = _dbContext.FuJian.Where(x => x.ChengGuoId == ruanjian.Id);
                    _dbContext.FuJian.RemoveRange(query_fj);

                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = ruanjian.Id;
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
                            file[i].ChengGuoId = ruanjian.Id;
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
                            article[i].ChengGuoId = ruanjian.Id;
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
                            wenjian[i].ChengGuoId = ruanjian.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }
                    if (zhengshu != null)
                    {
                        for (int i = 0; i < zhengshu.Count; i++)
                        {
                            zhengshu[i].Id = Guid.NewGuid();
                            zhengshu[i].ChengGuoId = ruanjian.Id;
                            zhengshu[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.证书;
                            zhengshu[i].CreateDateTime = zhengshu[i].LastUpdateTime = DateTime.Now;
                            zhengshu[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }

                }
                var result = _dbContext.SaveChanges() > 0;
                if (result)
                {
                    SaveCgjl(ruanjian, jilu, canyuzes, status);
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
        public SingleResult<bool> SaveCgjl(CgRuanJianYuZhuanLi entity, JiLu jiLu, List<canyuze> canyuzes, int status)
        {
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
                    //query_jilu.UserId = currentUser.Id;
                    query_jilu.CgLeiXingMingCheng = "软件与专利";
                    query_jilu.LastUpdateDate = DateTime.Now;
                    query_jilu.CgMingCheng = entity.MingCheng;
                    //query_jilu.ShenHeFen = entity.ShenHeDeFen;
                    query_jilu.ShuMingPaiXu = entity.BenRenShuMingPaiXu;
                    query_jilu.XiangMuZuChengYuan = str;
                    query_jilu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    query_jilu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;

                }
                else
                {
                    CgJiLu cgJiLu = new CgJiLu();
                    cgJiLu.Id = Guid.NewGuid();
                    cgJiLu.CgId = entity.Id;
                    cgJiLu.UserId = currentUser.Id;
                    cgJiLu.CgLeiXingMingCheng = "软件与专利";
                    cgJiLu.Status = status;
                    cgJiLu.CreateDate = cgJiLu.LastUpdateDate = DateTime.Now;
                    cgJiLu.UserName = currentUser.Name;
                    cgJiLu.BumenId = OrgHelper.GetBuMenId(currentUser);
                    cgJiLu.Bumen = OrgHelper.GetBuMenMingCheng(currentUser);
                    cgJiLu.StartDate = entity.ZhuanLiShenQingRi;
                    cgJiLu.CgMingCheng = entity.MingCheng;
                    //cgJiLu.ShenHeFen = entity.ShenHeDeFen;
                    cgJiLu.ShuMingPaiXu = entity.BenRenShuMingPaiXu;
                    cgJiLu.XiangMuZuChengYuan = str;
                    cgJiLu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    cgJiLu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;
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
        /// 获取 著作详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<Cg_RuanJianDto> GetCgRuanJianById(Guid id)
        {
            SingleResult<Cg_RuanJianDto> singleResult = new SingleResult<Cg_RuanJianDto>();
            try
            {
                if (_dbContext.CgRuanJianYuZhuanLi.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgRuanJianYuZhuanLi.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = _mapper.Map<Cg_RuanJianDto>(query);
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
        /// 查询软件 不带分页
        /// </summary>
        /// <param name="lx"></param>
        /// <returns></returns>
        public ListResult<Cg_RuanJianDto> GetRuanJianS(int lx)
        {
            ListResult<Cg_RuanJianDto> listResult = new ListResult<Cg_RuanJianDto>();
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "软件与专利" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgRuanJianYuZhuanLi.Where(x =>query_ids.Contains(x.Id));

                if (lx == 0)
                {
                    // query = query.Where(x => x.LeiXing == 3).GroupBy(x => x.MingCheng.Trim()).Select(x => x.First());
                    query = query.Where(x => x.LeiXing == 3);
                }
                else
                {
                    //query = query.Where(x => x.LeiXing != 3).GroupBy(x => x.MingCheng.Trim()).Select(x => x.First());
                    query = query.Where(x => x.LeiXing != 3);
                }
                listResult.Results = _mapper.Map<List<Cg_RuanJianDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }
        /// <summary>
        /// 查询软件 带分页
        /// </summary>
        /// <param name="lx"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<Cg_RuanJianDto> GetRuanJianSByFenYe(int lx, int skip, int take)
        {
            ListResult<Cg_RuanJianDto> listResult = new ListResult<Cg_RuanJianDto>();
            try
            {
                // var query = _dbContext.CgRuanJianYuZhuanLi.Where(x => x.Status == 1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "软件与专利" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgRuanJianYuZhuanLi.Where(x => query_ids.Contains(x.Id));

                if (lx == 0)
                {
                    query = query.Where(x => x.LeiXing == 3);
                }
                else
                {
                    query = query.Where(x => x.LeiXing != 3);
                }
                listResult.Results = _mapper.Map<List<Cg_RuanJianDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 筛选软件
        /// </summary>
        /// <param name="lx"></param>
        /// <param name="applyName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isHuoJiang"></param>
        /// <param name="cgName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<Cg_RuanJianDto> GetRuanJianByBase(int lx, string applyName, string startTime, string endTime, string isHuoJiang,string cgName,int skip,int take)
        {
            ListResult<Cg_RuanJianDto> listResult = new ListResult<Cg_RuanJianDto>();
            try
            {
                // var query = _dbContext.CgRuanJianYuZhuanLi.Where(x => x.Status != -1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "软件与专利" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgRuanJianYuZhuanLi.Where(x => query_ids.Contains(x.Id));
                if (lx == 0)
                {
                    query = query.Where(x => x.LeiXing == 3);
                    if (!string.IsNullOrEmpty(applyName))
                    {
                        query = query.Where(x => x.UserName.Contains(applyName));
                    }
                    else if (string.IsNullOrEmpty(cgName))
                    {
                        query = query.Where(x=>x.MingCheng.Contains(cgName));
                    }
                    else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                    {
                        query = query.Where(x => x.KaiFaWanChengRiQi >= Convert.ToDateTime(startTime));
                    }
                    else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                    {
                        query = query.Where(x => x.KaiFaWanChengRiQi <= Convert.ToDateTime(endTime));
                    }
                    else if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                    {
                        query = query.Where(x => x.KaiFaWanChengRiQi <= Convert.ToDateTime(endTime) && x.KaiFaWanChengRiQi >= Convert.ToDateTime(startTime));
                    }
                }
                else
                {
                    query = query.Where(x => x.LeiXing != 3);
                    if (!string.IsNullOrEmpty(applyName))
                    {
                        query = query.Where(x => x.UserName.Contains(applyName));
                    }
                    else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                    {
                        query = query.Where(x =>x.ZhuanLiShenQingRi >= Convert.ToDateTime(startTime));
                    }
                    else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                    {
                        query = query.Where(x => x.ZhuanLiShenQingRi <= Convert.ToDateTime(endTime));
                    }
                    else if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                    {
                        query = query.Where(x => x.ZhuanLiShenQingRi <= Convert.ToDateTime(endTime) && x.ZhuanLiShenQingRi >= Convert.ToDateTime(startTime));
                    }
                }
                listResult.Results = _mapper.Map<List<Cg_RuanJianDto>>(query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
                listResult.TotalRows = query.Count();
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