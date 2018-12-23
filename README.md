[![Build status](https://ci.appveyor.com/api/projects/status/3k10iipudlw1v9va?svg=true)](https://ci.appveyor.com/project/dejanfajfar/epoch-net)
[![Build status](https://ci.appveyor.com/api/projects/status/3k10iipudlw1v9va/branch/master?svg=true)](https://ci.appveyor.com/project/dejanfajfar/epoch-net/branch/master)
[![](https://img.shields.io/nuget/v/epoch.net.svg)](https://www.nuget.org/packages/Epoch.net/)

![](https://github.com/dejanfajfar/epoch.net/blob/raw/net-stadard/images/logo_square_64.png?raw=true)

# epoch.net

> A simple and non-intrusive library for all your epoch needs

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
