//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace NPGeek.Web.Models

{
    using System;
    using System.Collections.Generic;
    
    public partial class survey_result
    {
        public int surveyId { get; set; }
        public string parkCode { get; set; }
        [Required(ErrorMessage = "Please enter a valid email")]
        public string emailAddress { get; set; }
        public string state { get; set; }
        public string activityLevel { get; set; }
    
        public virtual park park { get; set; }
    }
}
