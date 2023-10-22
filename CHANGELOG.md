# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [3.2]
### Changed

- Updated to .net version 7
- Moved build to github actions
- 

### Added

- DateOnly extensions
- TimeOnly extensions

## [3.1]
### Added

- LongEpochTime ToString method
- EpochTime ToString method

## [3.0]
### Added

- LongEpochTime
- EpochTime.ShortEpoch
- EpochTime.RawEpoch
- EpochTime.DateTime
- EpochTime.TimeSpan
- EpochTime.Add
- EpochValidator
- EpochTimeValueException
- ITimeProvider
- DefaultTimeProvider
- Long extensions methods

### Removed

- EpochOverflowException
- EpochTime.AddSeconds
- EpochTime.ToRawEpoch
- EpochTime.ToDateTime
- EpochTime.ToTimeSpan

## [2.0]
### Changed

- Renamed the ```Epoch``` class to ```EpochTime``` to fix the name collision with the namespace.
- Updated the README.md to reflect the new naming

### Fixed

- The name collision bug

## [1.1]
### Fixed

* DateTime.ToRawEpoch now thrown an EpochOverflow exception if the resulting epoch is not storable in an integer
