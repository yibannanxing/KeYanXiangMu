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
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class JingFeiController : KeYanControllerBase
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
        public JingFeiController(
            FAPContext fapContext,
          FAP.Client.Service.OrganizationService organizationService,
          FAP.Client.Service.PrivilegeService privilegeService,
          FAP.Client.Service.MessageService messageService,
          FAP.Client.Service.LoggerService loggerService,
          KeYanGuanLiContext dbContext,
          IHttpContextAccessor httpContext,
          IMemoryCache memoryCache,
          IConfiguration configuration,
          ILogger<JingFeiController> logger,
          IMapper mapper)
          : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 删除经费
        /// </summary>
        /// <param name="jingfeiid"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> DelJingFei(Guid jingfeiid) {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _jingFeiService.DelJingFei(jingfeiid);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 编辑经费
        /// </summary>
        /// <param name="jingfei"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> UpdateJingFei(JingFei jingfei)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _jingFeiService.SaveJinFei(jingfei);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 获取当前项目下的经费列表(排序)
        /// </summary>
        /// <param name="XiangMuId"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<JingFei> GetJingFeisByXiangMuIds(Guid XiangMuId) {
            ListResult<JingFei> listResult = new ListResult<JingFei>();
            try
            {
                listResult.Results = _jingFeiService.JingFeiPaiXu(XiangMuId);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 保存经费
        /// </summary>
        /// <param name="jf"></param>
        /// <param name="xiangmuId"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> SaveJingFei(JingFei jf, Guid xiangmuId)
        {
            string id = "00000000-0000-0000-0000-000000000000";
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuService.SaveJingFei(jf,Guid.Parse(id));
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
        /// <param name="JingFeiId"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<JingFei> GetJingFeisByJingFeiId(Guid JingFeiId)
        {
            SingleResult<JingFei> singleResult = new SingleResult<JingFei>();
            try
            {
                if (_dbContext.JingFei.Any(X=>X.Id==JingFeiId))
                {
                    singleResult.Result = _dbContext.JingFei.SingleOrDefault(x=>x.Id==JingFeiId);
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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<JingFei> GetJingFeisBynull()
        {
            SingleResult<JingFei> singleResult = new SingleResult<JingFei>();
            try
            {
                singleResult.Result = new JingFei();

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