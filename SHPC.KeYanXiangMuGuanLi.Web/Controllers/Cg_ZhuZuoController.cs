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
    public class Cg_ZhuZuoController : KeYanControllerBase
    {
        public Cg_ZhuZuoController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<Cg_ZhuZuoController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgZhuzuo(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var zhuzuo = entity.cgZuZhuo;
            var canyuzes = entity.canyuzes;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var banquan = entity.banquanlist;
            var jilu = entity.jilu;

            try
            {
                if (zhuzuo.Id == Guid.Empty)
                {
                    zhuzuo.Id = Guid.NewGuid();
                    zhuzuo.UserId = currentUser.Id;
                    zhuzuo.UserName = currentUser.Name;
                    zhuzuo.Status = status;
                    zhuzuo.CreateDate = zhuzuo.LastUpdateDate = DateTime.Now;
                    zhuzuo.BuMenId = OrgHelper.GetBuMenId(currentUser);
                    zhuzuo.BuMenMingCheng = OrgHelper.GetBuMenMingCheng(currentUser);
                    _dbContext.CgZuZhuo.Add(zhuzuo);
                    //作者
                    if (canyuzes != null)
                    {

                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = zhuzuo.Id;
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
                            fm[i].ChengGuoId = zhuzuo.Id;
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
                            file[i].ChengGuoId = zhuzuo.Id;
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
                            article[i].ChengGuoId = zhuzuo.Id;
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
                            wenjian[i].ChengGuoId = zhuzuo.Id;
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
                            banquan[i].ChengGuoId = zhuzuo.Id;
                            banquan[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.版权页面;
                            banquan[i].CreateDateTime = banquan[i].LastUpdateTime = DateTime.Now;
                            banquan[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(banquan[i]);
                        }

                    }

                }
                else
                {
                    var query_zuzhuo = _dbContext.CgZuZhuo.SingleOrDefault(x => x.Id == zhuzuo.Id);
                    query_zuzhuo.ZuZuoMingCheng = zhuzuo.ZuZuoMingCheng;
                    query_zuzhuo.Isbn = zhuzuo.Isbn;
                    query_zuzhuo.LeiBie = zhuzuo.LeiBie;
                    query_zuzhuo.ChuBanSe = zhuzuo.ChuBanSe;
                    query_zuzhuo.ChuBanSeJiBie = zhuzuo.ChuBanSeJiBie;
                    query_zuzhuo.ChuBanShiJian = zhuzuo.ChuBanShiJian;
                    query_zuzhuo.FengMianBenRenShuMingPaiXu = zhuzuo.FengMianBenRenShuMingPaiXu;
                    query_zuzhuo.YuanNeiBenRenShuMingPaiXu = zhuzuo.YuanNeiBenRenShuMingPaiXu;
                    query_zuzhuo.IsBiaoZhuXueYuan = zhuzuo.IsBiaoZhuXueYuan;
                    query_zuzhuo.QuanShuZiShu = zhuzuo.QuanShuZiShu;
                    query_zuzhuo.GongGaoZhangJie = zhuzuo.GongGaoZhangJie;
                    query_zuzhuo.GongGaoZiShu = zhuzuo.GongGaoZiShu;
                    query_zuzhuo.ZuZhuoHuoJiangJiBie = zhuzuo.ZuZhuoHuoJiangJiBie;
                    query_zuzhuo.ZuZhuoHuoJiangShiJian = zhuzuo.ZuZhuoHuoJiangShiJian;
                    query_zuzhuo.KeYanKaoHeDeFen = zhuzuo.KeYanKaoHeDeFen;
                    query_zuzhuo.LastUpdateDate = DateTime.Now;
                    query_zuzhuo.HuoJiangMingCheng = zhuzuo.HuoJiangMingCheng;
                    query_zuzhuo.ShiJiDeFen = zhuzuo.ShiJiDeFen;
                    query_zuzhuo.Status = status;
                    query_zuzhuo.SuoShuNianDu = zhuzuo.SuoShuNianDu;

                    //作者
                    var query_cyz = _dbContext.CgCanYuZhe.Where(x => x.CgId == zhuzuo.Id);
                    _dbContext.CgCanYuZhe.RemoveRange(query_cyz);
                    //作者
                    if (canyuzes != null)
                    {

                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = zhuzuo.Id;
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
                    var query_fj = _dbContext.FuJian.Where(x => x.ChengGuoId == zhuzuo.Id);
                    _dbContext.FuJian.RemoveRange(query_fj);
                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = zhuzuo.Id;
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
                            file[i].ChengGuoId = zhuzuo.Id;
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
                            article[i].ChengGuoId = zhuzuo.Id;
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
                            wenjian[i].ChengGuoId = zhuzuo.Id;
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
                            banquan[i].ChengGuoId = zhuzuo.Id;
                            banquan[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.版权页面;
                            banquan[i].CreateDateTime = banquan[i].LastUpdateTime = DateTime.Now;
                            banquan[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(banquan[i]);
                        }

                    }

                }
                var result = _dbContext.SaveChanges() > 0;
                if (result)
                {
                    SaveCgjl(zhuzuo, jilu, canyuzes, status);
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
        /// 获取 著作详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<CgZhuZuoDto> GetCgZhuZuoById(Guid id)
        {
            SingleResult<CgZhuZuoDto> singleResult = new SingleResult<CgZhuZuoDto>();
            try
            {
                if (_dbContext.CgZuZhuo.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgZuZhuo.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = _mapper.Map<CgZhuZuoDto>(query);
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
        /// 保存成功记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="canyuzes"></param>
        /// <param name="jiLu"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgjl(CgZuZhuo entity, JiLu jiLu, List<canyuze> canyuzes, int status)
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

                    // query_jilu.UserId = currentUser.Id;
                    query_jilu.CgLeiXingMingCheng = "著作";
                    query_jilu.LastUpdateDate = DateTime.Now;
                    query_jilu.StartDate = entity.ChuBanShiJian;
                    query_jilu.HuoJiangLeiXing = entity.ZuZhuoHuoJiangJiBie;
                    query_jilu.CgMingCheng = entity.ZuZuoMingCheng;
                    //query_jilu.ShenHeFen = entity.ShenHeDeFen;
                    query_jilu.ShuMingPaiXu = entity.YuanNeiBenRenShuMingPaiXu;
                    query_jilu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    query_jilu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;
                    query_jilu.XiangMuZuChengYuan = str;

                }
                else
                {
                    CgJiLu cgJiLu = new CgJiLu();
                    cgJiLu.Id = Guid.NewGuid();
                    cgJiLu.CgId = entity.Id;
                    cgJiLu.UserId = currentUser.Id;
                    cgJiLu.CgLeiXingMingCheng = "著作";
                    cgJiLu.Status = status;
                    cgJiLu.CreateDate = cgJiLu.LastUpdateDate = DateTime.Now;
                    cgJiLu.UserName = currentUser.Name;
                    cgJiLu.BumenId = OrgHelper.GetBuMenId(currentUser);
                    cgJiLu.Bumen = OrgHelper.GetBuMenMingCheng(currentUser);
                    cgJiLu.StartDate = entity.ChuBanShiJian;
                    //cgJiLu.EndDate = entity.JiHuaWanChengShiJian;
                    cgJiLu.HuoJiangLeiXing = entity.ZuZhuoHuoJiangJiBie;
                    cgJiLu.CgMingCheng = entity.ZuZuoMingCheng;
                    // cgJiLu.ShenHeFen = entity.ShenHeDeFen;
                    cgJiLu.ShuMingPaiXu = entity.YuanNeiBenRenShuMingPaiXu;
                    cgJiLu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    cgJiLu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;
                    cgJiLu.XiangMuZuChengYuan = str;

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
        /// 
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
        /// 不带分页 著作统计
        /// </summary>
        /// <returns></returns>
        public ListResult<CgZhuZuoDto> GetZhuZhuoS()
        {
            ListResult<CgZhuZuoDto> listResult = new ListResult<CgZhuZuoDto>();
            try
            {
                //var query = _dbContext.CgZuZhuo.Where(x => x.Status == 1).GroupBy(x => x.ZuZuoMingCheng.Trim()).Select(x => x.First()); 
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "著作" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgZuZhuo.Where(x =>query_ids.Contains(x.Id));

                listResult.Results = _mapper.Map<List<CgZhuZuoDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }
        /// <summary>
        /// 带分页 著作统计
        /// </summary>
        /// <returns></returns>
        public ListResult<CgZhuZuoDto> GetZhuZhuoSByFenYe(int skip, int take)
        {
            ListResult<CgZhuZuoDto> listResult = new ListResult<CgZhuZuoDto>();
            try
            {
                //var query = _dbContext.CgZuZhuo.Where(x => x.Status == 1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "著作" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgZuZhuo.Where(x => query_ids.Contains(x.Id));

                listResult.Results = _mapper.Map<List<CgZhuZuoDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 筛选著作
        /// </summary>
        /// <param name="applyName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isHuoJiang"></param>
        /// <param name="cgName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgZhuZuoDto> GetZhuZhuoByBase(string applyName, string startTime, string endTime, string isHuoJiang,string cgName,int skip,int take)
        {
            ListResult<CgZhuZuoDto> listResult = new ListResult<CgZhuZuoDto>();
            try
            {
                //var query = _dbContext.CgZuZhuo.Where(x => x.Status != -1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "著作" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgZuZhuo.Where(x => query_ids.Contains(x.Id));
                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(cgName))
                {
                    query = query.Where(x => x.ZuZuoMingCheng.Contains(cgName));
                }
                else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.ChuBanShiJian >= Convert.ToDateTime(startTime));
                }
                else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.ChuBanShiJian <= Convert.ToDateTime(endTime));
                }
                else if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.ChuBanShiJian <= Convert.ToDateTime(endTime) && x.ChuBanShiJian >= Convert.ToDateTime(startTime));
                }
                else if (isHuoJiang == "是")
                {
                    query = query.Where(x => x.ZuZhuoHuoJiangJiBie != null);
                }
                else if (isHuoJiang == "否")
                {
                    query = query.Where(x => x.ZuZhuoHuoJiangJiBie == null);
                }
                listResult.Results = _mapper.Map<List<CgZhuZuoDto>>(query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
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