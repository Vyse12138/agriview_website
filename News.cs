using Nancy;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Nancy.ModelBinding;
using System;
using System.Data.SQLite;

namespace nancyfx
{
    public class API : NancyModule
    {
        //routers
        public API() : base("api/news")
        {
            Get["/"] = GetJson;
            Get["/image/{image}"] = GetImage;
            Post["/"] = PostNews;
            Post["/image/{image}"] = PostImage;
        }

        //template class of news
        public class News
        {
            public string id { get; set; }
            public string title { get; set; }
            public string date { get; set; }
            public string author { get; set; }
            public string img { get; set; }
            public string imgDetail { get; set; }
            public string content { get; set; }
            public string contentDetail { get; set; }
        }

        //HTTP GET method for json file 
        private dynamic GetJson(dynamic parameters)
        {


            return File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/News.json"));
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

            string a = HttpContext.Current.Server.MapPath("~/App_Data/News.db");
            SQLiteConnection con = new SQLiteConnection($"Data Source = {a}");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO News VALUES ('a1','a2','a3','a4','a5','a6','a7')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            //get current time
            DateTime date = DateTime.Now;
            string hour = date.Hour.ToString();
            string minute = date.Minute.ToString();
            //get post data
            News newsItem = this.Bind();
            //change cover image name
            string imgName = newsItem.img;
            string[] imgNameArray = imgName.Split('.');
            imgNameArray[0] += hour + minute;
            imgName = string.Join(".", imgNameArray);
            newsItem.img = imgName;
            //change detail image name
            string imgDetailName = newsItem.imgDetail;
            string[] imgDetailNameArray = imgDetailName.Split('.');
            imgDetailNameArray[0] += hour + minute;
            imgDetailName = string.Join(".", imgDetailNameArray);
            newsItem.imgDetail = imgDetailName;
            //append post data to News.json file
            var newsListJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/News.json"));
            var newsList = JsonConvert.DeserializeObject<List<News>>(newsListJson);
            newsList.Add(newsItem);
            newsListJson = JsonConvert.SerializeObject(newsList, Formatting.Indented);
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/App_Data/News.json"), newsListJson);
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
            imageNameArray[0] += hour + minute;
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
    }
}
