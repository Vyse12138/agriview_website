using Nancy;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Nancy.ModelBinding;
using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;

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

        //HTTP GET method for json file 
        private dynamic GetNewsList(dynamic parameters)
        {
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //sql query
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM News",con);
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

        private dynamic GetNews(dynamic parameters)
        {
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //sql query
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

        //HTTP GET method for images
        private dynamic GetImage(dynamic parameters)
        {
            string img = HttpContext.Current.Server.MapPath("~/App_Data/Image/" + parameters.image);
            return Response.AsImage(img);
        }

        //HTTP POST method for json objects
        private dynamic PostNews(dynamic parameters)
        {

            News news = this.Bind();

            //get current time
            DateTime date = DateTime.Now;
            string hour = date.Hour.ToString();
            string minute = date.Minute.ToString();
            //get post data

            //change cover image name
            string imgName = news.img;
            string[] imgNameArray = imgName.Split('.');
            if ((imgNameArray[0].Length < 4) || !(Regex.IsMatch(imgNameArray[0].Substring(imgNameArray[0].Length- 4,4), @"^\d+$")))
            {

                imgNameArray[0] += hour + minute;
            }
            imgName = string.Join(".", imgNameArray);
            news.img = imgName;
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();
            if (parameters.id)
            {
                SQLiteCommand cmd = new SQLiteCommand($"UPDATE News SET title='{news.title}', date='{news.date}', author='{news.author}', img='{news.img}', content='{news.content}', contentDetail='{news.contentDetail}' WHERE id='{parameters.id}'", con);
                cmd.ExecuteNonQuery();
            }
            else
            {






                SQLiteCommand cmd1 = new SQLiteCommand($"INSERT INTO News VALUES ('{news.id}','{news.title}','{news.date}','{news.author}','{news.img}','{news.content}','{news.contentDetail}')", con);
                cmd1.ExecuteNonQuery();
                

            }
            con.Close();
            return System.Net.HttpStatusCode.OK;
        }

        //HTTP POST method for images
        private dynamic PostImage(dynamic parameters)
        {
            //get current time
            DateTime date = DateTime.Now;
            string hour = date.Hour.ToString();
            string minute = date.Minute.ToString();
            //rename imgage based on current time
            string imageName = parameters.image;
            string[] imageNameArray = imageName.Split('.');
            if ((imageNameArray[0].Length < 4) || !(Regex.IsMatch(imageNameArray[0].Substring(imageNameArray[0].Length - 4, 4), @"^\d+$")))
            {

                imageNameArray[0] += hour + minute;
            }
            imageName = string.Join(".", imageNameArray);
            //get post data
            var img = Bitmap.FromStream(this.Request.Body);
            //save the image
            if (!File.Exists(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + imageName)))
            {
                img.Save(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + imageName));
            }
            return System.Net.HttpStatusCode.OK;
        }

        private dynamic DeleteNews(dynamic parameters)
        {
            //connect to sqlite database
            string url = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {url}");
            con.Open();

            //sql query
            SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM News WHERE img='{parameters.id}'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            File.Delete(HttpContext.Current.Server.MapPath("~/App_Data/Image/" + parameters.id));
            return System.Net.HttpStatusCode.OK;
        }
    }
}
