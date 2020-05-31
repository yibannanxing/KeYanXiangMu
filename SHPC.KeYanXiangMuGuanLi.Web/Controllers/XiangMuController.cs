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
using static SHPC.KeYanXiangMuGuanLi.Engine.Services.MeiJuUtils;
using System.Web;
using System.IO;
using System.Diagnostics;
using WordExportDemo;
using Novacode;


namespace SHPC.KeYanXiangMuGuanLi.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]

    public class XiangMuController : KeYanControllerBase
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
        public XiangMuController(
              FAPContext fapContext,
            FAP.Client.Service.OrganizationService organizationService,
            FAP.Client.Service.PrivilegeService privilegeService,
            FAP.Client.Service.MessageService messageService,
            FAP.Client.Service.LoggerService loggerService,
            KeYanGuanLiContext dbContext,
            IHttpContextAccessor httpContext,
            IMemoryCache memoryCache,
            IConfiguration configuration,
            ILogger<XiangMuController> logger,
            IMapper mapper)
            : base(fapContext, organizationService, privilegeService, messageService, loggerService, dbContext, configuration, httpContext, memoryCache, logger, mapper)
        { }
        /// <summary>
        /// 根据项目id 获取详情
        /// </summary>
        /// <param name="xiangmuId"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<XiangMuDto> GetXiangMuXiangQingById(Guid xiangmuId)
        {
            SingleResult<XiangMuDto> singleResult = new SingleResult<XiangMuDto>();
            try
            {
                singleResult.Result = _mapper.Map<XiangMuDto>(_xiangMuService.GetXiangMu(xiangmuId));
            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");

            }
            return singleResult;
        }
        /// <summary>
        /// 编辑项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<XiangMuDto> GetXiangMuById(Guid id)
        {
            SingleResult<XiangMuDto> singleResult = new SingleResult<XiangMuDto>();
            try
            {
                var single = _dbContext.XiangMu.SingleOrDefault(x => x.Id == id);
                single = single == null ? new XiangMu
                {
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                    ChuShengNianYue = DateTime.Now
                } : single;
                var dto = _mapper.Map<XiangMuDto>(single);
                singleResult.Result = dto;


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
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="applyName"></param>
        /// <param name="bumen"></param>
        /// <param name="xiangmuleixing"></param>
        /// <param name="yanjiuleixing"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuDto> GetXiangMuByZiDuan(int skip, int take, string applyName, string bumen, int xiangmuleixing, int yanjiuleixing, string startTime, string endTime)
        {
            ListResult<XiangMuDto> listResult = new ListResult<XiangMuDto>();
            try
            {
                var lresult = _xiangMuService.XiangMuShow(skip, take, applyName, bumen, xiangmuleixing, yanjiuleixing, startTime, endTime, out int totalRows);

                listResult.Results = _mapper.Map<List<XiangMuDto>>(lresult);
                listResult.TotalRows = totalRows;
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 筛选个人
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="xiangmuleixing"></param>
        /// <param name="yanjiuleixing"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuDto> GetXiangMuByGeRen(int skip, int take, int xiangmuleixing, int yanjiuleixing, string startTime, string endTime)
        {
            ListResult<XiangMuDto> listResult = new ListResult<XiangMuDto>();
            try
            {
                var useid = _fapContext.CurrentUser.Id;
                var lresult = _xiangMuService.XiangMuShow(skip, take, useid, xiangmuleixing, yanjiuleixing, startTime, endTime, out int totalRows);
                listResult.Results = _mapper.Map<List<XiangMuDto>>(lresult);
                listResult.TotalRows = totalRows;
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }
        /// <summary>
        /// 总览页面
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuDto> GetXiangMus(int skip, int take)
        {
            ListResult<XiangMuDto> listResult = new ListResult<XiangMuDto>();
            try
            {
                //  listResult.Results = _mapper.Map<List<XiangMuDto>>(_xiangMuService.XiangMuShow(skip, take, out int totalRows));
                var lrsult = _xiangMuService.XiangMuShow(skip, take, out int totalRows);
                listResult.Results = _mapper.Map<List<XiangMuDto>>(lrsult);
                listResult.TotalRows = totalRows;
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                listResult.Error = new Error("系统未知错误");
            }
            return listResult;
        }

        /// <summary>
        /// 当前登录人页面（个人）
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public ListResult<XiangMuDto> GetXiangMusByUserId(int skip, int take)
        {
            ListResult<XiangMuDto> listResult = new ListResult<XiangMuDto>();
            try
            {
                var currentUserId = _fapContext.CurrentUser.Id;
                var lrsult = _dbContext.XiangMu.Where(x => x.ShenQingRenId == currentUserId && x.Status != (int)MeiJuUtils.XiangMuZhuangTaiName.已删除 && x.Status != (int)MeiJuUtils.XiangMuZhuangTaiName.归档).OrderByDescending(x => x.EndDateTime).Skip(skip).Take(take).ToList();
                listResult.Results = _mapper.Map<List<XiangMuDto>>(lrsult);
                listResult.TotalRows = lrsult.Count;
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
        /// <returns></returns>
        [HttpGet]
        public SingleResult<XiangMuDto> GetXiangMuSchema()
        {
            SingleResult<XiangMuDto> singleResult = new SingleResult<XiangMuDto>();
            try
            {
                var currentUser = _fapContext.CurrentUser;
                singleResult.Result = new XiangMuDto
                {
                    Id = Guid.Empty,
                    IsYanQi = false,
                    ShenQingRenId = currentUser.Id,
                    ShenQingRenName = currentUser.Name,
                    ShenQingRenBuMenId = currentUser.OrganizationalUnitRoleDefault.OrganizationalUnitId,
                    ShenQingRenBuMenMingCheng = currentUser.OrganizationalUnitRoleDefault.ORGName,
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now,
                };


            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 测试 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> SaveXiangMu(XiangMuDto entity)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            XiangMu instance = new XiangMu();
            var cUser = _fapContext.CurrentUser;
            try
            {

                if (_dbContext.XiangMu.Any(p => p.Id == entity.Id))
                {
                    instance = _dbContext.XiangMu.Find(entity.Id);

                }
                else
                {
                    entity.Id = Guid.NewGuid();
                    entity.CreateDate = entity.LastUpdateDate = DateTime.Now;
                    entity.Status = (int)XiangMuZhuangTaiName.提交;
                    entity.ShenQingRenId = cUser.Id;
                    entity.ShenQingRenBuMenMingCheng = cUser.Name;
                    entity.ShenQingRenBuMenId = OrgHelper.GetBuMenId(cUser);
                    entity.ShenQingRenBuMenMingCheng = OrgHelper.GetBuMenMingCheng(cUser);
                    entity.IsYanQi = false;
                    _dbContext.XiangMu.Add(instance);
                }
                _mapper.Map(entity, instance, typeof(XiangMuDto), typeof(XiangMu));

                //添加外键信息
                //方案
                if (entity.XiangMuFangAn != null)
                {
                    if (_dbContext.XiangMuFangAn.Any(p => p.XiangMuId == entity.Id))
                    {
                        var fangAnInstance = _dbContext.XiangMuFangAn.Find(entity.Id);
                        entity.XiangMuFangAn.LastUpdateDate = DateTime.Now;
                        _mapper.Map(entity.XiangMuFangAn, fangAnInstance, typeof(XiangMuFangAn), typeof(XiangMuFangAn));
                    }
                    else
                    {
                        entity.XiangMuFangAn.XiangMuId = entity.Id;
                        entity.XiangMuFangAn.CreateDate = entity.XiangMuFangAn.LastUpdateDate = DateTime.Now;
                        _dbContext.XiangMuFangAn.Add(entity.XiangMuFangAn);
                    }
                }
                //成员
                if (entity.XiangMuZuYuans != null)
                {
                    //将除去做过删除操作的元素
                    var zyIds = entity.XiangMuZuYuans.Select(p => p.Id);
                    var delRange = _dbContext.XiangMuZuYuan.Where(p => p.XiangMuId == entity.Id && !zyIds.Contains(p.Id));
                    _dbContext.XiangMuZuYuan.RemoveRange(delRange);

                    entity.KeTiZuChengYuanRenSu = entity.XiangMuZuYuans.Count();
                    foreach (var zy in entity.XiangMuZuYuans)
                    {
                        if (_dbContext.XiangMuZuYuan.Any(p => p.Id == zy.Id))
                        {
                            var zyInstance = _dbContext.XiangMuZuYuan.Find(zy.Id);
                            zy.LastUpdateDate = DateTime.Now;
                            _mapper.Map(zy, zyInstance, typeof(XiangMuZuYuan), typeof(XiangMuZuYuan));
                        }
                        else
                        {
                            zy.XiangMuId = entity.Id;
                            zy.CreateDate = zy.LastUpdateDate = DateTime.Now;
                            _dbContext.XiangMuZuYuan.Add(zy);
                        }
                    }
                }
                //经费
                if (entity.JingFeis != null)
                {
                    //将除去做过删除操作的元素
                    var jfIds = entity.JingFeis.Select(p => p.Id);
                    var delRange = _dbContext.JingFei.Where(p => p.XiangMuId == entity.Id && !jfIds.Contains(p.Id));
                    _dbContext.JingFei.RemoveRange(delRange);
                    foreach (var jf in entity.JingFeis)
                    {
                        if (_dbContext.JingFei.Any(p => p.Id == jf.Id))
                        {
                            var jfInstance = _dbContext.JingFei.Find(jf.Id);
                            jf.LastUpdateDate = DateTime.Now;
                            _mapper.Map(jf, jfInstance, typeof(JingFei), typeof(JingFei));
                        }
                        else
                        {
                            jf.XiangMuId = entity.Id;
                            jf.CreateDate = jf.LastUpdateDate = DateTime.Now;
                            _dbContext.JingFei.Add(jf);
                        }
                    }
                }
                _dbContext.SaveChanges();
                singleResult.Result = true;
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;

        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="xiangmuId"></param>
        /// <returns></returns>
        [HttpGet]
        public SingleResult<bool> DelXiangMu(Guid xiangmuId)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuService.DelXiangMu(xiangmuId);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 项目延期
        /// </summary>
        /// <param name="xiangmuId"></param>
        /// <param name="yanQiDate"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> XiangMuYanQi(Guid xiangmuId, DateTime yanQiDate)
        {
            SingleResult<bool> singleResult = new SingleResult<bool>();
            try
            {
                singleResult.Result = _xiangMuService.YanQiXiangMu(xiangmuId, yanQiDate);
            }
            catch (Exception ex)
            {

                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 项目审批
        /// </summary>
        /// <param name="xiangmu"></param>
        /// <returns></returns>
        [HttpPost]
        public SingleResult<bool> ShenPi(XiangMu xiangmu)
        {
            return null;
        }
        /// <summary>
        /// 根据选择人获取用户信息
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public SingleResult<XiangMuDto> GetResultBy(Guid UserId)
        {
            SingleResult<XiangMuDto> singleResult = new SingleResult<XiangMuDto>();
            try
            {


            }
            catch (Exception ex)
            {
                _loggerService.LogException(_fapContext.CurrentUser, null, "", ex);
                singleResult.Error = new Error("系统未知错误");
            }
            return singleResult;
        }
        /// <summary>
        /// 导出个人模板 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool exportresult(Guid id)
        {
            #region 获取需要导出的数据
            var query = _mapper.Map<XiangMuDto>(_xiangMuService.GetXiangMu(id));
            var zy = query.XiangMuZuYuans;
            var fangan = query.XiangMuFangAn;
            var jf = query.JingFeis;
            #endregion
            var result = false;
            try
            {
                //填充数据
                //Stopwatch sw = new Stopwatch();
                Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"xiangMuMingCheng",query.XiangMuMingCheng },
                {"xiangMuLeiXingName",query.XiangMuLeiXingName },
                {"yanJiuLeiXingName",query.YanJiuLeiXingName },
                {"shenQingRenName",query.ShenQingRenName },
                {"xingBie",query.XingBie },
                {"minZu",query.MinZu },
                {"chuShengNianYue",query.ChuShengNianYue },
                {"xingZhengZhiWu",query.XingZhengZhiWu },
                {"jiaoGuanZhiWu",query.JiaoGuanZhiWu },
                {"zhunJiZhiWu",query.ZhunJiZhiWu },
                {"zuiHouXueLi",query.ZuiHouXueLi },
                {"shenQingRenBuMenMingCheng",query.ShenQingRenBuMenMingCheng },
                {"lianXiDianHua",query.LianXiDianHua },
                {"shouKeKeMu",query.ShouKeKeMu },
                {"shouKeDuiXiang",query.ShouKeDuiXiang },
                {"yuQiChengGuoLeiXingName",query.YuQiChengGuoLeiXingName },
                {"jingFeiZongE",query.JingFeiZongE },
                {"endDateTime",query.EndDateTime },
            };
                //list列表 组员
                IList<Dictionary<string, object>> zuyuans = new List<Dictionary<string, object>>();
                zy.ForEach(x =>
                {
                    zuyuans.Add(new Dictionary<string, object>() {
                        {"xiangMuZuChengYuanXingMing",x.XiangMuZuChengYuanXingMing},
                        {"xingBie",x.XingBie},
                        {"chuShengNianYue",x.ChuShengNianYue},
                        {"zhiWuMingCheng",x.ZhiWuMingCheng},
                        {"yanJiuZhuanChang",x.YanJiuZhuanChang},
                        {"xueLi",x.XueLi},
                        {"suoSuBuMenMingCheng",x.SuoSuBuMenMingCheng},
                    });

                });
                data.Add("zuyuans", zuyuans);
                // sw.Start();
                //string rootdir = AppContext.BaseDirectory;
                //DirectoryInfo dir = Directory.GetParent(rootdir);
                //string root = dir.Parent.Parent.Parent.Parent.FullName;
                //string root = System.AppDomain.CurrentDomain.BaseDirectory;

                var root = "";
                //WordHelper.Export(root + Path.Combine("Templates", "temp_1.docx"), root + Path.Combine("Templates_out", "temp_1_out.docx"), data);
                //WordHelper.Export(root + Path.Combine("Templates", "temp_2.docx"), root + Path.Combine("Templates_out", "temp_2_out.docx"), data);
                WordHelper.Export(root + Path.Combine("wwwroot/Templates", "temp_3_stu.docx"), root + Path.Combine("wwwroot/Templates_out", "temp_3_stu_out.docx"), data);
                // sw.Stop();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 获取需要导出的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XiangMuDto GetById(Guid id)
        {
            XiangMuDto query = new XiangMuDto();
            if (_dbContext.XiangMu.Any(x => x.Id == id))
            {
                query = _mapper.Map<XiangMuDto>(_xiangMuService.GetXiangMu(id));
            }
            return query;
        }

        /// <summary>
        /// 第一部分
        /// </summary>
        /// <param name="xiangmu"></param>
        /// <returns></returns>
        public DocX WriteDocf(XiangMuDto xiangmu)
        {
            DocX doc = null;
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();

            try
            {

                var zy = xiangmu.XiangMuZuYuans;
                var fangan = xiangmu.XiangMuFangAn;

                //默认老师
                if (xiangmu.LiXiangLeiXing == 0)
                {
                    doc = DocX.Load("wwwroot/Templates/stuFront.docx");
                }
                else
                {
                    doc = DocX.Load("wwwroot/Templates/teaFront.docx");
                }

                doc.ReplaceText("{year}", year);//年
                doc.ReplaceText("{month}", month);//月

                //项目表
                doc.ReplaceText("{xmmc}", xiangmu.XiangMuMingCheng);//项目名称
                doc.ReplaceText("{xmlb}", xiangmu.XiangMuLeiXingName);//项目类型名称
                doc.ReplaceText("{yjlx}", xiangmu.YanJiuLeiXingName);//研究类型名称
                doc.ReplaceText("{sqr}", xiangmu.ShenQingRenName);//申请人名称
                doc.ReplaceText("{xb}", xiangmu.XingBie);//性别
                doc.ReplaceText("{mz}", xiangmu.MinZu);//名族
                doc.ReplaceText("{csny}", xiangmu.ChuShengNianYue.ToString("yyyy-MM-dd"));//出生年月
                doc.ReplaceText("{tbrq}", xiangmu.CreateDate.ToString("yyyy-MM-dd"));//填表日期

                doc.ReplaceText("{xzzw}", xiangmu.XingZhengZhiWu == null ? "暂无" : xiangmu.XingZhengZhiWu);//行政职务
                doc.ReplaceText("{jgzw}", xiangmu.JiaoGuanZhiWu == null ? "暂无" : xiangmu.JiaoGuanZhiWu);//教官职务
                doc.ReplaceText("{zjzw}", xiangmu.ZhunJiZhiWu == null ? "暂无" : xiangmu.ZhunJiZhiWu);//专技职务
                doc.ReplaceText("{zhxl}", xiangmu.ZuiHouXueLi == null ? "暂无" : xiangmu.ZuiHouXueLi);//最后学历
                doc.ReplaceText("{ssbm}", xiangmu.ShenQingRenBuMenMingCheng);//所属部门
                doc.ReplaceText("{lxdh}", xiangmu.LianXiDianHua);//联系电话
                doc.ReplaceText("{skkm}", xiangmu.ShouKeKeMu == null ? "暂无" : xiangmu.ShouKeKeMu);//授课科目
                doc.ReplaceText("{skdx}", xiangmu.ShouKeDuiXiang == null ? "暂无" : xiangmu.ShouKeDuiXiang);//授课对象
                doc.ReplaceText("{ssqd}", xiangmu.SuoShuQuDui == null ? "暂无" : xiangmu.SuoShuQuDui);//所属区队
                doc.ReplaceText("{xslxdh}", xiangmu.XueShengLianXiDianHua == null ? "" : xiangmu.XueShengLianXiDianHua);//学生联系电话
                doc.ReplaceText("{yjzc}", xiangmu.YanJiuZhuanChang == null ? "暂无" : xiangmu.YanJiuZhuanChang);//研究专长
                doc.ReplaceText("{zdls}", xiangmu.ZhiDaoLaoShi == null ? "暂无" : xiangmu.ZhiDaoLaoShi);//指导老师

                doc.ReplaceText("{yqcg}", xiangmu.YuQiChengGuoLeiXingName);//预期成果
                doc.ReplaceText("{sqjf}", xiangmu.JingFeiZongE.ToString());//申请经费
                doc.ReplaceText("{wcsj}", xiangmu.EndDateTime.ToString("yyyy-MM-dd"));//申请经费

                //组员表
                for (int i = 0; i < zy.Count; i++)
                {
                    doc.ReplaceText("{zyxm" + (i + 1) + "}", zy[i].XiangMuZuChengYuanXingMing);//组员姓名
                    doc.ReplaceText("{zyxb" + (i + 1) + "}", zy[i].XingBie == 0 ? "男" : "女");//组员性别
                    doc.ReplaceText("{zycsny" + (i + 1) + "}", zy[i].ChuShengNianYue.ToString("yyyy-MM-dd"));//组员出生年月
                    doc.ReplaceText("{zyzw" + (i + 1) + "}", zy[i].ZhiWuMingCheng);//组员职务
                    doc.ReplaceText("{zyyjzc" + (i + 1) + "}", zy[i].YanJiuZhuanChang);//组员研究专长
                    doc.ReplaceText("{zyxl" + (i + 1) + "}", zy[i].XueLi);//组员学历
                    doc.ReplaceText("{zyssbm" + (i + 1) + "}", zy[i].SuoSuBuMenMingCheng);//组员所属部门
                }
                //少于7人
                for (int i = 0; i < 7; i++)
                {
                    doc.ReplaceText("{zyxm" + (i + 1) + "}", "");//组员姓名
                    doc.ReplaceText("{zyxb" + (i + 1) + "}", "");//组员性别
                    doc.ReplaceText("{zycsny" + (i + 1) + "}", "");//组员出生年月
                    doc.ReplaceText("{zyzw" + (i + 1) + "}", "");//组员职务
                    doc.ReplaceText("{zyyjzc" + (i + 1) + "}", "");//组员研究专长
                    doc.ReplaceText("{zyxl" + (i + 1) + "}", "");//组员学历
                    doc.ReplaceText("{zyssbm" + (i + 1) + "}", "");//组员所属部门
                }
                //方案表
                doc.ReplaceText("{zzcg}", fangan.ZuiZhongChengGuo);//最终成果
                doc.ReplaceText("{xmfacg}", fangan.XiangMuChengGuo);//项目成果
                doc.ReplaceText("{faxt}", fangan.XiangMuXuanTi);//方案选题
                doc.ReplaceText("{fafa}", fangan.XiangMuFangAn1);//方案 方案
                doc.ReplaceText("{fayjjc}", fangan.YanJiuJiChu);//方案研究基础
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doc;
        }
        /// <summary>
        /// 第二部分（经费以前）
        /// </summary>
        /// <param name="jinFeis"></param>
        /// <returns></returns>
        public DocX WriteDocs(List<JingFei> jinFeis)
        {
            DocX doc = null;
            double num = 0;
            try
            {
                doc = DocX.Load("wwwroot/Templates/last.docx");
                //经费表
                jinFeis.ForEach(x =>
                {
                    num += x.JinE.Value;
                    switch (x.MingCheng)
                    {
                        case "资料费":
                            doc.ReplaceText("{jfje1}", x.JinE.ToString());
                            break;
                        case "调研差旅费":
                            doc.ReplaceText("{jfje2}", x.JinE.ToString());
                            break;
                        case "材料费":
                            doc.ReplaceText("{jfje3}", x.JinE.ToString());
                            break;
                        case "制作费":
                            doc.ReplaceText("{jfje4}", x.JinE.ToString());
                            break;
                        case "软件开发费":
                            doc.ReplaceText("{jfje5}", x.JinE.ToString());
                            break;
                        case "咨询费":
                            doc.ReplaceText("{jfje6}", x.JinE.ToString());
                            break;
                        case "知识产权服务费等费用":
                            doc.ReplaceText("{jfje7}", x.JinE.ToString());
                            break;
                        case "其他":
                            doc.ReplaceText("{jfje8}", x.JinE.ToString());
                            break;
                    }

                });
                doc.ReplaceText("{zongjine}", num.ToString());
                //默认给空
                for (int i = 1; i < 9; i++)
                {
                    doc.ReplaceText("{jfje" + i + "}", " ");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="docPath"></param>
        /// <returns></returns>
        public Task<string> WriteDocs(Guid id, string docPath)
        {
            DocX docX = DocX.Create(docPath, DocumentTypes.Document);
            var query = GetById(id);
            var docf = WriteDocf(query);
            docX.InsertDocument(docf);
            var docs = WriteDocs(query.JingFeis);
            docX.InsertDocument(docs);
            docX.SaveAs(docPath);
            docX.Dispose();
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetPrint(Guid id)
        {
            var docpath = "wwwroot/Templates_out/上海公安学院科研项目.docx";
            WriteDocs(id, docpath);
            return docpath.Replace("wwwroot/", "");
        }



    }
}

