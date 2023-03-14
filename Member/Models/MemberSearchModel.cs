using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member.Models
{
    public class MemberSearchModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhysicianName { get; set; }
        public int PhysicianId { get; set; }
        public int? ClaimId { get; set; }
        public decimal? ClaimAmount { get; set; }
        public DateTime? ClaimDate { get; set; }
    }
}
