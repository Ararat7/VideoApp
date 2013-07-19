using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoApp
{
    class Video
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Details { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string AppStore { get; set; }
        public string GooglePlay { get; set; }
        public string Maps { get; set; }

        public Video()
        {
            Text1 = string.Empty;
            Text2 = string.Empty;
            Details = string.Empty;
            Link1 = string.Empty;
            Link2 = string.Empty;
            Facebook = string.Empty;
            Twitter = string.Empty;
            AppStore = string.Empty;
            GooglePlay = string.Empty;
            Maps = string.Empty;
        }
    }
}