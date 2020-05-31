using AutoMapper;
using SHPC.KeYanXiangMuGuanLi.Engine.Models;
using SHPC.KeYanXiangMuGuanLi.Engine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHPC.KeYanXiangMuGuanLi.Engine.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile(KeYanGuanLiContext keYanGuanLiContext)
        {
            CreateMap<XiangMu, XiangMuDto>()
                  .ForMember(d => d.XiangMuLeiXingName, opt =>
                     {
                         opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.XiangMuLeiXingName), e.XiangMuLeiXing));
                     })
                  .ForMember(d => d.LiXiangLeiXingName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.LiXiangLeiXingName), e.LiXiangLeiXing));
                  })
                  .ForMember(d => d.YanJiuLeiXingName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.YanJiuLeiXingName), e.YanJiuLeiXing));
                  })
                  .ForMember(d => d.YuQiChengGuoLeiXingName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.YuQiChengGuoLeiXingName), e.YuQiChengGuoLeiXing));
                  })
                   .ForMember(d => d.XiangMuZhuangTaiName, opt =>
                   {
                       opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.XiangMuZhuangTaiName), e.Status));
                   })
                   .ForMember(d => d.JingFeis, src => src.MapFrom((s, d, i, context) =>
                    {
                        var jfs = keYanGuanLiContext.JingFei.Where(x => x.XiangMuId == s.Id).ToList();
                        if (jfs.Count() > 0)
                            return jfs;
                        else
                            return new List<JingFei>();
                    }))
                  .ForMember(d => d.XiangMuZuYuans, src => src.MapFrom((s, d, i, context) =>
                  {
                      var zys = keYanGuanLiContext.XiangMuZuYuan.Where(x => x.XiangMuId == s.Id).ToList();
                      if (zys.Count() > 0)
                          return zys;
                      else
                          return new List<XiangMuZuYuan>();

                  }))
                  .ForMember(d => d.XiangMuFangAn, src => src.MapFrom((s, d, i, context) =>
                  {
                      var xmfa = keYanGuanLiContext.XiangMuFangAn.SingleOrDefault(x => x.XiangMuId == s.Id);

                      if (xmfa != null)
                          return xmfa;
                      else
                          return new XiangMuFangAn();

                  }));
            CreateMap<XiangMuDto, XiangMu>();
            CreateMap<XiangMuChengGuo, XiangMuChengGuoDto>()
                .ForMember(d => d.ChengGuoLeiXingName, opt =>
                {
                    opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ChengGuoLeiXingName), e.ChengGuoLeiXing));
                })
                .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                {
                    var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.CreateDateTime).ThenBy(x => x.WenJianMingCheng).ToList();
                    return fjs;
                }));

            CreateMap<JingFei, JingFei>();
            CreateMap<XiangMuFangAn, XiangMuFangAn>();
            CreateMap<XiangMuZuYuan, XiangMuZuYuan>();
            CreateMap<FuJian, FuJianDto>();

            CreateMap<JieXiang, JieXiangDto>()
                 .ForMember(d => d.jieXiangJingFeis, src => src.MapFrom((s, d, i, context) =>
                 {
                     var jxjfs = keYanGuanLiContext.JieXiangJingFei.Where(x => x.JieXiangId == s.Id).ToList();
                     if (jxjfs.Count() > 0)
                     {
                         return jxjfs;
                     }
                     else
                     {
                         return new List<JieXiangJingFei>();
                     }
                 }))
                 .ForMember(d => d.jieXiangZuYuans, src => src.MapFrom((s, d, i, context) =>
                 {
                     var jfzys = keYanGuanLiContext.JieXiangZuYuan.Where(x => x.JieXiangId == s.Id).ToList();
                     if (jfzys.Count() > 0)
                     {
                         return jfzys;
                     }
                     else
                     {
                         return new List<JieXiangZuYuan>();
                     }
                 }));
            //成果科研项目
            CreateMap<CgKeYanXiangMu, CgKeYanXiangMuDto>()
                .ForMember(d => d.cgCanYuZhes, src => src.MapFrom((s, d, i, context) =>
                {
                    var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id).OrderBy(x => x.PaiXu).ToList();
                    if (cyzs.Count() > 0)
                    {
                        return cyzs;
                    }
                    else
                    {
                        return new List<CgCanYuZhe>();
                    }
                }))
                .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                {
                    var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.PaiXu).ToList();
                    if (fjs.Count() > 0)
                    {
                        return fjs;
                    }
                    else
                    {
                        return new List<FuJian>();
                    }
                }))
                .ForMember(d => d.xiangMuLeiBieName, opt =>
                {
                    opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.xiangMuLeiBieName), e.XiangMuLeiBie));
                })
                .ForMember(d => d.HuoJiangLeiXingName, opt =>
                 {
                     opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.HuoJiangLeiXing), e.XiangMuHuoJiangJiBie));
                 })
                .ForMember(d => d.zuyuans, src => src.MapFrom((s, d, i, context) =>
                {
                    var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id).Select(x => x.Name);
                    var zuyuans = "";
                    if (cyzs.Count() > 0)
                    {
                        return string.Join("，", cyzs);
                    }
                    else
                    {
                        return zuyuans;
                    }
                }))
                 .ForMember(d => d.XiangMuJieBieName, opt =>
                 {
                     opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.XiangMuJiBie), e.XiangMuJiBie));
                 })
                  .ForMember(d => d.XiangMuZhuangTaiName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.XiangMuZhuangTai), e.XiangMuZhuangTai));
                  })
                 .ForMember(d => d.PiZunLiXiangShiJianName, src => src.MapFrom((s, d, i, context) =>
                 {
                     var time = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                     if (time != null)
                         return time.LiXiangShiJian == null ? "" : Convert.ToDateTime(time.LiXiangShiJian).ToString("yyyy-MM-dd");
                     else
                         return "";
                 }))
                    .ForMember(d => d.PiZunJieXiangShiJianName, src => src.MapFrom((s, d, i, context) =>
                    {
                        var time = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                        if (time != null)
                            return time.GongBuJieXiangShiJian == null ? "" : Convert.ToDateTime(time.GongBuJieXiangShiJian).ToString("yyyy-MM-dd");
                        else
                            return "";
                    }))
                    .ForMember(d => d.IsYouYuanKeZhuGuanName, src => src.MapFrom((s, d, i, context) =>
                    {
                        var query = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                        if (query != null)
                            return query.IsYuanKeYanZuGuanBmgl == null ? "" : MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(query.IsYuanKeYanZuGuanBmgl));
                        else
                            return "";
                    }))
                      .ForMember(d => d.IsWeiBenRenZhiDaoName, src => src.MapFrom((s, d, i, context) =>
                      {
                          var query = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                          if (query != null)
                              return (query.IsBenRenZhiDao == null)||(query.IsBenRenZhiDao=="null") ? "" : MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(query.IsBenRenZhiDao));
                          else
                              return "";
                      }))
                       .ForMember(d => d.XiangMuHuoJiangShiJianName, src => src.MapFrom((s, d, i, context) =>
                       {
                           var time = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                           if (time != null)
                               return time.XiangMuHuoJiangTime == null ? "" : Convert.ToDateTime(time.XiangMuHuoJiangTime).ToString("yyyy-MM-dd");
                           else
                               return "";
                       }))
                         .ForMember(d => d.XiangMuCaiNaJiBieName, src => src.MapFrom((s, d, i, context) =>
                         {
                             var query = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                             if (query != null)
                                 return query.XiangMuChengGuoCaiNaJiBie == null ? "" : MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.XiangMuCaiNaJiBie), Convert.ToInt32(query.XiangMuChengGuoCaiNaJiBie));
                             else
                                 return "";
                         }))
                        .ForMember(d => d.XiangMuChengGuoCaiNaShiJianName, src => src.MapFrom((s, d, i, context) =>
                        {
                            var time = keYanGuanLiContext.CgKeYanXiangMu.Find(s.Id);
                            if (time != null)
                                return time.XiangMuChengGuoCaiNaTime == null ? "" : Convert.ToDateTime(time.XiangMuChengGuoCaiNaTime).ToString("yyyy-MM-dd");
                            else
                                return "";
                        }))
                 ;
            CreateMap<CgKeYanXiangMuDto, CgKeYanXiangMu>();

            //成果 著作
            CreateMap<CgZuZhuo, CgZhuZuoDto>()
                 .ForMember(d => d.cgCanYuZhes, src => src.MapFrom((s, d, i, context) =>
                 {
                     var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id).OrderBy(x => x.PaiXu).ToList();
                     if (cyzs.Count() > 0)
                     {
                         return cyzs;
                     }
                     else
                     {
                         return new List<CgCanYuZhe>();
                     }
                 }))
                .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                {
                    var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.PaiXu).ToList();
                    if (fjs.Count() > 0)
                    {
                        return fjs;
                    }
                    else
                    {
                        return new List<FuJian>();
                    }
                }))
                 .ForMember(d => d.ZuZhuoHuoJiangJiBieName, opt =>
                 {
                     opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.HuoJiangLeiXing), e.ZuZhuoHuoJiangJiBie));
                 })
                  .ForMember(d => d.zuyuans, src => src.MapFrom((s, d, i, context) =>
                  {
                      var cyzs = keYanGuanLiContext.CgCanYuZhe.OrderBy(x => x.PaiXu).Where(x => x.CgId == s.Id).Select(x => x.Name);
                      var zuyuans = "";
                      if (cyzs.Count() > 0)
                      {
                          return string.Join("，", cyzs);
                      }
                      else
                      {
                          return zuyuans;
                      }
                  }))
                  .ForMember(d => d.ZhuZuoLeiBieName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ZhuZhuo), Convert.ToInt32(e.LeiBie)));
                  })
                  .ForMember(d => d.ChuBanSheJiBieName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ChuBanShe), Convert.ToInt32(e.ChuBanSeJiBie)));
                  })
                  .ForMember(d => d.ChuBanShiJianName, src => src.MapFrom((s, d, i, context) =>
                  {
                      var time = keYanGuanLiContext.CgZuZhuo.Find(s.Id);
                      if (time != null)
                          return Convert.ToDateTime(time.ChuBanShiJian).ToString("yyyy-MM-dd");
                      else
                          return "";
                  }))
                    .ForMember(d => d.IsBiaoZhuXueYuanName, opt =>
                    {
                        opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsBiaoZhuXueYuan)));
                    })
                   .ForMember(d => d.ZhuZhuoHuoJiangShiJianName, src => src.MapFrom((s, d, i, context) =>
                     {
                         var time = keYanGuanLiContext.CgZuZhuo.Find(s.Id);
                         if (time != null)
                             return time.ZuZhuoHuoJiangShiJian == null ? "" : Convert.ToDateTime(time.ZuZhuoHuoJiangShiJian).ToString("yyyy-MM-dd");
                         //return Convert.ToDateTime(time.ZuZhuoHuoJiangShiJian).ToString("yyyy-MM-dd");
                         else
                             return "";
                     }))
                ;
            // 教材
            CreateMap<CgJiaoCai, CgJiaoCaiDto>()
                 .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                 {
                     var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.PaiXu).ToList();
                     if (fjs.Count() > 0)
                     {
                         return fjs;
                     }
                     else
                     {
                         return new List<FuJian>();
                     }
                 }))
                  .ForMember(d => d.jiaoCaiHuoJiangJiBieName, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.HuoJiangLeiXing), e.JiaoCaiHuoJiangJiBie));
                  })
                    .ForMember(d => d.ChuBanSheJiBieName, opt =>
                    {
                        opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ChuBanShe), Convert.ToInt32(e.ChuBanSheJiBie)));
                    })
                       .ForMember(d => d.ChuBanShiJianName, src => src.MapFrom((s, d, i, context) =>
                       {
                           var time = keYanGuanLiContext.CgJiaoCai.Find(s.Id);
                           if (time != null)
                               return time.ChuBanShiJian == null ? "" : Convert.ToDateTime(time.ChuBanShiJian).ToString("yyyy-MM-dd");
                           else
                               return "";
                       }))
                 .ForMember(d => d.CanBianQingKuangName, opt =>
                 {
                     opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.CanBianQingKuang), Convert.ToInt32(e.CanBianQingKuang)));
                 })
                   .ForMember(d => d.IsBiaoZhuXueYuanName, opt =>
                   {
                       opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsBiaoZhuXueYuan)));
                   })
                     .ForMember(d => d.JiaoCaiHuoJiangShiJianName, src => src.MapFrom((s, d, i, context) =>
                        {
                            var time = keYanGuanLiContext.CgJiaoCai.Find(s.Id);
                            if (time != null)
                                return time.JiaoCaiHuoJiangShiJian == null ? "" : Convert.ToDateTime(time.JiaoCaiHuoJiangShiJian).ToString("yyyy-MM-dd");
                            else
                                return "";
                        }))
                ;
            //成果 论文
            CreateMap<CgLunWen, Cg_LunWenDto>()
                  .ForMember(d => d.LunWenLeiBieMingCheng, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.LunWenLeiBie), e.LunWenLeiBie));
                  })
                   .ForMember(d => d.LunWenZaiTiMingCheng, opt =>
                   {
                       opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.LunWenZaiTi), e.ZaiTiLeiXing));
                   })
                    .ForMember(d => d.ShouLuQingKuangMingCheng, src => src.MapFrom((s, d, i, context) =>
                    {
                        var zidian = keYanGuanLiContext.ZiDian.SingleOrDefault(x => x.FenZhi == int.Parse(s.ShouLuQiangKuang) && x.YiJiMingCheng == "ShouLuQiangKuang");
                        if (zidian != null)
                            return zidian.ErJiMingCheng;
                        else
                            return null;
                    }))

                 .ForMember(d => d.cgCanYuZhes, src => src.MapFrom((s, d, i, context) =>
                 {
                     var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id).OrderBy(x => x.PaiXu).ToList();
                     if (cyzs.Count() > 0)
                     {
                         return cyzs;
                     }
                     else
                     {
                         return new List<CgCanYuZhe>();
                     }
                 }))
                .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                {
                    var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.PaiXu).ToList();
                    if (fjs.Count() > 0)
                    {
                        return fjs;
                    }
                    else
                    {
                        return new List<FuJian>();
                    }
                }))
                .ForMember(d => d.lunWenHuoJiangJiBieName, opt =>
                {
                    opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.HuoJiangLeiXing), e.LunWenHuoJiangJiBie));
                })
                 .ForMember(d => d.zuyuans, src => src.MapFrom((s, d, i, context) =>
                 {
                     var cyzs = keYanGuanLiContext.CgCanYuZhe.OrderBy(x => x.PaiXu).Where(x => x.CgId == s.Id).Select(x => x.Name);
                     if (cyzs.Count() > 0)
                         return string.Join('，', cyzs);
                     else
                         return " ";
                 }))
                  .ForMember(d => d.FaBiaoShiJianName, src => src.MapFrom((s, d, i, context) =>
                  {
                      var time = keYanGuanLiContext.CgLunWen.Find(s.Id);
                      if (time != null)
                          return Convert.ToDateTime(time.FaBiaoNianDu).ToString("yyyy-MM-dd");
                      else
                          return "";
                  }))
                  .ForMember(d => d.LunWenHuoJiangTime, src => src.MapFrom((s, d, i, context) =>
                  {
                      var time = keYanGuanLiContext.CgLunWen.Find(s.Id);
                      if (time != null)
                          return time.LunWenHuoJiangShiJian == null ? "" : Convert.ToDateTime(time.LunWenHuoJiangShiJian).ToString("yyyy-MM-dd");
                      else

                          return "";

                  }))
                   .ForMember(d => d.IsBiaoZhuShangHaiGongAnXueYuan, opt =>
                    {
                        opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsBiaoZhuXueYuan)));
                    })
                    .ForMember(d => d.IsYuDiFang, opt =>
                    {
                        opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsYuDiFangLianHeFaBiao)));
                    })
                     .ForMember(d => d.IsYuHangYe, opt =>
                     {
                         opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsYuHangYeLianHeFaBiao)));
                     })
                 .ForMember(d => d.IsJingWai, opt =>
                 {
                     opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsYuGuoJiLianHeFaBiao)));
                 })
                  .ForMember(d => d.IsKuaXueKe, opt =>
                  {
                      opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsKuaXueKeLunWen)));
                  })
                ;
            //Cg_RuanJianDto 软件与专利
            CreateMap<CgRuanJianYuZhuanLi, Cg_RuanJianDto>()
                 .ForMember(d => d.cgCanYuZhes, src => src.MapFrom((s, d, i, context) =>
                 {
                     var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id && x.Status == 0).OrderBy(x => x.PaiXu).ToList();
                     if (cyzs.Count() > 0)
                     {
                         return cyzs;
                     }
                     else
                     {
                         return new List<CgCanYuZhe>();
                     }
                 }))
                 .ForMember(d => d.cgzhuanlis, src => src.MapFrom((s, d, i, context) =>
                 {
                     var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id && x.Status == 1).OrderBy(x => x.PaiXu).ToList();
                     if (cyzs.Count() > 0)
                     {
                         return cyzs;
                     }
                     else
                     {
                         return new List<CgCanYuZhe>();
                     }
                 }))

                .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                {
                    var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.PaiXu).ToList();
                    if (fjs.Count() > 0)
                    {
                        return fjs;
                    }
                    else
                    {
                        return new List<FuJian>();
                    }
                }))
                 .ForMember(d => d.famingren, src => src.MapFrom((s, d, i, context) =>
                 {
                     var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id && x.Status == 0).Select(x => x.Name);
                     var faminren = "";
                     if (cyzs.Count() > 0)
                     {
                         return string.Join("，", cyzs);
                     }
                     else
                     {
                         return faminren;
                     }
                 }))
                  .ForMember(d => d.zhuanliren, src => src.MapFrom((s, d, i, context) =>
                  {
                      var cyzs = keYanGuanLiContext.CgCanYuZhe.Where(x => x.CgId == s.Id && x.Status == 1).Select(x => x.Name);
                      var zhuanliren = "";
                      if (cyzs.Count() > 0)
                      {
                          return string.Join("，", cyzs);
                      }
                      else
                      {
                          return zhuanliren;
                      }
                  }))
                     .ForMember(d => d.LeiBieName, opt =>
                     {
                         opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.RuanJianLeiBie), Convert.ToInt32(e.LeiXing)));
                     })
                  .ForMember(d => d.KaiFaWanChengRiQiName, src => src.MapFrom((s, d, i, context) =>
                  {
                      var time = keYanGuanLiContext.CgRuanJianYuZhuanLi.Find(s.Id);
                      if (time != null)
                          return time.KaiFaWanChengRiQi == null ? "" : Convert.ToDateTime(time.KaiFaWanChengRiQi).ToString("yyyy-MM-dd");
                      else
                          return "";
                  }))
                   .ForMember(d => d.YingYongJiBieName, src => src.MapFrom((s, d, i, context) =>
                   {
                       var yingyong = keYanGuanLiContext.CgRuanJianYuZhuanLi.Find(s.Id);
                       if (yingyong != null)
                           return yingyong.YingYongJiBie == null ? "" : MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.YingYongJieBie), Convert.ToInt32(yingyong.YingYongJiBie));
                       else
                           return "";
                   }))
                     .ForMember(d => d.IsLianHeHangYeName, opt =>
                     {
                         opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.ShiFou), Convert.ToInt32(e.IsHangYeLianHeZhuanLi)));
                     })
                    .ForMember(d => d.ZhuanLiShenQingRiName, src => src.MapFrom((s, d, i, context) =>
                    {
                        var time = keYanGuanLiContext.CgRuanJianYuZhuanLi.Find(s.Id);
                        if (time != null)
                            return time.ZhuanLiShenQingRi == null ? "" : Convert.ToDateTime(time.ZhuanLiShenQingRi).ToString("yyyy-MM-dd");
                        else
                            return "";
                    }))
                    .ForMember(d => d.ShouQuanGongGaoRiName, src => src.MapFrom((s, d, i, context) =>
                       {
                           var time = keYanGuanLiContext.CgRuanJianYuZhuanLi.Find(s.Id);
                           if (time != null)
                               return time.ShouQuanGongGaoRi == null ? "" : Convert.ToDateTime(time.ShouQuanGongGaoRi).ToString("yyyy-MM-dd");
                           else
                               return "";
                       }))
                ;
            //Cg_QitaDto
            CreateMap<CgQiTa, Cg_QitaDto>()
                .ForMember(d => d.fuJians, src => src.MapFrom((s, d, i, context) =>
                {
                    var fjs = keYanGuanLiContext.FuJian.Where(x => x.ChengGuoId == s.Id).OrderBy(x => x.PaiXu).ToList();
                    if (fjs.Count() > 0)
                    {
                        return fjs;
                    }
                    else
                    {
                        return new List<FuJian>();
                    }
                }))
                ;

            //成果记录
            CreateMap<CgJiLu, CgJiLuDto>()
                .ForMember(d => d.HuoJiangLeiXingName, opt =>
                {
                    opt.MapFrom(e => MeiJuUtils.TryConvertEnumToStr(typeof(MeiJuUtils.HuoJiangLeiXing), e.HuoJiangLeiXing));
                })
                  .ForMember(d => d.cgShenHes, src => src.MapFrom((s, d, i, context) =>
                  {
                      var yijians = keYanGuanLiContext.CgShenHe.Where(x => x.CgId == s.CgId).ToList();
                      if (yijians.Count() > 0)
                      {
                          return yijians;
                      }
                      else
                      {
                          return new List<CgShenHe>();
                      }
                  }))

                ;


        }
    }
}
