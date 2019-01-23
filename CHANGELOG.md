# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).


## [1.1]
### Fixed

* DateTime.ToRawEpoch now thrown an EpochOverflow exception if the resulting epoch is not storable in an integer
