using System;
using CLILayer;

namespace UnhandledThreadException
{
   class Program
   {
      static void Main( string[] args )
      {
         AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
         //InteropLayer.Crash();
         InteropLayer.ThreadCrash();

         //InteropLayer.

         //var thread = new Thread( new ParameterizedThreadStart( _ =>
         //{
         //   throw new Exception();
         //} ) );

         ////throw new Exception();
         //thread.Start();
         //thread.Join();
      }

      private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
      {
      }
   }
}
