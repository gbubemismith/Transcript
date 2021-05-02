using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("transcript_request_main")]
    public class TranscriptRequest : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MatricNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ForwardingName { get; set; }
        public string ForwardingAddress { get; set; }
        public string ForwardingInstitution { get; set; }
        public string CourierType { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
        public SchoolFaculty Faculty { get; set; }
        public int FacultyId { get; set; }
        public SchoolDepartment Department { get; set; }
        public int DepartmentId { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string ApprovedBy { get; set; }
        public string Comment { get; set; }

    }
}