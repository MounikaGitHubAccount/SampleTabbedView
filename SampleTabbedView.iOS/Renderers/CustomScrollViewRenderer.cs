﻿using System;
using SampleTabbedView.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScrollView), typeof(CustomScrollViewRenderer))]

namespace SampleTabbedView.iOS.Renderers
{
    public class CustomScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Bounces = false;
        }
    }
}

