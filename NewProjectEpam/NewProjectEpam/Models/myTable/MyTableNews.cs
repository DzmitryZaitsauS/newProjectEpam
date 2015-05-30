using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProjectEpam.Models.myTable
{
    public class MyTableNews
    {
        public int Id_news { get; set; }
        public string user_nam { get; set; }
        public string name_news { get; set; }
        public DateTime date_publich { get; set; }

        public string content { get; set; }
        public string image { get; set; }

        public string typess { get; set; }

        public int pol_ozenk { get; set; }
        public int otr_ozaenk { get; set; }

        public int id_comments { get; set; }
        public string users_comment { get; set; }

        public string comment { get; set; }
        public DateTime date_comment { get; set; }

        public int pol_oc { get; set; }
        public int otr_oc { get; set; }
    }
}