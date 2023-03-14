using Claim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Claim.Services
{
    public interface IClaimService
    {
        IEnumerable<TblClaimType> GetAllClaimType();
        TblClaim SaveClaim(TblClaim claim);
    }
}
