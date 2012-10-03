﻿using Me.Amon.Api.Enums;

namespace Me.Amon.Api.Input
{
    /// <summary>
    /// The contract for a service that interprets the state of input devices.
    /// </summary>
    public interface IInputDeviceStateAdaptor
    {
        /// <summary>
        /// Determines whether the specified key is up or down.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        /// <returns>
        /// 	<c>true</c> if the key is down; otherwise, <c>false</c>.
        /// </returns>
        bool IsKeyDown(VirtualKey keyCode);

        /// <summary>
        /// Determines whether the specified key is up or down.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        /// <returns>
        /// 	<c>true</c> if the key is up; otherwise, <c>false</c>.
        /// </returns>
        bool IsKeyUp(VirtualKey keyCode);

        /// <summary>
        /// Determines whether the physical key is up or down at the time the function is called regardless of whether the application thread has read the keyboard event from the message pump.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        /// <returns>
        /// 	<c>true</c> if the key is down; otherwise, <c>false</c>.
        /// </returns>
        bool IsHardwareKeyDown(VirtualKey keyCode);

        /// <summary>
        /// Determines whether the physical key is up or down at the time the function is called regardless of whether the application thread has read the keyboard event from the message pump.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        /// <returns>
        /// 	<c>true</c> if the key is up; otherwise, <c>false</c>.
        /// </returns>
        bool IsHardwareKeyUp(VirtualKey keyCode);

        /// <summary>
        /// Determines whether the toggling key is toggled on (in-effect) or not.
        /// </summary>
        /// <param name="keyCode">The <see cref="VirtualKey"/> for the key.</param>
        /// <returns>
        /// 	<c>true</c> if the toggling key is toggled on (in-effect); otherwise, <c>false</c>.
        /// </returns>
        bool IsTogglingKeyInEffect(VirtualKey keyCode);
    }
}