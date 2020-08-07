using HtmlAgilityPack;
using System;
using System.IO;
using System.Web;

namespace RPCS3_Patch_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Downloading patches...");

            var patches = new HtmlWeb()
                .Load("https://wiki.rpcs3.net/index.php?title=Help:Game_Patches")
                .DocumentNode.Descendants("pre");

            var yml = "Version: 1.2\n";

            foreach (var patch in patches)
            {
                yml += HttpUtility.HtmlDecode(patch.InnerText);
            }

            File.WriteAllText("patch.yml", yml);
        }
    }
}
