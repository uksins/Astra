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
        // Defining Core For Veylib
        static Core core = new Core();

        static void SetWidth(int width)
        {
            Console.WindowWidth = width;
        }

        static void SetHeight(int height)
        {
            Console.WindowHeight = height;
        }



        static void Main(string[] args)
        {
            SetWidth(175);
            SetHeight(25);

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
                    Text = config.Logo,
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
            var optable = new AsciiTable();
            optable.AddColumn("1 - Server Management");
            optable.AddColumn("2 - Channel Management");
            optable.AddColumn("3 - Role Management");
            optable.AddRow("4 - User Management", "5 - Webhook Management", "6 - Exit");
            optable.WriteTable();
            Channels.Create();
        }
    }
}
