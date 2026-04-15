<!-- 260415 -->

<!--
  This section contains the project logo and various details.

  There are references for both a "light" and "dark" images. The dark image
  should have a background of HEX #0d1117, to match the dark mode of GitHub.
  The light image is the fallback.
-->

<div align="center">

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset=".github/repository/logo/TransmorgerLogo-256x256.png">
    <source media="(prefers-color-scheme: light)" srcset=".github/repository/logo/TransmorgerLogo-256x256.png">
    <img alt="Fallback image description" src=".github/repository/logo/TransmorgerLogo-256x256.png">
  </picture>

  ![VERSION-01](https://img.shields.io/badge/Version-0.9.31.0-teal)&nbsp;&nbsp;![STAGE](https://img.shields.io/badge/BETA-yellow)&nbsp;&nbsp;![LICENSE](https://img.shields.io/badge/license-apache-blue)<br>
  [![OPERATING-SYSTEM](https://custom-icon-badges.demolab.com/badge/Windows-0078D6?logo=windows11&logoColor=white)](#)&nbsp;&nbsp;[![DOTNET](https://img.shields.io/badge/.NET-10-512BD4?)](#)&nbsp;&nbsp;[![CSHARP](https://custom-icon-badges.demolab.com/badge/C%23-%23239120.svg?logo=cshrp&logoColor=white)](#)

</div>

***

<!--
  Optional screenshot
-->

<div align="center">

  ![](.github/repository/readme/Transmorger-MainWindowScreenshot.png)
  <h6>The Tingen Transmorger main window</h6>

</div>

<!--
  Optional menu.

  These are things that aren't/don't belong in the Table of Contents.

  Use whichever components you want/need. 
-->

<h6 align="center">

[Changelog](docs/CHANGELOG.md)&nbsp;&bull;&nbsp;[Roadmap](docs/ROADMAP.md)&nbsp;&bull;&nbsp;[Known issues](docs/KNOWN-ISSUES.md)

</h6>

<!-- 
  Table of contents.

  These are things that aren't/don't belong in the Menu.
  
  The HTML indentations have to stay this way to work.
-->

<table>
<tr>
<td img src=".github/repository/readme/spacer.png" alt="blank-spacer" width="1000" height="1">

  #### CONTENTS
  [About Tingen Transmorger](#about-tingen-transmorger)<br>
    [The Transmorger Database](#the-transmorger-database)<br>
    [Requirements](#requirements)<br>
  [Getting Started](#getting-started)<br>
  [Development](#development)<br>
  [Additional Information](#additional-information)<br>

</td>
</tr>
</table>

# About Tingen Transmorger

Troubleshooting [Netsmart's TeleHealth](https://www.ntst.com/carefabric/careguidance-solutions/telehealth) platform can be frustrating; data is spread across multiple reports which use inconsistent syntax, and are not end-user friendly.

**Tingen Transmorger** is a utility ***transmorgifies*** those reports, and makes it easy to find information like:

- Patient alert details (deliver successes/failures, etc.)
- Patient connection details (devices/operating systems used, etc.)
- Meeting details (start/end time, when participants joined, participant list, etc.)
- Meeting quality (bandwidth, audio/video quality, etc.)

And most of the information in Transmorger can easily be copy/pasted into other documentation, emails, and tickets.

## The Transmorger Database

The heart of Transmorger is its Database, which aggregates multiple TeleHealth reports into a single, well organized collection of data that:

- Contains information from date ranges *you* choose
- Can be added to *on-the-fly*, with dates/date ranges *you* choose
- Is updated for end-users *automatically*, ensuring users have the latest available details to work with

## Requirements

- [.NET 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- 64bit Operating System (only tested on Windows)
- Access to Netsmart TeleHealth reports

## Getting Started

Please see the [Tingen Transmorger manual](https://github.com/spectrum-health-systems/TingenTransmorger/blob/main/docs/man/README.md).

# Development

Tingen Transmorger is being [actively developed](https://github.com/spectrum-health-systems/TingenTransmorger/tree/development).

# Additional Information

- [Project homepage](https://github.com/spectrum-health-systems/Tingen-Transmorger)


- [Testing](docs/TESTING.md)
- [Built with](docs/BUILT-WITH.md)
- [Contributors](docs/CONTRIBUTORS.md)
- [Acknowledgements](docs/ACKNOWLEDGEMENTS.md)
- [Notices](src/Resources/Doc/third-party-notices.md)
- [Related projects](src/Resources/Doc/related-projects.md)
- [Additional reading](src/Resources/Doc/additional-reading.md)

- [Code of conduct](https://github.com/APrettyCoolProgram/.github/blob/main/.github/CODE_OF_CONDUCT.md)
- [Contributing guidelines](https://github.com/APrettyCoolProgram/.github/blob/main/.github/CONTRIBUTING.md)
- [Security](https://github.com/APrettyCoolProgram/.github/blob/main/.github/SECURITY.md)
- [Support](https://github.com/APrettyCoolProgram/.github/blob/main/.github/SUPPORT.md)


***

<!-- DEVELOPMENT FOOTER -->
[![GitHub release date](https://img.shields.io/github/release-date/github-account/repository-name?style=flat-square)](https://github.com/github-account/repository-name/releases)&nbsp;![Release downloads](https://img.shields.io/github/downloads/github-account/repository-name/total?style=flat-square)&nbsp;![Language count](https://img.shields.io/github/languages/count/github-account/repository-name?style=flat-square)&nbsp;
![Top language](https://img.shields.io/github/languages/top/github-account/repository-name?style=flat-square)&nbsp;
![Repository size](https://img.shields.io/github/repo-size/github-account/repository-name?style=flat-square)&nbsp;
![Lines of code](https://img.shields.io/tokei/lines/github/github-account/repository-name?style=flat-square)
[![Developed by](https://img.shields.io/badge/developed%20by-a%20pretty%20cool%20program-17806D?style=flat-square)](https://aprettycoolprogram.com)&nbsp;
[![Feedback](https://img.shields.io/badge/feedback@aprettycoolprogram.com-17806D?style=flat-square)](mailto:feedback@aprettycoolprogram.com)&nbsp;
[![GitHub](https://img.shields.io/github/followers/aprettycoolprogram.svg?label=GitHub&style=social)](https://github.com/aprettycoolprogram)&nbsp;
[![Twitter](https://img.shields.io/twitter/follow/aprettycoolprog.svg?label=Twitter&style=social)](https://twitter.com/aprettycoolprog)&nbsp;
[![Repository built using](https://img.shields.io/badge/README%20built%20using-a%20pretty%20cool%20README%20template-17806D.svg)](https://github.com/APrettyCoolProgram/my-development-environment/tree/development/templates/github)