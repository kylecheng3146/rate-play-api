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
    public class ActivityController : ControllerBase
    {
        private readonly ActivityRepository _ActivityRepository;

        public ActivityController(ActivityRepository ActivityController)
        {
            _ActivityRepository = ActivityController;
        }

        #region 【獲取特定資料】GetById
        /// <summary>
        /// 從ID條件下取得資料
        /// /api/activity/{value}
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
        public ActionResult<Activity> GetById(int id)
        {
            if (!_ActivityRepository.TryGetDataById(id, out var Activity))
            {
                return NotFound();
            }
            return Ok(Activity);
        }
        #endregion

        #region 【查詢工單號碼的資料】GetByActivityActivityCode
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
        // GET: api/Activity/{value}
        [HttpGet("GetByActivityCode")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Activity> GetByActivityCode(string Activity_code)
        {
            // return Activity_code;
            if (!_ActivityRepository.TryGetByActivitySouper(Activity_code, out var Activity))
            {
                return NotFound();
            }
            return Ok(Activity);
        }
        #endregion

        #region 【新增一筆工單資料】AddData
        [HttpPost]
        [Route("AddData")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Activity>> AddData([FromBody] Activity Activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ActivityRepository.AddDataAsync(Activity);
            return CreatedAtAction(nameof(GetById), new { id = Activity.Id }, Activity);
        }
        #endregion
    }
}