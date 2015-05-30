using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProjectEpam.Models.myTable
{
    public class MyTableComments
    {
        public int Id_comments { get; set; }
        public string users_comment { get; set; }
        public int  id_news { get; set; }
        public DateTime date_coments { get; set; }

        public string comments { get; set; }

        public int pol_oc { get; set; }
        public int otr_oc { get; set; }
    }
}