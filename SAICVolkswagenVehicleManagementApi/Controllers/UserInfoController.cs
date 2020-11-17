﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAICVolkswagenVehicleManagement_Helper;
using SAICVolkswagenVehicleManagement_Model;

namespace SAICVolkswagenVehicleManagementApi.Controllers
{
    /// <summary>
    /// 用户信息控制器Api
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IRepositoryWrapper dbContext;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dbContext"></param>
        public UserInfoController(IRepositoryWrapper _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserInfoAsync()
        {
            //获取员工信息表
            IEnumerable<R_UserInfo> r_UserInfos = await dbContext.r_UserInfoRepository.GetAllInfoAsync();
            //获取部门列表
            IEnumerable<DepartmentInfo> departmentInfos = await dbContext.departmentInfoRepository.GetAllInfoAsync();
            return Ok(r_UserInfos.ToList());
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="r_UserInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginUserInfoAsync(R_UserInfo r_UserInfo)
        {
            //判断传过来的值是否存在
            if (await dbContext.r_UserInfoRepository.IsExistAsync(r_UserInfo.UserID))
            {
                //找到这一条userInfo的数据
                R_UserInfo userInfo = await dbContext.r_UserInfoRepository.GetFirstInfo(r_UserInfo.UserID);
                //判断登录用户名和密码
                if (r_UserInfo.UserName == userInfo.UserName && r_UserInfo.UserPassWord == userInfo.UserPassWord)
                {
                    return Ok(1);
                }
            }
            //如果没有找到说明数据不存在
            return NotFound();
        }

        /// <summary>
        /// 找到一条数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetFirstUserInfoAsync(Guid userId)
        {
            //判断传过来的值是否存在
            if(await dbContext.r_UserInfoRepository.IsExistAsync(userId))
            {
                R_UserInfo r_UserInfo = await dbContext.r_UserInfoRepository.GetFirstInfo(userId);
                return Ok(r_UserInfo);
            }
            //如果没有说明数据不存在
            return NotFound();
        }

        /// <summary>
        /// 注册员工信息
        /// </summary>
        /// <param name="r_UserInfo"></param>
        /// <returns>注册员工信息</returns>
        [HttpPost]
        public async Task<IActionResult> InsertUserInfoAsync(R_UserInfo r_UserInfo)
        {
            dbContext.r_UserInfoRepository.CreateInfo(r_UserInfo);
            if(await dbContext.r_UserInfoRepository.SaveAsync())
            {
                return Ok(1);
            }
            return Ok("注册失败");
        }

        /// <summary>
        /// 删除一条用户数据
        /// </summary>
        /// <param name="r_UserInfo"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteUserInfoAsync(R_UserInfo r_UserInfo)
        {
            //判断传过来的值是否存在
            if(await dbContext.r_UserInfoRepository.IsExistAsync(r_UserInfo.UserID))
            {
                //找到这条数据
                R_UserInfo userInfo = await dbContext.r_UserInfoRepository.GetFirstInfo(r_UserInfo.UserID);
                dbContext.r_UserInfoRepository.DeleteInfo(userInfo);
                if(await dbContext.r_UserInfoRepository.SaveAsync())
                {
                    return Ok(1);
                }
            }
            return NotFound();
        }

        /// <summary>
        /// 修改一条用户数据
        /// </summary>
        /// <param name="r_UserInfo">反填的用户信息</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUserInfoAsync(R_UserInfo r_UserInfo)
        {
            //判断穿过来的值是否存在
            if(await dbContext.r_UserInfoRepository.IsExistAsync(r_UserInfo.UserID))
            {
                //找到这条数据
                dbContext.r_UserInfoRepository.UpdateInfo(r_UserInfo);
                if(await dbContext.r_UserInfoRepository.SaveAsync())
                {
                    return Ok(1);
                }
            }
            //如果不存在
            return NotFound();
        }
    }
}