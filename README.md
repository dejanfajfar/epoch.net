[![Build status](https://ci.appveyor.com/api/projects/status/3k10iipudlw1v9va?svg=true)](https://ci.appveyor.com/project/dejanfajfar/epoch-net)
[![Build status](https://ci.appveyor.com/api/projects/status/3k10iipudlw1v9va/branch/master?svg=true)](https://ci.appveyor.com/project/dejanfajfar/epoch-net/branch/master)
[![](https://img.shields.io/nuget/v/epoch.net.svg)](https://www.nuget.org/packages/Epoch.net/)
![](https://img.shields.io/nuget/dt/epoch.net.svg)

![](https://raw.githubusercontent.com/dejanfajfar/epoch.net/master/images/logo.png)

# epoch.net

> A simple and non-intrusive library for all your epoch needs

```c#
using Epoch.net 

...
var timestamp = Epoch.NowRaw
...

```

## What is an Epoch
Epoch is shorthand for _Unix epoch time_ or as it is also known __POSIX time__.

Short version: The number of seconds since 1970-01-01T00:00:00 without leap seconds.

Long version: [unix time](https://en.wikipedia.org/wiki/Unix_time)

## Motivation
More an more times I had to convert between the CLIs DateTime an a epoch. 
Because writing the same code over and over again was getting boring this little
library was created. 

Its sole purpose is to make the work with these unix timestamps as easy as possible.

For this purpose this little library contains extension methods that build
upon the existing __DateTime__.

## Glossary

| Term | Description |
|:-----|-------------:|
| Epoch | A wrapper object providing multiple tools to work with epoch data |
| rawEpoch | An integer representing the seconds passed since 1970-01-01T00:00:00 without leap seconds |


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

### Convert a DateTime to a epoch timestamp

```c#
using Epoch.net

var timestamp = Epoch.NowRaw;
```

or use the provided extension method on the DateTime structure

```c#
using Epoch.net

var timestamp = DateTime.Now.ToRawEpoch
```

### Convert a epoch timestamp to a DateTime

```c#
using Epoch.net

var timestamp = 1547931356;

var date = new Epoch(timestamp).ToRawEpoch();
```

or use the extension method on the integer

```c#
using Epoch.net

var timestamp = 1547931356;

var date = timestamp.ToDateTime();
```

### Determine the time span between two epoch timestamps

```c#
using Epoch.net

var timestamp1 = 1540425600;
var timestamp2 = 1547931356;

var epoch1 = new Epoch(timestamp1);
var epoch2 = new Epoch(timestamp2);

var epochDif = epoch2 - epoch1;

var timeSpan = epochDif.ToTimeSpan();
```

or we again use some provided extension methods

```c#
using Epoch.net

var timestamp1 = 1540425600;
var timestamp2 = 1547931356;

var timeSpan = (timestamp1 - timestamp2).ToTimeSpan();
```

### And much more...

More scenarios can be found in the wiki.

## Next steps

After the release of 1.0 and creating a new baseline I will concentrate on any possible bug fixes and to add as many convenience methods as possible.

Any bugs an feature request are welcome! 
