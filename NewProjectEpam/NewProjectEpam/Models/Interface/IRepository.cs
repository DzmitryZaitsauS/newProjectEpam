using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewProjectEpam.Models.myTable;

namespace NewProjectEpam.Models.Interface
{
    interface IRepository
    {
        #region Categories
       List<TableCategories> SelectCategories();
       bool GreateCategories(string typess);
     
       bool DeleteCategories(string typess);
        #endregion


        #region News
       List<MyTableNews> SelectNews();
       bool GreateNews(string name_news, string content, string image, string typess);
       List<MyTableNews> UpdateNews(int id_news);
       bool DeleteNews(int id_news);

       bool SaveNews(int id_news, string name_news, string typess, string content, string img);

       bool PolOcNews(int id_news);
       bool OtrOcNews(int id_news);

        #endregion

        #region ZakazNews
       List<TableZakazNews> SelectZakazNews();
       bool GreateZakazNews(string name_news);
     
       bool DeleteZakazNews(int id_zakaz);

       bool PolOcZakaz(int id_zakaz);
       bool OtrOcenZakaz(int id_zakaz);

        #endregion

        #region Comment
       List<MyTableNews> SelectComments();
       bool AddComments(string comment, int id_news);
       bool DeleteComments(int id_comments);

       bool PolOcComment(int id_comment);
       bool OtrOcComment(int id_comment);

        #endregion
    }
}
