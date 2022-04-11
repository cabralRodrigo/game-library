using System.Windows;

namespace GameLibrary.UI.Windows
{
    public class ViewModel
    {
        public Window Owner { get; set; } = default!;

        public void AttachWindow(Window window)
        {
            this.Owner = window;
            window.DataContext = this;

            window.Loaded += (_, _) => this.OnOwnerLoaded();
            window.Closing += (_, e) => e.Cancel = !this.OnOwnerClosing();
        }

        protected virtual bool OnOwnerClosing() => true;
        protected virtual void OnOwnerLoaded() { }
    }
}