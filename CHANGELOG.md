# Tingen Transmorger: Changelog

## 0.9.24.0 - 2/11/2026

`ADDED` Functionality to copy Meeting Details (General)  
`ADDED` Functionality to copy Meeting Details (Patient)  
`REMOVED` DiagnosticWindow  
`REMOVED` EmailSummaryWindow  

## 0.9.23.0 - 2/11/2026

`MODIFIED` Migrated the EmailSummaryWindow functionality into MessageHistoryWindow  

## 0.9.22.0 - 2/11/2026

`ADDED` Functionality to copy the following message histories to the clipboard:  
  - All message history  
  - The top 10 rows of message history  
  - All successes  
  - All errors  
`ADDED` TingenTransmorger.Help.HelpWindow  
`MODIFIED` TingenTransmorger.Database.MessageHistoryWindow  
    - Renamed TingenTransmorger.Database.MessageSummaryWindow -> TingenTransmorger.Database.MessageHistoryWindow  
    - Minor changes to user interface  


## 0.9.21.0 - 2/11/2026

`ADDED` ProjectInfo.cs  
`FIXED` The "opted-out" message properly displays  

## 0.9.20.0 - 2/10/2026

`FIXED` Fixed an issue where a clean install without a local database would not download the master database.
