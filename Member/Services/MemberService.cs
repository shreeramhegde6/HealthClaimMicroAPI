using Member.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member.Services
{
    public class MemberService : IMemberService
    {
        HealthclaimAppContext db;
        public MemberService(HealthclaimAppContext _db)
        {
            db = _db;
        }

        public TblMember SaveMember(TblMember member)
        {
            Random rnd = new Random();
            try
            {
                member.PhysicianId = rnd.Next(1, 10);
                member.UserId = 1002;
                member.CreatedBy = "admin";
                member.CreatedDate = DateTime.Now;
                member.ModifiedBy = "admin";
                member.ModifiedDate = DateTime.Now;
                db.TblMembers.Add(member);
                db.SaveChanges();
                return member;
            }
            catch (Exception ex)
            {
                return member;
            }
        }


        public IEnumerable<MemberSearchModel> GetAllMember()
        {
            var memberList = (from m in db.TblMembers
                              join py in db.TblPhysicians on m.PhysicianId equals py.PhysicianId
                              join c in db.TblClaims on m.MemberId equals c.MemberId into claims
                              from x in claims.DefaultIfEmpty()

                              select new
                              {
                                  memberId = m.MemberId,
                                  firstName = m.FirstName,
                                  lastName = m.LastName,
                                  physicianName = py.PhysicianName,
                                  claimAmount = x == null ? 0 : x.ClaimAmount,
                                  claimId = x == null ? 0 : x.ClaimId,
                                  claimDate = x == null ? Convert.ToDateTime("9999-09-09") : x.ClaimDate

                              }).ToList();

            MemberSearchModel memberSearchModel;
            List<MemberSearchModel> memberSearchModels = new List<MemberSearchModel>();
            foreach (var item in memberList)
            {
                memberSearchModel = new MemberSearchModel();

                memberSearchModel.MemberId = item.memberId;
                memberSearchModel.ClaimId = item.claimId;
                memberSearchModel.FirstName = item.firstName;
                memberSearchModel.LastName = item.lastName;
                memberSearchModel.PhysicianName = item.physicianName;
                memberSearchModel.ClaimAmount = item.claimAmount;
                memberSearchModel.ClaimDate = item.claimDate;

                memberSearchModels.Add(memberSearchModel);
            }

            return memberSearchModels;


        }
        public IEnumerable<TblPhysician> GetAllPhysician()
        {
            var physicianList = db.TblPhysicians.ToList();
            return physicianList;
        }
        public IEnumerable SearchMember(SearchDataModel searchDataModel)
        {
            try
            {
                int PhysicianId = 0;
                PhysicianId = Convert.ToInt32(searchDataModel?.PhysicianId);
                dynamic getdata = (from m in db.TblMembers
                                   join py in db.TblPhysicians on m.PhysicianId equals py.PhysicianId
                                   join c in db.TblClaims on m.MemberId equals c.MemberId into claims
                                   from x in claims.DefaultIfEmpty()
                                   where ((m.PhysicianId == PhysicianId || m.FirstName == searchDataModel.FirstName || m.LastName == searchDataModel.LastName
                                    || m.MemberId == Convert.ToInt32(searchDataModel.MemberId)  || x.ClaimId == Convert.ToInt32(searchDataModel.ClaimId)))
                                   select new
                                   {
                                       memberId = m.MemberId,
                                       firstName = m.FirstName,
                                       lastName = m.LastName,
                                       physicianName = py.PhysicianName,
                                       claimId = x == null ? 0 : x.ClaimId,
                                       claimDate = x == null ? Convert.ToDateTime("9999-09-09") : x.ClaimDate

                                   }).ToList();

                return getdata;
            }
            catch (Exception ex)
            {
                dynamic result = ex;
                return result;
            }
        }

        public IEnumerable<MemberSearchModel> GetAllMemberById(int id)
        {
            var memberList = (from m in db.TblMembers
                              join py in db.TblPhysicians on m.PhysicianId equals py.PhysicianId
                              join c in db.TblClaims on m.MemberId equals c.MemberId into claims
                              from x in claims.DefaultIfEmpty()
                              where(m.UserId==id)
                              select new
                              {
                                  memberId = m.MemberId,
                                  firstName = m.FirstName,
                                  lastName = m.LastName,
                                  physicianName = py.PhysicianName,
                                  claimAmount = x == null ? 0 : x.ClaimAmount,
                                  claimId = x == null ? 0 : x.ClaimId,
                                  claimDate = x == null ? Convert.ToDateTime("9999-09-09") : x.ClaimDate

                              }).ToList();

            MemberSearchModel memberSearchModel;
            List<MemberSearchModel> memberSearchModels = new List<MemberSearchModel>();
            foreach (var item in memberList)
            {
                memberSearchModel = new MemberSearchModel();

                memberSearchModel.MemberId = item.memberId;
                memberSearchModel.ClaimId = item.claimId;
                memberSearchModel.FirstName = item.firstName;
                memberSearchModel.LastName = item.lastName;
                memberSearchModel.PhysicianName = item.physicianName;
                memberSearchModel.ClaimAmount = item.claimAmount;
                memberSearchModel.ClaimDate = item.claimDate;

                memberSearchModels.Add(memberSearchModel);
            }

            return memberSearchModels;
        }
        public IEnumerable<TblMember> GetMemberDetailByMemberId(int memberId)
        {
            var memberDetails = db.TblMembers.Where(x =>  x.MemberId == Convert.ToInt32(memberId)).ToList();
            return memberDetails;
        }
        public int GetMemberId(int userId)
        {
            int memberId = db.TblMembers.SingleOrDefault(x => x.UserId == Convert.ToInt32(userId)).MemberId;
            return memberId;
        }
    }
}
