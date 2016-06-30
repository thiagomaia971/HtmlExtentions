using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Mvc
{
    public class HtmlButtonTypes
    {

        public string Value { get; set; }

        private HtmlButtonTypes(string value)
        {
            this.Value = value;
        }

        public static HtmlButtonTypes Submit { get { return new HtmlButtonTypes("submit"); } private set { Submit = value; } }
        public static HtmlButtonTypes Button { get { return new HtmlButtonTypes("button"); } private set { Button = value; } }
        public static HtmlButtonTypes Reset { get { return new HtmlButtonTypes("reset"); } private set { Reset = value; } }


    }
}
