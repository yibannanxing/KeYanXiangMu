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
    public class Cg_KeYanXiangMuController : KeYanControllerBase
    {
        public Cg_KeYanXiangMuController(
           FAPContext fapContext,
         FAP.Client.Service.OrganizationService organizationService,
         FAP.Client.Service.PrivilegeService privilegeService,
         FAP.Client.Service.MessageService messageService,
         FAP.Client.Service.LoggerService loggerService,
         KeYanGuanLiContext dbContext,
         IHttpContextAccessor httpContext,
         IMemoryCache memoryCache,
         IConfiguration configuration,
         ILogger<Cg_KeYanXiangMuController> logger,
         IMapper mapper)
         : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }

        /// <summary>
        /// 保存成果（科研项目）
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCGkyxm(Request_CG_Bag entity, string zhuangtai1, string zhuangtai2, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var kyxm = entity.cgKeYanXiangMu;
            var canyuzes = entity.canyuzes;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var jilu = entity.jilu;
            var result = false;
            try
            {
                if (kyxm.Id == Guid.Empty)
                {
                    if (Convert.ToInt32(zhuangtai2) == -1)
                    {
                        AddCgkyxm(entity, Convert.ToInt32(zhuangtai1), status);
                    }
                    else
                    {
                        AddCgkyxm(entity, Convert.ToInt32(zhuangtai1), status);
                        AddCgkyxm(entity, Convert.ToInt32(zhuangtai2), status);
                    }

                }
                else
                {
                    var query_kyxm = _dbContext.CgKeYanXiangMu.SingleOrDefault(x => x.Id == kyxm.Id);
                    query_kyxm.PiZunLiXiangBuMen = kyxm.PiZunLiXiangBuMen;
                    query_kyxm.LiXiangShiJian = kyxm.LiXiangShiJian;
                    query_kyxm.JiHuaWanChengShiJian = kyxm.JiHuaWanChengShiJian;
                    query_kyxm.GongBuJieXiangShiJian = kyxm.GongBuJieXiangShiJian;
                    query_kyxm.XiangMuJiBie = kyxm.XiangMuJiBie;
                    query_kyxm.XiangMuLeiBie = kyxm.XiangMuLeiBie;
                    query_kyxm.YuanNeiXiangMuBianHao = kyxm.YuanNeiXiangMuBianHao;
                    query_kyxm.YuanWaiXiangMuBianHao = kyxm.YuanWaiXiangMuBianHao;
                    query_kyxm.XiangMuZiZuZongE = kyxm.XiangMuZiZuZongE;
                    query_kyxm.BenRenShuMingPaiXu = kyxm.BenRenShuMingPaiXu;
                    query_kyxm.XiangMuZhuangTai = kyxm.XiangMuZhuangTai;
                    query_kyxm.IsYuanKeYanZuGuanBmgl = kyxm.IsYuanKeYanZuGuanBmgl;
                    query_kyxm.IsBenRenZhiDao = kyxm.IsBenRenZhiDao;
                    query_kyxm.XiangMuHuoJiangJiBie = kyxm.XiangMuHuoJiangJiBie;
                    query_kyxm.XiangMuHuoJiangTime = kyxm.XiangMuHuoJiangTime;
                    query_kyxm.XiangMuHuoJiangZhengShuId = kyxm.XiangMuHuoJiangZhengShuId;
                    query_kyxm.XiangMuChengGuoCaiNaJiBie = kyxm.XiangMuChengGuoCaiNaJiBie;
                    query_kyxm.XiangMuChengGuoCaiNaTime = kyxm.XiangMuChengGuoCaiNaTime;
                    query_kyxm.KeYanKaoHeDeFen = kyxm.KeYanKaoHeDeFen;
                    query_kyxm.LastUpdateDate = DateTime.Now;
                    query_kyxm.XiangMuHuoJiangMingCheng = kyxm.XiangMuHuoJiangMingCheng;
                    query_kyxm.ShiJiDeFen = kyxm.ShiJiDeFen;
                    query_kyxm.XiangMuLaiYuan = kyxm.XiangMuLaiYuan;
                    query_kyxm.XueShengJieXiangDengJi = kyxm.XueShengJieXiangDengJi;
                    query_kyxm.Status = status;
                    query_kyxm.YuanNeiBenRenShuMingPaiXu = kyxm.YuanNeiBenRenShuMingPaiXu;
                    query_kyxm.XiangMuMingCheng = kyxm.XiangMuMingCheng;
                    query_kyxm.SuoShuNianDu = kyxm.SuoShuNianDu;
                    //_mapper.Map(query_kyxm,kyxm, typeof(CgKeYanXiangMu), typeof(CgKeYanXiangMu));


                    var query_cyz = _dbContext.CgCanYuZhe.Where(x => x.CgId == kyxm.Id);
                    _dbContext.CgCanYuZhe.RemoveRange(query_cyz);
                    //参与者
                    if (canyuzes != null)
                    {
                        for (int i = 0; i < canyuzes.Count; i++)
                        {
                            var cgCanYuZhe = new CgCanYuZhe();
                            cgCanYuZhe.Id = Guid.NewGuid();
                            cgCanYuZhe.CgId = kyxm.Id;
                            cgCanYuZhe.Name = canyuzes[i].name;
                            if (canyuzes[i].isbenyuan == "是")
                            {
                                cgCanYuZhe.IsBenYuan = 0;
                            }
                            else
                            {
                                cgCanYuZhe.IsBenYuan = 1;
                            }
                            cgCanYuZhe.PaiXu = i;
                            cgCanYuZhe.IsTongXunZuoZe = 1;
                            cgCanYuZhe.Status = 0;
                            cgCanYuZhe.CreateDate = cgCanYuZhe.LastUpdateDate = DateTime.Now;
                            _dbContext.CgCanYuZhe.Add(cgCanYuZhe);
                        }
                    }
                    var query_fj = _dbContext.FuJian.Where(x => x.ChengGuoId == kyxm.Id);
                    _dbContext.FuJian.RemoveRange(query_fj);
                    //附件
                    if (fm != null)
                    {
                        for (int i = 0; i < fm.Count; i++)
                        {
                            fm[i].Id = Guid.NewGuid();
                            fm[i].ChengGuoId = kyxm.Id;
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
                            file[i].ChengGuoId = kyxm.Id;
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
                            article[i].ChengGuoId = kyxm.Id;
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
                            wenjian[i].ChengGuoId = kyxm.Id;
                            wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                            wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                            wenjian[i].PaiXu = i.ToString();
                            _dbContext.FuJian.Add(wenjian[i]);
                        }
                    }

                    SaveCgjl(kyxm, jilu, canyuzes, status);
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
        /// 添加cgkyxm
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="zt">状态</param>
        /// <param name="status"></param>
        /// <returns></returns>
        public SingleResult<bool> AddCgkyxm(Request_CG_Bag entity, int zt, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var kyxm = entity.cgKeYanXiangMu;
            var canyuzes = entity.canyuzes;
            var fm = entity.fengmianList;
            var file = entity.fileList;
            var article = entity.articleList;
            var wenjian = entity.wenjianList;
            var jilu = entity.jilu;
            bool result = false;
            try
            {
                //科研项目
                kyxm.Id = Guid.NewGuid();
                kyxm.UserName = currentUser.Name;
                kyxm.UserId = currentUser.Id;
                kyxm.XiangMuZhuangTai = zt;
                kyxm.Status = status;
                kyxm.CreateDate = kyxm.LastUpdateDate = DateTime.Now;
                kyxm.BuMenId = OrgHelper.GetBuMenId(currentUser);
                kyxm.BuMenMingCheng = OrgHelper.GetBuMenMingCheng(currentUser);
                _dbContext.CgKeYanXiangMu.Add(kyxm);

                //参与者
                if (canyuzes != null)
                {
                    for (int i = 0; i < canyuzes.Count; i++)
                    {
                        var cgCanYuZhe = new CgCanYuZhe();
                        cgCanYuZhe.Id = Guid.NewGuid();
                        cgCanYuZhe.CgId = kyxm.Id;
                        cgCanYuZhe.Name = canyuzes[i].name;
                        if (canyuzes[i].isbenyuan == "是")
                        {
                            cgCanYuZhe.IsBenYuan = 0;
                        }
                        else
                        {
                            cgCanYuZhe.IsBenYuan = 1;
                        }
                        cgCanYuZhe.PaiXu = i;
                        cgCanYuZhe.IsTongXunZuoZe = 1;
                        cgCanYuZhe.Status = 0;
                        cgCanYuZhe.CreateDate = cgCanYuZhe.LastUpdateDate = DateTime.Now;
                        _dbContext.CgCanYuZhe.Add(cgCanYuZhe);
                    }
                }
                //附件
                if (fm != null)
                {
                    for (int i = 0; i < fm.Count; i++)
                    {
                        fm[i].Id = Guid.NewGuid();
                        fm[i].ChengGuoId = kyxm.Id;
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
                        file[i].ChengGuoId = kyxm.Id;
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
                        article[i].ChengGuoId = kyxm.Id;
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
                        wenjian[i].ChengGuoId = kyxm.Id;
                        wenjian[i].WenJianLeiXing = (int)MeiJuUtils.chengGuoFuJianLeiXing.文件附件;
                        wenjian[i].CreateDateTime = wenjian[i].LastUpdateTime = DateTime.Now;
                        wenjian[i].PaiXu = i.ToString();
                        _dbContext.FuJian.Add(wenjian[i]);
                    }
                }

                result = _dbContext.SaveChanges() > 0;
                if (result)
                {
                    SaveCgjl(kyxm, jilu, canyuzes, status);
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
        /// 保存成功记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="canyuzes"></param>
        /// <param name="jilu"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<bool> SaveCgjl(CgKeYanXiangMu entity, JiLu jilu, List<canyuze> canyuzes, int status)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            var currentUser = _fapContext.CurrentUser;
            var str = "";

            try
            {
                if (canyuzes != null)
                {
                    canyuzes.ForEach(x =>
                    {
                        str = str + x.name + ',';
                    });
                }
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
                    query_jilu.CgLeiXingMingCheng = "科研项目";
                    query_jilu.LastUpdateDate = DateTime.Now;
                    query_jilu.StartDate = entity.LiXiangShiJian;
                    query_jilu.EndDate = entity.GongBuJieXiangShiJian;
                    query_jilu.HuoJiangLeiXing = entity.XiangMuHuoJiangJiBie;
                    query_jilu.CgMingCheng = entity.XiangMuMingCheng;
                    //query_jilu.ShenHeFen = entity.ShenHeDeFen;
                    query_jilu.XiangMuLaiYuan = entity.XiangMuLaiYuan;
                    query_jilu.YuanNeiXiangMuBianHao = entity.YuanNeiXiangMuBianHao;
                    query_jilu.ShuMingPaiXu = entity.BenRenShuMingPaiXu;
                    query_jilu.XiangMuZuChengYuan = str;
                    query_jilu.ZhuanJiZhiWu = jilu.ZhuanJiZhiWu;
                    query_jilu.JiaoGuanZhiWu = jilu.JiaoGuanZhiWu;
                }
                else
                {
                    CgJiLu cgJiLu = new CgJiLu();
                    cgJiLu.Id = Guid.NewGuid();
                    cgJiLu.CgId = entity.Id;
                    cgJiLu.UserId = currentUser.Id;
                    cgJiLu.CgLeiXingMingCheng = "科研项目";
                    cgJiLu.Status = status;
                    cgJiLu.CreateDate = cgJiLu.LastUpdateDate = DateTime.Now;
                    cgJiLu.UserName = currentUser.Name;
                    //正式环境
                    //OrgHelper.GetBuMenId(currentUser);
                    //测试环境（包含科室）
                    //currentUser.OrganizationalUnitRoleDefault.OrganizationalUnitId;
                    //currentUser.OrganizationalUnitRoleDefault.ORGName;

                    cgJiLu.BumenId = OrgHelper.GetBuMenId(currentUser);
                    cgJiLu.Bumen = OrgHelper.GetBuMenMingCheng(currentUser);

                    cgJiLu.StartDate = entity.LiXiangShiJian;
                    cgJiLu.EndDate = entity.GongBuJieXiangShiJian;
                    cgJiLu.HuoJiangLeiXing = entity.XiangMuHuoJiangJiBie;
                    cgJiLu.CgMingCheng = entity.XiangMuMingCheng;
                    // cgJiLu.ShenHeFen = entity.ShenHeDeFen;
                    cgJiLu.XiangMuLaiYuan = entity.XiangMuLaiYuan;
                    cgJiLu.YuanNeiXiangMuBianHao = entity.YuanNeiXiangMuBianHao;
                    cgJiLu.ShuMingPaiXu = entity.BenRenShuMingPaiXu;
                    cgJiLu.XiangMuZuChengYuan = str;
                    cgJiLu.ZhuanJiZhiWu = jilu.ZhuanJiZhiWu;
                    cgJiLu.JiaoGuanZhiWu = jilu.JiaoGuanZhiWu;
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
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        public SingleResult<CgKeYanXiangMuDto> GetCgkyxmById(Guid id)
        {
            SingleResult<CgKeYanXiangMuDto> singleResult = new SingleResult<CgKeYanXiangMuDto>();
            try
            {
                if (_dbContext.CgKeYanXiangMu.Any(x => x.Id == id))
                {
                    var query = _dbContext.CgKeYanXiangMu.SingleOrDefault(x => x.Id == id);
                    singleResult.Result = _mapper.Map<CgKeYanXiangMuDto>(query);
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
        /// 获取最近一条审核记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ListResult<CgShenHe> GetShenHe(Guid id)
        {
            ListResult<CgShenHe> listResult = new ListResult<CgShenHe>();
            try
            {
                if (_dbContext.CgShenHe.Any(x => x.CgId == id))
                {
                    var query = _dbContext.CgShenHe.Where(x => x.CgId == id);
                    listResult.Results = query.OrderByDescending(x => x.CreateDate).ToList();

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
        /// 科研项目统计 不带分页
        /// </summary>
        /// <returns></returns>
        public ListResult<CgKeYanXiangMuDto> GetKeYanXiangMuS()
        {
            ListResult<CgKeYanXiangMuDto> listResult = new ListResult<CgKeYanXiangMuDto>();
            try
            {
                //var query = _dbContext.CgKeYanXiangMu.Where(x => x.Status == 1).GroupBy(x => x.XiangMuMingCheng.Trim()).Select(x => x.First());
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "科研项目" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgKeYanXiangMu.Where(x => query_ids.Contains(x.Id));
               
                listResult.Results = _mapper.Map<List<CgKeYanXiangMuDto>>(query.ToList());
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误", ex);
            }
            return listResult;
        }
        /// <summary>
        /// 科研项目统计 带分页
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgKeYanXiangMuDto> GetKeYanXiangMuSByFenYe(int skip, int take)
        {
            ListResult<CgKeYanXiangMuDto> listResult = new ListResult<CgKeYanXiangMuDto>();
            try
            {
                //var query = _dbContext.CgKeYanXiangMu.Where(x => x.Status == 1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "科研项目" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgKeYanXiangMu.Where(x => query_ids.Contains(x.Id));

                listResult.Results = _mapper.Map<List<CgKeYanXiangMuDto>>(query.Skip(skip).Take(take).ToList());
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
        /// 科研项目 筛选
        /// </summary>
        /// <param name="applyName"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="isHuoJiang"></param>
        /// <param name="cgName"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public ListResult<CgKeYanXiangMuDto> GetKeYanXiangMuByBase(string applyName, string startTime, string endTime, string isHuoJiang,string cgName,int skip,int take)
        {
            ListResult<CgKeYanXiangMuDto> listResult = new ListResult<CgKeYanXiangMuDto>();
            try
            {
                //var query = _dbContext.CgKeYanXiangMu.Where(x => x.Status != -1);
                var query_ids = _dbContext.CgJiLu.Where(x => x.CgLeiXingMingCheng == "科研项目" && x.Status != -1).Select(x => x.CgId);
                var query = _dbContext.CgKeYanXiangMu.Where(x => query_ids.Contains(x.Id));

                if (!string.IsNullOrEmpty(applyName))
                {
                    query = query.Where(x => x.UserName.Contains(applyName));
                }
                else if (!string.IsNullOrEmpty(cgName))
                {
                    query = query.Where(x => x.XiangMuMingCheng.Contains(cgName));
                }
                else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.LiXiangShiJian >= Convert.ToDateTime(startTime));
                }
                else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.GongBuJieXiangShiJian <= Convert.ToDateTime(endTime));
                }
                else if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    query = query.Where(x => x.LiXiangShiJian <= Convert.ToDateTime(endTime) && x.GongBuJieXiangShiJian >= Convert.ToDateTime(startTime));
                }
                else if (isHuoJiang == "是")
                {
                    query = query.Where(x => x.XiangMuHuoJiangJiBie !=null);
                }
                else if (isHuoJiang == "否")
                {
                    query = query.Where(x => x.XiangMuHuoJiangJiBie == null);
                }
                listResult.Results = _mapper.Map<List<CgKeYanXiangMuDto>>(query.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList());
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