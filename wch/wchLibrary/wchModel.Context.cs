﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace wch
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wchEntities : DbContext
    {
        public wchEntities()
            : base("name=wchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<wch_Class> wch_Class { get; set; }
        public DbSet<wch_Course> wch_Course { get; set; }
        public DbSet<wch_CourseSelection> wch_CourseSelection { get; set; }
        public DbSet<wch_Department> wch_Department { get; set; }
        public DbSet<wch_Login> wch_Login { get; set; }
        public DbSet<wch_Schedule> wch_Schedule { get; set; }
        public DbSet<wch_Student> wch_Student { get; set; }
        public DbSet<wch_Teacher> wch_Teacher { get; set; }
        public DbSet<wch_Term> wch_Term { get; set; }
        public DbSet<wch_Theatre> wch_Theatre { get; set; }
        public DbSet<wch_TimeTable> wch_TimeTable { get; set; }
        public DbSet<wch_TimeTableDetail> wch_TimeTableDetail { get; set; }
        public DbSet<sv_wch_Student> sv_wch_Student { get; set; }
        public DbSet<sv_wch_CourseSelection> sv_wch_CourseSelection { get; set; }
        public DbSet<sv_wch_Teacher> sv_wch_Teacher { get; set; }
        public DbSet<sv_wch_TimeTable> sv_wch_TimeTable { get; set; }
    }
}
