using System;
using CLILayer;

namespace UnhandledThreadException
{
   class Program
   {
      private static void WriteBanner()
      {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.Write( "Crash" );
         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( " Tester" );
         Console.WriteLine( "============" );
         Console.WriteLine();

         WriteOption( '1', "Managed unhandled exception" );
         WriteOption( '2', "Native unhandled exception" );
         WriteOption( '3', "Threaded managed unhandled exception" );
         WriteOption( '4', "Threaded native unhandled exception" );
         WriteOption( '5', "Quit" );

         void WriteOption( char option, string text )
         {
            Console.Write( "[" );
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write( option );
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine( $"] {text}" );
         }
      }

      private static void GetUserInput()
      {
         var keyInfo = Console.ReadKey( intercept: true );

         switch ( keyInfo.Key )
         {
            case ConsoleKey.D1:
               Crash.Managed();
               break;
            case ConsoleKey.D2:
               Crash.Native();
               break;
            case ConsoleKey.D3:
               break;
            case ConsoleKey.D4:
               Crash.NativeThreaded();
               break;
            case ConsoleKey.Q:
               Environment.Exit( 0 );
               break;
         }
      }

      static int Main( string[] args )
      {
         WriteBanner();
         GetUserInput();

         return 0;

         Console.WriteLine( "===== Starting" );

         AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

         var interopLayer = new InteropLayer();
         //interopLayer.Init();

         //interopLayer.Crash();
         interopLayer.ThreadCrash();

         Console.Read();

         //InteropLayer.

         //var thread = new Thread( new ParameterizedThreadStart( _ =>
         //{
         //   throw new Exception();
         //} ) );

         ////throw new Exception();
         //thread.Start();
         //thread.Join();

         return 0;
      }

      private static void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
      {
         Console.WriteLine( "===== AppDomain UnhandledException" );
      }
   }
}
