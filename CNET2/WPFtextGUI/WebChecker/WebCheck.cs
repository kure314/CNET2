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

        public void Start()
        {
            Task.Run(() =>
            {
                Checking();
            });


        }
        private  void Checking()
        {
            while (true)
            {
                if (!(Webs.WebToCheck.ContainsKey(Url) && Webs.WebToCheck[Url] == true)) return;


                if (Webs.WebToCheck[Url]==true)
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
                }
                catch(Exception e)
                {
                    LastError = LastState = $"{DateTime.Now.ToString()} - ERROR: {e.Message}";
                }

                Task.Delay(5000).Wait();

            }
        }
    }
}
