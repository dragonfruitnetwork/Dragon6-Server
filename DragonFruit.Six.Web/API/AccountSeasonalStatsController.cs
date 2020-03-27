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
    [Route("api/accounts/{platform}/stats/season")]
    [ApiController]
    public class AccountSeasonalStatsController : ControllerBase
    {
        private readonly StatsClient _client;

        public AccountSeasonalStatsController(StatsClient client)
        {
            _client = client;
        }

        [HttpGet]
        public IEnumerable<SeasonStats> GetCurrentSeason(Platform platform, [Required] [FromQuery(Name = "ids")] string platformIds, [FromQuery(Name = "r")] Regions region = Regions.EMEA)
        {
            var accounts = platformIds.Split(',').ToAccountInfo(platform);
            return _client.GetSeasonStats(accounts, region.ToString());
        }

        [HttpGet("{seasonId:int}")]
        public IEnumerable<SeasonStats> GetSeason(Platform platform, int seasonId, [Required] [FromQuery(Name = "ids")] string platformIds, [FromQuery(Name = "r")] Regions region = Regions.EMEA)
        {
            var accounts = platformIds.Split(',').ToAccountInfo(platform);
            return _client.GetSeasonStats(accounts, region.ToString(), seasonId);
        }
    }
}
