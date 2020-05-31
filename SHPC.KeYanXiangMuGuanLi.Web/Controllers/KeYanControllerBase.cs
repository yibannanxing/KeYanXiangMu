using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FAP.Client;
using FAP.Client.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using SHPC.KeYanXiangMuGuanLi.Engine.Services;

namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class KeYanControllerBase : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly FAPContext _fapContext;
        /// <summary>
        /// 
        /// </summary>
        public readonly IConfiguration _configuration;
        /// <summary>
        /// 
        /// </summary>
        public readonly FAP.Client.Service.OrganizationService _organizationService = null;
        /// <summary>
        /// 
        /// </summary>
        public readonly FAP.Client.Service.PrivilegeService _privilegeService = null;
        /// <summary>
        /// 
        /// </summary>
        public readonly FAP.Client.Service.MessageService _messageService = null;
        /// <summary>
        /// 
        /// </summary>
        public readonly FAP.Client.Service.LoggerService _loggerService = null;
        /// <summary>
        /// 
        /// </summary>
        public readonly IHttpContextAccessor _httpContext = null;
        /// <summary>
        /// 
        /// </summary>
        public readonly IMemoryCache _memoryCache;
        /// <summary>
        /// 
        /// </summary>
        public readonly IMapper _mapper = null;
        /// <summary>
        /// 
        /// </summary>
        public readonly KeYanGuanLiContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        public readonly XiangMuChengGuoService _xiangMuChengGuoService;
        /// <summary>
        /// 
        /// </summary>
        public readonly JingFeiService _jingFeiService;
        /// <summary>
        /// 
        /// </summary>
        public readonly XiangMuFangAnService _xiangMuFangAnService;
        /// <summary>
        /// 
        /// </summary>
        public readonly XiangMuService _xiangMuService;
        /// <summary>
        /// 
        /// </summary>
        public readonly XiangMuZuYuanService _xiangMuZuYuanService;
        /// <summary>
        /// 
        /// </summary>
        private FAPContext fapContext;
        /// <summary>
        /// 
        /// </summary>
        private OrganizationService organizationService;
        /// <summary>
        /// 
        /// </summary>
        private PrivilegeService privilegeService;
        /// <summary>
        /// 
        /// </summary>
        private MessageService messageService;
        /// <summary>
        /// 
        /// </summary>
        private LoggerService loggerService;
        /// <summary>
        /// 
        /// </summary>
        private KeYanGuanLiContext dbContext;
        /// <summary>
        /// 
        /// </summary>
        private IConfiguration configuration;
        /// <summary>
        /// 
        /// </summary>
        private ILogger<XiangMuController> logger;
        /// <summary>
        /// 
        /// </summary>
        private IMapper mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fapContext"></param>
        /// <param name="organizationService"></param>
        /// <param name="privilegeService"></param>
        /// <param name="messageService"></param>
        /// <param name="loggerService"></param>
        /// <param name="dbContext"></param>
        /// <param name="configuration"></param>
        /// <param name="httpContext"></param>
        /// <param name="memoryCache"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public KeYanControllerBase(
            FAPContext fapContext,
            FAP.Client.Service.OrganizationService organizationService,
            FAP.Client.Service.PrivilegeService privilegeService,
            FAP.Client.Service.MessageService messageService,
            FAP.Client.Service.LoggerService loggerService,
            KeYanGuanLiContext dbContext,
            IConfiguration configuration,
            IHttpContextAccessor httpContext,
            IMemoryCache memoryCache,
            ILogger logger,
            IMapper mapper)
        {
            _fapContext = fapContext;
            _configuration = configuration;
            _organizationService = organizationService;
            _privilegeService = privilegeService;
            _messageService = messageService;
            _loggerService = loggerService;
            _httpContext = httpContext;
            _memoryCache = memoryCache;
            _mapper = mapper;
            _dbContext = dbContext;
            _xiangMuChengGuoService = new XiangMuChengGuoService(dbContext);
            _jingFeiService = new JingFeiService(dbContext);
            _xiangMuFangAnService = new XiangMuFangAnService(dbContext);
            _xiangMuService = new XiangMuService(dbContext);
            _xiangMuZuYuanService = new XiangMuZuYuanService(dbContext);
            //_fapContext.CurrentUser.PrivilegeIds
        }
    }
}