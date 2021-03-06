﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using Me.Amon.Api.Structures;
using Me.Amon.Api.User32;

namespace Me.Amon.Api.Input
{
    /// <summary>
    /// Implements the <see cref="IInputMessageDispatcher"/> by calling <see cref="NativeMethods.SendInput"/>.
    /// </summary>
    internal class WindowsInputMessageDispatcher : IInputMessageDispatcher
    {
        /// <summary>
        /// Dispatches the specified list of <see cref="INPUT"/> messages in their specified order by issuing a single called to <see cref="NativeMethods.SendInput"/>.
        /// </summary>
        /// <param name="inputs">The list of <see cref="INPUT"/> messages to be dispatched.</param>
        /// <returns>
        /// The number of <see cref="INPUT"/> messages that were successfully dispatched.
        /// </returns>
        public UInt32 DispatchInput(INPUT[] inputs)
        {
            return User32API.SendInput((UInt32)inputs.Count(), inputs.ToArray(), Marshal.SizeOf(typeof(INPUT)));
        }
    }
}