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
    [Route("api/accounts/{platform}/stats")]
    [ApiController]
    public class AccountStatsController : ControllerBase
    {
        private readonly StatsClient _client;

        public AccountStatsController(StatsClient client)
        {
            _client = client;
        }

        [HttpGet("general")]
        public IEnumerable<GeneralStats> GetGeneralStats(Platform platform, [Required] [FromQuery(Name = "ids")] string platformIds)
        {
            var accounts = platformIds.Split(',').ToAccountInfo(platform);
            return _client.GetStats(accounts);
        }

        [HttpGet("weapon")]
        public IEnumerable<IEnumerable<WeaponStats>> GetWeaponStats(Platform platform, [Required] [FromQuery(Name = "ids")] string platformIds)
        {
            var accounts = platformIds.Split(',').ToAccountInfo(platform);
            return _client.GetWeaponStats(accounts);
        }

        [HttpGet("operator")]
        public IEnumerable<IEnumerable<OperatorStats>> GetOperatorStats(Platform platform, [Required] [FromQuery(Name = "ids")] string platformIds)
        {
            var accounts = platformIds.Split(',').ToAccountInfo(platform);
            return _client.GetOperatorStats(accounts, _client.GetOperatorData());
        }
    }
}
