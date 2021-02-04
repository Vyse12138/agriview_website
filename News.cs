using Nancy;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using Nancy.ModelBinding;
using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace nancyfx
{
    public class API : NancyModule
    {
        //routers
        public API() : base("api/news")
        {
            Get["/"] = GetNewsList;
            Get["/{id}"] = GetNews;
            Get["/image/{image}"] = GetImage;
            Post["/{id?}"] = PostNews;
            Post["/image/{image}"] = PostImage;
            Delete["/{id}"] = DeleteNews;
        }

        //template class of news
        public class News
        {
            public string id { get; set; }
            public string title { get; set; }
            public string date { get; set; }
            public string author { get; set; }
            public string img { get; set; }
            public string content { get; set; }
            public string contentDetail { get; set; }
        }

        //get method for news list
        private dynamic GetNewsList(dynamic parameters)
        {
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //sql the select all data
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM News", con);
            var data = cmd.ExecuteReader();

            //return query response
            List<News> newsList = new List<News>();
            while (data.Read())
            {
                News news = new News();
                news.id = data.GetString(0);
                news.title = data.GetString(1);
                news.date = data.GetString(2);
                news.author = data.GetString(3);
                news.img = data.GetString(4);
                news.content = data.GetString(5);
                news.contentDetail = data.GetString(6);
                newsList.Add(news);
            }

            con.Close();

            return newsList;
        }

        //get method for single news
        private dynamic GetNews(dynamic parameters)
        {
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //sql to select news based on id
            SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM News where id='{parameters.id}'", con);
            var data = cmd.ExecuteReader();

            //return query response
            News news = new News();
            while (data.Read())
            {
                news.id = data.GetString(0);
                news.title = data.GetString(1);
                news.date = data.GetString(2);
                news.author = data.GetString(3);
                news.img = data.GetString(4);
                news.content = data.GetString(5);
                news.contentDetail = data.GetString(6);
            }
            con.Close();
            return news;
        }

        //get method for images
        private dynamic GetImage(dynamic parameters)
        {
            string url = HttpContext.Current.Server.MapPath("~/App_Data/Image/" + parameters.image);
            return Response.AsImage(url);
        }

        //post method for news
        private dynamic PostNews(dynamic parameters)
        {
            //retrieve request data
            News news = this.Bind();

            //get current time to encode image name 
            String date = DateTime.Now.ToString("HHmm");

            //encode image name if it is not being encoded
            string[] imgNameArray = news.img.Split('.');
            if ((imgNameArray[0].Length < 4) || !(Regex.IsMatch(imgNameArray[0].Substring(imgNameArray[0].Length - 4, 4), @"^\d+$")))
            {
                imgNameArray[0] += date;
            }
            news.img = string.Join(".", imgNameArray);

            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //update exsiting news
            if (parameters.id)
            {
                //sql to update news based on id
                SQLiteCommand cmd1 = new SQLiteCommand($"UPDATE News SET title='{news.title}', date='{news.date}', author='{news.author}', img='{news.img}', content='{news.content}', contentDetail='{news.contentDetail}' WHERE id='{parameters.id}'", con);
                cmd1.ExecuteNonQuery();

                //get all image names store in database
                SQLiteCommand cmd2 = new SQLiteCommand($"SELECT img FROM News", con);
                var data = cmd2.ExecuteReader();
                List<string> imageNames = new List<string>();
                while (data.Read())
                {
                    imageNames.Add(data.GetString(0));
                }

                //get all image names in loal file
                DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/App_Data/Image/"));
                FileInfo[] images = d.GetFiles();
                foreach (FileInfo image in images)
                {
                    //delete the image that are not stored in database
                    if (!imageNames.Contains(image.Name))
                    {
                        File.Delete(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + image.Name));
                    }
                }
            }
            //upload non-exsiting news
            else
            {
                //sql to insert news 
                SQLiteCommand cmd3 = new SQLiteCommand($"INSERT INTO News VALUES ('{news.id}','{news.title}','{news.date}','{news.author}','{news.img}','{news.content}','{news.contentDetail}')", con);
                cmd3.ExecuteNonQuery();
            }

            con.Close();

            return System.Net.HttpStatusCode.OK;
        }

        //post method for images
        private dynamic PostImage(dynamic parameters)
        {
            //retrieve request data
            var img = Bitmap.FromStream(this.Request.Body);

            //get current time to encode image name 
            String date = DateTime.Now.ToString("HHmm");

            //encode image name if it is not being encoded
            string imageName = parameters.image;
            string[] imageNameArray = imageName.Split('.');
            if ((imageNameArray[0].Length < 4) || !(Regex.IsMatch(imageNameArray[0].Substring(imageNameArray[0].Length - 4, 4), @"^\d+$")))
            {
                imageNameArray[0] += date;
            }
            imageName = string.Join(".", imageNameArray);

            //save the image
            if (!File.Exists(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + imageName)))
            {
                img.Save(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + imageName));
            }
            return System.Net.HttpStatusCode.OK;
        }

        //delete method for news
        private dynamic DeleteNews(dynamic parameters)
        {
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //sql to retrieve image name based on id
            SQLiteCommand cmd1 = new SQLiteCommand($"SELECT img FROM News WHERE id='{parameters.id}'", con);
            var data = cmd1.ExecuteReader();
            string imageName = "";
            while (data.Read())
            {
                imageName = data.GetString(0);
            }

            //sql to delete news based on id
            SQLiteCommand cmd2 = new SQLiteCommand($"DELETE FROM News WHERE id='{parameters.id}'", con);
            cmd2.ExecuteNonQuery();

            //sql to count the number of news that still holds the image
            SQLiteCommand cmd3 = new SQLiteCommand($"SELECT COUNT(id) FROM News WHERE img='{imageName}'", con);
            var count = Convert.ToInt32(cmd3.ExecuteScalar());
            Trace.WriteLine(count);
            Trace.WriteLine(123);

            con.Close();

            //delete local image file based on id if no more news is hold that image
            if (count == 0)
            {
                File.Delete(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + imageName));
            }

            return System.Net.HttpStatusCode.OK;
        }
    }
}
