using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Services
{
   public class XiangMuChengGuoService
    {
        private readonly KeYanGuanLiContext _dbContext;
        public XiangMuChengGuoService(KeYanGuanLiContext dbConetxt) {
            _dbContext = dbConetxt;
        }
        //通过Id删除文件
        /// <summary>
        /// 删除成果文件
        /// </summary>
        /// <param name="ChengGuoID"></param>
        /// <returns></returns>
        public bool DelChengGuo(Guid ChengGuoID) {
            if (_dbContext.XiangMuChengGuo.Any(x=>x.Id==ChengGuoID))
            {
                _dbContext.XiangMuChengGuo.Remove(_dbContext.XiangMuChengGuo.Find(ChengGuoID));
            }
            return _dbContext.SaveChanges() > 0;
        }
        //通过项目ID获取成果文件
        /// <summary>
        /// 获取这个项目下的成果
        /// </summary>
        /// <param name="XiangMuID"></param>
        /// <returns></returns>
        public List<XiangMuChengGuo> GetChengGuo(Guid XiangMuID)
        {

            return _dbContext.XiangMuChengGuo.Where(x=>x.XiangMuId==XiangMuID).ToList();

        }
    }
}
