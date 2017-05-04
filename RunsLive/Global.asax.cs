using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using RunsLive.Models.BindingModels;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;

namespace RunsLive
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
           Mapper.Initialize(expression =>
           {
               expression.CreateMap<Game, GamesViewModel>();
               expression.CreateMap<Vod, VodViewModel>();
               expression.CreateMap<RequestVodBindingModel, VodRequest>().ForMember(vm => vm.Status, m => m.UseValue("Pending"));
               expression.CreateMap<RequestStreamBindingModel, StreamRequest>().ForMember(vm => vm.Status, m => m.UseValue("Pending"));
               expression.CreateMap<Genre, GenresViewModel>();
               expression.CreateMap<RequestGameBindingModel, GameRequest>().ForMember(vm => vm.Status, m => m.UseValue("Pending"));
               expression.CreateMap<VodRequest, VodRequestViewModel>();
               expression.CreateMap<GameRequest, GameRequestViewModel>();
               expression.CreateMap<StreamRequest, StreamRequestViewModel>();
               expression.CreateMap<VodRequest, Vod>();
               expression.CreateMap<GameRequest, Game>();
               expression.CreateMap<Game, VodRequestViewModel>()
                   .ForMember(vm => vm.GameName, m => m.MapFrom(g => g.Name));
               expression.CreateMap<Genre, GameRequestViewModel>()
                  .ForMember(vm => vm.GenreName, m => m.MapFrom(g => g.Name));
               expression.CreateMap<Stream, StreamsViewModel>();
               expression.CreateMap<StreamRequest, Stream>().ForMember(vm=>vm.StreamerName,m=>m.MapFrom(s=>s.StreamName));
           });
        }
    }
}

