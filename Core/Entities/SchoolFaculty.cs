using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("transcript_faculty")]
    public class SchoolFaculty : BaseEntity
    {
        public string Name { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}