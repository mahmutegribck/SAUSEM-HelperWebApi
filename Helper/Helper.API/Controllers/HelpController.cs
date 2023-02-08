using Helper.Business.Categories;
using Helper.Business.Helps;
using Helper.Business.Helps.Dtos;
using Helper.Business.Users;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Helper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HelpController : ControllerBase
    {
        private readonly IHelpService _helpService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        private readonly UserManager<ApplicationUser> _userManager;


        public HelpController(IHelpService helpService, IUserService userService, UserManager<ApplicationUser> userManager, ICategoryService categoryService)
        {
            _helpService = helpService;
            _userService = userService;
            _userManager = userManager;
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllHelps()
        {
            var helps = await _helpService.GetAllHelps();

            if (helps.Count != 0)
            {
                return Ok(helps);
            }
            return NotFound("Paylaşım Bulunamadı");
        }


        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCheckedHelps()
        {
            var helps = await _helpService.GetAllCheckedHelps();

            if (helps.Count != 0)
            {
                return Ok(helps);
            }
            return NotFound("Onaylanmış Paylaşım Bulunamadı");
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUnCheckedHelps()
        {
            var helps = await _helpService.GetAllUnCheckedHelps();

            if (helps.Count != 0)
            {
                return Ok(helps);
            }
            return NotFound("Onaylanmamış Paylaşım Bulunamadı");
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllCheckedUserHelps()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var helps = await _helpService.GetAllCheckedUserHelps(user.Id);

                if (helps.Count != 0)
                {
                    return Ok(helps);
                }
                return NotFound("Onaylanmış Paylaşım Bulunamadı");
            }
            return NotFound("Kullanıcı Bulunamadı");
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllUnCheckedUserHelps()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var helps = await _helpService.GetAllUnCheckedUserHelps(user.Id);

                if (helps.Count != 0)
                {
                    return Ok(helps);
                }
                return NotFound("Onaylanmamış Paylaşım Bulunamadı");
            }
            return NotFound("Kullanıcı Bulunamadı");
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllUserHelps()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var helps = await _helpService.GetAllUserHelps(user.Id);

                if (helps.Count != 0)
                {
                    return Ok(helps);
                }
                return NotFound("Paylaşım Bulunamadı");
            }
            return NotFound("Kullanıcı Bulunamadı");
        }


        [HttpGet]
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetHelpById(int id)
        {
            var help = await _helpService.GetHelpById(id);
            if (help != null)
            {
                return Ok(help);
            }
            return NotFound("Paylaşım Bulunamadı");
        }



        [HttpGet]
        [Route("[action]/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetHelpByCategoryId(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category != null)
            {
                var helps = await _helpService.GetHelpsByCategoryId(id);
                if (helps.Count != 0)
                {
                    return Ok(helps);
                }
                return NotFound("Kategoriye Ait Paylaşım Bulunamadı");
            }
            return NotFound("Kategori Bulunamadı");
        }


        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> CreateHelp([FromBody] CreateHelpDto createHelpDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var category = await _categoryService.GetCategoryById(createHelpDto.CategoryId);
                if (category != null)
                {
                    var result = await _helpService.CreateHelp(user.Id, createHelpDto);
                    if (result)
                    {
                        return Ok("Başarıyla Oluşturuldu");
                    }
                    return BadRequest("Paylaşım Oluşturulamadı");
                }
                return NotFound("Kategori Bulunamadı");
            }
            return NotFound("Kullanıcı Bulunamadı");
        }


        [HttpDelete]
        [Route("[action]/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteHelp(int id)
        {
            if (await _helpService.GetHelpById(id) != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var result = await _helpService.DeleteHelp(user.Id, id);
                    if (result)
                    {
                        return Ok("Paylaşım Silindi");
                    }
                    return BadRequest("Paylaşım Silinemedi");
                }
                return NotFound("Kullanıcı Bulunamadı");
            }
            return NotFound("Paylaşım Bulunamadı");
        }


        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateHelp(int helpId, [FromBody] UpdateHelpDto updateHelpDto)
        {
            if (await _helpService.GetHelpById(helpId) != null)
            {
                var user = await _userManager.GetUserAsync(User);
                await _helpService.UpdateHelp(helpId, user.Id, updateHelpDto);

                return Ok("Paylaşım Güncellendi");
            }
            return BadRequest("Paylaşım Bulunamadı");
        }


        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetCheckedHelp(int id)
        {
            var checkHelp = await _helpService.GetHelpById(id);
            if (checkHelp != null)
            {
                await _helpService.SetCheckedHelp(checkHelp);

                return Ok("Paylaşım Onaylandı");
            }
            return BadRequest("Paylaşım Bulunamadı");
        }


        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetUnCheckedHelp(int id)
        {
            var unCheckHelp = await _helpService.GetHelpById(id);
            if (unCheckHelp != null)
            {
                await _helpService.SetUnCheckedHelp(unCheckHelp);

                return Ok("Paylaşım İptal Edildi");
            }
            return BadRequest("Paylaşım Bulunamadı");
        }
    }
}
