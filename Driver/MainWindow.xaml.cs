using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace Driver
{
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         if ( Debugger.IsAttached )
         {
            PInvokeFilterButton.Background = new SolidColorBrush( Colors.Red );
         }
         else
         {
            DebuggerWarningMessage.Visibility = Visibility.Collapsed;
         }
      }

      private void OnUnhandledNativeException( object sender, EventArgs e ) => MessageBox.Show( "Unhandled native exception" );
      private void PInvokeHandler() => MessageBox.Show( "P/invoke unhandled native exception" );

      private void NativeExceptionFilter_Click( object sender, EventArgs e )
      {
         Crash.Instance.Initialize();
         Crash.Instance.UnhandledNativeException += OnUnhandledNativeException;
      }

      private void PInvokeExceptionFilter_Click( object sender, EventArgs e )
      {
         UnhandledExceptionFilter.AddHandler( PInvokeHandler );
      }

      private void Managed_Click( object sender, RoutedEventArgs e ) => Crash.Instance.Managed();
      private void Native_Click( object sender, RoutedEventArgs e ) => Crash.Instance.Native();
      private void NativeThreaded_Click( object sender, RoutedEventArgs e ) => Crash.Instance.NativeThreadedStl();
      private void NativeThreadedWin32_Click( object sender, RoutedEventArgs e ) => Crash.Instance.NativeThreadedWin32();
   }
}
