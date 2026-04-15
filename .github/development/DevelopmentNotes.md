<div align="center">

  <h1>Tingen Transmorger: Development Notes

</div>

#### CONTENTS

* [Notes](#notes)
* [Roadmap](#roadmap)
* [Known Issues](#known-issues)
* [Version History](#version-history)

***

# Notes

* There isn't a way to easily match providers to their email addresses, so we aren't going to do that for now. Eventually we should, and this is (probably) where that logic should go. For now I've put the code I was working on in .github/development/old-src/ProviderEmailLogic.md.


# Roadmap

* `ADDED` Button to the MessageHistoryWindow that copies the opt-in message to the clipboard.
*`REFACTORED` TransmorgerDatabase.cs
DIFIED` If a database is out of date, the background is now red
* `MODIFIED` If a database is out of date, a message is displayed in the title bar
* Leading "0"s breaks search by ID
* Minimize database
* Refactor ns:Database

***

# Known Issues

## Some providers have `null` or `{}` ID values

This is caused when a meeting * any meeting * has multiple entries in `Provider/Staff Names`, even if the provider has
meetings where they are the only entry in that field.

The good news is that all of a provider's meetings are displayed, regardless of how many entries are
in `Provider/Staff Names`.

### Workaround

The workaround is to search for providers by ID, and just ignore the `null` or `{}` ID value, if there is one. The data is still accurate.

### Fix

This is going to take some looking into, because looking at the original data in the Excel files, practitioners who have this issue are also doing some funky things with meetings, such as:

* Non-standard meeting titles (e.g., "Dennis" instead of "TELEHEALTH")
* Workflow is listed as "INSTANT" instead of "EHR"
* No service codes associated with the meeting

***

# Version History

## 0.9.32.0

> This release includes significant changes to the TingenTransmorger repository.

* `ADDED` XML Documentation to ns:Database classes

## 0.9.31.0

* `ADDED` Ability to copy the meeting list rows to the clipboard
* `ADDED` XML Documentation to ns:Database classes
* `FIXED` dgrdMeetingList control now sorts correctly
* `FIXED` dgMessages control now sorts correctly

## 0.9.30.0

* `ADDED` Database date range to title bar
* `UPDATED` XML documentation for all classes
* `FIXED` Transmorger no longer exits if a database update is declined
* `MODIFIED` Admin mode background color is now purple
* `MODIFIED` Admin mode is displayed in the title bar
* `REMOVED` Core.Blueprint.cs (not used)
* `REMOVED` Help.HelpWindow.cs (not used)

## 0.9.29.0

* The application version is now displayed in the title bar

## 0.9.28.0

* MainWindow.AdminMode.cs
  * Fixed admin mode background border color
  * Refactored
* MainWindow.DataCopy.cs (new)
  * Catalog information for copies to the clipboard
* MainWindow.MeetingDetails.cs
  * Fixed participant name display
  * Moved the '''ReplaceNulls''' helper function to ```ReplaceNullValues()```
  * Refactored
* MainWindow.PatientDetail.cs
  * Refactored
* MainWindow.ProviderDetail.cs
  * Refactored
* MainWindow.Search.cs (new)
  * Refactored
* MainWindow.UserDetail.cs (new)
  * Refactored
* MainWindow.UserInterface.cs
  * Refactored, the goal being more control over the UI
* MainWindow.xaml
  * Modified the background border, but this needs more work.
  * Fixed alignments
  * Verified all controls are named correctly
  * Commented all controls
* MainWindow.xaml.cs
  * Moved most stuff out to other partial classes
* Fixed the UI reset when changing search modes
* Cleaned up the copied details
* Removed provider email logic
* Removed System.Diagnostics.Debug statements
* Removed MainWindow.DisplayDetails.cs
* Removed MainWindow.Events.cs
* Code/comment cleanup

## 0.9.27.0

* MainWindow.xaml cleanup, first pass

## 0.9.26.0

* Removed Settings button
* Started to cleanup MainWindow.xaml
* Working on breaking the patient display logic up into more manageable pieces.
* Combined the patient and provider search methods into a single method
* Made significant changes to the following classes:
  * MainWindow.xaml.cs
  * MainWindow.AdminMode.cs
  * TransmorgerDatabase.cs
* MainWindow/
  * Moved MainWindow classes to MainWindow/
* MainWindow.UserInterface.cs
* Made significant changes to the following classes:
  * MainWindow.xaml.cs
  * MainWindow.AdminMode.cs
  * TransmorgerDatabase.cs
* The default configuration file now defines both the LocalDb and Tmp directories under /AppData
* MainWindow
  * Commented out some code that may not be needed
  * Created MainWindow.AdminMode.cs partial class for admin mode stuff
  * Minor refactoring/code/comment cleanup
* DatabaseRebuildWindow
  * Minor UI tweaks
* Unused/abandoned code

## 0.9.25.0

* Meeting Details (Provider) component
* Disabled the meeting search functionality for now

## 0.9.24.0

* Functionality to copy Meeting Details (General)
* Functionality to copy Meeting Details (Patient)
* DiagnosticWindow
* EmailSummaryWindow

## 0.9.23.0

* Migrated the EmailSummaryWindow functionality into MessageHistoryWindow

## 0.9.22.0

* Functionality to copy the following message histories to the clipboard:
  * All message history
  * The top 10 rows of message history
  * All successes
  * All errors
* TingenTransmorger.Help.HelpWindow
* TingenTransmorger.Database.MessageHistoryWindow
  * Renamed TingenTransmorger.Database.MessageSummaryWindow -> TingenTransmorger.Database.MessageHistoryWindow
  * Minor changes to user interface

## 0.9.21.0

* ProjectInfo.cs
* The "opted-out" message properly displays

## 0.9.20.0

* Fixed an issue where a clean install without a local database would not download the master database.

***

<br>

<sub>Last updated: 260415 </sub>
