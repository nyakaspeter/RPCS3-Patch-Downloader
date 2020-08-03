using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace RPCS3_Patch_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Downloading patches...");

            using (WebClient client = new WebClient())
            {
                var htmlString = client.DownloadString("https://wiki.rpcs3.net/index.php?title=Help:Game_Patches");
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlString);

                var patches = htmlDocument.DocumentNode.Descendants("pre");

                var yml = "Version: 1.2\n";

                foreach (var patch in patches)
                {
                    yml += HttpUtility.HtmlDecode(patch.InnerText);
                }

                File.WriteAllText("patch.yml", yml);
            }
        }
    }
}
