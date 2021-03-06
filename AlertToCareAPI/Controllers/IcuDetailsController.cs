﻿
using AlertToCareAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using AlertToCareAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertToCareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcuDetailsController : ControllerBase
    {
        private readonly IIcuConfigurationRepo _configurationRepository;
        public IcuDetailsController(IIcuConfigurationRepo repo)
        {
            _configurationRepository = repo;
        }
        // GET: api/<IcuConfigurationController>
        [HttpGet("IcuWards")]
        public IActionResult Get()
        {
            return Ok(_configurationRepository.GetAllIcu());
        }

        [HttpGet("IcuWards/{IcuId}")]
        public IActionResult Get(string icuId)
        {
            var icuStore = _configurationRepository.GetAllIcu();
            foreach (var icu in icuStore)
            {
                if (icu.IcuId == icuId)
                {
                    return Ok(icu);
                }
            }
            return BadRequest();
        }

        [HttpPost("IcuWards")]
        public IActionResult Post([FromBody] ICUBedDetails icu)
        {
            try
            {
                _configurationRepository.AddIcu(icu);
                
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("IcuWards/{IcuId}")]
        public IActionResult Put(string icuId, [FromBody] ICUBedDetails icu)
        {
            try
            {
                _configurationRepository.UpdateIcu(icuId, icu);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("Remove/IcuWards/{IcuId}")]
        public IActionResult Delete(string icuId)
        {
            try
            {
                _configurationRepository.RemoveIcu(icuId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
