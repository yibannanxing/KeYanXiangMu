using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Services
{
    public class XiangMuFangAnService
    {
        private readonly KeYanGuanLiContext _dbContext;
        public XiangMuFangAnService(KeYanGuanLiContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 删除方案
        /// </summary>
        /// <param name="xiangmuid"></param>
        /// <param name="fananid"></param>
        /// <returns></returns>
        public bool DelFangan(Guid fananid) {
            //if (_dbContext.XiangMuFangAn.Any(x=>x.Id== fananid))
            //{
            //    _dbContext.XiangMuFangAn.Remove(_dbContext.XiangMuFangAn.Find(fananid));
            //}
            return _dbContext.SaveChanges()>0;
        }
        /// <summary>
        /// 修改项目方案
        /// </summary>
        /// <param name="FanAn"></param>
        /// <returns></returns>
        public bool SaveFangAn(XiangMuFangAn FanAn) {
            //if (_dbContext.XiangMuFangAn.Any(x=>x.Id==FanAn.Id))
            //{

            //    XiangMuFangAn fa = _dbContext.XiangMuFangAn.Find(FanAn.Id);
            //    fa.XiangMuChengGuo = FanAn.XiangMuChengGuo;
            //    fa.ZuiZhongChengGuo = FanAn.ZuiZhongChengGuo;
            //    fa.XiangMuXuanTi = FanAn.XiangMuXuanTi;
            //    fa.XiangMuFangAn1 = FanAn.XiangMuFangAn1;
            //    fa.LastUpdateDate = DateTime.Now;    
            //}
            return _dbContext.SaveChanges()>0;

        }
        /// <summary>
        /// 获取当前项目下的方案详情
        /// </summary>
        /// <param name="fanganid"></param>
        /// <returns></returns>
        //public List<XiangMuFangAn> GetFangAn(Guid fanganid) {
        //    return _dbContext.XiangMuFangAn.Where(x=>x.Id==fanganid).ToList();
        //}
    }
}
