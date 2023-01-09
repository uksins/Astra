using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Veylib.ICLI;
using Veylib.Utilities.Net;

namespace Astra
{
    internal class Channels
    {
        static Core core = new Core();

        public static void Create()
        {
        restart:
            var cname = core.ReadLine("@Channel-Name $ ");
            int type = 0;

            byte[] data = Encoding.UTF8.GetBytes("{ \"topic\": \"Astra Discord Tool\", \"name\": \"" + cname + "\", \"type\": " + type + " }");
            var request = WebRequest.Create($"https://discord.com/api/v10/guilds/{config.guild}/channels");
            request.Headers.Add("Authorization", $"Bot {config.token}");
            request.Method = "POST";
            var stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            try
            {
                request.GetResponse();
                core.WriteLine(Color.Lime, $"Successfully Created Channel: {cname}");
            }
            catch(Exception ex)
            {
                core.WriteLine(Color.Red, $"An Error Occured While Creating: {cname}: {ex}");
            }
        }
    }
}
