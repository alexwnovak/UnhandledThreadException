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
   std::ofstream myfile;

   myfile.open( "C:\\temp\\crash.txt" );
   myfile << "Writing this to a file.\n";
   myfile.close();

   std::cout << "===== Caught exception" << std::endl;

   if (_customExceptionCallback != nullptr)
   {
      _customExceptionCallback();
   }

   return 0L;
}



void InitNativeCrashHandler( VOID_CALLBACK handler )
{
   _customExceptionCallback = handler;

   //set_terminate( [] ()
   //   {
   //      std::cout << "CRUD";
   //   } );



   std::cout << "===== Init native crash handler" << std::endl;
   SetUnhandledExceptionFilter( &UnhandledExceptionGuy );
}

void NativeCrash()
{
   throw "";
}

void NativeThreadCrash()
{
   std::cout << "===== Thread crash" << std::endl;

   auto func = []
   {
      std::cout << "  -- Throwing exception" << std::endl;
      throw ""; // std::runtime_error( "Unhandled thread exception" );
   };

   std::cout << "  -- Starting thread" << std::endl;
   std::thread thread( func );

   std::cout << "  -- Joining thread" << std::endl;

   //Sleep( 5000 );
   thread.join();

   //std::thread x( func );

   //std::cout << "f";
}
