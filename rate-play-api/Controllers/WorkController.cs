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
//     public class WorkController : ControllerBase
//     {
//         private readonly WorkRepository _workRepository;

//         public WorkController(WorkRepository workController)
//         {
//             _workRepository = workController;
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
//         public ActionResult<MachineWorkOrder> GetById(int id)
//         {
//             if (!_workRepository.TryGetDataById(id, out var machineWorkOrder))
//             {
//                 return NotFound();
//             }
//             return Ok(machineWorkOrder);
//         }
//         #endregion

//         #region 【查詢工單號碼的資料】GetByMachineWorkCode
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
//         // GET: api/work/{value}
//         [HttpGet("GetByMachineWorkCode")]
//         [Authorize]
//         [ProducesResponseType(200)]
//         [ProducesResponseType(404)]
//         public ActionResult<Users> GetByMachineWorkCode(string work_code)
//         {
//             // return work_code;
//             if (!_workRepository.TryGetByMachineWorkCode(work_code, out var work))
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
//         public async Task<ActionResult<MachineWorkOrder>> AddData([FromBody] MachineWorkOrder machineWorkOrder)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
//             machineWorkOrder.SetTime = DateTime.Now;
//             await _workRepository.AddDataAsync(machineWorkOrder);
//             return CreatedAtAction(nameof(GetById), new { id = machineWorkOrder.No }, machineWorkOrder);
//         }
//         #endregion
//     }
// }