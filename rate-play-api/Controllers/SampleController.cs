// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using rate_play_api.Repositories;
// using rate_play_api.Services.OfcoContext;

// // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// namespace rate_play_api.Controllers {
//     [Route("api/[controller]")]
//     public class SampleController : Controller {
//         private readonly SampleRepository _sapleRepository;

//         public SampleController(SampleRepository sampleController) {
//             _sapleRepository = sampleController;
//         }

//         #region
//         /// <summary>
//         /// 取得所有資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         /// <remark>
//         /// Author:Kevin Cheng (quickey123@gmail.com).
//         /// </remark>
//         // GET: api/login
//         [HttpGet]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(400)]
//         public IEnumerable<Users> Get() {
//             return _sapleRepository.GetAllData();
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 取得最後一筆Users資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         /// <remark>
//         /// Author:Kevin Cheng (quickey123@gmail.com).
//         /// </remark>
//         // GET: api/login/getLastData
//         [HttpGet]
//         [Route("getLastData")]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(400)]
//         public Users GetLastData() {
//             return _sapleRepository.GetLastData();
//         }
//         #endregion

//         #region
//         /// <summary>
//         /// 取得七日資料
//         /// </summary>
//         /// <returns>
//         /// data list.
//         /// </returns>
//         /// <remark>
//         /// Author:Kevin Cheng (quickey123@gmail.com).
//         /// </remark>
//         // GET: api/login/getSevenDays
//         [HttpGet]
//         [Route("getSevenDays")]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(400)]
//         public object GetSevenDaysData() {
//             return _sapleRepository.GetSevenDaysData();
//         }
//         #endregion

//         #region 【獲取特定資料】GetById
//         /// <summary>
//         /// 從ID條件下取得資料
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         /// <remark>
//         /// Author:Kevin Cheng (quickey123@gmail.com).
//         /// </remark>
//         // GET: api/login/{value}
//         [HttpGet("{id}")]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(404)]
//         public ActionResult<Users> GetById(int id) {
//             if (!_sapleRepository.TryGetDataById(id, out var login)) {
//                 return NotFound();
//             }
//             return Ok(login);
//         }
//         #endregion

//         #region insert water meter to database.
//         /// <summary>
//         /// insert water meter to database.
//         /// </summary>
//         /// <returns>insert water meter to database.</returns>
//         /// <remark>
//         /// Author:Kevin Cheng (quickey123@gmail.com).
//         /// </remark>
//         // PUT: api/Login
//         [HttpPut]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(400)]
//         public async Task<ActionResult<Users>> AddData([FromBody] Users model) {
//             model.UpdTime = DateTime.Now;
//             await _sapleRepository.AddDataAsync(model);
//             return CreatedAtAction(nameof(GetById), new { id = model.UserId }, model);
//         }
//         #endregion

//         #region 【刪除一筆特定資料】DeleteLogin
//         /// <summary>
//         /// 刪除一筆特定資料
//         /// </summary>
//         /// <param name="id">id</param>
//         /// <returns>
//         /// Login Model table values.
//         /// </returns>
//         /// <remark>
//         /// Author:Kevin.
//         /// </remark>
//         // DELETE: api/Login/{value}
//         [HttpDelete("{id}")]
//         [ProducesResponseType(204)]
//         [ProducesResponseType(404)]
//         public async Task<ActionResult<Users>> DeleteData(long id) {
//             if (!_sapleRepository.TryGetDataById(id, out var Schedule)) {
//                 return NotFound();
//             }
//             await _sapleRepository.DeleteDataAsync(Schedule);
//             return NoContent();
//         }
//         #endregion
//     }
// }