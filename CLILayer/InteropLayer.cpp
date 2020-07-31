#include "InteropLayer.h"
#include "NativeCrash.h"

namespace CLILayer
{
   void InteropLayer::OnNativeThreadUnhandledException()
   {
      System::Console::WriteLine( "OH SHIT" );

   }

   void InteropLayer::Init()
   {
      NativeThreadUnhandledExceptionHandler^ handler = gcnew NativeThreadUnhandledExceptionHandler( this, &InteropLayer::OnNativeThreadUnhandledException );
      System::IntPtr handlerPtr = System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate( handler );
      VOID_CALLBACK nativeHandler = static_cast<VOID_CALLBACK>( handlerPtr.ToPointer() );

      InitNativeCrashHandler( nativeHandler );
   }

   void InteropLayer::Crash()
   {
      NativeCrash();
   }

   void InteropLayer::ThreadCrash()
   {
      NativeThreadCrash();
   }
}