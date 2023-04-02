using NTwain.Data;
using System;
using System.Runtime.InteropServices;

namespace NTwain.DSM
{
  /// <summary>
  /// Low-level pinvoke methods using /usr/local/lib/libtwaindsm.so.2.3.2.
  /// </summary>
  public static class LinuxBotched64DSM
  {
    const string DsmName = "/usr/local/lib/libtwaindsm.so.2.3.2";

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, IntPtr dest,
        DG dg, DAT dat, MSG msg, ref IntPtr hwnd
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, IntPtr dest,
        DG dg, DAT dat, MSG msg, IntPtr zero
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, IntPtr zero
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref IntPtr mem
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, IntPtr dest,
        DG dg, DAT dat, MSG msg, ref TW_IDENTITY twidentity
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_STATUS twstatus
    );
    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, IntPtr dest,
        DG dg, DAT dat, MSG msg, ref TW_STATUS twstatus
    );
    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, IntPtr dest,
        DG dg, DAT dat, MSG msg, ref TW_STATUSUTF8 twstatusutf8
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, IntPtr dest,
        DG dg, DAT dat, MSG msg, ref TW_ENTRYPOINT twentrypoint
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_DEVICEEVENT twdeviceevent
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_CUSTOMDSDATA twcustomedsdata
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_CALLBACK twcallback
    );
    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_CALLBACK2 twcallback
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref DG xfergroup
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_USERINTERFACE userinterface
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_EVENT evt
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_PENDINGXFERS pendingxfers
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_SETUPMEMXFER memxfer
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_SETUPFILEXFER filexfer
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_PASSTHRU passthru
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_FILESYSTEM filesystem
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_CAPABILITY cap
    );

    [DllImport(DsmName, CharSet = CharSet.Ansi)]
    public static extern ushort DSM_Entry
    (
        ref TW_IDENTITY origin, ref TW_IDENTITY dest,
        DG dg, DAT dat, MSG msg, ref TW_AUDIOINFO auioinfo
    );
  }
}
