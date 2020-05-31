using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SHPC.KeYanXiangMuGuanLi.Engine.Models
{
    public partial class KeYanGuanLiContext : DbContext
    {
        public KeYanGuanLiContext()
        {
        }

        public KeYanGuanLiContext(DbContextOptions<KeYanGuanLiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CgCanYuZhe> CgCanYuZhe { get; set; }
        public virtual DbSet<CgJiLu> CgJiLu { get; set; }
        public virtual DbSet<CgJiaoCai> CgJiaoCai { get; set; }
        public virtual DbSet<CgKeYanXiangMu> CgKeYanXiangMu { get; set; }
        public virtual DbSet<CgLunWen> CgLunWen { get; set; }
        public virtual DbSet<CgNianDuKaoHeFen> CgNianDuKaoHeFen { get; set; }
        public virtual DbSet<CgQiTa> CgQiTa { get; set; }
        public virtual DbSet<CgRuanJianYuZhuanLi> CgRuanJianYuZhuanLi { get; set; }
        public virtual DbSet<CgShenHe> CgShenHe { get; set; }
        public virtual DbSet<CgShenHeYiJian> CgShenHeYiJian { get; set; }
        public virtual DbSet<CgZuZhuo> CgZuZhuo { get; set; }
        public virtual DbSet<FuJian> FuJian { get; set; }
        public virtual DbSet<JieXiang> JieXiang { get; set; }
        public virtual DbSet<JieXiangJingFei> JieXiangJingFei { get; set; }
        public virtual DbSet<JieXiangZuYuan> JieXiangZuYuan { get; set; }
        public virtual DbSet<JingFei> JingFei { get; set; }
        public virtual DbSet<XiangMu> XiangMu { get; set; }
        public virtual DbSet<XiangMuChengGuo> XiangMuChengGuo { get; set; }
        public virtual DbSet<XiangMuFangAn> XiangMuFangAn { get; set; }
        public virtual DbSet<XiangMuZuYuan> XiangMuZuYuan { get; set; }
        public virtual DbSet<ZiDian> ZiDian { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=117.184.198.42,31433;initial catalog=KeYanGuanLi;persist security info=True;user id=sa;password=Password01!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CgCanYuZhe>(entity =>
            {
                entity.ToTable("CG_CanYuZhe");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CgJiLu>(entity =>
            {
                entity.ToTable("CG_JiLu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bumen).HasMaxLength(50);

                entity.Property(e => e.CgLeiXingMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CgMingCheng).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.RenDingFanWei).HasMaxLength(200);

                entity.Property(e => e.RenDingLeiXing).HasMaxLength(200);

                entity.Property(e => e.ShangJiShenHeRen).HasMaxLength(50);

                entity.Property(e => e.ShenHeFen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XiangMuLaiYuan).HasMaxLength(50);

                entity.Property(e => e.XiangMuZuChengYuan).HasMaxLength(200);

                entity.Property(e => e.YuanNeiXiangMuBianHao).HasMaxLength(50);
            });

            modelBuilder.Entity<CgJiaoCai>(entity =>
            {
                entity.ToTable("CG_JiaoCai");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CanBianZhangJie).HasMaxLength(100);

                entity.Property(e => e.CanBianZiShu).HasMaxLength(100);

                entity.Property(e => e.ChuBanShe).HasMaxLength(100);

                entity.Property(e => e.ChuBanShiJian).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.HuoJiangMingCheng).HasMaxLength(100);

                entity.Property(e => e.Isbn).HasMaxLength(100);

                entity.Property(e => e.JiaKouFenShuoMing).HasMaxLength(100);

                entity.Property(e => e.JiaoCaiHuoJiangShiJian).HasColumnType("datetime");

                entity.Property(e => e.JiaoCaiMingCheng).HasMaxLength(100);

                entity.Property(e => e.KeYanKaoHeDeFen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.QuanShuZiShu).HasMaxLength(100);

                entity.Property(e => e.ShenHeDeFen).HasMaxLength(100);

                entity.Property(e => e.ShenHeJiaKouFen).HasMaxLength(50);

                entity.Property(e => e.ShiJiDenFen).HasMaxLength(50);

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<CgKeYanXiangMu>(entity =>
            {
                entity.ToTable("CG_KeYanXiangMu");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenRenShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.GongBuJieXiangShiJian).HasColumnType("datetime");

                entity.Property(e => e.IsBenRenZhiDao).HasMaxLength(50);

                entity.Property(e => e.JiHuaWanChengShiJian).HasColumnType("datetime");

                entity.Property(e => e.JiaKouFenShuoMing).HasMaxLength(100);

                entity.Property(e => e.KeYanKaoHeDeFen).HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LiXiangShiJian).HasColumnType("datetime");

                entity.Property(e => e.PiZunLiXiangBuMen).HasMaxLength(200);

                entity.Property(e => e.ShenHeDeFen).HasMaxLength(50);

                entity.Property(e => e.ShenHeJiaKouFen).HasMaxLength(100);

                entity.Property(e => e.ShiJiDeFen).HasMaxLength(100);

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XiangMuChengGuoCaiNaTime).HasColumnType("datetime");

                entity.Property(e => e.XiangMuHuoJiangMingCheng).HasMaxLength(100);

                entity.Property(e => e.XiangMuHuoJiangTime).HasColumnType("datetime");

                entity.Property(e => e.XiangMuHuoJiangZhengShuId).HasMaxLength(100);

                entity.Property(e => e.XiangMuLaiYuan).HasMaxLength(200);

                entity.Property(e => e.XiangMuMingCheng).HasMaxLength(200);

                entity.Property(e => e.XiangMuZiZuZongE).HasMaxLength(100);

                entity.Property(e => e.YuanNeiBenRenShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.YuanNeiXiangMuBianHao).HasMaxLength(100);

                entity.Property(e => e.YuanWaiXiangMuBianHao).HasMaxLength(100);
            });

            modelBuilder.Entity<CgLunWen>(entity =>
            {
                entity.ToTable("CG_lunWen");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenRenShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChuBanSe).HasMaxLength(200);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DangNianQiHao).HasMaxLength(100);

                entity.Property(e => e.FaBiaoNianDu).HasColumnType("datetime");

                entity.Property(e => e.FaBiaoQiKan).HasMaxLength(100);

                entity.Property(e => e.GuoJiBiaoZhunHao).HasMaxLength(100);

                entity.Property(e => e.HuoJiangMingCheng).HasMaxLength(50);

                entity.Property(e => e.JiaKouFenShuoMing).HasMaxLength(100);

                entity.Property(e => e.KeYanKaoHeDeFen).HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("lastUpdateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LunWenHuoJiangShiJian).HasColumnType("datetime");

                entity.Property(e => e.LunWenMingCheng).HasMaxLength(500);

                entity.Property(e => e.LunWenZiShu).HasMaxLength(100);

                entity.Property(e => e.ShenHeDeFen).HasMaxLength(100);

                entity.Property(e => e.ShenHeJiaKouFen).HasMaxLength(50);

                entity.Property(e => e.ShiJiDeFen).HasMaxLength(50);

                entity.Property(e => e.ShouLuQiangKuang).HasMaxLength(100);

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.YuanNeiBenRenShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.ZaiTiMingCheng).HasMaxLength(50);
            });

            modelBuilder.Entity<CgNianDuKaoHeFen>(entity =>
            {
                entity.ToTable("CG_NianDuKaoHeFen");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMenMingCheng).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.JiaoGuanZhiWu).HasMaxLength(50);

                entity.Property(e => e.KaoHeFen).HasMaxLength(100);

                entity.Property(e => e.KeYanFen).HasMaxLength(100);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.NianDu).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.ZhuanJiZhiWu).HasMaxLength(50);
            });

            modelBuilder.Entity<CgQiTa>(entity =>
            {
                entity.ToTable("CG_QiTa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChengGuoNianDu).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.HuoJiangMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JiaKouFenShuoMing).HasMaxLength(100);

                entity.Property(e => e.KeYanKaoHeDeFen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.MingCheng).HasMaxLength(50);

                entity.Property(e => e.ShenHeDeFen).HasMaxLength(100);

                entity.Property(e => e.ShenHeJiaKouFen).HasMaxLength(50);

                entity.Property(e => e.ShiJiDeFen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CgRuanJianYuZhuanLi>(entity =>
            {
                entity.ToTable("CG_RuanJianYuZhuanLi");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BenRenShuMingPaiXu).HasMaxLength(100);

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DengJiHao).HasMaxLength(100);

                entity.Property(e => e.HuoJiangMingCheng).HasMaxLength(100);

                entity.Property(e => e.JiaKouFenShuoMing).HasMaxLength(100);

                entity.Property(e => e.KaiFaWanChengRiQi).HasColumnType("datetime");

                entity.Property(e => e.KeYanKaoHeDeFen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.MingCheng).HasMaxLength(50);

                entity.Property(e => e.QuanLiFanWei).HasMaxLength(100);

                entity.Property(e => e.QuanLiQuDeFangShi).HasMaxLength(100);

                entity.Property(e => e.ShenHeDeFen).HasMaxLength(100);

                entity.Property(e => e.ShenHeJiaKouFen).HasMaxLength(100);

                entity.Property(e => e.ShiJiDeFen).HasMaxLength(100);

                entity.Property(e => e.ShouQuanGongGaoRi).HasColumnType("datetime");

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YingYongJiBie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YuanNeiBenRenShuMingPaiXu).HasMaxLength(100);

                entity.Property(e => e.ZhengShuHao).HasMaxLength(100);

                entity.Property(e => e.ZhuanLiHao).HasMaxLength(100);

                entity.Property(e => e.ZhuanLiShenQingRi).HasColumnType("datetime");
            });

            modelBuilder.Entity<CgShenHe>(entity =>
            {
                entity.ToTable("CG_ShenHe");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.ShangJiShenHeRen).HasMaxLength(50);

                entity.Property(e => e.ShenHeYiJian).HasMaxLength(200);

                entity.Property(e => e.ShenPiRenBuMenMingCheng).HasMaxLength(50);

                entity.Property(e => e.ShenPiRenName).HasMaxLength(50);

                entity.Property(e => e.ShenPiShiJian).HasColumnType("datetime");
            });

            modelBuilder.Entity<CgShenHeYiJian>(entity =>
            {
                entity.ToTable("CG_ShenHeYiJian");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.ShenHeYiJian)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<CgZuZhuo>(entity =>
            {
                entity.ToTable("CG_ZuZhuo");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChuBanSe).HasMaxLength(100);

                entity.Property(e => e.ChuBanShiJian).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FengMianBenRenShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.GongGaoZhangJie).HasMaxLength(200);

                entity.Property(e => e.GongGaoZiShu).HasMaxLength(200);

                entity.Property(e => e.HuoJiangMingCheng).HasMaxLength(200);

                entity.Property(e => e.Isbn).HasMaxLength(100);

                entity.Property(e => e.JiaKouFenShuoMing).HasMaxLength(100);

                entity.Property(e => e.KeYanKaoHeDeFen).HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.QuanShuZiShu).HasMaxLength(200);

                entity.Property(e => e.ShenHeDeFen).HasMaxLength(100);

                entity.Property(e => e.ShenHeJiaKouFen).HasMaxLength(50);

                entity.Property(e => e.ShiJiDeFen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SuoShuNianDu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.YuanNeiBenRenShuMingPaiXu).HasMaxLength(50);

                entity.Property(e => e.ZuZhuoHuoJiangShiJian).HasColumnType("datetime");

                entity.Property(e => e.ZuZuoMingCheng).HasMaxLength(100);
            });

            modelBuilder.Entity<FuJian>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.PaiXu).HasMaxLength(50);
            });

            modelBuilder.Entity<JieXiang>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DianHua)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FuZeRenMingCheng)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JieXiangTime).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.XiangMuMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZhiWuMingCheng)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZuanyYe)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JieXiangJingFei>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.JingFeiMingCheng)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.KaiZhiShuoMing).HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<JieXiangZuYuan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FenGongQingKuang)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.XingMing)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YanJiuZhuanChang)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZhiWu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuanYe)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JingFei>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.MingCheng)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<XiangMu>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChuShengNianYue).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.JiaoGuanZhiWu).HasMaxLength(50);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LianXiDianHua)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MinZu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShenQingRenBuMenMingCheng)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShenQingRenName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShouKeDuiXiang).HasMaxLength(50);

                entity.Property(e => e.ShouKeKeMu).HasMaxLength(50);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.SuoShuQuDui).HasMaxLength(50);

                entity.Property(e => e.XiangMuMingCheng)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.XingBie)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.XingZhengZhiWu).HasMaxLength(50);

                entity.Property(e => e.XueShengLianXiDianHua).HasMaxLength(50);

                entity.Property(e => e.YanJiuZhuanChang).HasMaxLength(50);

                entity.Property(e => e.YanQiDate).HasColumnType("datetime");

                entity.Property(e => e.ZhiDaoLaoShi).HasMaxLength(50);

                entity.Property(e => e.ZhunJiZhiWu).HasMaxLength(50);

                entity.Property(e => e.ZuiHouXueLi).HasMaxLength(50);
            });

            modelBuilder.Entity<XiangMuChengGuo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuMenMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChengGuoMingCheng)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChuBanSe).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.NianQi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZuoZeMingCheng).HasMaxLength(50);
            });

            modelBuilder.Entity<XiangMuFangAn>(entity =>
            {
                entity.HasKey(e => e.XiangMuId);

                entity.Property(e => e.XiangMuId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.XiangMuFangAn1).HasColumnName("XiangMuFangAn");
            });

            modelBuilder.Entity<XiangMuZuYuan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChuShengNianYue).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.SuoSuBuMenId).HasMaxLength(50);

                entity.Property(e => e.SuoSuBuMenMingCheng).HasMaxLength(50);

                entity.Property(e => e.XiangMuZuChengYuanXingMing)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.XueLi).HasMaxLength(50);

                entity.Property(e => e.YanJiuZhuanChang).HasMaxLength(50);

                entity.Property(e => e.ZhiWuMingCheng).HasMaxLength(50);
            });

            modelBuilder.Entity<ZiDian>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BiaoMingCheng)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ErJiMingCheng).HasMaxLength(200);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.YiJiMingCheng)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}
