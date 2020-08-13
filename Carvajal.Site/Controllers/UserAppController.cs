using Carvajal.Models;
using Carvajal.Services;
using Carvajal.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Carvajal.Site.Controllers
{
    [Route("api/UserApp")]
    [ApiController]
    public class UserAppController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserAppController(IUserServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpPost]
        [Route("UserAppInsert")]
        public IActionResult UserAppInsert([FromBody] UserAppViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userApp = model.UserViewModelToUser();

                userApp = _services.UserAppInsert(userApp);

                return Ok(userApp);
            }
            catch (DataErrorException ex)
            {
                return StatusCode(500, ex.MessageInnerException);
            }
            catch (ExceptionBusiness ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UserAppUpdate")]
        public IActionResult UserAppUpdate([FromBody] UserAppViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userApp = model.UserViewModelToUser();

                userApp = _services.UserAppUpdate(userApp);

                if (userApp == null)
                    return NotFound($"User id {model.UserId} not Found");

                return Ok(userApp);
            }
            catch (DataErrorException ex)
            {
                return StatusCode(500, ex.MessageInnerException);
            }
            catch (ExceptionBusiness ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("UserAppUpdate")]
        public IActionResult GetUserFromById([FromQuery] int userId)
        {
            try
            {
                var userApp = _services.GetUserAppFromById(userId);

                if (userApp == null)
                    return NotFound($"User id {userId} not Found");

                return Ok(userApp);
            }
            catch (DataErrorException ex)
            {
                return StatusCode(500, ex.MessageInnerException);
            }
            catch (ExceptionBusiness ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}