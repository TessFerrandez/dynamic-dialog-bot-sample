using Autofac;
using DynamicDialogBot.Dialogs;
using DynamicDialogBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace DynamicDialogBot.Modules
{
    public sealed class DynamicDialogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Register top level dialog.
            builder.RegisterType<DynamicDialogDialog>()
             .As<IDialog<object>>()
             .InstancePerDependency();

            // Register services.
            builder.RegisterType<ResponseService>()
                .Keyed<IResponseService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}