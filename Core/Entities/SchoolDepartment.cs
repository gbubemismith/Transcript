using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("transcript_department")]
    public class SchoolDepartment : BaseEntity
    {
        public string Name { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
        public SchoolFaculty SchoolFaculty { get; set; }
        public int SchoolFacultyId { get; set; }
        public DateTime CreateDate { get; set; }
        public TranscriptRequest TranscriptRequests { get; set; }


    }
}