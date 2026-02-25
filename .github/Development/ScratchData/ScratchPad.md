

private void btnSearchToggle_Click(object? sender, RoutedEventArgs e) => SearchToggleClicked();
private void txbxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => SearchTextChanged();
private void rbtnSearch_Checked(object sender, RoutedEventArgs e) => SearchTextChanged();
private void lstbxSearchResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => SearchResultSelected();
private void dgPatientMeetings_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) => MeetingSelected();
private void btnPhoneDetails_Click(object sender, RoutedEventArgs e) => PhoneDetailsClicked();
private void btnEmailDetails_Click(object sender, RoutedEventArgs e) => EmailDetailsClicked();
private void btnCopyMeetingDetailsGeneral_Click(object sender, RoutedEventArgs e) => CopyMeetingDetailsGeneralClicked();
private void btnCopyMeetingDetailsPatient_Click(object sender, RoutedEventArgs e) => CopyMeetingDetailsPatientClicked();
private void btnCopyMeetingDetailsProvider_Click(object sender, RoutedEventArgs e) => CopyMeetingDetailsProviderClicked();
   



    A few things of note:
    
    

    * The btnSearchToggle control toggles between patient and provider search modes.
    
    * When in patient search mode:
    - The brdrMeetingDetailsPatient control is visible
    - The spnlPatientPhoneAndEmail control is visible
    - The brdrMeetingDetailsProvider control is hidden
    
    * When in provider search mode:
    - The spnlPatientPhoneAndEmail control is hidden
    - The brdrMeetingDetailsProvider control is visible
    - The brdrMeetingDetailsPatient control is hidden
    
    * If there are any errors with a meeting, the Meeting ID cell for that meeting will be highlighted in LightSalmon.
    
    * If a patient has a phone number and/or email address, the user can click the btnPhoneDetails or btnPhoneDetails
    buttons the to view more details about those pieces of information. These buttons will be different colors,
    depending on the following:
    - If the details are all success messages, the buttons will have a green background
    - If the details are all failure messages, the buttons will have a red background
    - If the details are a mix of success and failure messages, the buttons will have an orange background
    - If the patient has a phone number/email address, but there are no details to show, the buttons will have a gray background
    - If the patient does not have a phone number/email address, the buttons will have a black background
    
    - There are various "copy" buttons that copy different pieces of information to the clipboard.



                         <!--
      General meeting detail border
      This visible for both patient and provider search modes.
  -->
  <Border x:Name="brdrGeneralMeetingDetail"
      Margin="0,0,20,0"
      BorderBrush="Black"
      BorderThickness="1"
      CornerRadius="5">

      <!--
          General meeting detail panel
      -->
      <StackPanel x:Name="spnlGeneralMeetingDetail"
          Margin="5,5,0,0">

          <!--
              General meeting detail top panel
              Contains the header and copy button for the general meeting details section.
          -->
          <StackPanel x:Name="spnlGeneralMeetingDetailTop"
              Margin="0,0,0,4"
              Orientation="Horizontal">

              <!-- General meeting detail header -->
              <TextBlock x:Name="txbkGeneralMeetingDetailHeader"
                  Margin="0,5,0,0"
                  FontSize="12"
                  FontWeight="SemiBold"
                  Text="Meeting Details" />

              <!-- General meeting detail copy button -->
              <Button x:Name="btnCopyGeneralMeetingDetail"
                  Width="24"
                  Height="24"
                  Margin="10,0,0,0"
                  BorderThickness="0"
                  Click="btnCopyGeneralMeetingDetail_Click">
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

          <!--
              General meeting detail grid column definitions
              Left column: Meeting ID, Title, Status, Joins, Duration, Service code
              Center column: Started by, Scheduled start, Actual start, Ended by, Scheduled end, Actual end
              Right column: Workflow, Program, Front Desk Check-in, Meeting error
          -->
          <Grid x:Name="grdGeneralMeetingDetailColumnDefinitions"
              Margin="0,4,0,0">
              <Grid.ColumnDefinitions>
                  <!-- Left column definition -->
                  <ColumnDefinition x:Name="colGeneralMeetingDetailLeftColumnDefinition"
                      Width="*" />
                  <!-- Center column definition -->
                  <ColumnDefinition x:Name="colGeneralMeetingDetailCenterColumnDefinition"
                      Width="*" />
                  <!-- Right column definition -->
                  <ColumnDefinition x:Name="colGeneralMeetingDetailRightColumnDefinition"
                      Width="*" />
              </Grid.ColumnDefinitions>

              <!-- Left column panel -->
              <StackPanel x:Name="spnlGeneralMeetingDetailLeftColumn"
                  Grid.Column="0"
                  Margin="0,0,10,0">

                  <!-- Meeting ID panel -->
                  <StackPanel x:Name="spnlMeetingId"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Meeting ID label -->
                      <TextBlock x:Name="txbkMeetingIdKey"
                          Width="80"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Meeting ID:" />

                      <!-- Meeting ID value -->
                      <TextBlock x:Name="txbkMeetingIdValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Meeting title panel -->
                  <StackPanel x:Name="spnlMeetingTitle"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Meeting title label -->
                      <TextBlock x:Name="txbkMeetingTitleKey"
                          Width="80"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Title:" />

                      <!-- Meeting title value -->
                      <TextBlock x:Name="txbkMeetingTitleValue"
                          FontSize="11"
                          Text="---"
                          TextWrapping="Wrap" />
                  </StackPanel>

                  <!-- Meeting status panel -->
                  <StackPanel x:Name="spnlMeetingStatus"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Meeting status label -->
                      <TextBlock x:Name="txbkMeetingStatusKey"
                          Width="80"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Status:" />

                      <!-- Meeting status value -->
                      <TextBlock x:Name="txbkMeetingStatusValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Meeting joins panel -->
                  <StackPanel x:Name="spnlMeetingJoins"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Meeting joins label -->
                      <TextBlock x:Name="txbkMeetingJoinsKey"
                          Width="80"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Joins:" />

                      <!-- Meeting joins value -->
                      <TextBlock x:Name="txbkMeetingJoinsValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Meeting duration panel -->
                  <StackPanel x:Name="spnlMeetingDuration"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Meeting duration label -->
                      <TextBlock x:Name="txbkMeetingDurationKey"
                          Width="80"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Duration:" />

                      <!-- Meeting duration value -->
                      <TextBlock x:Name="txbkMeetingDurationValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Service code panel -->
                  <StackPanel x:Name="spnlMeetingServiceCode"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Service code label -->
                      <TextBlock x:Name="txbkMeetingServiceCodeKey"
                          Width="80"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Service code:" />

                      <!-- Service code value -->
                      <TextBlock x:Name="txbkMeetingServiceCodeValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>
              </StackPanel>

              <!-- Center column -->
              <StackPanel x:Name="spnlGeneralMeetingDetailCenterColumn"
                  Grid.Column="1"
                  Margin="0,0,10,0">

                  <!-- Started by panel -->
                  <StackPanel x:Name="spnlMeetingStartedBy"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Started by label -->
                      <TextBlock x:Name="txbkMeetingStartedByKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Started by:" />

                      <!-- Started by value -->
                      <TextBlock x:Name="txbkMeetingStartedByValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Scheduled start panel -->
                  <StackPanel x:Name="spnlMeetingScheduledStart"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Scheduled start label -->
                      <TextBlock x:Name="txbkMeetingScheduledStartKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Scheduled start:" />

                      <!-- Scheduled start value -->
                      <TextBlock x:Name="txbkMeetingScheduledStartValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Actual start panel -->
                  <StackPanel x:Name="spnlMeetingActualStart"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Actual start label -->
                      <TextBlock x:Name="txbkMeetingActualStartKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Actual start:" />

                      <!-- Actual start value -->
                      <TextBlock x:Name="txbkMeetingActualStartValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Ended by panel -->
                  <StackPanel x:Name="spnlMeetingEndedBy"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Ended by label -->
                      <TextBlock x:Name="txbkMeetingEndedByKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Ended by:" />

                      <!-- Ended by value -->
                      <TextBlock x:Name="txbkMeetingEndedByValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Scheduled end panel -->
                  <StackPanel x:Name="spnlMeetingScheduledEnd"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Scheduled end label -->
                      <TextBlock x:Name="txbkMeetingScheduledEndKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Scheduled end:" />

                      <!-- Scheduled end value -->
                      <TextBlock x:Name="txbkMeetingScheduledEndValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Actual end panel -->
                  <StackPanel
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Actual end label -->
                      <TextBlock x:Name="txbkMeetingActualEndKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Actual end:" />

                      <!-- Actual end value -->
                      <TextBlock x:Name="txbkMeetingActualEndValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>
              </StackPanel>

              <!-- Right column -->
              <StackPanel x:Name="spnlGeneralMeetingDetailRightColumn"
                  Grid.Column="2">

                  <!-- Workflow panel -->
                  <StackPanel x:Name="spnlMeetingWorkflow"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Workflow label -->
                      <TextBlock x:Name="txbkMeetingWorkflowKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Workflow:" />

                      <!-- Workflow value -->
                      <TextBlock x:Name="txbkMeetingWorkflowValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Program panel -->
                  <StackPanel x:Name="spnlMeetingProgram"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Program label -->
                      <TextBlock x:Name="txbkMeetingProgramKey"
                          Width="90"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Program:" />

                      <!-- Program value -->
                      <TextBlock x:Name="txbkMeetingProgram"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Front Desk Check-in panel -->
                  <StackPanel x:Name="spnlMeetingFrontDeskCheckIn"
                      Margin="0,2"
                      Orientation="Horizontal">

                      <!-- Front Desk Check-In label -->
                      <TextBlock x:Name="txbkMeetingFrontDeskCheckInKey"
                          Width="116"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Front Desk Check-In:" />

                      <!-- Front Desk Check-In value -->
                      <TextBlock x:Name="txbkMeetingCheckedInByFrontDeskValue"
                          FontSize="11"
                          Text="---" />
                  </StackPanel>

                  <!-- Meeting error panel -->
                  <StackPanel x:Name="spnlMeetingError"
                      Margin="0,2"
                      Orientation="Vertical">

                      <!-- Meeting error label -->
                      <TextBlock x:Name="txbkMeetingErrorKey"
                          FontSize="11"
                          FontWeight="SemiBold"
                          Text="Meeting error:" />

                      <!-- Meeting error value -->
                      <TextBlock x:Name="txbkMeetingErrorValue"
                          Margin="0,2,0,0"
                          FontSize="11"
                          Text="---"
                          TextWrapping="Wrap" />
                  </StackPanel>
              </StackPanel>
          </Grid>
      </StackPanel>
  </Border>

  <!--