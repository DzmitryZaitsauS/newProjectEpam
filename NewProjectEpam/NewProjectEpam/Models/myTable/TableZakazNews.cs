using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProjectEpam.Models.myTable
{
    public class TableZakazNews
    {
        public int Id_zakaz { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string name_news { get; set; }
        public DateTime date_zakaz { get; set; }
        public int pol_ozenk { get; set; }
        public int otr_ozaenk { get; set; }


    }
}