using System;
using System.Collections.Generic;

#nullable disable

namespace Claim.Models
{
    public partial class TblClaim
    {
        public int ClaimId { get; set; }
        public int? MemberId { get; set; }
        public int? ClaimTypeId { get; set; }
        public decimal? ClaimAmount { get; set; }
        public DateTime? ClaimDate { get; set; }
        public string ClaimRemark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblClaimType ClaimType { get; set; }
        public virtual TblMember Member { get; set; }
    }
}
