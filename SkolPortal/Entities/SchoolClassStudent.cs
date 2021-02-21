using System;
using System.Collections.Generic;
using System.ComponentModel;
using SkolPortal.Data;

#nullable disable

namespace SkolPortal.Entities
{
    public partial class SchoolClassStudent
    {
        [DisplayName("Student")]
        public string StudentId { get; set; }

  
        public Guid SchoolClassId { get; set; }
        public DateTime Created { get; set; }

       // public virtual AppUser Student { get; set; }

        [DisplayName("Class")]
        public virtual SchoolClass SchoolClass { get; set; }
    }
}
