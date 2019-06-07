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
    public class RateController : ControllerBase
    {
        private readonly RateRepository _RateRepository;

        public RateController(RateRepository RateController)
        {
            _RateRepository = RateController;
        }

        #region 【獲取特定資料】GetById
        /// <summary>
        /// 從ID條件下取得資料
        /// /api/Exrate/{value}
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
        public ActionResult<Exrate> GetById(int id)
        {
            if (!_RateRepository.TryGetDataById(id, out var Exrate))
            {
                return NotFound();
            }
            return Ok(Exrate);
        }
        #endregion

        #region 【查詢工單號碼的資料】GetByExrateExrateCode
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
        // GET: api/rate/{value}
        [HttpGet("GetByRateName")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Exrate> GetByRateName(string rate_name)
        {
            // return rate_name;
            if (!_RateRepository.TryGetByExrate(rate_name, out var Exrate))
            {
                return NotFound();
            }
            return Ok(Exrate);
        }
        #endregion

        #region 【查詢工單號碼的資料】GetByExrateExrateCode
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
        // GET: api/rate/{value}
        [HttpGet("GetHistoryRate")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Exrate> GetHistoryRate(string rate_name)
        {
            // return rate_name;
            if (!_RateRepository.TryGetHistoryRate(rate_name, out var Exrate))
            {
                return NotFound();
            }
            return Ok(Exrate);
        }
        #endregion

        #region 【新增一筆工單資料】AddData
        [HttpPost]
        [Route("AddData")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Exrate>> AddData([FromBody] Exrate Exrate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _RateRepository.AddDataAsync(Exrate);
            return CreatedAtAction(nameof(GetById), new { id = Exrate.Id }, Exrate);
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
        // GET: api/rate
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IEnumerable<Object> Get()
        {
            return _RateRepository.GetAllData();
        }
        #endregion
    }
}