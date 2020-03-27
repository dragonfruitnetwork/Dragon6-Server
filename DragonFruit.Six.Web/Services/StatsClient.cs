// Dragon6 Server Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under a modified BSD-3 Clause License. Please refer to the licence file in the root of this repo for more details

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.API.Clients;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Helpers;

namespace DragonFruit.Six.Web.Services
{
    public class StatsClient : Dragon6Client
    {
        private readonly string _tokenFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DragonFruit Network", "ubi.token");
        private readonly string _operatorFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DragonFruit Network", "operatordata.json");

        private readonly UbisoftAuthClient _authClient;

        public StatsClient()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_tokenFile));

            //create a new authclient for getting the session keys. Store logins somewhere that is NOT in the code
            _authClient = new UbisoftAuthClient(Environment.GetEnvironmentVariable("ubi_user", EnvironmentVariableTarget.User),
                Environment.GetEnvironmentVariable("ubi_password", EnvironmentVariableTarget.User));
        }

        /// <summary>
        /// Tells the Dragon6 Client how to get a token in the case it's restarted or expired
        /// </summary>
        protected override TokenBase GetToken()
        {
            if (File.Exists(_tokenFile))
            {
                var token = FileServices.ReadFile<UbisoftToken>(_tokenFile);

                if (!token.Expired)
                    return token;
            }

            var newToken = _authClient.GetToken();

            FileServices.WriteFile(_tokenFile, newToken);
            return newToken;
        }

        public IEnumerable<OperatorStats> GetOperatorData()
        {
            if (!File.Exists(_operatorFile))
            {
                using var webClient = new WebClient();
                webClient.DownloadFile("https://d6static.dragonfruit.network/data/operators.json", _operatorFile);
            }

            return OperatorData.GetOperatorDataFromFile(_operatorFile);
        }
    }
}
