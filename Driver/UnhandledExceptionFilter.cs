using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Driver
{
   public static class UnhandledExceptionFilter
   {
      //private enum FilterDelegate : uint
      //{
      //   EXCEPTION_EXECUTE_HANDLER = 0x1,
      //   EXCEPTION_CONTINUE_EXECUTION = 0xffffffff,
      //   EXCEPTION_CONTINUE_SEARCH = 0x0
      //}

      [UnmanagedFunctionPointer( CallingConvention.StdCall )]
      private delegate int FilterDelegate( IntPtr exception_pointers );

      [DllImport( "kernel32.dll" )]
      private static extern long SetUnhandledExceptionFilter( FilterDelegate lpTopLevelExceptionFilter );

      public static void AddHandler( Action action )
      {
         SetUnhandledExceptionFilter( _ =>
         {
            action();
            return 0;
         } );
      }
   }
}
