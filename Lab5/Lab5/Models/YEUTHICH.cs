//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class YEUTHICH
    {
        public int IDYT { get; set; }
        public Nullable<int> IDTV { get; set; }
    
        public virtual THANHVIEN THANHVIEN { get; set; }
    }
}
