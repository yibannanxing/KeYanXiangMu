using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FAP.Client;
using FAP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;

namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class XiangMuZuYuanController : KeYanControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fapContext"></param>
        /// <param name="organizationService"></param>
        /// <param name="privilegeService"></param>
        /// <param name="messageService"></param>
        /// <param name="loggerService"></param>
        /// <param name="dbContext"></param>
        /// <param name="httpContext"></param>
        /// <param name="memoryCache"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public XiangMuZuYuanController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<XiangMuZuYuanController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 删除组员
        /// </summary>
        /// <param name="zuyuanId"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> DelZuYuan(Guid zuyuanId)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuZuYuanService.DelZuYuan(zuyuanId);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="zuyuan"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> UpdateZuYuan(XiangMuZuYuan zuyuan)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuZuYuanService.SaveZuYuan(zuyuan);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 获取当前项目下的组员
        /// </summary>
        /// <param name="XiangMuId"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuZuYuan> GetZuYuanByIds(Guid XiangMuId)
        {
            ListResult<XiangMuZuYuan> listResult = new ListResult<XiangMuZuYuan>();
            try
            {
                listResult.Results = _xiangMuZuYuanService.GetZuYuan(XiangMuId);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 编辑组员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<XiangMuZuYuan> GetZuYuanById(Guid id)
        {
            SingleResult<XiangMuZuYuan> singleResult = new SingleResult<XiangMuZuYuan>();
            try
            {
                if (_dbContext.XiangMuZuYuan.Any(x => x.Id == id))
                {
                    singleResult.Result = _dbContext.XiangMuZuYuan.SingleOrDefault(x => x.Id == id);
                }
                else
                {
                    singleResult.Result = new XiangMuZuYuan { Id = Guid.NewGuid() };
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
        /// 保存组员
        /// </summary>
        /// <param name="xmzy"></param>
        /// <param name="xiangmuId"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> SaveZuYuan(XiangMuZuYuan xmzy, Guid xiangmuId)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuService.SaveXiangMuZuYuan(xmzy, xiangmuId);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        ///测试保存
        /// </summary>
        /// <param name="xiangmuzuyuan"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> SaveZuYuan1(XiangMuZuYuan xiangmuzuyuan)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (xiangmuzuyuan.Id == Guid.Empty)
                {
                    xiangmuzuyuan.Id = Guid.NewGuid();
                    xiangmuzuyuan.CreateDate = xiangmuzuyuan.LastUpdateDate = DateTime.Now;
                    _dbContext.XiangMuZuYuan.Add(xiangmuzuyuan);
                }
                else
                {
                    var single = _dbContext.XiangMuZuYuan.SingleOrDefault(x => x.Id == xiangmuzuyuan.Id);
                    single.XiangMuId = xiangmuzuyuan.XiangMuId;
                    single.XiangMuZuChengYuanId = xiangmuzuyuan.XiangMuZuChengYuanId;
                    single.XiangMuZuChengYuanXingMing = xiangmuzuyuan.XiangMuZuChengYuanXingMing;
                    single.XingBie = xiangmuzuyuan.XingBie;
                    single.ChuShengNianYue = xiangmuzuyuan.ChuShengNianYue;
                    single.ZhiWuMingCheng = xiangmuzuyuan.ZhiWuMingCheng;
                    single.YanJiuZhuanChang = xiangmuzuyuan.YanJiuZhuanChang;
                    single.XueLi = xiangmuzuyuan.XueLi;
                    single.SuoSuBuMenId = xiangmuzuyuan.SuoSuBuMenId;
                    single.SuoSuBuMenMingCheng = xiangmuzuyuan.SuoSuBuMenMingCheng;
                    single.CreateDate = xiangmuzuyuan.CreateDate;
                    //  _mapper.Map(single,xiangmuzuyuan,typeof(XiangMuZuYuan), typeof(XiangMuZuYuan));
                    single.LastUpdateDate = DateTime.Now;
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
        /// <returns></returns>
        [HttpGet]
        public SingleResult<XiangMuZuYuan> GetZuYuanBynull()
        {
            SingleResult<XiangMuZuYuan> singleResult = new SingleResult<XiangMuZuYuan>();
            try
            {
                singleResult.Result = new XiangMuZuYuan();

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