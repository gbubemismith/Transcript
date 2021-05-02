using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("transcript_school")]
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<SchoolDepartment> Departments { get; set; }
        public ICollection<SchoolFaculty> Faculties { get; set; }
        public ICollection<TranscriptRequest> TranscriptRequests { get; set; }
    }
}