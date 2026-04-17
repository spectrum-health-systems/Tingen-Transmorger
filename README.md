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

### Features

* **Tingen Transmorger** is a utility ***transmorgifies*** TeleHealth reports, and makes it easy to find information like:
  * Patient alert details (deliver successes/failures, etc.)
  * Patient connection details (devices/operating systems used, etc.)
  * Meeting details (start/end time, when participants joined, participant list, etc.)
  * Meeting quality (bandwidth, audio/video quality, etc.)
* Information can easily be copied from Transmorger, and pasted into other documentation, emails, and tickets.
* The Transmorger database, which aggregates multiple TeleHealth reports into a single, well organized collection of data:
  * Contains information from date ranges *you* choose
  * Can be added to *on-the-fly*, with dates/date ranges *you* choose
  * Is updated for end-users *automatically*, ensuring users have the latest available details to work with

### What's New

#### Version/Release X.Y.Z

* New feature — What it does and why it matters.
* Improvement — What was improved and why it matters.
* Bug fix — What was fixed and why it matters.

For more details, see the [CHANGELOG](docs/CHANGELOG.md).

### Built With

* [Technology or framework](URL)  - Role it plays in the project.
* [Technology or framework](URL)  - Role it plays in the project.
* [Technology or framework](URL)  - Role it plays in the project.

<!-- =============================================================== [ABOUT] -->

<!-- [HOW IT WORKS] ============================================================
* How it works
  A high-level overview of how the project works.
============================================================================= -->

## How It Works

A blurb describing how the project works at a high level.

<!-- ========================================================= [HOW IT WORKS] -->


<!-- [GETTING STARTED] =========================================================
* Before you begin
  Any prerequisites, assumptions, or other information a user should know before
  getting started.
* Prerequisites
  List of software, hardware, or other requirements.
* Documentation
  Information about where to find documentation.
============================================================================ -->

## Getting Started

### Before you begin

Things a user should know or do before starting.

### Prerequisites

| Requirement | Minimum version | Notes |
|-------------|-----------------|-------|
| [.NET SDK](https://dotnet.microsoft.com/download) | 10.0 | Required to build and run. |
| Requirement two | X.x | Notes. |
| Requirement three | X.x | Notes. |

<!-- [INSTALLING] =========================================================
* Installing
  Step-by-step instructions for installing the project on supported platforms.
  Remove OS sections that are not supported.
============================================================================ -->

## Installing

Quick summary of installation instructions, or link to the Installing documentation.

<!-- ========================================================== [INSTALLING] -->

<!-- [USAGE] ===================================================================
* Usage
  Step-by-step instructions for using the project on supported platforms.
  Remove OS sections that are not supported.
============================================================================ -->

## Usage

Step-by-step instructions for using the project on supported platforms.

<!-- =============================================================== [USAGE] -->

### Documentation

Documentation is available.

<!-- ===================================================== [GETTING STARTED] -->

## Acknowledgements

None.
### Additional reading

None.

### Related projects

None.

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
