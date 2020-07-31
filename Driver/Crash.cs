using System;
using CLILayer;

namespace Driver
{
   internal class Crash
   {
      public static Crash Instance { get; } = new Crash();
      private readonly InteropLayer _interopLayer = new InteropLayer();

      public void Initialize() => _interopLayer.Init();
      public void Managed() => throw new Exception();
      public void Native() => _interopLayer.Crash();
      public void NativeThreaded() => _interopLayer.ThreadCrash();
   }
}
