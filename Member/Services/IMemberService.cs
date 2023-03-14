using Member.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member.Services
{
    public interface IMemberService
    {
        TblMember SaveMember(TblMember member);
        IEnumerable<MemberSearchModel> GetAllMember();
        IEnumerable<MemberSearchModel> GetAllMemberById(int id);
        IEnumerable<TblPhysician> GetAllPhysician();
        IEnumerable SearchMember(SearchDataModel searchDataModel);

        IEnumerable<TblMember> GetMemberDetailByMemberId(int memberId);

        int GetMemberId(int userID);
    }
}
