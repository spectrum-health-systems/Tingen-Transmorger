# Tingen Muno: Development Notes

- [ ] Break up TransmorgerDatabase.cs
- [ ] Clean up Database classes
- [ ] Details for email messages
- [ ] Details for all messages
- [ ] Make sure controls clear when they are supposed to
- [ ] Smaller final database
- [ ] SHFB
- [ ] Ignore null ids (provider "no id", e.g., Lori D.)
- [ ] Show data base statistics/summaries
- [ ] After rebuild, non-existant database causes error
- [ ] Version on title bar
- [ ] Do the MeetingBreakdownComponents need to have text when launching?
- [ ] What controls have text when launching that don't need text?

- [ ] Review dgPatientProviderMeetings to make sure the comments work for both patients and providers


- [X] Details for phone messages
- [X] Add "-" to phone numbers
- [X] Remove leading "+1" on phone numbers
- [X] Change version to vx.x.x.x
- [X] Building the database when it exists in the master directory = error.
- [X] Getting latest master DB
- [X] Collapse window components correctly
- [X] Show building process
- [X] Check for database updates at startup




- Is verification working? if no import in config, crash

Method signatures
Make sure all paths use Path.Combine
Trim().ToLower() everything
Do something to shrink database size
Database contains a list of files used to build that version
Public/internal/private, static
Verify files are ONE_TWO-THREE_FOUR
Open excel files for detailed research



<a target="_blank" href="https://icons8.com/icon/43011/copy">Copy</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>



<!-- Left column: Meeting ID, Title, Status, Joins, Duration, Service code -->
<StackPanel x:Name="spnlMeetingDetailsGeneralLeftComponents"
    Grid.Column="0"
    Margin="0,0,10,0">

    <!-- Meeting ID -->
    <StackPanel x:Name="spnlMeetingId"
        Margin="0,2"
        Orientation="Horizontal">

        <!-- Meeting ID label -->
        <TextBlock x:Name="txbkMeetingIdKey"
            Width="80"
            FontSize="11"
            FontWeight="SemiBold"
            Text="Meeting ID:" />



                                                                                            <!-- Left column: Meeting ID, Title, Status, Joins, Duration, Service code -->
                                        <StackPanel x:Name="spnlMeetingDetailsGeneralLeftComponents"
                                            Grid.Column="0"
                                            Margin="0,0,10,0">