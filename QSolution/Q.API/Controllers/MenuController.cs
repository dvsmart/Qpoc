using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Q.API.Filters;
using Q.API.Models;
using Q.Core.Interfaces;
using Q.Entities;

namespace Q.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Menu")]
    [ValidateModel]
    public class MenuController : Controller
    {
        private readonly IRepository<MenuItem> _menuRepository;

        public MenuController(IRepository<MenuItem> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // GET: api/Menu
        [HttpGet]
        public IActionResult List()
        {
            var items = _menuRepository.List().OrderBy(x => x.SortOrder)
                            .Select(item => MenuModel.ReturnMenuModel(item));
            return Ok(items);
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = MenuModel.ReturnMenuModel(_menuRepository.GetById(id));
            return Ok(item);
        }

        // POST: api/Menu
        [HttpPost]
        public IActionResult Post([FromBody] MenuModel item)
        {
            item.MenuGroupId = 1;
            var menu = MenuModel.ReturnMenuItem(item);
            _menuRepository.Add(menu);
            return Ok(MenuModel.ReturnMenuModel(menu));
        }

        // PUT api/Menu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Menu/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = _menuRepository.GetById(id);
            _menuRepository.Delete(task);
        }

    }
}
