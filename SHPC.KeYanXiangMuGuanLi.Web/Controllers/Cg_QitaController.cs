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
    public class Cg_QitaController : KeYanControllerBase
    {
        public Cg_QitaController(
          FAPContext fapContext,
        FAP.Client.Service.OrganizationService organizationService,
        FAP.Client.Service.PrivilegeService privilegeService,
        FAP.Client.Service.MessageService messageService,
        FAP.Client.Service.LoggerService loggerService,
        KeYanGuanLiContext dbContext,
        IHttpContextAccessor httpContext,
        IMemoryCache memoryCache,
        IConfiguration configuration,
        ILogger<Cg_QitaController> logger,
        IMapper mapper)
        : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 保存 成果 其他
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<bool> SaveCgQita(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var qita = entity.cgQiTa;
            var canyuzes = entity.canyuzes;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var jilu = entity.jilu;
            try
            {
                if (qita.Id == Guid.Empty)
                {
                    qita.Id = Guid.NewGuid();
                    qita.UserId = currentUser.Id;
                    qita.UserName = currentUser.Name;
                    qita.Status = status;
                    qita.CreateDate = qita.LastUpdateDate = DateTime.Now;
                    qita.BuMenId = OrgHelper.GetBuMenId(currentUser);
                    qita.BuMenMingCheng = OrgHelper.GetBuMenMingCheng(currentUser);
                    _dbContext.CgQiTa.Add(qita);
                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = qita.Id;
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
                            file[i].ChengGuoId = qita.Id;
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
                            article[i].ChengGuoId = qita.Id;
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
                            wenjian[i].ChengGuoId = qita.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }

                }
                else
                {
                    var query_qita = _dbContext.CgQiTa.SingleOrDefault(x => x.Id == qita.Id);
                    query_qita.MingCheng = qita.MingCheng;
                    query_qita.ChengGuoNianDu = qita.ChengGuoNianDu;
                    query_qita.KeYanChengGuoJianJie = qita.KeYanChengGuoJianJie;
                    query_qita.LastUpdateDate = DateTime.Now;
                    query_qita.HuoJiangMingCheng = qita.HuoJiangMingCheng;
                    query_qita.ShiJiDeFen = query_qita.ShiJiDeFen;
                    query_qita.Status = status;
                    query_qita.SuoShuNianDu = qita.SuoShuNianDu;

                    //附件
                    var query_fj = _dbContext.FuJian.Where(x => x.ChengGuoId == qita.Id);
                    _dbContext.FuJian.RemoveRange(query_fj);

                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = qita.Id;
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
                            file[i].ChengGuoId = qita.Id;
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
                            article[i].ChengGuoId = qita.Id;
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
                            wenjian[i].ChengGuoId = qita.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }

                }
                var result = _dbContext.SaveChanges() > 0;
                if (result)
                {
                    SaveCgjl(qita, jilu, status);
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
        public SingleResult<bool> SaveCgjl(CgQiTa entity, JiLu jiLu, int status)
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
                    query_jilu.CgLeiXingMingCheng = "其他";

                    query_jilu.LastUpdateDate = DateTime.Now;
                    //query_jilu.StartDate = entity.CreateDate;
                    query_jilu.CgMingCheng = entity.MingCheng;
                    //query_jilu.ShenHeFen = entity.ShenHeDeFen;
                    query_jilu.ZhuanJiZhiWu = jiLu.ZhuanJiZhiWu;
                    query_jilu.JiaoGuanZhiWu = jiLu.JiaoGuanZhiWu;


                }
                else
                {
                    CgJiLu cgJiLu = new CgJiLu();
                    cgJiLu.Id = Guid.NewGuid();
                    cgJiLu.CgId = entity.Id;
                    cgJiLu.UserId = currentUser.Id;
                    cgJiLu.CgLeiXingMingCheng = "其他";
                    cgJiLu.Status = status;
                    cgJiLu.CreateDate = cgJiLu.LastUpdateDate = DateTime.Now;
                    cgJiLu.UserName = currentUser.Name;
                    cgJiLu.BumenId = OrgHelper.GetBuMenId(currentUser);
                    cgJiLu.Bumen = OrgHelper.GetBuMenMingCheng(currentUser);
                    //cgJiLu.StartDate = entity.CreateDate;
                    cgJiLu.CgMingCheng = entity.MingCheng;
                    //cgJiLu.ShenHeFen = entity.ShenHeDeFen;
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
        /// 获取 其他详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<Cg_QitaDto> GetCgQitaById(Guid id)
        {
            SingleResult<Cg_QitaDto> singleResult = new SingleResult<Cg_QitaDto>();
            try
            {
                if (_dbContext.CgQiTa.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgQiTa.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = _mapper.Map<Cg_QitaDto>(query);
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
        /// 其他 统计 不带分页
        /// </summary>
        /// <returns></returns>
        public ListResult<CgQiTa> GetQiTaS()
        {
            ListResult<CgQiTa> listResult = new ListResult<CgQiTa>();
            try
            {
                //var query = _dbContext.CgQiTa.Where(x => x.Status == 1).GroupBy(x => x.MingCheng.Trim()).Select(x => x.First());
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "其他" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgQiTa.Where(x => query_ids.Contains(x.Id));

                listResult.Results = query.ToList();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 其他统计 带分页
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgQiTa> GetQiTaSByFenYe(int skip,int take)
        {
            ListResult<CgQiTa> listResult = new ListResult<CgQiTa>();
            try
            {
                // var query = _dbContext.CgQiTa.Where(x => x.Status == 1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "其他" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgQiTa.Where(x => query_ids.Contains(x.Id));

                listResult.Results = query.Skip(skip).Take(take).ToList();
                listResult.TotalRows = query.Count();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 筛选其他
        /// </summary>
        /// <param name="applyName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isHuoJiang"></param>
        /// <param name="cgName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgQiTa> GetQiTaByBase(string applyName, string startTime, string endTime, string isHuoJiang,string cgName,int skip,int take)
        {
            ListResult<CgQiTa> listResult = new ListResult<CgQiTa>();
            try
            {
                //var query = _dbContext.CgQiTa.Where(x => x.Status != -1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "其他" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgQiTa.Where(x => query_ids.Contains(x.Id));
                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(cgName))
                {
                    query = query.Where(x => x.MingCheng.Contains(cgName));
                }
                listResult.Results = query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList();
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