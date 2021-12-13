using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWcfConsume.Models
{
    public class Fil
    {

        public IEnumerable<String> Cities { get; set; }

        public Fil()
        {
            List<String> list = new List<string>();
            list.Add("GINF");
            list.Add("GIL");
            list.Add("G3EI");
            list.Add("GSTR");
            list.Add("GSEA");
            Cities = list;
        }

       
    }
}