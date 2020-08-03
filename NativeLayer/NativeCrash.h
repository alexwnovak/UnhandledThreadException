#pragma once

typedef void( __stdcall* VOID_CALLBACK )( );

void InitNativeCrashHandler( VOID_CALLBACK handler );
void NativeCrash();
void NativeThreadCrashStl();
void NativeThreadCrashWin32();
