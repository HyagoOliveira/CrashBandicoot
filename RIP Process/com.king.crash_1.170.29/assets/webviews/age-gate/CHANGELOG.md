# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.4.4] - 2021-08-17

### Fixed
-   Bump up [@king/muffin-styles] to 1.0.8
-   Tap area in buttons after using inputs are now aligned

## [0.4.3] - 2021-08-17

### Fixed

-   Month validation for Android does not activate button when out-of-range input

## [0.4.2] - 2021-08-16

### Added

-   Set maximum and minimum values for Year input
-   Debounce function

### Changed

-   Changes validations from `onBlur` to `onKeyDown` and debounces the event

### Fixed

-   Restricted view now uses its custom `Contact Us`, `Terms of Use` and `Privacy Policy` links to send the propper `GuiId` value
-   Display of popups in landscape view, adapting content and allowing scroll

### Removed

-   JavaScript Map files are removed from the production bundle
-   Input Number increase and decrease arrows

## [0.4.1] - 2021-08-10

### Changed

-   Switch scenarios 2 & 3

## [0.4.0] - 2021-08-04

### Added

-   Age Gate view requesting full birthdate
-   Form validations for birthdate input
-   Blocked and Restricted views
-   Interaction, load view and form submission tracking events
-   UI using [@king/muffin-styles] v1.0.6

### Removed
-   Alternatives for *Only Year* and *Age Ranges*

## 0.2.0

### Added

-   FHSS Experiment Prototype

[@king/muffin-styles]: https://github.int.midasplayer.com/social-and-identity/muffin/tree/master/packages/mb-styles

[Unreleased]: https://github.int.midasplayer.com/social-and-identity/age-gate-webview/compare/v0.4.3...develop
[0.4.3]: https://github.int.midasplayer.com/social-and-identity/age-gate-webview/compare/v0.4.2...v0.4.3
[0.4.2]: https://github.int.midasplayer.com/social-and-identity/age-gate-webview/compare/v0.4.1...v0.4.2
[0.4.1]: https://github.int.midasplayer.com/social-and-identity/age-gate-webview/compare/v0.4.0...v0.4.1
[0.4.0]: https://github.int.midasplayer.com/social-and-identity/age-gate-webview/compare/v0.2.0...v0.4.0
