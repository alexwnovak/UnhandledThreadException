#include "pch.h"
#include "NativeCrash.h"

#include <exception>
#include <thread>
#include <iostream>
#include <fstream>

#include <Windows.h>

VOID_CALLBACK _customExceptionCallback = nullptr;

LONG UnhandledExceptionGuy( PEXCEPTION_POINTERS pExceptionInfo )
{
   _customExceptionCallback();
   return EXCEPTION_CONTINUE_SEARCH;
}

void InitNativeCrashHandler( VOID_CALLBACK handler )
{
   _customExceptionCallback = handler;
   SetUnhandledExceptionFilter( &UnhandledExceptionGuy );
}

void NativeCrash()
{
   throw "";
}

DWORD WINAPI Win32ThreadFunc( LPVOID lpParam )
{
   throw 123;
   return 0;
}

void NativeThreadCrashStl()
{
   auto func = []
   {
      throw "";
   };

   std::thread thread( func );
   thread.join();
}

void NativeThreadCrashWin32()
{
   DWORD threadId;
   auto hThread = CreateThread(
      nullptr,                   // default security attributes
      0,                         // use default stack size
      Win32ThreadFunc,           // thread function name
      nullptr,                   // argument to thread function
      0,                         // use default creation flags
      &threadId );
}
