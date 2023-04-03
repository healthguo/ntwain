﻿using NTwain.Data;
using NTwain.Triplets;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NTwain
{
  // this file contains callback methods

  partial class TwainSession
  {

    delegate ushort LegacyIDCallbackDelegate(
      ref TW_IDENTITY_LEGACY origin, ref TW_IDENTITY_LEGACY dest,
        DG dg, DAT dat, MSG msg, IntPtr twnull
    );
    delegate ushort BotchedLinuxCallbackDelegate
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, IntPtr twnull
    );
    delegate ushort OSXCallbackDelegate
    (
        ref TW_IDENTITY_MACOSX origin, ref TW_IDENTITY_MACOSX dest,
        DG dg, DAT dat, MSG msg, IntPtr twnull
    );

    // these are kept around while a callback ptr is registered so they
    // don't get gc'd
    readonly LegacyIDCallbackDelegate _legacyCallbackDelegate;
    readonly OSXCallbackDelegate _osxCallbackDelegate;

    /// <summary>
    /// Try to registers callbacks for after opening the source.
    /// </summary>
    internal void RegisterCallback()
    {
      IntPtr cbPtr = IntPtr.Zero;

      if (TwainPlatform.IsMacOSX)
      {
        cbPtr = Marshal.GetFunctionPointerForDelegate(_osxCallbackDelegate);
      }
      else
      {
        cbPtr = Marshal.GetFunctionPointerForDelegate(_legacyCallbackDelegate);
      }

      var rc = STS.FAILURE;

      // per the spec (pg 8-10), apps for 2.2 or higher uses callback2 so try this first
      if (_appIdentity.ProtocolMajor > 2 || (_appIdentity.ProtocolMajor >= 2 && _appIdentity.ProtocolMinor >= 2))
      {
        var cb2 = new TW_CALLBACK2 { CallBackProc = cbPtr };
        rc = DGControl.Callback2.RegisterCallback(ref _appIdentity, ref _currentDS, ref cb2);
      }
      if (rc != STS.SUCCESS)
      {
        // always try old callback
        var cb = new TW_CALLBACK { CallBackProc = cbPtr };
        DGControl.Callback.RegisterCallback(ref _appIdentity, ref _currentDS, ref cb);
      }
    }

    private ushort LegacyCallbackHandler
    (
        ref TW_IDENTITY_LEGACY origin, ref TW_IDENTITY_LEGACY dest,
        DG dg, DAT dat, MSG msg, IntPtr twnull
    )
    {
      Debug.WriteLine($"Legacy callback got {msg}");
      HandleSourceMsg(msg);
      return (ushort)STS.SUCCESS;
    }

    private ushort OSXCallbackHandler
    (
        ref TW_IDENTITY_MACOSX origin, ref TW_IDENTITY_MACOSX dest,
        DG dg, DAT dat, MSG msg, IntPtr twnull
    )
    {
      Debug.WriteLine($"OSX callback got {msg}");
      HandleSourceMsg(msg);
      return (ushort)STS.SUCCESS;
    }

    private void HandleSourceMsg(MSG msg)
    {
      switch (msg)
      {
        case MSG.XFERREADY:
          break;
        case MSG.DEVICEEVENT:
          // use diff thread to get it
          //if (DGControl.DeviceEvent.Get(ref _appIdentity, ref _currentDS, out TW_DEVICEEVENT de) == STS.SUCCESS)
          //{

          //}
          break;
        case MSG.CLOSEDSOK:
          DisableSource();
          break;
        case MSG.CLOSEDSREQ:
          DisableSource();
          break;
      }
    }
  }
}
