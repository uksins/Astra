using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// External Imports
using Veylib.ICLI;
using Veylib.Utilities.Net;
using Veylib.VeyAPI.VeyAuth;

namespace Astra
{
    internal class BotChecks
    {
        // Define The Core Of Veylib
        static Core core = new Core();
        
        public static void Authorization()
        {
            // Check If Token Is Valid
            NetRequest request = new NetRequest("https://discord.com/api/v10/users/@me");
            request.SetHeader("Authorization", $"Bot {config.token}");
            NetResponse response = request.Send();

            if (response.Status != HttpStatusCode.OK)
            {
                core.WriteLine(Color.Red, "Couldn't Authorize The Bot Token");
                core.Delay(2500);
                Environment.Exit(0);
            }
            // Token Is Valid: Check If Bot Is In Guild
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
        
        // Get Username And Bot ID
        public static void Information()
        {
            NetRequest request = new NetRequest("https://discord.com/api/v10/users/@me");
            request.SetHeader("Authorization", $"Bot {config.token}");
            NetResponse response = request.Send();
            dynamic json = response.ToJson();
            string username = json.username;
            string id = json.id;
            core.WriteLine($"Client Username: [{username}]");
            core.WriteLine($"Client ID: [{id}]");
            config.username = username;
            config.id = id;
        }
    }
}
