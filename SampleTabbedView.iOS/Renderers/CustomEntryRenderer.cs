using System;
using CoreGraphics;
using SampleTabbedView.CustomRenders;
using SampleTabbedView.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SampleTabbedView.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.BorderColor = UIColor.FromRGB(211, 211, 211).CGColor;
                Control.Layer.BorderWidth = 0;

                //Control.LeftView = new UIView(new CGRect(0, 0, 8, 0));
                //Control.LeftViewMode = UITextFieldViewMode.Always;
                //Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
                //Control.RightViewMode = UITextFieldViewMode.Always;
            }
        }
    }
}