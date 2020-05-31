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
    public class Cg_ShenHeController : KeYanControllerBase
    {
        public Cg_ShenHeController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<Cg_ShenHeController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> shenhe(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var kyxm = entity.cgKeYanXiangMu;
            var zuzuo = entity.cgZuZhuo;
            var jiaocai = entity.cgJiaoCai;
            var lunwen = entity.cgLunWen;
            var ruanjian = entity.CgRuanJianYuZhuanLi;
            var qita = entity.cgQiTa;
            var yijian = entity.CgShenHeYiJian;
            var sh = entity.CgShenHe;

            try
            {
                if (kyxm != null)
                {
                    if (_dbContext.CgKeYanXiangMu.Any(x => x.Id == kyxm.Id))
                    {
                        SaveShenHe(kyxm.Id, sh, status);
                        var query_kyxm = _dbContext.CgKeYanXiangMu.SingleOrDefault(x => x.Id == kyxm.Id);
                        query_kyxm.ShenHeJiaKouFen = kyxm.ShenHeJiaKouFen;
                        query_kyxm.JiaKouFenShuoMing = kyxm.JiaKouFenShuoMing;
                        query_kyxm.ShenHeDeFen = kyxm.ShenHeDeFen;
                        query_kyxm.ShiJiDeFen = kyxm.ShiJiDeFen;



                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == kyxm.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.ShenHeFen = query_kyxm.ShenHeDeFen;
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;

                    }
                }
                else if (zuzuo != null)
                {
                    if (_dbContext.CgZuZhuo.Any(x => x.Id == zuzuo.Id))
                    {
                        SaveShenHe(zuzuo.Id, sh, status);
                        var query_zuzuo = _dbContext.CgZuZhuo.SingleOrDefault(x => x.Id == zuzuo.Id);
                        query_zuzuo.ShenHeJiaKouFen = zuzuo.ShenHeJiaKouFen;
                        query_zuzuo.JiaKouFenShuoMing = zuzuo.JiaKouFenShuoMing;
                        query_zuzuo.ShenHeDeFen = zuzuo.ShenHeDeFen;
                        query_zuzuo.ShiJiDeFen = zuzuo.ShiJiDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == zuzuo.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.ShenHeFen = query_zuzuo.ShenHeDeFen;
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;
                    }
                }
                else if (jiaocai != null)
                {
                    if (_dbContext.CgJiaoCai.Any(x => x.Id == jiaocai.Id))
                    {
                        SaveShenHe(jiaocai.Id, sh, status);
                        var query_jiaocai = _dbContext.CgJiaoCai.SingleOrDefault(x => x.Id == jiaocai.Id);
                        query_jiaocai.ShenHeJiaKouFen = jiaocai.ShenHeJiaKouFen;
                        query_jiaocai.JiaKouFenShuoMing = jiaocai.JiaKouFenShuoMing;
                        query_jiaocai.ShenHeDeFen = jiaocai.ShenHeDeFen;
                        query_jiaocai.ShiJiDenFen = jiaocai.ShiJiDenFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == jiaocai.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.ShenHeFen = query_jiaocai.ShenHeDeFen;
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;

                    }
                }
                else if (lunwen != null)
                {
                    if (_dbContext.CgLunWen.Any(x => x.Id == lunwen.Id))
                    {
                        SaveShenHe(lunwen.Id, sh, status);
                        var query_lunwen = _dbContext.CgLunWen.SingleOrDefault(x => x.Id == lunwen.Id);
                        query_lunwen.ShenHeJiaKouFen = lunwen.ShenHeJiaKouFen;
                        query_lunwen.JiaKouFenShuoMing = lunwen.JiaKouFenShuoMing;
                        query_lunwen.ShenHeDeFen = lunwen.ShenHeDeFen;
                        query_lunwen.ShiJiDeFen = lunwen.ShiJiDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == lunwen.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.ShenHeFen = query_lunwen.ShenHeDeFen;
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;
                    }
                }
                else if (ruanjian != null)
                {
                    if (_dbContext.CgRuanJianYuZhuanLi.Any(x => x.Id == ruanjian.Id))
                    {
                        SaveShenHe(ruanjian.Id, sh, status);
                        var query_ruanjian = _dbContext.CgRuanJianYuZhuanLi.SingleOrDefault(x => x.Id == ruanjian.Id);
                        query_ruanjian.ShenHeJiaKouFen = ruanjian.ShenHeJiaKouFen;
                        query_ruanjian.JiaKouFenShuoMing = ruanjian.JiaKouFenShuoMing;
                        query_ruanjian.ShenHeDeFen = ruanjian.ShenHeDeFen;
                        query_ruanjian.ShiJiDeFen = ruanjian.ShiJiDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == ruanjian.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.ShenHeFen = query_ruanjian.ShenHeDeFen;
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;
                    }
                }
                else if (qita != null)
                {
                    if (_dbContext.CgQiTa.Any(x => x.Id == qita.Id))
                    {
                        SaveShenHe(qita.Id, sh, status);
                        var query_qita = _dbContext.CgQiTa.SingleOrDefault(x => x.Id == qita.Id);
                        query_qita.ShenHeJiaKouFen = qita.ShenHeJiaKouFen;
                        query_qita.JiaKouFenShuoMing = qita.JiaKouFenShuoMing;
                        query_qita.ShenHeDeFen = qita.ShenHeDeFen;
                        query_qita.ShiJiDeFen = qita.ShiJiDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == qita.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.ShenHeFen = query_qita.ShenHeDeFen;
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;
                    }
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
        /// 部门，科研处退回
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> tuihui(Request_CG_Bag entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var kyxm = entity.cgKeYanXiangMu;
            var zuzuo = entity.cgZuZhuo;
            var jiaocai = entity.cgJiaoCai;
            var lunwen = entity.cgLunWen;
            var ruanjian = entity.CgRuanJianYuZhuanLi;
            var qita = entity.cgQiTa;
            var yijian = entity.CgShenHeYiJian;
            var sh = entity.CgShenHe;

            try
            {
                if (kyxm != null)
                {
                    if (_dbContext.CgKeYanXiangMu.Any(x => x.Id == kyxm.Id))
                    {
                        SaveShenHe(kyxm.Id, sh, -2);
                        //var query_kyxm = _dbContext.CgKeYanXiangMu.SingleOrDefault(x => x.Id == kyxm.Id);
                        //query_kyxm.ShenHeJiaKouFen = kyxm.ShenHeJiaKouFen;
                        //query_kyxm.JiaKouFenShuoMing = kyxm.JiaKouFenShuoMing;
                        //query_kyxm.ShenHeDeFen = kyxm.ShenHeDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == kyxm.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.Status = -2;
                        query.LastUpdateDate = DateTime.Now;

                    }
                }
                else if (zuzuo != null)
                {
                    if (_dbContext.CgZuZhuo.Any(x => x.Id == zuzuo.Id))
                    {
                        SaveShenHe(zuzuo.Id, sh, -2);
                        //var query_zuzuo = _dbContext.CgZuZhuo.SingleOrDefault(x => x.Id == zuzuo.Id);
                        //query_zuzuo.ShenHeJiaKouFen = zuzuo.ShenHeJiaKouFen;
                        //query_zuzuo.JiaKouFenShuoMing = zuzuo.JiaKouFenShuoMing;
                        //query_zuzuo.ShenHeDeFen = zuzuo.ShenHeDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == zuzuo.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.Status = -2;
                        query.LastUpdateDate = DateTime.Now;
                    }
                }
                else if (jiaocai != null)
                {
                    if (_dbContext.CgJiaoCai.Any(x => x.Id == jiaocai.Id))
                    {
                        SaveShenHe(jiaocai.Id, sh, -2);
                        //var query_jiaocai = _dbContext.CgJiaoCai.SingleOrDefault(x => x.Id == jiaocai.Id);
                        //query_jiaocai.ShenHeJiaKouFen = jiaocai.ShenHeJiaKouFen;
                        //query_jiaocai.JiaKouFenShuoMing = jiaocai.JiaKouFenShuoMing;
                        //query_jiaocai.ShenHeDeFen = jiaocai.ShenHeDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == jiaocai.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.Status = -2;
                        query.LastUpdateDate = DateTime.Now;

                    }
                }
                else if (lunwen != null)
                {
                    if (_dbContext.CgLunWen.Any(x => x.Id == lunwen.Id))
                    {
                        SaveShenHe(lunwen.Id, sh, -2);
                        //var query_lunwen = _dbContext.CgLunWen.SingleOrDefault(x => x.Id == lunwen.Id);
                        //query_lunwen.ShenHeJiaKouFen = lunwen.ShenHeJiaKouFen;
                        //query_lunwen.JiaKouFenShuoMing = lunwen.JiaKouFenShuoMing;
                        //query_lunwen.ShenHeDeFen = lunwen.ShenHeDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == lunwen.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.Status = -2;
                        query.LastUpdateDate = DateTime.Now;
                    }
                }
                else if (ruanjian != null)
                {
                    if (_dbContext.CgRuanJianYuZhuanLi.Any(x => x.Id == ruanjian.Id))
                    {
                        SaveShenHe(ruanjian.Id, sh, -2);
                        //var query_ruanjian = _dbContext.CgRuanJianYuZhuanLi.SingleOrDefault(x => x.Id == ruanjian.Id);
                        //query_ruanjian.ShenHeJiaKouFen = ruanjian.ShenHeJiaKouFen;
                        //query_ruanjian.JiaKouFenShuoMing = ruanjian.JiaKouFenShuoMing;
                        //query_ruanjian.ShenHeDeFen = ruanjian.ShenHeDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == ruanjian.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.Status = -2;
                        query.LastUpdateDate = DateTime.Now;
                    }
                }
                else if (qita != null)
                {
                    if (_dbContext.CgQiTa.Any(x => x.Id == qita.Id))
                    {
                        SaveShenHe(qita.Id, sh, -2);
                        //var query_qita = _dbContext.CgQiTa.SingleOrDefault(x => x.Id == qita.Id);
                        //query_qita.ShenHeJiaKouFen = qita.ShenHeJiaKouFen;
                        //query_qita.JiaKouFenShuoMing = qita.JiaKouFenShuoMing;
                        //query_qita.ShenHeDeFen = qita.ShenHeDeFen;

                        var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == qita.Id);
                        if (status == 3)
                        {
                            query.IsKeYanChuShenHe = 1;
                        }
                        query.Status = -2;
                        query.LastUpdateDate = DateTime.Now;
                    }
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
        /// 审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<bool> SaveShenHe(Guid id, CgShenHe entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            try
            {
                CgShenHe cgShenHe = new CgShenHe();
                cgShenHe.Id = Guid.NewGuid();
                cgShenHe.CgId = id;
                cgShenHe.JieDian = 1;
                cgShenHe.Status = status;
                cgShenHe.ShenPiRenId = currentUser.Id;
                cgShenHe.ShenPiRenName = currentUser.Name;
                cgShenHe.ShenPiRenBuMenId = OrgHelper.GetBuMenId(currentUser);
                cgShenHe.ShenPiRenBuMenMingCheng = OrgHelper.GetBuMenMingCheng(currentUser);
                cgShenHe.ShenPiShiJian = cgShenHe.CreateDate = cgShenHe.LastUpdateDate = DateTime.Now;
                cgShenHe.ShenHeYiJian = entity.ShenHeYiJian;
                _dbContext.CgShenHe.Add(cgShenHe);

                //CgShenHeYiJian cgShenHeYiJian = new CgShenHeYiJian();
                //cgShenHeYiJian.Id = Guid.NewGuid();
                //cgShenHeYiJian.Status = status;
                //cgShenHeYiJian.ShenHeId = cgShenHe.Id;
                //cgShenHeYiJian.ShenHeYiJian = yijian;
                //cgShenHeYiJian.CreateDate = cgShenHeYiJian.LastUpdateDate = DateTime.Now;
                //_dbContext.CgShenHeYiJian.Add(cgShenHeYiJian);

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
        /// 退回
        /// </summary>
        /// <param name="id"></param>
        /// <param name="yijian"></param>
        /// <returns></returns>
        public SingleResult<bool> Savetuihui(Guid id, string yijian)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            try
            {
                CgShenHe cgShenHe = new CgShenHe();
                cgShenHe.Id = Guid.NewGuid();
                cgShenHe.CgId = id;
                cgShenHe.JieDian = 1;
                cgShenHe.Status = 1;
                cgShenHe.ShenPiRenId = currentUser.Id;
                cgShenHe.ShenPiRenName = currentUser.Name;
                cgShenHe.ShenPiRenBuMenId = currentUser.OrganizationalUnitRoleDefault.OrganizationalUnitId;
                cgShenHe.ShenPiRenBuMenMingCheng = currentUser.OrganizationalUnitRoleDefault.ORGName;
                cgShenHe.ShenPiShiJian = cgShenHe.CreateDate = cgShenHe.LastUpdateDate = DateTime.Now;
                _dbContext.CgShenHe.Add(cgShenHe);

                CgShenHeYiJian cgShenHeYiJian = new CgShenHeYiJian();
                cgShenHeYiJian.Id = Guid.NewGuid();
                cgShenHeYiJian.Status = 1;
                cgShenHeYiJian.ShenHeId = cgShenHe.Id;
                cgShenHeYiJian.ShenHeYiJian = yijian;
                cgShenHeYiJian.CreateDate = cgShenHeYiJian.LastUpdateDate = DateTime.Now;
                _dbContext.CgShenHeYiJian.Add(cgShenHeYiJian);

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
        /// 获取 审核意见(部门)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<CgShenHe> GetShenHeYiJian(Guid id, int status)
        {
            SingleResult<CgShenHe> singleResult = new SingleResult<CgShenHe>();
            try
            {
                if (_dbContext.CgShenHe.Any(x => x.CgId == id))
                {
                    var query = _dbContext.CgShenHe.SingleOrDefault(x => x.CgId == id && x.Status == status);
                    singleResult.Result = query;
                }
                else
                {
                    CgShenHe cgShenHe = new CgShenHe();
                    singleResult.Result = cgShenHe;
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
        /// 获取 审核意见(科研处)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<CgShenHe> GetkycYiJian(Guid id, int status)
        {
            SingleResult<CgShenHe> singleResult = new SingleResult<CgShenHe>();
            try
            {
                if (_dbContext.CgShenHe.Any(x => x.CgId == id && x.Status == status))
                {
                    var query = _dbContext.CgShenHe.SingleOrDefault(x => x.CgId == id && x.Status == status);
                    singleResult.Result = query;
                }
                else
                {
                    CgShenHe cgShenHe = new CgShenHe();
                    singleResult.Result = cgShenHe;
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
        /// 获取 审核意见(退回)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<CgShenHe> GetthYiJian(Guid id, int status)
        {
            SingleResult<CgShenHe> singleResult = new SingleResult<CgShenHe>();
            try
            {
                if (_dbContext.CgShenHe.Any(x => x.CgId == id && x.Status == status))
                {
                    var query = _dbContext.CgShenHe.Where(x => x.CgId == id && x.Status == status).OrderByDescending(x => x.CreateDate);

                    // singleResult.Result = query[];
                }
                else
                {
                    CgShenHe cgShenHe = new CgShenHe();
                    singleResult.Result = cgShenHe;
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
        /// 部门审核权限
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public bool BumenShenHeQuanXian()
        {
            bool result = false;
            var id = Guid.Parse(_configuration.GetSection("BMSH").Value);
            if (_fapContext.CurrentUser.PrivilegeIds.Contains(id)|| _fapContext.CurrentUser.IsSystemAdmin)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 科研处审核权限
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public bool KeYanChuShenHeQuanXian()
        {
            bool result = false;
            var id = Guid.Parse(_configuration.GetSection("KYCSH").Value);
            if (_fapContext.CurrentUser.PrivilegeIds.Contains(id)|| _fapContext.CurrentUser.IsSystemAdmin)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 科研初审权限
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> ChuShen()
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            bool result = false;
            try
            {
                var id = Guid.Parse(_configuration.GetSection("KYCS").Value);
                if (_fapContext.CurrentUser.PrivilegeIds.Contains(id)||_fapContext.CurrentUser.IsSystemAdmin)
                {
                    result = true;
                }
                singleResult.Result = result;
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误", ex);
            }
            return singleResult;
        }
        /// <summary>
        /// 获取权限id 集合
        /// </summary>
        /// <returns></returns>
        public ListResult<object> GetList()
        {
            ListResult<object> listResult = new ListResult<object>();
            try
            {
                List<object> list = new List<object>();
                var ids = _fapContext.CurrentUser.PrivilegeIds;
                ids.ForEach(x =>
                {
                    list.Add(x);
                });
                listResult.Results = list;
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<object> Getid()
        {
            SingleResult<object> singleResult = new SingleResult<object>();
            try
            {
                var id = Guid.Parse(_configuration.GetSection("KYCS").Value);
                singleResult.Result = id;
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误", ex);
            }
            return singleResult;
        }



        /// <summary>
        /// 获取当前登录人姓名
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            var currentUser = _fapContext.CurrentUser;
            return currentUser.Name;
        }


        /// <summary>
        /// 获取 全部意见
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ListResult<CgShenHe> GetShenHeYiJians(Guid id)
        {
            ListResult<CgShenHe> listResult = new ListResult<CgShenHe>();
            try
            {
                if (_dbContext.CgShenHe.Any(x => x.CgId == id))
                {
                    var query = _dbContext.CgShenHe.Where(x => x.CgId == id).OrderByDescending(x => x.CreateDate);
                    listResult.Results = query.ToList();
                }
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 部门批量审核
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<bool> BuMenShenHes(List<CgJiLu> entity, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            CgShenHe cgShenHe = new CgShenHe();
            cgShenHe.ShenHeYiJian = "部门通过";
            try
            {
                entity.ForEach(x =>
                {
                    if (_dbContext.CgJiLu.Any(p => p.Id == x.Id))
                    {
                        SaveShenHe(x.CgId.Value,cgShenHe,status);
                        var query = _dbContext.CgJiLu.SingleOrDefault(p => p.Id == x.Id);
                        query.Status = status + 1;
                        query.LastUpdateDate = DateTime.Now;
                        query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;
                    }
                });
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
        /// 部门直接审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<bool> ZhiJieShenHe(Guid id,int status) {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            CgShenHe cgShenHe = new CgShenHe();
            cgShenHe.ShenHeYiJian = "部门通过";
            try
            {
                if (_dbContext.CgJiLu.Any(x=>x.Id==id))
                {
                    var query = _dbContext.CgJiLu.SingleOrDefault(x => x.Id == id);
                    SaveShenHe(query.CgId.Value, cgShenHe, status);

                    query.Status = status + 1;
                    query.LastUpdateDate = DateTime.Now;
                    query.ShangJiShenHeRen = _fapContext.CurrentUser.Name;
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

    }
}