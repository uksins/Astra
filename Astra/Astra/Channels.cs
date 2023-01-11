using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Veylib.ICLI;
using Veylib.Utilities.Net;
using Newtonsoft.Json;

namespace Astra
{
    internal class Channels
    {
        // Define The Core Of Veylib
        static Core core = new Core();

        // Hold The Data For Our Class
        public class Channel
        {
            public string name { get; set; }
            public int type { get; set; }
        }

        // Create's A Channel
        public static void Create()
        {
        restart:
            var cname = core.ReadLine("@Channel-Name $ ");
            var channel = new Channel()
            {
                name = cname,
                type = 0
            };
            var content = JsonConvert.SerializeObject(channel);
            var request = new NetRequest($"https://discord.com/api/v10/guilds/{config.guild}/channels");
            request.SetHeader("Authorization", $"Bot {config.token}");
            request.SetMethod(Method.POST);
            request.SetContentType("application/json");
            request.SetContent(content);
            NetResponse response = request.Send();
            if (respone.Status != HttpStatusCode.OK)
            {
                core.WriteLine(Color.Lime, $"Successfully Created Channel: {cname}");
            }
            
            /*var response = request.Send();
            if (response.Status != HttpStatusCode.BadRequest)
            {
                core.WriteLine(Color.Lime, $"Successfully Created Channel: {cname}");
            }
            */
        }
    }
}
