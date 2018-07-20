using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebParser
{
    class Program
    {
        static void Main(string[] args)
        {
            WebParser parser = new WebParser("google.com");
            Console.WriteLine(parser.FindContentInTag("h1"));
        }
    }

    class WebParser : WebClient
    {
        private string _url;

        public WebParser(string url)
        {
            _url = url;
        }

        public string FindContentInTag(string tag)
        {
            string page = DownloadString(_url);
            Regex exp = new Regex($@"^<{tag}>[\D]$</{tag}>");
            return exp.Match(page).Value;
        }
    }
}
