![](https://raw.githubusercontent.com/dejanfajfar/epoch.net/master/images/logo.png)

---

![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/dejanfajfar/epoch.net/dotnet.yml?style=flat-square)
![Nuget](https://img.shields.io/nuget/dt/epoch.net?style=flat-square&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FEpoch.net)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/epoch.net?style=flat-square&link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FEpoch.net)

---

# 👋 Introduction

> A simple and non-intrusive library for all your epoch needs

```csharp
using Epoch.net;

...
var timestamp = EpochTime.Now;
...

```

## 🤔 What is an Epoch
Epoch is shorthand for _Unix epoch time_ or as it is also known __POSIX time__.

__Short version:__ The number of seconds since __1970-01-01T00:00:00Z__ without leap seconds.

__Long version:__ [unix time](https://en.wikipedia.org/wiki/Unix_time)

## Motivation
With __.net core__ working on all major operating systems and most of them using POSIX to denote time and timestamps.
Not to mention the myriad of 3rd party tools, using POSIX time internally. The need for a working and tested implementation became clearer and clearer.
Additionally I did not want to write this logic in an inferior form in many of my applications.
So this little library was written.

Its sole purpose is to make the work with these unix timestamps as easy as possible.

For this purpose this library contains extension methods that build upon the existing __DateTime__, __TimeSpan__, __int__ and __long__ types.

# 📖 Glossary

| Term | Description |
|:-----|:-------------|
| EpochTime | Represents a POSIX time instance exact to the _second_ |
| EpochTimestamp | The number of seconds since 1970-01-01T00:00Z |
| LongEpochTime | Represents a POSIX time instance exact to the _millisecond_ |
| LongEpochTimestamp | The number of milliseconds since 1970-01-01T00:00Z |

## Difference between `EpochTime` and `LongEpochTime`

The initial difference was precision. _EpochTime_ will only be accurate to the nearest second on the other hand _LongEpochTime_ is accurate to the millisecond.
From this precision difference I decided to differentiate then by their __underlying__ base type.

`EpochTime` is based on `int32` / `int`

`LongEpochTime` is based on `int64` / `long`  

> ❗This is sadly implies that if you get a POSIX timestamp from somewhere you, the developer, have to know if it is representing milliseconds or seconds!

## Ranges

| Unit | Min value | Max value |
|:----|----:|----:|
| EpochTimestamp | -2147483648 | 2147483647 |
| LongEpochTimestamp | -922337203685477 | 922337203685477 |

📝 _Note:_ The range of the `LongEpoch` is theoretically limited only by the range of `int64`.

# 👨‍🔬 Installation

The preferred way of integrating the library is to use the [nuget package](https://www.nuget.org/packages/Epoch.net). This is easily done be either: 

```shell
dotnet add package Epoch.net
```

or

```shell
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
