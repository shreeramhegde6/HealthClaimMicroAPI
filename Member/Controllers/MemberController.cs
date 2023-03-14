using Member.Models;
using Member.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IMemberService memberService;
        public MemberController(IMemberService _memberService)
        {
            memberService = _memberService;
        }

        [HttpGet]
        [Route("GetAllMember")]
        public IEnumerable<MemberSearchModel> GetAllMember()
        {
            var memberList = memberService.GetAllMember();
            return memberList;
        }
        [HttpGet]
        [Route("GetMemberId")]
        public int GetMemberId(int userId)
        {
            int memberId = memberService.GetMemberId(userId);
            return memberId;
        }

        [HttpGet]
        [Route("GetAllMemberById")]
        public IEnumerable<MemberSearchModel> GetAllMemberById(int id)
        {
            var memberList = memberService.GetAllMemberById(id);
            return memberList;
        }
        [HttpGet]
        [Route("GetMemberDetailByMemberId")]
        public IEnumerable<TblMember> GetMemberDetailByMemberId(int memberId)
        {
            var memberDetails = memberService.GetMemberDetailByMemberId(memberId);
            return memberDetails;
        }

        [HttpGet]
        [Route("GetAllPhysician")]
        public IEnumerable<TblPhysician> GetAllPhysician()
        {
            var physicianList = memberService.GetAllPhysician();
            return physicianList;
        }


        [HttpPost]
        [Route("add-member")]
        public IActionResult SaveMember([FromBody] TblMember member)
        {
            try
            {
                var data =  memberService.SaveMember(member);
                return Ok(data);

            }
            catch (Exception ex)
            {
                return Ok(ex);

            }

        }
        [HttpPost]
        [Route("SearchMember")]
        public IActionResult SearchMember([FromBody]SearchDataModel searchDataModel)
        {
            try
            {
                dynamic data = null;
                if (searchDataModel != null)
                {
                    data =  memberService.SearchMember(searchDataModel);
                }

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
