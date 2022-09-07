using IoTDevicesProject.Business_logic;
using IoTDevicesProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDevicesProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private CategoryFunctions cf;
        public CategoryController(CategoryFunctions categoryFuns)
        {
            cf = categoryFuns;
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Index()
        {
            return Ok(cf.getAllCategory());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getCategoryUsingId(Guid id)
        {
            return Ok(cf.getCategoryWithId(id));
        }


        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult createCategory(Category category)
        {
            if(category != null)
            {
                cf.createCategory(category);
                return Ok("Created");
            }
            return NotFound("Category null");
        }


        [HttpPatch]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult updateCategory(Category a)
        {
            if (a != null)
            {
                cf.updateCategory(a);
                return Ok("Updated");
            }
            return NotFound("category Not found");
        }


        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult deleteCategory(Category a)
        {
            if (a != null)
            {
                cf.deleteCategory(a);
                return Ok("Deleted");
            }
            return NotFound("Category not found");
        }
    }
}
