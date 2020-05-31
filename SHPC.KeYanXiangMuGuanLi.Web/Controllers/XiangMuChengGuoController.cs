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
    public class XiangMuChengGuoController : KeYanControllerBase
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
        public XiangMuChengGuoController(
          FAPContext fapContext,
        FAP.Client.Service.OrganizationService organizationService,
        FAP.Client.Service.PrivilegeService privilegeService,
        FAP.Client.Service.MessageService messageService,
        FAP.Client.Service.LoggerService loggerService,
        KeYanGuanLiContext dbContext,
        IHttpContextAccessor httpContext,
        IMemoryCache memoryCache,
        IConfiguration configuration,
        ILogger<XiangMuChengGuoController> logger,
        IMapper mapper)
        : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 获取这个项目下的成果附件
        /// </summary>
        /// <param name="ChengGuoID"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuChengGuo> GetXiangMuById(Guid ChengGuoID)
        {
            ListResult<XiangMuChengGuo> listResult = new ListResult<XiangMuChengGuo>();
            try
            {
                listResult.Results = _xiangMuChengGuoService.GetChengGuo(ChengGuoID);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 总览成果
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuChengGuoDto> GetXiangMuChengGuos(int skip,int take,int zhuangtai)
        {                                                          
            ListResult<XiangMuChengGuoDto> listResult = new ListResult<XiangMuChengGuoDto>();
            try
            {
                listResult.Results = _mapper.Map<List<XiangMuChengGuoDto>>(_dbContext.XiangMuChengGuo.Where(x => x.Stadus == zhuangtai).OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
                listResult.TotalRows = _dbContext.XiangMuChengGuo.Where(x => x.Stadus == zhuangtai).Count();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取当前登录人的成果
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuChengGuoDto> GetXiangMuChengGuoByUser()
        {
            ListResult<XiangMuChengGuoDto> listResult = new ListResult<XiangMuChengGuoDto>();
            var currentUser = _fapContext.CurrentUser;
            try
            {
                var lists = _dbContext.XiangMuChengGuo.Where(x => x.ZuoZeId == currentUser.Id).OrderByDescending(x=>x.CreateDate);
                listResult.Results = _mapper.Map<List<XiangMuChengGuoDto>>(lists);
                listResult.TotalRows = lists.Count();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }

        /// <summary>
        /// 成果上传
        /// </summary>
        /// <param name="chengGuoRequest_Bag"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> AddXiangMuChengGuo(ChengGuoRequest_Bag chengGuoRequest_Bag)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var chengguo = chengGuoRequest_Bag.xiangMuChengGuo;
            var fengmianList = chengGuoRequest_Bag.fengmianList;
            var fileList = chengGuoRequest_Bag.fileList;
            var articleList = chengGuoRequest_Bag.articleList;
            var wenjianList = chengGuoRequest_Bag.wenjianList;
            var cUser = _fapContext.CurrentUser;
            if (fengmianList!=null&& fileList!=null&& articleList!=null)
            {
                wenjianList = null;
            }

            try
            {
                if (chengguo.Id == Guid.Empty)
                {
                    chengguo.Id = Guid.NewGuid();
                    chengguo.BuMenId = OrgHelper.GetBuMenId(cUser);
                    chengguo.BuMenMingCheng = OrgHelper.GetBuMenMingCheng(cUser);
                    chengguo.ZuoZeId = cUser.Id;
                    chengguo.PaiXu = 1;
                    chengguo.Stadus = 0;
                    chengguo.CreateDate = chengguo.LastUpdateDate = DateTime.Now;
                    _dbContext.XiangMuChengGuo.Add(chengguo);

                    if (chengguo.ChengGuoLeiXing == 0|| chengguo.ChengGuoLeiXing == 1|| chengguo.ChengGuoLeiXing == 2)
                    {   //期刊封面
                        if (fengmianList != null)
                        {
                            fengmianList.ForEach(x =>
                            {
                                if (_dbContext.FuJian.Any(p => p.ChengGuoId == chengguo.Id))
                                {
                                    var single = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                    single.WenJianLeiXing = x.WenJianLeiXing;
                                    single.WenJianMingCheng = x.WenJianMingCheng;
                                    single.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                    single.LuJing = x.LuJing;
                                    single.LastUpdateTime = x.LastUpdateTime;
                                }
                                else
                                {
                                    x.ChengGuoId = chengguo.Id;
                                    x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊封面;
                                    x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                    _dbContext.FuJian.Add(x);
                                }
                            });
                        }
                        //期刊目录
                        if (fileList != null)
                        {
                            fileList.ForEach(x =>
                            {
                                if (_dbContext.FuJian.Any(p => p.ChengGuoId == chengguo.Id))
                                {
                                    var single = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                    single.WenJianLeiXing = x.WenJianLeiXing;
                                    single.WenJianMingCheng = x.WenJianMingCheng;
                                    single.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                    single.LuJing = x.LuJing;
                                    single.LastUpdateTime = x.LastUpdateTime;
                                }
                                else
                                {
                                    x.ChengGuoId = chengguo.Id;
                                    x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊目录;
                                    x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                    _dbContext.FuJian.Add(x);
                                }
                            });
                        }
                        //上传文章页面
                        if (articleList != null)
                        {
                            articleList.ForEach(x =>
                            {
                                if (_dbContext.FuJian.Any(p => p.ChengGuoId == chengguo.Id))
                                {
                                    var single = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                    single.WenJianLeiXing = x.WenJianLeiXing;
                                    single.WenJianMingCheng = x.WenJianMingCheng;
                                    single.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                    single.LuJing = x.LuJing;
                                    single.LastUpdateTime = x.LastUpdateTime;
                                }
                                else
                                {
                                    x.ChengGuoId = chengguo.Id;
                                    x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文章页面;
                                    x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                    _dbContext.FuJian.Add(x);
                                }

                            });
                        }
                    }
                    else
                    {
                        //上传附件
                        if (wenjianList != null)
                        {
                            wenjianList.ForEach(x =>
                            {
                                if (_dbContext.FuJian.Any(p => p.ChengGuoId == chengguo.Id))
                                {
                                    var single = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                    single.WenJianLeiXing = x.WenJianLeiXing;
                                    single.WenJianMingCheng = x.WenJianMingCheng;
                                    single.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                    single.LuJing = x.LuJing;
                                    single.LastUpdateTime = x.LastUpdateTime;
                                }
                                else
                                {
                                    x.ChengGuoId = chengguo.Id;
                                    x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                                    x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                    _dbContext.FuJian.Add(x);
                                }
                            });
                        }
                    }





                }
                else
                {
                    if (_dbContext.XiangMuChengGuo.Any(x => x.Id == chengguo.Id))
                    {
                        var single = _dbContext.XiangMuChengGuo.SingleOrDefault(x => x.Id == chengguo.Id);
                        single.ZuoZeId = chengguo.ZuoZeId;
                        single.ZuoZeMingCheng = chengguo.ZuoZeMingCheng;
                        single.BuMenId = chengguo.BuMenId;
                        single.BuMenMingCheng = chengguo.BuMenMingCheng;
                        single.ChengGuoMingCheng = chengguo.ChengGuoMingCheng;
                        single.ChengGuoLeiXing = chengguo.ChengGuoLeiXing;
                        single.NianQi = chengguo.NianQi;
                        single.PaiXu = chengguo.PaiXu;
                        single.Stadus = chengguo.Stadus;
                        single.LastUpdateDate = chengguo.LastUpdateDate;

                        if (chengguo.ChengGuoLeiXing == 0 || chengguo.ChengGuoLeiXing == 1 || chengguo.ChengGuoLeiXing == 2)
                        {

                            //期刊封面
                            if (fengmianList != null)
                            {
                                fengmianList.ForEach(x =>
                                {
                                    if (_dbContext.FuJian.Any(p => p.Id == x.Id))
                                    {
                                        var singlefengmian = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                        singlefengmian.WenJianLeiXing = x.WenJianLeiXing;
                                        singlefengmian.WenJianMingCheng = x.WenJianMingCheng;
                                        singlefengmian.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                        singlefengmian.LuJing = x.LuJing;
                                        singlefengmian.LastUpdateTime = x.LastUpdateTime;
                                    }
                                    else
                                    {
                                        x.ChengGuoId = chengguo.Id;
                                        x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊封面;
                                        x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                        _dbContext.FuJian.Add(x);
                                    }
                                });
                            }

                            //期刊目录
                            if (fileList != null)
                            {
                                fileList.ForEach(x =>
                                {
                                    if (_dbContext.FuJian.Any(p => p.Id == x.Id))
                                    {
                                        var singlemulu = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                        singlemulu.WenJianLeiXing = x.WenJianLeiXing;
                                        singlemulu.WenJianMingCheng = x.WenJianMingCheng;
                                        singlemulu.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                        singlemulu.LuJing = x.LuJing;
                                        singlemulu.LastUpdateTime = x.LastUpdateTime;
                                    }
                                    else
                                    {
                                        x.ChengGuoId = chengguo.Id;
                                        x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.期刊目录;
                                        x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                        _dbContext.FuJian.Add(x);
                                    }
                                });
                            }

                            //上传文章页面
                            if (articleList != null)
                            {
                                articleList.ForEach(x =>
                                {
                                    if (_dbContext.FuJian.Any(p => p.Id == x.Id))
                                    {
                                        var singlewenzhang = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                        singlewenzhang.WenJianLeiXing = x.WenJianLeiXing;
                                        singlewenzhang.WenJianMingCheng = x.WenJianMingCheng;
                                        singlewenzhang.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                        singlewenzhang.LuJing = x.LuJing;
                                        singlewenzhang.LastUpdateTime = x.LastUpdateTime;
                                    }
                                    else
                                    {
                                        x.ChengGuoId = chengguo.Id;
                                        x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文章页面;
                                        x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                        _dbContext.FuJian.Add(x);
                                    }

                                });
                            }



                        }
                        else
                        {
                            //上传附件
                            if (wenjianList != null)
                            {
                                wenjianList.ForEach(x =>
                                {
                                    if (_dbContext.FuJian.Any(p => p.Id == x.Id))
                                    {
                                        var singlefujian = _dbContext.FuJian.SingleOrDefault(d => d.Id == x.Id);
                                        singlefujian.WenJianLeiXing = x.WenJianLeiXing;
                                        singlefujian.WenJianMingCheng = x.WenJianMingCheng;
                                        singlefujian.FuWuQiWenJianMingCheng = x.FuWuQiWenJianMingCheng;
                                        singlefujian.LuJing = x.LuJing;
                                        singlefujian.LastUpdateTime = x.LastUpdateTime;
                                    }
                                    else
                                    {
                                        x.ChengGuoId = chengguo.Id;
                                        x.WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                                        x.CreateDateTime = x.LastUpdateTime = DateTime.Now;
                                        _dbContext.FuJian.Add(x);
                                    }
                                });
                            }

                        }




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
        /// 详情
        /// </summary>
        /// <param name="ChengGuoID"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<XiangMuChengGuoDto> GetXiangMuChengGuoById(Guid ChengGuoID)
        {
            SingleResult<XiangMuChengGuoDto> singleResult = new SingleResult<XiangMuChengGuoDto>();
            try
            {
                if (_dbContext.XiangMuChengGuo.Any(x => x.Id == ChengGuoID))
                {
                    var single = _dbContext.XiangMuChengGuo.SingleOrDefault(x => x.Id == ChengGuoID);
                    if (single == null)
                    {
                        singleResult.Result = new XiangMuChengGuoDto();
                    }
                    singleResult.Result = _mapper.Map<XiangMuChengGuoDto>(single);
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
        /// 真删
        /// </summary>
        /// <param name="ChengGuoID"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<bool> DelXiangMuChengGuo(Guid ChengGuoID)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.XiangMuChengGuo.Any(x => x.Id == ChengGuoID))
                {
                    var single = _dbContext.XiangMuChengGuo.SingleOrDefault(x => x.Id == ChengGuoID);
                    _dbContext.XiangMuChengGuo.Remove(single);
                    singleResult.Result = _dbContext.SaveChanges() > 0;
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
        /// 审核
        /// </summary>
        /// <param name="cgId"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<bool> UpdateXiangMuChengGuo(Guid cgId)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.XiangMuChengGuo.Any(x => x.Id == cgId))
                {
                    var single = _dbContext.XiangMuChengGuo.SingleOrDefault(x => x.Id == cgId);
                    single.Stadus = 1;
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

    }
}