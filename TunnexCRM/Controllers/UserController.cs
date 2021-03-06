﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Domains;
using CRMSystem.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRMSystem.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepo<User> _repo;
        private readonly IUserRepo _uRepo;
        public UserController(IRepo<User> repo, IUserRepo uRepo)
        {
            _repo = repo;
            _uRepo = uRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("SaveUser")]
        public async Task<IActionResult> Save(User data)
        {
            var result = await _repo.insertAsync(data);
            if (result > 0)
                return Ok(result);
            return NotFound();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            var result = await _uRepo.GetUserByNameandPassword(username,password);
            if (result == null)
                return Unauthorized();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> Update(User data)
        {
            var result = await _repo.updateAsync(data);
            if (result > 0)
                return Ok(result);
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetUserByID/{ID}")]
        public async Task<IActionResult> GetUserByID(int ID)
        {
            var result = await _repo.getAsync(ID);
            return Ok(result);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _repo.getAllAsync();
            return Ok(result);

        }
    }
}