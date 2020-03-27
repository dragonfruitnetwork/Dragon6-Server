# Dragon6 Server

## Overview
This is a very basic ASP.NET Core server for getting r6 stats from. This is designed to show users how to use the `UbisoftAuthClient`, `Dragon6Client` and Extensions. This uses `ApiControllers` and `Newtonsoft.Json` to provide fast access to stats. Please note DragonFruit do not use this and as a result, support will be limited. YMMV

## How to use

Clone the repo, change the `StatsClient.cs`'s `UbisoftAuthClient` constructor to contain a set of valid login details to ubisoft. This can be a shell account if you want. These are used to get the time-limited keys for accessing stats.

Build and run, the endpoints are below

## Endpoints

Endpoints in this follow the pattern `~/api/accounts/{platform}/{action}?{ids|q}={value}` where value is a CSL of queries

| Endpoint                                                                          | Action                                                                                  |
|-----------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|
| ~/api/accounts/pc/name?q=Curry.                                                   | Lookup an account on **PC** with the username `Curry.` (case-insensitive)               |
| ~/api/accounts/psn/id?q=56671f61-9d4a-46a2-99d9-ae97447b2444                      | Lookup an account on **PSN** with the ubisoft id `56671f61-9d4a-46a2-99d9-ae97447b2444` |
| ~/api/accounts/pc/stats/general?ids=14c01250-ef26-4a32-92ba-e04aa557d619          | Get general stats for the account with the id `14c01250-ef26-4a32-92ba-e04aa557d619`    |
| ~/api/accounts/pc/stats/operator?ids=14c01250-ef26-4a32-92ba-e04aa557d619         | Get operator stats for account                                                          |
| ~/api/accounts/pc/stats/weapon?ids=14c01250-ef26-4a32-92ba-e04aa557d619           | Get weapon stats for account                                                            |
| ~/api/accounts/pc/stats/season/14?ids=14c01250-ef26-4a32-92ba-e04aa557d619&r=emea | Get ranked stats for season **16** the account in the **emea** region                   |
| ~/api/accounts/pc/stats/season?ids=14c01250-ef26-4a32-92ba-e04aa557d619&r=apac    | Get ranked stats for the **current season** in the **apac** region                      |

## License

This is licensed under a BSD-3 Clause license with a modification to the last clause. If you take or use any part of this program we require you to put in the footer or about page that your program is `Powered by Dragon6`