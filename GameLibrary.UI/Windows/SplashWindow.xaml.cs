using System;
using System.Windows;

namespace GameLibrary.UI.Windows
{
    public partial class SplashWindow : Window
    {
        public SplashWindow(SplashViewModel viewModel)
        {
            if (viewModel is null)
                throw new ArgumentNullException(nameof(viewModel));

            this.InitializeComponent();
            viewModel.AttachWindow(this);
        }
    }
}