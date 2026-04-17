<!--
  260417_code
  260417_documentation
-->

<!-- [PROJECT WARNING] =========================================================
* Project warning
---------------------------------------------------------------------------- -->

> [!WARNING]  
> Tingen Transmorger is currently **Beta software**.

<!--
This divider separates the this section from the rest of the README. If you are
not using the this section, comment this divider out.
--->
---

<!-- ===================================================== [PROJECT WARNING] -->

<!-- [PROJECT INTRO] ===========================================================
* Project logo
  There are references for both a "light" and "dark" images. The dark image
  should have a background of HEX #0d1117, to match the dark mode of GitHub.
  The light image is the fallback.
* Project title
* Project catchphrase!
* Project badges
---------------------------------------------------------------------------- -->

<div align="center">

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset=".github/repository/logo/TransmorgerLogo-256x256.png">
    <source media="(prefers-color-scheme: light)" srcset=".github/repository/logo/TransmorgerLogo-256x256.png">
    <img alt="Fallback image description" src=".github/repository/logo/TransmorgerLogo-256x256.png">
  </picture>

  <h1>Tingen Transmorger</h1>

  A utility for parsing Netsmart AvatarNX TeleHealth reports.

  ![RELEASE](https://img.shields.io/badge/Version-0.9.31.0-teal)&nbsp;
  ![STAGE](https://img.shields.io/badge/ALPHA/BETA-yellow)&nbsp; <!-- Alpha = Red, Beta = Yellow, Stable = Green -->
  ![LICENSE](https://img.shields.io/badge/license-apache-blue)&nbsp;
  ![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)&nbsp;

</div>

<!--
This divider separates this section from the rest of the README. This should
not be modified.
--->
---

<!-- ======================================================= [PROJECT INTRO] -->

<!-- [PROJECT DETAIL] ==========================================================
* Project screenshot
  There are references for both a "light" and "dark" images. The dark image
  should have a background of HEX #0d1117, to match the dark mode of GitHub.
  The light image is the fallback.
---------------------------------------------------------------------------- -->

<div align="center">

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset=".github/repository/readme/Transmorger-MainWindowScreenshot.png">
    <source media="(prefers-color-scheme: light)" srcset=".github/repository/readme/Transmorger-MainWindowScreenshot.png">
    <img alt="Fallback image description" src=".github/repository/readme/Transmorger-MainWindowScreenshot.png">
  </picture>
  <h6>The Tingen Transmorger main window</h6>

</div>

<!--
This divider separates the this section from the rest of the README. If you are
not using the this section, comment this divider out.
--->
---

<!-- [HORIZONTAL MENU] =========================================================
* Horizontal menu (top)
  Contains components that aren't in/don't belong in the table of contents.
---------------------------------------------------------------------------- -->

<h6 align="center">

  [MANUAL](docs/man/README.md)&nbsp;&bull;&nbsp;[CHANGELOG](docs/CHANGELOG.md)&nbsp;&bull;&nbsp;[ROADMAP](docs/ROADMAP.md)&nbsp;&bull;&nbsp;[KNOWN ISSUES](docs/KNOWN-ISSUES.md)
  
</h6>

<!--
This divider separates the this section from the rest of the README. If you are
not using the this section, comment this divider out.
--->
---

<!-- ===================================================== [HORIZONTAL MENU] -->

<!-- [TABLE OF CONTENTS] =======================================================
* The Table of Contents
  The [TOC] contains components that aren't in/don't belong in the horizontal menu.
---------------------------------------------------------------------------- -->

### CONTENTS

* [About Tingen Transmorger](#about-tingen-transmorger)<br>
* [How It Works](#how-it-works)<br>
* [Getting Started](#getting-started)<br>
* [Installing](#installing)<br>
* [Usage](#usage)<br>
* [Acknowledgements](#acknowledgements)<br>
* [License](#license)<br>

<!--
This divider separates the this section from the rest of the README. If you are
not using the this section, comment this divider out.
--->
---

<!-- =================================================== [TABLE OF CONTENTS] -->

<!-- [PROJECT MESSAGE] =========================================================
* Project message
  Use for time-sensitive notices, deprecation warnings, or anything critical
  that every visitor should see. Remove this section if not needed.
============================================================================ -->
<!-- Not used
> [!IMPORTANT]
> Replace this with a message everyone should see, or remove this section entirely.
-->
<!--
This divider separates the this section from the rest of the README. If you are
not using the this section, comment this divider out.
--->
---

<!-- ===================================================== [PROJECT MESSAGE] -->

<!-- [ABOUT] ===================================================================
* About %ProjectName%
  Describes the project in a few sentences
* Features
  List of project features
* What's new
  A summary of what's new in the latest release
* Built With
  List of technologies and/or frameworks used
---------------------------------------------------------------------------- -->

## About Tingen Transmorger

Troubleshooting [Netsmart's TeleHealth](https://www.ntst.com/carefabric/careguidance-solutions/telehealth) platform can be frustrating; data is spread across multiple reports which use inconsistent syntax, and are not end-user friendly.

**Tingen Transmorger** is a utility ***transmorgifies*** TeleHealth reports, and makes it easy to find the information you're looking for.

### Features

* Aggregate TeleHealth reports across a custom date range
* Find information like:
  * Patient alert details
  * Patient connection details
  * Meeting details
  * Meeting quality
* Copy information from Transmorger, and paste it into other aplications as plain text

<!-- =============================================================== [ABOUT] -->

<!-- [HOW IT WORKS] ============================================================
* How it works
  A high-level overview of how the project works.
============================================================================= -->

## How It Works

Here's the 50,000-foot view of how Tingen Transmorger works:

* TeleHealth reports are (manually) run from the TeleHealth portal
* The completed reports are downloaded
* Transmorger takes all of the downloaded reports and ***transmorgifies*** them into a single, custom database
* That custom database is saved in a location that end-users have access to
* Transmorger automatically downloads/updates the database for end-users
* End-users can use Transmorger to troubleshoot TeleHealth issues

### The Transmorger Database

The heart of Transmorger is its Database, which aggregates multiple TeleHealth reports into a single, well organized collection of data that:

* Contains information from date ranges *you* choose
* Can be added to *on-the-fly*, with dates/date ranges *you* choose
* Is updated for end-users *automatically*, ensuring users have the latest available details to work with

<!-- ========================================================= [HOW IT WORKS] -->

<!-- [INSTALLING] =========================================================
* Installing
  Step-by-step instructions for installing the project on supported platforms.
  Remove OS sections that are not supported.

  In general, this should be a quick overview of the installation process,
  with a link to docs/man/README.md.
============================================================================ -->

## Installing

For detailed installation instructions, see the [Manual](docs/man/README.md#installation).

<!-- ========================================================== [INSTALLING] -->

<!-- [USAGE] ===================================================================
* Usage
  Step-by-step instructions for using the project on supported platforms.
  Remove OS sections that are not supported.

  In general, this should be a quick overview of the installation process,
  with a link to docs/man/README.md.
============================================================================ -->

## Usage

For detailed usage instructions, see the [Manual](docs/man/README.md#usage).

<!-- =============================================================== [USAGE] -->

### Related projects

* [Tingen Nyqvist](https://github.com/spectrum-health-systems/Tingen-Nyqvist)  
  Nyqvist is used to test SQL queries against different Avatar Systems.

  > [!IMPORTANT]  
> Since Tingen Nyqvist only works with Spectrum Health Systems AvatarNX Systems, it is a private repository. If you would like access to the Tingen Nyqvist repository, please contact us.

* [Tingen Web Service](https://github.com/spectrum-health-systems/Tingen-WebService)  
The Tingen Web Service is a custom web service which includes various tools and utilities for Netsmart's [Avatar™ EHR](https://www.ntst.com/Solutions-and-Services/Offerings/myAvatar™) EHR that aren't included in the official release, and provides a solid foundation for building additional functionality quickly and efficiently.

## License

Distributed under the [Apache 2.0 License](LICENSE).  
Copyright &copy; 2026 %Owner%

---

<!-- [HORIZONTAL MENU] =========================================================
* Horizontal menu (bottom)
  Contains components that aren't in/don't belong in the table of contents.
---------------------------------------------------------------------------- -->

<h6 align="center">

  [FAQ](docs/FAQ.md)&nbsp;&bull;&nbsp;[DEVELOPMENT](docs/DEVELOPMENT.md)&nbsp;&bull;&nbsp;[API](docs/api/README.md)&nbsp;&bull;&nbsp;[TESTING](docs/TESTING.md)&nbsp;&bull;&nbsp;[SUPPORT](docs/SUPPORT.md)&nbsp;&bull;&nbsp;[NOTICES](docs/NOTICES.md)
  
</h6>

<!-- ===================================================== [HORIZONTAL MENU] -->

---

<sub>Last updated: 260417</sub>
