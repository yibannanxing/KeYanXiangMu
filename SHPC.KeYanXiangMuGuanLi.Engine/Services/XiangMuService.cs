using SHPC.KeYanXiangMuGuanLi.Engine.DTOs;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Services
{
    public class XiangMuService
    {

        private readonly KeYanGuanLiContext _dbContext;

        public XiangMuService(KeYanGuanLiContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 保存申请
        /// </summary>
        /// <returns></returns>
        public bool SaveXiangMu(XiangMu xiangmu, XiangMuFangAn xmfa)
        {
            if (xiangmu.Id == Guid.Empty)//新增
            {
                #region 新增项目
                xiangmu.Id = Guid.NewGuid();
                xiangmu.CreateDate = xiangmu.LastUpdateDate = DateTime.Now;
                //xiang.ShenQingRenId = xuesheng.ShenQingRenId;
                //xiang.ShenQingRenName = xuesheng.ShenQingRenName;
                //xiang.ShenQingRenBuMenId = xuesheng.ShenQingRenBuMenId;//学生 填写老师的部门
                //xiang.ShenQingRenBuMenMingCheng = xuesheng.ShenQingRenBuMenMingCheng;
                #endregion

                #region 新增方案
                //xmfa.Id = Guid.NewGuid();
                xmfa.XiangMuId = xiangmu.Id;
                xmfa.CreateDate = xmfa.LastUpdateDate = DateTime.Now;
                #endregion

                _dbContext.XiangMu.Add(xiangmu);
                _dbContext.XiangMuFangAn.Add(xmfa);
            }
            else//编辑
            {
                if (_dbContext.XiangMu.Any(p => p.Id == xiangmu.Id))
                {
                    #region 编辑申请表
                    var single = _dbContext.XiangMu.SingleOrDefault(p => p.Id == xiangmu.Id);
                    single.XiangMuMingCheng = xiangmu.XiangMuMingCheng;
                    single.XiangMuLeiXing = xiangmu.XiangMuLeiXing;
                    single.LiXiangLeiXing = xiangmu.LiXiangLeiXing;
                    //single.ShenQingRenId = xiangmu.ShenQingRenId;
                    //single.ShenQingRenName = xiangmu.ShenQingRenName;
                    //single.ShenQingRenBuMenId = xiangmu.ShenQingRenBuMenId;//学生 填写老师的部门
                    //single.ShenQingRenBuMenMingCheng = xiangmu.ShenQingRenBuMenMingCheng;
                    single.XingBie = xiangmu.XingBie;
                    single.MinZu = xiangmu.MinZu;
                    single.ChuShengNianYue = xiangmu.ChuShengNianYue;
                    single.YanJiuLeiXing = xiangmu.YanJiuLeiXing;
                    single.ShouKeKeMu = xiangmu.ShouKeKeMu;
                    single.ShouKeDuiXiang = xiangmu.ShouKeDuiXiang;
                    single.SuoShuQuDui = xiangmu.SuoShuQuDui;
                    single.XueShengLianXiDianHua = xiangmu.XueShengLianXiDianHua;
                    single.ZhiDaoLaoShi = xiangmu.ZhiDaoLaoShi;
                    single.YanJiuLeiXing = xiangmu.YanJiuLeiXing;
                    single.XingZhengZhiWu = xiangmu.XingZhengZhiWu;
                    single.JiaoGuanZhiWu = xiangmu.JiaoGuanZhiWu;
                    single.ZhunJiZhiWu = xiangmu.ZhunJiZhiWu;
                    single.ZuiHouXueLi = xiangmu.ZuiHouXueLi;
                    single.LianXiDianHua = xiangmu.LianXiDianHua;
                    single.KeTiZuChengYuanRenSu = xiangmu.KeTiZuChengYuanRenSu;
                    single.YuQiChengGuoLeiXing = xiangmu.YuQiChengGuoLeiXing;
                    single.CreateDate = xiangmu.CreateDate;
                    single.LastUpdateDate = DateTime.Now;
                    single.StartDateTime = xiangmu.StartDateTime;
                    single.EndDateTime = xiangmu.EndDateTime;
                    single.YanQiDate = xiangmu.YanQiDate;
                    single.JingFeiZongE = xiangmu.JingFeiZongE;
                    single.Status = xiangmu.Status;
                    //后续会有AutoMapper来做对象映射
                    //xiang.LastUpdateDate = xuesheng.LastUpdateDate;
                    #endregion

                    #region 编辑项目方案
                    var fangan = _dbContext.XiangMuFangAn.SingleOrDefault(x => x.XiangMuId == xiangmu.Id);
                    fangan.ZuiZhongChengGuo = xmfa.ZuiZhongChengGuo;
                    fangan.XiangMuChengGuo = xmfa.XiangMuChengGuo;
                    fangan.XiangMuXuanTi = xmfa.XiangMuXuanTi;
                    fangan.XiangMuFangAn1 = xmfa.XiangMuFangAn1;
                    fangan.YanJiuJiChu = xmfa.YanJiuJiChu;
                    fangan.LastUpdateDate = DateTime.Now;
                    #endregion

                }
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 保存经费
        /// </summary>
        /// <param name="jf"></param>
        /// <returns></returns>
        public bool SaveJingFei(JingFei jf,Guid xiangmuId)
        {
            if (jf.Id == Guid.Empty)
            {
                jf.Id = Guid.NewGuid();
                jf.XiangMuId = xiangmuId;
                jf.CreateDate = jf.LastUpdateDate = DateTime.Now;
                _dbContext.JingFei.Add(jf);
            }
            else
            {
                if (_dbContext.JingFei.Any(x => x.Id == jf.Id))
                {
                    var jingfei = _dbContext.JingFei.SingleOrDefault(x => x.Id == jf.Id);
                    jingfei.MingCheng = jf.MingCheng;
                    jingfei.JinE = jf.JinE;
                    jingfei.PaiXu = jf.PaiXu;
                    jingfei.LastUpdateDate = DateTime.Now;
                }

            }
            return _dbContext.SaveChanges() > 0;

        }

        /// <summary>
        /// 新增组员
        /// </summary>
        /// <param name="xmzy"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SaveXiangMuZuYuan(XiangMuZuYuan xmzy, Guid id)
        {
            if (xmzy.Id == Guid.Empty)
            {
                xmzy.Id = Guid.NewGuid();
                //xmzy.XiangMuId = id;
                xmzy.CreateDate = xmzy.LastUpdateDate = DateTime.Now;
                _dbContext.XiangMuZuYuan.Add(xmzy);
            }
            else
            {
                if (_dbContext.XiangMuZuYuan.Any(x => x.Id == xmzy.Id))
                {
                    var zuyuan = _dbContext.XiangMuZuYuan.Find(xmzy.Id);
                    zuyuan.XiangMuZuChengYuanId = xmzy.XiangMuZuChengYuanId;
                    zuyuan.XiangMuZuChengYuanXingMing = xmzy.XiangMuZuChengYuanXingMing;
                    zuyuan.XingBie = xmzy.XingBie;
                    zuyuan.ChuShengNianYue = xmzy.ChuShengNianYue;
                    zuyuan.ZhiWuMingCheng = xmzy.ZhiWuMingCheng;
                    zuyuan.YanJiuZhuanChang = xmzy.YanJiuZhuanChang;
                    zuyuan.XueLi = xmzy.XueLi;
                    zuyuan.SuoSuBuMenId = xmzy.SuoSuBuMenId;
                    zuyuan.SuoSuBuMenMingCheng = xmzy.SuoSuBuMenMingCheng;
                    zuyuan.LastUpdateDate = DateTime.Now;
                }
            }
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelXiangMu(Guid id)
        {
            if (id != null)
            {
                if (_dbContext.XiangMu.Any(x => x.Id == id))
                {
                    #region 删除申请项目
                    _dbContext.XiangMu.Find(id).Status = Convert.ToInt32(MeiJuUtils.XiangMuZhuangTaiName.已删除);
                    #endregion

                   
                }
            }
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 总览页面 部门 研究成果
        /// </summary>
        /// <returns></returns>
        public List<XiangMu> XiangMuShow(int skip, int take,out int totalRows)
        {
            var liu = _dbContext.XiangMu.Where(x => x.Status != Convert.ToInt32(MeiJuUtils.XiangMuZhuangTaiName.已删除));
            totalRows = liu.Count();

            return liu.OrderByDescending(x=>x.CreateDate)
                .ThenBy(x=>x.JingFeiZongE).Skip(skip).Take(take).ToList();
            
        }

        /// <summary>
        /// 模糊查找
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="ApplyName">申请名称</param>
        /// <param name="type">类型</param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<XiangMu> XiangMuShow(int skip, int take, string applyName, string bumen, int xiangmuleixing,int yanjiuleixing, string startTime, string endTime, out int totalRows)
        {
            var linq = from xm in _dbContext.XiangMu
                       where xm.Status!=(int)MeiJuUtils.XiangMuZhuangTaiName.已删除
                       select xm;
            if (!string.IsNullOrEmpty(applyName))
            {
                linq = linq.Where(x => x.ShenQingRenName.Contains(applyName));
            }
           else  if (!string.IsNullOrEmpty(bumen))
            {
                linq = linq.Where(x => x.ShenQingRenBuMenMingCheng.Contains(bumen));
            }
            else if (!string.IsNullOrEmpty(xiangmuleixing.ToString())&&xiangmuleixing!=-1)
            {
                linq = linq.Where(x => x.XiangMuLeiXing== xiangmuleixing);
            }
            else if (!string.IsNullOrEmpty(yanjiuleixing.ToString())&& yanjiuleixing != -1)
            {
                linq = linq.Where(x => x.YanJiuLeiXing== yanjiuleixing);
            }
            else if (!string.IsNullOrEmpty(startTime)&& string.IsNullOrEmpty(endTime))
            {
                linq = linq.Where(x => x.StartDateTime>= Convert.ToDateTime(startTime));
            }
            else if (!string.IsNullOrEmpty(endTime)&& string.IsNullOrEmpty(startTime))
            {
                linq = linq.Where(x => x.EndDateTime<= Convert.ToDateTime(endTime));
            }
            else if (!string.IsNullOrEmpty(endTime)&& !string.IsNullOrEmpty(startTime))
            {
                linq = linq.Where(x => x.StartDateTime >= Convert.ToDateTime(startTime)&&x.EndDateTime<= Convert.ToDateTime(endTime));
            }
            totalRows = linq.Count();
            return linq.OrderByDescending(x=>x.EndDateTime).Skip(skip).Take(take).ToList();
        }
        /// <summary>
        /// 个人
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="xiangmuleixing"></param>
        /// <param name="yanjiuleixing"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="totalRows"></param>
        /// <returns></returns>
        public List<XiangMu> XiangMuShow(int skip, int take, Guid userid ,int xiangmuleixing, int yanjiuleixing, string startTime, string endTime, out int totalRows)
        {

            var linq = from xm in _dbContext.XiangMu where xm.ShenQingRenId==userid&&
                       xm.Status != (int)MeiJuUtils.XiangMuZhuangTaiName.已删除
                       select xm;
           
           if (!string.IsNullOrEmpty(xiangmuleixing.ToString()) && xiangmuleixing != -1)
            {
                linq = linq.Where(x => x.XiangMuLeiXing == xiangmuleixing);
            }
            else if (!string.IsNullOrEmpty(yanjiuleixing.ToString()) && yanjiuleixing != -1)
            {
                linq = linq.Where(x => x.YanJiuLeiXing == yanjiuleixing);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                linq = linq.Where(x => x.StartDateTime >= Convert.ToDateTime(startTime));
            }
            else if (!string.IsNullOrEmpty(endTime) && string.IsNullOrEmpty(startTime))
            {
                linq = linq.Where(x => x.EndDateTime <= Convert.ToDateTime(endTime));
            }
            else if (!string.IsNullOrEmpty(endTime) && !string.IsNullOrEmpty(startTime))
            {
                linq = linq.Where(x => x.StartDateTime >= Convert.ToDateTime(startTime) && x.EndDateTime <= Convert.ToDateTime(endTime));
            }
            totalRows = linq.Count();
            return linq.OrderByDescending(x => x.EndDateTime).Skip(skip).Take(take).ToList();
        }

        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XiangMu GetXiangMu(Guid xiangmuid)
        {
            return _dbContext.XiangMu.Find(xiangmuid);
        }
        /// <summary>
        /// 延期功能
        /// </summary>
        /// <param name="xiangmu"></param>
        /// <returns></returns>
        public bool YanQiXiangMu(Guid xiangmuId,DateTime yanQiDate)
        {
            if (_dbContext.XiangMu.Any(x=>x.Id==xiangmuId))
            {
                var xm = _dbContext.XiangMu.Find(xiangmuId);
                if (xm.Status==Convert.ToInt32( MeiJuUtils.XiangMuZhuangTaiName.通过))
                {
                    xm.Status =Convert.ToInt32(MeiJuUtils.XiangMuZhuangTaiName.延期);
                    xm.YanQiDate = yanQiDate;
                }
               
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 审批功能
        /// </summary>
        /// <param name="xiangmu"></param>
        /// <returns></returns>
        public bool IsPass(XiangMu xiangmu)
        {
            return true;
        }

    }
}
