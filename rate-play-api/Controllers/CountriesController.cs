using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rate_play_api.Repositories;
using rate_play_api.Services.RatePlayContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rate_play_api.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly CountriesRepository _CountriesRepository;

        public CountriesController(CountriesRepository CountriesController)
        {
            _CountriesRepository = CountriesController;
        }

        #region 【獲取特定資料】GetById
        /// <summary>
        /// 從ID條件下取得資料
        /// /api/Countries/{value}
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        /// <remark>
        /// Author:Kevin.
        /// </remark>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Countries> GetById(int id)
        {
            if (!_CountriesRepository.TryGetDataById(id, out var Countries))
            {
                return NotFound();
            }
            return Ok(Countries);
        }
        #endregion

        #region 【查詢工單號碼的資料】GetByCountriesCountriesCode
        /// <summary>
        /// 從ID條件下取得資料
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>
        /// boolean.
        /// </returns>
        /// <remark>
        /// Author:Kevin Cheng (quickey123@gmail.com).
        /// </remark>
        // GET: api/Countries/{value}
        [HttpGet("GetByCountryCode")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Countries> GetByCountriesCode(string country_code)
        {
            // return Countries_Code;
            if (!_CountriesRepository.TryGetByCountry(country_code, out var Countries))
            {
                return NotFound();
            }
            return Ok(Countries);
        }
        #endregion

        #region 【新增一筆工單資料】AddData
        [HttpPost]
        [Route("AddData")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Countries>> AddData([FromBody] Countries Countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _CountriesRepository.AddDataAsync(Countries);
            return CreatedAtAction(nameof(GetById), new { id = Countries.Id }, Countries);
        }
        #endregion

        #region
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns>
        /// data list.
        /// </returns>
        /// <remark>
        /// Author:Kevin Cheng (quickey123@gmail.com).
        /// </remark>
        // GET: api/countries
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IEnumerable<Object> Get()
        {
            return _CountriesRepository.GetAllData();
        }
        #endregion
    }
}