// Dragon6 Server Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under a modified BSD-3 Clause License. Please refer to the licence file in the root of this repo for more details

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.Web.Services
{
    public static class AccountInfoExtensions
    {
        public static IEnumerable<AccountInfo> ToAccountInfo(this IEnumerable<string> ids, Platform platform)
        {
            return ids.Select(x => new AccountInfo
            {
                Guid = x,
                Platform = platform
            });
        }
    }
}
