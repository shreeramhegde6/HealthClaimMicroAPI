using System;
using System.Collections.Generic;

#nullable disable

namespace Member.Models
{
    public partial class TblPhysician
    {
        public TblPhysician()
        {
            TblMembers = new HashSet<TblMember>();
        }

        public int PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianState { get; set; }

        public virtual ICollection<TblMember> TblMembers { get; set; }
    }
}
