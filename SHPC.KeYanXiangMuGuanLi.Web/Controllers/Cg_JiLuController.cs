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

namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class Cg_JiLuController : KeYanControllerBase
    {
        public Cg_JiLuController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<Cg_JiLuController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }

        /// <summary>
        /// 总览
        /// </summary>
        /// <returns></returns>
        public ListResult<CgJiLuDto> GetCgJilus(int skip, int take)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            try
            {
                var query = _dbContext.CgJiLu.Where(x => x.Status != -1).OrderByDescending(x => x.CreateDate);
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        ///个人
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgJiLuDto> GetMycgjilus(int skip, int take)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            var useid = _fapContext.CurrentUser.Id;
            try
            {
                var query = _dbContext.CgJiLu.Where(x => x.UserId == useid && x.Status != -1).OrderByDescending(x => x.CreateDate);
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 根据状态获取
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ListResult<CgJiLuDto> GetCgJiLuByStatus(int skip, int take, int status)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            var currentUser = _fapContext.CurrentUser;
            var bumen = OrgHelper.GetBuMenId(currentUser);
            try
            {
                var query = _dbContext.CgJiLu.Where(x => x.Status != -1);
                //状态2为部门审核；3为科研处审核。
                if (status == 2)
                {
                    query = query.Where(x => x.Status == status && x.BumenId == bumen).OrderByDescending(x => x.CreateDate);
                }
                else if (status == 3)
                {
                    query = query.Where(x => x.Status == status).OrderByDescending(x => x.CreateDate);
                }
                else if (status == 1)
                {
                    query = query.Where(x => x.Status == 1 && x.BumenId == bumen).OrderByDescending(x => x.CreateDate);
                }
                // var query = _dbContext.CgJiLu.Where(x=>x.Status == status).OrderByDescending(x => x.CreateDate).Skip(skip).Take(take);
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 筛选 科研处未审核的
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="name"></param>
        /// <param name="bumen"></param>
        /// <param name="zhuangtai"></param>
        /// <returns></returns>
        public ListResult<CgJiLuDto> SelectJiLu(int skip, int take, string name, string bumen, int zhuangtai)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            try
            {
                var query = _dbContext.CgJiLu.AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(x => x.Status == zhuangtai && x.UserName.Contains(name));
                }
                else if (!string.IsNullOrEmpty(bumen))
                {
                    query = query.Where(x => x.Status == zhuangtai && x.Bumen.Contains(bumen));
                }
                else
                {
                    query = query.Where(x => x.Status == zhuangtai).OrderByDescending(x => x.CreateDate);
                }
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 筛选
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="applyName"></param>
        /// <param name="bumen"></param>
        /// <param name="mingcheng"></param>
        /// <param name="xiangmuleixing"></param>
        /// <param name="huojiangleixing"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="huojiangtime"></param>
        /// <returns></returns>
        public ListResult<CgJiLu> GetCgJiluBase(int skip, int take, string applyName, string bumen, string mingcheng, int xiangmuleixing, int huojiangleixing, string startTime, string endTime, string huojiangtime)
        {
            ListResult<CgJiLu> listResult = new ListResult<CgJiLu>();
            string leixingname = "";
            if (xiangmuleixing == 0)
            {
                leixingname = "科研项目";
            }
            else if (xiangmuleixing == 1)
            {
                leixingname = "著作";
            }
            else if (xiangmuleixing == 2)
            {
                leixingname = "教材";
            }
            else if (xiangmuleixing == 3)
            {
                leixingname = "论文";
            }
            else if (xiangmuleixing == 4)
            {
                leixingname = "软件与专利";
            }
            else if (xiangmuleixing == 5)
            {
                leixingname = "其他";
            }
            try
            {
                var query = _dbContext.CgJiLu.Where(x => x.Status != -1);
                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(bumen))
                {
                    query = query.Where(x => x.Bumen.Contains(bumen));
                }
                else if (!string.IsNullOrEmpty(mingcheng))
                {
                    query = query.Where(x => x.CgMingCheng.Contains(mingcheng));
                }
                else if (!string.IsNullOrEmpty(leixingname))
                {
                    query = query.Where(x => x.CgLeiXingMingCheng.Contains(leixingname));
                }
                else if (!string.IsNullOrEmpty(huojiangleixing.ToString()) && huojiangleixing != -1)
                {
                    query = query.Where(x => x.HuoJiangLeiXing == huojiangleixing);
                }
                else if (!string.IsNullOrEmpty(startTime.ToString()) && string.IsNullOrEmpty(endTime.ToString()))
                {
                    query = query.Where(x => x.StartDate >= Convert.ToDateTime(startTime));
                }
                else if (!string.IsNullOrEmpty(endTime.ToString()) && string.IsNullOrEmpty(startTime.ToString()))
                {
                    query = query.Where(x => x.EndDate <= Convert.ToDateTime(endTime));
                }
                else if (!string.IsNullOrEmpty(endTime.ToString()) && !string.IsNullOrEmpty(startTime.ToString()))
                {
                    query = query.Where(x => x.StartDate >= Convert.ToDateTime(startTime) && x.EndDate <= Convert.ToDateTime(endTime));
                }

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
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SingleResult<CgJiLuDto> GetCgjlById(Guid id)
        {
            SingleResult<CgJiLuDto> singleResult = new SingleResult<CgJiLuDto>();
            try
            {
                var query = _dbContext.CgJiLu.SingleOrDefault(x => x.Id == id);
                singleResult.Result = _mapper.Map<CgJiLuDto>(query);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }

        /// <summary>
        /// 删除 cgkyxm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> DelCgkyxm(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgKeYanXiangMu.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgKeYanXiangMu.SingleOrDefault(x => x.Id == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
                    // DelCgjl(id);
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
        /// 删除 著作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> DelCgZhuZuo(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgZuZhuo.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgZuZhuo.SingleOrDefault(x => x.Id == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 删除 教材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> DelCgJiaoCai(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgJiaoCai.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgJiaoCai.SingleOrDefault(x => x.Id == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 删除 论文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> DelCgLunWen(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgLunWen.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgLunWen.SingleOrDefault(x => x.Id == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 删除 软件与专利
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> DelRuanJian(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgRuanJianYuZhuanLi.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgRuanJianYuZhuanLi.SingleOrDefault(x => x.Id == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 删除 其他
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> DelQita(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgQiTa.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgQiTa.SingleOrDefault(x => x.Id == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 更改记录
        /// </summary>
        /// <param name="id">成果id</param>
        /// <returns></returns>
        public SingleResult<bool> DelCgjl(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            try
            {
                DelCgkyxm(id);
                DelCgZhuZuo(id);
                DelCgJiaoCai(id);
                DelCgLunWen(id);
                DelRuanJian(id);
                DelQita(id);
                if (_dbContext.CgJiLu.Any(x => x.CgId == id))
                {
                    var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == id);
                    query.Status = -1;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 获取审核意见
        /// </summary>
        /// <param name="id">成果id</param>
        /// <param name="status">退回 部门审核 科研处审核 （意见）</param>
        /// <returns></returns>
        public SingleResult<CgShenHe> GetShenHeYiJian(Guid id, int status)
        {
            SingleResult<CgShenHe> singleResult = new SingleResult<CgShenHe>();
            try
            {
                if (_dbContext.CgJiLu.Any(x => x.CgId == id))
                {
                    var query_jilu = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == id);
                    var yijians = _mapper.Map<CgJiLuDto>(query_jilu);
                    yijians.cgShenHes.ForEach(x =>
                    {
                        if (x.Status == status)
                        {
                            singleResult.Result = x;
                        }
                    });
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
        /// 查询部门已审核的
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgJiLuDto> GetJiLuByBuMenShenHe(int skip, int take)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            var currentUser = _fapContext.CurrentUser;
            var bumen = OrgHelper.GetBuMenId(currentUser);
            try
            {
                var ids = _dbContext.CgShenHe.Where(x => x.Status == 2 && x.Status != -1).Select(p => p.CgId);
                var jilu = _dbContext.CgJiLu.Where(x => ids.Contains(x.CgId) && x.BumenId == bumen);
                var query = jilu.OrderByDescending(x => x.CreateDate);
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 查询初审人审核
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgJiLuDto> GetJiLuByChushenren(int skip, int take)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            var currentUser = _fapContext.CurrentUser;
            var bumen = OrgHelper.GetBuMenId(currentUser);
            try
            {
                var ids = _dbContext.CgShenHe.Where(x => x.Status == 1 && x.Status != -1).Select(p => p.CgId);
                var jilu = _dbContext.CgJiLu.Where(x => ids.Contains(x.CgId) && x.BumenId == bumen);
                var query = jilu.OrderByDescending(x => x.CreateDate);
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 查询科研处已审核的
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgJiLuDto> GetJiLuByKeYanChu(int skip, int take)
        {
            ListResult<CgJiLuDto> listResult = new ListResult<CgJiLuDto>();
            var currentUser = _fapContext.CurrentUser;
            var bumen = OrgHelper.GetBuMenId(currentUser);
            try
            {
                //var ids = _dbContext.CgShenHe.Where(x => x.Status == 3).Select(p => p.CgId);
                //var jilu = _dbContext.CgJiLu.Where(x => ids.Contains(x.CgId));
                //var query = jilu.OrderByDescending(x => x.CreateDate);
                var query = _dbContext.CgJiLu.OrderByDescending(x => x.CreateDate).Where(x => x.Status == 4 && x.IsKeYanChuShenHe == 1);
                listResult.Results = _mapper.Map<List<CgJiLuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SingleResult<CgJiLu> GetJiLuByid(Guid id)
        {
            SingleResult<CgJiLu> singleResult = new SingleResult<CgJiLu>();
            try
            {
                if (_dbContext.CgJiLu.Any(x => x.CgId == id))
                {
                    var query = _dbContext.CgJiLu.SingleOrDefault(x => x.CgId == id);
                    singleResult.Result = query;
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
        /// 查询每个人
        /// </summary>
        /// <returns></returns>
        public ListResult<CgJiLu> GetJilus(int skip, int take)
        {
            ListResult<CgJiLu> listResult = new ListResult<CgJiLu>();
            try
            {
                var query = _dbContext.CgJiLu.GroupBy(x => x.UserId).Select(x => x.First());
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
        /// 筛选
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="applyName"></param>
        /// <param name="bumen"></param>
        /// <returns></returns>
        public ListResult<CgJiLu> GetJilusByziduan(int skip, int take, string applyName, string bumen)
        {
            ListResult<CgJiLu> listResult = new ListResult<CgJiLu>();
            try
            {
                var query_jilu = _dbContext.CgJiLu.Where(x => x.Status != -1);
                if (!string.IsNullOrEmpty(applyName))
                {
                    query_jilu = query_jilu.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(bumen))
                {
                    query_jilu = query_jilu.Where(x => x.Bumen.Contains(bumen));
                }
                var query = query_jilu.GroupBy(x => x.UserId).Select(x => x.First()).Skip(skip).Take(take);
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
        /// 筛选 年度
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="applyName"></param>
        /// <param name="bumen"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public ListResult<CgNianDuKaoHeFen> GetNianDusByziduan(int skip, int take, string applyName, string bumen, string startTime, string endTime)
        {
            var time = DateTime.Now.Year;
            ListResult<CgNianDuKaoHeFen> listResult = new ListResult<CgNianDuKaoHeFen>();
            try
            {
                var query = _dbContext.CgNianDuKaoHeFen.Where(x => x.Status == 1);
                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(bumen))
                {
                    query = query.Where(x => x.BuMenMingCheng.Contains(bumen));
                }
                else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => int.Parse(x.NianDu) >= Convert.ToDateTime(startTime).Year);
                }
                else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => int.Parse(x.NianDu) <= Convert.ToDateTime(endTime).Year);
                }
                else if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => (int.Parse(x.NianDu) >= Convert.ToDateTime(startTime).Year) && (int.Parse(x.NianDu) <= Convert.ToDateTime(endTime).Year));
                }
                listResult.Results = query.Skip(skip).Take(take).ToList();
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
        /// 科研分
        /// </summary>
        /// <returns></returns>
        public SingleResult<bool> UpdateKeYanFen(Guid id,string niandu)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var time = DateTime.Now.Year;
            try
            {
                if (_dbContext.CgNianDuKaoHeFen.Any(x => x.UserId == id && x.NianDu == niandu))
                {
                    var query = _dbContext.CgNianDuKaoHeFen.SingleOrDefault(x => x.UserId == id && x.NianDu == niandu);
                    query.KeYanFen = Addkyf(id,niandu).ToString();
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
        /// 根据记录添加年度考核分
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveNianDu()
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var time = DateTime.Now.Year;
            var query_jilus = GetJilus(0, 1000).Results;
            var query_nd = _dbContext.CgJiLu.Where(x => x.Status != -1).GroupBy(x => x.SuoShuNianDu).ToList();
            List<CgNianDuKaoHeFen> lists = new List<CgNianDuKaoHeFen>();
            query_jilus.ForEach(x =>
            {
                query_nd.ForEach(p =>
                {
                    if (_dbContext.CgNianDuKaoHeFen.Any(y => y.UserId == x.UserId && y.NianDu ==p.Key))
                    {
                        UpdateKeYanFen(x.UserId.Value,p.Key);
                    }
                    else
                    {
                        CgNianDuKaoHeFen result = new CgNianDuKaoHeFen();
                        result.Id = Guid.NewGuid();
                        result.UserId = x.UserId.Value;
                        result.UserName = x.UserName;
                        result.BuMenId = x.BumenId.Value;
                        result.BuMenMingCheng = x.Bumen;
                        result.ZhuanJiZhiWu = x.ZhuanJiZhiWu.ToString();
                        result.JiaoGuanZhiWu = x.JiaoGuanZhiWu.ToString();
                        result.NianDu = p.Key;
                        result.Status = 1;
                        result.CreateDate = result.LastUpdateDate = DateTime.Now;
                        lists.Add(result);
                    }

                });
            });
            if (lists != null&&lists.Count>0)
            {
                _dbContext.CgNianDuKaoHeFen.AddRange(lists);
            }
            singleResult.Result = _dbContext.SaveChanges() > 0;
            return singleResult;
        }

        /// <summary>
        /// 编辑 年度考核分
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> UpdateNianDu(CgNianDuKaoHeFen entity)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.CgNianDuKaoHeFen.Any(x => x.Id == entity.Id))
                {
                    var query = _dbContext.CgNianDuKaoHeFen.SingleOrDefault(x => x.Id == entity.Id);
                    query.KaoHeFen = entity.KaoHeFen;
                    query.KeYanFen = entity.KeYanFen;
                    query.LastUpdateDate = DateTime.Now;
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
        /// 获取本年 年度考核详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<CgNianDuKaoHeFen> GetNianDuById(Guid id)
        {
            SingleResult<CgNianDuKaoHeFen> singleResult = new SingleResult<CgNianDuKaoHeFen>();
            try
            {
                if (_dbContext.CgNianDuKaoHeFen.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgNianDuKaoHeFen.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = query;
                }
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误", ex);
            }
            return singleResult;
        }

        /// <summary>
        /// 获取年度考核表
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgNianDuKaoHeFen> GetNianDus(int skip, int take)
        {
            ListResult<CgNianDuKaoHeFen> listResult = new ListResult<CgNianDuKaoHeFen>();
            var time = DateTime.Now.Year;
            try
            {
                var query = _dbContext.CgNianDuKaoHeFen.Where(x => x.NianDu == (time-1).ToString());
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
        /// 获取科研项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgKeYanXiangMuDto> Getcgky(Guid id)
        {
            ListResult<CgKeYanXiangMuDto> listResult = new ListResult<CgKeYanXiangMuDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgKeYanXiangMu.Where(x => query_ids.Contains(x.Id));
                listResult.Results = _mapper.Map<List<CgKeYanXiangMuDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取科研项目 带年度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nianDu"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgKeYanXiangMuDto> Getcgkybyniandu(Guid id, string nianDu)
        {
            ListResult<CgKeYanXiangMuDto> listResult = new ListResult<CgKeYanXiangMuDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgKeYanXiangMu.Where(x => query_ids.Contains(x.Id) && x.SuoShuNianDu == nianDu);
                // x.LiXiangShiJian.Value.Year >= int.Parse(nianDu) && x.JiHuaWanChengShiJian.Value.Year <= int.Parse(nianDu)
                listResult.Results = _mapper.Map<List<CgKeYanXiangMuDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取著作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgZhuZuoDto> Getcgzz(Guid id)
        {
            ListResult<CgZhuZuoDto> listResult = new ListResult<CgZhuZuoDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgZuZhuo.Where(x => query_ids.Contains(x.Id));
                listResult.Results = _mapper.Map<List<CgZhuZuoDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取著作 带年度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nianDu"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgZhuZuoDto> Getcgzzbyniandu(Guid id, string nianDu)
        {
            ListResult<CgZhuZuoDto> listResult = new ListResult<CgZhuZuoDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgZuZhuo.Where(x => query_ids.Contains(x.Id) && x.SuoShuNianDu == nianDu);
                //x.ChuBanShiJian.Value.Year == int.Parse(nianDu)

                listResult.Results = _mapper.Map<List<CgZhuZuoDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取教材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgJiaoCaiDto> Getcgjc(Guid id)
        {
            ListResult<CgJiaoCaiDto> listResult = new ListResult<CgJiaoCaiDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgJiaoCai.Where(x => query_ids.Contains(x.Id));
                listResult.Results = _mapper.Map<List<CgJiaoCaiDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取教材 带年度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nianDu"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<CgJiaoCaiDto> Getcgjcbyniandu(Guid id, string nianDu)
        {
            ListResult<CgJiaoCaiDto> listResult = new ListResult<CgJiaoCaiDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgJiaoCai.Where(x => query_ids.Contains(x.Id) && x.SuoShuNianDu == nianDu);
                // x.ChuBanShiJian.Value.Year == int.Parse(nianDu)
                listResult.Results = _mapper.Map<List<CgJiaoCaiDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取论文
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<Cg_LunWenDto> Getcglw(Guid id)
        {
            ListResult<Cg_LunWenDto> listResult = new ListResult<Cg_LunWenDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgLunWen.Where(x => query_ids.Contains(x.Id));
                listResult.Results = _mapper.Map<List<Cg_LunWenDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取论文 带年度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nianDu"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<Cg_LunWenDto> Getcglwbyniandu(Guid id, string nianDu)
        {
            ListResult<Cg_LunWenDto> listResult = new ListResult<Cg_LunWenDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgLunWen.Where(x => query_ids.Contains(x.Id) && x.SuoShuNianDu == nianDu);
                // x.FaBiaoNianDu.Value.Year == int.Parse(nianDu)
                listResult.Results = _mapper.Map<List<Cg_LunWenDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取软件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<Cg_RuanJianDto> Getcgrj(Guid id)
        {
            ListResult<Cg_RuanJianDto> listResult = new ListResult<Cg_RuanJianDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgRuanJianYuZhuanLi.Where(x => query_ids.Contains(x.Id));
                listResult.Results = _mapper.Map<List<Cg_RuanJianDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取软件 带年度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nianDu"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<Cg_RuanJianDto> Getcgrjbyniandu(Guid id, string nianDu)
        {
            ListResult<Cg_RuanJianDto> listResult = new ListResult<Cg_RuanJianDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgRuanJianYuZhuanLi.Where(x => query_ids.Contains(x.Id) && x.SuoShuNianDu == nianDu);
                listResult.Results = _mapper.Map<List<Cg_RuanJianDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取其他
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<Cg_QitaDto> Getcgqt(Guid id)
        {
            ListResult<Cg_QitaDto> listResult = new ListResult<Cg_QitaDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgQiTa.Where(x => query_ids.Contains(x.Id));
                listResult.Results = _mapper.Map<List<Cg_QitaDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取其他
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nianDu"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public ListResult<Cg_QitaDto> Getcgqtbyniandu(Guid id, string nianDu)
        {
            ListResult<Cg_QitaDto> listResult = new ListResult<Cg_QitaDto>();
            var time = DateTime.Now.Year;
            try
            {
                var query_ids = _dbContext.CgJiLu.Where(x => x.UserId == id && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgQiTa.Where(x => query_ids.Contains(x.Id) && x.SuoShuNianDu == nianDu);
                listResult.Results = _mapper.Map<List<Cg_QitaDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 计算科研分
        /// </summary>
        /// <param name="id"></param>
        /// <param name="niandu"></param>
        /// <returns></returns>
        public double Addkyf(Guid id,string niandu)
        {
            double num = 0;
            //var nian = DateTime.Now.Year;
            var query_ky = Getcgkybyniandu(id, niandu);
            var query_zz = Getcgzzbyniandu(id, niandu);
            var query_jc = Getcgjcbyniandu(id, niandu);
            var query_lw = Getcglwbyniandu(id, niandu);
            var query_rj = Getcgrjbyniandu(id, niandu);
            var query_qt = Getcgqtbyniandu(id, niandu);
            //科研项目
            if (query_ky != null && query_ky.Results.Count > 0)
            {
                query_ky.Results.ForEach(x =>
                {
                    if (x.ShenHeJiaKouFen != null)
                    {
                        num += Convert.ToDouble(x.ShenHeJiaKouFen);
                    }
                });
            }
            //著作
            if (query_zz != null && query_zz.Results.Count > 0)
            {
                query_zz.Results.ForEach(x =>
                {
                    if (x.ShenHeJiaKouFen != null)
                    {
                        num += Convert.ToDouble(x.ShenHeJiaKouFen);
                    }
                });
            }
            //教材
            if (query_jc != null && query_jc.Results.Count > 0)
            {
                query_jc.Results.ForEach(x =>
                {
                    if (x.ShenHeJiaKouFen != null)
                    {
                        num += Convert.ToDouble(x.ShenHeJiaKouFen);
                    }
                });
            }
            //论文
            if (query_lw != null && query_lw.Results.Count > 0)
            {
                query_lw.Results.ForEach(x =>
                {
                    if (x.ShenHeJiaKouFen != null)
                    {
                        num += Convert.ToDouble(x.ShenHeJiaKouFen);
                    }
                });
            }
            //软件
            if (query_rj != null && query_rj.Results.Count > 0)
            {
                query_rj.Results.ForEach(x =>
                {
                    if (x.ShenHeJiaKouFen != null)
                    {
                        num += Convert.ToDouble(x.ShenHeJiaKouFen);
                    }
                });
            }
            //其他
            if (query_qt != null && query_qt.Results.Count > 0)
            {
                query_qt.Results.ForEach(x =>
                {
                    if (x.ShenHeJiaKouFen != null)
                    {
                        num += Convert.ToDouble(x.ShenHeJiaKouFen);
                    }
                });
            }
            return num;
        }

    }
}