#pragma once

#include <Windows.h>

namespace CLILayer
{
   public ref class InteropLayer
   {
   public:
      void Init();
      void Crash();
      void ThreadCrash();

      event System::EventHandler^ UnhandledNativeException;

   private:
      delegate void NativeThreadUnhandledExceptionHandler();

      void OnNativeThreadUnhandledException();
   };
}
