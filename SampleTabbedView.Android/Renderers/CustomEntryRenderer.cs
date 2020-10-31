using System;
using Android.Graphics.Drawables;
using Android.Text;
using SampleTabbedView.CustomRenders;
using SampleTabbedView.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SampleTabbedView.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Android.Content.Context context) : base(context)
        { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                this.Control.SetPadding(10, 20, 10, 20);

                gd.SetCornerRadius(5); //increase or decrease to changes the corner look  
                gd.SetColor(Android.Graphics.Color.Transparent);
                gd.SetStroke(3, Android.Graphics.Color.Rgb(211, 211, 211));

                var nativeEntryEditText = Control as FormsEditText;
                nativeEntryEditText.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextFlagCapSentences;
            }
        }
    }
}