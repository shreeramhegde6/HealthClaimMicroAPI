﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Claim.Models
{
    public partial class TblMember
    {
        public TblMember()
        {
            TblClaims = new HashSet<TblClaim>();
        }

        public int MemberId { get; set; }
        public int? PhysicianId { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblPhysician Physician { get; set; }
        public virtual ICollection<TblClaim> TblClaims { get; set; }
    }
}
