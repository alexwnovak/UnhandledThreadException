using System;
using System.Windows;
using System.Windows.Threading;

namespace Driver
{
   public partial class App : Application
   {
      protected override void OnStartup( StartupEventArgs e )
      {
         base.OnStartup( e );
         //Crash.Instance.Initialize();
         UnhandledExceptionFilter.AddHandler( PInvokeHandler );

         AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
         Dispatcher.UnhandledException += Dispatcher_UnhandledException;
         Dispatcher.UnhandledExceptionFilter += Dispatcher_UnhandledExceptionFilter;
      }

      private void PInvokeHandler()
      {
         MessageBox.Show( $"P/Invoke handler" );
      }

      private void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
      {
         MessageBox.Show( $"APPDOMAIN:{Environment.NewLine}{e.ExceptionObject}" );
      }

      private void Dispatcher_UnhandledException( object sender, DispatcherUnhandledExceptionEventArgs e )
      {
         MessageBox.Show( $"DISPATCHER:{Environment.NewLine}{e.Exception}" );
      }

      private void Dispatcher_UnhandledExceptionFilter( object sender, DispatcherUnhandledExceptionFilterEventArgs e )
      {
         MessageBox.Show( $"DISPATCHER FILTER:{Environment.NewLine}{e.Exception}" );
      }
   }
}
