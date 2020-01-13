Public Class uiBase

    Public Enum FormSaveResult
        Nochanges = 0
        SaveError = 1
        SaveSuccess = 2
    End Enum

    Private mDSN As String
    Private mChannel As String
    Private mCurrency As String
    Private mParameter As String
    Private mUserName As String
    Private mBrowser As Object = Nothing
    Private mDLLServer As String
    Private mSptServer As String

    Private mTempErrorMessage As String
    Private mTempWarningMessage As String
    Private mTempInfoMessage As String
    Public tbl_MstSetting As DataTable = clsDataset.CreateTblMstSetting()
    Private mDataFiller As clsDataFiller

    '--yg ditambah di buat transbrowserbaru
    Private mConfig As Data.DataSet
    '----------------
    Public START_DSN As String

    'Private mDBSERVER As String = clsConfig.DBSERVER
    'Private mDBNAME As String = clsConfig.DBNAME
    'Private mDBUSER As String = clsConfig.DBUSER
    'Private mDBPASSWORD As String = clsConfig.DBPASSWORD
    'Private mDSNTemp As String = "User ID={0}; Password={1}; Data Source=""{2}""; Initial Catalog={3}; Tag with column collation when possible=False; Use Procedure for Prepare=1; Auto Translate=True; Persist Security Info=True; Provider=""SQLOLEDB.1""; Use Encryption for Data=False; Packet Size=4096"
#Region "TAMBAHAN BUAT TRANSBROWSER BARU"
    '---------- TAMBAHAN BUAT TRANSBROWSER BARU 18 APRIL 2012--------------------
    Public Sub InitializeControl(ByVal UserName As String, ByVal Parameter As String, ByRef Browser As Object, ByVal Config As DataSet)

        Me.mUserName = UserName
        Me.mParameter = Parameter
        Me.mBrowser = Browser
        'Me.mDLLServer = DLLServer
        'Me.mSptServer = SptServer
        Me.mConfig = Config

        Call Me.ReadConfigDSN()
    End Sub

    Private Sub ReadConfigDSN()
        Using dbCon As New clsDatabaseConfig("FRM", Me.mConfig)
            Me.DSN = dbCon.DSN
        End Using

        Using dbCon As New clsDatabaseConfig("START", Me.mConfig)
            Me.START_DSN = dbCon.DSN
        End Using

        'Tambahan lagi
        Using address As New clsAddressConfig(Me.mConfig)
            Me.mDLLServer = address.DllAddress
            Me.mSptServer = address.SptAddress
        End Using
    End Sub


    Private Sub ReadConfigurasiDataset(ByVal path As String)
        'Dim ms As IO.MemoryStream
        'Dim enc As Byte() = My.Computer.FileSystem.ReadAllBytes(path)
        'Dim res As String

        'Using rj As New clsRijndael()
        '    res = rj.Decrypt(System.Text.Encoding.ASCII.GetString(enc))
        'End Using

        'ms = New IO.MemoryStream(System.Text.Encoding.ASCII.GetBytes(res))

        path = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & path
        Me.mConfig = New Data.DataSet
        Me.mConfig.ReadXml(path)
    End Sub
    '------------------------------------------------------------
#End Region


#Region " Property "

    Public Property DSN() As String
        Get
            Return mDSN
        End Get
        Set(ByVal value As String)
            mDSN = value
        End Set
    End Property

    Public ReadOnly Property globChannel() As String
        Get
            Return mChannel
        End Get
    End Property

    Public ReadOnly Property globCurrency() As String
        Get
            Return mCurrency
        End Get
    End Property

    Public ReadOnly Property Parameter() As String
        Get
            Return mParameter
        End Get
    End Property

    Public ReadOnly Property UserName() As String
        Get
            Return mUserName
        End Get
    End Property

    Public ReadOnly Property Browser() As Object
        Get
            Return mBrowser
        End Get
    End Property

    Public ReadOnly Property DLLServer() As String
        Get
            Return mDLLServer
        End Get
    End Property

    Public ReadOnly Property SptServer() As String
        Get
            Return mSptServer
        End Get
    End Property

    Public Property ErrorMessage() As String
        Get
            Return mTempErrorMessage
        End Get
        Set(ByVal value As String)
            MessageBox.Show(value, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Set
    End Property

    Public Property WarningMessage() As String
        Get
            Return mTempWarningMessage
        End Get
        Set(ByVal value As String)
            MessageBox.Show(value, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Set
    End Property

    Public Property InfoMessage() As String
        Get
            Return mTempInfoMessage
        End Get
        Set(ByVal value As String)
            MessageBox.Show(value, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Set
    End Property


#End Region

#Region " Overridable "

    Public Overridable Function btnNew_Click() As Boolean
    End Function

    Public Overridable Function btnSave_Click() As Boolean
    End Function

    Public Overridable Function btnPrint_Click() As Boolean
    End Function

    Public Overridable Function btnPrintPreview_Click() As Boolean
    End Function

    Public Overridable Function btnEdit_Click() As Boolean
    End Function

    Public Overridable Function btnDel_Click() As Boolean
    End Function

    Public Overridable Function btnLoad_Click() As Boolean
    End Function

    Public Overridable Function btnQuery_Click() As Boolean
    End Function

    Public Overridable Function btnRefresh_Click() As Boolean
    End Function

    Public Overridable Function btnReset_Click() As Boolean
    End Function

    Public Overridable Function btnFirst_Click() As Boolean
    End Function

    Public Overridable Function btnPrev_Click() As Boolean
    End Function

    Public Overridable Function btnNext_Click() As Boolean
    End Function

    Public Overridable Function btnLast_Click() As Boolean
    End Function

    Public Overridable Function btnHelpTopic_Click() As Boolean
    End Function

    Public Overridable Function btnShowStatus_Click() As Boolean
    End Function

    Public Overridable Function btnShowConsole_Click() As Boolean
    End Function

    Public Overridable Function btnReserved1_Click() As Boolean
    End Function

    Public Overridable Function btnReserved2_Click() As Boolean
    End Function

    Public Overridable Function btnReserved3_Click() As Boolean
    End Function

    Public Overridable Function btnReserved4_Click() As Boolean
    End Function

    Public Overridable Function btnReserved5_Click() As Boolean
    End Function

    Public Overridable Function btnReserved6_Click() As Boolean
    End Function

#End Region

#Region " ToolStripButton Event "

    Private Sub tbtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNew.Click
        Me.btnNew_Click()
    End Sub

    Private Sub tbtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnSave.Click
        Me.btnSave_Click()
    End Sub

    Private Sub tbtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrint.Click
        Me.btnPrint_Click()
    End Sub

    Private Sub tbtnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.Click
        Me.btnPrintPreview_Click()
    End Sub

    Private Sub tbtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnEdit.Click
        Me.btnEdit_Click()
    End Sub

    Private Sub tbtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnDel.Click
        Me.btnDel_Click()
    End Sub

    Private Sub tbtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLoad.Click
        Me.btnLoad_Click()
    End Sub

    Private Sub tbtnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnQuery.Click
        Me.btnQuery_Click()
    End Sub

    Private Sub tbtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnRefresh.Click
        Me.btnRefresh_Click()
    End Sub

    Private Sub tbtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnFirst.Click
        Me.btnFirst_Click()
    End Sub

    Private Sub tbtnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnPrev.Click
        Me.btnPrev_Click()
    End Sub

    Private Sub tbtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnNext.Click
        Me.btnNext_Click()
    End Sub

    Private Sub tbtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnLast.Click
        Me.btnLast_Click()
    End Sub

#End Region

#Region " Syncronisasi "
    Private Sub tbtnNew_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnNew.EnabledChanged
        Me._SyncronizeControlEnableState("New", tbtnNew.Enabled)
    End Sub

    Private Sub tbtnSave_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnSave.EnabledChanged
        Me._SyncronizeControlEnableState("Save", tbtnSave.Enabled)
    End Sub

    Private Sub tbtnPrint_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrint.EnabledChanged
        Me._SyncronizeControlEnableState("Print", tbtnPrint.Enabled)
    End Sub

    Private Sub tbtnPrintPreview_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnPrintPreview.EnabledChanged
        Me._SyncronizeControlEnableState("PrintPreview", tbtnPrintPreview.Enabled)
    End Sub

    Private Sub tbtnDel_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnDel.EnabledChanged
        Me._SyncronizeControlEnableState("Delete", tbtnDel.Enabled)
    End Sub

    Private Sub tbtnLoad_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnLoad.EnabledChanged
        Me._SyncronizeControlEnableState("LoadData", tbtnLoad.Enabled)
    End Sub

    Private Sub tbtnQuery_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbtnQuery.EnabledChanged
        Me._SyncronizeControlEnableState("Queri", tbtnQuery.Enabled)
    End Sub

    Public Sub SyncronizeControlEnableState()
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled("New", tbtnNew.Enabled)
                Me.Browser.MenuEnabled("Save", tbtnSave.Enabled)
                Me.Browser.MenuEnabled("Print", tbtnPrint.Enabled)
                Me.Browser.MenuEnabled("PrintPreview", tbtnPrintPreview.Enabled)
                Me.Browser.MenuEnabled("Delete", tbtnDel.Enabled)
                Me.Browser.MenuEnabled("LoadData", tbtnLoad.Enabled)
                Me.Browser.MenuEnabled("Queri", tbtnQuery.Enabled)

            End If
        End If
    End Sub

    Public Sub _SyncronizeControlEnableState(ByVal Name As String, ByVal state As Boolean)
        If Me.Browser IsNot Nothing Then
            If Me.Browser.Name IsNot Nothing Then
                Me.Browser.MenuEnabled(Name, state)
            End If
        End If
    End Sub


#End Region

#Region " DataGridView Column Handler "

    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewTextBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewTextBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewComboBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewComboBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Function CreateDataGridViewColumn(ByVal col As System.Windows.Forms.DataGridViewCheckBoxColumn, ByVal name As String, ByVal headertext As String, ByVal datapropertyname As String, Optional ByVal width As Integer = 100) As System.Windows.Forms.DataGridViewCheckBoxColumn
        col.Name = name
        col.HeaderText = headertext
        col.DataPropertyName = datapropertyname
        col.Width = width
        col.Visible = True
        col.ReadOnly = False
        Return col
    End Function

    Public Function CreateDataGridViewComboBinding(ByRef objDgv As System.Windows.Forms.DataGridView, ByVal columnname As String, ByVal datavalue As String, ByVal datamember As String, ByVal dt As Data.DataTable) As Boolean
        With CType(objDgv.Columns(columnname), System.Windows.Forms.DataGridViewComboBoxColumn)
            .ValueMember = datavalue
            .DisplayMember = datamember
            .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            .DisplayStyleForCurrentCellOnly = True
            .AutoComplete = True
            .DataSource = dt
        End With
        Return True
    End Function


#End Region

    Private Sub uiBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim DefaultDSN As String



        'If Me.DSN = "" Then
        '    DefaultDSN = String.Format(Me.mDSNTemp, Me.mDBUSER, Me.mDBPASSWORD, Me.mDBSERVER, Me.mDBNAME)
        '    Me.InitializeControl(DefaultDSN, "indah", "", "D:\INSOSYS\bin", "http://insosys_start.transtv.co.id/services/live", Nothing)
        '    'Me.InitializeControl(DefaultDSN, "collection", "", "D:\INSOSYS\bin", "http://workshop/services/TransBrowser/SptServer", Nothing)
        '    'Me.InitializeControl(DefaultDSN, "eva.kd", "", "D:\INSOSYS\bin", "http://insosys_start.transtv.co.id/services/live", Nothing)
        'End If

        clsUtil.SetLocalization()
        'DSN = clsUtil.GetDSN()

        'Me.mDataFiller = New clsDataFiller(Me.DSN)
        'Me.tbtnEdit.Visible = False

        ''Untuk Develop -------================================================================
        If Me.Browser Is Nothing And Application.ProductName <> "TransBrowser" Then
            ReadConfigurasiDataset("config.xml")
            Me.InitializeControl("lucky", "", Nothing, Me.mConfig)
        End If
        ''==========================================================================================


        Me.mDataFiller = New clsDataFiller(Me.DSN)
        Me.tbtnEdit.Visible = False

        If (Me.Browser IsNot Nothing And MyBase.Name = "MainControl") Or (Me.Browser Is Nothing And Application.ProductName <> "TransBrowser") Then
            Me.DataFill(Me.tbl_MstSetting, "ms_MstSetting_Select", "")
        End If

        Me.tbtnEdit.Visible = False
    End Sub

    'Public Function InitializeControl(ByVal DSN As String, ByVal UserName As String, ByVal Parameter As String, ByVal DLLServer As String, ByVal SptServer As String, ByRef Browser As Object)
    '    Me.mDSN = DSN
    '    Me.mUserName = UserName
    '    Me.mParameter = Parameter
    '    Me.mBrowser = Browser
    '    Me.mDLLServer = DLLServer
    '    Me.mSptServer = SptServer
    '    Return True
    'End Function

    Private Function GetDefaultDSN() As String
        Return " "
    End Function

    Public Function GetParameterCollection(ByVal ParameterString As String) As Collection
        Dim i As Integer
        Dim arrParameter() As String
        Dim tempParameterLine() As String
        Dim ParameterKey As String
        Dim ParameterValue As String
        Dim objParameters As Collection = New Collection

        'Parameter = "CHANNEL=NTV; CHANNEL_CANBE_CHANGED=0; CHANNEL_CANBE_BROWSED=0; POSTING_MODE=1; POSTING_AUTHORITY=0; UNPOSTING_AUTHORITY=1;"
        arrParameter = ParameterString.Split(";")
        If Trim(ParameterString) <> "" Then
            For i = 0 To arrParameter.Length - 1
                tempParameterLine = arrParameter(i).Split("=")
                If tempParameterLine.Length = 2 Then
                    ParameterKey = Trim(tempParameterLine(0))
                    ParameterValue = Trim(tempParameterLine(1))

                    If objParameters.Contains(ParameterKey) Then
                        objParameters.Remove(ParameterKey)
                    End If

                    objParameters.Add(ParameterValue, ParameterKey)

                End If
            Next
        End If

        Return objParameters

    End Function

    Public Function GetBolValueFromParameter(ByVal Col As Collection, ByVal key As String) As Boolean
        If Col.Contains(key) Then
            If Col(key) = "0" Or Col(key) = "1" Or Col(key) = "true" Or Col(key) = "false" Then
                If Col(key) = "0" Or Col(key) = "false" Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetIntValueFromParameter(ByVal Col As Collection, ByVal key As String) As Integer
        If Col.Contains(key) Then
            Return CType(Col(key), Integer)
        Else
            Return 0
        End If
    End Function

    Public Function GetValueFromParameter(ByVal Col As Collection, ByVal key As String) As String
        If Col.Contains(key) Then
            Return Col(key)
        Else
            Return ""
        End If
    End Function

    Public Overloads Function DataFill(ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        dt.Clear()
        Return Me.mDataFiller.DataFill(dt, procedure, criteria, channel_id)
    End Function

    Public Overloads Function DataFill(ByRef dt As DataTable, ByVal procedure As String, ByVal parameter1 As String, ByVal parameter2 As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        dt.Clear()
        Return Me.mDataFiller.DataFillParam(dt, procedure, parameter1, parameter2, criteria, channel_id)
    End Function

    Public Overloads Function DataFill(ByRef dbconn As OleDb.OleDbConnection, ByRef dbtrans As OleDb.OleDbTransaction, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        dt.Clear()
        Return Me.mDataFiller.DataFill(dbconn, dbtrans, dt, procedure, criteria, channel_id)
    End Function

    Public Function DataFillLimit(ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, ByVal limit As Integer, Optional ByVal channel_id As String = "") As Boolean
        dt.Clear()
        Return Me.mDataFiller.DataFillLimit(dt, procedure, criteria, limit, channel_id)
    End Function

    Public Function DataFillFromCache(ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String) As Boolean
        If Me.Browser IsNot Nothing Then
            If Me.Browser.IsDataTableCached(procedure, criteria) Then
                dt.Clear()
                dt = Me.Browser.GetCachedDataTable(procedure, criteria)
            Else
                dt.Clear()
                Return Me.mDataFiller.DataFill(dt, procedure, criteria)
            End If
        Else
            dt.Clear()
            Return Me.mDataFiller.DataFill(dt, procedure, criteria)
        End If
    End Function

    Public Function DataFillForCombo(ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return Me.mDataFiller.DataFillForCombo(valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function
    Public Function DataFillForComboDec(ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return Me.mDataFiller.DataFillForComboAngka(valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function


    Public Function ComboFill(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return Me.mDataFiller.ComboFill(combobox, valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function
    Public Function ComboFillDec(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable, ByVal procedure As String, ByVal criteria As String, Optional ByVal channel_id As String = "") As Boolean
        Return Me.mDataFiller.ComboFillDec(combobox, valuemember, displaymember, dt, procedure, criteria, channel_id)
    End Function
    Public Function ComboLink(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef datatable As DataTable, ByVal withOption As Boolean) As Boolean
        Return Me.mDataFiller.ComboLink(combobox, valuemember, displaymember, datatable, withOption)
    End Function

    Public Function ComboFillFromDataTable(ByRef combobox As ComboBox, ByVal valuemember As String, ByVal displaymember As String, ByRef dt As DataTable) As Boolean

        combobox.DataSource = dt
        combobox.ValueMember = valuemember
        combobox.DisplayMember = displaymember
    End Function
    Public Function FusCriteria(ByVal newcriteria As String, ByVal criteria As String) As String
        Dim str As String = ""

        If criteria = "" Then
            str = " (" & newcriteria & ") "
        Else
            str = criteria & " AND " & " (" & newcriteria & ") "
        End If

        Return str
    End Function

    Public Function ComboboxIsSelected(ByRef objCombo As ComboBox, ByRef objFormError As ErrorProvider, ByVal message As String) As Boolean
        If objCombo.SelectedValue = 0 Then
            objFormError.SetError(objCombo, message)
            Return False
        Else
            objFormError.SetError(objCombo, "")
            Return True
        End If
    End Function

    Public Function RefreshCachedTable(ByVal procedure As String, ByVal criteria As String) As Boolean
        'dim refreshed as 
        If Me.Browser IsNot Nothing Then
            Me.Browser.RefreshCachedDataTable(procedure, criteria)
        End If
    End Function
 
End Class

