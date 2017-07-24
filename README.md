# epoch.net

A simple non intrusive epoch calculation thing.

## Motivation
In reality this is a siteproduct of the [openTSDB.net](http://github.com/dfajfar/opentsdb.net)
project. After implementing it as part of the aforementioned project I found it to usefull to
just be a internall code artefact.

# Usage

## DateTime => Epoch

To get a unix epoch representation of a DateTime Object

```
var epochNow = DateTime.Now.AsEpoch();
```

or

```
var epochNow = DateTime.UtcNow.AsEpoch();
```

or


```
var epochNow = Epoch.Now;
```

or

```
var epochNow = new Epoch(DateTime.Now).AsEpoch;
```

## Epoch => DateTime

```
var dateTime = 0l.AsDateTime();
```

or

```
var dateTime = 0l.AsDateTime();
```