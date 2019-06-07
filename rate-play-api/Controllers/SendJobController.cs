// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using rate_play_api.Repositories;
// using rate_play_api.Services.OfcoContext;

// // For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// namespace rate_play_api.Controllers
// {
//     [Route("api/[controller]")]
//     public class SendJobController : ControllerBase
//     {
//         private readonly SendJobRepository _SendJobRepository;

//         public SendJobController(SendJobRepository SendJobController)
//         {
//             _SendJobRepository = SendJobController;
//         }

//         #region 【獲取特定資料】GetById
//         /// <summary>
//         /// 從ID條件下取得資料
//         /// /api/Device/{value}
//         /// </summary>
//         /// <param name="id">id.</param>
//         /// <returns>
//         /// boolean.
//         /// </returns>
//         /// <remark>
//         /// Author:Kevin.
//         /// </remark>
//         [HttpGet("{id}")]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(404)]
//         public ActionResult<工令作業> GetById(int id)
//         {
//             if (!_SendJobRepository.TryGetDataById(id, out var 工令作業))
//             {
//                 return NotFound();
//             }
//             return Ok(工令作業);
//         }
//         #endregion

//         #region 【查詢工令作業的資料】GetBySendJob
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
//         // GET: api/sendjob/{value}
//         [HttpGet("GetBySendJob")]
//         [Authorize]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(404)]
//         public ActionResult<工令作業> GetBySendJob(string work_code)
//         {
//             // return work_code;
//             if (!_SendJobRepository.TryGetBySendJob(work_code, out var work))
//             {
//                 return NotFound();
//             }
//             return Ok(work);
//         }
//         #endregion

//         #region 【新增一筆工單資料】AddData
//         [HttpPost]
//         [Route("AddData")]
//         [ProducesResponseType(201)]
//         [ProducesResponseType(400)]
//         public async Task<ActionResult<工令作業>> AddData([FromBody] 工令作業 工令作業)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             // 工令作業.SetTime = DateTime.Now;
//             await _SendJobRepository.AddDataAsync(工令作業);
//             return CreatedAtAction(nameof(GetById), new { id = 工令作業.單據編號 }, 工令作業);
//         }
//         #endregion
//     }
// }