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
    public class Cg_JiaoCaiController : KeYanControllerBase
    {
        public Cg_JiaoCaiController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<Cg_JiaoCaiController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }

        /// <summary>
        /// 保存教材
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgJiaoCai(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var jiaocai = entity.cgJiaoCai;
            // var canyuzes = entity.canyuzes;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var banquan = entity.banquanlist;
            var jilu = entity.jilu;

            try
            {
                if (jiaocai.Id == Guid.Empty)
                {
                    jiaocai.Id = Guid.NewGuid();
                    jiaocai.UserId = currentUser.Id;
                    jiaocai.UserName = currentUser.Name;
                    jiaocai.Status = status;
                    jiaocai.CreateDate = jiaocai.LastUpdateDate = DateTime.Now;
                    jiaocai.BuMenId= OrgHelper.GetBuMenId(currentUser);
                    jiaocai.BuMenMingCheng= OrgHelper.GetBuMenMingCheng(currentUser);
                    _dbContext.CgJiaoCai.Add(jiaocai);

                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = jiaocai.Id;
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
                            file[i].ChengGuoId = jiaocai.Id;
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
                            article[i].ChengGuoId = jiaocai.Id;
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
                            wenjian[i].ChengGuoId = jiaocai.Id;
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
                            banquan[i].ChengGuoId = jiaocai.Id;
                            banquan[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.版权页面;
                            banquan[i].CreateDateTime = banquan[i].LastUpdateTime = DateTime.Now;
                            banquan[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(banquan[i]);
                        }
                    }


                }
                else
                {
                    //教材
                    var query_jiaocai = _dbContext.CgJiaoCai.SingleOrDefault(x => x.Id == jiaocai.Id);
                    query_jiaocai.JiaoCaiMingCheng = jiaocai.JiaoCaiMingCheng;
                    query_jiaocai.Isbn = jiaocai.Isbn;
                    query_jiaocai.ChuBanShe = jiaocai.ChuBanShe;
                    query_jiaocai.ChuBanSheJiBie = jiaocai.ChuBanSheJiBie;
                    query_jiaocai.ChuBanShiJian = jiaocai.ChuBanShiJian;
                    query_jiaocai.CanBianQingKuang = jiaocai.CanBianQingKuang;
                    query_jiaocai.IsBiaoZhuXueYuan = jiaocai.IsBiaoZhuXueYuan;
                    query_jiaocai.QuanShuZiShu = jiaocai.QuanShuZiShu;
                    query_jiaocai.CanBianZhangJie = jiaocai.CanBianZhangJie;
                    query_jiaocai.CanBianZiShu = jiaocai.CanBianZiShu;
                    query_jiaocai.JiaoCaiHuoJiangJiBie = jiaocai.JiaoCaiHuoJiangJiBie;
                    query_jiaocai.JiaoCaiHuoJiangShiJian = jiaocai.JiaoCaiHuoJiangShiJian;
                    query_jiaocai.KeYanKaoHeDeFen = jiaocai.KeYanKaoHeDeFen;
                    query_jiaocai.LastUpdateDate = DateTime.Now;
                    query_jiaocai.HuoJiangMingCheng = jiaocai.HuoJiangMingCheng;
                    query_jiaocai.ShiJiDenFen = jiaocai.ShiJiDenFen;
                    query_jiaocai.Status = status;
                    query_jiaocai.SuoShuNianDu = jiaocai.SuoShuNianDu;

                    //附件
                    var query_fj = _dbContext.FuJian.Where(x => x.ChengGuoId == jiaocai.Id);
                    _dbContext.FuJian.RemoveRange(query_fj);
                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = jiaocai.Id;
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
                            file[i].ChengGuoId = jiaocai.Id;
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
                            article[i].ChengGuoId = jiaocai.Id;
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
                            wenjian[i].ChengGuoId = jiaocai.Id;
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
                            banquan[i].ChengGuoId = jiaocai.Id;
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
                    SaveCgjl(jiaocai, jilu, status);
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
        /// <param name="jiLu"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgjl(CgJiaoCai entity, JiLu jiLu, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            try
            {
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
                    query_jilu.CgLeiXingMingCheng = "教材";
                    query_jilu.LastUpdateDate = DateTime.Now;
                    query_jilu.StartDate = entity.ChuBanShiJian;
                    query_jilu.HuoJiangLeiXing = entity.JiaoCaiHuoJiangJiBie;
                    query_jilu.CgMingCheng = entity.JiaoCaiMingCheng;
                    //query_jilu.ShenHeFen = entity.ShenHeDeFen;
                    query_jilu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;
                    query_jilu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;

                }
                else
                {
                    CgJiLu cgJiLu = new CgJiLu();
                    cgJiLu.Id = Guid.NewGuid();
                    cgJiLu.CgId = entity.Id;
                    cgJiLu.UserId = currentUser.Id;
                    cgJiLu.CgLeiXingMingCheng = "教材";
                    cgJiLu.Status = status;
                    cgJiLu.CreateDate = cgJiLu.LastUpdateDate = DateTime.Now;
                    cgJiLu.UserName = currentUser.Name;
                    cgJiLu.BumenId = OrgHelper.GetBuMenId(currentUser);
                    cgJiLu.Bumen = OrgHelper.GetBuMenMingCheng(currentUser);
                    cgJiLu.StartDate = entity.ChuBanShiJian;
                    //cgJiLu.EndDate = entity.JiHuaWanChengShiJian;
                    cgJiLu.HuoJiangLeiXing = entity.JiaoCaiHuoJiangJiBie;
                    cgJiLu.CgMingCheng = entity.JiaoCaiMingCheng;
                    //cgJiLu.ShenHeFen = entity.ShenHeDeFen;
                    cgJiLu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;
                    cgJiLu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
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
        /// 获取教材详情
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<CgJiaoCaiDto> GetJiaoCaiById(Guid id)
        {
            SingleResult<CgJiaoCaiDto> singleResult = new SingleResult<CgJiaoCaiDto>();
            try
            {
                if (_dbContext.CgJiaoCai.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgJiaoCai.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = _mapper.Map<CgJiaoCaiDto>(query);
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
        /// 教材统计 不带分页
        /// </summary>
        /// <returns></returns>
        public ListResult<CgJiaoCaiDto> GetJiaoCaiS()
        {
            ListResult<CgJiaoCaiDto> listResult = new ListResult<CgJiaoCaiDto>();
            try
            {
                //var query = _dbContext.CgJiaoCai.Where(x => x.Status == 1).GroupBy(x => x.JiaoCaiMingCheng.Trim()).Select(x => x.First());
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "教材" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgJiaoCai.Where(x => query_ids.Contains(x.Id));
               
                listResult.Results = _mapper.Map<List<CgJiaoCaiDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误",ex);
            }
            return listResult;
        }
       /// <summary>
       /// 教材统计 带分页
       /// </summary>
       /// <param name="skip"></param>
       /// <param name="take"></param>
       /// <returns></returns>
        public ListResult<CgJiaoCaiDto> GetJiaoCaiSByFenYe(int skip,int take)
        {
            ListResult<CgJiaoCaiDto> listResult = new ListResult<CgJiaoCaiDto>();
            try
            {
                //var query = _dbContext.CgJiaoCai.Where(x => x.Status == 1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "教材" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgJiaoCai.Where(x => query_ids.Contains(x.Id));

                listResult.Results = _mapper.Map<List<CgJiaoCaiDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 教材筛选
        /// </summary>
        /// <param name="applyName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isHuoJiang"></param>
        /// <param name="cgName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgJiaoCaiDto> GetJiaoCaiByBase(string applyName, string startTime, string endTime, string isHuoJiang,string cgName,int skip,int take)
        {
            ListResult<CgJiaoCaiDto> listResult = new ListResult<CgJiaoCaiDto>();
            try
            {
                //var query = _dbContext.CgJiaoCai.Where(x => x.Status != -1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "教材" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgJiaoCai.Where(x => query_ids.Contains(x.Id));
                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(cgName))
                {
                    query = query.Where(x => x.JiaoCaiMingCheng.Contains(cgName));
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
                    query = query.Where(x => x.JiaoCaiHuoJiangJiBie != null);
                }
                else if (isHuoJiang == "否")
                {
                    query = query.Where(x => x.JiaoCaiHuoJiangJiBie == null);
                }
                listResult.Results = _mapper.Map<List<CgJiaoCaiDto>>(query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
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