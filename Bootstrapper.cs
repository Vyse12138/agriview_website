using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
using System.Threading;

namespace nancyfx
{

    /// <summary>
    /// 因为vueClient工具只能生成到指定目录，比如wwwroot, 无法设置到根目录，因为vue需要删除指定目录下的所有文件和子目录。
    /// </summary>

    public class Bootstrapper : DefaultNancyBootstrapper
    {

        protected override void ApplicationStartup(TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            StaticConfiguration.Caching.EnableRuntimeViewUpdates = true;
            StaticConfiguration.DisableErrorTraces = false;
        }
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/img", "wwwroot/img"));//第一个参数为请求路径，第二个为实际文件路径
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/css", "wwwroot/css"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/js", "wwwroot/js"));
            //nancyConventions.ViewLocationConventions.Add((viewName, model, context) => "wwwroot/" + viewName); 
        }
    }
}