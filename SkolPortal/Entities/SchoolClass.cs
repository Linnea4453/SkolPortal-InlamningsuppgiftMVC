using System;
using System.Collections.Generic;
using System.ComponentModel;
using SkolPortal.Data;

#nullable disable

namespace SkolPortal.Entities
{
    public partial class SchoolClass
    {
        public SchoolClass()
        {
            SchoolClassStudents = new HashSet<SchoolClassStudent>();
        }

        public Guid Id { get; set; }

        [DisplayName("Class")]
        public string ClassName { get; set; }

        [DisplayName("Teacher")]
        public string TeacherId { get; set; }
        public DateTime Created { get; set; }

        public virtual AppUser Teacher { get; set; }

        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
    }
}
