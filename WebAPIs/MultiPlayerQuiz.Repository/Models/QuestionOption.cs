//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultiPlayerQuiz.Repository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionOption
    {
        public int Id { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public string Option { get; set; }
        public Nullable<bool> IsAnswer { get; set; }
    
        public virtual Question Question { get; set; }
    }
}
