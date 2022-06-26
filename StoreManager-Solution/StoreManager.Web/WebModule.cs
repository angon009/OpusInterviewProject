using Autofac;
using StoreManager.Web.Areas.Manager.Models;

namespace StoreManager.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemCRUDModel>().AsSelf();
            base.Load(builder);
        }
    }
}
