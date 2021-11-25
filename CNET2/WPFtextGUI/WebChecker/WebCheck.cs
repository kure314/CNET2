using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFtextGUI.WebChecker
{
    public class WebCheck
    {

        /// <summary>
        /// adresa webu kde hledat
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Výraz který vyhledávat
        /// </summary>
        public string Term { get; set; }

        /// <summary>
        /// nalezeno ,nebo nenalezeno, true = nalezeno, false, nenalezeno
        /// </summary>
        public bool Found { get; set; }
        
        public string LastState { get; set; }

        public string LastError { get; set; }


        private HttpClient httpClient = new HttpClient();

        public WebCheck(string url, string term)
        {
            Url = url;
            Term = term;

        }

        public void Start(IProgress<string> progress)
        {
            Task.Run(() =>
            {
                Checking(progress);
            });


        }
        private  void Checking(IProgress<string> progress)
        {
            while (true)
            {
                System.Diagnostics.Debug.WriteLine("jsem Tu");
                if (!(Webs.WebToCheck.ContainsKey(Url) && Webs.WebToCheck[Url] == true)) return;


                if (Webs.WebToCheck[Url]==false)
                {
                    return;
                }
                try
                {
                    string content = httpClient.GetStringAsync(Url).Result;
                    if (content.Contains(Term, StringComparison.OrdinalIgnoreCase))
                    {
                        Found = true;
                        
                    }
                    progress.Report($"{DateTime.Now.ToString("hh:mm")} Výsledek= { Found}{Environment.NewLine}");
                }
                catch(Exception e)
                {
                    LastError = LastState = $"{DateTime.Now.ToString()} - ERROR: {e.Message}";
                    progress.Report($"{DateTime.Now.ToString("hh:mm")} Výsledek skončil s chybou:{Environment.NewLine}{LastError}{Environment.NewLine}");
                }

                Task.Delay(1000).Wait();

            }
        }
    }
}
