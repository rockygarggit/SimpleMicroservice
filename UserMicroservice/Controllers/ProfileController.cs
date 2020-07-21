using Commons.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileMicroservice.DTO.Profile;
using ProfileMicroservice.Services;
using System.Collections.Generic;

namespace ProfileMicroservice.Controllers
{
    [Authorize]
    [Route(RouteConsts.ROUTE_USER_BASE)]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService) {
            _profileService = profileService;
        }

        [Authorize(Roles = RoleConsts.ROLE_USER)]
        [HttpGet]
        public ActionResult<List<ProfileResponseDTO>> HandleGetAllUsers() {
            return Ok(this._profileService.GetAll());
        }

        [AllowAnonymous]
        [HttpGet(RouteConsts.ROUTE_USER_GET_ONE_BY_UUID)]
        public ActionResult<ProfileResponseDTO> HandleGetOneUserByUuid(string uuid) {
            return Ok(this._profileService.GetOneByUuid(uuid));
        }

    }
}