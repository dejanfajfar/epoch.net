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

# ✅ Features

- EpochTime a second precise POSIX time wrapper
- LongEpochTime a millisecond precise POSIX time wrapper
- Extension methods for build in time handling classes:
  - DateTime
  - TimeSpan
  - DateOnly
  - TimeOnly
- Fully tested ;)

# 🏃‍♂️ Quick start

## Add the package to yor project

The preferred way of integrating the library is to use the [nuget package](https://www.nuget.org/packages/Epoch.net). This is easily done be either: 

```shell
dotnet add package Epoch.net
```

or

```shell
Install-Package Epoch.net
```

## Reference

After the package is added to the project add the using directive:

```csharp
...
using Epoch.net;
...
```

Done 🎉

# 🦮 Helping out

Everyone can help in their own way. 

Here are just some ideas:

- Create a [ticket](https://github.com/dejanfajfar/epoch.net/issues) with a improvement suggestion
- Create a [ticket](https://github.com/dejanfajfar/epoch.net/issues) with a bug or issue you may be having
- Create a [ticket](https://github.com/dejanfajfar/epoch.net/issues) with a question that you may be having
- Have a look at the code and suggest improvements
- Spread the word of its existence
- And for the hardcore among you you can help me with the documentation 😈

# 🔗 Links

- [Changelog](https://github.com/dejanfajfar/epoch.net/blob/master/CHANGELOG.md)
- [Wiki](https://github.com/dejanfajfar/epoch.net/wiki)
- [Nuge](https://www.nuget.org/packages/Epoch.net)

# ⏭️ Next steps

- Consult the [Wiki](https://github.com/dejanfajfar/epoch.net/wiki)
- Create a [ticket](https://github.com/dejanfajfar/epoch.net/issues) to help the project improve