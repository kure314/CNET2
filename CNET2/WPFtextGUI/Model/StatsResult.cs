using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtextGUI.Model
{
    /// <summary>
    /// Result of frequential analysis from given source 
    /// </summary>
    public class StatsResult
    {
        public int Id { get; set; }
        /// <summary>
        /// source of text for analysis
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        ///10 most common words in source
        /// </summary>
        public Dictionary<string, int> Top10Words { get; set; }

        /// <summary>
        /// Jak dlouho trvalo vytvořit analýzu
        /// </summary>
        public int ElapsedMilliseconds { get; set; }
        public string SubmitedBy { get; set; }
        public string Name { get; set; }

    }
}
