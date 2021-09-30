using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace ButtonDemo
{
    public partial class MainPage : ContentPage
    {
        bool animationInProgress = false;
        bool bold = false;
        Stopwatch stopwatch = new Stopwatch();
        public MainPage()
        {
            InitializeComponent();
        }
        void OnButtonPressed(object sender, EventArgs args)
        {
            stopwatch.Start();
            animationInProgress = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(20), () =>
            {
                label.Rotation = 360 * (stopwatch.Elapsed.TotalSeconds % 1);
                return animationInProgress;
            });
        }
        void OnButtonReleased(object sender, EventArgs args)
        {
            animationInProgress = false;
            stopwatch.Stop();
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            if (bold)
            {
                bold = false;
                button.FontAttributes = FontAttributes.None;
            }
            else
            {
                bold = true;
                button.FontAttributes = FontAttributes.Bold;
            }
        }
    }
}