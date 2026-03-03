<div align="center">

  ![Logo](.github/Logo/TransmorgerLogo-256x256.png)

  ![Release](https://img.shields.io/badge/version-0.9.28.0-teal)&nbsp;&nbsp;
  ![License](https://img.shields.io/badge/license-apache-blue)

  <h1>Tingen Transmorger</h1>

</div>

Troubleshooting [Netsmart's TeleHealth](https://www.ntst.com/carefabric/careguidance-solutions/telehealth) platform can be frustrating; data is spread across multiple reports which use inconsistent syntax, and is not end-user friendly.

Tingen Transmorger is a utility that *aggregates* those reports, ***transmorgifies*** the data, and makes it easy to find information like:

- Patient alert details (deliver successes/failures, etc.)
- Patient connection details (devices/operating systems used, etc.)
- Meeting details (start time, participants, etc.)
- Meeting quality (bandwidth, audio/video quality, etc.)

## The Transmorger database

The heart of Tingen Transmorger is the Transmorger Database, which combines multiple TeleHealth reports into a single, well organized collection of data.

The Transmorger database also:

- Contains data from date ranges *you* choose
- Data can be added to the database *on-the-fly*
- The end-user database is updated *automatically*, ensuring users have the latest available data
- Specific data can be copied out of Transmorger, and pasted into tickets, emails, etc.

## How it works

> [!NOTE]
> Please see the Tingen Transmorger [Manual]() for detailed information.

The 50,000-foot view of how Tingen Transmorger works is:

1. TeleHealth reports are (manually) run from the TeleHealth portal
2. The completed reports are downloaded
3. Transmorger takes all of the downloaded reports and ***transmorgifies*** them into a single, custom database
4. That custom database is saved in a location that end-users have access to
5. End-users can use Transmorger to troubleshoot TeleHealth issues.

## Getting Started

Read the Tingen Transmorger [Manual](./docs/man/README.md)!

## Development

Tingen Transmorger is being actively developed. The current development branch is [here](https://github.com/spectrum-health-systems/TingenTransmorger/tree/development).

You can also take a look at the [roadmap](ROADMAP.md), [known issues](KNOWN-ISSUES.md), and [changelog](CHANGELOG.md)
