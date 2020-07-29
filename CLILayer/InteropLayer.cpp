#include "InteropLayer.h"
#include "NativeCrash.h"

namespace CLILayer
{
   void InteropLayer::Crash()
   {
      NativeCrash();
   }

   void InteropLayer::ThreadCrash()
   {
      NativeThreadCrash();
   }
}