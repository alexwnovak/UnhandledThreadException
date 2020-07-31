using System;
using CLILayer;

namespace UnhandledThreadException
{
   internal static class Crash
   {
      public static void Managed()
      {
         throw new Exception( "Managed exception" );
      }

      public static void Native()
      {
         new InteropLayer().Crash();
      }

      public static void NativeThreaded()
      {
         new InteropLayer().ThreadCrash();
      }
   }
}
