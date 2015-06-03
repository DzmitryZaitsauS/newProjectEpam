using NewProjectEpam.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NewProjectEpam.Models.myTable;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace NewProjectEpam.Models
{
    public class Repository: IRepository
    {
    
   
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MyDb.mdf;Integrated Security=True;Connect Timeout=30");
       
        public List<myTable.TableCategories> SelectCategories()
        {
            
                connection.Open();
                string query = "SELECT * FROM MyTableCategories ";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@id", ID);
                SqlDataReader reader = command.ExecuteReader();
                List<TableCategories> list = new List<TableCategories>();
                while (reader.Read())
                {
                    TableCategories typess = new TableCategories();
                    typess.Typess = reader["TYPESS"].ToString();
                    list.Add(typess);
                }
          
           return list;
        }

        public bool GreateCategories(string typess)
        {
            connection.Open();
            string query = "INSERT INTO [MyTableCategories]([TYPESS]) VALUES(@Name)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = typess;
            command.ExecuteNonQuery();
            
            return true;
        }

   

        public bool DeleteCategories(string typess)
        {
            connection.Open();
            string query = "Delete from MyTableCategories where TYPESS = @TYPESS";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@TYPESS", SqlDbType.VarChar, 50).Value = typess;
            command.ExecuteNonQuery();
            return true;
        }


        public List<TableZakazNews> SelectZakazNews()
        {
            connection.Open();
            string query = "SELECT * FROM MyTableZakazNews ";
            SqlCommand command = new SqlCommand(query, connection);
          
            SqlDataReader reader = command.ExecuteReader();
            List<TableZakazNews> list = new List<TableZakazNews>();
            while (reader.Read())
            {
                TableZakazNews zakaz = new TableZakazNews();
                zakaz.Id_zakaz = (int)reader["ID_zakaz"];
                zakaz.user_name = reader["user_nam"].ToString();
                zakaz.email = reader["email"].ToString();
                zakaz.name_news = reader["name_news"].ToString();
                zakaz.date_zakaz= (DateTime)reader["date_zakaz"];
                zakaz.pol_ozenk = (int)reader["pol_ozenk"];
                zakaz.otr_ozaenk = (int)reader["otr_ozaenk"];
                
                
                list.Add(zakaz);
            }

            return list;
        }

        public bool GreateZakazNews(string name_news)
        {
                              
         
           string user_nam= HttpContext.Current.User.Identity.Name.ToString();
           string email = HttpContext.Current.User.Identity.Name.ToString();
            DateTime date= DateTime.Today;
            int pol_ozenk=0;
            int otr_ocenk=0;

            connection.Open();
            string query = "INSERT INTO [MyTableZakazNews]([user_nam],[email],[name_news],[date_zakaz],[pol_ozenk],[otr_ozaenk]) VALUES(@user_nam, @email, @name, @date, @pol_ozenk, @otr_ocenk)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@user_nam", SqlDbType.VarChar, 50).Value = user_nam;
            command.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
            command.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = name_news;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            command.Parameters.Add("@pol_ozenk", SqlDbType.Int).Value = pol_ozenk;
            command.Parameters.Add("@otr_ocenk", SqlDbType.Int).Value = otr_ocenk;
            command.ExecuteNonQuery();

            return true;
        }

    

        public bool DeleteZakazNews(int id_zakaz)
        {
            connection.Open();
            string query = "Delete from MyTableZakazNews where ID_zakaz = @ID_zakaz";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ID_zakaz", SqlDbType.VarChar, 50).Value = id_zakaz;
            command.ExecuteNonQuery();
            return true;
        }





        public List<MyTableNews> SelectNews()
        {
            
            connection.Open();
            string query = "Select * From  MyTableAddNews , MyTableComment where dbo.MyTableAddNews.ID_news = dbo.MyTableComment.id_news   ";
            SqlCommand command = new SqlCommand(query, connection);
            

            SqlDataReader reader = command.ExecuteReader();
            List<MyTableNews> list = new List<MyTableNews>();
            while (reader.Read())
            {
                MyTableNews News = new MyTableNews();
                News.Id_news = (int)reader["ID_news"];
                News.user_nam = reader["user_nam"].ToString();
                News.name_news = reader["name_news"].ToString();
                News.date_publich = (DateTime)reader["date_publich"];
                News.content = reader["Content"].ToString();
                News.image = reader["img"].ToString();
                News.typess = reader["typess"].ToString();
                News.pol_ozenk = (int)reader["pol_ozenk"];
                News.otr_ozaenk = (int)reader["otr_ozaenk"];

                News.id_comments = (int)reader["ID_comment"];
                News.comment = reader["comments"].ToString(); ;
                News.users_comment = reader["users_comment"].ToString();

                News.date_comment = (DateTime)reader["date_coments"];
                News.pol_oc = (int)reader["pol_oc"];
                News.otr_oc = (int)reader["otr_oc"];

            
                list.Add(News);
              

            }

                return list;
               
        }

        public bool GreateNews(string name_news, string content, string image, string typess)
        {
            string user_nam = HttpContext.Current.User.Identity.Name.ToString();
          
            DateTime date = DateTime.Today;
            int pol_ozenk = 0;
            int otr_ocenk = 0;

            connection.Open();
            string query = "INSERT INTO [MyTableAddNews]([user_nam],[name_news],[date_publich],[content],[img],[typess],[pol_ozenk],[otr_ozaenk]) VALUES(@user_nam , @name, @date,@content,@img,@typess, @pol_ozenk, @otr_ocenk)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@user_nam", SqlDbType.VarChar, 50).Value = user_nam;
           
            command.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = name_news;
            command.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            command.Parameters.Add("@content", SqlDbType.VarChar).Value = content;
            command.Parameters.Add("@img", SqlDbType.VarChar).Value = image;
            command.Parameters.Add("@typess", SqlDbType.VarChar, 100).Value = typess;
            command.Parameters.Add("@pol_ozenk", SqlDbType.Int).Value = pol_ozenk;
            command.Parameters.Add("@otr_ocenk", SqlDbType.Int).Value = otr_ocenk;
            command.ExecuteNonQuery();


             string con = "Select * From  MyTableZakazNews ";
            SqlCommand com = new SqlCommand(con, connection);
            

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                TableZakazNews News = new TableZakazNews();
                string news =News.name_news = (string)reader["name_news"];
                if(news.Equals(name_news))
                {
                    SendMailMessage(name_news, user_nam);
                }
            }
            return true;
        }

        public List<MyTableNews> UpdateNews(int id_news)
        {
             connection.Open();
             string query = "SELECT * FROM MyTableAddNews Where ID_news=@id_news";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@id_news", SqlDbType.Int).Value = id_news;

            SqlDataReader reader = command.ExecuteReader();
            List<MyTableNews> list = new List<MyTableNews>();
            while (reader.Read())
            {
                MyTableNews News = new MyTableNews();
                News.Id_news = (int)reader["ID_news"];
                News.user_nam = reader["user_nam"].ToString();
                News.name_news = reader["name_news"].ToString();
                News.date_publich = (DateTime)reader["date_publich"];
                News.content = reader["Content"].ToString();
                News.image = reader["img"].ToString();
                News.typess = reader["typess"].ToString();
                News.pol_ozenk = (int)reader["pol_ozenk"];
                News.otr_ozaenk = (int)reader["otr_ozaenk"];


                list.Add(News);
            }
            return list;
            
        }

        public bool DeleteNews(int id_news)
        {
            connection.Open();
            string query = "Delete from MyTableAddNews where ID_news = @ID_news";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@ID_news", SqlDbType.Int).Value = id_news;
            command.ExecuteNonQuery();
            return true;
        }


        public List<MyTableNews> SelectComments()
        {
                       
                       string query = "Select * From  dbo.MyTableAddNews INNER JOIN dbo.MyTableComment ON dbo.MyTableAddNews.ID_news = dbo.MyTableComment.id_news ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Close();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<MyTableNews> list = new List<MyTableNews>();
            while (reader.Read())
            {
                MyTableNews News = new MyTableNews();
                News.comment = reader["comments"].ToString(); ;
                News.users_comment = reader["users_comment"].ToString();

                News.date_comment = (DateTime)reader["date_coments"];
                News.pol_oc = (int)reader["pol_oc"];
                News.otr_oc = (int)reader["otr_oc"];

                list.Add(News);

            }



            return list;
        }

        public bool AddComments(string comment, int id_news)
        {
            string users_comment = HttpContext.Current.User.Identity.Name.ToString();

            DateTime date = DateTime.Today;
            int pol_ozenk = 0;
            int otr_ocenk = 0;

            connection.Open();
            string query = "INSERT INTO [MyTableComment]([users_comment],[id_news],[date_coments],[comments],[pol_oc],[otr_oc]) VALUES(@users_comment , @id_news, @date_coments,@comments, @pol_ozenk, @otr_ocenk)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@users_comment", SqlDbType.VarChar, 50).Value = users_comment;
            command.Parameters.Add("@id_news", SqlDbType.Int).Value = id_news;
            command.Parameters.Add("@date_coments", SqlDbType.DateTime).Value = date;
            command.Parameters.Add("@comments", SqlDbType.VarChar).Value = comment;
            command.Parameters.Add("@pol_ozenk", SqlDbType.Int).Value = pol_ozenk;

            command.Parameters.Add("@otr_ocenk", SqlDbType.Int).Value = otr_ocenk;
            command.ExecuteNonQuery();

            return true;
        }

        public bool DeleteComments(int id_comments)
        {
            connection.Open();
            string query = "Delete from MyTableComment where ID_comment = @id_comments";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@id_comments", SqlDbType.Int).Value = id_comments;
            command.ExecuteNonQuery();
            return true;
        }


        public bool SaveNews(int id_news, string name_news, string typess, string content, string img)
        {
            DateTime date_publich = DateTime.Today;
            connection.Open();
          

            string query = @"UPDATE MyTableAddNews
                             SET [name_news] = @name             
                             WHERE [ID_news] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_news);
            command.Parameters.AddWithValue("@name", name_news);
            command.ExecuteNonQuery();

            string s1 = @"UPDATE MyTableAddNews
                             SET [date_publich] = @date_publich              
                             WHERE [ID_news] = @id";
            SqlCommand com1 = new SqlCommand(s1, connection);
            com1.Parameters.AddWithValue("@id", id_news);
            com1.Parameters.AddWithValue("@date_publich", DateTime.Today);
            com1.ExecuteNonQuery();

            string s2 = @"UPDATE MyTableAddNews
                             SET [Content] = @Content              
                             WHERE [ID_news] = @id";
            SqlCommand com2 = new SqlCommand(s2, connection);
            com2.Parameters.AddWithValue("@id", id_news);
            com2.Parameters.AddWithValue("@Content", content);
            com2.ExecuteNonQuery();

            string s3 = @"UPDATE MyTableAddNews
                             SET [img] = @img             
                             WHERE [ID_news] = @id";
            SqlCommand com3 = new SqlCommand(s3, connection);
            com3.Parameters.AddWithValue("@id", id_news);
            com3.Parameters.AddWithValue("@img", img);
            com3.ExecuteNonQuery();

            string s4 = @"UPDATE MyTableAddNews
                             SET [typess] = @typess              
                             WHERE [ID_news] = @id";
            SqlCommand com4 = new SqlCommand(s4, connection);
            com4.Parameters.AddWithValue("@id", id_news);
            com4.Parameters.AddWithValue("@typess", typess);
            com4.ExecuteNonQuery();

            return true;
        }


        public bool PolOcZakaz(int id_zakaz)
        {

            connection.Open();

            string con = "Select * From  MyTableZakazNews Where ID_zakaz=@id_zakaz ";
            SqlCommand com = new SqlCommand(con, connection);
            com.Parameters.Add("@id_zakaz", SqlDbType.Int).Value=id_zakaz;
           
            SqlDataReader reader = com.ExecuteReader();
           
                TableZakazNews News = new TableZakazNews();
                while (reader.Read())
                {
                    News.pol_ozenk = (int)reader["pol_ozenk"];


                }
                reader.Close();
                int polOc = News.pol_ozenk; 
            polOc++;
                

               string query = @"UPDATE MyTableZakazNews
                             SET [pol_ozenk] = @pol_ozenk             
                             WHERE [ID_zakaz] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_zakaz);
            command.Parameters.AddWithValue("@pol_ozenk", polOc);
            command.ExecuteNonQuery();

            return true;

        }

        public bool OtrOcenZakaz(int id_zakaz)
        {
            connection.Open();

            string con = "Select * From  MyTableZakazNews Where ID_zakaz=@id_zakaz ";
            SqlCommand com = new SqlCommand(con, connection);
            com.Parameters.Add("@id_zakaz", SqlDbType.Int).Value = id_zakaz;

            SqlDataReader reader = com.ExecuteReader();

            TableZakazNews News = new TableZakazNews();
            while (reader.Read())
            {
                News.otr_ozaenk = (int)reader["otr_ozaenk"];


            }
            reader.Close();
            int otrOc = News.otr_ozaenk;
            otrOc--;


            string query = @"UPDATE MyTableZakazNews
                             SET [otr_ozaenk] = @otr_ozaenk             
                             WHERE [ID_zakaz] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_zakaz);
            command.Parameters.AddWithValue("@otr_ozaenk", otrOc);
            command.ExecuteNonQuery();

            return true;
        }


        public bool PolOcNews(int id_news)
        {
            connection.Open();

            string con = "Select * From  MyTableAddNews Where ID_news=@ID_news ";
            SqlCommand com = new SqlCommand(con, connection);
            com.Parameters.Add("@ID_news", SqlDbType.Int).Value = id_news;

            SqlDataReader reader = com.ExecuteReader();

            MyTableNews News = new MyTableNews();
            while (reader.Read())
            {
                News.pol_ozenk = (int)reader["pol_ozenk"];


            }
            reader.Close();
            int polOc = News.pol_ozenk;
            polOc++;


            string query = @"UPDATE MyTableAddNews
                             SET [pol_ozenk] = @pol_ozenk             
                             WHERE [ID_news] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_news);
            command.Parameters.AddWithValue("@pol_ozenk", polOc);
            command.ExecuteNonQuery();

            return true;
        }

        public bool OtrOcNews(int id_news)
        {
            connection.Open();

            string con = "Select * From  MyTableAddNews Where ID_news=@ID_news ";
            SqlCommand com = new SqlCommand(con, connection);
            com.Parameters.Add("@ID_news", SqlDbType.Int).Value = id_news;

            SqlDataReader reader = com.ExecuteReader();

            MyTableNews News = new MyTableNews();
            while (reader.Read())
            {
                News.otr_ozaenk = (int)reader["otr_ozaenk"];


            }
            reader.Close();
            int otrOc = News.otr_ozaenk;
            otrOc--;


            string query = @"UPDATE MyTableAddNews
                             SET [otr_ozaenk] = @otr_ozaenk             
                             WHERE [ID_news] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_news);
            command.Parameters.AddWithValue("@otr_ozaenk", otrOc);
            command.ExecuteNonQuery();

            return true;
        }

        public bool PolOcComment(int id_comment)
        {
            connection.Open();

            string con = "Select * From  MyTableComment Where ID_comment=@ID_comment ";
            SqlCommand com = new SqlCommand(con, connection);
            com.Parameters.Add("@ID_comment", SqlDbType.Int).Value = id_comment;

            SqlDataReader reader = com.ExecuteReader();

            MyTableComments News = new MyTableComments();
            while (reader.Read())
            {
                News.pol_oc = (int)reader["pol_oc"];


            }
            reader.Close();
            int polOc = News.pol_oc;
            polOc++;


            string query = @"UPDATE MyTableComment
                             SET [pol_oc] = @pol_ozenk             
                             WHERE [ID_comment] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_comment);
            command.Parameters.AddWithValue("@pol_ozenk", polOc);
            command.ExecuteNonQuery();

            return true;
        }

        public bool OtrOcComment(int id_comment)
        {
            connection.Open();

            string con = "Select * From  MyTableComment Where ID_comment=@ID_comment ";
            SqlCommand com = new SqlCommand(con, connection);
            com.Parameters.Add("@ID_comment", SqlDbType.Int).Value = id_comment;

            SqlDataReader reader = com.ExecuteReader();

            MyTableComments News = new MyTableComments();
            while (reader.Read())
            {
                News.otr_oc = (int)reader["otr_oc"];


            }
            reader.Close();
            int otrOc = News.otr_oc;
            otrOc--;


            string query = @"UPDATE MyTableComment
                             SET [otr_oc] = @otr_ozaenk             
                             WHERE [ID_comment] = @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id_comment);
            command.Parameters.AddWithValue("@otr_ozaenk", otrOc);
            command.ExecuteNonQuery();

            return true;
        }


        public bool SendMailMessage(string name_mews, string email)
        {
            MailMessage Message = new MailMessage();

Message.Subject = "Запрошенная вами новость добавлена на сайт!";

Message.Body = "Здравствуйте!Хотим сказать что новость"+name_mews+"апрошеная вами  на сайте www.tut.tut.by, успешено добавлена!!! С ув. администрация сайта!";

Message.BodyEncoding = Encoding.GetEncoding("Windows-1254"); // Turkish Character Encoding// кодировка эсли нужно!

Message.From = new System.Net.Mail.MailAddress("dmitry_zajcew@mail.ru");

Message.To.Add(new MailAddress(email));

System.Net.Mail.SmtpClient Smtp = new SmtpClient("127.0.0.1");

Smtp.Host = "smtp.mail.ru"; //например для gmail (smtp.gmail.com), mail.ru(smtp.mail.ru)

Smtp.EnableSsl = true; // включение SSL для gmail нужно!!! для mail.ru не нада!!!

Smtp.Credentials = new System.Net.NetworkCredential("логин", "пароль");


Smtp.Send(Message);//отправка

            return true;

        }
    }
}