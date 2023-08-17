using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace PSC.Maui.Components.Doughnuts
{
    public class Doughnut : SKCanvasView
    {
        #region BindableProperty

        public static readonly BindableProperty InnerColorProperty = BindableProperty.Create(nameof(InnerColor), typeof(Color),
                                                                typeof(Doughnut), Color.FromArgb("#ffffffff"), propertyChanged: OnAnyPropertyChanged);

        public static readonly BindableProperty ShowNoDataProperty = BindableProperty.Create(nameof(ShowNoData), typeof(bool),
                                                                        typeof(Doughnut), false, propertyChanged: OnAnyPropertyChanged);

        public static readonly BindableProperty SweepAngleProperty = BindableProperty.Create(nameof(SweepAngle), typeof(float),
                                                                        typeof(Doughnut), 0F, propertyChanged: OnAnyPropertyChanged);

        public static readonly BindableProperty WheelSelectedColorProperty = BindableProperty.Create(nameof(WheelSelectedColor), typeof(Color),
                                                                        typeof(Doughnut), Color.FromArgb("#ffdcdcdc"), propertyChanged: OnAnyPropertyChanged);

        public static readonly BindableProperty WheelColorProperty = BindableProperty.Create(nameof(WheelColor), typeof(Color),
                                                                typeof(Doughnut), Color.FromArgb("#ff003270"), propertyChanged: OnAnyPropertyChanged);

        #endregion BindableProperty

        #region Variables

        // actual canvas instance to draw on
        private SKCanvas canvas;

        // rectangle which will be used to draw the Progress Bar
        private SKRect drawRect;

        private float EPSILON = 0.0001f;

        // holds information about the dimensions, etc.
        private SKImageInfo info;

        #endregion Variables

        #region Properties

        public Color InnerColor
        {
            get => (Color)GetValue(InnerColorProperty);
            set => SetValue(InnerColorProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:MyPolicy.UI.Forms.Controls.Doughnut"/> show no data.
        /// </summary>
        /// <value><c>true</c> if show no data; otherwise, <c>false</c>.</value>
        public bool ShowNoData
        {
            get => (bool)GetValue(ShowNoDataProperty);
            set => SetValue(ShowNoDataProperty, value);
        }

        /// <summary>
        /// Gets or sets the sweep angle.
        /// </summary>
        /// <value>The sweep angle.</value>
        public float SweepAngle
        {
            get => (float)GetValue(SweepAngleProperty);
            set => SetValue(SweepAngleProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the wheel.
        /// </summary>
        /// <value>The color of the wheel.</value>
        public Color WheelColor
        {
            get => (Color)GetValue(WheelColorProperty);
            set => SetValue(WheelColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the wheel.
        /// </summary>
        /// <value>The color of the wheel.</value>
        public Color WheelSelectedColor
        {
            get => (Color)GetValue(WheelSelectedColorProperty);
            set => SetValue(WheelSelectedColorProperty, value);
        }

        #endregion Properties

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            canvas = e.Surface.Canvas;
            canvas.Clear(); // clears the canvas for every frame
            info = e.Info;
            drawRect = new SKRect(0, 0, info.Width, info.Height);

            // where the pie starts
            var startAngle = -90F;

            canvas.Clear();

            var center = new SKPoint(info.Width / 2F, info.Height / 2F);

            float bigWheelRadius = 0.96F;
            float bigAngle = 360F;
            float interWheelRadius = 0.96F;
            float miniWheelRadius = 0.84F;

            // draw the big doughnut
            DrawCircle(info, canvas, WheelSelectedColor, 1, startAngle, bigAngle);
            //DrawCircle(info, canvas, InnerColor, interWheelRadius, startAngle, bigAngle);

            if (ShowNoData)
            {
                DrawCircle(info, canvas, WheelColor, 1, -93, 6);
                DrawCircle(info, canvas, InnerColor, miniWheelRadius, startAngle, bigAngle);
            }
            else
            {
                DrawCircle(info, canvas, WheelColor, 1, startAngle, SweepAngle);
                DrawCircle(info, canvas, InnerColor, miniWheelRadius, startAngle, bigAngle);
            }
        }

        /// <summary>
        /// On the sweep angle property changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private static void OnAnyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Doughnut)bindable).InvalidateSurface();
        }

        private void DrawCircle(SKImageInfo info, SKCanvas canvas, Color color, float Radius, float startAngle, float sweepAngle)
        {
            var center = new SKPoint(info.Width / 2F, info.Height / 2F);

            using (var path = new SKPath())
            using (var fillPaint = new SKPaint())
            {
                fillPaint.Style = SKPaintStyle.Fill;
                fillPaint.Color = color.ToSKColor();

                var radius = Math.Min(info.Width / 2, info.Height / 2) * Radius;
                var rect = new SKRect(center.X - radius, center.Y - radius,
                                      center.X + radius, center.Y + radius);

                path.MoveTo(center);
                path.ArcTo(rect, startAngle,
                           Math.Abs(sweepAngle - 360F) < EPSILON ? 359.99F : sweepAngle, false);
                path.Close();

                canvas.DrawPath(path, fillPaint);
            }
        }
    }
}