using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Services
{
   public class XiangMuZuYuanService
    {
        private readonly KeYanGuanLiContext _dbContext;

        public XiangMuZuYuanService(KeYanGuanLiContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 删除组员
        /// </summary>
        /// <param name="zuyuanid"></param>
        /// <param name="xiangmuid"></param>
        /// <returns></returns>
        public bool DelZuYuan(Guid zuyuanid)
        {
            if (_dbContext.XiangMuZuYuan.Any(x => x.Id == zuyuanid))
            {
                _dbContext.Remove(_dbContext.XiangMuZuYuan.Find(zuyuanid));
            }
            return _dbContext.SaveChanges() > 0;

        }
        /// <summary>
        /// 编辑组员
        /// </summary>
        /// <param name="xiangmuid"></param>
        /// <param name="zuyuan"></param>
        /// <returns></returns>
        public bool SaveZuYuan(XiangMuZuYuan zuyuan) {
            if (_dbContext.XiangMuZuYuan.Any(x=>x.Id==zuyuan.Id))
            {
                var zy = _dbContext.XiangMuZuYuan.Find(zuyuan.Id);
                zy.XiangMuZuChengYuanXingMing = zuyuan.XiangMuZuChengYuanXingMing;
                zy.XingBie = zuyuan.XingBie;
                zy.ChuShengNianYue = zuyuan.ChuShengNianYue;
                zy.ZhiWuMingCheng = zuyuan.ZhiWuMingCheng;
                zy.YanJiuZhuanChang = zuyuan.YanJiuZhuanChang;
                zy.XueLi = zuyuan.XueLi;
                zy.SuoSuBuMenMingCheng = zuyuan.SuoSuBuMenMingCheng;
                zy.LastUpdateDate = zuyuan.LastUpdateDate;

            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取项目下的组员
        /// </summary>
        /// <param name="XiangMuId"></param>
        /// <returns></returns>
        public List<XiangMuZuYuan> GetZuYuan(Guid XiangMuId) {
            return _dbContext.XiangMuZuYuan.Where(x => x.XiangMuId == XiangMuId).ToList();
        }

    }
}
