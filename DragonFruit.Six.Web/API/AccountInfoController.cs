// Dragon6 Server Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under a modified BSD-3 Clause License. Please refer to the licence file in the root of this repo for more details

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DragonFruit.Six.Web.API
{
    [Route("api/accounts/{platform}")]
    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly StatsClient _client;

        public AccountInfoController(StatsClient client)
        {
            _client = client;
        }

        [HttpGet]
        [HttpGet("name")]
        public IEnumerable<AccountInfo> GetUsersFromName(Platform platform, [Required] [FromQuery(Name = "q")] string names)
        {
            return _client.GetUsers(platform, LookupMethod.Name, names.Split(','));
        }

        [HttpGet("id")]
        public IEnumerable<AccountInfo> GetUsersFromId(Platform platform, [Required] [FromQuery(Name = "q")] string names)
        {
            return _client.GetUsers(platform, LookupMethod.Name, names.Split(','));
        }
    }
}
