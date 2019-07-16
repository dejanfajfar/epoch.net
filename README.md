[![Build status](https://ci.appveyor.com/api/projects/status/3k10iipudlw1v9va?svg=true)](https://ci.appveyor.com/project/dejanfajfar/epoch-net)
[![Build status](https://ci.appveyor.com/api/projects/status/3k10iipudlw1v9va/branch/master?svg=true)](https://ci.appveyor.com/project/dejanfajfar/epoch-net/branch/master)
[![](https://img.shields.io/nuget/v/epoch.net.svg)](https://www.nuget.org/packages/Epoch.net/)
![](https://img.shields.io/nuget/dt/epoch.net.svg)
[![Gitter](https://img.shields.io/gitter/room/dejanfajfar/epoch.net.svg)](https://gitter.im/dejanfajfar/epoch.net)

![](https://raw.githubusercontent.com/dejanfajfar/epoch.net/master/images/logo.png)

# epoch.net

> A simple and non-intrusive library for all your epoch needs

```csharp
using Epoch.net;

...
var timestamp = EpochTime.Now;
...

```

# v3 breaking changes

with the new v3 some breaking changes have happened!

Methods were replaced by properties and the Error Types have changed.

If something is too broken please feel free to scream at me in the chat: [![Gitter](https://img.shields.io/gitter/room/dejanfajfar/epoch.net.svg)](https://gitter.im/dejanfajfar/epoch.net)

## What is an Epoch
Epoch is shorthand for _Unix epoch time_ or as it is also known __POSIX time__.

Short version: The number of seconds since __1970-01-01T00:00:00Z__ without leap seconds.

Long version: [unix time](https://en.wikipedia.org/wiki/Unix_time)

## Motivation
With __.net core__ working on all major operating systems and most of them using POSIX to denote time and timestamps.
Not to mention the myriad of 3rd party tools, using POSIX time internally. The need for a working and tested implementation became clearer and clearer.
Additionally I did not want to write this logic in an inferior form in many of my applications.
So this little library was written.

Its sole purpose is to make the work with these unix timestamps as easy as possible.

For this purpose this library contains extension methods that build upon the existing __DateTime__, __TimeSpan__, __int__ and __long__ types.

## Glossary

| Term | Description |
|:-----|-------------:|
| EpochTime | Represents a POSIX time instance exact to the _second_ |
| EpochTimestamp | The number of seconds since 1970-01-01T00:00Z |
| LongEpochTime | Represents a POSIX time instance exact to the _millisecond_ |
| LongEpochTimestamp | The number of milliseconds since 1970-01-01T00:00Z |

### Difference between EpochTime and LongEpochTime

The initial difference was precision. _EpochTime_ will only be accurate to the nearest second on the other hand _LongEpochTime_ is accurate to the millisecond.
From this precision difference I decided to differentiate then by their __underlying__ base type.

_EpochTime_ is based on __int32__ / _int_

_LongEpochTime_ is based on __int64__ / _long_  

> This is sadly implies that if you get a POSIX timestamp from somewhere you, the developer, have to know if it is representing milliseconds or seconds!

## Ranges

| Unit | Min value | Max value |
|:----|----:|----:|
| EpochTimestamp | -2147483648 | 2147483647 |
| LongEpochTimestamp | -922337203685477 | 922337203685477 |

_Note:_ The range of the __LongEpochTimestamp__ and __LongEpoch__ is theoretically limited only by the range of _int64_.
If left like this some timestamps could not be represented by the __TimeSpan__ structure.

## Installation

Installation is simple as installing any other __nuget package__ 

```bash
dotnet add package Epoch.net
```

or

```bash
Install-Package Epoch.net
```

## Quick How-Tos

Before you go and start looking for answers in the wiki here a few common scenarios and their suggested solutions.

### Current time to EpochTime

```csharp
using Epoch.net;

var timestamp = EpochTime.Now;
```

or use the provided extension method on the DateTime structure

```csharp
using Epoch.net;

var timestamp = DateTime.Now.ToEpochTime();
```

#### The same is true for a LongEpochTime

```csharp
using Epoch.net;

var timestamp = LongEpochTime.Now;
```

or

```csharp
using Epoch.net;

var timestamp = DateTime.Now.ToLongEpochTime();
```

### Get a DateTime from a epoch timestamp

```csharp
using Epoch.net;

int timestamp = 1547931356;

var date = new EpochTime(timestamp).DateTime;
```

or use the extension method on the integer

```csharp
using Epoch.net

int timestamp = 1547931356;

var date = timestamp.ToDateTime();
```

#### The same can be done with a LongEpochTimestamp

```csharp
using Epoch.net;

long timestamp = 1547931356567;

var date = new LongEpochTime(timestamp).DateTime;
```

or

```csharp
using Epoch.net

long timestamp = 1547931356;

var date = timestamp.ToDateTime();
```

### Determine the time span between two epoch timestamps

```csharp
using Epoch.net;

int timestamp1 = 1540425600;
int timestamp2 = 1547931356;

var epoch1 = new EpochTime(timestamp1);
var epoch2 = new EpochTime(timestamp2);

var epochDif = epoch2 - epoch1;

var timeSpan = epochDif.ToTimeSpan();
```

or we again use some provided extension methods

```csharp
using Epoch.net

int timestamp1 = 1540425600;
int timestamp2 = 1547931356;

var timeSpan = (timestamp1 - timestamp2).ToTimeSpan();
```

### And much more...

More scenarios can be found in the wiki...

## Next steps

Check out the chat 
[![Gitter](https://img.shields.io/gitter/room/dejanfajfar/epoch.net.svg)](https://gitter.im/dejanfajfar/epoch.net)

Or the wiki (if I have created one yet) :)