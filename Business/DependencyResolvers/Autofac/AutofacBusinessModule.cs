using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Entities.Concrete;
using Core.Utulities.Interceptors;
using Core.Utulities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<İçerikManager>().As<IİçerikService>().SingleInstance();
            builder.RegisterType<EfİçerikDal>().As<IİçerikDal>().SingleInstance();

            //builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            //builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();


            //builder.RegisterType<KonuManager>().As<IKonuService>().SingleInstance();
            //builder.RegisterType<EfKonuDal>().As<IKonuDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly=System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableClassInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector=new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
