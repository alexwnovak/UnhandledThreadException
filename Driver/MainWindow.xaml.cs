using System.Windows;

namespace Driver
{
   public partial class MainWindow : Window
   {
      public MainWindow() => InitializeComponent();
      private void Managed_Click( object sender, RoutedEventArgs e ) => Crash.Instance.Managed();
      private void Native_Click( object sender, RoutedEventArgs e ) => Crash.Instance.Native();
      private void NativeThreaded_Click( object sender, RoutedEventArgs e ) => Crash.Instance.NativeThreaded();
   }
}
