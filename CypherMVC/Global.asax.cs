using AutoMapper;
using CypherMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CypherMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.CreateMap<TaskVM, Task>()
                            .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                            .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId))
                            .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                            .ForMember(d => d.DueDate, o => o.MapFrom(s => s.DueDate))
                            .ForMember(d => d.Completed, o => o.MapFrom(s => s.Completed))
                            .ForMember(d => d.AssociatedMessageId, o => o.MapFrom(s => s.AssociatedMessageId))
                            .ForMember(d => d.AssignedToId, o => o.MapFrom(s => s.AssignedToId))
                            .ForMember(d => d.Notes, o => o.MapFrom(s => s.Notes));
            Mapper.CreateMap<Task,TaskVM>()
                            .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                            .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId))
                            .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                            .ForMember(d => d.DueDate, o => o.MapFrom(s => s.DueDate))
                            .ForMember(d => d.Completed, o => o.MapFrom(s => s.Completed))
                            .ForMember(d => d.AssociatedMessageId, o => o.MapFrom(s => s.AssociatedMessageId))
                            .ForMember(d => d.AssignedToId, o => o.MapFrom(s => s.AssignedToId))
                            .ForMember(d => d.Notes, o => o.MapFrom(s => s.Notes));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
