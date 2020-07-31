using System;
using System.Windows;
using CLILayer;

namespace Driver
{
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Button_Click( object sender, RoutedEventArgs e )
      {
         throw new Exception( "Managed exception" );
      }

      private void Button_Click_1( object sender, RoutedEventArgs e )
      {
         new InteropLayer().Crash();
      }

      private void Button_Click_2( object sender, RoutedEventArgs e )
      {
         new InteropLayer().ThreadCrash();
      }
   }
}
