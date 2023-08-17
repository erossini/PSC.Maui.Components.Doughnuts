using SkiaSharp.Views.Maui.Handlers;

namespace PSC.Maui.Components.Doughnuts
{
    public static class Registration
    {
        public static MauiAppBuilder UseDoughnut(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(h =>
            {
                h.AddHandler<Doughnut, SKCanvasViewHandler>();
            });

            return builder;
        }
    }
}