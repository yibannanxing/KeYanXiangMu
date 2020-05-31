using System;
using System.Collections.Generic;
using System.IO;
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
using SHPC.KeYanXiangMuGuanLi.Web.Controllers;


namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [RequestSizeLimit(100_000_000)]
    public class UploadController : KeYanControllerBase
    {
        public UploadController(
            FAPContext fapContext,
          FAP.Client.Service.OrganizationService organizationService,
          FAP.Client.Service.PrivilegeService privilegeService,
          FAP.Client.Service.MessageService messageService,
          FAP.Client.Service.LoggerService loggerService,
          KeYanGuanLiContext dbContext,
          IHttpContextAccessor httpContext,
          IMemoryCache memoryCache,
          IConfiguration configuration,
          ILogger<UploadController> logger,
          IMapper mapper)
          : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet,HttpPost]
        [DisableRequestSizeLimit]
        public SingleResult<FuJian> UploadFile()
        {
            SingleResult<FuJian> result = new SingleResult<FuJian>();
            var CurrentUser = _fapContext.CurrentUser;
            try
            {
                if (Request.Form.Files.Count > 0)
                {
                    var type = Request.Query["type"][0];
                    var id = Guid.NewGuid();
                    var file = Request.Form.Files[0];
                    var localFileName = file.FileName;
                    var serverFileName = string.Format("{0}{1}", id.ToString("N"),
                        file.FileName.Substring(file.FileName.LastIndexOf('.')));
                    var filePath = string.Format("{0}/{1}", CurrentDir, serverFileName);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fs);
                    }
                    result.Result = new FuJian
                    {
                        //项目编号
                        Id = id,
                        WenJianLeiXing = int.Parse(type),
                        WenJianMingCheng = localFileName,
                        FuWuQiWenJianMingCheng = serverFileName,
                        LuJing = filePath.Replace("wwwroot/", "")
                    };
                }
                else
                    throw new Exception("上传异常");

            }
            catch (Exception ex)
            {
                _loggerService.LogException(CurrentUser, CurrentUser.SignInAccountId,
                    CurrentUser.SignInAccountName, ex);
                result.Error = new Error("系统错误", ex);
            }
            return result;
        }
        /// <summary>
        /// 删除上传附件（真删）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<bool> DelFile()
        {
            SingleResult<bool> result = new SingleResult<bool>();
            var CurrentUser = _fapContext.CurrentUser;
            try
            {
                var filePath = Request.Query["filePath"][0];
                if (Guid.TryParse(Request.Query["fileId"][0], out Guid fileId))
                {
                    if (_dbContext.FuJian.Any(p => p.Id == fileId))
                    {
                        _dbContext.FuJian.Remove(_dbContext.FuJian.Find(fileId));
                        _dbContext.SaveChanges();
                    }

                }
                var removePath = string.Format("wwwroot/{0}", filePath);
                if (System.IO.File.Exists(string.Format("wwwroot/{0}", filePath)))
                    System.IO.File.Delete(removePath);
            }
            catch (Exception ex)
            {
                _loggerService.LogException(CurrentUser, CurrentUser.SignInAccountId,
                    CurrentUser.SignInAccountName, ex);
                result.Error = new Error("系统错误", ex);
            }
            return result;
        }

        private string CurrentDir
        {
            get
            {
                var rootDir = "wwwroot/uploads";
                var existDir = string.Format("{0}/{1}", rootDir,
                    DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "/"));
                if (!Directory.Exists(existDir))
                    Directory.CreateDirectory(existDir);
                return existDir;
            }
        }
        public class UploadFileInfo
        {
            public Guid Id { get; set; }
            public int Type { get; set; }
            public string LocalFileName { get; set; }
            public string ServerFileName { get; set; }
            public string FilePath { get; set; }
        }
    }
}