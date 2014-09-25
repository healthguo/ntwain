﻿using NTwain.Internals;
using NTwain.Triplets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NTwain
{
    /// <summary>
    /// Contains various platform requirements and conditions for TWAIN.
    /// </summary>
    public class PlatformInfo : IPlatformInfo
    {
        internal static readonly PlatformInfo __global = new PlatformInfo();
        /// <summary>
        /// Gets the current platform info related to TWAIN.
        /// </summary>
        /// <value>
        /// The current info.
        /// </value>
        public static IPlatformInfo Current { get { return __global; } }


        PlatformInfo()
        {
            IsApp64bit = IntPtr.Size == 8;

            IsOnMono = Type.GetType("Mono.Runtime") != null;
            IsWindows = Environment.OSVersion.Platform == PlatformID.Win32NT;
            IsLinux = Environment.OSVersion.Platform == PlatformID.Unix;

            if (IsWindows)
            {
                var newDsmPath = Path.Combine(Environment.SystemDirectory, Dsm.WIN_NEW_DSM_NAME);
                var oldDsmPath = Path.Combine(Environment.SystemDirectory, Dsm.WIN_OLD_DSM_NAME);

                if (IsApp64bit)
                {
                    ExpectedDsmPath = newDsmPath;
                    IsSupported = DsmExists = File.Exists(ExpectedDsmPath);
                    UseNewWinDSM = true;
                }
                else
                {
                    if (File.Exists(newDsmPath))
                    {
                        ExpectedDsmPath = newDsmPath;
                        UseNewWinDSM = IsSupported = DsmExists = true;
                    }
                    else
                    {
                        ExpectedDsmPath = oldDsmPath;
                        IsSupported = DsmExists = File.Exists(ExpectedDsmPath);
                    }
                }
            }
            else if (IsLinux)
            {
                ExpectedDsmPath = Dsm.LINUX_DSM_PATH;
                DsmExists = File.Exists(ExpectedDsmPath);
                IsSupported = DsmExists && IsOnMono;
            }
            else
            {
                // mac? not gonna happen
            }

            _defaultMemManager = new WinMemoryManager();
        }

        internal readonly bool UseNewWinDSM;
        internal readonly bool IsOnMono;
        internal readonly bool IsWindows;
        internal readonly bool IsLinux;

        /// <summary>
        /// Gets a value indicating whether the application is running in 64-bit.
        /// </summary>
        /// <value>
        /// <c>true</c> if the application is 64-bit; otherwise, <c>false</c>.
        /// </value>
        public bool IsApp64bit { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the applicable TWAIN DSM library exists in the operating system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the TWAIN DSM; otherwise, <c>false</c>.
        /// </value>
        public bool DsmExists { get; private set; }

        /// <summary>
        /// Gets the expected TWAIN DSM dll path.
        /// </summary>
        /// <value>
        /// The expected DSM path.
        /// </value>
        public string ExpectedDsmPath { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this library is supported on current OS.
        /// Check the other platform properties to determine the reason if this is false.
        /// </summary>
        /// <value>
        /// <c>true</c> if this library is supported; otherwise, <c>false</c>.
        /// </value>
        public bool IsSupported { get; private set; }


        readonly IMemoryManager _defaultMemManager;
        IMemoryManager _specifiedMemManager;

        /// <summary>
        /// Gets the <see cref="IMemoryManager"/> for communicating with data sources.
        /// This should only be used when a <see cref="TwainSession"/> is open.
        /// </summary>
        /// <value>
        /// The memory manager.
        /// </value>
        public IMemoryManager MemoryManager
        {
            get
            {
                if (_specifiedMemManager == null) { return _defaultMemManager; }
                return _specifiedMemManager;
            }
            internal set
            {
                _specifiedMemManager = value;
            }
        }
    }
}