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



<!-- Meeting Details (Patient) -->
<!--
    This visible only in patient search mode.
-->
<Border x:Name="brdrMeetingDetailsPatientContainer"
    Margin="0,10,20,0"
    BorderBrush="Black"
    BorderThickness="1"
    CornerRadius="5">

    <!-- Contains the patient-specific meeting details components -->
    <StackPanel x:Name="spnlMeetingDetailsPatientComponent"
        Margin="8">

        <!-- StackPanel containing the header and copy button -->
        <StackPanel x:Name="spnlMeetingDetailsPatientTop"
            Margin="0,0,0,4"
            Orientation="Horizontal">

            <!-- Header -->
            <TextBlock x:Name="txbkMeetingDetailsPatientHeader"
                Margin="0,5,0,0"
                FontSize="12"
                FontWeight="SemiBold"
                Text="Meeting Details (Patient)" />

            <!-- Copy button -->
            <Button x:Name="btnCopyMeetingDetailsPatient"
                Width="24"
                Height="24"
                Margin="10,0,0,0"
                BorderThickness="0"
                Click="btnCopyMeetingDetailsPatient_Click">
                <Button.Resources>
                    <Style TargetType="Border">
                        <Setter Property="CornerRadius" Value="3" />
                    </Style>
                </Button.Resources>
                <Button.Background>
                    <ImageBrush ImageSource="/AppData/Image/Control/Button/Copy-40x40.png" />
                </Button.Background>
            </Button>
        </StackPanel>

        <!-- Definitions for the meeting details (patient) grid -->
        <Grid x:Name="grdMeetingDetailsPatientDefinitions"
            Margin="0,4,0,0">
            <Grid.ColumnDefinitions>
                <!-- Left column -->
                <ColumnDefinition x:Name="colMeetingDetailsPatientLeft"
                    Width="201*" />
                <ColumnDefinition Width="49*" />
                <!-- Center column -->
                <ColumnDefinition x:Name="colMeetingDetailsPatientCenter"
                    Width="250*" />
                <!-- Right column -->
                <ColumnDefinition x:Name="colMeetingDetailsPatientRight"
                    Width="250*" />
            </Grid.ColumnDefinitions>

            <!-- Left column: Patient arrived, Patient dropped, Duration, Rating -->
            <StackPanel x:Name="spnlMeetingDetailsPatientLeftComponents"
                Grid.Column="0"
                Grid.ColumnSpan="2"
                Margin="0,0,10,0">

                <!-- Patient Arrived -->
                <StackPanel x:Name="spnlPatientArrived"
                    Margin="0,2"
                    Orientation="Horizontal">

                    <!-- Patient Arrived key -->
                    <TextBlock x:Name="txbkPatientArrivedKey"
                        Width="90"
                        FontSize="11"
                        FontWeight="SemiBold"
                        Text="Patient arrived:" />

                    <!-- Patient Arrived value -->
                    <TextBlock x:Name="txbkPatientArrivedValue"
                        FontSize="11"