﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BreakOutApp
{
    public sealed partial class Ball : UserControl
    {
        // location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        // speed
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public Ball()
        {
            this.InitializeComponent();

            Width = 15;
            Height = 15;
            SpeedX = -6;
            SpeedY = -6;
        }

        // return balls rect
        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }

        // move ball

        public void Move()
        {
            // change in x
            LocationX = LocationX + SpeedX;
            if (LocationX < 0)
            {
                LocationX = 0;
                SpeedX *= -1;
            }
            else if (LocationX + Width > MainPage.CanvasWidth) // right
            {
                LocationX = MainPage.CanvasWidth - Width;
                SpeedX *= -1;
            }
            // Change in y
            LocationY = LocationY + SpeedY;
            if (LocationY < 0) // up
            {
                LocationY = 0;
                SpeedY *= -1;
            }
            // Move ball in canvas
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY); 
        }

        // ball speed, hit percent -0.5 <-> 0.5
        public void SetSpeed(double hitPercent)
        {
            SpeedX = hitPercent * 10; // -5 <-> 5
            SpeedY *= -1;
        }
    }
}
