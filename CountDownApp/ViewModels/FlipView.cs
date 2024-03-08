using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CountDownApp.ViewModels
{
	public class FlipView : ContentView
    {
        private Label topLabel;
        private Label bottomLabel;
        private BoxView flipBox;

        public FlipView()
        {
            topLabel = new Label
            {

                Padding = 10,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromRgb(0, 0, 0),
                WidthRequest = 55,
                HeightRequest=55,
                BackgroundColor = Color.FromRgb(255, 255, 255)
            };

            bottomLabel = new Label
            {
                Padding = 10,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                FontSize = 24,
                WidthRequest = 55,
                HeightRequest = 55,
                TextColor = Color.FromRgba(252, 96, 135, 255),
                BackgroundColor = Color.FromRgba(52, 55, 80, 255)

            };

            flipBox = new BoxView
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Color = Color.FromRgba(255, 0, 0, 0)
            };

            var flipGesture = new TapGestureRecognizer();
            flipGesture.Tapped += OnFlipTapped;

            GestureRecognizers.Add(flipGesture);

            Content = new Grid
            {
                Children = { topLabel, bottomLabel, flipBox }
            };
        }

        private async void OnFlipTapped(object sender, EventArgs e)
        {
            await this.RotateXTo(180, 250, Easing.Linear);
            (topLabel.Text, bottomLabel.Text) = (bottomLabel.Text, topLabel.Text);
            await this.RotateXTo(0, 250, Easing.Linear);
        }

        public async Task SetNumberAsync(int number)
        {
            if (topLabel.Text != number.ToString())
            {
                topLabel.Text = number.ToString();
                await FlipAsync();
            }
        }

        private async Task FlipAsync()
        {
            await this.RotateXTo(90, 250, Easing.Linear);
            (topLabel.Text, bottomLabel.Text) = (bottomLabel.Text, topLabel.Text);
            await this.RotateXTo(0, 250, Easing.Linear);
        }


    }

}

