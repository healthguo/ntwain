﻿using NTwain.Data;
using NTwain.Values;

namespace NTwain.Triplets
{
    /// <summary>
    /// Represents <see cref="DataArgumentType.DeviceEvent"/>.
    /// </summary>
	public sealed class DeviceEvent : OpBase
	{
		internal DeviceEvent(ITwainStateInternal session) : base(session) { }
		public ReturnCode Get(out TWDeviceEvent sourceDeviceEvent)
		{
			Session.VerifyState(4, 7, DataGroups.Control, DataArgumentType.DeviceEvent, Message.Get);
			sourceDeviceEvent = new TWDeviceEvent();
			return Dsm.DsmEntry(Session.AppId, Session.SourceId, Message.Get, sourceDeviceEvent);
		}
	}
}