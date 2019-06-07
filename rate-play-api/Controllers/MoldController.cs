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
//     public class MoldController : ControllerBase
//     {
//         private readonly MoldRepository MoldeRepository;

//         public MoldController(MoldRepository MoldRepository)
//         {
//             MoldeRepository = MoldRepository;
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
//         public ActionResult<線材櫃> GetById(int id)
//         {
//             if (!MoldeRepository.TryGetDataById(id, out var 線材櫃))
//             {
//                 return NotFound();
//             }
//             return Ok(線材櫃);
//         }
//         #endregion

//         #region 【查詢線材櫃的資料】GetByWire
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
//         // GET: api/Wire/{value}
//         [HttpGet("GetByWire")]
//         [Authorize]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(404)]
//         public ActionResult<線材櫃> GetByWire(string wire_code)
//         {
//             // return wire_code;
//             if (!MoldeRepository.TryGetByWire(wire_code, out var wire))
//             {
//                 return NotFound();
//             }
//             return Ok(wire);
//         }
//         #endregion

//         #region 【新增一筆工單資料】AddData
//         [HttpPost]
//         [Route("AddData")]
//         [ProducesResponseType(201)]
//         [ProducesResponseType(400)]
//         public async Task<ActionResult<線材櫃>> AddData([FromBody] 線材櫃 線材櫃)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             // 線材櫃.SetTime = DateTime.Now;
//             await MoldeRepository.AddDataAsync(線材櫃);
//             return CreatedAtAction(nameof(GetById), new { id = 線材櫃.品號 }, 線材櫃);
//         }
//         #endregion
//     }
// }