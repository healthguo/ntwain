﻿using NTwain.Data;
using System;

namespace NTwain
{
  // TODO: maybe a 2-level "dispose" with end of event being 1
  // and manual dispose 2 for perf if this is not good enough.

  public class DataTransferredEventArgs : EventArgs
  {
    public DataTransferredEventArgs(TW_AUDIOINFO info, TW_SETUPFILEXFER fileInfo)
    {
      AudioInfo = info;
      FileInfo = fileInfo;
    }
    public DataTransferredEventArgs(TW_AUDIOINFO info, byte[] data)
    {
      AudioInfo = info;
      Data = data;
    }

    public DataTransferredEventArgs(TW_IMAGEINFO info, TW_SETUPFILEXFER? fileInfo, byte[]? data)
    {
      ImageInfo = info;
      FileInfo = fileInfo;
      IsImage = true;
      Data = data;
    }

    /// <summary>
    /// Whether transferred data is an image or audio.
    /// </summary>
    public bool IsImage { get; }

    /// <summary>
    /// The complete file data if memory was involved in the transfer. 
    /// IMPORTANT: Content of this array may not valid once
    /// the event handler ends.
    /// </summary>
    public byte[]? Data { get; }

    /// <summary>
    /// The file info if the transfer involved file information.
    /// </summary>
    public TW_SETUPFILEXFER? FileInfo { get; }


    /// <summary>
    /// Gets the final image information if <see cref="IsImage"/> is true.
    /// </summary>
    public TW_IMAGEINFO ImageInfo { get; }


    /// <summary>
    /// Gets the final audio information if <see cref="IsImage"/> is false.
    /// </summary>
    public TW_AUDIOINFO AudioInfo { get; }

  }
}