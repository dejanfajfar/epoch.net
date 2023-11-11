using System;

namespace Epoch.net;

/// <summary>
/// Defines a date time provides as used by Epoch.net
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current system UTC time
    /// </summary>
    DateTime UtcNow { get; }
}