//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class wch_TimeTableDetail
    {
        public int RowID { get; set; }
        public Nullable<int> TimeID { get; set; }
        public Nullable<int> TermID { get; set; }
        public Nullable<byte> Day { get; set; }
        public Nullable<int> ScheduleID { get; set; }
        public Nullable<int> TheatreID { get; set; }
    
        public virtual wch_Schedule wch_Schedule { get; set; }
        public virtual wch_Term wch_Term { get; set; }
        public virtual wch_Theatre wch_Theatre { get; set; }
        public virtual wch_TimeTable wch_TimeTable { get; set; }
    }
}
