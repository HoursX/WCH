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
    
    public partial class wch_Class
    {
        public wch_Class()
        {
            this.wch_Student = new HashSet<wch_Student>();
        }
    
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public Nullable<byte> DepID { get; set; }
        public Nullable<int> StuNum { get; set; }
    
        public virtual wch_Department wch_Department { get; set; }
        public virtual ICollection<wch_Student> wch_Student { get; set; }
    }
}
