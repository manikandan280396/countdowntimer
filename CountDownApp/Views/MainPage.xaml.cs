using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CountDownApp
{
    public partial class MainPage : ContentPage
    {
        private TimeSpan totalTime;
        private bool isTimerRunning = false;
        public MainPage()
        {
            InitializeComponent();
            InitializeFlipViews();
            if (!isTimerRunning)
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    UpdateTimer();
                    return isTimerRunning && totalTime.TotalSeconds > 0;
                });

                isTimerRunning = true;
            }

        }
        private void InitializeFlipViews()
        {
            totalTime = TimeSpan.FromDays(8) + TimeSpan.FromHours(23) + TimeSpan.FromMinutes(55) + TimeSpan.FromSeconds(45);

            dayFlipView.SetNumberAsync(totalTime.Days);
            hourFlipView.SetNumberAsync(totalTime.Hours);
            minuteFlipView.SetNumberAsync(totalTime.Minutes);
            secondFlipView.SetNumberAsync(totalTime.Seconds);
        }

        

        private void UpdateTimer()
        {
            totalTime = totalTime.Subtract(TimeSpan.FromSeconds(1));

            if (totalTime.TotalSeconds < 0)
            {
                totalTime = TimeSpan.Zero;
                isTimerRunning = false;
            }

            dayFlipView.SetNumberAsync(totalTime.Days);
            hourFlipView.SetNumberAsync(totalTime.Hours);
            minuteFlipView.SetNumberAsync(totalTime.Minutes);
            secondFlipView.SetNumberAsync(totalTime.Seconds);
        }

        void tapImage_Tapped(System.Object sender, System.EventArgs e)
        {
             Launcher.OpenAsync("http://facebook.com");
        }

        void tapImage_Tapped_1(System.Object sender, System.EventArgs e)
        {
            Launcher.OpenAsync("http://facebook.com");
        }

        void tapImage_Tapped_2(System.Object sender, System.EventArgs e)
        {
            Launcher.OpenAsync("http://instagram.com");
        }
    }
}


