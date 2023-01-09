using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Veylib.ICLI;
using Veylib.Utilities.Net;

namespace Astra
{
    internal class BotChecks
    {
        static Core core = new Core();
        public static void Authorization()
        {
            NetRequest request = new NetRequest("https://discord.com/api/v10/users/@me");
            request.SetHeader("Authorization", $"Bot {config.token}");
            NetResponse response = request.Send();

            if (response.Status != HttpStatusCode.OK)
            {
                core.WriteLine(Color.Red, "Couldn't Authorize The Bot Token");
                core.Delay(2500);
                Environment.Exit(0);
            }

            request = new NetRequest($"https://discord.com/api/v10/guilds/{config.guild}");
            request.SetHeader("Authorization", $"Bot {config.token}");
            response = request.Send();
            if(response.Status != HttpStatusCode.OK)
            {
                core.WriteLine(Color.Red, "Couldn't Authorize The Target Guild");
                core.Delay(2500);
                Environment.Exit(0);
            }
        }

        public static void Information()
        {
            NetRequest request = new NetRequest("https://discord.com/api/v10/users/@me");
            request.SetHeader("Authorization", $"Bot {config.token}");
            NetResponse response = request.Send();
            dynamic json = response.ToJson();
            // need to get username via json
        }
    }
}
