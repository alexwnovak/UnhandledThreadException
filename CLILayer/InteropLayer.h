#pragma once

namespace CLILayer
{
   public ref class InteropLayer abstract sealed
   {
   public:
      static void Crash();
      static void ThreadCrash();
   };
}
