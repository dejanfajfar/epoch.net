# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [3.0]
### Added

- Decimal extensions methods
- Double extensions methods
- EpochTime.ShortEpoch
- EpochTime.RawEpoch
- EpochTime.DateTime
- EpochTime.TimeSpan
- EpochTime.AddHours
- EpochTime.AddTimeSpan
- EpochTime.ctor for decimal values
- TimeSpanExtensions.ToShortEpoch
- DateTimeExtensions.ToShortEpoch
- EpochValidator
- EpochValueException

### Changed

- The underlying value of the stored raw Epoch is changed from int to double
- ```EpochTime.ToRawEpoch``` return type changed from ```ìnt``` to ```double```
- TimeSpanExtensions.ToRawEpoch returns double instead of int
- DateTimeExtensions.ToRawEpoch returns double instead of int

### Deprecated

- EpochTime.ToRawEpoch
- EpochTime.ToDateTime
- EpochTime.ToTimeSpan

### Removed

- EpochOverflowException

## [2.0]
### Changed

- Renamed the ```Epoch``` class to ```EpochTime``` to fix the name collision with the namespace.
- Updated the README.md to reflect the new naming

### Fixed

- The name collision bug

## [1.1]
### Fixed

* DateTime.ToRawEpoch now thrown an EpochOverflow exception if the resulting epoch is not storable in an integer
