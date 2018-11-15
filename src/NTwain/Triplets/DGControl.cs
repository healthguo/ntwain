﻿using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTwain.Triplets
{
    /// <summary>
    /// Represents <see cref="DataGroups.Control"/>.
	/// </summary>
    public partial class DGControl : BaseTriplet
    {
        internal DGControl(TwainSession session) : base(session) { }

        Parent _parent;
        internal Parent Parent => _parent ?? (_parent = new Parent(Session));

        EntryPoint _entryPoint;
        internal EntryPoint EntryPoint => _entryPoint ?? (_entryPoint = new EntryPoint(Session));

        Identity _identity;
        internal Identity Identity => _identity ?? (_identity = new Identity(Session));

        Callback _callback;
        internal Callback Callback => _callback ?? (_callback = new Callback(Session));

        Callback2 _callback2;
        internal Callback2 Callback2 => _callback2 ?? (_callback2 = new Callback2(Session));

        Status _status;
        internal Status Status => _status ?? (_status = new Status(Session));
    }
}