using System;
using System.Windows;

namespace Driver
{
   public partial class App : Application
   {
      protected override void OnStartup( StartupEventArgs e )
      {
         base.OnStartup( e );

         AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
      }

      private void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
      {
         MessageBox.Show( $"Unhandled exception caught:{Environment.NewLine}{e.ExceptionObject}" );
      }
   }
}
