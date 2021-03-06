﻿using System;
using CLILayer;

namespace Driver
{
   internal class Crash
   {
      public static Crash Instance { get; } = new Crash();
      private readonly InteropLayer _interopLayer = new InteropLayer();

      public event EventHandler UnhandledNativeException;

      private Crash() => _interopLayer.UnhandledNativeException += UnhandledNativeException;

      public void Initialize() => _interopLayer.Init();
      public void Managed() => throw new Exception();
      public void Native() => _interopLayer.Crash();
      public void NativeThreadedStl() => _interopLayer.ThreadCrashStl();
      public void NativeThreadedWin32() => _interopLayer.ThreadCrashWin32();
   }
}
