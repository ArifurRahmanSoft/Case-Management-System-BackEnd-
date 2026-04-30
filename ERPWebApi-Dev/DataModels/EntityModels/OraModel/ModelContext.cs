using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataModels.EntityModels.OraModel
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCaseAdvocate> TCaseAdvocates { get; set; } = null!;
        public virtual DbSet<TCaseCourt> TCaseCourts { get; set; } = null!;
        public virtual DbSet<TCaseDocument> TCaseDocuments { get; set; } = null!;
        public virtual DbSet<TCaseHearing> TCaseHearings { get; set; } = null!;
        public virtual DbSet<TCaseHearingAdvocate> TCaseHearingAdvocates { get; set; } = null!;
        public virtual DbSet<TCaseHearingDoc> TCaseHearingDocs { get; set; } = null!;
        public virtual DbSet<TCaseHearingEvent> TCaseHearingEvents { get; set; } = null!;
        public virtual DbSet<TCaseLand> TCaseLands { get; set; } = null!;
        public virtual DbSet<TCasePriority> TCasePriorities { get; set; } = null!;
        public virtual DbSet<TCaseStatus> TCaseStatuses { get; set; } = null!;
        public virtual DbSet<TCaseType> TCaseTypes { get; set; } = null!;
        public virtual DbSet<TCmnDocumentUpload> TCmnDocumentUploads { get; set; } = null!;
        public virtual DbSet<TCmnLandDocument> TCmnLandDocuments { get; set; } = null!;
        public virtual DbSet<TCmnUploadType> TCmnUploadTypes { get; set; } = null!;
        public virtual DbSet<TCmndocument> TCmndocuments { get; set; } = null!;
        public virtual DbSet<TCmnmenu> TCmnmenus { get; set; } = null!;
        public virtual DbSet<TCmnmenupermission> TCmnmenupermissions { get; set; } = null!;
        public virtual DbSet<TDeedWiseBayadeed> TDeedWiseBayadeeds { get; set; } = null!;
        public virtual DbSet<TDeedWiseLandSubCategory> TDeedWiseLandSubCategories { get; set; } = null!;
        public virtual DbSet<TDeedWiseServey> TDeedWiseServeys { get; set; } = null!;
        public virtual DbSet<TDistrict> TDistricts { get; set; } = null!;
        public virtual DbSet<TDivision> TDivisions { get; set; } = null!;
        public virtual DbSet<TErrorLog> TErrorLogs { get; set; } = null!;
        public virtual DbSet<TKhajnaMutationWise> TKhajnaMutationWises { get; set; } = null!;
        public virtual DbSet<TKhajnaMutationWise01> TKhajnaMutationWise01s { get; set; } = null!;
        public virtual DbSet<TLandCategory> TLandCategories { get; set; } = null!;
        public virtual DbSet<TLandClass> TLandClasses { get; set; } = null!;
        public virtual DbSet<TLandDeed> TLandDeeds { get; set; } = null!;
        public virtual DbSet<TLandDeed111225> TLandDeed111225s { get; set; } = null!;
        public virtual DbSet<TLandDeedBak> TLandDeedBaks { get; set; } = null!;
        public virtual DbSet<TLandDeedBak1> TLandDeedBaks1 { get; set; } = null!;
        public virtual DbSet<TLandDeedBakA> TLandDeedBakAs { get; set; } = null!;
        public virtual DbSet<TLandMutation> TLandMutations { get; set; } = null!;
        public virtual DbSet<TLandOffice> TLandOffices { get; set; } = null!;
        public virtual DbSet<TLandProject> TLandProjects { get; set; } = null!;
        public virtual DbSet<TLandPurchaser> TLandPurchasers { get; set; } = null!;
        public virtual DbSet<TLandSeller> TLandSellers { get; set; } = null!;
        public virtual DbSet<TLandSubCategory> TLandSubCategories { get; set; } = null!;
        public virtual DbSet<TMouza> TMouzas { get; set; } = null!;
        public virtual DbSet<TMutationWiseDag> TMutationWiseDags { get; set; } = null!;
        public virtual DbSet<TMutationWiseDeed> TMutationWiseDeeds { get; set; } = null!;
        public virtual DbSet<TMutationWiseLandClass> TMutationWiseLandClasses { get; set; } = null!;
        public virtual DbSet<TPurchaser> TPurchasers { get; set; } = null!;
        public virtual DbSet<TRegistryOffice> TRegistryOffices { get; set; } = null!;
        public virtual DbSet<TRoleSetup> TRoleSetups { get; set; } = null!;
        public virtual DbSet<TSeller> TSellers { get; set; } = null!;
        public virtual DbSet<TServey> TServeys { get; set; } = null!;
        public virtual DbSet<TServeyType> TServeyTypes { get; set; } = null!;
        public virtual DbSet<TSysUser> TSysUsers { get; set; } = null!;
        public virtual DbSet<TThana> TThanas { get; set; } = null!;
        public virtual DbSet<TThanaTemp> TThanaTemps { get; set; } = null!;
        public virtual DbSet<TUserRole> TUserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=erpprd)(PORT=1523))(CONNECT_DATA=(SERVICE_NAME=CITYNPDB)));User Id=city_lms;Password=citylms_it;;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CITY_LMS")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<TCaseAdvocate>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_ADVOCATE_PK");

                entity.ToTable("T_CASE_ADVOCATE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseCourt>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_COURT_PK");

                entity.ToTable("T_CASE_COURT");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseDocument>(entity =>
            {
                entity.HasKey(e => e.Documentid)
                    .HasName("T_CASE_DOCUMENT_PK");

                entity.ToTable("T_CASE_DOCUMENT");

                entity.Property(e => e.Documentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTID");

                entity.Property(e => e.Basepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BASEPATH");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Documentfullpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTFULLPATH");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTNAME");

                entity.Property(e => e.Documentpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTPATH");

                entity.Property(e => e.Documentsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTSIZE");

                entity.Property(e => e.Documenttype)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTTYPE");

                entity.Property(e => e.Inputname)
                    .HasMaxLength(250)
                    .HasColumnName("INPUTNAME");

                entity.Property(e => e.Inputnumber)
                    .HasMaxLength(250)
                    .HasColumnName("INPUTNUMBER");

                entity.Property(e => e.Inputothers)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("INPUTOTHERS");

                entity.Property(e => e.Inputtype)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("INPUTTYPE");

                entity.Property(e => e.InputtypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("INPUTTYPE_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.Originaldocname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINALDOCNAME");

                entity.Property(e => e.Referenceid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCEID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Virtualpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIRTUALPATH");
            });

            modelBuilder.Entity<TCaseHearing>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_HEARING_PK");

                entity.ToTable("T_CASE_HEARING");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CASE_OID");

                entity.Property(e => e.Column1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN1");

                entity.Property(e => e.Column2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN2");

                entity.Property(e => e.Column3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN3");

                entity.Property(e => e.Column4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN4");

                entity.Property(e => e.Column5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN5");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.LastHearingDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_HEARING_DATE");

                entity.Property(e => e.NextHearingDate)
                    .HasColumnType("DATE")
                    .HasColumnName("NEXT_HEARING_DATE");

                entity.Property(e => e.ReasonNxtHearing)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REASON_NXT_HEARING");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseHearingAdvocate>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_HEARING_ADVOCATE_PK");

                entity.ToTable("T_CASE_HEARING_ADVOCATE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.AdvocateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADVOCATE_ID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CASE_OID");

                entity.Property(e => e.CaseStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CASE_STATUS");

                entity.Property(e => e.Column2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN2");

                entity.Property(e => e.Column3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN3");

                entity.Property(e => e.Column4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN4");

                entity.Property(e => e.Column5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COLUMN5");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Expense)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXPENSE");

                entity.Property(e => e.HearingNoteDetails).HasColumnName("HEARING_NOTE_DETAILS");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.RowNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROW_NUM");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseHearingDoc>(entity =>
            {
                entity.HasKey(e => e.Documentid)
                    .HasName("T_CASE_HEARING_DOC_PK");

                entity.ToTable("T_CASE_HEARING_DOC");

                entity.Property(e => e.Documentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTID");

                entity.Property(e => e.AdvHearingId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ADV_HEARING_ID");

                entity.Property(e => e.Basepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BASEPATH");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CASE_ID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Documentfullpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTFULLPATH");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTNAME");

                entity.Property(e => e.Documentpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTPATH");

                entity.Property(e => e.Documentsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTSIZE");

                entity.Property(e => e.Documenttype)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTTYPE");

                entity.Property(e => e.IndexNo)
                    .HasMaxLength(10)
                    .HasColumnName("INDEX_NO");

                entity.Property(e => e.Inputothers)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("INPUTOTHERS");

                entity.Property(e => e.Inputtype)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("INPUTTYPE");

                entity.Property(e => e.InputtypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("INPUTTYPE_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Originaldocname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINALDOCNAME");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Virtualpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIRTUALPATH");
            });

            modelBuilder.Entity<TCaseHearingEvent>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_HEARING_REASON_PK");

                entity.ToTable("T_CASE_HEARING_EVENT");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseLand>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_LAND_PK");

                entity.ToTable("T_CASE_LAND");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Badi)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("BADI");

                entity.Property(e => e.Bibadi)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("BIBADI");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseDate)
                    .HasColumnType("DATE")
                    .HasColumnName("CASE_DATE");

                entity.Property(e => e.CaseDetails)
                    .HasMaxLength(1500)
                    .IsUnicode(false)
                    .HasColumnName("CASE_DETAILS");

                entity.Property(e => e.CasePriorityId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CASE_PRIORITY_ID");

                entity.Property(e => e.CaseTypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CASE_TYPE_ID");

                entity.Property(e => e.Caseno)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CASENO");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_ID");

                entity.Property(e => e.CourtId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COURT_ID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.CurrentStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CURRENT_STATUS");

                entity.Property(e => e.Dagbs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DAGBS");

                entity.Property(e => e.Dagcs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DAGCS");

                entity.Property(e => e.Dagdr)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DAGDR");

                entity.Property(e => e.Dagrs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DAGRS");

                entity.Property(e => e.Dagsa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DAGSA");

                entity.Property(e => e.Deedids)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DEEDIDS");

                entity.Property(e => e.Deednos)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DEEDNOS");

                entity.Property(e => e.Districtid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICTID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Khatianbs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KHATIANBS");

                entity.Property(e => e.Khatiancs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KHATIANCS");

                entity.Property(e => e.Khatiandr)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KHATIANDR");

                entity.Property(e => e.Khatianrs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KHATIANRS");

                entity.Property(e => e.Khatiansa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("KHATIANSA");

                entity.Property(e => e.Mouzaid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOUZAID");

                entity.Property(e => e.RefCaseNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REF_CASE_NO");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1500)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.SurveyType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SURVEY_TYPE");

                entity.Property(e => e.Thanaid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("THANAID");

                entity.Property(e => e.TotalLand)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TOTAL_LAND");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCasePriority>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_PRIORITY_PK");

                entity.ToTable("T_CASE_PRIORITY");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseStatus>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_STATUS_PK");

                entity.ToTable("T_CASE_STATUS");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCaseType>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_CASE_TYPE_PK");

                entity.ToTable("T_CASE_TYPE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCmnDocumentUpload>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_CMN_DOCUMENT_UPLOAD");

                entity.Property(e => e.Basepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BASEPATH");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Documentfullpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTFULLPATH");

                entity.Property(e => e.Documentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTID");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTNAME");

                entity.Property(e => e.Documentpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTPATH");

                entity.Property(e => e.Documentsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTSIZE");

                entity.Property(e => e.Documenttype)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTTYPE");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 \n")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 \n")
                    .IsFixedLength();

                entity.Property(e => e.Originaldocname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINALDOCNAME");

                entity.Property(e => e.Referenceid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCEID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Virtualpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIRTUALPATH");
            });

            modelBuilder.Entity<TCmnLandDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK_T_CMN_STUDENT_DOCUMENT_1");

                entity.ToTable("T_CMN_LAND_DOCUMENT");

                entity.Property(e => e.DocumentId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("DOCUMENT_ID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_OID");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.DocPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_PATH");

                entity.Property(e => e.DocVPath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOC_V_PATH");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.RoleIds)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_IDS");

                entity.Property(e => e.UpParentTypeId)
                    .HasPrecision(10)
                    .HasColumnName("UP_PARENT_TYPE_ID");

                entity.Property(e => e.UpTypeId)
                    .HasPrecision(10)
                    .HasColumnName("UP_TYPE_ID");

                entity.Property(e => e.UpTypeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UP_TYPE_NAME");

                entity.Property(e => e.UpTypeNo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UP_TYPE_NO");

                entity.Property(e => e.UpTypeOthers)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UP_TYPE_OTHERS");

                entity.Property(e => e.UpTypeSeq)
                    .HasPrecision(10)
                    .HasColumnName("UP_TYPE_SEQ");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCmnUploadType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("T_CMN_UPLOAD_TYPE");

                entity.Property(e => e.TypeId)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("TYPE_ID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .HasColumnName("TYPE_NAME");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCmndocument>(entity =>
            {
                entity.HasKey(e => e.Documentid)
                    .HasName("T_CMNDOCUMENT_PK");

                entity.ToTable("T_CMNDOCUMENT");

                entity.Property(e => e.Documentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTID");

                entity.Property(e => e.Basepath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BASEPATH");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Documentfullpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTFULLPATH");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTNAME");

                entity.Property(e => e.Documentpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTPATH");

                entity.Property(e => e.Documentsize)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DOCUMENTSIZE");

                entity.Property(e => e.Documenttype)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTTYPE");

                entity.Property(e => e.Inputname)
                    .HasMaxLength(250)
                    .HasColumnName("INPUTNAME");

                entity.Property(e => e.Inputnumber)
                    .HasMaxLength(250)
                    .HasColumnName("INPUTNUMBER");

                entity.Property(e => e.Inputothers)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("INPUTOTHERS");

                entity.Property(e => e.Inputtype)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("INPUTTYPE");

                entity.Property(e => e.InputtypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("INPUTTYPE_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 \n")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 \n")
                    .IsFixedLength();

                entity.Property(e => e.Originaldocname)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINALDOCNAME");

                entity.Property(e => e.Referenceid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCEID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Virtualpath)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIRTUALPATH");
            });

            modelBuilder.Entity<TCmnmenu>(entity =>
            {
                entity.HasKey(e => e.Menuid)
                    .HasName("T_CMNMENU_PK");

                entity.ToTable("T_CMNMENU");

                entity.Property(e => e.Menuid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUID");

                entity.Property(e => e.Companyid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COMPANYID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Issubparent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSUBPARENT")
                    .IsFixedLength();

                entity.Property(e => e.Menuicon)
                    .HasMaxLength(100)
                    .HasColumnName("MENUICON");

                entity.Property(e => e.Menuname)
                    .HasMaxLength(100)
                    .HasColumnName("MENUNAME");

                entity.Property(e => e.Menupath)
                    .HasMaxLength(300)
                    .HasColumnName("MENUPATH");

                entity.Property(e => e.Menushortname)
                    .HasMaxLength(100)
                    .HasColumnName("MENUSHORTNAME");

                entity.Property(e => e.Moduleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MODULEID");

                entity.Property(e => e.Parentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PARENTID");

                entity.Property(e => e.Sequence)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SEQUENCE");

                entity.Property(e => e.Subparentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SUBPARENTID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TCmnmenupermission>(entity =>
            {
                entity.HasKey(e => e.Menupermissionid)
                    .HasName("T_CMNMENUPERMISSION_PK");

                entity.ToTable("T_CMNMENUPERMISSION");

                entity.Property(e => e.Menupermissionid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUPERMISSIONID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Enabledelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEDELETE")
                    .IsFixedLength();

                entity.Property(e => e.Enableinsert)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEINSERT")
                    .IsFixedLength();

                entity.Property(e => e.Enableupdate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEUPDATE")
                    .IsFixedLength();

                entity.Property(e => e.Enableview)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ENABLEVIEW")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Menuid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MENUID");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TDeedWiseBayadeed>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_DEED_WISE_BAYADEED");

                entity.Property(e => e.BayaDeedNo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("BAYA_DEED_NO");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TDeedWiseLandSubCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_DEED_WISE_LAND_SUB_CATEGORY");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.LandSubCatId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAND_SUB_CAT_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TDeedWiseServey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_DEED_WISE_SERVEY");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.ServeyId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SERVEY_ID");

                entity.Property(e => e.ServeyNo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SERVEY_NO");

                entity.Property(e => e.ServeyTypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SERVEY_TYPE_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TDistrict>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_DISTRICT_PK");

                entity.ToTable("T_DISTRICT");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DivisionId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TDivision>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_DIVISION_PK");

                entity.ToTable("T_DIVISION");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TErrorLog>(entity =>
            {
                entity.HasKey(e => e.Errorid)
                    .HasName("TESTLOG_PK");

                entity.ToTable("T_ERROR_LOGS");

                entity.Property(e => e.Errorid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ERRORID");

                entity.Property(e => e.Apipath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("APIPATH");

                entity.Property(e => e.Browser)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("BROWSER");

                entity.Property(e => e.Clientagent)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTAGENT");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Errormessage)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("ERRORMESSAGE");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("IPADDRESS");

                entity.Property(e => e.Requesttype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("REQUESTTYPE");

                entity.Property(e => e.Spname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SPNAME");

                entity.Property(e => e.Stacktrace)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("STACKTRACE");
            });

            modelBuilder.Entity<TKhajnaMutationWise>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_KHAJNA_MUTATION_WISE_PK");

                entity.ToTable("T_KHAJNA_MUTATION_WISE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DocPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_PATH");

                entity.Property(e => e.DocVPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_V_PATH");

                entity.Property(e => e.FineAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("FINE_AMOUNT");

                entity.Property(e => e.FiscalYearEng)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FISCAL_YEAR_ENG");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.KhajnaAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("KHAJNA_AMOUNT");

                entity.Property(e => e.KhajnaDate)
                    .HasColumnType("DATE")
                    .HasColumnName("KHAJNA_DATE");

                entity.Property(e => e.KhajnaDateBn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("KHAJNA_DATE_BN");

                entity.Property(e => e.KhajnaDateStrBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("KHAJNA_DATE_STR_BN");

                entity.Property(e => e.KhajnaMonthBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("KHAJNA_MONTH_BN");

                entity.Property(e => e.KhajnaYear)
                    .HasPrecision(12)
                    .HasColumnName("KHAJNA_YEAR");

                entity.Property(e => e.KhajnaYearBn)
                    .HasPrecision(12)
                    .HasColumnName("KHAJNA_YEAR_BN");

                entity.Property(e => e.LastDue)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LAST_DUE");

                entity.Property(e => e.LastDueYear)
                    .HasPrecision(12)
                    .HasColumnName("LAST_DUE_YEAR");

                entity.Property(e => e.LastPayDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_PAY_DATE");

                entity.Property(e => e.LastPayDateBn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_DATE_BN");

                entity.Property(e => e.LastPayDateStrBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_DATE_STR_BN");

                entity.Property(e => e.LastPayMonthBn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_MONTH_BN");

                entity.Property(e => e.LastPayUnit)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LAST_PAY_UNIT");

                entity.Property(e => e.LastPayYear)
                    .HasPrecision(12)
                    .HasColumnName("LAST_PAY_YEAR");

                entity.Property(e => e.LastPayYearBn)
                    .HasPrecision(12)
                    .HasColumnName("LAST_PAY_YEAR_BN");

                entity.Property(e => e.MutationId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MUTATION_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalDueYear)
                    .HasPrecision(12)
                    .HasColumnName("TOTAL_DUE_YEAR");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TKhajnaMutationWise01>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_KHAJNA_MUTATION_WISE_01");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DocPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_PATH");

                entity.Property(e => e.DocVPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_V_PATH");

                entity.Property(e => e.FineAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("FINE_AMOUNT");

                entity.Property(e => e.FiscalYearEng)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FISCAL_YEAR_ENG");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.KhajnaAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("KHAJNA_AMOUNT");

                entity.Property(e => e.KhajnaDate)
                    .HasColumnType("DATE")
                    .HasColumnName("KHAJNA_DATE");

                entity.Property(e => e.KhajnaDateBn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KHAJNA_DATE_BN");

                entity.Property(e => e.KhajnaDateStrBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("KHAJNA_DATE_STR_BN");

                entity.Property(e => e.KhajnaMonthBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("KHAJNA_MONTH_BN");

                entity.Property(e => e.KhajnaYear)
                    .HasPrecision(12)
                    .HasColumnName("KHAJNA_YEAR");

                entity.Property(e => e.KhajnaYearBn)
                    .HasPrecision(12)
                    .HasColumnName("KHAJNA_YEAR_BN");

                entity.Property(e => e.LastDue)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LAST_DUE");

                entity.Property(e => e.LastDueYear)
                    .HasPrecision(12)
                    .HasColumnName("LAST_DUE_YEAR");

                entity.Property(e => e.LastPayDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_PAY_DATE");

                entity.Property(e => e.LastPayDateBn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_DATE_BN");

                entity.Property(e => e.LastPayDateStrBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_DATE_STR_BN");

                entity.Property(e => e.LastPayMonthBn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_MONTH_BN");

                entity.Property(e => e.LastPayUnit)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LAST_PAY_UNIT");

                entity.Property(e => e.LastPayYear)
                    .HasPrecision(12)
                    .HasColumnName("LAST_PAY_YEAR");

                entity.Property(e => e.LastPayYearBn)
                    .HasPrecision(12)
                    .HasColumnName("LAST_PAY_YEAR_BN");

                entity.Property(e => e.MutationId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MUTATION_ID");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TotalDueYear)
                    .HasPrecision(12)
                    .HasColumnName("TOTAL_DUE_YEAR");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_CATEGORY");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(150)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(100)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_CLASS");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandDeed>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_LAND_DEED_PK");

                entity.ToTable("T_LAND_DEED");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("CASE_NO");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_BS");

                entity.Property(e => e.DagCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_CS");

                entity.Property(e => e.DagDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_DR");

                entity.Property(e => e.DagRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_RS");

                entity.Property(e => e.DagSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_SA");

                entity.Property(e => e.DeedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_CODE");

                entity.Property(e => e.DeedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEED_DATE");

                entity.Property(e => e.DeedNo)
                    .HasMaxLength(250)
                    .HasColumnName("DEED_NO");

                entity.Property(e => e.DeedNoVia)
                    .HasColumnType("CLOB")
                    .HasColumnName("DEED_NO_VIA");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.DivisionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_ID");

                entity.Property(e => e.HoldingNo)
                    .HasMaxLength(250)
                    .HasColumnName("HOLDING_NO");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isposted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISPOSTED")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.KhatianBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_BS");

                entity.Property(e => e.KhatianCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_CS");

                entity.Property(e => e.KhatianDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_DR");

                entity.Property(e => e.KhatianRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_RS");

                entity.Property(e => e.KhatianSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_SA");

                entity.Property(e => e.LandCatOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAND_CAT_OID");

                entity.Property(e => e.LandClass)
                    .HasMaxLength(250)
                    .HasColumnName("LAND_CLASS");

                entity.Property(e => e.LandOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAND_OFFICE_ID");

                entity.Property(e => e.LandSubCatOid)
                    .HasMaxLength(3000)
                    .IsUnicode(false)
                    .HasColumnName("LAND_SUB_CAT_OID");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.LdTaxAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LD_TAX_AMOUNT");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.MouzaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOUZA_ID");

                entity.Property(e => e.MutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATED_LAND");

                entity.Property(e => e.MutationJotNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_JOT_NO");

                entity.Property(e => e.MutationKhatianNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_KHATIAN_NO");

                entity.Property(e => e.NotMutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("NOT_MUTATED_LAND");

                entity.Property(e => e.PostCodeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE_NO");

                entity.Property(e => e.ProjectOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_OID");

                entity.Property(e => e.PurchaseAmount)
                    .HasPrecision(12)
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.Property(e => e.PurchasedLand)
                    .HasMaxLength(50)
                    .HasColumnName("PURCHASED_LAND");

                entity.Property(e => e.RegistryOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRY_OFFICE_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.TotalLandInDag)
                    .HasMaxLength(50)
                    .HasColumnName("TOTAL_LAND_IN_DAG");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandDeed111225>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_DEED_111225");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("CASE_NO");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_BS");

                entity.Property(e => e.DagCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_CS");

                entity.Property(e => e.DagDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_DR");

                entity.Property(e => e.DagRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_RS");

                entity.Property(e => e.DagSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_SA");

                entity.Property(e => e.DeedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_CODE");

                entity.Property(e => e.DeedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEED_DATE");

                entity.Property(e => e.DeedNo)
                    .HasMaxLength(250)
                    .HasColumnName("DEED_NO");

                entity.Property(e => e.DeedNoVia)
                    .HasColumnType("CLOB")
                    .HasColumnName("DEED_NO_VIA");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.DivisionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_ID");

                entity.Property(e => e.HoldingNo)
                    .HasMaxLength(250)
                    .HasColumnName("HOLDING_NO");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.Isposted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISPOSTED")
                    .IsFixedLength();

                entity.Property(e => e.KhatianBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_BS");

                entity.Property(e => e.KhatianCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_CS");

                entity.Property(e => e.KhatianDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_DR");

                entity.Property(e => e.KhatianRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_RS");

                entity.Property(e => e.KhatianSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_SA");

                entity.Property(e => e.LandCatOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAND_CAT_OID");

                entity.Property(e => e.LandClass)
                    .HasMaxLength(250)
                    .HasColumnName("LAND_CLASS");

                entity.Property(e => e.LandOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAND_OFFICE_ID");

                entity.Property(e => e.LandSubCatOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAND_SUB_CAT_OID");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.LdTaxAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LD_TAX_AMOUNT");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.MouzaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOUZA_ID");

                entity.Property(e => e.MutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATED_LAND");

                entity.Property(e => e.MutationJotNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_JOT_NO");

                entity.Property(e => e.MutationKhatianNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_KHATIAN_NO");

                entity.Property(e => e.NotMutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("NOT_MUTATED_LAND");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.PostCodeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE_NO");

                entity.Property(e => e.ProjectOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROJECT_OID");

                entity.Property(e => e.PurchaseAmount)
                    .HasPrecision(12)
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.Property(e => e.PurchasedLand)
                    .HasMaxLength(50)
                    .HasColumnName("PURCHASED_LAND");

                entity.Property(e => e.RegistryOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRY_OFFICE_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.TotalLandInDag)
                    .HasMaxLength(50)
                    .HasColumnName("TOTAL_LAND_IN_DAG");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandDeedBak>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_DEED_BAK");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("CASE_NO");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_BS");

                entity.Property(e => e.DagCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_CS");

                entity.Property(e => e.DagDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_DR");

                entity.Property(e => e.DagRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_RS");

                entity.Property(e => e.DagSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_SA");

                entity.Property(e => e.DeedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_CODE");

                entity.Property(e => e.DeedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEED_DATE");

                entity.Property(e => e.DeedNo)
                    .HasMaxLength(250)
                    .HasColumnName("DEED_NO");

                entity.Property(e => e.DeedNoVia)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DEED_NO_VIA");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.DivisionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_ID");

                entity.Property(e => e.HoldingNo)
                    .HasMaxLength(250)
                    .HasColumnName("HOLDING_NO");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.KhatianBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_BS");

                entity.Property(e => e.KhatianCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_CS");

                entity.Property(e => e.KhatianDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_DR");

                entity.Property(e => e.KhatianRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_RS");

                entity.Property(e => e.KhatianSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_SA");

                entity.Property(e => e.LandClass)
                    .HasMaxLength(250)
                    .HasColumnName("LAND_CLASS");

                entity.Property(e => e.LandOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAND_OFFICE_ID");

                entity.Property(e => e.LdTaxAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LD_TAX_AMOUNT");

                entity.Property(e => e.MouzaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOUZA_ID");

                entity.Property(e => e.MutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATED_LAND");

                entity.Property(e => e.MutationJotNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_JOT_NO");

                entity.Property(e => e.MutationKhatianNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_KHATIAN_NO");

                entity.Property(e => e.NotMutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("NOT_MUTATED_LAND");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.PostCodeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE_NO");

                entity.Property(e => e.PurchaseAmount)
                    .HasPrecision(12)
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.Property(e => e.PurchasedLand)
                    .HasMaxLength(50)
                    .HasColumnName("PURCHASED_LAND");

                entity.Property(e => e.RegistryOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRY_OFFICE_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.TotalLandInDag)
                    .HasMaxLength(50)
                    .HasColumnName("TOTAL_LAND_IN_DAG");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandDeedBak1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_DEED_BAKS");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("CASE_NO");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_BS");

                entity.Property(e => e.DagCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_CS");

                entity.Property(e => e.DagDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_DR");

                entity.Property(e => e.DagRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_RS");

                entity.Property(e => e.DagSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_SA");

                entity.Property(e => e.DeedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_CODE");

                entity.Property(e => e.DeedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEED_DATE");

                entity.Property(e => e.DeedNo)
                    .HasMaxLength(250)
                    .HasColumnName("DEED_NO");

                entity.Property(e => e.DeedNoVia)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DEED_NO_VIA");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.DivisionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_ID");

                entity.Property(e => e.HoldingNo)
                    .HasMaxLength(250)
                    .HasColumnName("HOLDING_NO");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.KhatianBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_BS");

                entity.Property(e => e.KhatianCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_CS");

                entity.Property(e => e.KhatianDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_DR");

                entity.Property(e => e.KhatianRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_RS");

                entity.Property(e => e.KhatianSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_SA");

                entity.Property(e => e.LandClass)
                    .HasMaxLength(250)
                    .HasColumnName("LAND_CLASS");

                entity.Property(e => e.LandOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAND_OFFICE_ID");

                entity.Property(e => e.LdTaxAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LD_TAX_AMOUNT");

                entity.Property(e => e.MouzaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOUZA_ID");

                entity.Property(e => e.MutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATED_LAND");

                entity.Property(e => e.MutationJotNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_JOT_NO");

                entity.Property(e => e.MutationKhatianNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_KHATIAN_NO");

                entity.Property(e => e.NotMutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("NOT_MUTATED_LAND");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.PostCodeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE_NO");

                entity.Property(e => e.PurchaseAmount)
                    .HasPrecision(12)
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.Property(e => e.PurchasedLand)
                    .HasMaxLength(50)
                    .HasColumnName("PURCHASED_LAND");

                entity.Property(e => e.RegistryOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRY_OFFICE_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.TotalLandInDag)
                    .HasMaxLength(50)
                    .HasColumnName("TOTAL_LAND_IN_DAG");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandDeedBakA>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_DEED_BAK_A");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("CASE_NO");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_BS");

                entity.Property(e => e.DagCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_CS");

                entity.Property(e => e.DagDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_DR");

                entity.Property(e => e.DagRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_RS");

                entity.Property(e => e.DagSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_SA");

                entity.Property(e => e.DeedCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_CODE");

                entity.Property(e => e.DeedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("DEED_DATE");

                entity.Property(e => e.DeedNo)
                    .HasMaxLength(250)
                    .HasColumnName("DEED_NO");

                entity.Property(e => e.DeedNoVia)
                    .IsUnicode(false)
                    .HasColumnName("DEED_NO_VIA");

                entity.Property(e => e.DeedViaNoT)
                    .HasColumnType("CLOB")
                    .HasColumnName("DEED_VIA_NO_T");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.DivisionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIVISION_ID");

                entity.Property(e => e.HoldingNo)
                    .HasMaxLength(250)
                    .HasColumnName("HOLDING_NO");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .IsFixedLength();

                entity.Property(e => e.Isposted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISPOSTED")
                    .IsFixedLength();

                entity.Property(e => e.KhatianBs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_BS");

                entity.Property(e => e.KhatianCs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_CS");

                entity.Property(e => e.KhatianDr)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_DR");

                entity.Property(e => e.KhatianRs)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_RS");

                entity.Property(e => e.KhatianSa)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("KHATIAN_SA");

                entity.Property(e => e.LandClass)
                    .HasMaxLength(250)
                    .HasColumnName("LAND_CLASS");

                entity.Property(e => e.LandOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAND_OFFICE_ID");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.LdTaxAmount)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("LD_TAX_AMOUNT");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.MouzaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MOUZA_ID");

                entity.Property(e => e.MutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATED_LAND");

                entity.Property(e => e.MutationJotNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_JOT_NO");

                entity.Property(e => e.MutationKhatianNo)
                    .HasMaxLength(50)
                    .HasColumnName("MUTATION_KHATIAN_NO");

                entity.Property(e => e.NotMutatedLand)
                    .HasMaxLength(50)
                    .HasColumnName("NOT_MUTATED_LAND");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.PostCodeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POST_CODE_NO");

                entity.Property(e => e.PurchaseAmount)
                    .HasPrecision(12)
                    .HasColumnName("PURCHASE_AMOUNT");

                entity.Property(e => e.PurchasedLand)
                    .HasMaxLength(50)
                    .HasColumnName("PURCHASED_LAND");

                entity.Property(e => e.RegistryOfficeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REGISTRY_OFFICE_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.TotalLandInDag)
                    .HasMaxLength(50)
                    .HasColumnName("TOTAL_LAND_IN_DAG");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandMutation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_MUTATION");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CaseNo)
                    .HasMaxLength(50)
                    .HasColumnName("CASE_NO");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagNos)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DAG_NOS");

                entity.Property(e => e.DcrFee)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("DCR_FEE");

                entity.Property(e => e.DeedNos)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("DEED_NOS");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.DocPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_PATH");

                entity.Property(e => e.DocVPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_V_PATH");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.JotNo)
                    .HasMaxLength(50)
                    .HasColumnName("JOT_NO");

                entity.Property(e => e.KhatianNo)
                    .HasMaxLength(50)
                    .HasColumnName("KHATIAN_NO");

                entity.Property(e => e.LandClass)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("LAND_CLASS");

                entity.Property(e => e.LastPayDate)
                    .HasColumnType("DATE")
                    .HasColumnName("LAST_PAY_DATE");

                entity.Property(e => e.LastPayDateBn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_DATE_BN");

                entity.Property(e => e.LastPayDateStrBn)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_DATE_STR_BN");

                entity.Property(e => e.LastPayMonthBn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_PAY_MONTH_BN");

                entity.Property(e => e.LastPayYear)
                    .HasPrecision(12)
                    .HasColumnName("LAST_PAY_YEAR");

                entity.Property(e => e.LastPayYearBn)
                    .HasPrecision(12)
                    .HasColumnName("LAST_PAY_YEAR_BN");

                entity.Property(e => e.MouzaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOUZA_ID");

                entity.Property(e => e.MutationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("MUTATION_DATE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.PaymentUnit)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("PAYMENT_UNIT");

                entity.Property(e => e.ServeyId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SERVEY_ID");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("NUMBER(12,2)")
                    .HasColumnName("TOTAL_DUE");

                entity.Property(e => e.TotalLand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TOTAL_LAND");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandOffice>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_LAND_OFFICE_PK");

                entity.ToTable("T_LAND_OFFICE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_PROJECT");

                entity.Property(e => e.AddressBn)
                    .HasMaxLength(250)
                    .HasColumnName("ADDRESS_BN");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(150)
                    .HasColumnName("ADDRESS_EN");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(150)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(100)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandPurchaser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_PURCHASERS");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isgong)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISGONG")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.PurchaserId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PURCHASER_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandSeller>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_SELLERS");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isgong)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISGONG")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.SellerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SELLER_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TLandSubCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_LAND_SUB_CATEGORY");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.CatOid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CAT_OID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(150)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(100)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TMouza>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_MOUZA_PK");

                entity.ToTable("T_MOUZA");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DocPath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_PATH");

                entity.Property(e => e.DocVpath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DOC_VPATH");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.ThanaId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("THANA_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TMutationWiseDag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_MUTATION_WISE_DAG");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DagNo)
                    .HasMaxLength(150)
                    .HasColumnName("DAG_NO");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.MutationId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MUTATION_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TMutationWiseDeed>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_MUTATION_WISE_DEED");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DeedId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEED_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.MutationId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MUTATION_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TMutationWiseLandClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_MUTATION_WISE_LAND_CLASS");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.LandClassId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LAND_CLASS_ID");

                entity.Property(e => e.MutationId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MUTATION_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TPurchaser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_PURCHASERS");

                entity.Property(e => e.AddressBn)
                    .HasMaxLength(500)
                    .HasColumnName("ADDRESS_BN");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .HasColumnName("ADDRESS_EN");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(300)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscom)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCOM")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isgong)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISGONG")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.MotherName)
                    .HasMaxLength(300)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(300)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(300)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.NidNo)
                    .HasMaxLength(100)
                    .HasColumnName("NID_NO");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(300)
                    .HasColumnName("REGISTRATION_NO");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(300)
                    .HasColumnName("SPOUSE_NAME");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TRegistryOffice>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_REGISTRY_OFFICE_PK");

                entity.ToTable("T_REGISTRY_OFFICE");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TRoleSetup>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("T_ROLE_SETUP_PK");

                entity.ToTable("T_ROLE_SETUP");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DefaultPath)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DEFAULT_PATH")
                    .HasDefaultValueSql("'/home'");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deletelpc)
                    .HasMaxLength(50)
                    .HasColumnName("DELETELPC");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Remarks)
                    .HasMaxLength(200)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .HasColumnName("ROLENAME");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TSeller>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_SELLERS_PK");

                entity.ToTable("T_SELLERS");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.AddressBn)
                    .HasMaxLength(500)
                    .HasColumnName("ADDRESS_BN");

                entity.Property(e => e.AddressEn)
                    .HasMaxLength(500)
                    .HasColumnName("ADDRESS_EN");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(300)
                    .HasColumnName("FATHER_NAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Isgong)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISGONG")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.MotherName)
                    .HasMaxLength(300)
                    .HasColumnName("MOTHER_NAME");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(300)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(300)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.NidNo)
                    .HasMaxLength(100)
                    .HasColumnName("NID_NO");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(300)
                    .HasColumnName("SPOUSE_NAME");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TServey>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_SERVEY");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TServeyType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_SERVEY_TYPE");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Oid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TSysUser>(entity =>
            {
                entity.HasKey(e => e.Sysid)
                    .HasName("T_SYS_USER_PK");

                entity.ToTable("T_SYS_USER");

                entity.Property(e => e.Sysid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SYSID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESIGNATION");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Issys)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSYS")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Photo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.Userid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<TThana>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("T_THANA_PK");

                entity.ToTable("T_THANA");

                entity.Property(e => e.Oid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OID");

                entity.Property(e => e.Cancelby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELBY");

                entity.Property(e => e.Cancelon)
                    .HasColumnType("DATE")
                    .HasColumnName("CANCELON");

                entity.Property(e => e.Cancelpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CANCELPC");

                entity.Property(e => e.Createby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1 ")
                    .IsFixedLength();

                entity.Property(e => e.Iscancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISCANCEL")
                    .HasDefaultValueSql("0 ")
                    .IsFixedLength();

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(12,10)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.NameBn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_BN");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");
            });

            modelBuilder.Entity<TThanaTemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_THANA_TEMP");

                entity.Property(e => e.DistrictId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DISTRICT_ID");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_EN");
            });

            modelBuilder.Entity<TUserRole>(entity =>
            {
                entity.HasKey(e => e.Userroleid)
                    .HasName("T_USER_ROLE_PK");

                entity.ToTable("T_USER_ROLE");

                entity.Property(e => e.Userroleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERROLEID");

                entity.Property(e => e.Createby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CREATEBY");

                entity.Property(e => e.Createon)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEON");

                entity.Property(e => e.Createpc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATEPC");

                entity.Property(e => e.Deleteby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DELETEBY");

                entity.Property(e => e.Deleteon)
                    .HasColumnType("DATE")
                    .HasColumnName("DELETEON");

                entity.Property(e => e.Deletepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DELETEPC");

                entity.Property(e => e.Isactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISACTIVE")
                    .HasDefaultValueSql("1")
                    .IsFixedLength();

                entity.Property(e => e.Isdelete)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISDELETE")
                    .HasDefaultValueSql("0")
                    .IsFixedLength();

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.Updateby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEBY");

                entity.Property(e => e.Updateon)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEON");

                entity.Property(e => e.Updatepc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEPC");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USER_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
