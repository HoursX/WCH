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
    
    public partial class wch_Term
    {
        public wch_Term()
        {
            this.wch_TimeTableDetail = new HashSet<wch_TimeTableDetail>();
        }
    
        public int TermID { get; set; }
        public string TermName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartChoice { get; set; }
        public string EndChoice { get; set; }
    
        public virtual ICollection<wch_TimeTableDetail> wch_TimeTableDetail { get; set; }
    }
}