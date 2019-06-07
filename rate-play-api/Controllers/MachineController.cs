using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rate_play_api.Repositories;
using rate_play_api.Services.OfcoContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rate_play_api.Controllers
{
    [Route("api/[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly MachineRepository _MachineRepository;

        public MachineController(MachineRepository MachineController)
        {
            _MachineRepository = MachineController;
        }

        #region 【獲取特定資料】GetById
        /// <summary>
        /// 從ID條件下取得資料
        /// /api/Device/{value}
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
        public ActionResult<Machine> GetById(int id)
        {
            if (!_MachineRepository.TryGetDataById(id, out var Machine))
            {
                return NotFound();
            }
            return Ok(Machine);
        }
        #endregion

        #region 【查詢工單號碼的資料】GetByMachineMachineCode
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
        // GET: api/machine/{value}
        [HttpGet("GetByMachineCode")]
        [Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Machine> GetByMachineCode(string machine_code)
        {
            // return machine_code;
            if (!_MachineRepository.TryGetByMachineCode(machine_code, out var Machine))
            {
                return NotFound();
            }
            return Ok(Machine);
        }
        #endregion

        #region 【新增一筆工單資料】AddData
        [HttpPost]
        [Route("AddData")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Machine>> AddData([FromBody] Machine Machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Machine.SetTime = DateTime.Now;
            await _MachineRepository.AddDataAsync(Machine);
            return CreatedAtAction(nameof(GetById), new { id = Machine.MahId }, Machine);
        }
        #endregion
    }
}