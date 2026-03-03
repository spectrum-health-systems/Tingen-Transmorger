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

And most of the information in Tingen Transmorger can easily be copy/pasted into other documentation/emails/tickets.

## The Transmorger database

The heart of Tingen Transmorger is the Transmorger Database, which combines multiple TeleHealth reports into a single, well organized collection of data.

The Transmorger database:

- Contains data from date ranges *you* choose
- That data can be added to the database *on-the-fly*
- The end-user database is updated *automatically*, ensuring users have the latest available data
- Data can be copied out of Transmorger, and pasted into tickets, emails, etc.

## Getting Started

Check out the the Tingen Transmorger [Manual](./docs/man/README.md)!

## Development

Tingen Transmorger is being actively developed. The current development branch is [here](https://github.com/spectrum-health-systems/TingenTransmorger/tree/development).

You can also take a look at the [roadmap](ROADMAP.md), [known issues](KNOWN-ISSUES.md), and [changelog](CHANGELOG.md)
