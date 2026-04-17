<!--
  Tingen Transmorger manual
  260417_code
  260417_documentation
-->

<!-- [WARNING] =========================================================
* Warning
---------------------------------------------------------------------------- -->

> [!WARNING]
> This documentation is a work-in-progress.

<!--
This divider separates the this section from the rest of the README. If you are
not using the this section, comment this divider out.
--->
---

<!-- ============================================================= [WARNING] -->

<!-- [INTRO] ===================================================================
* Project logo
  There are references for both a "light" and "dark" images. The dark image
  should have a background of HEX #0d1117, to match the dark mode of GitHub.
  The light image is the fallback.
* Page title
* Project/manual version badge
---------------------------------------------------------------------------- -->

<div align="center">

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="../../.github/repository/logo/TransmorgerLogo-256x256.png">
    <source media="(prefers-color-scheme: light)" srcset="../../.github/repository/logo/TransmorgerLogo-256x256.png">
    <img alt="Fallback image description" src="../../.github/repository/logo/TransmorgerLogo-256x256.png">
  </picture>

  <h1>Tingen Transmorger Manual</h1>

  ![RELEASE](https://img.shields.io/badge/Version-0.9.31.0-teal)&nbsp;

</div>

---

<!-- [TABLE OF CONTENTS] =======================================================
* The Table of Contents
  The Table of Contents.
---------------------------------------------------------------------------- -->

### CONTENTS

* [About %ProjectName%](#about)<br>
    * [Features](#features)<br>
* [How It Works](#how-it-works)<br>
  * [The Transmorger Database](#the-transmorger-database)<br>
* [Getting Started](#getting-started)<br>
  * [Requirements](#requirements)<br>
* [Installing](#installing)<br>
  * [Windows](#windows)
* [Setup](#setup)<br>
  * [Creating the LocalDb path](#creating-the-localdb-path)<br>
  * [The MasterDb path warning](#the-masterdb-path-warning)<br>
  


* [Usage](#usage)<br>
* [Acknowledgements](#acknowledgements)<br>
* [Related Projects](#related-projects)<br>
* [License](#license)<br>

---

<!-- =================================================== [TABLE OF CONTENTS] -->

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

## Getting Started

Tingen Transmorger is a stand-alone, portable, and (in theory) cross-platform application.

Installation is as simple as downloading the latest release and executing it.

Configuration is done via an external JSON file.

To uninstall, simply delete the executable and the `AppData/*` directory.

### Requirements

| Requirement | Minimum version | Notes |
|-------------|-----------------|-------|
| [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) | 10.0 | Required to build and run. |
| 64bit Microsoft Windows OS | | |
| Access to Netsmart TeleHealth reports | | |

## Installing

> [!NOTE]
> Transmorger is currently only available for Windows.

### Windows

To install Transmorger:

1. Download the latest [release](https://github.com/spectrum-health-systems/TingenTransmorger/releases)
2. Extract the `TingenTransmorger.exe` file to a location of your choice

> [!WARNING]
> Verify the SHA256 hash!  
> ```text
> Name: TingenTransmorger-0.9.31.0.7z
> Size: 39.6 MB (41,531,038 bytes)
> SHA256: 80ef3ef83669daa9e2884c092afbe024761502d92ef9303772394e29b09bb5c3 
> ```

## Setup

When you double-click on the `TingenTransmorger.exe` file, and launch it for the first time, it does a few setup-type things, including:

* Creating the `./AppData/` folder
* Creating the `./AppData/Config/` folder
* Creating the `./AppData/Config/transmorger.config` file
* Prompt the user to create the `LocalDb` path
* Warn the user about the `MasterDb` path


## Creating the LocalDb path

The when you launch Transmorger for the first time, you should see this popup:

<div align="center">

![](./Images/TransmorgerManual-LocalDbPathDoesNotExistCreatePrompt.png)

</div>

The ***LocalDb path*** is where the *local copy* of the Transmorger database will stored.

When you click **Yes**, Transmorger will create an empty folder named `./AppData/Database/`. This is the default (and recommended) location for the LocalDb, but you can change the path to any location via the configuration file.

Click **Yes**.

> [!WARNING]
> Clicking **No** will exit Transmorger.  
> Subsequent launches will ask the same question, until you click **Yes**, so this step is required.

## The MasterDb path warning

After creating the LocalDb path, you should get the following popup:

<div align="center">

![](./Images/TransmorgerManual-MasterDbPathIsUndefined.png)

</div>

The **MasterDb** is the most up-to-date version of the Transmorger database...but it doesn't actually exist yet. In fact, it doesn't even have a *location* to exist in!

We'll fix that next, so for now just click **OK**, and Transmorger will exit.





