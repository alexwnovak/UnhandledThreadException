using System;
using System.Windows;

namespace Driver
{
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
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
      private void NativeThreaded_Click( object sender, RoutedEventArgs e ) => Crash.Instance.NativeThreaded();
   }
}
