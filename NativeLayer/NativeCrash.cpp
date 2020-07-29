#include "pch.h"
#include "NativeCrash.h"
#include <thread>

void NativeCrash()
{
   throw "";
}

void NativeThreadCrash()
{
   auto func = []
   {
      throw "";
   };

   std::thread thread( func );
   thread.join();

   //std::thread x( func );

   //std::cout << "f";
}
