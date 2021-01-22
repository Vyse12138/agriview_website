using Nancy;

namespace nancyfx
{
    public class HomeModule : NancyModule
    {
        //routers
        public HomeModule()
        {
            Get["/"] = _ => View["index"];
        }

    }
}
