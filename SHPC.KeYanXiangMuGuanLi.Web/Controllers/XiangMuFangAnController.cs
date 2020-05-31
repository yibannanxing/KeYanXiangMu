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
    public class XiangMuFangAnController : KeYanControllerBase
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
        public XiangMuFangAnController(
             FAPContext fapContext,
           FAP.Client.Service.OrganizationService organizationService,
           FAP.Client.Service.PrivilegeService privilegeService,
           FAP.Client.Service.MessageService messageService,
           FAP.Client.Service.LoggerService loggerService,
           KeYanGuanLiContext dbContext,
           IHttpContextAccessor httpContext,
           IMemoryCache memoryCache,
           IConfiguration configuration,
           ILogger<XiangMuFangAnController> logger,
           IMapper mapper)
           : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 删除当前方案
        /// </summary>
        /// <param name="fananid"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> DelFangAn(Guid fananid) {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuFangAnService.DelFangan(fananid);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 编辑方案
        /// </summary>
        /// <param name="FangAn"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> UpdateFangAn(XiangMuFangAn FangAn) {

            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuFangAnService.SaveFangAn(FangAn);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 获取当前项目下的方案
        /// </summary>
        /// <param name="fanganid"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuFangAn> GetFangAn(Guid fanganid) {
            ListResult<XiangMuFangAn> listResult = new ListResult<XiangMuFangAn>();
            try
            {
                //listResult.Results = _xiangMuFangAnService.GetFangAn(fanganid);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }

    }
}