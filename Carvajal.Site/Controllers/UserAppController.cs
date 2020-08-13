using Carvajal.Models;
using Carvajal.Services;
using Carvajal.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carvajal.Site.Controllers
{
    /// <summary>
    /// Controlador para el componente IUserServices
    /// </summary>
    [Route("api/UserApp")]
    [ApiController]
    public class UserAppController : ControllerBase
    {
        /// <summary>
        /// Componente de servicio IUserServices
        /// </summary>
        private readonly IUserServices _services;

        /// <summary>
        /// Constructor del controlador UserAppController
        /// </summary>
        /// <param name="services">Componente de servicio IUserServices/param>
        public UserAppController(IUserServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Agrega un nuevo usuario a la base de datos
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar los usuario por nombre completo, numero de identificacion y tipo de identificacion
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserAppsFromFilter")]
        public IActionResult GetUserAppsFromFilter([FromBody] UserFilter filter)
        {
            try
            {
                var userModel = new List<UserAppViewModel>();
                var users = _services.GetUserAppsFromFilter(filter);
                if (users.Any())
                    userModel = users.Select(x => x.UserToUserViewModel()).ToList();

                return Ok(userModel);
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

        /// <summary>
        /// Modifica un usuario por id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Consulta un usuario por id
        /// </summary>
        /// <param name="userId">usuario id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserFromById")]
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

        /// <summary>
        /// Consulta un usuario por id
        /// </summary>
        /// <param name="userId">usuario id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTypeIdsFromAll")]
        public IActionResult GetTypeIdsFromAll()
        {
            try
            {
                var typeIds = _services.GetTypeIdsFromAll();

                return Ok(typeIds);
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