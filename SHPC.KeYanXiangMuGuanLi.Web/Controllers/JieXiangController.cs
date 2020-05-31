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
using SHPC.KeYanXiangMuGuanLi.Engine.DTOs;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using SHPC.KeYanXiangMuGuanLi.Web.Utils;

namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class JieXiangController : KeYanControllerBase
    {
        public JieXiangController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<JieXiangController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 根据立项查找结项项目
        /// </summary>
        /// <param name="id">立项id</param>
        /// <returns></returns>
        public SingleResult<JieXiang> GetJieXiang(Guid id)
        {
            SingleResult<JieXiang> singleResult = new SingleResult<JieXiang>();
            try
            {
                if (_dbContext.XiangMu.Any(x => x.Id == id))
                {
                    var query_lx = _mapper.Map<XiangMuDto>(_dbContext.XiangMu.SingleOrDefault(x => x.Id == id));
                    var lxzys = query_lx.XiangMuZuYuans;
                    var lxjfs = query_lx.JingFeis;

                    JieXiang jieXiang = new JieXiang();
                    jieXiang.FuZeRenMingCheng = query_lx.ShenQingRenName;
                    jieXiang.BuMenMingCheng = query_lx.ShenQingRenBuMenMingCheng;
                    jieXiang.ZhiWuMingCheng = query_lx.ZhunJiZhiWu;
                    jieXiang.ZuiZhongChengGuo1 = query_lx.XiangMuFangAn.ZuiZhongChengGuo;
                    if (query_lx.EndDateTime > DateTime.Now)
                    {
                        jieXiang.WanChengZhuangTai = 1;
                    }
                    else if (query_lx.EndDateTime == DateTime.Now)
                    {
                        jieXiang.WanChengZhuangTai = 0;
                    }
                    else
                    {
                        jieXiang.WanChengZhuangTai = 2;
                    }
                    jieXiang.ZuiZhongChengGuoZiShu = 5;
                    jieXiang.HeZunJingFei = query_lx.JingFeiZongE;

                    singleResult.Result = jieXiang;
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
        /// 根据立项查找结项组员
        /// </summary>
        /// <returns></returns>
        public ListResult<JieXiangZuYuan> GetJieXiangZuYuans(Guid id)
        {
            ListResult<JieXiangZuYuan> listResult = new ListResult<JieXiangZuYuan>();
            List<JieXiangZuYuan> jieXiangZuYuans = new List<JieXiangZuYuan>();
            try
            {
                //判断是否 立项
                if (_dbContext.XiangMu.Any(x => x.Id == id))
                {
                    var query_lx = _mapper.Map<XiangMuDto>(_dbContext.XiangMu.SingleOrDefault(x => x.Id == id));
                    var lxzys = query_lx.XiangMuZuYuans;
                    var lxjfs = query_lx.JingFeis;

                    lxzys.ForEach(x =>
                    {
                        JieXiangZuYuan jieXiangZuYuan = new JieXiangZuYuan();
                        jieXiangZuYuan.LiXiangId = x.XiangMuId;
                        jieXiangZuYuan.XingMing = x.XiangMuZuChengYuanXingMing;
                        jieXiangZuYuan.BuMen = x.SuoSuBuMenMingCheng;
                        jieXiangZuYuan.YanJiuZhuanChang = x.YanJiuZhuanChang;
                        jieXiangZuYuans.Add(jieXiangZuYuan);
                    });
                    listResult.Results = jieXiangZuYuans;
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
        /// 根据立项查找结项经费
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ListResult<JieXiangJingFei> GetJieXiangJingFeis(Guid id)
        {
            ListResult<JieXiangJingFei> listResult = new ListResult<JieXiangJingFei>();
            List<JieXiangJingFei> jieXiangJingFeis = new List<JieXiangJingFei>();
            try
            {
                //判断是否 立项
                if (_dbContext.XiangMu.Any(x => x.Id == id))
                {
                    var query_lx = _mapper.Map<XiangMuDto>(_dbContext.XiangMu.SingleOrDefault(x => x.Id == id));
                    var lxzys = query_lx.XiangMuZuYuans;
                    var lxjfs = query_lx.JingFeis;

                    lxjfs.ForEach(x =>
                    {
                        JieXiangJingFei jieXiangJingFei = new JieXiangJingFei();
                        jieXiangJingFei.LiXiangId = x.XiangMuId;
                        jieXiangJingFei.JingFeiMingCheng = x.MingCheng;
                        jieXiangJingFei.JinE = x.JinE;
                        jieXiangJingFeis.Add(jieXiangJingFei);
                    });

                    listResult.Results = jieXiangJingFeis;
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
        /// 保存结项组员
        /// </summary>
        /// <returns></returns>
        [HttpPost,HttpGet]
        public SingleResult<bool> SaveJieXiangZuyuan(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.XiangMu.Any(x => x.Id == id))
                {
                    //var lxzy = _dbContext.XiangMuZuYuan.Where(x => x.XiangMuId == id).ToList();
                    //lxzy.ForEach(x =>
                    //{
                    //    JieXiangZuYuan jieXiangZuYuan = new JieXiangZuYuan();
                    //    jieXiangZuYuan.Id = Guid.NewGuid();
                    //    jieXiangZuYuan.LiXiangId = x.XiangMuId;
                    //    jieXiangZuYuan.YanJiuZhuanChang = x.YanJiuZhuanChang;
                    //    jieXiangZuYuan.BuMen = x.SuoSuBuMenMingCheng;
                    //    jieXiangZuYuan.ZhiWu = x.ZhiWuMingCheng;
                    //    jieXiangZuYuan.CreateDate = jieXiangZuYuan.LastUpdateDate = DateTime.Now;
                    //    _dbContext.JieXiangZuYuan.Add(jieXiangZuYuan);

                    //});
                    //singleResult.Result = _dbContext.SaveChanges() > 0;
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
        /// 保存结项
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpGet,HttpPost]
        public SingleResult<bool> SaveJieXiang(JieXiang_RequestBag entity)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var jiexiang = entity.JieXiang;
            var zys = entity.jiexiangzuyuans;
            var jfs = entity.jxJingFeis;
            var query_lx = _dbContext.XiangMu.SingleOrDefault(x => x.Id == jiexiang.LiXiangId);
            try
            {
                if (jiexiang.Id == Guid.Empty)
                {
                    //结项项目
                    jiexiang.Id = Guid.NewGuid();
                    jiexiang.XiangMuMingCheng = query_lx.XiangMuMingCheng;
                    jiexiang.XiangMuLeiXing = query_lx.XiangMuLeiXing;
                    jiexiang.JieXiangLeiXing = query_lx.LiXiangLeiXing;
                    if (jiexiang.JieXiangLeiXing == 1)
                    {
                        jiexiang.DianHua = query_lx.LianXiDianHua;
                    }
                    jiexiang.JieXiangTime = DateTime.Now;
                    jiexiang.CreateDate = jiexiang.LastUpdateDate = DateTime.Now;
                    _dbContext.JieXiang.Add(jiexiang);
                    //结项组员
                    zys.ForEach(x =>
                    {
                        x.Id = Guid.NewGuid();
                        x.JieXiangId = jiexiang.Id;
                        x.CreateDate = x.LastUpdateDate = DateTime.Now;
                        _dbContext.JieXiangZuYuan.Add(x);
                    });
                    //经费
                    jfs.ForEach(x =>
                    {
                        JieXiangJingFei jieXiangJingFei = new JieXiangJingFei();
                        jieXiangJingFei.Id = Guid.NewGuid();
                        jieXiangJingFei.LiXiangId = jiexiang.LiXiangId;
                        jieXiangJingFei.JieXiangId = jiexiang.Id;
                        jieXiangJingFei.JingFeiMingCheng = x.name;
                        jieXiangJingFei.JinE = double.Parse(x.jine);
                        jieXiangJingFei.KaiZhiShuoMing = x.kaizhi;
                        jieXiangJingFei.CreateDate = jieXiangJingFei.LastUpdateDate = DateTime.Now;
                        _dbContext.JieXiangJingFei.Add(jieXiangJingFei);
                    });

                }
                else
                {
                    //结项项目
                    var query_jiexiang = _dbContext.JieXiang.SingleOrDefault(x => x.Id == jiexiang.Id);
                    query_jiexiang.FuZeRenMingCheng = jiexiang.FuZeRenMingCheng;
                    query_jiexiang.BuMenMingCheng = jiexiang.BuMenMingCheng;
                    query_jiexiang.ZhiWuMingCheng = jiexiang.ZhiWuMingCheng;
                    query_jiexiang.ZuanyYe = jiexiang.ZuanyYe;
                    query_jiexiang.DianHua = jiexiang.DianHua;
                    query_jiexiang.ZuiZhongChengGuo1 = jiexiang.ZuiZhongChengGuo1;
                    query_jiexiang.ZuiZhongChengGuo2 = jiexiang.ZuiZhongChengGuo2;
                    query_jiexiang.WanChengZhuangTai = jiexiang.WanChengZhuangTai;
                    query_jiexiang.ZuiZhongChengGuoZiShu = jiexiang.ZuiZhongChengGuoZiShu;
                    query_jiexiang.FaBiaoChuBan = jiexiang.FaBiaoChuBan;
                    query_jiexiang.HeZunJingFei = jiexiang.HeZunJingFei;
                    query_jiexiang.ShiJiJingFei = jiexiang.ShiJiJingFei;
                    query_jiexiang.JieYu = jiexiang.JieYu;
                    query_jiexiang.ZongJie1 = jiexiang.ZongJie1;
                    query_jiexiang.ZongJie2 = jiexiang.ZongJie2;
                    query_jiexiang.ZongJie3 = jiexiang.ZongJie3;
                    query_jiexiang.LastUpdateDate = DateTime.Now;

                    //结项组员
                    var ids = zys.Select(x => x.Id);
                    var delRange = _dbContext.JieXiangZuYuan.Where(x => x.JieXiangId == jiexiang.Id && !ids.Contains(x.Id));
                    _dbContext.JieXiangZuYuan.RemoveRange(delRange);

                    zys.ForEach(x =>
                    {
                        if (_dbContext.JieXiangZuYuan.Any(p => p.Id == x.Id))
                        {
                            var query_zy = _dbContext.JieXiangZuYuan.SingleOrDefault(p => p.Id == x.Id);
                            query_zy.XingMing = x.XingMing;
                            query_zy.BuMen = x.BuMen;
                            query_zy.ZhiWu = x.ZhiWu;
                            query_zy.YanJiuZhuanChang = x.YanJiuZhuanChang;
                            query_zy.ZuanYe = x.ZuanYe;
                            query_zy.FenGongQingKuang = x.FenGongQingKuang;
                            query_zy.LastUpdateDate = DateTime.Now;
                        }

                    });

                    //结项经费
                    // 删除所有
                    deljfbyid(jiexiang.LiXiangId, jiexiang.Id);
                    //重新添加
                    jfs.ForEach(x =>
                    {
                        JieXiangJingFei jieXiangJingFei = new JieXiangJingFei();
                        jieXiangJingFei.Id = Guid.NewGuid();
                        jieXiangJingFei.LiXiangId = jiexiang.LiXiangId;
                        jieXiangJingFei.JieXiangId = jiexiang.Id;
                        jieXiangJingFei.JingFeiMingCheng = x.name;
                        jieXiangJingFei.JinE = double.Parse(x.jine);
                        jieXiangJingFei.KaiZhiShuoMing = x.kaizhi;
                        jieXiangJingFei.CreateDate = jieXiangJingFei.LastUpdateDate = DateTime.Now;
                        _dbContext.JieXiangJingFei.Add(jieXiangJingFei);
                    });

                }
                var result = _dbContext.SaveChanges() > 0;
                //结项状态更改
                if (result)
                {
                    updatelixiang(jiexiang.LiXiangId);
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
        /// 
        /// </summary>
        /// <param name="lixiangid"></param>
        /// <param name="jiexiangid"></param>
        /// <returns></returns>
        public bool deljfbyid(Guid lixiangid, Guid jiexiangid)
        {
            if (_dbContext.JieXiangJingFei.Any(x => x.LiXiangId == lixiangid && x.JieXiangId == jiexiangid))
            {
                var delRange = _dbContext.JieXiangJingFei.Where(x => x.LiXiangId == lixiangid && x.JieXiangId == jiexiangid);
                _dbContext.JieXiangJingFei.RemoveRange(delRange);
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取结项列表
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<JieXiang> GetJieXinags(int skip, int take)
        {
            ListResult<JieXiang> listResult = new ListResult<JieXiang>();
            var currentUser = _fapContext.CurrentUser;
            try
            {
                var query = _dbContext.JieXiang.Where(x=>x.FuZeRenMingCheng==currentUser.Name).OrderByDescending(x=>x.CreateDate).Skip(skip).Take(take);
                listResult.Results = query.ToList();
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
        /// 结项时 更改立项状态
        /// </summary>
        /// <param name="lixiangid"></param>
        /// <returns></returns>
        public bool updatelixiang(Guid lixiangid)
        {
            if (_dbContext.XiangMu.Any(x => x.Id == lixiangid))
            {
                var query = _dbContext.XiangMu.SingleOrDefault(x => x.Id == lixiangid);
                query.Status = 6;
                query.LastUpdateDate = DateTime.Now;

            }

            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除结项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SingleResult<bool> DelJieXiang(Guid id)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                if (_dbContext.JieXiang.Any(x => x.Id == id))
                {
                    var query_jx = _dbContext.JieXiang.SingleOrDefault(x => x.Id == id);
                    _dbContext.JieXiang.Remove(query_jx);
                    //更改立项状态
                    var query_lx = _dbContext.XiangMu.SingleOrDefault(x => x.Id == query_jx.LiXiangId);
                    query_lx.Status = 8;
                    query_lx.LastUpdateDate = DateTime.Now;

                    //获取 结项组员 经费
                    var delRange_zy = _dbContext.JieXiangZuYuan.Where(x => x.LiXiangId == query_lx.Id && x.JieXiangId == query_jx.Id);
                    _dbContext.JieXiangZuYuan.RemoveRange(delRange_zy);

                    var delRange_jf = _dbContext.JieXiangJingFei.Where(x => x.LiXiangId == query_lx.Id && x.JieXiangId == query_jx.Id);
                    _dbContext.JieXiangJingFei.RemoveRange(delRange_jf);
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
        /// 根据 结项编号获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SingleResult<JieXiangDto> GetJieXiangById(Guid id)
        {
            SingleResult<JieXiangDto> singleResult = new SingleResult<JieXiangDto>();
            try
            {
                var query = _dbContext.JieXiang.SingleOrDefault(x => x.Id == id);
                var result = _mapper.Map<JieXiangDto>(query);
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
        /// 筛选
        /// </summary>
        /// <returns></returns>
        public ListResult<JieXiang> GetJieXiangBy(int xiangmuleixing, string EndTime, int skip, int take)
        {
            ListResult<JieXiang> listResult = new ListResult<JieXiang>();
            try
            {
                var linq = from jx in _dbContext.JieXiang select jx;
                if (!string.IsNullOrEmpty(xiangmuleixing.ToString()) && xiangmuleixing != -1)
                {
                    linq = linq.Where(x => x.XiangMuLeiXing == xiangmuleixing);
                }
                else if (!string.IsNullOrEmpty(EndTime))
                {
                    linq = linq.Where(x => x.JieXiangTime <= Convert.ToDateTime(EndTime));
                }
                var query = linq.OrderByDescending(x=>x.CreateDate).Skip(skip).Take(take).ToList();
                listResult.Results = query;
                listResult.TotalRows = query.Count;
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 获取该结项的经费 详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ListResult<JieXiangJingFei> GetJieXiangjfs(Guid id) {
            ListResult<JieXiangJingFei> listResult = new ListResult<JieXiangJingFei>();
            try
            {
                if (_dbContext.JieXiangJingFei.Any(x=>x.JieXiangId==id))
                {
                    var query = _dbContext.JieXiangJingFei.Where(x => x.JieXiangId == id);
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
    }
}