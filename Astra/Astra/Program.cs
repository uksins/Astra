using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veylib.ICLI;
using Veylib.VeyAPI.VeyAuth;

namespace Astra
{
    internal class Program
    {
        static Core core = new Core();
        static string logo = config.Logo;

        static void SetWidth(int width)
        {
            Console.WindowWidth = width;
        }

        static void Main(string[] args)
        {
            var props = new Core.StartupProperties
            {
                Title = new Core.StartupConsoleTitleProperties
                {
                    Text = "Astra – Discord Server Manager"
                },

                Author = new Core.StartupAuthorProperties
                {
                    Name = "sins",
                    Url = "https://wwwsins.uk/",
                },

                Logo = new Core.StartupLogoProperties
                {
                    Text = logo,
                }
            };

            core.Start(props);
            top:
            var token = core.ReadLine("@Bot token $ ");
            var guild = core.ReadLine("@Server ID $ ");
            core.WriteLine("Storing Details, And Starting Session");
            config.token = token; 
            config.guild = guild;
            core.Clear();
            core.WriteLine("Continue?");
            var resp = new SelectionMenu("Yes", "No").Activate();

            // Incorrect. Exit.
            if (resp != "Yes")
                Environment.Exit(0);
            core.Clear();
            // Next Part: Request /api/v10/users/@me : To Get Username, Bot ID

            BotChecks.Authorization();
            core.WriteLine(Color.Lime, "Completely Authorized Your Bot");
            core.Delay(2500);
            core.Clear();

            BotChecks.Information();

        }
    }
}
