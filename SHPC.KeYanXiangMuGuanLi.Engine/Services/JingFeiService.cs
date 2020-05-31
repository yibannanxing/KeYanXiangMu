using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Services
{
    public class JingFeiService
    {
        private readonly KeYanGuanLiContext _dbContext;
        public JingFeiService(KeYanGuanLiContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 删除经费
        /// </summary>
        /// <param name="jingfeiid"></param>
        /// <param name="xiangmuid"></param>
        /// <returns></returns>
        public bool DelJingFei(Guid jingfeiid)
        {
            if (_dbContext.JingFei.Any(x => x.Id == jingfeiid))
            {
                _dbContext.JingFei.Remove(_dbContext.JingFei.Find(jingfeiid));
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 编辑经费
        /// </summary>
        /// <param name="xiangmuid"></param>
        /// <param name="jingfeiid"></param>
        /// <returns></returns>
        public bool SaveJinFei(JingFei jingfei)
        {
            if (_dbContext.JingFei.Any(x => x.Id == jingfei.Id))
            {
                var jf = _dbContext.JingFei.Find(jingfei.Id);
                jf.MingCheng = jingfei.MingCheng;
                jf.JinE = jingfei.JinE;
                jf.PaiXu = jingfei.PaiXu;
                jf.LastUpdateDate = DateTime.Now;
            }
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>
        /// 获取项目下的经费(未排序)
        /// </summary>
        /// <param name="XiangMuId"></param>
        /// <returns></returns>
        public List<JingFei> GetJinFei(Guid XiangMuId)
        {
            return _dbContext.JingFei.Where(x => x.XiangMuId == XiangMuId).ToList();
        }
        //根据项目id 进行排序
        /// <summary>
        /// 获取项目经费
        /// </summary>
        /// <param name="XiangMuId"></param>
        /// <returns></returns>
        public List<JingFei> JingFeiPaiXu(Guid XiangMuId)
        {
            return _dbContext.JingFei.Where(x => x.XiangMuId == XiangMuId).OrderBy(x => x.XiangMuId == XiangMuId).ToList();
        }
    }
}
