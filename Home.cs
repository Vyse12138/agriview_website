using Nancy;

namespace nancyfx
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["wwwroot/index"];
        }

    }
}
