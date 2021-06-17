using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Models
{
    public class UserLeave
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Duration { get; set; }
        public string Reason { get; set; }
        public string Detail { get; set; }
        public decimal RemainingLeaveBalance { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
