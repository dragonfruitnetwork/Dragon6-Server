// Dragon6 Server Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under a modified BSD-3 Clause License. Please refer to the licence file in the root of this repo for more details

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DragonFruit.Six.Web.API
{
    [Route("api/accounts/{platform}/level")]
    [ApiController]
    public class AccountLevelController : ControllerBase
    {
        private readonly StatsClient _client;

        public AccountLevelController(StatsClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IEnumerable<PlayerLevelStats> GetLevel(Platform platform, [Required] [FromQuery(Name = "ids")] string platformIds)
        {
            var accounts = platformIds.Split(',').Select(x => new AccountInfo
            {
                Guid = x,
                Platform = platform
            });

            return _client.GetLevel(accounts);
        }
    }
}
