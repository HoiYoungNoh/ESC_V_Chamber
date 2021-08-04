Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Data.SqlClient
'Imports VB = Microsoft.VisualBasic
Imports System.Threading
Public Class frmMain
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private pOSK As Process = Nothing

    Public iReturnCode As Integer
    Private KillAllThreads As Integer = 0
    Private CycleTimeCal As Integer
    Private SeqMsg(3, 16) As String
    Private SV_Focus As Boolean
    Private Temp_Set_Focus As Boolean
    Private Recipe_Cell_Focus As Boolean
    Private StepSeq As Integer
    Private TempSeq As Integer
    Private DelayTimeChk As Integer

    Private SIO_UP35A As SerialPort     '** 온도컨트롤러 UP35A
    Private _continue_0 As Boolean
    Private Read_UP35A_Thread As Thread = New Thread(AddressOf Read_UP35A)

    Private SIO_UP35A1 As SerialPort     '** 온도컨트롤러 UP35A
    Private _continue_1 As Boolean
    Private Read_UP35A_Thread1 As Thread = New Thread(AddressOf Read_UP35A1)

    '** UP35A Yokogawa
    Public UP35A_SendMsg As String
    Public UP35A_SendMsg1 As String
    Public Seq_UP35A As Integer
    Public UP35A_SetDataTransFlag As Boolean
    Public UP35A_StartFlag As Boolean
    Public UP35A_StopFlag As Boolean
    Public UP35A_ValChk As Boolean
    Public UP35A_ValUpdate As Boolean
    Public UP35A_FuncChk As Boolean
    Public UP35A_Func As String
    Public UP35A_R_Unit As String

    Public UP35A_Receive(100) As Byte    ' 수신패킷 버퍼
    Public UP35A_ReceiveSize As Short
    Public UP35A_ReceiveMsg As String
    Public UP35A_ReceiveOK As Boolean
    Public UP35A_rpos As Short
    Public UP35A_ReTryCNT As Integer
    Public UP35A_PV_Save_Flag As Boolean
    Public UP35A_PV_Receive_ing As Boolean
    Public UP35A_SetRead_Receive_ing As Boolean
    Public UP35A_SV_Set_Receive_ing As Boolean
    Public UP35A_Select_Set_Receive_ing As Boolean
    Public UP35A_Start_Receive_ing As Boolean
    Public UP35A_Stop_Receive_ing As Boolean
    Public UP35A_RunStop_Receive_ing As Boolean
    Public UP35A_Ctrl_Set_Receive_ing As Boolean


    Public UP35A_Command As Short
    Public UP35A_TimeChk As Integer
    Public UP35A_TimeChk1 As Integer
    Public UP35A_Send_DelayChk As Integer

    Public UP35A_Receive1(100) As Byte    ' 수신패킷 버퍼
    Public UP35A_ReceiveSize1 As Short
    Public UP35A_ReceiveMsg1 As String
    Public UP35A_ReceiveOK1 As Boolean
    Public UP35A_rpos1 As Short
    Public UP35A_ReTryCNT1 As Integer
    Public UP35A_PV_Receive_ing1 As Boolean
    Public UP35A_SetRead_Receive_ing1 As Boolean
    Public UP35A_SV_Set_Receive_ing1 As Boolean
    Public UP35A_Select_Set_Receive_ing1 As Boolean
    Public UP35A_Start_Receive_ing1 As Boolean
    Public UP35A_Stop_Receive_ing1 As Boolean
    Public UP35A_RunStop_Receive_ing1 As Boolean
    Public UP35A_Ctrl_Set_Receive_ing1 As Boolean

    Public UP35A_Send_DelayChk1 As Integer

    'DataTables
    Public tblUnit1 As DataTable = New DataTable("Heater_1_Table")
    Public tblUnit2 As DataTable = New DataTable("Heater_2_Table")

    'Public Seq_TM4_N2SB_FuncChk As Byte
    Public Const Temp_Read_Time_Index_ = 10000
    Public Buf_Temp_Read_Time As Long

    Const Pos_inLet_StartAdr_ = 100
    Const Pos_Buffer_StartAdr_ = 200
    Const Pos_inStacker_StartAdr_ = 800
    Const Pos_Work_StartAdr_ = 900
    Const Pos_ByPass_StartAdr_ = 1500
    Const Pos_OutStacker_StartAdr_ = 1800

    Public Pos_inLet(5, 9) As String '0:Work id(BCR), 1:Mat id, 2:Pallet pattern, 3:SV Weight, 4:Current Weight, 5:Stacker Path, 6:End Code
    Public Pos_Buffer(5, 9) As String
    Public Pos_inStacker(5, 9) As String
    Public Pos_OutStacker(5, 9) As String
    Public Pos_Work(5, 9) As String
    Public Pos_ByPass(5, 9) As String
    Public Pos_OutLet(5, 9) As String


    'test test test test
    'Public Work_ID_Old(5) As String

    Public MesWorkOder_ID(5, 0) As String
    Public MesWorkOder_ID_Old(5, 0) As String
    Public MesWorkOder_MatID(5, 0) As String
    Public MesWorkOder_SV(5, 0) As String

    Public lbl_WorkTitle(5) As Label
    Public lbl_Work_ID(70) As Label
    Public lbl_Mat_ID(70) As Label
    Public lbl_SV_Weight(70) As Label
    Public lbl_PV_Weight(70) As Label
    Public lbl_Status(70) As Label
    Public lbl_Pallet_Weight(70) As Label
    Public lbl_msg(70) As Label

    Public PLC_Port_Open_OK As Boolean
    Public Alarm_Bit(320) As Boolean
    Public Alarm_Bit_Old(320) As Boolean
    Public AlarmComment(2000)

    Public test_i As Integer
    Public test_j As Integer

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.



    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        '** 이중 실행 방지
        If UBound(System.Diagnostics.Process.GetProcessesByName(
                 System.Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("already in the RUN !")
            End
        End If

        '1920 * 1080
        Me.Width = 1280     '1920
        Me.Height = 1024        '1080
        Me.Left = 0
        Me.Top = 0

        WorkStatus = PAUSE_

        'Call GetSystemSettings()
        Call Load_EQ_Val_ini()

        Call AlarmCommentRead()
        Call RecipeForm()
        Call SeqMsgDef()

        '** Data Set
        tblUnit1.Columns.AddRange(New DataColumn(0) {New DataColumn("Heater1", GetType(Decimal))})
        tblUnit2.Columns.AddRange(New DataColumn(0) {New DataColumn("Heater2", GetType(Decimal))})
        Chart1.DataSource = tblUnit1
        Chart2.DataSource = tblUnit2

        'Call Plc_Port_Open()
        If PLC_Port_Open_OK = True Then
            Timer1.Enabled = True
        End If

        Call LoadFile_Model()
        Me.cboModel.SelectedIndex = gLastModelindex

        Call Serial_Initial()
        If WorkStatus <> ERROR_ Then
            UP35A_PV_interval = GetTickCount
            tmrTemp.Enabled = True
        End If


    End Sub

    Private Sub RecipeForm()
        Dim font As New Font(DataGridView1.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold)

        Try
            DataGridView1.Columns(0).Width = 480
            DataGridView1.Columns(1).Width = 90
            DataGridView1.Columns(2).Width = 90
            DataGridView1.Columns(3).Width = 90
            DataGridView1.Columns(4).Width = 90
            DataGridView1.Columns(5).Width = 90
            DataGridView1.Columns(6).Width = 90
            DataGridView1.Columns(0).ReadOnly = True

            DataGridView1.Rows.Add("Plasma_MFC_Sccm (sccm)(0~200)", "123456", "", "", "", "", "")
            DataGridView1.Rows.Add("BSP_MFC_Sccm (sccm)(0~5)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Chamber_Hi_Vacuum_Pressure ", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Chamber_Hi_Vacuum_Pressure_Square (*10, Torr)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Chamber_Low_Vacuum_Pressure ", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Chamber_Low_Vacuum_Pressure_Square (*10, Torr)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Chamber_Slow_Rough_OK_Pressure ", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Chamber_Slow_Rough_OK_Pressure_Square (*10, Torr)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Line_Vacuum_OK_Pressure ", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Line_Vacuum_OK_Pressure_Square (*10, Torr)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("DC_Power_Output_Voltage (Vdc)(0~2000)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("RF_Power_Set_Point (W)(0~1000)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Baraton_Gauge_Pressure (Torr)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_DC_Power_On_Delay (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("DC_Power_ONLY_USE (1:Only DC, 0:DC-RF Use)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("DC_Power_ONLY_USE_TIME  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_5Sccm_Ar_Gas_Flow_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_200Sccm_Ar_Gas_Flow_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_RF_Power_On_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_RF_Power_Off_Check_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_200_Sccm_Ar_Gas_Flow_Off_Check_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Auto_5_Sccm_Ar_Gas_Flow_Off_Check_Delay ", "", "", "", "", "", "")
            DataGridView1.Rows.Add("DC_Power_Off_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("Throttle_Valve_Pressure_CNT_Check_Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.Rows.Add("MFC1 Open 전 Delay  (sec)", "", "", "", "", "", "")
            DataGridView1.DefaultCellStyle.Font = font

            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
        Catch ex As Exception
            Debug.Print("Recipe Form = " & ex.Message)
        End Try

    End Sub
    Private Sub SeqMsgDef()
        '** Vacuum Step
        SeqMsg(1, 1) = "Valve All Close"
        SeqMsg(1, 2) = "Dry Pump Run"
        SeqMsg(1, 3) = "Line Vacuum Check"
        SeqMsg(1, 4) = "TMP ForeLine Valve Open"
        SeqMsg(1, 5) = "Line Vacuum Check"
        SeqMsg(1, 6) = "TMP Run"
        SeqMsg(1, 7) = "TMP Run Normal Check"
        SeqMsg(1, 8) = "Valve All Close"
        SeqMsg(1, 9) = "Chamber Rough Valve Open"
        SeqMsg(1, 10) = "Chamber Low Vacuum Check"
        SeqMsg(1, 11) = "Valve All Close"
        SeqMsg(1, 12) = "TMP Foreline Valve Open"
        SeqMsg(1, 13) = "TMP Throttle Valve Open"
        SeqMsg(1, 14) = "Chamber Gate Valve Open"
        SeqMsg(1, 15) = "Chamber Base Pressure Check"

        '** Vent Step
        SeqMsg(2, 1) = "Valve All Close"
        SeqMsg(2, 2) = "Chamber Vent Valve Open"
        SeqMsg(2, 3) = "Chamber ATM Check"
        SeqMsg(2, 4) = "Chamber Vent Valve Close"
        SeqMsg(2, 5) = "Chamber Vent Comeplte Check"

        '** ESC Power Step
        SeqMsg(3, 1) = "Base Pressure Check"
        SeqMsg(3, 2) = "DC Power On"
        SeqMsg(3, 3) = "Ar 5Sccm Flow Start"
        SeqMsg(3, 4) = "Ar 5Sccm Flow Check"
        SeqMsg(3, 5) = "Ar 200Sccm Flow Start"
        SeqMsg(3, 6) = "Ar 200Sccm Flow Check"
        SeqMsg(3, 7) = "Throttle Pressure Control"
        SeqMsg(3, 8) = "RF Power On"
        SeqMsg(3, 9) = "RF Power Off"
        SeqMsg(3, 10) = "Ar 200Sccm Flow Off"
        SeqMsg(3, 11) = "Ar 5Sccm Flow Off"
        SeqMsg(3, 12) = "DC Power Off"
        SeqMsg(3, 13) = "Throttle Valve Open Start"
        SeqMsg(3, 14) = "ESC Power Step Complete"

    End Sub

    Private Sub Server_Conn_Chk()
        'Dim adoCon As New SqlConnection
        'Dim DB_Name As String
        'Dim DB_HalfYear As String

        'With tIni.tEQValIni
        '    Try
        '        '** 년 상반기/ 하반기
        '        DB_Name = Format(Now, "yyyy")
        '        DB_HalfYear = Format(Now, "MM")
        '        If CInt(DB_HalfYear) <= 6 Then
        '            DB_Name = DB_Name & "01"
        '        ElseIf CInt(DB_HalfYear) > 6 Then
        '            DB_Name = DB_Name & "07"
        '        End If

        '        'adoCon.ConnectionString = "Data Source=" & "127.0.0.1,1433" & ";Initial Catalog=" & "202007DB" & ";Uid=" & "UserCJ" & ";Pwd=" & "12345"
        '        With tIni.tEQValIni
        '            adoCon.ConnectionString = "Data Source=" & .Server_Ip & ";Initial Catalog=" & DB_Name & ";Uid=" & .Server_Uid & ";Pwd=" & .Server_Pwd
        '        End With

        '        adoCon.Open()
        '        If (adoCon.State = ConnectionState.Open) Then
        '            DB_Updating_Flag = True
        '            DB_Conn_OK = True
        '            adoCon.Close()
        '            DB_Updating_Flag = False
        '        End If


        '    Catch ex As Exception
        '        If adoCon.State = ConnectionState.Open Then
        '            adoCon.Close()
        '        End If

        '        DB_Conn_OK = False
        '        DB_Updating_Flag = False
        '        MsgDisplay("Server Connect Err : " & ex.Message, Color.Red)
        '    End Try

        'End With
    End Sub

    '---------------- 설비 상태정보 저장 ------------------------------------
    Public Sub EQ_TB1_MES_Trnas(ByVal statusMSG As String)
        'Dim adoCon As New SqlConnection
        'Dim DB_Name As String
        'Dim DB_HalfYear As String
        'Dim sColHeads As String
        'Dim sCols As String
        'Dim sColHead() As String
        'Dim sCol() As String
        'Dim sQuery As String
        'Dim i As Integer

        'Try
        '    With tIni.tEQValIni

        '        '** 년 상반기/ 하반기
        '        DB_Name = Format(Now, "yyyy")
        '        DB_HalfYear = Format(Now, "MM")
        '        If CInt(DB_HalfYear) <= 6 Then
        '            DB_Name = DB_Name & "01DB"
        '        ElseIf CInt(DB_HalfYear) > 6 Then
        '            DB_Name = DB_Name & "07DB"
        '        End If

        '        'adoCon.ConnectionString = "Data Source=" & "127.0.0.1,1433" & ";Initial Catalog=" & "LotData" & ";Uid=" & "Test" & ";Pwd=" & "12345"
        '        With tIni.tEQValIni
        '            adoCon.ConnectionString = "Data Source=" & .Server_Ip & ";Initial Catalog=" & DB_Name & ";Uid=" & .Server_Uid & ";Pwd=" & .Server_Pwd
        '        End With
        '        adoCon.Open()

        '        '** SQL Insert
        '        If (adoCon.State = ConnectionState.Open) Then

        '            ReDim sColHead(.Server_TB1_Cols - 1)
        '            ReDim sCol(.Server_TB1_Cols - 1)
        '            sColHeads = ""
        '            sCols = ""

        '            sCol(0) = statusMSG                                         'Machine Status
        '            sCol(1) = Format(Now, "yyyy-MM-dd HH:mm:ss.fff")           'Format(Now, "yy-MM-dd HH:mm")   (insert Time)          

        '            For i = 0 To .Server_TB1_Cols - 1           'Col
        '                '** Insert (PalletPileRelateInfo)
        '                DB_Updating_Flag = True
        '                'for DB
        '                sColHead(i) = .Server_TB1_ColHead(i)
        '                sColHeads += sColHead(i) & ","

        '                If i = .Server_TB1_Cols - 1 Then
        '                    'sCols += sCol(i) & ","         '마지막 항목 따옴표 무시
        '                    sCols += Chr(39) & sCol(i) & Chr(39) & ","
        '                Else
        '                    sCols += Chr(39) & sCol(i) & Chr(39) & ","
        '                End If

        '            Next

        '            'If sCol(2) <> "" Then
        '            sColHeads = Mid(sColHeads, 1, Len(sColHeads) - 1)
        '            sCols = Mid(sCols, 1, Len(sCols) - 1)
        '            sQuery = "Insert into " & .Server_TB1 & "(" & sColHeads & ") VALUES(" & sCols & ")"
        '            'Debug.Print(sQuery)
        '            Dim cmd As New SqlCommand(sQuery, adoCon)
        '            Dim iResult As Integer
        '            iResult = cmd.ExecuteNonQuery
        '            'End If

        '            adoCon.Close()
        '            DB_Updating_Flag = False

        '        Else
        '            adoCon.Close()
        '            MsgDisplay("TB1 Trans Open Err", Color.Red)
        '        End If
        '    End With

        'Catch ex As Exception
        '    adoCon.Close()
        '    MsgDisplay("TB1 Trans Err : " & ex.Message, Color.Red)

        'End Try

    End Sub

    '---------------- 설비 알람정보 저장 ------------------------------------
    Public Sub EQ_TB2_MES_Trnas(ByVal AlarmMSG As String)
        'Dim adoCon As New SqlConnection
        'Dim DB_Name As String
        'Dim DB_HalfYear As String
        'Dim sColHeads As String
        'Dim sCols As String
        'Dim sColHead() As String
        'Dim sCol() As String
        'Dim sQuery As String
        'Dim i As Integer

        'Try
        '    With tIni.tEQValIni

        '        '** 년 상반기/ 하반기
        '        DB_Name = Format(Now, "yyyy")
        '        DB_HalfYear = Format(Now, "MM")
        '        If CInt(DB_HalfYear) <= 6 Then
        '            DB_Name = DB_Name & "01DB"
        '        ElseIf CInt(DB_HalfYear) > 6 Then
        '            DB_Name = DB_Name & "07DB"
        '        End If

        '        'adoCon.ConnectionString = "Data Source=" & "127.0.0.1,1433" & ";Initial Catalog=" & "LotData" & ";Uid=" & "Test" & ";Pwd=" & "12345"
        '        With tIni.tEQValIni
        '            adoCon.ConnectionString = "Data Source=" & .Server_Ip & ";Initial Catalog=" & DB_Name & ";Uid=" & .Server_Uid & ";Pwd=" & .Server_Pwd
        '            'Debug.Print("sdf " & .Server_Ip)
        '            'Debug.Print("sdf " & .Server_Uid)
        '            'Debug.Print("sdf " & .Server_Pwd)
        '        End With
        '        adoCon.Open()

        '        '** SQL Insert
        '        If (adoCon.State = ConnectionState.Open) Then

        '            ReDim sColHead(.Server_TB2_Cols - 1)
        '            ReDim sCol(.Server_TB2_Cols - 1)
        '            sColHeads = ""
        '            sCols = ""

        '            sCol(0) = AlarmMSG                                         'Machine Alarm Message
        '            sCol(1) = Format(Now, "yyyy-MM-dd HH:mm:ss.fff")           'Format(Now, "yy-MM-dd HH:mm")   (insert Time)          

        '            For i = 0 To .Server_TB2_Cols - 1           'Col
        '                '** Insert (PalletPileRelateInfo)
        '                DB_Updating_Flag = True
        '                'for DB
        '                sColHead(i) = .Server_TB2_ColHead(i)
        '                sColHeads += sColHead(i) & ","

        '                If i = .Server_TB2_Cols - 1 Then
        '                    'sCols += sCol(i) & ","         '마지막 항목 따옴표 무시
        '                    sCols += Chr(39) & sCol(i) & Chr(39) & ","
        '                Else
        '                    sCols += Chr(39) & sCol(i) & Chr(39) & ","
        '                End If

        '            Next

        '            'If sCol(2) <> "" Then
        '            sColHeads = Mid(sColHeads, 1, Len(sColHeads) - 1)
        '            sCols = Mid(sCols, 1, Len(sCols) - 1)
        '            sQuery = "Insert into " & .Server_TB2 & "(" & sColHeads & ") VALUES(" & sCols & ")"
        '            'Debug.Print(sQuery)
        '            Dim cmd As New SqlCommand(sQuery, adoCon)
        '            Dim iResult As Integer
        '            iResult = cmd.ExecuteNonQuery
        '            'End If

        '            adoCon.Close()
        '            DB_Updating_Flag = False

        '        Else
        '            adoCon.Close()
        '            MsgDisplay("TB2 Trans Open Err", Color.Red)
        '        End If
        '    End With

        'Catch ex As Exception
        '    adoCon.Close()
        '    MsgDisplay("TB2 Trans Err : " & ex.Message, Color.Red)

        'End Try

    End Sub


    '---------------- 설비 포지션별 데이타 저장 ------------------------------------
    Public Sub EQ_TB3_MES_Trnas(ByVal Position As String, ByVal inOut As String, ByVal WorkID As String,
                                ByVal MatID As String, ByVal SV_Weight As String, ByVal PV_Weight As String, ByVal EndMSG As String)
        'Dim adoCon As New SqlConnection
        'Dim DB_Name As String
        'Dim DB_HalfYear As String
        'Dim sColHeads As String
        'Dim sCols As String
        'Dim sColHead() As String
        'Dim sCol() As String
        'Dim sQuery As String
        'Dim i As Integer

        'Try
        '    With tIni.tEQValIni

        '        '** 년 상반기/ 하반기
        '        DB_Name = Format(Now, "yyyy")
        '        DB_HalfYear = Format(Now, "MM")
        '        If CInt(DB_HalfYear) <= 6 Then
        '            DB_Name = DB_Name & "01DB"
        '        ElseIf CInt(DB_HalfYear) > 6 Then
        '            DB_Name = DB_Name & "07DB"
        '        End If

        '        'adoCon.ConnectionString = "Data Source=" & "127.0.0.1,1433" & ";Initial Catalog=" & "LotData" & ";Uid=" & "Test" & ";Pwd=" & "12345"
        '        With tIni.tEQValIni
        '            adoCon.ConnectionString = "Data Source=" & .Server_Ip & ";Initial Catalog=" & DB_Name & ";Uid=" & .Server_Uid & ";Pwd=" & .Server_Pwd
        '        End With
        '        adoCon.Open()

        '        '** SQL Insert
        '        If (adoCon.State = ConnectionState.Open) Then

        '            ReDim sColHead(.Server_TB3_Cols - 1)
        '            ReDim sCol(.Server_TB3_Cols - 1)
        '            sColHeads = ""
        '            sCols = ""

        '            sCol(0) = Position                                          'Work Position
        '            sCol(1) = inOut                                             'Pallet in / Out
        '            'sCol(2) = VB.Left(WorkID, 20)                                            'Work id
        '            sCol(2) = Mid(WorkID, 1, 20)                                            'Work id
        '            sCol(3) = MatID                                             'Mat id (자재코드)
        '            sCol(4) = SV_Weight                                         '설정 무게
        '            sCol(5) = PV_Weight                                         '현재 무게
        '            sCol(6) = EndMSG                                            '파렛 완료 메시지
        '            sCol(7) = Format(Now, "yyyy-MM-dd HH:mm:ss.fff")           'Format(Now, "yy-MM-dd HH:mm")   (insert Time)          

        '            For i = 0 To .Server_TB3_Cols - 1           'Col
        '                '** Insert (PalletPileRelateInfo)
        '                DB_Updating_Flag = True
        '                'for DB
        '                sColHead(i) = .Server_TB3_ColHead(i)
        '                sColHeads += sColHead(i) & ","

        '                If i = .Server_TB3_Cols - 1 Then
        '                    'sCols += sCol(i) & ","         '마지막 항목 따옴표 무시
        '                    sCols += Chr(39) & sCol(i) & Chr(39) & ","
        '                Else
        '                    sCols += Chr(39) & sCol(i) & Chr(39) & ","
        '                End If

        '            Next

        '            'If sCol(2) <> "" Then
        '            sColHeads = Mid(sColHeads, 1, Len(sColHeads) - 1)
        '            sCols = Mid(sCols, 1, Len(sCols) - 1)
        '            sQuery = "Insert into " & .Server_TB3 & "(" & sColHeads & ") VALUES(" & sCols & ")"
        '            'Debug.Print(sQuery)
        '            Dim cmd As New SqlCommand(sQuery, adoCon)
        '            Dim iResult As Integer
        '            iResult = cmd.ExecuteNonQuery
        '            'End If

        '            adoCon.Close()
        '            DB_Updating_Flag = False

        '        Else
        '            adoCon.Close()
        '            MsgDisplay("TB3 Trans Open Err", Color.Red)
        '        End If
        '    End With

        'Catch ex As Exception
        '    adoCon.Close()
        '    MsgDisplay("TB3 Trans Err : " & ex.Message, Color.Red)

        'End Try

    End Sub

    '---------------------- PLC Port Open --------------------------
    Public Function Plc_Port_Open() As Boolean
        'Dim iReturnCode As Integer              'Return code

        Try
            If PLC_Port_Open_OK = False Then
                Me.AxActUtlType1.ActLogicalStationNumber = 3     '1
                iReturnCode = Me.AxActUtlType1.Open()
                If iReturnCode = 0 Then
                    MsgDisplay("PLC Connect  ", Color.Lime, 0)
                    PLC_Port_Open_OK = True
                Else
                    MsgDisplay("PLC  Not Connect", Color.Red, 0)
                    PLC_Port_Open_OK = False
                End If
            End If
            Plc_Port_Open = True

        Catch ex As Exception
            Plc_Port_Open = False
        End Try


    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CycleTimeCal = GetTickCount

        Call Plc_Port_Open()

        Call PLC_Alarm_Get()

        Call RealDataRead()

        Call PLC_Data_Display()


        '** Step Sequence
        'If PlcData_D0(PLC_Step_CNT_) >= 1 And WorkStatus <> RUN_ Then
        If AutoStatFlag = True And WorkStatus <> RUN_ Then
            StepSeq = 0
            WorkStatus = RUN_
            AutoStatFlag = False
            TabControl.SelectedIndex = 1
            DelayTimeChk = GetTickCount
        End If
        If PlcData_M_bit(401) = True And WorkStatus <> STOP_ Then
            StepSeq = 0
            WorkStatus = STOP_
            iReturnCode = AxActUtlType1.WriteDeviceBlock("D" & PLC_Step_CNT_, 1, 0)
            iReturnCode = AxActUtlType1.WriteDeviceBlock("D" & PLC_Step_Complete_, 1, 0)
        End If


        Select Case WorkStatus
            Case RUN_

                Select Case StepSeq

                    Case 0      '** Data Trans
                        If GetTickCount < DelayTimeChk Then Exit Select
                        With WorkData
                            ' ZR
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR20", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 20))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR22", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 22))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR30", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 30))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR31", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 31))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR40", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 40))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR41", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 41))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR60", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 60))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR61", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 61))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR70", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 70))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR71", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 71))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR50", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 50))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR54", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 54))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR80", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 80))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR81", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 81))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR82", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 82))
                            Call DoubleDataWrite("ZR", 92, .ZR(PlcData_D0(PLC_Step_CNT_), 92))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR110", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 110))
                            Call DoubleDataWrite("ZR", 112, .ZR(PlcData_D0(PLC_Step_CNT_), 112))
                            Call DoubleDataWrite("ZR", 94, .ZR(PlcData_D0(PLC_Step_CNT_), 94))
                            Call DoubleDataWrite("ZR", 96, .ZR(PlcData_D0(PLC_Step_CNT_), 96))
                            Call DoubleDataWrite("ZR", 90, .ZR(PlcData_D0(PLC_Step_CNT_), 90))
                            Call DoubleDataWrite("ZR", 98, .ZR(PlcData_D0(PLC_Step_CNT_), 98))
                            Call DoubleDataWrite("ZR", 102, .ZR(PlcData_D0(PLC_Step_CNT_), 102))
                            Call DoubleDataWrite("ZR", 104, .ZR(PlcData_D0(PLC_Step_CNT_), 104))
                            Call DoubleDataWrite("ZR", 100, .ZR(PlcData_D0(PLC_Step_CNT_), 100))
                            Call DoubleDataWrite("ZR", 106, .ZR(PlcData_D0(PLC_Step_CNT_), 106))
                            Call DoubleDataWrite("ZR", 108, .ZR(PlcData_D0(PLC_Step_CNT_), 108))
                            ' D
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1020", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 20))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1022", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 22))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1030", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 30))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1031", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 31))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1040", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 40))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1041", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 41))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1060", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 60))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1061", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 61))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1070", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 70))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1071", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 71))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1050", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 50))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1054", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 54))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1080", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 80))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1081", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 81))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1082", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 82))
                            Call DoubleDataWrite("D", 1092, .ZR(PlcData_D0(PLC_Step_CNT_), 92))
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D1110", 1, .ZR(PlcData_D0(PLC_Step_CNT_), 110))
                            Call DoubleDataWrite("D", 1112, .ZR(PlcData_D0(PLC_Step_CNT_), 112))
                            Call DoubleDataWrite("D", 1094, .ZR(PlcData_D0(PLC_Step_CNT_), 94))
                            Call DoubleDataWrite("D", 1096, .ZR(PlcData_D0(PLC_Step_CNT_), 96))
                            Call DoubleDataWrite("D", 1090, .ZR(PlcData_D0(PLC_Step_CNT_), 90))
                            Call DoubleDataWrite("D", 1098, .ZR(PlcData_D0(PLC_Step_CNT_), 98))
                            Call DoubleDataWrite("D", 1102, .ZR(PlcData_D0(PLC_Step_CNT_), 102))
                            Call DoubleDataWrite("D", 1104, .ZR(PlcData_D0(PLC_Step_CNT_), 104))
                            Call DoubleDataWrite("D", 1100, .ZR(PlcData_D0(PLC_Step_CNT_), 100))
                            Call DoubleDataWrite("D", 1106, .ZR(PlcData_D0(PLC_Step_CNT_), 106))
                            Call DoubleDataWrite("D", 1108, .ZR(PlcData_D0(PLC_Step_CNT_), 108))
                        End With
                        'Current Colums
                        DataGridView1(6, 0).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 0).Value
                        DataGridView1(6, 1).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 1).Value
                        DataGridView1(6, 2).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 2).Value
                        DataGridView1(6, 3).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 3).Value
                        DataGridView1(6, 4).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 4).Value
                        DataGridView1(6, 5).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 5).Value
                        DataGridView1(6, 6).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 6).Value
                        DataGridView1(6, 7).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 7).Value
                        DataGridView1(6, 8).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 8).Value
                        DataGridView1(6, 9).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 9).Value
                        DataGridView1(6, 10).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 10).Value
                        DataGridView1(6, 11).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 11).Value
                        DataGridView1(6, 12).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 12).Value
                        DataGridView1(6, 13).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 13).Value
                        DataGridView1(6, 14).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 14).Value
                        DataGridView1(6, 15).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 15).Value
                        DataGridView1(6, 16).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 16).Value
                        DataGridView1(6, 17).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 17).Value
                        DataGridView1(6, 18).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 18).Value
                        DataGridView1(6, 19).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 19).Value
                        DataGridView1(6, 20).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 20).Value
                        DataGridView1(6, 21).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 21).Value
                        DataGridView1(6, 22).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 22).Value
                        DataGridView1(6, 23).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 23).Value
                        DataGridView1(6, 24).Value = DataGridView1(PlcData_D0(PLC_Step_CNT_) + 1, 24).Value
                        iReturnCode = AxActUtlType1.WriteDeviceRandom("M400", 1, 1) 'bit
                        DelayTimeChk = GetTickCount + 500
                        StepSeq += 1

                    Case 1
                        If GetTickCount < DelayTimeChk Then Exit Select
                        If PlcData_M_bit(410) = True Then
                            iReturnCode = AxActUtlType1.WriteDeviceRandom("M400", 1, 0) 'bit
                            StepSeq += 1
                        End If

                    Case 2
                        If PlcData_D0(PLC_Step_Complete_) = 1 Then
                            If PlcData_D0(PLC_Step_CNT_) >= WorkData.StepCNT Then
                                StepSeq = 0
                                WorkStatus = STOP_
                                Call MsgDisplay("ESC Power Auto END.", Color.Orange, 0)
                                iReturnCode = AxActUtlType1.WriteDeviceBlock("D" & PLC_Step_CNT_, 1, 0)
                            Else
                                DelayTimeChk = GetTickCount + 3000
                                StepSeq = 0
                            End If
                            '** RST
                            iReturnCode = AxActUtlType1.WriteDeviceBlock("D" & PLC_Step_Complete_, 1, 0)
                        End If
                End Select

            Case STOP_

        End Select


        lblAutoSeq.Text = StepSeq
        lblCycleTime.Text = GetTickCount - CycleTimeCal
    End Sub


    Private Sub PLC_Alarm_Get()
        Dim AlarmData(19) As Short
        Dim bDioSet As Boolean = False
        Dim i, j, k As Integer

        If PLC_Port_Open_OK = True Then
            '**  Alarm,  D10010 ~ 29 : 알람코드 (bit로처리)
            'Call ActUtl1_Read("D10010", 20, AlarmData)
            Call ActUtl1_Read("F0", (PLC_F_CNT_ / 16), PlcData_F)  'Device Y
            'Call ActUtl1_Read("M0", (PLC_M_CNT_ / 16), PlcData_M)  'Device M

            k = 0
            For i = 0 To (PLC_F_CNT_ / 16) - 1
                For j = 0 To 15
                    'bDioSet = ( nDioState >> i ) & 0x01 ? TRUE : FALSE
                    bDioSet = IIf(((PlcData_F(i) >> j) And &H1) = 1, True, False)
                    PlcData_F_bit(k) = bDioSet
                    Alarm_Bit(k) = bDioSet
                    'Debug.Print("K= " & k)
                    If Alarm_Bit(k) = True Then
                        If Alarm_Bit_Old(k) = False Then
                            Alarm_Bit_Old(k) = True
                            lst_Alarm.Items.Add(AlarmComment(k))
                            lst_Alarm.SelectedIndex = lst_Alarm.Items.Count - 1
                            If lst_Alarm.Items.Count > 100 Then lst_Alarm.Items.RemoveAt(0)
                            If Alarm_Bit(1) = True Then btnHeaterOFF_Click(Nothing, Nothing)    '** EMG Heater Off
                            'Call EQ_TB2_MES_Trnas(AlarmComment(k))
                        End If
                    Else
                        Alarm_Bit_Old(k) = False
                    End If
                    k += 1
                Next
                'Debug.Print("i = " & i)
            Next




            'k = 0
            'For i = 0 To AlarmData.Length - 1
            '    For j = 0 To 15
            '        'bDioSet = ( nDioState >> i ) & 0x01 ? TRUE : FALSE
            '        bDioSet = IIf(((AlarmData(i) >> j) And &H1) = 1, True, False)
            '        Alarm_Bit(k) = bDioSet
            '        'Debug.Print("K= " & k)
            '        If Alarm_Bit(k) = True Then
            '            If Alarm_Bit_Old(k) = False Then
            '                Alarm_Bit_Old(k) = True
            '                lst_Alarm.Items.Add(AlarmComment(k))
            '                lst_Alarm.SelectedIndex = lst_Alarm.Items.Count - 1
            '                If lst_Alarm.Items.Count > 100 Then lst_Alarm.Items.RemoveAt(0)
            '                Call EQ_TB2_MES_Trnas(AlarmComment(k))
            '            End If
            '        Else
            '            Alarm_Bit_Old(k) = False
            '        End If
            '        k += 1
            '    Next
            'Next
        End If
    End Sub

    Public Sub RealDataRead()
        Dim i, j, k As Integer
        Dim iReturnCode As Integer              'Return code
        Dim bDioSet As Boolean = False

        Try

            If PLC_Port_Open_OK = True Then

                'Call ActUtl1_Read("D10000", PLC_Data_CNT_, PlcData)          'PLC Data Read


                'Call ActUtl1_Read1("M71", 1, PlcData_M_Test)  'Device M bit
                'Call ActUtl1_Read1("M70", 1, PlcData_M_Test)  'Device M bit
                'Call ActUtl1_Read_Bit("M0", PLC_M_CNT_ / 16, PlcData_M)  'Device M


                'PLC Data Read 
                Call ActUtl1_Read("L0", (PLC_L_CNT_ / 16), PlcData_L)  'Device L 10진
                k = 0
                For i = 0 To (PLC_L_CNT_ / 16) - 1
                    For j = 0 To 15
                        'bDioSet = ( nDioState >> i ) & 0x01 ? TRUE : FALSE
                        bDioSet = IIf(((PlcData_L(i) >> j) And &H1) = 1, True, False)
                        PlcData_L_bit(k) = bDioSet
                        k += 1
                    Next
                    'Debug.Print("i = " & i)
                Next

                Call ActUtl1_Read("M0", (PLC_M_CNT_ / 16), PlcData_M)  'Device M
                k = 0
                For i = 0 To (PLC_M_CNT_ / 16) - 1
                    For j = 0 To 15
                        'bDioSet = ( nDioState >> i ) & 0x01 ? TRUE : FALSE
                        bDioSet = IIf(((PlcData_M(i) >> j) And &H1) = 1, True, False)
                        PlcData_M_bit(k) = bDioSet
                        k += 1
                    Next
                Next

                Call ActUtl1_Read("X0", (PLC_X_CNT_ / 16), PlcData_X)  'Device X  16진
                For i = 0 To (PLC_X_CNT_ / 16) - 1
                    For j = 0 To 15
                        'bDioSet = ( nDioState >> i ) & 0x01 ? TRUE : FALSE
                        bDioSet = IIf(((PlcData_X(i) >> j) And &H1) = 1, True, False)
                        PlcData_X_bit(i, j) = bDioSet
                    Next
                Next

                Call ActUtl1_Read("Y0", (PLC_Y_CNT_ / 16), PlcData_Y)  'Device Y
                For i = 0 To (PLC_Y_CNT_ / 16) - 1
                    For j = 0 To 15
                        'bDioSet = ( nDioState >> i ) & 0x01 ? TRUE : FALSE
                        bDioSet = IIf(((PlcData_Y(i) >> j) And &H1) = 1, True, False)
                        PlcData_Y_bit(i, j) = bDioSet
                    Next
                Next

                'Debug.Print("Y1046 = " & PlcData_Y_bit(Val(&H104), 6))

                Call ActUtl1_Read("ZR0", PLC_ZR_CNT_, PlcData_ZR)  'Device ZR
                Call ActUtl1_Read("D0", PLC_D0_CNT_, PlcData_D0)  'Device D
                Call ActUtl1_Read("D700", 1, PlcData_D700)  'Device D700
                Call ActUtl1_Read("D800", 1, PlcData_D800)  'Device D800
                PlcData_D0(700) = PlcData_D700(0)
                PlcData_D0(800) = PlcData_D800(0)

                Call ActUtl1_Read("D900", PLC_D900_CNT_, PlcData_D900)  'Device D900
                Array.Copy(PlcData_D900, 0, PlcData_D0, 900, PLC_D900_CNT_)

                Call ActUtl1_Read("D8530", 1, PlcData_D8530)  'Device D8530
                Call ActUtl1_Read("D8531", 1, PlcData_D8531)  'Device D8531
                PlcData_D0(8530) = PlcData_D8530(0)
                PlcData_D0(8531) = PlcData_D8531(0)

                Call ActUtl1_Read("D10401", PLC_D10401_CNT_, PlcData_D10401)  'Device D10401
                Array.Copy(PlcData_D10401, 0, PlcData_D0, 10401, PLC_D10401_CNT_)

                'Debug.Print("D = " & PlcData_D0(11464))

                Call ActUtl1_Read("D30450", PLC_D30450_CNT_, PlcData_D30450)  'Device D30450
                Array.Copy(PlcData_D30450, 0, PlcData_D0, 30450, PLC_D30450_CNT_)

                Call ActUtl1_Read("D50450", PLC_D50450_CNT_, PlcData_D50450)  'Device D50450
                Array.Copy(PlcData_D50450, 0, PlcData_D0, 50450, PLC_D50450_CNT_)


            End If

        Catch ex As Exception
            MsgDisplay("RealDataRead Err : " & ex.Message, Color.Red)
        End Try

    End Sub


    Private Sub PLC_Data_Display()
        Dim byteArray(3) As Byte

        If PlcData_L_bit(20) = True And btnBuzzerStop.BackColor <> Color.SkyBlue Then
            btnBuzzerStop.BackColor = Color.SkyBlue
        ElseIf PlcData_L_bit(20) = False And btnBuzzerStop.BackColor <> Color.LightGray Then
            btnBuzzerStop.BackColor = Color.LightGray
        End If
        'lblStep_PV.Text = PlcData_D0(PLC_Step_CNT_)


        If TabControl.SelectedIndex = 0 Then    'Main
            If PlcData_L_bit(100) = True And btnStandy.BackColor <> Color.SkyBlue Then
                btnStandy.BackColor = Color.SkyBlue
            ElseIf PlcData_L_bit(100) = False And btnStandy.BackColor <> Color.LightGray Then
                btnStandy.BackColor = Color.LightGray
            End If
            If PlcData_L_bit(101) = True And btnStandyStop.BackColor <> Color.Tomato Then
                btnStandyStop.BackColor = Color.Tomato
            ElseIf PlcData_L_bit(101) = False And btnStandyStop.BackColor <> Color.DarkRed Then
                btnStandyStop.BackColor = Color.DarkRed
            End If

            If PlcData_L_bit(200) = True And btnATM.BackColor <> Color.SkyBlue Then
                btnATM.BackColor = Color.SkyBlue
            ElseIf PlcData_L_bit(200) = False And btnATM.BackColor <> Color.LightGray Then
                btnATM.BackColor = Color.LightGray
            End If
            If PlcData_L_bit(201) = True And btnATMStop.BackColor <> Color.Tomato Then
                btnATMStop.BackColor = Color.Tomato
            ElseIf PlcData_L_bit(201) = False And btnATMStop.BackColor <> Color.DarkRed Then
                btnATMStop.BackColor = Color.DarkRed
            End If

            If PlcData_L_bit(400) = True And btnESC_PWR_Auto.BackColor <> Color.SkyBlue Then
                btnESC_PWR_Auto.BackColor = Color.SkyBlue
            ElseIf PlcData_L_bit(400) = False And btnESC_PWR_Auto.BackColor <> Color.LightGray Then
                btnESC_PWR_Auto.BackColor = Color.LightGray
            End If
            If PlcData_L_bit(401) = True And btnESC_PWR_Stop.BackColor <> Color.Tomato Then
                btnESC_PWR_Stop.BackColor = Color.Tomato
            ElseIf PlcData_L_bit(401) = False And btnESC_PWR_Stop.BackColor <> Color.DarkRed Then
                btnESC_PWR_Stop.BackColor = Color.DarkRed
            End If

            If PlcData_M_bit(6) = True And btnManualValveEnable.BackColor <> Color.Lime Then
                btnManualValveEnable.BackColor = Color.Lime
            ElseIf PlcData_M_bit(6) = False And btnManualValveEnable.BackColor <> Color.DarkGreen Then
                btnManualValveEnable.BackColor = Color.DarkGreen
            End If

            lblStandbyStep.Text = PlcData_D0(800)
            lblStandby_MSG.Text = SeqMsg(PlcData_D0(90), PlcData_D0(800))
            lblATMStep.Text = PlcData_D0(900)
            lblATM_MSG.Text = SeqMsg(PlcData_D0(91), PlcData_D0(900))
            lblESCStep.Text = PlcData_D0(700)
            lblESC_MSG.Text = SeqMsg(PlcData_D0(70), PlcData_D0(700))


            lblLD.Text = Work_data_String_D(50450, 3) ' PlcData_D0(50450) & PlcData_D0(50451) & PlcData_D0(50452)
            lblTN.Text = Work_data_String_D(50550, 3) 'PlcData_D0(50550) & PlcData_D0(50551) & PlcData_D0(50552)

            lblRF_Power_SV.Text = PlcData_D0(1054)
            lblRF_Power_Fwd.Text = PlcData_D0(2005)
            lblRF_Power_Ref.Text = PlcData_D0(2004)
            lblDC_Power_SV.Text = PlcData_D0(1050)
            lblDC_Power_PV.Text = PlcData_D0(12001)
            lblLeak_Current_P.Text = Work_data_String_D(30450, 2) 'PlcData_D0(30450) & PlcData_D0(30451)
            lblLeak_Current_N.Text = Work_data_String_D(30550, 2) 'PlcData_D0(30550) & PlcData_D0(30551)

            If PlcData_M_bit(0) = True And lblBASE_PRESSURE_Lamp.BackColor <> Color.Red Then
                lblBASE_PRESSURE_Lamp.BackColor = Color.Red
            ElseIf PlcData_M_bit(0) = False And lblBASE_PRESSURE_Lamp.BackColor <> Color.DarkRed Then
                lblBASE_PRESSURE_Lamp.BackColor = Color.DarkRed
            End If
            If PlcData_M_bit(10) = True And lblATM_CHECK_Lamp.BackColor <> Color.Red Then
                lblATM_CHECK_Lamp.BackColor = Color.Red
            ElseIf PlcData_M_bit(10) = False And lblATM_CHECK_Lamp.BackColor <> Color.DarkRed Then
                lblATM_CHECK_Lamp.BackColor = Color.DarkRed
            End If
            If PlcData_L_bit(130) = True And lblBSP_Pressure_Warning_Lamp.BackColor <> Color.Red Then
                lblBSP_Pressure_Warning_Lamp.BackColor = Color.Red
            ElseIf PlcData_L_bit(130) = False And lblBSP_Pressure_Warning_Lamp.BackColor <> Color.DarkRed Then
                lblBSP_Pressure_Warning_Lamp.BackColor = Color.DarkRed
            End If
            lblBaratonGauge_PV.Text = Work_data_String_D(10401, 3)
            lblPlasma_MFC.Text = PlcData_D0(2000)
            lblBSP_MFC.Text = (PlcData_D0(2002) / 10)
            lblBSP_Pressure.Text = (PlcData_D0(200) / 10) & " X 10 " & PlcData_D0(201)
            lblLine_Vacuum.Text = (PlcData_D0(100) / 10) & " X 10 " & PlcData_D0(101)
            lblHi_Vacuum.Text = (PlcData_D0(110) / 10) & " X 10 " & PlcData_D0(111)
            lblThrottleValve_Position_PV.Text = Work_data_String_D(10501, 3)

            If PlcData_L_bit(19) = True Then
                lblChamberRangeOver.Top = 741
                lblChamberRangeOver.Left = 440
                lblChamberRangeOver.Visible = True
            Else
                lblChamberRangeOver.Visible = False
            End If


        ElseIf TabControl.SelectedIndex = 1 Then    'Manual
            If PlcData_L_bit(100) = True And btnStandy1.BackColor <> Color.SkyBlue Then
                btnStandy1.BackColor = Color.SkyBlue
            ElseIf PlcData_L_bit(100) = False And btnStandy1.BackColor <> Color.LightGray Then
                btnStandy1.BackColor = Color.LightGray
            End If
            If PlcData_L_bit(101) = True And btnStandyStop1.BackColor <> Color.Tomato Then
                btnStandyStop1.BackColor = Color.Tomato
            ElseIf PlcData_L_bit(101) = False And btnStandyStop1.BackColor <> Color.DarkRed Then
                btnStandyStop1.BackColor = Color.DarkRed
            End If

            If PlcData_L_bit(200) = True And btnATM1.BackColor <> Color.SkyBlue Then
                btnATM1.BackColor = Color.SkyBlue
            ElseIf PlcData_L_bit(200) = False And btnATM1.BackColor <> Color.LightGray Then
                btnATM1.BackColor = Color.LightGray
            End If
            If PlcData_L_bit(201) = True And btnATMStop1.BackColor <> Color.Tomato Then
                btnATMStop1.BackColor = Color.Tomato
            ElseIf PlcData_L_bit(201) = False And btnATMStop1.BackColor <> Color.DarkRed Then
                btnATMStop1.BackColor = Color.DarkRed
            End If

            If PlcData_L_bit(400) = True And btnESC_PWR_Auto1.BackColor <> Color.SkyBlue Then
                btnESC_PWR_Auto1.BackColor = Color.SkyBlue
            ElseIf PlcData_L_bit(400) = False And btnESC_PWR_Auto1.BackColor <> Color.LightGray Then
                btnESC_PWR_Auto1.BackColor = Color.LightGray
            End If
            If PlcData_L_bit(401) = True And btnESC_PWR_Stop1.BackColor <> Color.Tomato Then
                btnESC_PWR_Stop1.BackColor = Color.Tomato
            ElseIf PlcData_L_bit(401) = False And btnESC_PWR_Stop1.BackColor <> Color.DarkRed Then
                btnESC_PWR_Stop1.BackColor = Color.DarkRed
            End If

            If PlcData_M_bit(6) = True And btnManualValveEnable1.BackColor <> Color.Lime Then
                btnManualValveEnable1.BackColor = Color.Lime
            ElseIf PlcData_M_bit(6) = False And btnManualValveEnable1.BackColor <> Color.DarkGreen Then
                btnManualValveEnable1.BackColor = Color.DarkGreen
            End If

            If PlcData_Y_bit(Val(&H101), 4) = True And PlcData_Y_bit(Val(&H101), 5) = False And 'Y1014,5
               btnGate_Valve.BackColor <> Color.Lime Then
                btnGate_Valve.Text = "Gate V/V Opne"
                btnGate_Valve.BackColor = Color.Lime
            ElseIf PlcData_Y_bit(Val(&H101), 4) = False And PlcData_Y_bit(Val(&H101), 5) = False And
               btnGate_Valve.BackColor <> Color.LightGray Then
                btnGate_Valve.Text = "Gate V/V"
                btnGate_Valve.BackColor = Color.LightGray
            End If
            If PlcData_Y_bit(Val(&H101), 5) = True And PlcData_Y_bit(Val(&H101), 4) = False And
               btnGate_Valve.BackColor <> Color.Orange Then
                btnGate_Valve.Text = "Gate V/V Close"
                btnGate_Valve.BackColor = Color.Orange
            ElseIf PlcData_Y_bit(Val(&H101), 5) = False And PlcData_Y_bit(Val(&H101), 4) = False And
               btnGate_Valve.BackColor <> Color.LightGray Then
                btnGate_Valve.Text = "Gate V/V"
                btnGate_Valve.BackColor = Color.LightGray
            End If
            If PlcData_D0(92) = 0 And btnThrottle_Valve.BackColor <> Color.LightGray Then
                btnThrottle_Valve.Text = "Throttle Valve"
                btnThrottle_Valve.BackColor = Color.LightGray
            ElseIf PlcData_D0(92) = 1 And btnThrottle_Valve.BackColor <> Color.Orange Then
                btnThrottle_Valve.Text = "Throttle Close"
                btnThrottle_Valve.BackColor = Color.Orange
            ElseIf PlcData_D0(92) = 2 And btnThrottle_Valve.BackColor <> Color.Lime Then
                btnThrottle_Valve.Text = "Throttle Open"
                btnThrottle_Valve.BackColor = Color.Lime
            ElseIf PlcData_D0(92) = 3 And btnThrottle_Valve.BackColor <> Color.Orange Then
                btnThrottle_Valve.Text = "Pressure Move"
                btnThrottle_Valve.BackColor = Color.Orange
            End If
            If PlcData_D0(93) = 0 And btnTMP_OFF.BackColor <> Color.LightGray Then
                btnTMP_OFF.Text = "TMP OFF"
                btnTMP_OFF.BackColor = Color.LightGray
            ElseIf PlcData_D0(93) = 1 And btnTMP_OFF.BackColor <> Color.Lime Then
                btnTMP_OFF.Text = "TMP Normal"
                btnTMP_OFF.BackColor = Color.Lime
            ElseIf PlcData_D0(93) = 2 And btnTMP_OFF.BackColor <> Color.Orange Then
                btnTMP_OFF.Text = "TMP RUN"
                btnTMP_OFF.BackColor = Color.Orange
            ElseIf PlcData_D0(93) = 3 And btnTMP_OFF.BackColor <> Color.Tomato Then
                btnTMP_OFF.Text = "TMP Alarm"
                btnTMP_OFF.BackColor = Color.Tomato
            End If
            If PlcData_D0(94) = 0 And btnDRY_Pump_Off.BackColor <> Color.LightGray Then
                btnDRY_Pump_Off.Text = "DRY PUMP OFF"
                btnDRY_Pump_Off.BackColor = Color.LightGray
            ElseIf PlcData_D0(94) = 1 And btnDRY_Pump_Off.BackColor <> Color.Chocolate Then
                btnDRY_Pump_Off.Text = "DRY PUMP ON"
                btnDRY_Pump_Off.BackColor = Color.Chocolate
            ElseIf PlcData_D0(94) = 2 And btnDRY_Pump_Off.BackColor <> Color.Orange Then
                btnDRY_Pump_Off.Text = "DRY PUMP RUN"
                btnDRY_Pump_Off.BackColor = Color.Orange
            ElseIf PlcData_D0(94) = 3 And btnDRY_Pump_Off.BackColor <> Color.Tomato Then
                btnDRY_Pump_Off.Text = "DRY PUMP Alarm"
                btnDRY_Pump_Off.BackColor = Color.Tomato
            End If
            If PlcData_Y_bit(Val(&H103), 0) = True And btnRFON.BackColor <> Color.Lime Then
                btnRFON.BackColor = Color.Lime
            ElseIf PlcData_Y_bit(Val(&H103), 0) = False And btnRFON.BackColor <> Color.LightGray Then
                btnRFON.BackColor = Color.LightGray
            End If
            If PlcData_Y_bit(Val(&H103), 1) = True And btnRFOFF.BackColor <> Color.Tomato Then
                btnRFOFF.BackColor = Color.Tomato
            ElseIf PlcData_Y_bit(Val(&H103), 1) = False And btnRFOFF.BackColor <> Color.LightGray Then
                btnRFOFF.BackColor = Color.LightGray
            End If
            If PlcData_Y_bit(Val(&H104), 4) = True And btnDCPWR_HV_ON.BackColor <> Color.Lime Then
                btnDCPWR_HV_ON.BackColor = Color.Lime
            ElseIf PlcData_Y_bit(Val(&H104), 4) = False And btnDCPWR_HV_ON.BackColor <> Color.LightGray Then
                btnDCPWR_HV_ON.BackColor = Color.LightGray
            End If
            If PlcData_Y_bit(Val(&H104), 5) = True And btnDCPWR_HV_OFF.BackColor <> Color.Tomato Then
                btnDCPWR_HV_OFF.BackColor = Color.Tomato
            ElseIf PlcData_Y_bit(Val(&H104), 5) = False And btnDCPWR_HV_OFF.BackColor <> Color.LightGray Then
                btnDCPWR_HV_OFF.BackColor = Color.LightGray
            End If
            If PlcData_Y_bit(Val(&H101), 10) = True And btnSV_Change.BackColor <> Color.Lime Then
                btnSV_Change.BackColor = Color.Lime
            ElseIf PlcData_Y_bit(Val(&H101), 10) = False And btnSV_Change.BackColor <> Color.LightGray Then
                btnSV_Change.BackColor = Color.LightGray
            End If

            lblESCStep1.Text = PlcData_D0(700)
            lblESC_MSG1.Text = SeqMsg(PlcData_D0(70), PlcData_D0(700))

            If SV_Focus = False Then numPowerSupply_SV.Value = DoubleDataRead(PlcData_D0(980), PlcData_D0(981)) / 10
            lblPowerSupply_PV.Text = DoubleDataRead(PlcData_D0(990), PlcData_D0(991)) / 10

            lblLD1.Text = Work_data_String_D(50450, 3)   'PlcData_D0(50450) & PlcData_D0(50451) & PlcData_D0(50452)
            lblTN1.Text = Work_data_String_D(50550, 3)   'PlcData_D0(50550) & PlcData_D0(50551) & PlcData_D0(50552)

            If SV_Focus = False Then numRF_Power_SV1.Value = PlcData_D0(1054)
            lblRF_Power_Fwd1.Text = PlcData_D0(2005)
            lblRF_Power_Ref1.Text = PlcData_D0(2004)
            If SV_Focus = False Then numDC_Power_SV1.Value = PlcData_D0(1050)
            lblDC_Power_PV1.Text = PlcData_D0(12001)

            'Debug.Print("db= " & DoubleDataRead(PlcData_D0(8530), PlcData_D0(8531)))
            'lblDC_Power_Keysight.Text = "0.000"
            'lblDC_Power_Keysight.Text = DoubleDataRead(PlcData_D0(8530), PlcData_D0(8531)) / 1000
            byteArray(0) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(8530)), 4), 3, 2), 16)
            byteArray(1) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(8530)), 4), 1, 2), 16)
            byteArray(2) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(8531)), 4), 3, 2), 16)
            byteArray(3) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(8531)), 4), 1, 2), 16)
            lblDC_Power_Keysight.Text = Format(CDbl(BAToSingle(byteArray, 0)), "0.000")
            lblLeak_Current_P1.Text = Work_data_String_D(30450, 2)   'PlcData_D0(30450) & PlcData_D0(30451)
            lblLeak_Current_N1.Text = Work_data_String_D(30550, 2)   'PlcData_D0(30550) & PlcData_D0(30551)
            lblThrottleValve_DataRD_Pressure.Text = Work_data_String_D(10401, 3)
            'lblThrottleValve_DataRD_Pressure.Text = Chr(Convert.ToSByte(Mid(Hex(PlcData_D0(10401)), 3, 2), 16)) &
            '                                        Chr(Convert.ToSByte(Mid(Hex(PlcData_D0(10401)), 1, 2), 16)) &
            '                                        Chr(Convert.ToSByte(Mid(Hex(PlcData_D0(10402)), 3, 2), 16)) &
            '                                        Chr(Convert.ToSByte(Mid(Hex(PlcData_D0(10402)), 1, 2), 16)) &
            '                                        Chr(Convert.ToSByte(Mid(Hex(PlcData_D0(10403)), 3, 2), 16)) &
            '                                        Chr(Convert.ToSByte(Mid(Hex(PlcData_D0(10403)), 1, 2), 16))

            If PlcData_L_bit(130) = True And lblBSP_Pressure_Warning_Lamp1.BackColor <> Color.Red Then
                lblBSP_Pressure_Warning_Lamp1.BackColor = Color.Red
            ElseIf PlcData_L_bit(130) = False And lblBSP_Pressure_Warning_Lamp1.BackColor <> Color.DarkRed Then
                lblBSP_Pressure_Warning_Lamp1.BackColor = Color.DarkRed
            End If

            If SV_Focus = False Then numBSP_Pressure_Alarm_SV.Value = (PlcData_D0(210) / 10)
            If SV_Focus = False Then numBSP_Pressure_Alarm_SV_Square.Value = PlcData_D0(211)

            ''Debug.Print("D211 = " & PlcData_D0(211))
            'Debug.Print(Mid(Hex(PlcData_D0(140)), 3, 2))
            'Debug.Print(Format(Hex(PlcData_D0(140)), "#0000"))
            'Debug.Print("&H" & Strings.Right("0000" & Hex(PlcData_D0(140)), 4))  ':&H2174
            'Debug.Print(Hex(PlcData_D0(140)))
            ''Debug.Print(Hex(PlcData_D0(140)).)

            '** 부동소수
            lblBSP_Pressure1.Text = (PlcData_D0(200) / 10) & " X 10 " & PlcData_D0(201)
            byteArray(0) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(140)), 4), 3, 2), 16)
            byteArray(1) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(140)), 4), 1, 2), 16)
            byteArray(2) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(141)), 4), 3, 2), 16)
            byteArray(3) = Convert.ToInt16(Mid(Strings.Right("0000" & Hex(PlcData_D0(141)), 4), 1, 2), 16)
            lblBSP_Pressure2.Text = BAToSingle(byteArray, 0)

            lblLine_Vacuum1.Text = (PlcData_D0(100) / 10) & " X 10 " & PlcData_D0(101)
            lblHi_Vacuum1.Text = (PlcData_D0(110) / 10) & " X 10 " & PlcData_D0(111)

            If SV_Focus = False Then numMFC1_SV.Value = PlcData_D0(1020)
            lblMFC1_PV.Text = PlcData_D0(2000)
            If SV_Focus = False Then numMFC2_SV.Value = Format(PlcData_D0(1022) / 10, "#.0")
            lblMFC2_PV.Text = PlcData_D0(2002) / 10

            If SV_Focus = False Then numDry_Off_Delay_SV.Value = DoubleDataRead(PlcData_ZR(120), PlcData_ZR(121))  'PlcData_ZR(120)
            lblDry_Off_Delay_PV.Text = DoubleDataRead(PlcData_D0(910), PlcData_D0(911))

            If PlcData_X_bit(Val(&H10), 5) = True Then
                picN2_X105.Image = ImageList1.Images(2)
            Else
                picN2_X105.Image = ImageList1.Images(0)
            End If
            If PlcData_Y_bit(Val(&H12), 8) = True Then      'Y128
                picN2_VV_Y128.Image = ImageList1.Images(26)
                picN2_Y128.Image = ImageList1.Images(2)
                picN2__Y128.Image = ImageList1.Images(2)
            Else
                picN2_VV_Y128.Image = ImageList1.Images(24)
                picN2_Y128.Image = ImageList1.Images(0)
                picN2__Y128.Image = ImageList1.Images(0)
            End If
            If PlcData_Y_bit(Val(&H15), 12) = True Then
                picN2_VV_Y15C.Image = ImageList1.Images(29)
            Else
                picN2_VV_Y15C.Image = ImageList1.Images(27)
            End If
            If PlcData_Y_bit(Val(&H13), 0) = True Then
                picN2_Y130.Image = ImageList1.Images(5)
                picAr2_Y130.Image = ImageList1.Images(2)
                picAr2_VV1_Y130.Image = ImageList1.Images(26)
                picAr2__Y130.Image = ImageList1.Images(2)
                picAr2___Y130.Image = ImageList1.Images(11)
                picAr2____Y130.Image = ImageList1.Images(5)
            Else
                picN2_Y130.Image = ImageList1.Images(3)
                picAr2_Y130.Image = ImageList1.Images(0)
                picAr2_VV1_Y130.Image = ImageList1.Images(24)
                picAr2__Y130.Image = ImageList1.Images(0)
                picAr2___Y130.Image = ImageList1.Images(9)
                picAr2____Y130.Image = ImageList1.Images(3)
            End If
            If PlcData_X_bit(Val(&H10), 6) = True Then
                picAr1_T_X106.Image = ImageList1.Images(23)
                picAr1_X106.Image = ImageList1.Images(2)
                picAr1__X106.Image = ImageList1.Images(5)
                picAr2_X106.Image = ImageList1.Images(2)
                picAr2_T_X106.Image = ImageList1.Images(20)
                picAr2__X106.Image = ImageList1.Images(5)
                picAr2___X106.Image = ImageList1.Images(8)
            Else
                picAr1_T_X106.Image = ImageList1.Images(21)
                picAr1_X106.Image = ImageList1.Images(0)
                picAr1__X106.Image = ImageList1.Images(3)
                picAr2_X106.Image = ImageList1.Images(0)
                picAr2_T_X106.Image = ImageList1.Images(18)
                picAr2__X106.Image = ImageList1.Images(3)
                picAr2___X106.Image = ImageList1.Images(6)
            End If
            If PlcData_Y_bit(Val(&H12), 10) = True Then
                picAr1_VV_Y12A.Image = ImageList1.Images(26)
            Else
                picAr1_VV_Y12A.Image = ImageList1.Images(24)
            End If
            If PlcData_Y_bit(Val(&H12), 12) = True Then
                picAr1_VV1_Y12C.Image = ImageList1.Images(26)
                picAr1__Y12C.Image = ImageList1.Images(2)
            Else
                picAr1_VV1_Y12C.Image = ImageList1.Images(24)
                picAr1__Y12C.Image = ImageList1.Images(0)
            End If
            If PlcData_Y_bit(Val(&H12), 14) = True Then
                picAr2_VV_Y12E.Image = ImageList1.Images(26)
            Else
                picAr2_VV_Y12E.Image = ImageList1.Images(24)
            End If
            If PlcData_Y_bit(Val(&H13), 2) = True Then
                picDry2_Y132_4.Image = ImageList1.Images(4)
                picDry2_T_Y132_4.Image = ImageList1.Images(19)
                picDry21_Y132_4.Image = ImageList1.Images(1)
                picDry21__Y132_4.Image = ImageList1.Images(13)
                picDry21___Y132_4.Image = ImageList1.Images(4)
                picDry22_Y132_4.Image = ImageList1.Images(4)
                picDry21_VV_Y132.Image = ImageList1.Images(28)
            Else
                picDry2_Y132_4.Image = ImageList1.Images(3)
                picDry2_T_Y132_4.Image = ImageList1.Images(18)
                picDry21_Y132_4.Image = ImageList1.Images(0)
                picDry21__Y132_4.Image = ImageList1.Images(12)
                picDry21___Y132_4.Image = ImageList1.Images(3)
                picDry22_Y132_4.Image = ImageList1.Images(3)
                picDry21_VV_Y132.Image = ImageList1.Images(27)
            End If
            If PlcData_Y_bit(Val(&H13), 4) = True Then
                picDry2_Y132_4.Image = ImageList1.Images(4)
                picDry2_T_Y132_4.Image = ImageList1.Images(19)
                picDry21_Y132_4.Image = ImageList1.Images(1)
                picDry21__Y132_4.Image = ImageList1.Images(13)
                picDry21___Y132_4.Image = ImageList1.Images(4)
                picDry22_Y132_4.Image = ImageList1.Images(4)
                picDry22_VV_Y134.Image = ImageList1.Images(28)
            Else
                picDry2_Y132_4.Image = ImageList1.Images(3)
                picDry2_T_Y132_4.Image = ImageList1.Images(18)
                picDry21_Y132_4.Image = ImageList1.Images(0)
                picDry21__Y132_4.Image = ImageList1.Images(12)
                picDry21___Y132_4.Image = ImageList1.Images(3)
                picDry22_Y132_4.Image = ImageList1.Images(3)
                picDry22_VV_Y134.Image = ImageList1.Images(27)
            End If
            If PlcData_X_bit(Val(&H14), 13) = True Then
                picDry21_X14D.Image = ImageList1.Images(4)
                picDry22_X14D.Image = ImageList1.Images(4)
                picDry21__X14D.Image = ImageList1.Images(7)
                picDry21___X14D.Image = ImageList1.Images(1)
                picDry2_T_X14D.Image = ImageList1.Images(16)
                picDry2_X14D.Image = ImageList1.Images(1)
                picDry1_X14D.Image = ImageList1.Images(4)
                picDry1_T_X14D.Image = ImageList1.Images(19)
                picDry1__X14D.Image = ImageList1.Images(4)
            Else
                picDry21_X14D.Image = ImageList1.Images(3)
                picDry22_X14D.Image = ImageList1.Images(3)
                picDry21__X14D.Image = ImageList1.Images(6)
                picDry21___X14D.Image = ImageList1.Images(0)
                picDry2_T_X14D.Image = ImageList1.Images(15)
                picDry2_X14D.Image = ImageList1.Images(0)
                picDry1_X14D.Image = ImageList1.Images(3)
                picDry1_T_X14D.Image = ImageList1.Images(18)
                picDry1__X14D.Image = ImageList1.Images(3)
            End If
            If PlcData_Y_bit(Val(&H13), 6) = True Then
                picDry1_Y136.Image = ImageList1.Images(4)
                picDry1__Y136.Image = ImageList1.Images(4)
                picDry1_VV_Y136.Image = ImageList1.Images(28)
            Else
                picDry1_Y136.Image = ImageList1.Images(3)
                picDry1__Y136.Image = ImageList1.Images(3)
                picDry1_VV_Y136.Image = ImageList1.Images(27)
            End If

            If PlcData_Y_bit(Val(&H13), 12) = True Or PlcData_Y_bit(Val(&H13), 13) = True Then
                btnHeaterON.BackColor = Color.Lime
                btnHeaterOFF.BackColor = Color.LightGray
            Else
                btnHeaterON.BackColor = Color.LightGray
                btnHeaterOFF.BackColor = Color.Lime
            End If

            If PlcData_M_bit(410) = True Then
                panManual_ESC_Step.Visible = True
                grpManualPowerSupply.Visible = True
            Else
                panManual_ESC_Step.Visible = False
                grpManualPowerSupply.Visible = False
            End If
            If PlcData_L_bit(19) = True Then
                lblChamberRangeOver1.Visible = True
            Else
                lblChamberRangeOver1.Visible = False
            End If

            If panValve.Visible = True Then
                Select Case panValve.Tag
                    Case 1
                        If PlcData_L_bit(1000) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1000) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1001) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1001) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 0) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 0) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 1) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 1) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If


                    Case 2
                        If PlcData_L_bit(1002) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1002) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1003) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1003) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 2) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 2) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 3) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 3) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 3
                        If PlcData_L_bit(1004) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1004) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1005) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1005) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 4) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 4) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 5) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 5) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 4
                        If PlcData_L_bit(1006) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1006) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1007) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1007) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 6) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 6) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 7) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 7) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 5
                        If PlcData_L_bit(1008) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1008) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1009) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1009) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 8) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 8) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 9) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 9) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 6
                        If PlcData_L_bit(1020) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1020) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1021) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1021) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 10) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 10) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 11) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 11) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 7
                        If PlcData_L_bit(1022) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1022) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1023) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1023) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 12) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 12) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 13) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 13) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 8
                        If PlcData_L_bit(1024) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1024) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1025) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1025) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H100), 14) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 14) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H100), 15) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H100), 15) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 9
                        lblThrottleValve_Position_PV.Text = Work_data_String_D(10501, 3)   'PlcData_D0(10501) & PlcData_D0(10502) & PlcData_D0(10503)
                        If SV_Focus = False Then numBaratonGauge_SV.Value = Work_data_String_D(1080, 3)    'PlcData_D0(1080) & PlcData_D0(1081) & PlcData_D0(1082)
                        lblBaratonGauge_PV1.Text = Work_data_String_D(10401, 3)    'PlcData_D0(10401) & PlcData_D0(10402) & PlcData_D0(10403)
                        If PlcData_L_bit(1026) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1026) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1027) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1027) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1028) = True And lblPressureinterlock_Lamp.BackColor <> Color.Red Then
                            lblPressureinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1028) = False And lblPressureinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblPressureinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H101), 0) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 0) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H101), 1) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 1) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H101), 2) = True And btnThrottleValve_PositionMove.BackColor <> Color.Lime Then
                            btnThrottleValve_PositionMove.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 2) = False And btnThrottleValve_PositionMove.BackColor <> Color.LightGray Then
                            btnThrottleValve_PositionMove.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H101), 10) = True And btnBaratonGaugeSV_Change.BackColor <> Color.Lime Then
                            btnBaratonGaugeSV_Change.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 10) = False And btnBaratonGaugeSV_Change.BackColor <> Color.LightGray Then
                            btnBaratonGaugeSV_Change.BackColor = Color.LightGray
                        End If

                    Case 10
                        If PlcData_L_bit(1030) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1030) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1031) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1031) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H102), 0) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H102), 0) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H102), 1) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H102), 1) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 11
                        If PlcData_L_bit(1032) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1032) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1033) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1033) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H102), 2) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H102), 2) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H102), 3) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H102), 3) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 12
                        If PlcData_L_bit(1034) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1034) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1035) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1035) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H101), 4) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 4) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H101), 5) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 5) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If

                    Case 13
                        If PlcData_L_bit(1036) = True And lblOpeninterlock_Lamp.BackColor <> Color.Red Then
                            lblOpeninterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1036) = False And lblOpeninterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblOpeninterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_L_bit(1037) = True And lblCloseinterlock_Lamp.BackColor <> Color.Red Then
                            lblCloseinterlock_Lamp.BackColor = Color.Red
                        ElseIf PlcData_L_bit(1037) = False And lblCloseinterlock_Lamp.BackColor <> Color.DarkRed Then
                            lblCloseinterlock_Lamp.BackColor = Color.DarkRed
                        End If
                        If PlcData_Y_bit(Val(&H101), 6) = True And btnValveOpen.BackColor <> Color.Lime Then
                            btnValveOpen.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 6) = False And btnValveOpen.BackColor <> Color.LightGray Then
                            btnValveOpen.BackColor = Color.LightGray
                        End If
                        If PlcData_Y_bit(Val(&H101), 7) = True And btnValveClose.BackColor <> Color.Lime Then
                            btnValveClose.BackColor = Color.Lime
                        ElseIf PlcData_Y_bit(Val(&H101), 7) = False And btnValveClose.BackColor <> Color.LightGray Then
                            btnValveClose.BackColor = Color.LightGray
                        End If
                End Select
            End If

        ElseIf TabControl.SelectedIndex = 2 Then    'Recipe

            If SV_Focus = True Then Exit Sub

            DataGridView1(1, 0).Value = PlcData_ZR(20)
            DataGridView1(1, 1).Value = PlcData_ZR(22) / 10
            DataGridView1(1, 2).Value = PlcData_ZR(30) / 10
            DataGridView1(1, 3).Value = PlcData_ZR(31)
            DataGridView1(1, 4).Value = PlcData_ZR(40) / 10
            DataGridView1(1, 5).Value = PlcData_ZR(41)
            DataGridView1(1, 6).Value = PlcData_ZR(60) / 10
            DataGridView1(1, 7).Value = PlcData_ZR(61)
            DataGridView1(1, 8).Value = PlcData_ZR(70) / 10
            DataGridView1(1, 9).Value = PlcData_ZR(71)
            DataGridView1(1, 10).Value = PlcData_ZR(50)
            DataGridView1(1, 11).Value = PlcData_ZR(54)
            DataGridView1(1, 12).Value = Work_data_String_ZR(80, 3)
            DataGridView1(1, 13).Value = DoubleDataRead(PlcData_ZR(92), PlcData_ZR(93)) / 10
            DataGridView1(1, 14).Value = PlcData_ZR(110)
            DataGridView1(1, 15).Value = DoubleDataRead(PlcData_ZR(112), PlcData_ZR(113)) / 10
            DataGridView1(1, 16).Value = DoubleDataRead(PlcData_ZR(94), PlcData_ZR(95)) / 10
            DataGridView1(1, 17).Value = DoubleDataRead(PlcData_ZR(96), PlcData_ZR(97)) / 10
            DataGridView1(1, 18).Value = DoubleDataRead(PlcData_ZR(90), PlcData_ZR(91)) / 10
            DataGridView1(1, 19).Value = DoubleDataRead(PlcData_ZR(98), PlcData_ZR(99)) / 10
            DataGridView1(1, 20).Value = DoubleDataRead(PlcData_ZR(102), PlcData_ZR(103)) / 10
            DataGridView1(1, 21).Value = DoubleDataRead(PlcData_ZR(104), PlcData_ZR(105)) / 10
            DataGridView1(1, 22).Value = DoubleDataRead(PlcData_ZR(100), PlcData_ZR(101)) / 10
            DataGridView1(1, 23).Value = DoubleDataRead(PlcData_ZR(106), PlcData_ZR(107)) / 10
            DataGridView1(1, 24).Value = DoubleDataRead(PlcData_ZR(108), PlcData_ZR(109)) / 10

            If PlcData_ZR(110) = 1 Then
                lblOnly_DC.BackColor = Color.OliveDrab
                lblDC_RF.BackColor = Color.Black
            Else
                lblOnly_DC.BackColor = Color.Black
                lblDC_RF.BackColor = Color.OliveDrab
            End If


        ElseIf TabControl.SelectedIndex = 4 Then    'Temp
            lblTemp1.Text = UP35A_temp
            lblTemp2.Text = UP35A_temp1
            numTempSV1.Value = UP35A_TSP
            numTempSV2.Value = UP35A_TSP1
            numTagetTime1.Value = UP35A_TSP_Time
            numTagetTime2.Value = UP35A_TSP_Time1

            If UP35A_RunStop = 1 Then
                btnHeaterON.BackColor = Color.Lime
                btnHeaterOFF.BackColor = Color.LightGray
            Else
                btnHeaterON.BackColor = Color.LightGray
                btnHeaterOFF.BackColor = Color.Lime
            End If
        End If

    End Sub
    Public Sub RealDataRead_Old()
        'Dim i As Integer
        'Dim iReturnCode As Integer              'Return code

        'Try

        '    If PLC_Port_Open_OK = True Then
        '        Call ActUtl1_Read("D10000", PLC_Data_CNT_, PlcData)          'PLC Data Read

        '        '** Live bit
        '        iReturnCode = AxActUtlType1.WriteDeviceBlock("D10000", 1, 1)



        '        '** Machine Status
        '        Select Case PlcData(1)
        '            Case 0  'STOP
        '                If lblMC_Status.BackColor <> Color.Orange Then
        '                    lblMC_Status.BackColor = Color.Orange
        '                    lblMC_Status.ForeColor = Color.Black
        '                    lblMC_Status.Text = "STOP"
        '                    Call EQ_TB1_MES_Trnas("STOP")
        '                End If
        '            Case 1  'RUN
        '                If lblMC_Status.BackColor <> Color.GreenYellow Then
        '                    lblMC_Status.BackColor = Color.GreenYellow
        '                    lblMC_Status.ForeColor = Color.Blue
        '                    lblMC_Status.Text = "RUN"
        '                    Call EQ_TB1_MES_Trnas("RUN")
        '                End If
        '            Case 2  'TROUBLE
        '                If lblMC_Status.BackColor <> Color.Tomato Then
        '                    lblMC_Status.BackColor = Color.Tomato
        '                    lblMC_Status.ForeColor = Color.Black
        '                    lblMC_Status.Text = "ALARM"
        '                    Call EQ_TB1_MES_Trnas("ALARM")
        '                End If

        '            Case Else
        '                'Status_Label(PLC_Num).Text = " "
        '                'Status_Label(PLC_Num).BackColor = Color.AliceBlue
        '        End Select

        '        '**투입부 파렛 투입 가능 
        '        If PlcData(138) = 1 Then
        '            lbl0_inLet_Possible.BackColor = Color.DimGray
        '            lbl0_inLet_imPossible.BackColor = Color.GreenYellow
        '        Else
        '            lbl0_inLet_Possible.BackColor = Color.GreenYellow
        '            lbl0_inLet_imPossible.BackColor = Color.DimGray
        '        End If


        '        '** Work Data GET
        '        Pos_inLet(0, 0) = Work_data_String(Pos_inLet_StartAdr_, 20)                 '** inLet Position Work iD
        '        Pos_inLet(0, 1) = Work_data_String(Pos_inLet_StartAdr_ + 20, 10)            '** inLet Position MAT iD

        '        Pos_Buffer(0, 0) = Work_data_String(Pos_Buffer_StartAdr_ + 500, 20)                '** Buffer Position Work iD
        '        Pos_Buffer(1, 0) = Work_data_String(Pos_Buffer_StartAdr_ + 400, 20)
        '        Pos_Buffer(2, 0) = Work_data_String(Pos_Buffer_StartAdr_ + 300, 20)
        '        Pos_Buffer(3, 0) = Work_data_String(Pos_Buffer_StartAdr_ + 200, 20)
        '        Pos_Buffer(4, 0) = Work_data_String(Pos_Buffer_StartAdr_ + 100, 20)
        '        Pos_Buffer(5, 0) = Work_data_String(Pos_Buffer_StartAdr_, 20)
        '        Pos_Buffer(0, 1) = Work_data_String(Pos_Buffer_StartAdr_ + 520, 10)           '** Buffer Position MAT iD
        '        Pos_Buffer(1, 1) = Work_data_String(Pos_Buffer_StartAdr_ + 420, 10)
        '        Pos_Buffer(2, 1) = Work_data_String(Pos_Buffer_StartAdr_ + 320, 10)
        '        Pos_Buffer(3, 1) = Work_data_String(Pos_Buffer_StartAdr_ + 220, 10)
        '        Pos_Buffer(4, 1) = Work_data_String(Pos_Buffer_StartAdr_ + 120, 10)
        '        Pos_Buffer(5, 1) = Work_data_String(Pos_Buffer_StartAdr_ + 20, 10)
        '        Pos_Buffer(0, 2) = DoubleDataRead(PlcData(Pos_Buffer_StartAdr_ + 530), PlcData(Pos_Buffer_StartAdr_ + 131))     '** Buffer Position Pallet Petern
        '        Pos_Buffer(1, 2) = DoubleDataRead(PlcData(Pos_Buffer_StartAdr_ + 430), PlcData(Pos_Buffer_StartAdr_ + 131))
        '        Pos_Buffer(2, 2) = DoubleDataRead(PlcData(Pos_Buffer_StartAdr_ + 330), PlcData(Pos_Buffer_StartAdr_ + 131))
        '        Pos_Buffer(3, 2) = DoubleDataRead(PlcData(Pos_Buffer_StartAdr_ + 230), PlcData(Pos_Buffer_StartAdr_ + 131))
        '        Pos_Buffer(4, 2) = DoubleDataRead(PlcData(Pos_Buffer_StartAdr_ + 130), PlcData(Pos_Buffer_StartAdr_ + 131))
        '        Pos_Buffer(5, 2) = DoubleDataRead(PlcData(Pos_Buffer_StartAdr_ + 30), PlcData(Pos_Buffer_StartAdr_ + 31))

        '        Pos_inStacker(0, 0) = Work_data_String(Pos_inStacker_StartAdr_, 20)         '** inStacker Position Work iD
        '        Pos_inStacker(0, 1) = Work_data_String(Pos_inStacker_StartAdr_ + 20, 10)    '** inStacker Position MAT iD
        '        Pos_inStacker(0, 2) = DoubleDataRead(PlcData(Pos_inStacker_StartAdr_ + 30), PlcData(Pos_inStacker_StartAdr_ + 31))    '** inStacker Position Pallet Petern
        '        Pos_inStacker(0, 5) = PlcData(Pos_inStacker_StartAdr_ + 36)                 '** inStacker Position MAT iD
        '        Pos_OutStacker(0, 0) = Work_data_String(Pos_OutStacker_StartAdr_, 20)       '** OutStacker Position Work iD
        '        Pos_OutStacker(0, 1) = Work_data_String(Pos_OutStacker_StartAdr_ + 20, 10)  '** OutStacker Position MAT iD
        '        Pos_OutStacker(0, 2) = DoubleDataRead(PlcData(Pos_OutStacker_StartAdr_ + 30), PlcData(Pos_inStacker_StartAdr_ + 31))    '** OutStacker Position Pallet Petern
        '        Pos_OutStacker(0, 5) = PlcData(Pos_OutStacker_StartAdr_ + 36)

        '        Pos_Work(0, 0) = Work_data_String(Pos_Work_StartAdr_, 20)               '** Work Position Work iD
        '        Pos_Work(1, 0) = Work_data_String(Pos_Work_StartAdr_ + 100, 20)
        '        Pos_Work(2, 0) = Work_data_String(Pos_Work_StartAdr_ + 200, 20)
        '        Pos_Work(3, 0) = Work_data_String(Pos_Work_StartAdr_ + 300, 20)
        '        Pos_Work(4, 0) = Work_data_String(Pos_Work_StartAdr_ + 400, 20)
        '        Pos_Work(5, 0) = Work_data_String(Pos_Work_StartAdr_ + 500, 20)
        '        Pos_Work(0, 1) = Work_data_String(Pos_Work_StartAdr_ + 20, 10)          '** Work Position MAT iD
        '        Pos_Work(1, 1) = Work_data_String(Pos_Work_StartAdr_ + 120, 10)
        '        Pos_Work(2, 1) = Work_data_String(Pos_Work_StartAdr_ + 220, 10)
        '        Pos_Work(3, 1) = Work_data_String(Pos_Work_StartAdr_ + 320, 10)
        '        Pos_Work(4, 1) = Work_data_String(Pos_Work_StartAdr_ + 420, 10)
        '        Pos_Work(5, 1) = Work_data_String(Pos_Work_StartAdr_ + 520, 10)
        '        Pos_Work(0, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 30), PlcData(Pos_Work_StartAdr_ + 31))    '** Work Position Pallet Petern
        '        Pos_Work(1, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 130), PlcData(Pos_Work_StartAdr_ + 131))
        '        Pos_Work(2, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 230), PlcData(Pos_Work_StartAdr_ + 231))
        '        Pos_Work(3, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 330), PlcData(Pos_Work_StartAdr_ + 331))
        '        Pos_Work(4, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 430), PlcData(Pos_Work_StartAdr_ + 431))
        '        Pos_Work(5, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 530), PlcData(Pos_Work_StartAdr_ + 531))
        '        Pos_Work(0, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 32), PlcData(Pos_Work_StartAdr_ + 33))    '** Work SV Weight
        '        Pos_Work(1, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 132), PlcData(Pos_Work_StartAdr_ + 133))
        '        Pos_Work(2, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 232), PlcData(Pos_Work_StartAdr_ + 233))
        '        Pos_Work(3, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 332), PlcData(Pos_Work_StartAdr_ + 333))
        '        Pos_Work(4, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 432), PlcData(Pos_Work_StartAdr_ + 433))
        '        Pos_Work(5, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 532), PlcData(Pos_Work_StartAdr_ + 533))
        '        Pos_Work(0, 6) = PlcData(Pos_Work_StartAdr_ + 40)          '** Work END Code
        '        Pos_Work(1, 6) = PlcData(Pos_Work_StartAdr_ + 140)
        '        Pos_Work(2, 6) = PlcData(Pos_Work_StartAdr_ + 240)
        '        Pos_Work(3, 6) = PlcData(Pos_Work_StartAdr_ + 340)
        '        Pos_Work(4, 6) = PlcData(Pos_Work_StartAdr_ + 440)
        '        Pos_Work(5, 6) = PlcData(Pos_Work_StartAdr_ + 540)

        '        'Pos_Work(0, 0) = Work_data_String(Pos_Work_StartAdr_ + 500, 20)               '** Work Position Work iD
        '        'Pos_Work(1, 0) = Work_data_String(Pos_Work_StartAdr_ + 400, 20)
        '        'Pos_Work(2, 0) = Work_data_String(Pos_Work_StartAdr_ + 300, 20)
        '        'Pos_Work(3, 0) = Work_data_String(Pos_Work_StartAdr_ + 200, 20)
        '        'Pos_Work(4, 0) = Work_data_String(Pos_Work_StartAdr_ + 100, 20)
        '        'Pos_Work(5, 0) = Work_data_String(Pos_Work_StartAdr_, 20)

        '        'Pos_Work(0, 1) = Work_data_String(Pos_Work_StartAdr_ + 520, 10)          '** Work Position MAT iD
        '        'Pos_Work(1, 1) = Work_data_String(Pos_Work_StartAdr_ + 320, 10)
        '        'Pos_Work(2, 1) = Work_data_String(Pos_Work_StartAdr_ + 420, 10)
        '        'Pos_Work(3, 1) = Work_data_String(Pos_Work_StartAdr_ + 220, 10)
        '        'Pos_Work(4, 1) = Work_data_String(Pos_Work_StartAdr_ + 120, 10)
        '        'Pos_Work(5, 1) = Work_data_String(Pos_Work_StartAdr_ + 20, 10)

        '        'Pos_Work(0, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 530), PlcData(Pos_Work_StartAdr_ + 531))    '** Work Position Pallet Petern
        '        'Pos_Work(1, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 430), PlcData(Pos_Work_StartAdr_ + 431))
        '        'Pos_Work(2, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 330), PlcData(Pos_Work_StartAdr_ + 331))
        '        'Pos_Work(3, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 230), PlcData(Pos_Work_StartAdr_ + 231))
        '        'Pos_Work(4, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 130), PlcData(Pos_Work_StartAdr_ + 131))
        '        'Pos_Work(5, 2) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 30), PlcData(Pos_Work_StartAdr_ + 31))

        '        'Pos_Work(0, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 532), PlcData(Pos_Work_StartAdr_ + 533))    '** Work SV Weight
        '        'Pos_Work(1, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 432), PlcData(Pos_Work_StartAdr_ + 433))
        '        'Pos_Work(2, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 332), PlcData(Pos_Work_StartAdr_ + 333))
        '        'Pos_Work(3, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 232), PlcData(Pos_Work_StartAdr_ + 233))
        '        'Pos_Work(4, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 132), PlcData(Pos_Work_StartAdr_ + 133))
        '        'Pos_Work(5, 3) = DoubleDataRead(PlcData(Pos_Work_StartAdr_ + 32), PlcData(Pos_Work_StartAdr_ + 33))

        '        'Pos_Work(0, 6) = PlcData(Pos_Work_StartAdr_ + 540)          '** Work END Code
        '        'Pos_Work(1, 6) = PlcData(Pos_Work_StartAdr_ + 440)
        '        'Pos_Work(2, 6) = PlcData(Pos_Work_StartAdr_ + 340)
        '        'Pos_Work(3, 6) = PlcData(Pos_Work_StartAdr_ + 240)
        '        'Pos_Work(4, 6) = PlcData(Pos_Work_StartAdr_ + 140)
        '        'Pos_Work(5, 6) = PlcData(Pos_Work_StartAdr_ + 40)
        '        ''Pos_OutLet(0, 6) = Pos_Work(0, 6)
        '        ''Pos_OutLet(1, 6) = Pos_Work(1, 6)
        '        ''Pos_OutLet(2, 6) = Pos_Work(2, 6)
        '        ''Pos_OutLet(3, 6) = Pos_Work(3, 6)
        '        ''Pos_OutLet(4, 6) = Pos_Work(4, 6)
        '        ''Pos_OutLet(5, 6) = Pos_Work(5, 6)

        '        Pos_ByPass(0, 0) = Work_data_String(Pos_ByPass_StartAdr_, 20)           '** ByPass Position Work iD
        '        Pos_ByPass(1, 0) = Work_data_String(Pos_ByPass_StartAdr_ + 100, 20)
        '        Pos_ByPass(2, 0) = Work_data_String(Pos_ByPass_StartAdr_ + 200, 20)
        '        Pos_ByPass(0, 1) = Work_data_String(Pos_ByPass_StartAdr_ + 20, 10)      '** ByPass Position MAT iD
        '        Pos_ByPass(1, 1) = Work_data_String(Pos_ByPass_StartAdr_ + 120, 10)
        '        Pos_ByPass(2, 1) = Work_data_String(Pos_ByPass_StartAdr_ + 220, 10)



        '        Call ActUtl1_Read("D5001", 6, WorkRunData)              '** Work Pos Status
        '        Call ActUtl1_Read("D5500", 240, WorkOderData)
        '        MesWorkOder_ID(0, 0) = Work_Oder_String(0)             '** Work id GET
        '        MesWorkOder_ID(1, 0) = Work_Oder_String(20)
        '        MesWorkOder_ID(2, 0) = Work_Oder_String(40)
        '        MesWorkOder_ID(3, 0) = Work_Oder_String(60)
        '        MesWorkOder_ID(4, 0) = Work_Oder_String(80)
        '        MesWorkOder_ID(5, 0) = Work_Oder_String(100)
        '        MesWorkOder_MatID(0, 0) = Work_Oder_String(120)     '** Work MAT id GET
        '        MesWorkOder_MatID(1, 0) = Work_Oder_String(140)
        '        MesWorkOder_MatID(2, 0) = Work_Oder_String(160)
        '        MesWorkOder_MatID(3, 0) = Work_Oder_String(180)
        '        MesWorkOder_MatID(4, 0) = Work_Oder_String(200)
        '        MesWorkOder_MatID(5, 0) = Work_Oder_String(220)
        '        Call ActUtl1_Read("D5250", 60, WorkOderSVData)
        '        MesWorkOder_SV(0, 0) = Work_Oder_SV_String(0)       '** Work SV Weight GET
        '        MesWorkOder_SV(1, 0) = Work_Oder_SV_String(10)
        '        MesWorkOder_SV(2, 0) = Work_Oder_SV_String(20)
        '        MesWorkOder_SV(3, 0) = Work_Oder_SV_String(30)
        '        MesWorkOder_SV(4, 0) = Work_Oder_SV_String(40)
        '        MesWorkOder_SV(5, 0) = Work_Oder_SV_String(50)
        '        Call ActUtl1_Read("W18A", 2, LoadCellData)          '** 1 Line LoadCell
        '        Pos_OutLet(0, 4) = DoubleDataRead(LoadCellData(0), LoadCellData(1))         'Pos_OutLet(0, 4) 
        '        Call ActUtl1_Read("W17A", 2, LoadCellData)          '** 2 Line LoadCell
        '        Pos_OutLet(1, 4) = DoubleDataRead(LoadCellData(0), LoadCellData(1))         'Pos_OutLet(1, 4) 
        '        Call ActUtl1_Read("W16A", 2, LoadCellData)          '** 3 Line LoadCell
        '        Pos_OutLet(2, 4) = DoubleDataRead(LoadCellData(0), LoadCellData(1))         'Pos_OutLet(2, 4) 
        '        Call ActUtl1_Read("W15A", 2, LoadCellData)          '** 4 Line LoadCell
        '        Pos_OutLet(3, 4) = DoubleDataRead(LoadCellData(0), LoadCellData(1))         'Pos_OutLet(3, 4) 
        '        Call ActUtl1_Read("W14A", 2, LoadCellData)          '** 5 Line LoadCell
        '        Pos_OutLet(4, 4) = DoubleDataRead(LoadCellData(0), LoadCellData(1))         'Pos_OutLet(4, 4) 
        '        Call ActUtl1_Read("W13A", 2, LoadCellData)          '** 6 Line LoadCell
        '        Pos_OutLet(5, 4) = DoubleDataRead(LoadCellData(0), LoadCellData(1))         'Pos_OutLet(5, 4) 

        '        Select Case Pos_inStacker(0, 5)                     '** inStacker 경로
        '            Case 0
        '                lbl20_Stacker_Target.Text = ""
        '            Case 1
        '                lbl20_Stacker_Target.Text = "버퍼 1로 이동"
        '            Case 2
        '                lbl20_Stacker_Target.Text = "버퍼 2로 이동"
        '            Case 3
        '                lbl20_Stacker_Target.Text = "버퍼 3로 이동"
        '            Case 4
        '                lbl20_Stacker_Target.Text = "버퍼 4로 이동"
        '            Case 5
        '                lbl20_Stacker_Target.Text = "버퍼 5로 이동"
        '            Case 6
        '                lbl20_Stacker_Target.Text = "버퍼 6로 이동"
        '            Case 7
        '                lbl20_Stacker_Target.Text = "바이패스 이동"
        '            Case 11
        '                lbl20_Stacker_Target.Text = "작업 1로 이동"
        '            Case 12
        '                lbl20_Stacker_Target.Text = "작업 2로 이동"
        '            Case 13
        '                lbl20_Stacker_Target.Text = "작업 3로 이동"
        '            Case 14
        '                lbl20_Stacker_Target.Text = "작업 4로 이동"
        '            Case 15
        '                lbl20_Stacker_Target.Text = "작업 5로 이동"
        '            Case 16
        '                lbl20_Stacker_Target.Text = "작업 6로 이동"
        '            Case 17
        '                lbl20_Stacker_Target.Text = "공파렛 배출로 이동"
        '        End Select


        '        '** Data Exchange
        '        Call DataExchage()      ' 0 -> 5, 1 -> 4

        '        '** 위치별 데이타
        '        For i = 0 To 5
        '            '** Work Pos Title
        '            Select Case WorkRunData(i)
        '                Case 0  'Empty
        '                    lbl_WorkTitle(i).BackColor = Color.Black
        '                    lbl_WorkTitle(i).ForeColor = Color.White
        '                Case 1  'Wait
        '                    lbl_WorkTitle(i).BackColor = Color.DarkSeaGreen
        '                    lbl_WorkTitle(i).ForeColor = Color.Blue
        '                Case 2  'RUN
        '                    lbl_WorkTitle(i).BackColor = Color.Lime
        '                    lbl_WorkTitle(i).ForeColor = Color.Blue
        '                Case Else
        '            End Select

        '            '** 작업지시 수신 chk
        '            If MesWorkOder_ID(i, 0) <> "" Then
        '                If MesWorkOder_ID_Old(i, 0) <> MesWorkOder_ID(i, 0) Then
        '                    MesWorkOder_ID_Old(i, 0) = MesWorkOder_ID(i, 0)
        '                    lst_WorkOder_Receive.Items.Add(i + 1 & " 라인, WorkID:" & MesWorkOder_ID(i, 0) & ", MAT ID:" & MesWorkOder_MatID(i, 0))
        '                    lst_WorkOder_Receive.SelectedIndex = lst_WorkOder_Receive.Items.Count - 1
        '                    If lst_WorkOder_Receive.Items.Count > 100 Then lst_WorkOder_Receive.Items.RemoveAt(0)

        '                End If
        '            ElseIf MesWorkOder_ID(i, 0) = "" Then
        '                MesWorkOder_ID_Old(i, 0) = ""
        '            End If

        '            '** inLet / Stacker Work Check
        '            If i = 0 Then
        '                If (Len(Pos_inLet(i, 1)) > 0) And (Pos_inLet(i, 1) <> "0") Then
        '                    If Pos_inLet_ID_Old(i, 0) <> Pos_inLet(i, 1) Then
        '                        Pos_inLet_ID_Old(i, 0) = Pos_inLet(i, 1)
        '                        lbl_Work_ID(0 + i).Text = Pos_inLet(i, 0)
        '                        lbl_Mat_ID(0 + i).Text = Pos_inLet(i, 1)
        '                        Call EQ_TB3_MES_Trnas("inLet", "Input", Pos_inLet(i, 0), Pos_inLet(i, 1), "0", "0", "")
        '                        Call Save_PosOldVal_ini("inLet", Pos_inLet_ID_Old(i, 0))
        '                    Else
        '                        If lbl_Mat_ID(0 + i).Text = "" Or lbl_Mat_ID(0 + i).Text = "-" Then
        '                            Pos_inLet_ID_Old(i, 0) = Pos_inLet(i, 1)
        '                            lbl_Work_ID(0 + i).Text = Pos_inLet(i, 0)
        '                            lbl_Mat_ID(0 + i).Text = Pos_inLet(i, 1)
        '                            Call Save_PosOldVal_ini("inLet", Pos_inLet_ID_Old(i, 0))
        '                        End If
        '                    End If
        '                Else
        '                    If Pos_inLet_ID_Old(i, 0) <> Pos_inLet(i, 1) Then
        '                        Call EQ_TB3_MES_Trnas("inLet", "Output", "", Pos_inLet_ID_Old(i, 0), "0", "0", "")
        '                        Call Save_PosOldVal_ini("inLet", "")
        '                        Pos_inLet_ID_Old(i, 0) = ""
        '                        Pos_inLet(i, 1) = ""
        '                        lbl_Work_ID(0 + i).Text = ""
        '                        lbl_Mat_ID(0 + i).Text = ""
        '                    End If
        '                End If
        '                If (Len(Pos_inStacker(i, 1)) > 0) And (Pos_inStacker(i, 1) <> "0") Then   '**inStacker
        '                    If Pos_inStacker_ID_Old(i, 0) <> Pos_inStacker(i, 1) Then
        '                        Pos_inStacker_ID_Old(i, 0) = Pos_inStacker(i, 1)
        '                        lbl_Work_ID(20 + i).Text = Pos_inStacker(i, 0)
        '                        lbl_Mat_ID(20 + i).Text = Pos_inStacker(i, 1)
        '                        lbl_Status(20 + i).Text = IIf(Pos_inStacker(i, 2) <> 0, "ON", "-")
        '                        Call EQ_TB3_MES_Trnas("inStacker", "Input", Pos_inStacker(i, 0), Pos_inStacker(i, 1), "0", "0", "")
        '                        Call Save_PosOldVal_ini("inStacker", Pos_inStacker_ID_Old(i, 0))
        '                    Else
        '                        If lbl_Mat_ID(20 + i).Text = "" Or lbl_Mat_ID(20 + i).Text = "-" Then
        '                            Pos_inStacker_ID_Old(i, 0) = Pos_inStacker(i, 1)
        '                            lbl_Work_ID(20 + i).Text = Pos_inStacker(i, 0)
        '                            lbl_Mat_ID(20 + i).Text = Pos_inStacker(i, 1)
        '                            lbl_Status(20 + i).Text = IIf(Pos_inStacker(i, 2) <> 0, "ON", "-")
        '                            Call Save_PosOldVal_ini("inStacker", Pos_inStacker_ID_Old(i, 0))
        '                        End If
        '                    End If
        '                Else
        '                    If Pos_inStacker_ID_Old(i, 0) <> Pos_inStacker(i, 1) Then
        '                        Call EQ_TB3_MES_Trnas("inStacker", "Output", "", Pos_inStacker_ID_Old(i, 0), "0", "0", "")
        '                        Call Save_PosOldVal_ini("inStacker", "")
        '                        Pos_inStacker_ID_Old(i, 0) = ""
        '                        Pos_inStacker(i, 1) = ""
        '                        lbl_Work_ID(20 + i).Text = ""
        '                        lbl_Mat_ID(20 + i).Text = ""
        '                        lbl_Status(20 + i).Text = "-"
        '                    End If
        '                End If
        '                If (Len(Pos_OutStacker(i, 1)) > 0) And (Pos_OutStacker(i, 1) <> "0") Then   '**outStacker
        '                    If Pos_outStacker_ID_Old(i, 0) <> Pos_OutStacker(i, 1) Then
        '                        Pos_outStacker_ID_Old(i, 0) = Pos_OutStacker(i, 1)
        '                        lbl_Work_ID(20 + i + 1).Text = Pos_OutStacker(i, 0)
        '                        lbl_Mat_ID(20 + i + 1).Text = Pos_OutStacker(i, 1)
        '                        lbl_Status(20 + i + 1).Text = IIf(Pos_OutStacker(i, 2) <> 0, "ON", "-")
        '                        Call EQ_TB3_MES_Trnas("OutStacker", "Input", Pos_OutStacker(i, 0), Pos_OutStacker(i, 1), "0", "0", "")
        '                        Call Save_PosOldVal_ini("OutStacker", Pos_outStacker_ID_Old(i, 0))
        '                    Else
        '                        If lbl_Mat_ID(20 + i + 1).Text = "" Or lbl_Mat_ID(20 + i + 1).Text = "-" Then
        '                            Pos_outStacker_ID_Old(i, 0) = Pos_OutStacker(i, 1)
        '                            lbl_Work_ID(20 + i + 1).Text = Pos_OutStacker(i, 0)
        '                            lbl_Mat_ID(20 + i + 1).Text = Pos_OutStacker(i, 1)
        '                            lbl_Status(20 + i + 1).Text = IIf(Pos_OutStacker(i, 2) <> 0, "ON", "-")
        '                            Call Save_PosOldVal_ini("OutStacker", Pos_outStacker_ID_Old(i, 0))
        '                        End If
        '                    End If
        '                Else
        '                    If Pos_outStacker_ID_Old(i, 0) <> Pos_OutStacker(i, 1) Then
        '                        Call EQ_TB3_MES_Trnas("OutStacker", "Output", "", Pos_outStacker_ID_Old(i, 0), "0", "0", "")
        '                        Call Save_PosOldVal_ini("OutStacker", "")
        '                        Pos_outStacker_ID_Old(i, 0) = ""
        '                        Pos_OutStacker(i, 1) = ""
        '                        lbl_Work_ID(20 + i + 1).Text = ""
        '                        lbl_Mat_ID(20 + i + 1).Text = ""
        '                        lbl_Status(20 + i + 1).Text = "-"
        '                    End If
        '                End If
        '            End If

        '            '** 버퍼위치 Work Check
        '            If (Len(Pos_Buffer(i, 1)) > 0) And (Pos_Buffer(i, 1) <> "0") Then
        '                If Pos_Buffer_ID_Old(i, 0) <> Pos_Buffer(i, 1) Then
        '                    Pos_Buffer_ID_Old(i, 0) = Pos_Buffer(i, 1)
        '                    lbl_Work_ID(10 + i).Text = Pos_Buffer(i, 0)
        '                    lbl_Mat_ID(10 + i).Text = Pos_Buffer(i, 1)
        '                    lbl_Status(10 + i).Text = IIf(Pos_Buffer(i, 2) <> 0, "ON", "-")
        '                    Call EQ_TB3_MES_Trnas("Buffer " & i + 1, "Input", Pos_Buffer(i, 0), Pos_Buffer(i, 1), "0", "0", "")
        '                    Call Save_PosOldVal_ini("Buffer " & i + 1, Pos_Buffer_ID_Old(i, 0))
        '                Else
        '                    If lbl_Mat_ID(10 + i).Text = "" Or lbl_Mat_ID(10 + i).Text = "-" Then
        '                        Pos_Buffer_ID_Old(i, 0) = Pos_Buffer(i, 1)
        '                        lbl_Work_ID(10 + i).Text = Pos_Buffer(i, 0)
        '                        lbl_Mat_ID(10 + i).Text = Pos_Buffer(i, 1)
        '                        lbl_Status(10 + i).Text = IIf(Pos_Buffer(i, 2) <> 0, "ON", "-")
        '                        Call Save_PosOldVal_ini("Buffer " & i + 1, Pos_Buffer_ID_Old(i, 0))
        '                    End If
        '                End If
        '            Else
        '                If Pos_Buffer_ID_Old(i, 0) <> Pos_Buffer(i, 1) Then
        '                    Call EQ_TB3_MES_Trnas("Buffer " & i + 1, "Output", "", Pos_Buffer_ID_Old(i, 0), "0", "0", "")
        '                    Call Save_PosOldVal_ini("Buffer " & i + 1, "")
        '                    Pos_Buffer_ID_Old(i, 0) = ""
        '                    Pos_Buffer(i, 1) = ""
        '                    lbl_Work_ID(10 + i).Text = ""
        '                    lbl_Mat_ID(10 + i).Text = ""
        '                    lbl_Status(10 + i).Text = "-"
        '                End If
        '            End If

        '            '** 작업위치 Work Check
        '            If (Len(Pos_Work(i, 1)) > 0) And (Pos_Work(i, 1) <> "0") Then
        '                If Pos_Work_ID_Old(i, 0) <> Pos_Work(i, 1) Then
        '                    Pos_Work_ID_Old(i, 0) = Pos_Work(i, 1)
        '                    lbl_Work_ID(30 + (5 - i)).Text = Pos_Work(i, 0)
        '                    lbl_Mat_ID(30 + (5 - i)).Text = Pos_Work(i, 1)
        '                    lbl_Status(30 + (5 - i)).Text = IIf(Pos_Work(i, 2) <> 0, "ON", "-")
        '                    lbl_SV_Weight(30 + (5 - i)).Text = Pos_Work(i, 3)
        '                    lbl_Work_ID(40 + (5 - i)).Text = Pos_Work(i, 0)
        '                    lbl_Mat_ID(40 + (5 - i)).Text = Pos_Work(i, 1)
        '                    lbl_Status(40 + (5 - i)).Text = "-"   'IIf(Pos_Work(i, 2) <> 0, "ON", "-")
        '                    lbl_SV_Weight(40 + (5 - i)).Text = Pos_Work(i, 3)
        '                    Call EQ_TB3_MES_Trnas("Work " & i + 1, "Input", Pos_Work(i, 0), Pos_Work(i, 1), Pos_Work(i, 3), Pos_Work(i, 4), "")
        '                    Call Save_PosOldVal_ini("Work " & i + 1, Pos_Work_ID_Old(i, 0))
        '                Else
        '                    If lbl_Mat_ID(30 + (5 - i)).Text = "" Or lbl_Mat_ID(30 + (5 - i)).Text = "-" Then
        '                        Pos_Work_ID_Old(i, 0) = Pos_Work(i, 1)
        '                        lbl_Work_ID(30 + (5 - i)).Text = Pos_Work(i, 0)
        '                        lbl_Mat_ID(30 + (5 - i)).Text = Pos_Work(i, 1)
        '                        lbl_Status(30 + (5 - i)).Text = IIf(Pos_Work(i, 2) <> 0, "ON", "-")
        '                        lbl_SV_Weight(30 + (5 - i)).Text = Pos_Work(i, 3)
        '                        lbl_Work_ID(40 + (5 - i)).Text = Pos_Work(i, 0)
        '                        lbl_Mat_ID(40 + (5 - i)).Text = Pos_Work(i, 1)
        '                        lbl_Status(40 + (5 - i)).Text = "-"   'IIf(Pos_Work(i, 2) <> 0, "ON", "-")
        '                        lbl_SV_Weight(40 + (5 - i)).Text = Pos_Work(i, 3)
        '                        Call Save_PosOldVal_ini("Work " & i + 1, Pos_Work_ID_Old(i, 0))
        '                    End If
        '                End If
        '            Else
        '                If Pos_Work_ID_Old(i, 0) <> Pos_Work(i, 1) Then
        '                    Call EQ_TB3_MES_Trnas("Work " & i + 1, "Output", "", Pos_Work_ID_Old(i, 0), "0", "0", "")
        '                    Call Save_PosOldVal_ini("Work " & i + 1, "")
        '                    Pos_Work_ID_Old(i, 0) = ""
        '                    Pos_Work(i, 1) = ""
        '                    lbl_Work_ID(30 + (5 - i)).Text = ""
        '                    lbl_Mat_ID(30 + (5 - i)).Text = ""
        '                    lbl_Status(30 + (5 - i)).Text = "-"
        '                    lbl_SV_Weight(30 + (5 - i)).Text = ""
        '                    lbl_Work_ID(40 + (5 - i)).Text = ""
        '                    lbl_Mat_ID(40 + (5 - i)).Text = ""
        '                    lbl_Status(40 + (5 - i)).Text = "-"
        '                    lbl_SV_Weight(40 + (5 - i)).Text = ""
        '                End If
        '            End If


        '            '** 바이패스 Work Check
        '            If i < 3 Then
        '                If (Len(Pos_ByPass(i, 1)) > 0) And (Pos_ByPass(i, 1) <> "0") Then
        '                    If Pos_ByPass_ID_Old(i, 0) <> Pos_ByPass(i, 1) Then
        '                        Pos_ByPass_ID_Old(i, 0) = Pos_ByPass(i, 1)
        '                        lbl_Work_ID(50 + i).Text = Pos_ByPass(i, 0)
        '                        lbl_Mat_ID(50 + i).Text = Pos_ByPass(i, 1)
        '                        Call EQ_TB3_MES_Trnas("ByPass " & i + 1, "Input", Pos_ByPass(i, 0), Pos_ByPass(i, 1), "0", "0", "")
        '                        Call Save_PosOldVal_ini("ByPass " & i + 1, Pos_ByPass_ID_Old(i, 0))
        '                    Else
        '                        If lbl_Mat_ID(50 + i).Text = "" Or lbl_Mat_ID(50 + i).Text = "-" Then
        '                            Pos_ByPass_ID_Old(i, 0) = Pos_ByPass(i, 1)
        '                            lbl_Work_ID(50 + i).Text = Pos_ByPass(i, 0)
        '                            lbl_Mat_ID(50 + i).Text = Pos_ByPass(i, 1)
        '                            Call Save_PosOldVal_ini("ByPass " & i + 1, Pos_ByPass_ID_Old(i, 0))
        '                        End If
        '                    End If
        '                Else
        '                    If Pos_ByPass_ID_Old(i, 0) <> Pos_ByPass(i, 1) Then
        '                        Call EQ_TB3_MES_Trnas("ByPass " & i + 1, "Output", "", Pos_ByPass_ID_Old(i, 0), "0", "0", "")
        '                        Call Save_PosOldVal_ini("ByPass " & i + 1, "")
        '                        Pos_ByPass_ID_Old(i, 0) = ""
        '                        Pos_ByPass(i, 1) = ""
        '                        lbl_Work_ID(50 + i).Text = ""
        '                        lbl_Mat_ID(50 + i).Text = ""
        '                    End If
        '                End If
        '            End If

        '            '** 배출 Work Check
        '            If (Len(Pos_Work(i, 6)) > 0) And (Pos_Work(i, 6) <> "0") Then
        '                If Pos_OutLet_EndCode_Old(i, 0) <> Pos_Work(i, 6) Then
        '                    Pos_OutLet_EndCode_Old(i, 0) = Pos_Work(i, 6)
        '                    If Pos_Work(i, 6) = 1 Then        '1:작업완료(공파렛)
        '                        Call EQ_TB3_MES_Trnas("OutLet " & i + 1, "OutPut", Pos_Work(i, 0), Pos_Work(i, 1), Pos_Work(i, 3), Pos_OutLet(i, 4), "작업완료(공파렛)")
        '                    ElseIf Pos_Work(i, 6) = 2 Then    '2:작업완료(계획무계 완료)
        '                        Call EQ_TB3_MES_Trnas("OutLet " & i + 1, "OutPut", Pos_Work(i, 0), Pos_Work(i, 1), Pos_Work(i, 3), Pos_OutLet(i, 4), "작업완료(계획무계 완료)")
        '                    ElseIf Pos_Work(i, 6) = 3 Then    '3:작업완료(강제종료)
        '                        Call EQ_TB3_MES_Trnas("OutLet " & i + 1, "OutPut", Pos_Work(i, 0), Pos_Work(i, 1), Pos_Work(i, 3), Pos_OutLet(i, 4), "작업완료(강제종료)")
        '                    End If
        '                    Call Save_PosOldVal_ini("OutLet " & i + 1, Pos_OutLet_EndCode_Old(i, 0))
        '                End If
        '            Else
        '                If Pos_OutLet_EndCode_Old(i, 0) <> Pos_Work(i, 6) Then
        '                    Call Save_PosOldVal_ini("OutLet " & i + 1, "0")
        '                    Pos_OutLet_EndCode_Old(i, 0) = "0"
        '                    Pos_Work(i, 6) = "0"
        '                End If
        '            End If

        '            'If (Len(Pos_OutLet(i, 6)) > 0) And (Pos_OutLet(i, 6) <> "0") Then
        '            '    If Pos_OutLet_EndCode_Old(i, 0) <> Pos_OutLet(i, 6) Then
        '            '        Pos_OutLet_EndCode_Old(i, 0) = Pos_OutLet(i, 6)
        '            '        If Pos_OutLet(i, 6) = 1 Then        '1:작업완료(공파렛)
        '            '            Call EQ_TB3_MES_Trnas("OutLet " & i + 1, "OutPut", Pos_OutLet(i, 0), Pos_OutLet(i, 1), "0", "0", "작업완료(공파렛)")
        '            '        ElseIf Pos_OutLet(i, 6) = 2 Then    '2:작업완료(계획무계 완료)
        '            '            Call EQ_TB3_MES_Trnas("OutLet " & i + 1, "OutPut", Pos_OutLet(i, 0), Pos_OutLet(i, 1), "0", "0", "작업완료(계획무계 완료)")
        '            '        ElseIf Pos_OutLet(i, 6) = 3 Then    '3:작업완료(강제종료)
        '            '            Call EQ_TB3_MES_Trnas("OutLet " & i + 1, "OutPut", Pos_OutLet(i, 0), Pos_OutLet(i, 1), "0", "0", "작업완료(강제종료)")
        '            '        End If
        '            '        Call Save_PosOldVal_ini("OutLet " & i + 1, Pos_OutLet_EndCode_Old(i, 0))

        '            '    End If
        '            'Else
        '            '    If Pos_OutLet_EndCode_Old(i, 0) <> "" Then
        '            '        Call Save_PosOldVal_ini("OutLet " & i + 1, "")
        '            '        Pos_OutLet_EndCode_Old(i, 0) = ""
        '            '        Pos_OutLet(i, 6) = ""
        '            '    End If
        '            'End If

        '            '** 배출 로드셀 표시
        '            lbl_PV_Weight(40 + (5 - i)).Text = Pos_OutLet(i, 4)

        '        Next





        '        'Select Case PlcData(1)
        '        '    Case 1  'RUN
        '        '        Status_Label(PLC_Num).BackColor = Color.Lime
        '        '    Case 2  'WAIT
        '        '        Status_Label(PLC_Num).BackColor = Color.Orange
        '        '    Case 4  'TROUBLE
        '        '        Status_Label(PLC_Num).BackColor = Color.Red

        '        '    Case 8  'STOP
        '        '        Status_Label(PLC_Num).BackColor = Color.DarkBlue
        '        '    Case Else
        '        '        Status_Label(PLC_Num).Text = " "
        '        '        Status_Label(PLC_Num).BackColor = Color.AliceBlue
        '        'End Select

        '        'LoadingCount = DoubleDataRead(800)
        '        'GoodCount = DoubleDataRead(802)
        '        'FailureCount = DoubleDataRead(804)
        '        'Shift_GoodCount = DoubleDataRead(852)
        '        'Shift_FailureCount = DoubleDataRead(854)

        '        'PPM_Label(PLC_Num).Text = Format(PlcData(817) / 10, "#0.0")
        '        'Operation_Label(PLC_Num).Text = Format(PlcData(814) / 100, "#0.#0")
        '        'GoodRate_Label(PLC_Num).Text = Format(PlcData(815) / 100, "#0.#0")

        '        'LoadingCount_Label(PLC_Num).Text = LoadingCount
        '        'GoodCount_Label(PLC_Num).Text = GoodCount
        '        'FailureCount_Label(PLC_Num).Text = FailureCount
        '        'Current_LotNameSearch()         'Lot No Data Read
        '    End If

        'Catch ex As Exception
        '    MsgDisplay("RealDataRead Err : " & ex.Message, Color.Red)
        'End Try

    End Sub

    Private Sub DataExchage()
        Dim WorkRunDataBuff(5) As Short

        WorkRunDataBuff(0) = WorkRunData(5)
        WorkRunDataBuff(1) = WorkRunData(4)
        WorkRunDataBuff(2) = WorkRunData(3)
        WorkRunDataBuff(3) = WorkRunData(2)
        WorkRunDataBuff(4) = WorkRunData(1)
        WorkRunDataBuff(5) = WorkRunData(0)

        WorkRunData(0) = WorkRunDataBuff(0)
        WorkRunData(1) = WorkRunDataBuff(1)
        WorkRunData(2) = WorkRunDataBuff(2)
        WorkRunData(3) = WorkRunDataBuff(3)
        WorkRunData(4) = WorkRunDataBuff(4)
        WorkRunData(5) = WorkRunDataBuff(5)
    End Sub

    Public Sub ActUtl1_Read(ByVal StartAdd As String, ByVal DeviceCNT As Integer, ByRef ArrDeviceVal() As Short)

        Dim iReturnCode As Integer              'Return code
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        'Dim i As Integer                  'Loop counter

        'Assign the array for 'DeviceValue'.
        ReDim sharrDeviceValue(DeviceCNT - 1)

        'Processing of ReadDeviceBlock2 method

        Try
            'When ActUtlType is selected by the radio button,
            'the ReadDeviceBlock2 method is executed.

            If PLC_Port_Open_OK = True Then
                iReturnCode = AxActUtlType1.ReadDeviceBlock2(StartAdd, DeviceCNT, sharrDeviceValue(0))
                'iReturnCode = AxActUtlType1.ReadBuffer()
            End If


        Catch exException As Exception
            'Exception processing
            MsgDisplay("PLC_Read Err : " & exException.Message, Color.Red, 0)
            'MessageBox.Show(exException.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'The return code of the method is displayed by the hexadecimal.
        'txt_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

        '
        'Display the read data
        '
        'When the ReadDeviceBlock2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            ''Assign array for the read data.
            'ReDim ArrDeviceVal(DeviceCNT - 1)

            ''Copy the read data to the 'lpszarrData'.
            'For i = 0 To DeviceCNT - 1
            '    ArrDeviceVal(i) = sharrDeviceValue(i).ToString()
            'Next i


            Array.Copy(sharrDeviceValue, ArrDeviceVal, DeviceCNT)

        End If
    End Sub

    Public Sub ActUtl1_Read_Bit(ByVal StartAdd As String, ByVal DeviceCNT As Integer, ByRef ArrDeviceVal() As Short)

        Dim iReturnCode As Integer              'Return code
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        'Dim i As Integer                  'Loop counter

        'Assign the array for 'DeviceValue'.
        ReDim sharrDeviceValue(DeviceCNT - 1)

        'Processing of ReadDeviceBlock2 method

        Try
            'When ActUtlType is selected by the radio button,
            'the ReadDeviceBlock2 method is executed.

            If PLC_Port_Open_OK = True Then
                iReturnCode = AxActUtlType1.ReadDeviceRandom(StartAdd, DeviceCNT, sharrDeviceValue(0))  'bit
            End If


        Catch exException As Exception
            'Exception processing
            MsgDisplay("PLC_Read Err : " & exException.Message, Color.Red, 0)
            'MessageBox.Show(exException.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'The return code of the method is displayed by the hexadecimal.
        'txt_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

        '
        'Display the read data
        '
        'When the ReadDeviceBlock2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            ''Assign array for the read data.
            'ReDim ArrDeviceVal(DeviceCNT - 1)

            ''Copy the read data to the 'lpszarrData'.
            'For i = 0 To DeviceCNT - 1
            '    ArrDeviceVal(i) = sharrDeviceValue(i).ToString()
            'Next i


            Array.Copy(sharrDeviceValue, ArrDeviceVal, DeviceCNT)

        End If
    End Sub

    Public Sub ActUtl1_Read1(ByVal StartAdd As String, ByVal DeviceCNT As Integer, ByRef ArrDeviceVal() As Short)

        Dim iReturnCode As Integer              'Return code
        Dim sharrDeviceValue() As Short         'Data for 'DeviceValue'
        'Dim i As Integer                  'Loop counter

        'Assign the array for 'DeviceValue'.
        ReDim sharrDeviceValue(DeviceCNT - 1)

        'Processing of ReadDeviceBlock2 method

        Try
            'When ActUtlType is selected by the radio button,
            'the ReadDeviceBlock2 method is executed.

            If PLC_Port_Open_OK = True Then
                'iReturnCode = AxActUtlType1.ReadDeviceBlock2(StartAdd, DeviceCNT, sharrDeviceValue(0))
                'iReturnCode = AxActUtlType1.ReadDeviceBlock(StartAdd, DeviceCNT, sharrDeviceValue(0))
                'iReturnCode = AxActUtlType1.ReadDeviceRandom(StartAdd, DeviceCNT, sharrDeviceValue(0))  'bit

                'iReturnCode = AxActUtlType1.ReadBuff(StartAdd, DeviceCNT, sharrDeviceValue(0))

                'iReturnCode = AxActUtlType1.ReadBuffer()
            End If


        Catch exException As Exception
            'Exception processing
            MsgDisplay("PLC_Read Err : " & exException.Message, Color.Red, 0)
            'MessageBox.Show(exException.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        'The return code of the method is displayed by the hexadecimal.
        'txt_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

        '
        'Display the read data
        '
        'When the ReadDeviceBlock2 method is succeeded, display the read data.
        If iReturnCode = 0 Then

            ''Assign array for the read data.
            'ReDim ArrDeviceVal(DeviceCNT - 1)

            ''Copy the read data to the 'lpszarrData'.
            'For i = 0 To DeviceCNT - 1
            '    ArrDeviceVal(i) = sharrDeviceValue(i).ToString()
            'Next i


            Array.Copy(sharrDeviceValue, ArrDeviceVal, DeviceCNT)

        End If
    End Sub

    Public Function Work_Oder_String(ByVal start_adr As Integer) As String
        Dim i As Byte
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String


        'On Error Resume Next

        Work_id = ""
        For i = 0 To 19
            PLC_Read = Hex(WorkOderData(start_adr + i))
            If Len(PLC_Read) = 4 Then
                Buf1 = Mid(PLC_Read, 1, 2)
                Buf2 = Mid(PLC_Read, 3, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf2))
                Work_id = Work_id & Chr(Val("&H" & Buf1))
            ElseIf Len(PLC_Read) = 2 Then
                Buf1 = Mid(PLC_Read, 1, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf1))
            End If
        Next
        Work_Oder_String = Trim(Work_id)

        Return Work_Oder_String

    End Function

    Public Function Work_Oder_SV_String(ByVal start_adr As Integer) As String
        Dim i As Byte
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String


        'On Error Resume Next

        Work_id = ""
        For i = 0 To 9
            PLC_Read = Hex(WorkOderSVData(start_adr + i))
            If Len(PLC_Read) = 4 Then
                Buf1 = Mid(PLC_Read, 1, 2)
                Buf2 = Mid(PLC_Read, 3, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf2))
                Work_id = Work_id & Chr(Val("&H" & Buf1))
            ElseIf Len(PLC_Read) = 2 Then
                Buf1 = Mid(PLC_Read, 1, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf1))
            End If
        Next
        Work_Oder_SV_String = Trim(Work_id)

        Return Work_Oder_SV_String

    End Function

    Public Function MAT_id_String(ByVal start_adr As Integer) As String
        'Dim i As Byte
        'Dim MAT_id As String
        'Dim PLC_Read As String
        'Dim Buf1 As String
        'Dim Buf2 As String


        ''On Error Resume Next

        'MAT_id = ""
        'For i = 0 To 9
        '    PLC_Read = Hex(PlcData(start_adr + i))
        '    If Len(PLC_Read) = 4 Then
        '        Buf1 = Mid(PLC_Read, 1, 2)
        '        Buf2 = Mid(PLC_Read, 3, 2)
        '        MAT_id = MAT_id & Chr(Val("&H" & Buf2))
        '        MAT_id = MAT_id & Chr(Val("&H" & Buf1))
        '    ElseIf Len(PLC_Read) = 2 Then
        '        Buf1 = Mid(PLC_Read, 1, 2)
        '        MAT_id = MAT_id & Chr(Val("&H" & Buf1))
        '    End If
        'Next
        'MAT_id_String = Trim(MAT_id)

        'Return MAT_id

    End Function


    Public Sub AlarmCommentRead()
        Dim WorkFileName As String
        Dim FileNo As Integer
        Dim i As Integer

        Try
            '---------- CJL
            i = 0
            FileNo = FreeFile() '파일번호를 알아서 정해 줍니다.
            WorkFileName = My.Application.Info.DirectoryPath & "\SetData\Alarm_List.csv"
            If System.IO.File.Exists(WorkFileName) Then
                FileOpen(FileNo, WorkFileName, OpenMode.Input)  '경로를 지정합니다.
                Do While Not EOF(FileNo)        'end of file 즉 파일의 내용 끝까지 읽는다.
                    Name = LineInput(FileNo)    '첫번째 줄을 읽어서 Name 변수에 저장
                    'If Len(Trim(Name)) > 0 Then     ' 만약 읽는 줄에 내용이 공백을 지우고도 글자수가 0보다 크다면 (Trim공백제거 명령)
                    If i < 2000 Then
                        AlarmComment(i) = Name
                        Name = ""
                        i = i + 1
                    Else
                        Exit Do
                    End If
                    'End If
                Loop
                FileClose(FileNo)       '열었던 파일을 닫는다.
            End If

        Catch ex As Exception
            MsgDisplay("Alarm Comment File Open Err : " & ex.Message, Color.Red)
        End Try

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim result = MessageBox.Show("종료 하시겠습니까?", "프로그램 종료!", MessageBoxButtons.YesNo)

        'Debug.Print(result)

        If result = 6 Then  'Yes
            'Debug.Print("Closing")
            e.Cancel = False ' 종료

        ElseIf result = 7 Then 'NO
            'Debug.Print("No Closing")
            e.Cancel = True ' 종료 안함
        End If

    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


        Try
            Timer1.Enabled = False
            iReturnCode = Me.AxActUtlType1.Close()
            If SIO_UP35A.IsOpen = True Then SIO_UP35A.Close()
            If SIO_UP35A1.IsOpen = True Then SIO_UP35A1.Close()

            Interlocked.Exchange(KillAllThreads, 1)

        Catch ex As Exception

        End Try


        End

    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim buf As String
        Dim dec1 As String
        Dim dec2 As String

        Select Case e.KeyCode
            Case Keys.Escape
                MsgDisplay("", Color.Black, 0)

                'Debug.Print("ESC")

            Case Keys.F2
                'Debug.Print("mod = " & 65 \ 16)
                'Debug.Print(DataGridView1.Columns(2).Width)
                'Call SaveFile_Work("Test")
                'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR124", 2, "1234567890")
                'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR92", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)

                'buf = Hex("1234567890")
                buf = Hex("1234")
                If Len(buf) > 4 Then
                    dec1 = Convert.ToInt16(Mid(buf, 5, 4), 16)
                    dec2 = Convert.ToInt16(Mid(buf, 1, 4 - (8 - Len(buf))), 16)
                    Debug.Print(dec1)
                    Debug.Print(dec2)
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR124", 1, dec1)
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR125", 1, dec2)
                Else
                    dec1 = Convert.ToInt16(Mid(buf, 1, 4 - (4 - Len(buf))), 16)
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR124", 1, dec1)

                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR124", 2, "2,147,483,647")
                End If




            Case Keys.F3
                Dim row1 As DataRow
                Dim row2 As DataRow
                row1 = tblUnit1.NewRow()
                row2 = tblUnit2.NewRow()

                test_i += 1
                test_j = test_i + 1

                UP35A_temp = test_i
                UP35A_temp1 = test_j
                lblTemp1.Text = UP35A_temp
                lblTemp2.Text = UP35A_temp1

                row1(0) = UP35A_temp
                row2(0) = UP35A_temp1
                tblUnit1.Rows.Add(row1)
                tblUnit2.Rows.Add(row2)
                Chart1.Series(0).YValueMembers = tblUnit1.Columns.Item(0).ColumnName
                Chart1.DataBind()
                Chart2.Series(0).YValueMembers = tblUnit2.Columns.Item(0).ColumnName
                Chart2.DataBind()

                If tblUnit1.Rows.Count >= 10 Then
                    tblUnit1.Rows.RemoveAt(0)
                    'DataGridView1.FirstDisplayedScrollingRowIndex = 0
                    'DataGridView1.Rows.Item(0).Selected = True
                End If
                If tblUnit2.Rows.Count >= 10 Then
                    tblUnit2.Rows.RemoveAt(0)
                    'DataGridView1.FirstDisplayedScrollingRowIndex = 0
                    'DataGridView1.Rows.Item(0).Selected = True
                End If


                Dim currDateTime As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                Call ResultFileSave(True, currDateTime & ", " & UP35A_temp & ", " & UP35A_temp1)


                'Call UP35A_Send(3,,, 1)
                'Call UP35A_Send(16,,, 1)

                'Debug.Print(DataGridView1.Columns.Item(1).DefaultCellStyle.BackColor.ToString)
                'DataGridView1.Columns.Item(2).DefaultCellStyle.BackColor = Color.Empty
                'Call SaveFile_Work_Old2("Test")
                'picN2_X105.Image = ImageList1.Images(0)
                'picN2_VV_Y128.Image = ImageList1.Images(8)
                'picN2_Y128.Image = ImageList1.Images(0)

                ''ImageList1.Images(8).RotateFlip(RotateFlipType.Rotate180FlipY)
                'picN2_VV_Y15C.Image = ImageList1.Images(8)

                'picAr2_VV1_Y130.Image = ImageList1.Images(1)



                ''Debug.Print(TabControl.SelectedTab.tostring)
                'Debug.Print(TabControl.SelectedIndex)
                'Debug.Print("asdf")


            Case Keys.F4
                'Call UP35A_Send(16, , , 2)     '* Select

                'Call UP35A_Send(16,, 0)
                'picN2_X105.Image = ImageList1.Images(2)
                'picN2_VV_Y128.Image = ImageList1.Images(10)
                'picN2_Y128.Image = ImageList1.Images(2)

                ''ImageList1.Images(8).RotateFlip(RotateFlipType.RotateNoneFlipNone)
                'picN2_VV_Y15C.Image = ImageList1.Images(2)

            Case Keys.F5
                'Call UP35A_Send(16, 300, 70, 3)     '* Set
                'Call UP35A_Send(16, 300, 123, 3)     '* Set

        End Select
    End Sub
    Private Sub btnStandy_MouseDown(sender As Object, e As MouseEventArgs) Handles btnStandy.MouseDown, btnStandy1.MouseDown
        'iReturnCode = AxActUtlType1.WriteDeviceBlock("D10000", 1, 1)
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M100", 1, 1) 'bit
    End Sub

    Private Sub btnStandy_MouseUp(sender As Object, e As MouseEventArgs) Handles btnStandy.MouseUp, btnStandy1.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M100", 1, 0) 'bit
    End Sub

    Private Sub btnStandyStop_MouseDown(sender As Object, e As MouseEventArgs) Handles btnStandyStop.MouseDown, btnStandyStop1.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M101", 1, 1) 'bit
    End Sub

    Private Sub btnStandyStop_MouseUp(sender As Object, e As MouseEventArgs) Handles btnStandyStop.MouseUp, btnStandyStop1.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M101", 1, 0) 'bit
    End Sub

    Private Sub btnATM_MouseDown(sender As Object, e As MouseEventArgs) Handles btnATM.MouseDown, btnATM1.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M200", 1, 1) 'bit
    End Sub

    Private Sub btnATM_MouseUp(sender As Object, e As MouseEventArgs) Handles btnATM.MouseUp, btnATM1.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M200", 1, 0) 'bit
    End Sub

    Private Sub btnATMStop_MouseDown(sender As Object, e As MouseEventArgs) Handles btnATMStop.MouseDown, btnATMStop1.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M201", 1, 1) 'bit
    End Sub

    Private Sub btnATMStop_MouseUp(sender As Object, e As MouseEventArgs) Handles btnATMStop.MouseUp, btnATMStop1.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M201", 1, 0) 'bit
    End Sub

    Private Sub btnESC_PWR_Auto_MouseDown(sender As Object, e As MouseEventArgs) Handles btnESC_PWR_Auto.MouseDown, btnESC_PWR_Auto1.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceBlock("D" & PLC_Step_CNT_, 1, 0)
        iReturnCode = AxActUtlType1.WriteDeviceBlock("D" & PLC_Step_Complete_, 1, 0)
        AutoStatFlag = True
        Call MsgDisplay("ESC Power Auto Start...", Color.Lime, 0)
        'iReturnCode = AxActUtlType1.WriteDeviceRandom("M400", 1, 1) 'bit
    End Sub

    Private Sub btnESC_PWR_Auto_MouseUp(sender As Object, e As MouseEventArgs) Handles btnESC_PWR_Auto.MouseUp, btnESC_PWR_Auto1.MouseUp
        'AutoStatFlag = False
        'iReturnCode = AxActUtlType1.WriteDeviceRandom("M400", 1, 0) 'bit
    End Sub

    Private Sub btnESC_PWR_Stop_MouseDown(sender As Object, e As MouseEventArgs) Handles btnESC_PWR_Stop.MouseDown, btnESC_PWR_Stop1.MouseDown
        AutoStatFlag = False
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M401", 1, 1) 'bit
        Call MsgDisplay("ESC Power Auto Stop", Color.Orange, 0)
    End Sub

    Private Sub btnESC_PWR_Stop_MouseUp(sender As Object, e As MouseEventArgs) Handles btnESC_PWR_Stop.MouseUp, btnESC_PWR_Stop1.MouseUp
        AutoStatFlag = False
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M401", 1, 0) 'bit
    End Sub

    Private Sub btnManualValveEnable_MouseDown(sender As Object, e As MouseEventArgs) Handles btnManualValveEnable.MouseDown, btnManualValveEnable1.MouseDown

        Call ActUtl1_Read("M6", 1, PlcData_M6)

        If PlcData_M6(0) = 1 Then
            iReturnCode = AxActUtlType1.WriteDeviceRandom("M6", 1, 0) 'bit
        Else
            iReturnCode = AxActUtlType1.WriteDeviceRandom("M6", 1, 1) 'bit
        End If

    End Sub

    Private Sub btnManualValveEnable_MouseUp(sender As Object, e As MouseEventArgs) Handles btnManualValveEnable.MouseUp, btnManualValveEnable1.MouseUp

    End Sub

    Private Sub btnRFON_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRFON.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1030", 1, 1) 'bit
    End Sub

    Private Sub btnRFON_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRFON.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1030", 1, 0) 'bit
    End Sub

    Private Sub btnRFOFF_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRFOFF.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1031", 1, 1) 'bit
    End Sub

    Private Sub btnRFOFF_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRFOFF.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1031", 1, 0) 'bit
    End Sub

    Private Sub btnSV_Change_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSV_Change.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X101A", 1, 1) 'bit
    End Sub

    Private Sub btnSV_Change_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSV_Change.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X101A", 1, 0) 'bit
    End Sub

    Private Sub btnDCPWR_HV_ON_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDCPWR_HV_ON.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1044", 1, 1) 'bit
    End Sub

    Private Sub btnDCPWR_HV_ON_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDCPWR_HV_ON.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1044", 1, 0) 'bit
    End Sub

    Private Sub btnDCPWR_HV_OFF_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDCPWR_HV_OFF.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1045", 1, 1) 'bit
    End Sub

    Private Sub btnDCPWR_HV_OFF_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDCPWR_HV_OFF.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X1045", 1, 0) 'bit
    End Sub

    Private Sub btnValveOpen_MouseDown(sender As Object, e As MouseEventArgs) Handles btnValveOpen.MouseDown
        Select Case panValve.Tag
            Case 1
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1000", 1, 1) 'bit
            Case 2
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1002", 1, 1) 'bit
            Case 3
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1004", 1, 1) 'bit
            Case 4
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1006", 1, 1) 'bit
            Case 5
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1008", 1, 1) 'bit
            Case 6
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100A", 1, 1) 'bit
            Case 7
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100C", 1, 1) 'bit
            Case 8
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100E", 1, 1) 'bit
            Case 9
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1010", 1, 1) 'bit
            Case 10
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1020", 1, 1) 'bit
            Case 11
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1022", 1, 1) 'bit
            Case 12
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1014", 1, 1) 'bit
            Case 13
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1016", 1, 1) 'bit
        End Select
    End Sub

    Private Sub btnValveOpen_MouseUp(sender As Object, e As MouseEventArgs) Handles btnValveOpen.MouseUp
        Select Case panValve.Tag
            Case 1
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1000", 1, 0) 'bit
            Case 2
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1002", 1, 0) 'bit
            Case 3
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1004", 1, 0) 'bit
            Case 4
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1006", 1, 0) 'bit
            Case 5
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1008", 1, 0) 'bit
            Case 6
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100A", 1, 0) 'bit
            Case 7
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100C", 1, 0) 'bit
            Case 8
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100E", 1, 0) 'bit
            Case 9
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1010", 1, 0) 'bit
            Case 10
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1020", 1, 0) 'bit
            Case 11
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1022", 1, 0) 'bit
            Case 12
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1014", 1, 0) 'bit
            Case 13
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1016", 1, 0) 'bit
        End Select
    End Sub

    Private Sub btnValveClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnValveClose.MouseDown
        Select Case panValve.Tag
            Case 1
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1001", 1, 1) 'bit
            Case 2
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1003", 1, 1) 'bit
            Case 3
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1005", 1, 1) 'bit
            Case 4
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1007", 1, 1) 'bit
            Case 5
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1009", 1, 1) 'bit
            Case 6
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100B", 1, 1) 'bit
            Case 7
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100D", 1, 1) 'bit
            Case 8
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100F", 1, 1) 'bit
            Case 9
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1011", 1, 1) 'bit
            Case 10
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1021", 1, 1) 'bit
            Case 11
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1023", 1, 1) 'bit
            Case 12
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1015", 1, 1) 'bit
            Case 13
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1017", 1, 1) 'bit
        End Select
    End Sub

    Private Sub btnValveClose_MouseUp(sender As Object, e As MouseEventArgs) Handles btnValveClose.MouseUp
        Select Case panValve.Tag
            Case 1
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1001", 1, 0) 'bit
            Case 2
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1003", 1, 0) 'bit
            Case 3
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1005", 1, 0) 'bit
            Case 4
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1007", 1, 0) 'bit
            Case 5
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1009", 1, 0) 'bit
            Case 6
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100B", 1, 0) 'bit
            Case 7
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100D", 1, 0) 'bit
            Case 8
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X100F", 1, 0) 'bit
            Case 9
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1011", 1, 0) 'bit
            Case 10
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1021", 1, 0) 'bit
            Case 11
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1023", 1, 0) 'bit
            Case 12
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1015", 1, 0) 'bit
            Case 13
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1017", 1, 0) 'bit
        End Select
    End Sub

    Private Sub btnThrottleValve_PositionMove_MouseDown(sender As Object, e As MouseEventArgs) Handles btnThrottleValve_PositionMove.MouseDown
        Select Case panValve.Tag
            Case 9
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1012", 1, 1) 'bit
        End Select
    End Sub

    Private Sub btnThrottleValve_PositionMove_MouseUp(sender As Object, e As MouseEventArgs) Handles btnThrottleValve_PositionMove.MouseUp
        Select Case panValve.Tag
            Case 9
                iReturnCode = AxActUtlType1.WriteDeviceRandom("X1012", 1, 0) 'bit
        End Select
    End Sub

    Private Sub btnBaratonGaugeSV_Change_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBaratonGaugeSV_Change.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X101A", 1, 1) 'bit
    End Sub

    Private Sub btnBaratonGaugeSV_Change_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBaratonGaugeSV_Change.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("X101A", 1, 0) 'bit
    End Sub

    Private Sub btnValvePannelClose_Click(sender As Object, e As EventArgs) Handles btnValvePannelClose.Click
        panValve.Tag = 0
        iReturnCode = AxActUtlType1.WriteDeviceBlock("D7", 1, 0)
        grpBaratonGauge.Visible = False
        btnThrottleValve_PositionMove.Visible = False
        panValve.Visible = False
    End Sub

    Private Sub btnThrottle_Valve_Click(sender As Object, e As EventArgs) Handles btnThrottle_Valve.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 9
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "Throttle VALVE"
        grpBaratonGauge.Visible = True
        btnThrottleValve_PositionMove.Visible = True
        panValve.Visible = True
    End Sub


    Private Sub btnGate_Valve_Click(sender As Object, e As EventArgs) Handles btnGate_Valve.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 12
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "GATE V/V Operation"
        panValve.Visible = True
    End Sub

    Private Sub btnTMP_OFF_Click(sender As Object, e As EventArgs) Handles btnTMP_OFF.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 10
        btnValveOpen.Text = "RUN"
        btnValveClose.Text = "STOP"
        grpValve.Text = "TURBO PUMP Operation"
        panValve.Visible = True
    End Sub

    Private Sub btnDRY_Pump_Off_Click(sender As Object, e As EventArgs) Handles btnDRY_Pump_Off.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 11
        btnValveOpen.Text = "RUN"
        btnValveClose.Text = "STOP"
        grpValve.Text = "DRY PUMP Operation"
        panValve.Visible = True
    End Sub

    Private Sub picN2_VV_Y128_Click(sender As Object, e As EventArgs) Handles picN2_VV_Y128.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 1
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "N2 Supply Valve"
        panValve.Visible = True
    End Sub
    Private Sub picAr1_VV_Y12A_Click(sender As Object, e As EventArgs) Handles picAr1_VV_Y12A.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 2
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "AR1 Supply MFC Before"
        panValve.Visible = True
    End Sub

    Private Sub picAr1_VV1_Y12C_Click(sender As Object, e As EventArgs) Handles picAr1_VV1_Y12C.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 3
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "AR1 Supply MFC After"
        panValve.Visible = True
    End Sub

    Private Sub picAr2_VV_Y12E_Click(sender As Object, e As EventArgs) Handles picAr2_VV_Y12E.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 4
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "AR2 Supply MFC Before"
        panValve.Visible = True

    End Sub

    Private Sub picAr2_VV1_Y130_Click(sender As Object, e As EventArgs) Handles picAr2_VV1_Y130.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 5
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "AR2 Supply MFC After"
        panValve.Visible = True

    End Sub

    Private Sub picDry21_VV_Y132_Click(sender As Object, e As EventArgs) Handles picDry21_VV_Y132.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 6
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "Chamber Slow Rough Valver"
        panValve.Visible = True

    End Sub

    Private Sub picDry22_VV_Y134_Click(sender As Object, e As EventArgs) Handles picDry22_VV_Y134.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 7
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "Chamber Fast Rough Valve"
        panValve.Visible = True
    End Sub

    Private Sub picDry1_VV_Y136_Click(sender As Object, e As EventArgs) Handles picDry1_VV_Y136.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 8
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "TMP Foreline Valve"
        panValve.Visible = True
    End Sub

    Private Sub picN2_VV_Y15C_Click(sender As Object, e As EventArgs) Handles picN2_VV_Y15C.Click
        If panValve.Visible = True Then Exit Sub

        panValve.Left = 813
        panValve.Top = 443
        panValve.Tag = 13
        btnValveOpen.Text = "OPEN"
        btnValveClose.Text = "CLOSE"
        grpValve.Text = "BSP Pumping Valve"
        panValve.Visible = True
    End Sub


    Private Sub numPowerSupply_SV_GotFocus(sender As Object, e As EventArgs) Handles numPowerSupply_SV.GotFocus, numMFC1_SV.GotFocus, numMFC2_SV.GotFocus,
                                                                                    numRF_Power_SV1.GotFocus, numDC_Power_SV1.GotFocus, numDry_Off_Delay_SV.GotFocus,
                                                                                    numBSP_Pressure_Alarm_SV.GotFocus, numBSP_Pressure_Alarm_SV_Square.GotFocus, numBaratonGauge_SV.GotFocus
        SV_Focus = True
        'Debug.Print("SV_Focus = True")
    End Sub
    Private Sub numRF_Power_SV1_MouseDown(sender As Object, e As MouseEventArgs) Handles numRF_Power_SV1.MouseDown, numMFC1_SV.MouseDown, numMFC2_SV.MouseDown,
                                                                                    numRF_Power_SV1.MouseDown, numDC_Power_SV1.MouseDown, numDry_Off_Delay_SV.MouseDown,
                                                                                    numBSP_Pressure_Alarm_SV.MouseDown, numBSP_Pressure_Alarm_SV_Square.MouseDown, numBaratonGauge_SV.MouseDown
        SV_Focus = True
    End Sub

    Private Sub numTempSV1_GotFocus(sender As Object, e As EventArgs) Handles numTempSV1.GotFocus, numTempSV2.GotFocus, numTagetTime1.GotFocus, numTagetTime2.GotFocus
        Temp_Set_Focus = True
    End Sub
    Private Sub numTempSV1_MouseDown(sender As Object, e As MouseEventArgs) Handles numTempSV1.MouseDown, numTempSV2.MouseDown, numTagetTime1.MouseDown, numTagetTime2.MouseDown
        Temp_Set_Focus = True
    End Sub

    Private Sub numTempSV1_Click(sender As Object, e As EventArgs) Handles numTempSV1.Click, numTempSV2.Click, numTagetTime1.Click, numTagetTime1.Click,
                                                                            numTempDeviation.Click
        Dim old As Long

        Temp_Set_Focus = True

        If Environment.Is64BitOperatingSystem Then
            '64 Bit
            If Wow64DisableWow64FsRedirection(old) Then
                pOSK = Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            '32 Bit
            pOSK = Process.Start(osk)
        End If

    End Sub

    Private Sub TabControl_Click(sender As Object, e As EventArgs) Handles TabControl.Click
        SV_Focus = False
        Temp_Set_Focus = False
        Recipe_Cell_Focus = False
        Label1.Focus()
    End Sub

    Private Sub TabControl_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl.TabIndexChanged

        If TabControl.SelectedIndex = 2 Then
            If WorkStatus = RUN_ Then TabControl.SelectedIndex = 1
        End If

    End Sub

    Private Sub numPowerSupply_SV_LostFocus(sender As Object, e As EventArgs) Handles numPowerSupply_SV.LostFocus, numMFC1_SV.LostFocus, numMFC2_SV.LostFocus,
                                                                                    numRF_Power_SV1.LostFocus, numDC_Power_SV1.LostFocus, numDry_Off_Delay_SV.LostFocus,
                                                                                    numBSP_Pressure_Alarm_SV.LostFocus, numBSP_Pressure_Alarm_SV_Square.LostFocus, numBaratonGauge_SV.LostFocus
        'SV_Focus = False
        'Debug.Print("SV_Focus = False")
    End Sub
    Private Sub numPowerSupply_SV_Click(sender As Object, e As EventArgs) Handles numPowerSupply_SV.Click, numMFC1_SV.Click, numMFC2_SV.Click,
                                                                                    numRF_Power_SV1.Click, numDC_Power_SV1.Click, numDry_Off_Delay_SV.Click,
                                                                                    numBSP_Pressure_Alarm_SV.Click, numBSP_Pressure_Alarm_SV_Square.Click, numBaratonGauge_SV.Click

        Dim old As Long

        SV_Focus = True

        If Environment.Is64BitOperatingSystem Then
            '64 Bit
            If Wow64DisableWow64FsRedirection(old) Then
                pOSK = Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            '32 Bit
            pOSK = Process.Start(osk)
        End If


    End Sub

    Private Sub numMFC1_SV_KeyDown(sender As Object, e As KeyEventArgs) Handles numMFC1_SV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("D1020", 1, numMFC1_SV.Value)
                Label1.Focus()
                'Debug.Print("txtMFC1_SV Enter ~")

        End Select
    End Sub


    Private Sub numMFC2_SV_KeyDown(sender As Object, e As KeyEventArgs) Handles numMFC2_SV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("D1022", 1, numMFC2_SV.Value * 10)
                Label1.Focus()

        End Select
    End Sub


    Private Sub numRF_Power_SV1_KeyDown(sender As Object, e As KeyEventArgs) Handles numRF_Power_SV1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("D1054", 1, numRF_Power_SV1.Value)
                Label1.Focus()

        End Select
    End Sub

    Private Sub numDC_Power_SV1_KeyDown(sender As Object, e As KeyEventArgs) Handles numDC_Power_SV1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("D1050", 1, numDC_Power_SV1.Value)
                Label1.Focus()

        End Select
    End Sub

    Private Sub numDry_Off_Delay_SV_KeyDown(sender As Object, e As KeyEventArgs) Handles numDry_Off_Delay_SV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR120", 1, numDry_Off_Delay_SV.Value)
                Label1.Focus()

        End Select
    End Sub

    Private Sub numBSP_Pressure_Alarm_SV_KeyDown(sender As Object, e As KeyEventArgs) Handles numBSP_Pressure_Alarm_SV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("D210", 1, numBSP_Pressure_Alarm_SV.Value * 10)
                Label1.Focus()

        End Select
    End Sub

    Private Sub numBSP_Pressure_Alarm_SV_Square_KeyDown(sender As Object, e As KeyEventArgs) Handles numBSP_Pressure_Alarm_SV_Square.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                iReturnCode = AxActUtlType1.WriteDeviceBlock("D211", 1, numBSP_Pressure_Alarm_SV_Square.Value)
                Label1.Focus()

        End Select
    End Sub



    Private Sub numBaratonGauge_SV_KeyDown(sender As Object, e As KeyEventArgs) Handles numBaratonGauge_SV.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SV_Focus = False
                Call Work_data_String_Write_D(1080, 3, numBaratonGauge_SV.Value)
                Label1.Focus()

        End Select

    End Sub

    Private Sub numTempSV1_KeyDown(sender As Object, e As KeyEventArgs) Handles numTempSV1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                'Temp_Set_Focus = False
                UP35A_SetDataTransFlag = True
                Label1.Focus()

        End Select
    End Sub

    Private Sub numTempSV2_KeyDown(sender As Object, e As KeyEventArgs) Handles numTempSV2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                'Temp_Set_Focus = False
                UP35A_SetDataTransFlag = True
                Label1.Focus()

        End Select
    End Sub

    Private Sub numTagetTime1_KeyDown(sender As Object, e As KeyEventArgs) Handles numTagetTime1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                'Temp_Set_Focus = False
                UP35A_SetDataTransFlag = True
                Label1.Focus()

        End Select
    End Sub

    Private Sub numTagetTime2_KeyDown(sender As Object, e As KeyEventArgs) Handles numTagetTime2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                'Temp_Set_Focus = False
                UP35A_SetDataTransFlag = True
                Label1.Focus()

        End Select
    End Sub

    Private Sub numTempDeviation_KeyDown(sender As Object, e As KeyEventArgs) Handles numTempDeviation.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                Temp_Set_Focus = False
                Label1.Focus()

        End Select
    End Sub

    Private Sub btnThrottleValve_PositionMove_Click(sender As Object, e As EventArgs) Handles btnThrottleValve_PositionMove.Click

    End Sub

    Private Sub LstModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstModel.SelectedIndexChanged
        Me.cboModel.SelectedIndex = Me.LstModel.SelectedIndex
    End Sub

    Private Sub cboModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModel.SelectedIndexChanged
        Dim model_infor() As String

        Try
            MsgDisplay("Recipe Loading...", Color.Orange, 0)
            '    DoEvents


            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            model_infor = Split(cboModel.Text, ",")

            If (LoadFile_Work(model_infor(0))) Then

                Model = model_infor(0)

                'Me.LblModel.Text = "(" & "모델 : " & cboModel.Text & ")"
                Me.LblModel.Text = "RECIPE : " & model_infor(0)

                MsgDisplay("", Color.Red, 0)

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

                Me.LstModel.SelectedIndex = Me.cboModel.SelectedIndex

                '** Last Model index Save
                gLastModelindex = Me.LstModel.SelectedIndex
                SaveSystemSettings()

                'Result_Title = vbTab & "Time" & "," & vbTab & "dmmHg Val" & "," & vbTab & "sccm Val" & "," & vbTab & "리크판정" ' & "," & vbTab & "VIS 판정"


                'Result_Title = "시간" & "," & vbTab &
                '               "유닛 번호." & "," & vbTab &
                '               "QR" & "," & vbTab &
                '               "저항(Ω)" & "," & vbTab &
                '               "전압(V)" & "," & vbTab &
                '               "작업자"

                Modelindex = Me.LstModel.SelectedIndex


            Else
                MsgDisplay("Recipe Load Fail", Color.Orange, 0)
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            End If

        Catch ex As Exception
            Debug.Print("cboModel Err : " & ex.Message)
        End Try
    End Sub

    Private Sub butDelModel_Click(sender As Object, e As EventArgs) Handles butDelModel.Click
        Dim Response As Object
        Dim model_infor() As String

        On Error GoTo ErrorHandler


        If LstModel.Items.Count = 1 Then Exit Sub

        If LstModel.SelectedIndex = -1 Then
            MsgDisplay("Select Recipe ?", Color.Red, 0)
            Exit Sub
        End If

        Response = MsgBox(LstModel.Text & " Delete ?", MsgBoxStyle.YesNo)

        If Response = 7 Then Exit Sub

        model_infor = Split(LstModel.Text, ",")
        Kill(My.Application.Info.DirectoryPath & "\SetData" & "\" & model_infor(0) & "_" & "*.set")

        Me.cboModel.Items.RemoveAt(LstModel.SelectedIndex)
        LstModel.Items.RemoveAt(LstModel.SelectedIndex)

        Model = ""
        Me.LblModel.Text = ""

        Call SaveFile_Model()

        Exit Sub
ErrorHandler:
        Debug.Print(Err.Number & Err.Description)
        If Err.Number = 53 Then Resume Next
    End Sub

    Private Sub butInPutModelName_Click(sender As Object, e As EventArgs) Handles butInPutModelName.Click
        Dim sDateTime As String

        If TxtModelName.Text = "" Then
            MsgDisplay("Input Recipe Name !", Color.Red, 0)
            Exit Sub
        End If

        sDateTime = Format(Now, "yyMMdd" & "_" & "HHmmss")
        LstModel.Items.Add(TxtModelName.Text & ", " & sDateTime)
        Me.cboModel.Items.Add(TxtModelName.Text & ", " & sDateTime)

        '    LstModel.List(LstModel.ListIndex) = TxtModelName.Text
        '    FrmMain.LblModel.Caption = TxtModelName.Text

        Call SaveFile_Model()

        Call SaveFile_Work((TxtModelName.Text))
        'Call SaveRef()
    End Sub


    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Recipe_Cell_Focus = True

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim buf As String
        Dim dec1 As String
        Dim dec2 As String

        If e.ColumnIndex <> 1 Then Exit Sub

        If IsNumeric(DataGridView1(e.ColumnIndex, e.RowIndex).Value) Then
            Select Case e.RowIndex
                Case 0
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value < 0 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 0
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value > 2000 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 2000
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR20", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 1
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value < 0 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 0
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value > 5 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 5
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR22", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 2
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR30", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 3
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR31", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 4
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR40", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 5
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR41", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 6
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR60", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 7
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR61", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 8
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR70", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 9
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR71", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 10
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value < 0 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 0
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value > 2000 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 2000
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR50", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 11
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value < 0 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 0
                    If DataGridView1(e.ColumnIndex, e.RowIndex).Value > 1000 Then DataGridView1(e.ColumnIndex, e.RowIndex).Value = 1000
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR54", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 12
                    Call Work_data_String_Write_ZR(80, 3, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 13
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR92", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 92, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 14
                    iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR110", 1, DataGridView1(e.ColumnIndex, e.RowIndex).Value)
                Case 15
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR112", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 112, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 16
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR94", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 94, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 17
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR96", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 96, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 18
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR90", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 90, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 19
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR98", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 98, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 20
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR102", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 102, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 21
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR104", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 104, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 22
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR100", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 100, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 23
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR106", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 106, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                Case 24
                    'iReturnCode = AxActUtlType1.WriteDeviceBlock("ZR106", 2, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
                    Call DoubleDataWrite("ZR", 108, DataGridView1(e.ColumnIndex, e.RowIndex).Value * 10)
            End Select

        Else

        End If

        Recipe_Cell_Focus = False
    End Sub

    Private Sub btnDataSave_Click(sender As Object, e As EventArgs) Handles btnDataSave.Click
        Dim dec() As String
        Dim dec1 As String = ""
        Dim dec2 As String = ""

        Call MsgDisplay("Save Start...", Color.Lime, 0)

        'With tIni.tEQVaiIni
        '    .Door_Sen_Chk = Me.chkDoorPass.Checked
        '    .Area_Sen_Chk = Me.chkAreaPass.Checked
        '    .NumOCV_Retry_CNT = Me.NumOCV_Retry_CNT.Value
        '    .NumListView_CNT = Me.NumListView_CNT.Value
        'End With
        'Call Save_EQ_Val_ini()


        With WorkData
            .StepCNT = numStepCNT.Value
            For i = 0 To 0  '4
                .ZR(i, 20) = DataGridView1(i + 1, 0).Value
                .ZR(i, 22) = DataGridView1(i + 1, 1).Value * 10
                .ZR(i, 30) = DataGridView1(i + 1, 2).Value * 10
                .ZR(i, 31) = DataGridView1(i + 1, 3).Value
                .ZR(i, 40) = DataGridView1(i + 1, 4).Value * 10
                .ZR(i, 41) = DataGridView1(i + 1, 5).Value
                .ZR(i, 60) = DataGridView1(i + 1, 6).Value * 10
                .ZR(i, 61) = DataGridView1(i + 1, 7).Value
                .ZR(i, 70) = DataGridView1(i + 1, 8).Value * 10
                .ZR(i, 71) = DataGridView1(i + 1, 9).Value
                .ZR(i, 50) = DataGridView1(i + 1, 10).Value
                .ZR(i, 54) = DataGridView1(i + 1, 11).Value
                Call Work_data_String_ReturnEach(3, DataGridView1(i + 1, 12).Value, dec)
                .ZR(i, 80) = dec(0)
                .ZR(i, 81) = dec(1)
                .ZR(i, 82) = dec(2)
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 13).Value * 10, dec1, dec2)
                .ZR(i, 92) = dec1
                .ZR(i, 93) = dec2
                .ZR(i, 110) = DataGridView1(i + 1, 14).Value
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 15).Value * 10, dec1, dec2)
                .ZR(i, 112) = dec1
                .ZR(i, 113) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 16).Value * 10, dec1, dec2)
                .ZR(i, 94) = dec1
                .ZR(i, 95) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 17).Value * 10, dec1, dec2)
                .ZR(i, 96) = dec1
                .ZR(i, 97) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 18).Value * 10, dec1, dec2)
                .ZR(i, 90) = dec1
                .ZR(i, 91) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 19).Value * 10, dec1, dec2)
                .ZR(i, 98) = dec1
                .ZR(i, 99) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 20).Value * 10, dec1, dec2)
                .ZR(i, 102) = dec1
                .ZR(i, 103) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 21).Value * 10, dec1, dec2)
                .ZR(i, 104) = dec1
                .ZR(i, 105) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 22).Value * 10, dec1, dec2)
                .ZR(i, 100) = dec1
                .ZR(i, 101) = dec2
                dec1 = "" : dec2 = ""
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 23).Value * 10, dec1, dec2)
                .ZR(i, 106) = dec1
                .ZR(i, 107) = dec2
                Call DoubleData_ReturnEach(DataGridView1(i + 1, 24).Value * 10, dec1, dec2)
                .ZR(i, 108) = dec1
                .ZR(i, 109) = dec2
            Next
        End With

        Call SaveFile_Work(Model)
        Call SaveFile_Model()
    End Sub


    Private Sub btnAlarmReset_Click(sender As Object, e As EventArgs) Handles btnAlarmReset.Click

    End Sub

    Private Sub btnBuzzerStop_Click(sender As Object, e As EventArgs) Handles btnBuzzerStop.Click
        If PlcData_M_bit(20) = 1 Then
            iReturnCode = AxActUtlType1.WriteDeviceRandom("M20", 1, 0) 'bit
        ElseIf PlcData_M_bit(20) = 0 Then
            iReturnCode = AxActUtlType1.WriteDeviceRandom("M20", 1, 1) 'bit
        End If

    End Sub

    Private Sub btnAlarmReset_MouseDown(sender As Object, e As MouseEventArgs) Handles btnAlarmReset.MouseDown
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M5", 1, 1) 'bit
    End Sub

    Private Sub btnAlarmReset_MouseUp(sender As Object, e As MouseEventArgs) Handles btnAlarmReset.MouseUp
        iReturnCode = AxActUtlType1.WriteDeviceRandom("M5", 1, 0) 'bit
    End Sub


    Private Sub Serial_Initial()
        Dim ComSet() As String

        'Parity()
        '0 = None
        '1 = Odd
        '2 = Even
        '3 = Mark
        '4 = Space

        'Handshake()
        '0 = None
        '1 = XOnXOff
        '2 = RequestToSend
        '3 = Handshake.RequestToSendXOnXOff


        '** TM4_N2SB
        ' Create a new SerialPort object with default settings.
        With tIni.tEQValIni
            SIO_UP35A = New SerialPort()
            SIO_UP35A.PortName = .UP35A_Com_Port  '"com3" 
            ComSet = Split(.UP35A_Com_Set, ",")
            SIO_UP35A.BaudRate = ComSet(0)           '"19200"
            SIO_UP35A.Parity = ComSet(1)             '"2" 
            SIO_UP35A.DataBits = ComSet(2)           '"8"
            SIO_UP35A.StopBits = ComSet(3)           '"1"
            SIO_UP35A.Handshake = ComSet(4)          '"0"
            SIO_UP35A.DtrEnable = True

            SIO_UP35A1 = New SerialPort()
            SIO_UP35A1.PortName = .UP35A1_Com_Port    '"com4"
            ComSet = Split(.UP35A1_Com_Set, ",")
            SIO_UP35A1.BaudRate = ComSet(0)           '"19200"
            SIO_UP35A1.Parity = ComSet(1)             '"2" 
            SIO_UP35A1.DataBits = ComSet(2)           '"8"
            SIO_UP35A1.StopBits = ComSet(3)           '"1"
            SIO_UP35A1.Handshake = ComSet(4)          '"0"
            SIO_UP35A1.DtrEnable = True

        End With


        Try
            If (SIO_UP35A.IsOpen = False) Then
                SIO_UP35A.Open()
                _continue_0 = True
                Read_UP35A_Thread.Start()

                UP35A_FuncChk = True
                Call CRC16_init()

            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            MsgDisplay("UP35A-1 Comport Open Err" & ex.Message.ToString, Color.Red, 0)
            WorkStatus = ERROR_
        End Try

        'Try
        '    If (SIO_UP35A1.IsOpen = False) Then
        '        SIO_UP35A1.Open()
        '        _continue_1 = True
        '        Read_UP35A_Thread1.Start()

        '        UP35A_FuncChk1 = True
        '        Call CRC16_init()

        '    End If
        'Catch ex As Exception
        '    Debug.Print(ex.Message)
        '    MsgDisplay("UP35A-2 Comport Open Err" & ex.Message.ToString, Color.Red, 0)
        '    WorkStatus = ERROR_
        'End Try



    End Sub

    Public Sub Read_TM4_N2SB_Old()
        'Dim rBuf As Object
        'Dim RChar As Byte
        'Dim TempValue As String
        'Dim CRC As Long
        'Dim Pv_Deviation As Short

        'Dim msg As String = ""
        'Dim msgLength As Integer = 0


        'While (_continue_0)

        '    Try
        '        rBuf = SIO_TM4_N2SB.ReadByte
        '        RChar = rBuf   'Hex(rBuf)       'Asc(rBuf)
        '        'Debug.Print("Buff = " & RChar)

        '        TM4_N2SB_Receive(TM4_N2SB_rpos) = RChar
        '        'TM4_N2SB_ReceiveMsg = TM4_N2SB_ReceiveMsg & VB.Right("00" & Asc(RChar), 2) & " "
        '        TM4_N2SB_ReceiveMsg += Hex(RChar) & " "
        '        'Debug.Print("asdf = " & Asc(RChar))
        '        'Debug.Print("Rec Byte = " & Hex(RChar))

        '        TM4_N2SB_rpos = TM4_N2SB_rpos + 1

        '        'Debug.Print("ReadByte = " & TM4_N2SB_ReceiveMsg)

        '        If (TM4_N2SB_PV_Receive_ing = True Or TM4_N2SB_SV_Set_Receive_ing = True Or TM4_N2SB_Ctrl_Set_Receive_ing = True) And (TM4_N2SB_rpos >= TM4_N2SB_ReceiveSize) Then

        '            CRC = CRC16table_packet(TM4_N2SB_Receive, TM4_N2SB_rpos - 2)
        '            If ((CRC And 255) = TM4_N2SB_Receive(TM4_N2SB_rpos - 2)) And ((Fix(CRC / 256) And 255) = TM4_N2SB_Receive(TM4_N2SB_rpos - 1)) Then
        '                'Debug.Print("Tm4-N2SB = " & TM4_N2SB_Receive(1))
        '                'Debug.Print("Rec Msg : " & TM4_N2SB_ReceiveMsg)
        '                If TM4_N2SB_Receive(1) = 4 Or TM4_N2SB_Receive(1) = 132 Then 'Command 4
        '                    TM4_N2SB_MT_ReTryCNT = 0

        '                    'Debug.Print((Heater_PVIndex_CntChk - 1) & "_Tm4 Rec Msg : " & TM4_N2SB_ReceiveMsg)
        '                    'Debug.Print(Convert.ToInt16(Hex(TM4_N2SB_Receive(3)) & Hex(TM4_N2SB_Receive(4)), 16) / (10 ^ TM4_N2SB_Receive(6)))
        '                    'Debug.Print(((TM4_N2SB_Receive(3) * 256) + TM4_N2SB_Receive(4)) / (10 ^ TM4_N2SB_Receive(6)))

        '                    'TM4_temp(Heater_PVIndex_CntChk - 1) = Convert.ToInt16(Hex(TM4_N2SB_Receive(3)) & Hex(TM4_N2SB_Receive(4)), 16) / (10 ^ TM4_N2SB_Receive(6))
        '                    TempValue = Val("&H" & VB.Right("00" & Hex(TM4_N2SB_Receive(3)), 2) & VB.Right("00" & Hex(TM4_N2SB_Receive(4)), 2)) / (10 ^ TM4_N2SB_Receive(6)).ToString
        '                    TM4_temp(Heater_PVIndex_CntChk - 1) = TempValue

        '                    'Debug.Print("Pv_" & Heater_PVIndex_CntChk - 1 & " : " & TM4_temp(Heater_PVIndex_CntChk - 1))
        '                    ''** Temp Offset
        '                    'With tIni.tTempOffset
        '                    '    TM4_temp(Heater_PVIndex_CntChk - 1) += CShort(.tOffset(Heater_PVIndex_CntChk - 1))
        '                    'End With
        '                    'If Heater_PVIndex_CntChk - 1 = 22 Then Debug.Print("PV-C")

        '                    If TM4_N2SB_Receive(1) = 132 Then Debug.Print("Tm4 Rec Err")

        '                    ''** Hunting Val Exchange
        '                    'If FirstPV = False Then
        '                    '    If TM4_temp(Heater_PVIndex_CntChk - 1) <> 31000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> -30000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> 30000 Then
        '                    '        TM4_temp_old(Heater_PVIndex_CntChk - 1) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    '    End If
        '                    'Else
        '                    '    'Pv_Deviation = Math.Abs(TM4_temp_old(Heater_PVIndex_CntChk - 1) - TM4_temp(Heater_PVIndex_CntChk - 1))
        '                    '    Pv_Deviation = TM4_temp_old(Heater_PVIndex_CntChk - 1) - TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    '    If Pv_Deviation >= 100 Then
        '                    '        If TM4_temp(Heater_PVIndex_CntChk - 1) <> 31000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> -30000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> 30000 Then
        '                    '            Debug.Print("Te_" & Heater_PVIndex_CntChk - 1 & " = " & TM4_temp(Heater_PVIndex_CntChk - 1))
        '                    '            TM4_temp(Heater_PVIndex_CntChk - 1) = TM4_temp_old(Heater_PVIndex_CntChk - 1)
        '                    '        End If
        '                    '    Else
        '                    '        TM4_temp_old(Heater_PVIndex_CntChk - 1) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    '    End If
        '                    'End If


        '                    Chart1Data(Heater_PVIndex_CntChk, Temp_Reading_Count) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    'lblPV(Heater_PVIndex_CntChk - 1).Text = "PV:" & TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    TM4_N2SB_ReceiveOK = True
        '                    TM4_N2SB_PV_Receive_ing = False
        '                    TM4_Send_DelayChk = GetTickCount + 80  ' 600

        '                ElseIf TM4_N2SB_Receive(1) = 6 Then 'Command 6
        '                    'ch1
        '                    'ch2
        '                    'ch3
        '                    'ch4
        '                    If (TM4_N2SB_Receive(2) = 0 And TM4_N2SB_Receive(3) = 0) Or
        '                        (TM4_N2SB_Receive(2) = 3 And TM4_N2SB_Receive(3) = 232) Or
        '                        (TM4_N2SB_Receive(2) = 7 And TM4_N2SB_Receive(3) = 208) Or
        '                        (TM4_N2SB_Receive(2) = 11 And TM4_N2SB_Receive(3) = 184) Then
        '                        TM4_N2SB_SV_Set_Receive_ing = False
        '                        Debug.Print("SV Set. Receive")
        '                    End If
        '                    If (TM4_N2SB_Receive(2) = 0 And TM4_N2SB_Receive(3) = 50) Or
        '                        (TM4_N2SB_Receive(2) = 4 And TM4_N2SB_Receive(3) = 26) Or
        '                        (TM4_N2SB_Receive(2) = 8 And TM4_N2SB_Receive(3) = 2) Or
        '                        (TM4_N2SB_Receive(2) = 11 And TM4_N2SB_Receive(3) = 234) Then
        '                        TM4_N2SB_Ctrl_Set_Receive_ing = False
        '                        Debug.Print("Ctrl set. Receive")
        '                    End If
        '                Else
        '                    Debug.Print("수신 펑션 블럭값이 지령값과 틀림 = " & TM4_N2SB_ReceiveMsg)
        '                    Debug.Print((Heater_PVIndex_CntChk - 1) & "_Tm4 Rec Msg : " & TM4_N2SB_ReceiveMsg)
        '                    Call WriteLogInText("수신 펑션 블럭값이 지령값과 틀림 = " & TM4_N2SB_ReceiveMsg)
        '                    SIO_TM4_N2SB.DiscardInBuffer()
        '                End If
        '            Else
        '                'MT_ReTryCNT += 1
        '                TM4_N2SB_PV_Receive_ing = False
        '                Debug.Print("온도값 수신 CRC 체크가 틀림.")
        '                Call WriteLogInText("온도값 수신 CRC 체크가 틀림.")
        '            End If

        '        ElseIf TM4_N2SB_rpos = 5 Then
        '            '** Err Receive
        '            If Hex(TM4_N2SB_Receive(1)) >= 128 Then
        '                'MT_ReTryCNT += 1
        '                TM4_N2SB_PV_Receive_ing = False
        '                Debug.Print("온도수신 Comm Err Code = " & Hex(TM4_N2SB_Receive(2)))
        '                Call WriteLogInText("온도수신 Comm Err Code = " & Hex(TM4_N2SB_Receive(2)))
        '            End If
        '        End If
        '    Catch ex As Exception ' TimeoutException
        '        ' Do nothing
        '        'TM4_N2SB_Rec = ""
        '        TM4_N2SB_Receive.Initialize()
        '        TM4_N2SB_PV_Receive_ing = False
        '        TM4_N2SB_SV_Set_Receive_ing = False
        '        TM4_N2SB_Ctrl_Set_Receive_ing = False
        '        Debug.Print("TM4_N2SB Comm Err : " & ex.Message)

        '    End Try
        '    BalanceThreadScheduling()       ' 쓰레드 안정화 타임
        'End While
    End Sub

    Public Sub Read_TM4_N2SB1_Old()
        'Dim rBuf As Object
        'Dim RChar As Byte
        ''Dim i As Integer
        'Dim CRC As Long
        'Dim Pv_Deviation As Short
        'Dim TempValue As String
        'Dim msg As String = ""
        'Dim msgLength As Integer = 0


        'While (_continue_1)

        '    Try
        '        rBuf = SIO_TM4_N2SB1.ReadByte
        '        RChar = rBuf   'Hex(rBuf)       'Asc(rBuf)
        '        'Debug.Print("Buff = " & RChar)

        '        TM4_N2SB_Receive1(TM4_N2SB_rpos1) = RChar
        '        'TM4_N2SB_ReceiveMsg1 = TM4_N2SB_ReceiveMsg1 & VB.Right("00" & Asc(RChar), 2) & " "
        '        TM4_N2SB_ReceiveMsg1 += Hex(RChar) & " "
        '        'Debug.Print("asdf = " & Asc(RChar))

        '        TM4_N2SB_rpos1 = TM4_N2SB_rpos1 + 1

        '        'Debug.Print("ReadByte = " & TM4_N2SB_Receive1Msg)

        '        If (TM4_N2SB_PV_Receive_ing = True Or TM4_N2SB_SV_Set_Receive_ing = True Or TM4_N2SB_Ctrl_Set_Receive_ing = True) And (TM4_N2SB_rpos1 >= TM4_N2SB_ReceiveSize1) Then
        '            'Debug.Print("Rec Msg : " & TM4_N2SB_ReceiveMsg1)

        '            CRC = CRC16table_packet(TM4_N2SB_Receive1, TM4_N2SB_rpos1 - 2)
        '            If ((CRC And 255) = TM4_N2SB_Receive1(TM4_N2SB_rpos1 - 2)) And ((Fix(CRC / 256) And 255) = TM4_N2SB_Receive1(TM4_N2SB_rpos1 - 1)) Then

        '                If TM4_N2SB_Receive1(1) = 4 Or TM4_N2SB_Receive1(1) = 132 Then 'Command 4
        '                    TM4_N2SB_MT_ReTryCNT1 = 0

        '                    'Debug.Print((Heater_PVIndex_CntChk - 1) & "_Tm41 Rec Msg : " & TM4_N2SB_ReceiveMsg1)
        '                    'Debug.Print(Convert.ToInt16(Hex(TM4_N2SB_Receive1(3)) & Hex(TM4_N2SB_Receive1(4)), 16) / (10 ^ TM4_N2SB_Receive1(6)))
        '                    'Debug.Print(((TM4_N2SB_Receive1(3) * 256) + TM4_N2SB_Receive1(4)) / (10 ^ TM4_N2SB_Receive1(6)))

        '                    'TM4_temp(Heater_PVIndex_CntChk - 1) = Convert.ToInt16(Hex(TM4_N2SB_Receive1(3)) & Hex(TM4_N2SB_Receive1(4)), 16) / (10 ^ TM4_N2SB_Receive1(6))
        '                    TempValue = Val("&H" & VB.Right("00" & Hex(TM4_N2SB_Receive1(3)), 2) & VB.Right("00" & Hex(TM4_N2SB_Receive1(4)), 2)) / (10 ^ TM4_N2SB_Receive1(6)).ToString
        '                    TM4_temp(Heater_PVIndex_CntChk - 1) = TempValue

        '                    ''** Temp Offset
        '                    'With tIni.tTempOffset
        '                    '    TM4_temp(Heater_PVIndex_CntChk - 1) += CShort(.tOffset(Heater_PVIndex_CntChk - 1))
        '                    'End With

        '                    If TM4_N2SB_Receive1(1) = 132 Then Debug.Print("Tm41 Rec Err")

        '                    ''** Hunting Val Exchange
        '                    'If FirstPV = False Then
        '                    '    If TM4_temp(Heater_PVIndex_CntChk - 1) <> 31000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> -30000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> 30000 Then
        '                    '        TM4_temp_old(Heater_PVIndex_CntChk - 1) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    '    End If
        '                    'Else
        '                    '    'Pv_Deviation = Math.Abs(TM4_temp_old(Heater_PVIndex_CntChk - 1) - TM4_temp(Heater_PVIndex_CntChk - 1))
        '                    '    Pv_Deviation = TM4_temp_old(Heater_PVIndex_CntChk - 1) - TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    '    If Pv_Deviation >= 100 Then
        '                    '        If TM4_temp(Heater_PVIndex_CntChk - 1) <> 31000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> -30000 And TM4_temp(Heater_PVIndex_CntChk - 1) <> 30000 Then
        '                    '            Debug.Print("Te1_" & Heater_PVIndex_CntChk - 1 & " = " & TM4_temp(Heater_PVIndex_CntChk - 1))
        '                    '            TM4_temp(Heater_PVIndex_CntChk - 1) = TM4_temp_old(Heater_PVIndex_CntChk - 1)
        '                    '        End If
        '                    '    Else
        '                    '        TM4_temp_old(Heater_PVIndex_CntChk - 1) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    '    End If
        '                    'End If

        '                    'Debug.Print("Temp: " & Heater_Index_CntChk & "  value : " & TM4_temp(Heater_Index_CntChk - 1))
        '                    If (Heater_PVIndex_CntChk) <= (TM4_1GroupCnt_ + 39) Then    '** 상부
        '                        Chart1Data(Heater_PVIndex_CntChk, Temp_Reading_Count) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    Else    '** 하부
        '                        Chart2Data((Heater_PVIndex_CntChk - 99), Temp_Reading_Count) = TM4_temp(Heater_PVIndex_CntChk - 1)
        '                    End If

        '                    'lblPV(Heater_PVIndex_CntChk - 1).Text = "PV:" & TM4_temp(Heater_PVIndex_CntChk - 1)

        '                    If Heater_PVIndex_CntChk >= HeaterCNT_ Then Heater_PVIndex_CntChk = 0
        '                    TM4_N2SB_ReceiveOK1 = True
        '                    TM4_N2SB_PV_Receive_ing = False
        '                    TM4_Send_DelayChk = GetTickCount + 80   '600

        '                ElseIf TM4_N2SB_Receive1(1) = 6 Then 'Command 6
        '                    'ch1
        '                    'ch2
        '                    'ch3
        '                    'ch4
        '                    If (TM4_N2SB_Receive1(2) = 0 And TM4_N2SB_Receive1(3) = 0) Or
        '                        (TM4_N2SB_Receive1(2) = 3 And TM4_N2SB_Receive1(3) = 232) Or
        '                        (TM4_N2SB_Receive1(2) = 7 And TM4_N2SB_Receive1(3) = 208) Or
        '                        (TM4_N2SB_Receive1(2) = 11 And TM4_N2SB_Receive1(3) = 184) Then
        '                        TM4_N2SB_SV_Set_Receive_ing = False
        '                        Debug.Print("SV Set. Receive1")
        '                    End If
        '                    If (TM4_N2SB_Receive1(2) = 0 And TM4_N2SB_Receive1(3) = 50) Or
        '                        (TM4_N2SB_Receive1(2) = 4 And TM4_N2SB_Receive1(3) = 26) Or
        '                        (TM4_N2SB_Receive1(2) = 8 And TM4_N2SB_Receive1(3) = 2) Or
        '                        (TM4_N2SB_Receive1(2) = 11 And TM4_N2SB_Receive1(3) = 234) Then
        '                        TM4_N2SB_Ctrl_Set_Receive_ing = False
        '                        Debug.Print("Ctrl set. Receive1")
        '                    End If

        '                Else
        '                    Debug.Print("TM4_N2SB1, 수신 펑션 블럭값이 지령값과 틀림 = " & TM4_N2SB_ReceiveMsg1)
        '                    Debug.Print((Heater_PVIndex_CntChk - 1) & "_Tm41 Rec Msg : " & TM4_N2SB_ReceiveMsg1)
        '                    Call WriteLogInText("TM4_N2SB1, 수신 펑션 블럭값이 지령값과 틀림 = " & TM4_N2SB_ReceiveMsg1)
        '                    SIO_TM4_N2SB1.DiscardInBuffer()
        '                End If
        '            Else
        '                'MT_ReTryCNT += 1
        '                TM4_N2SB_PV_Receive_ing = False
        '                Debug.Print("TM4_N2SB1, 온도값 수신 CRC 체크가 틀림.")
        '                Call WriteLogInText("TM4_N2SB1, 온도값 수신 CRC 체크가 틀림.")
        '            End If

        '        ElseIf TM4_N2SB_rpos1 = 5 Then
        '            '** Err Receive
        '            If Hex(TM4_N2SB_Receive1(1)) >= 128 Then
        '                'MT_ReTryCNT += 1
        '                TM4_N2SB_PV_Receive_ing = False
        '                Debug.Print("TM4_N2SB1, 온도수신 Comm Err Code = " & Hex(TM4_N2SB_Receive1(2)))
        '                Call WriteLogInText("TM4_N2SB1, 온도수신 Comm Err Code = " & Hex(TM4_N2SB_Receive1(2)))
        '            End If
        '        End If
        '    Catch ex As Exception ' TimeoutException
        '        ' Do nothing
        '        'TM4_N2SB_Rec = ""
        '        TM4_N2SB_Receive1.Initialize()
        '        TM4_N2SB_PV_Receive_ing = False
        '        TM4_N2SB_SV_Set_Receive_ing = False
        '        TM4_N2SB_Ctrl_Set_Receive_ing = False
        '        Debug.Print("TM4_N2SB1 Comm Err : " & ex.Message)

        '    End Try

        '    BalanceThreadScheduling()

        'End While
    End Sub

    Public Sub Read_UP35A()
        Dim rBuf As Object
        Dim RChar As Byte
        Dim TempValue As String
        Dim CRC As Long
        Dim Pv_Deviation As Short

        Dim msg As String = ""
        Dim msgLength As Integer = 0


        While (_continue_0)

            Try
                rBuf = SIO_UP35A.ReadByte
                RChar = rBuf   'Hex(rBuf)       'Asc(rBuf)
                'Debug.Print("Buff = " & RChar)

                UP35A_Receive(UP35A_rpos) = RChar
                'TM4_N2SB_ReceiveMsg = TM4_N2SB_ReceiveMsg & VB.Right("00" & Asc(RChar), 2) & " "
                UP35A_ReceiveMsg += Hex(RChar) & " "
                'Debug.Print("asdf = " & Asc(RChar))
                'Debug.Print("Rec Byte = " & Hex(RChar))

                UP35A_rpos = UP35A_rpos + 1

                Debug.Print("ReadByte = " & UP35A_ReceiveMsg)

                'If (UP35A_PV_Receive_ing = True Or UP35A_SV_Set_Receive_ing = True Or UP35A_Select_Set_Receive_ing = True) And (UP35A_rpos >= UP35A_ReceiveSize) Then
                If (UP35A_rpos >= UP35A_ReceiveSize) Then
                    CRC = CRC16table_packet(UP35A_Receive, UP35A_rpos - 2)
                    If ((CRC And 255) = UP35A_Receive(UP35A_rpos - 2)) And ((Fix(CRC / 256) And 255) = UP35A_Receive(UP35A_rpos - 1)) Then
                        'Debug.Print("Tm4-N2SB = " & TM4_N2SB_Receive(1))
                        'Debug.Print("Rec Msg : " & TM4_N2SB_ReceiveMsg)
                        If UP35A_Receive(1) = 3 Then 'Function Code 3
                            UP35A_ReTryCNT = 0

                            If UP35A_PV_Receive_ing = True Then
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive(3)) & Hex(UP35A_Receive(4)), 16)
                                UP35A_temp = TempValue
                                UP35A_PV_Receive_ing = False
                            End If
                            If UP35A_RunStop_Receive_ing = True Then
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive(3)) & Hex(UP35A_Receive(4)), 16)
                                UP35A_RunStop = TempValue
                                UP35A_RunStop_Receive_ing = False
                            End If
                            If UP35A_SetRead_Receive_ing = True Then
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive(3)) & Hex(UP35A_Receive(4)), 16)
                                UP35A_TSP = TempValue
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive(7)) & Hex(UP35A_Receive(8)), 16)
                                UP35A_TSP_Time = TempValue
                                UP35A_SetRead_Receive_ing = False
                            End If

                            'Chart1Data(Heater_PVIndex_CntChk, Temp_Reading_Count) = TM4_temp(Heater_PVIndex_CntChk - 1)
                            'lblPV(Heater_PVIndex_CntChk - 1).Text = "PV:" & TM4_temp(Heater_PVIndex_CntChk - 1)
                            UP35A_ReceiveOK = True
                            UP35A_Send_DelayChk = GetTickCount + 80  ' 600

                        ElseIf UP35A_Receive(1) = 16 Then 'Command 16
                            If UP35A_Select_Set_Receive_ing = True Then
                                Debug.Print("Rec Select Msg = " & UP35A_ReceiveMsg)
                                UP35A_Select_Set_Receive_ing = False
                            End If
                            If UP35A_SV_Set_Receive_ing = True Then
                                Debug.Print("Rec SV Set Msg = " & UP35A_ReceiveMsg)
                                UP35A_SV_Set_Receive_ing = False
                            End If
                            If UP35A_Start_Receive_ing = True Then
                                Debug.Print("Rec Start Msg = " & UP35A_ReceiveMsg)
                                UP35A_Start_Receive_ing = False
                            End If
                            If UP35A_Stop_Receive_ing = True Then
                                Debug.Print("Rec Stop Msg = " & UP35A_ReceiveMsg)
                                UP35A_Stop_Receive_ing = False
                            End If

                            UP35A_ReceiveOK = True
                            UP35A_Send_DelayChk = GetTickCount + 80  ' 600

                        Else
                            Debug.Print("수신 펑션 블럭값이 지령값과 틀림 = " & UP35A_ReceiveMsg)
                            Call WriteLogInText("수신 펑션 블럭값이 지령값과 틀림 = " & UP35A_ReceiveMsg)
                            UP35A_ReceiveOK = True
                            SIO_UP35A.DiscardInBuffer()
                        End If
                    Else
                        'MT_ReTryCNT += 1
                        UP35A_PV_Receive_ing = False
                        UP35A_Select_Set_Receive_ing = False
                        UP35A_SV_Set_Receive_ing = False
                        UP35A_Start_Receive_ing = False
                        UP35A_Stop_Receive_ing = False
                        UP35A_ReceiveOK = True
                        Debug.Print("수신 CRC 체크가 틀림.")
                        Call WriteLogInText("수신 CRC 체크가 틀림.(UP35A_1), " & UP35A_ReceiveMsg)
                    End If

                ElseIf UP35A_rpos = 5 Then
                    '** Err Receive
                    If Hex(UP35A_Receive(1)) >= 128 Then
                        'MT_ReTryCNT += 1
                        UP35A_PV_Receive_ing = False
                        UP35A_Select_Set_Receive_ing = False
                        UP35A_SV_Set_Receive_ing = False
                        UP35A_Start_Receive_ing = False
                        UP35A_Stop_Receive_ing = False
                        UP35A_ReceiveOK = True
                        Debug.Print("Comm Err Code = " & Hex(UP35A_Receive(2)) & ", " & UP35A_ReceiveMsg & " (UP35A_1)")
                        Call WriteLogInText("Comm Err Code = " & Hex(UP35A_Receive(2)) & ", " & UP35A_ReceiveMsg & " (UP35A_1)")
                    End If
                End If
            Catch ex As Exception ' TimeoutException
                ' Do nothing
                'TM4_N2SB_Rec = ""
                UP35A_Receive.Initialize()
                UP35A_PV_Receive_ing = False
                UP35A_Select_Set_Receive_ing = False
                UP35A_SV_Set_Receive_ing = False
                UP35A_Start_Receive_ing = False
                UP35A_Stop_Receive_ing = False
                UP35A_ReceiveOK = True
                Debug.Print("UP35A Comm Err : " & ex.Message & ", " & UP35A_ReceiveMsg)

            End Try
            BalanceThreadScheduling()       ' 쓰레드 안정화 타임
        End While
    End Sub

    Public Sub Read_UP35A1()
        Dim rBuf As Object
        Dim RChar As Byte
        Dim TempValue As String
        Dim CRC As Long
        Dim Pv_Deviation As Short

        Dim msg As String = ""
        Dim msgLength As Integer = 0


        While (_continue_1)

            Try
                rBuf = SIO_UP35A1.ReadByte
                RChar = rBuf   'Hex(rBuf)       'Asc(rBuf)
                'Debug.Print("Buff = " & RChar)

                UP35A_Receive1(UP35A_rpos1) = RChar
                'TM4_N2SB_ReceiveMsg = TM4_N2SB_ReceiveMsg & VB.Right("00" & Asc(RChar), 2) & " "
                UP35A_ReceiveMsg1 += Hex(RChar) & " "
                'Debug.Print("asdf = " & Asc(RChar))
                'Debug.Print("Rec Byte = " & Hex(RChar))

                UP35A_rpos1 = UP35A_rpos1 + 1

                Debug.Print("ReadByte1 = " & UP35A_ReceiveMsg1)

                'If (UP35A_PV_Receive_ing = True Or UP35A_SV_Set_Receive_ing = True Or UP35A_Select_Set_Receive_ing = True) And (UP35A_rpos >= UP35A_ReceiveSize) Then
                If (UP35A_rpos1 >= UP35A_ReceiveSize1) Then
                    CRC = CRC16table_packet(UP35A_Receive1, UP35A_rpos1 - 2)
                    If ((CRC And 255) = UP35A_Receive1(UP35A_rpos1 - 2)) And ((Fix(CRC / 256) And 255) = UP35A_Receive1(UP35A_rpos1 - 1)) Then
                        If UP35A_Receive1(1) = 3 Then 'Function Code 3
                            UP35A_ReTryCNT1 = 0

                            If UP35A_PV_Receive_ing1 = True Then
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive1(3)) & Hex(UP35A_Receive1(4)), 16)
                                UP35A_temp1 = TempValue
                                UP35A_PV_Receive_ing1 = False
                            End If
                            If UP35A_RunStop_Receive_ing1 = True Then
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive1(3)) & Hex(UP35A_Receive1(4)), 16)
                                UP35A_RunStop1 = TempValue
                                UP35A_RunStop_Receive_ing1 = False
                            End If
                            If UP35A_SetRead_Receive_ing1 = True Then
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive1(3)) & Hex(UP35A_Receive1(4)), 16)
                                UP35A_TSP1 = TempValue
                                TempValue = Convert.ToInt16(Hex(UP35A_Receive1(7)) & Hex(UP35A_Receive1(8)), 16)
                                UP35A_TSP_Time1 = TempValue
                                UP35A_SetRead_Receive_ing1 = False
                            End If

                            'Chart1Data(Heater_PVIndex_CntChk, Temp_Reading_Count) = TM4_temp(Heater_PVIndex_CntChk - 1)
                            'lblPV(Heater_PVIndex_CntChk - 1).Text = "PV:" & TM4_temp(Heater_PVIndex_CntChk - 1)
                            UP35A_ReceiveOK1 = True
                            UP35A_Send_DelayChk1 = GetTickCount + 80  ' 600

                        ElseIf UP35A_Receive1(1) = 16 Then 'Command 16
                            If UP35A_Select_Set_Receive_ing1 = True Then
                                Debug.Print("Rec Select Msg1 = " & UP35A_ReceiveMsg1)
                                UP35A_Select_Set_Receive_ing1 = False
                            End If
                            If UP35A_SV_Set_Receive_ing1 = True Then
                                Debug.Print("Rec SV Set Msg1 = " & UP35A_ReceiveMsg1)
                                UP35A_SV_Set_Receive_ing1 = False
                            End If
                            If UP35A_Start_Receive_ing1 = True Then
                                Debug.Print("Rec Start Msg1 = " & UP35A_ReceiveMsg1)
                                UP35A_Start_Receive_ing1 = False
                            End If
                            If UP35A_Stop_Receive_ing1 = True Then
                                Debug.Print("Rec Stop Msg1 = " & UP35A_ReceiveMsg1)
                                UP35A_Stop_Receive_ing1 = False
                            End If

                            UP35A_ReceiveOK1 = True
                            UP35A_Send_DelayChk1 = GetTickCount + 80  ' 600

                        Else
                            Debug.Print("수신 펑션 블럭값이 지령값과 틀림1 = " & UP35A_ReceiveMsg1)
                            Call WriteLogInText("수신 펑션 블럭값이 지령값과 틀림1 = " & UP35A_ReceiveMsg1)
                            UP35A_ReceiveOK1 = True
                            SIO_UP35A1.DiscardInBuffer()
                        End If
                    Else
                        'MT_ReTryCNT += 1
                        UP35A_PV_Receive_ing1 = False
                        UP35A_Select_Set_Receive_ing1 = False
                        UP35A_SV_Set_Receive_ing1 = False
                        UP35A_Start_Receive_ing1 = False
                        UP35A_Stop_Receive_ing1 = False
                        UP35A_ReceiveOK1 = True
                        Debug.Print("수신 CRC 체크가 틀림1.")
                        Call WriteLogInText("수신 CRC 체크가 틀림.(UP35A_1), " & UP35A_ReceiveMsg1)
                    End If

                ElseIf UP35A_rpos1 = 5 Then
                    '** Err Receive
                    If Hex(UP35A_Receive1(1)) >= 128 Then
                        'MT_ReTryCNT += 1
                        UP35A_PV_Receive_ing1 = False
                        UP35A_Select_Set_Receive_ing1 = False
                        UP35A_SV_Set_Receive_ing1 = False
                        UP35A_Start_Receive_ing1 = False
                        UP35A_Stop_Receive_ing1 = False
                        UP35A_ReceiveOK1 = True
                        Debug.Print("Comm Err Code = " & Hex(UP35A_Receive1(2)) & ", " & UP35A_ReceiveMsg1 & " (UP35A_1)")
                        Call WriteLogInText("Comm Err Code = " & Hex(UP35A_Receive1(2)) & ", " & UP35A_ReceiveMsg1 & " (UP35A_1)")
                    End If
                End If
            Catch ex As Exception ' TimeoutException
                ' Do nothing
                'TM4_N2SB_Rec = ""
                UP35A_Receive1.Initialize()
                UP35A_PV_Receive_ing1 = False
                UP35A_Select_Set_Receive_ing1 = False
                UP35A_SV_Set_Receive_ing1 = False
                UP35A_Start_Receive_ing1 = False
                UP35A_Stop_Receive_ing1 = False
                UP35A_ReceiveOK1 = True
                Debug.Print("UP35A1 Comm Err1 : " & ex.Message & ", " & UP35A_ReceiveMsg1)

            End Try
            BalanceThreadScheduling()       ' 쓰레드 안정화 타임
        End While
    End Sub

    Public Sub UP35A_Send(ByVal Cmd As Byte, Optional SV_Val As Integer = 0, Optional Minute_Val As Integer = 0, Optional RunStop As Integer = 0, Optional Order As Integer = 0)
        Dim Send(20) As Byte
        Dim CRC As Long
        Dim SendCNT As Integer
        Dim Slave As Byte = 1
        Dim Channel As Byte = 0
        Dim SV_Hex As String = ""
        Dim SV_Hi As String = ""
        Dim SV_Lo As String = ""
        Dim Time_Hex As String = ""
        Dim Time_Hi As String = ""
        Dim Time_Lo As String = ""


        UP35A_ReceiveOK = False
        UP35A_rpos = 0


        UP35A_ReceiveMsg = ""
        ReDim UP35A_Receive(100)     ' 수신패킷 버퍼

        If Cmd = 3 Then     'Reading of multiple D registers
            If RunStop = 2 Then 'PV Read
                '01 03 0002 00 01 25CA
                '국번(1), 펑션코드(1), StartADR(2), CNT(2), [CRC](2)
                UP35A_PV_Receive_ing = True
                UP35A_ReceiveSize = 7
                Send(0) = Slave             ' address
                Send(1) = Cmd               ' Function Code
                Send(2) = Val("&h" & "0")   '상위 Byte (Start address)
                Send(3) = Val("&h" & "2")   '하위 Byte (Start address)
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                CRC = CRC16table_packet(Send, 6)
                Send(6) = CRC And 255       ' crc16
                Send(7) = Fix(CRC / 256) And 255
                SendCNT = 8

            ElseIf RunStop = 3 Then 'Set Data Read (PrgNum=1, Seg=1, TSP & Time)
                '01 03 0002 00 01 25CA
                '국번(1), 펑션코드(1), StartADR(2), CNT(2), [CRC](2)
                UP35A_SetRead_Receive_ing = True
                UP35A_ReceiveSize = 11
                Send(0) = Slave             ' address
                Send(1) = Cmd               ' Function Code
                Send(2) = Val("&h" & "1F")  '상위 Byte (Start address)
                Send(3) = Val("&h" & "A6")  '하위 Byte (Start address)
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 3                 '하위 Byte (데이타 개수)
                CRC = CRC16table_packet(Send, 6)
                Send(6) = CRC And 255       ' crc16
                Send(7) = Fix(CRC / 256) And 255
                SendCNT = 8

            ElseIf RunStop = 4 Then 'Run/Stop Read
                '01 03 0002 00 01 25CA
                '국번(1), 펑션코드(1), StartADR(2), CNT(2), [CRC](2)
                UP35A_RunStop_Receive_ing = True
                UP35A_ReceiveSize = 7
                Send(0) = Slave             ' address
                Send(1) = Cmd               ' Function Code
                Send(2) = Val("&h" & "09")  '상위 Byte (Start address)
                Send(3) = Val("&h" & "0B")  '하위 Byte (Start address)
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                CRC = CRC16table_packet(Send, 6)
                Send(6) = CRC And 255       ' crc16
                Send(7) = Fix(CRC / 256) And 255
                SendCNT = 8
            End If


        ElseIf Cmd = 16 Then    'Writing of multiple D registers
            '01 10 1F40 0002 04 0002 0000 [CRC]
            '국번(1), 펑션코드(1), StartADR(2), CNT(2), ByteCNT(1), Data, [CRC](2)

            If RunStop = 0 Then 'Stop
                UP35A_Stop_Receive_ing = True
                UP35A_ReceiveSize = 8
                Send(0) = Slave             'slave address
                Send(1) = Cmd               'Query register command
                Send(2) = Val("&h" & "09")   '상위 Byte (Start address), CH1
                Send(3) = Val("&h" & "0B")  '하위 Byte (Start address), CH1
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                Send(6) = 2
                Send(7) = 0
                Send(8) = 0
                CRC = CRC16table_packet(Send, 9)
                Send(9) = CRC And 255       ' crc16
                Send(10) = Fix(CRC / 256) And 255
                SendCNT = 11

            ElseIf RunStop = 1 Then 'Run
                UP35A_Start_Receive_ing = True
                UP35A_ReceiveSize = 8
                Send(0) = Slave             'slave address
                Send(1) = Cmd               'Query register command
                Send(2) = Val("&h" & "09")   '상위 Byte (Start address), CH1
                Send(3) = Val("&h" & "0B")  '하위 Byte (Start address), CH1
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                Send(6) = 2
                Send(7) = 0
                Send(8) = 1
                CRC = CRC16table_packet(Send, 9)
                Send(9) = CRC And 255       ' crc16
                Send(10) = Fix(CRC / 256) And 255
                SendCNT = 11

            ElseIf RunStop = 2 Then 'Select
                If Order = 1 Then
                    UP35A_Select_Set_Receive_ing = True
                    UP35A_ReceiveSize = 8
                    '01 10 1FA4 0002 04 0001 0001 [CRC]     'D8101, PrgNum1, Seg1 (select)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A4")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    Send(6) = 4                 'Data Byte 
                    Send(7) = 0                 'Data
                    Send(8) = 1                 'Data
                    Send(9) = 0                 'Data
                    Send(10) = 1                'Data
                    CRC = CRC16table_packet(Send, 11)
                    Send(11) = CRC And 255       ' crc16
                    Send(12) = Fix(CRC / 256) And 255
                    SendCNT = 13

                ElseIf Order = 2 Then
                    UP35A_Select_Set_Receive_ing = True
                    UP35A_ReceiveSize = 8
                    '01 10 1FA4 0002 04 0001 0001 [CRC]     'D8101, PrgNum1, Seg2 (select)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A4")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    Send(6) = 4                 'Data Byte 
                    Send(7) = 0                 'Data
                    Send(8) = 1                 'Data
                    Send(9) = 0                 'Data
                    Send(10) = 2                'Data
                    CRC = CRC16table_packet(Send, 11)
                    Send(11) = CRC And 255       ' crc16
                    Send(12) = Fix(CRC / 256) And 255
                    SendCNT = 13
                End If


            ElseIf RunStop = 3 Then 'SET
                If Order = 1 Then
                    UP35A_SV_Set_Receive_ing = True
                    UP35A_ReceiveSize = 8
                    SV_Hex = Hex(SV_Val)
                    If Len(SV_Hex) = 1 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 1))
                    ElseIf Len(SV_Hex) = 2 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 2))
                    ElseIf Len(SV_Hex) = 3 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 1))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 2, 2))
                    ElseIf Len(SV_Hex) = 4 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 2))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 3, 2))
                    End If

                    Time_Hex = Hex(Minute_Val)
                    If Len(Time_Hex) = 1 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 1))
                    ElseIf Len(Time_Hex) = 2 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 2))
                    ElseIf Len(Time_Hex) = 3 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 1))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 2, 2))
                    ElseIf Len(Time_Hex) = 4 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 2))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 3, 2))
                    End If

                    ''국번(1), 펑션코드(1), StartADR(2), CNT(2), ByteCNT(1), Data, [CRC](2)
                    ''01 10 1FA6 0003 04 0001 0000 0001[CRC]     'D8103, PrgNum1, Seg1 (TSP set, Time set)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A6") 'Val("&h" & "A6")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 3                 '하위 Byte (데이타 개수)
                    Send(6) = 6                 'Data Byte 
                    Send(7) = SV_Hi             'Data
                    Send(8) = SV_Lo             'Data
                    Send(9) = 0                 'Data
                    Send(10) = 0                'Data
                    Send(11) = Time_Hi          'Data
                    Send(12) = Time_Lo          'Data
                    CRC = CRC16table_packet(Send, 13)
                    Send(13) = CRC And 255       ' crc16
                    Send(14) = Fix(CRC / 256) And 255
                    SendCNT = 15

                ElseIf Order = 2 Then
                    UP35A_SV_Set_Receive_ing = True
                    UP35A_ReceiveSize = 8
                    SV_Hex = Hex(SV_Val)
                    If Len(SV_Hex) = 1 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 1))
                    ElseIf Len(SV_Hex) = 2 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 2))
                    ElseIf Len(SV_Hex) = 3 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 1))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 2, 2))
                    ElseIf Len(SV_Hex) = 4 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 2))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 3, 2))
                    End If

                    Time_Hex = Hex(Minute_Val)
                    If Len(Time_Hex) = 1 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 1))
                    ElseIf Len(Time_Hex) = 2 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 2))
                    ElseIf Len(Time_Hex) = 3 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 1))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 2, 2))
                    ElseIf Len(Time_Hex) = 4 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 2))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 3, 2))
                    End If

                    ''국번(1), 펑션코드(1), StartADR(2), CNT(2), ByteCNT(1), Data, [CRC](2)
                    ''01 10 1FA6 0003 04 0001 0000 0001[CRC]     'D8103, PrgNum1, Seg1 (TSP set, Time set)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A6") 'Val("&h" & "A6")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 3                 '하위 Byte (데이타 개수)
                    Send(6) = 6                 'Data Byte 
                    Send(7) = SV_Hi             'Data
                    Send(8) = SV_Lo             'Data
                    Send(9) = 0                 'Data
                    Send(10) = 0                'Data
                    Send(11) = Time_Hi          'Data
                    Send(12) = Time_Lo          'Data
                    CRC = CRC16table_packet(Send, 13)
                    Send(13) = CRC And 255       ' crc16
                    Send(14) = Fix(CRC / 256) And 255
                    SendCNT = 15
                End If

            End If
        End If


        UP35A_SendMsg = Hex(Send(0)) & " " & Hex(Send(1)) & " " &
                    Hex(Send(2)) & " " & Hex(Send(3)) & " " &
                    Hex(Send(4)) & " " & Hex(Send(5)) & " " &
                    Hex(Send(6)) & " " & Hex(Send(7)) & " " &
                    Hex(Send(8)) & " " & Hex(Send(9)) & " " &
                    Hex(Send(10)) & " " & Hex(Send(11)) & " " &
                    Hex(Send(12)) & " " & Hex(Send(13)) & " " &
                    Hex(Send(14)) & " " & Hex(Send(15))
        '"1 10 9 0 1 1 1 44 C1"
        '0110090001010144C1
        Debug.Print("Send = " & UP35A_SendMsg)

        '** UP35A 
        If SIO_UP35A.IsOpen = True Then
            SIO_UP35A.Write(Send, 0, SendCNT)
            UP35A_TimeChk = GetTickCount + 100

        Else
            'StatusMsg = "Invalid COM port"
        End If
    End Sub

    Public Sub UP35A_Send1(ByVal Cmd As Byte, Optional SV_Val As Integer = 0, Optional Minute_Val As Integer = 0, Optional RunStop As Integer = 0, Optional Order As Integer = 0)
        Dim Send(20) As Byte
        Dim CRC As Long
        Dim SendCNT As Integer
        Dim Slave As Byte = 1
        Dim Channel As Byte = 0
        Dim SV_Hex As String = ""
        Dim SV_Hi As String = ""
        Dim SV_Lo As String = ""
        Dim Time_Hex As String = ""
        Dim Time_Hi As String = ""
        Dim Time_Lo As String = ""


        UP35A_ReceiveOK1 = False
        UP35A_rpos1 = 0


        UP35A_ReceiveMsg1 = ""
        ReDim UP35A_Receive1(100)     ' 수신패킷 버퍼

        If Cmd = 3 Then     'Reading of multiple D registers
            If RunStop = 2 Then 'PV Read
                '01 03 0002 00 01 25CA
                '국번(1), 펑션코드(1), StartADR(2), CNT(2), [CRC](2)
                UP35A_PV_Receive_ing1 = True
                UP35A_ReceiveSize1 = 7
                Send(0) = Slave             ' address
                Send(1) = Cmd               ' Function Code
                Send(2) = Val("&h" & "0")   '상위 Byte (Start address)
                Send(3) = Val("&h" & "2")   '하위 Byte (Start address)
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                CRC = CRC16table_packet(Send, 6)
                Send(6) = CRC And 255       ' crc16
                Send(7) = Fix(CRC / 256) And 255
                SendCNT = 8

            ElseIf RunStop = 3 Then 'Set Data Read (PrgNum=1, Seg=1, TSP & Time)
                '01 03 0002 00 01 25CA
                '국번(1), 펑션코드(1), StartADR(2), CNT(2), [CRC](2)
                UP35A_SetRead_Receive_ing1 = True
                UP35A_ReceiveSize1 = 11
                Send(0) = Slave             ' address
                Send(1) = Cmd               ' Function Code
                Send(2) = Val("&h" & "1F")  '상위 Byte (Start address)
                Send(3) = Val("&h" & "A6")  '하위 Byte (Start address)
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 3                 '하위 Byte (데이타 개수)
                CRC = CRC16table_packet(Send, 6)
                Send(6) = CRC And 255       ' crc16
                Send(7) = Fix(CRC / 256) And 255
                SendCNT = 8

            ElseIf RunStop = 4 Then 'Run/Stop Read
                '01 03 0002 00 01 25CA
                '국번(1), 펑션코드(1), StartADR(2), CNT(2), [CRC](2)
                UP35A_RunStop_Receive_ing1 = True
                UP35A_ReceiveSize1 = 7
                Send(0) = Slave             ' address
                Send(1) = Cmd               ' Function Code
                Send(2) = Val("&h" & "09")  '상위 Byte (Start address)
                Send(3) = Val("&h" & "0B")  '하위 Byte (Start address)
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                CRC = CRC16table_packet(Send, 6)
                Send(6) = CRC And 255       ' crc16
                Send(7) = Fix(CRC / 256) And 255
                SendCNT = 8
            End If


        ElseIf Cmd = 16 Then    'Writing of multiple D registers
            '01 10 1F40 0002 04 0002 0000 [CRC]
            '국번(1), 펑션코드(1), StartADR(2), CNT(2), ByteCNT(1), Data, [CRC](2)

            If RunStop = 0 Then 'Stop
                UP35A_Stop_Receive_ing1 = True
                UP35A_ReceiveSize1 = 8
                Send(0) = Slave             'slave address
                Send(1) = Cmd               'Query register command
                Send(2) = Val("&h" & "09")   '상위 Byte (Start address), CH1
                Send(3) = Val("&h" & "0B")  '하위 Byte (Start address), CH1
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                Send(6) = 2
                Send(7) = 0
                Send(8) = 0
                CRC = CRC16table_packet(Send, 9)
                Send(9) = CRC And 255       ' crc16
                Send(10) = Fix(CRC / 256) And 255
                SendCNT = 11

            ElseIf RunStop = 1 Then 'Run
                UP35A_Start_Receive_ing1 = True
                UP35A_ReceiveSize1 = 8
                Send(0) = Slave             'slave address
                Send(1) = Cmd               'Query register command
                Send(2) = Val("&h" & "09")   '상위 Byte (Start address), CH1
                Send(3) = Val("&h" & "0B")  '하위 Byte (Start address), CH1
                Send(4) = 0                 '상위 Byte (데이타 개수)
                Send(5) = 1                 '하위 Byte (데이타 개수)
                Send(6) = 2
                Send(7) = 0
                Send(8) = 1
                CRC = CRC16table_packet(Send, 9)
                Send(9) = CRC And 255       ' crc16
                Send(10) = Fix(CRC / 256) And 255
                SendCNT = 11

            ElseIf RunStop = 2 Then 'Select
                If Order = 1 Then
                    UP35A_Select_Set_Receive_ing1 = True
                    UP35A_ReceiveSize1 = 8
                    '01 10 1FA4 0002 04 0001 0001 [CRC]     'D8101, PrgNum1, Seg1 (select)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A4")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    Send(6) = 4                 'Data Byte 
                    Send(7) = 0                 'Data
                    Send(8) = 1                 'Data
                    Send(9) = 0                 'Data
                    Send(10) = 1                'Data
                    CRC = CRC16table_packet(Send, 11)
                    Send(11) = CRC And 255       ' crc16
                    Send(12) = Fix(CRC / 256) And 255
                    SendCNT = 13

                ElseIf Order = 2 Then
                    UP35A_Select_Set_Receive_ing1 = True
                    UP35A_ReceiveSize1 = 8
                    '01 10 1FA4 0002 04 0001 0001 [CRC]     'D8101, PrgNum1, Seg2 (select)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A4")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    Send(6) = 4                 'Data Byte 
                    Send(7) = 0                 'Data
                    Send(8) = 1                 'Data
                    Send(9) = 0                 'Data
                    Send(10) = 2                'Data
                    CRC = CRC16table_packet(Send, 11)
                    Send(11) = CRC And 255       ' crc16
                    Send(12) = Fix(CRC / 256) And 255
                    SendCNT = 13
                End If


            ElseIf RunStop = 3 Then 'SET
                If Order = 1 Then
                    UP35A_SV_Set_Receive_ing1 = True
                    UP35A_ReceiveSize1 = 8
                    SV_Hex = Hex(SV_Val)
                    If Len(SV_Hex) = 1 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 1))
                    ElseIf Len(SV_Hex) = 2 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 2))
                    ElseIf Len(SV_Hex) = 3 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 1))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 2, 2))
                    ElseIf Len(SV_Hex) = 4 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 2))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 3, 2))
                    End If

                    Time_Hex = Hex(Minute_Val)
                    If Len(Time_Hex) = 1 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 1))
                    ElseIf Len(Time_Hex) = 2 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 2))
                    ElseIf Len(Time_Hex) = 3 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 1))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 2, 2))
                    ElseIf Len(Time_Hex) = 4 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 2))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 3, 2))
                    End If

                    ''국번(1), 펑션코드(1), StartADR(2), CNT(2), ByteCNT(1), Data, [CRC](2)
                    ''01 10 1FA6 0003 04 0001 0000 0001[CRC]     'D8103, PrgNum1, Seg1 (TSP set, Time set)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A6") 'Val("&h" & "A6")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 3                 '하위 Byte (데이타 개수)
                    Send(6) = 6                 'Data Byte 
                    Send(7) = SV_Hi             'Data
                    Send(8) = SV_Lo             'Data
                    Send(9) = 0                 'Data
                    Send(10) = 0                'Data
                    Send(11) = Time_Hi          'Data
                    Send(12) = Time_Lo          'Data
                    CRC = CRC16table_packet(Send, 13)
                    Send(13) = CRC And 255       ' crc16
                    Send(14) = Fix(CRC / 256) And 255
                    SendCNT = 15

                ElseIf Order = 2 Then
                    UP35A_SV_Set_Receive_ing1 = True
                    UP35A_ReceiveSize1 = 8
                    SV_Hex = Hex(SV_Val)
                    If Len(SV_Hex) = 1 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 1))
                    ElseIf Len(SV_Hex) = 2 Then
                        SV_Hi = 0
                        SV_Lo = Val("&H" & Mid(SV_Hex, 1, 2))
                    ElseIf Len(SV_Hex) = 3 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 1))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 2, 2))
                    ElseIf Len(SV_Hex) = 4 Then
                        SV_Hi = Val("&H" & Mid(SV_Hex, 1, 2))
                        SV_Lo = Val("&H" & Mid(SV_Hex, 3, 2))
                    End If

                    Time_Hex = Hex(Minute_Val)
                    If Len(Time_Hex) = 1 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 1))
                    ElseIf Len(Time_Hex) = 2 Then
                        Time_Hi = 0
                        Time_Lo = Val("&H" & Mid(Time_Hex, 1, 2))
                    ElseIf Len(Time_Hex) = 3 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 1))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 2, 2))
                    ElseIf Len(Time_Hex) = 4 Then
                        Time_Hi = Val("&H" & Mid(Time_Hex, 1, 2))
                        Time_Lo = Val("&H" & Mid(Time_Hex, 3, 2))
                    End If

                    ''국번(1), 펑션코드(1), StartADR(2), CNT(2), ByteCNT(1), Data, [CRC](2)
                    ''01 10 1FA6 0003 04 0001 0000 0001[CRC]     'D8103, PrgNum1, Seg1 (TSP set, Time set)
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "1F")  '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "A6") 'Val("&h" & "A6")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 3                 '하위 Byte (데이타 개수)
                    Send(6) = 6                 'Data Byte 
                    Send(7) = SV_Hi             'Data
                    Send(8) = SV_Lo             'Data
                    Send(9) = 0                 'Data
                    Send(10) = 0                'Data
                    Send(11) = Time_Hi          'Data
                    Send(12) = Time_Lo          'Data
                    CRC = CRC16table_packet(Send, 13)
                    Send(13) = CRC And 255       ' crc16
                    Send(14) = Fix(CRC / 256) And 255
                    SendCNT = 15
                End If

            End If
        End If


        UP35A_SendMsg1 = Hex(Send(0)) & " " & Hex(Send(1)) & " " &
                    Hex(Send(2)) & " " & Hex(Send(3)) & " " &
                    Hex(Send(4)) & " " & Hex(Send(5)) & " " &
                    Hex(Send(6)) & " " & Hex(Send(7)) & " " &
                    Hex(Send(8)) & " " & Hex(Send(9)) & " " &
                    Hex(Send(10)) & " " & Hex(Send(11)) & " " &
                    Hex(Send(12)) & " " & Hex(Send(13)) & " " &
                    Hex(Send(14)) & " " & Hex(Send(15))
        '"1 10 9 0 1 1 1 44 C1"
        '0110090001010144C1
        Debug.Print("Send = " & UP35A_SendMsg1)

        '** UP35A 
        If SIO_UP35A1.IsOpen = True Then
            SIO_UP35A1.Write(Send, 0, SendCNT)
            UP35A_TimeChk1 = GetTickCount + 100

        Else
            'StatusMsg = "Invalid COM port"
        End If
    End Sub
    Public Sub UP35A_Send_Old(ByVal Cmd As Byte, ByVal H_inedex As Integer, Optional SV_Val As Integer = 0, Optional RunStop As Integer = 0)
        Dim Send(0 To 7) As Byte
        Dim CRC As Long
        Dim Slave As Byte = 0
        Dim Channel As Byte = 0
        Dim SV_Hex As String = ""
        Dim SV_Hi As String = ""
        Dim SV_Lo As String = ""


        UP35A_ReceiveOK = False
        UP35A_ReceiveOK1 = False
        UP35A_rpos = 0
        UP35A_rpos1 = 0
        'LampAmpare = 0




        If H_inedex = -1 Then H_inedex = 0
        If TM4_1GroupCnt_ <= H_inedex Then
            '** TM4 2Group
            Slave = (H_inedex - TM4_1GroupCnt_) \ 4
            Slave += 1
            Channel = (H_inedex - TM4_1GroupCnt_) Mod 4
            UP35A_ReceiveMsg1 = ""
            ReDim UP35A_Receive1(100)     ' 수신패킷 버퍼
        Else
            '** TM4 1Group
            Slave = H_inedex \ 4
            Slave += 1
            Channel = H_inedex Mod 4
            UP35A_ReceiveMsg = ""
            ReDim UP35A_Receive(100)     ' 수신패킷 버퍼
        End If
        'If H_inedex = 22 Then Debug.Print("Slave = " & Slave & ", " & "Ch = " & Channel)

        If Cmd = 6 Then     'Preset single Register
            UP35A_ReceiveSize = 8
            UP35A_ReceiveSize1 = 8

            If SV_Val <> 0 Then     '** SV Set
                UP35A_SV_Set_Receive_ing = True

                SV_Hex = Hex(SV_Val)
                If Len(SV_Hex) = 1 Then
                    SV_Hi = 0
                    SV_Lo = Val("&H" & Mid(SV_Hex, 1, 1))
                ElseIf Len(SV_Hex) = 2 Then
                    SV_Hi = 0
                    SV_Lo = Val("&H" & Mid(SV_Hex, 1, 2))
                ElseIf Len(SV_Hex) = 3 Then
                    SV_Hi = Val("&H" & Mid(SV_Hex, 1, 1))
                    SV_Lo = Val("&H" & Mid(SV_Hex, 2, 2))
                ElseIf Len(SV_Hex) = 4 Then
                    SV_Hi = Val("&H" & Mid(SV_Hex, 1, 2))
                    SV_Lo = Val("&H" & Mid(SV_Hex, 3, 2))
                End If


                Select Case Channel
                    Case 0
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "0")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "0")   '하위 Byte (Start address), CH1
                        Send(4) = SV_Hi             '상위 Byte (데이타 개수)
                        Send(5) = SV_Lo             '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255

                    Case 1
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "3")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "E8")  '하위 Byte (Start address), CH1
                        Send(4) = SV_Hi             '상위 Byte (데이타 개수)
                        Send(5) = SV_Lo             '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255

                    Case 2
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "7")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "D0")  '하위 Byte (Start address), CH1
                        Send(4) = SV_Hi             '상위 Byte (데이타 개수)
                        Send(5) = SV_Lo             '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255

                    Case 3
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "0B")  '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "B8")  '하위 Byte (Start address), CH1
                        Send(4) = SV_Hi             '상위 Byte (데이타 개수)
                        Send(5) = SV_Lo             '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255
                End Select

            ElseIf SV_Val = 0 And (RunStop = 0 Or RunStop = 1) Then     '** Temp Controll RUN (0=Run, 1=Stop)
                UP35A_Ctrl_Set_Receive_ing = True
                Select Case Channel
                    Case 0
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "0")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "32")  '하위 Byte (Start address), CH1
                        Send(4) = 0                 '상위 Byte (데이타 개수)
                        Send(5) = RunStop           '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255

                    Case 1
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "4")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "1A")  '하위 Byte (Start address), CH1
                        Send(4) = 0                 '상위 Byte (데이타 개수)
                        Send(5) = RunStop           '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255

                    Case 2
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "8")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "2")   '하위 Byte (Start address), CH1
                        Send(4) = 0                 '상위 Byte (데이타 개수)
                        Send(5) = RunStop           '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255

                    Case 3
                        Send(0) = Slave             'slave address
                        Send(1) = Cmd               'Query register command
                        Send(2) = Val("&h" & "B")   '상위 Byte (Start address), CH1
                        Send(3) = Val("&h" & "EA")  '하위 Byte (Start address), CH1
                        Send(4) = 0                 '상위 Byte (데이타 개수)
                        Send(5) = RunStop           '하위 Byte (데이타 개수)
                        CRC = CRC16table_packet(Send, 6)
                        Send(6) = CRC And 255       ' crc16
                        Send(7) = Fix(CRC / 256) And 255
                End Select
            End If


        ElseIf Cmd = 4 Then     'Read input Register
            UP35A_ReceiveSize = 9
            UP35A_ReceiveSize1 = 9
            UP35A_PV_Receive_ing = True

            Select Case Channel
                Case 0
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "3")   '상위 Byte (Start address), CH1 (31000=Open, 30000=상한Err, -30000 하한Err)
                    Send(3) = Val("&h" & "E8")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    CRC = CRC16table_packet(Send, 6)
                    Send(6) = CRC And 255       ' crc16
                    Send(7) = Fix(CRC / 256) And 255

                Case 1
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "3")   '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "EE")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    CRC = CRC16table_packet(Send, 6)
                    Send(6) = CRC And 255       ' crc16
                    Send(7) = Fix(CRC / 256) And 255

                Case 2
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "3")   '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "F4")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    CRC = CRC16table_packet(Send, 6)
                    Send(6) = CRC And 255       ' crc16
                    Send(7) = Fix(CRC / 256) And 255

                Case 3
                    Send(0) = Slave             'slave address
                    Send(1) = Cmd               'Query register command
                    Send(2) = Val("&h" & "3")   '상위 Byte (Start address), CH1
                    Send(3) = Val("&h" & "FA")  '하위 Byte (Start address), CH1
                    Send(4) = 0                 '상위 Byte (데이타 개수)
                    Send(5) = 2                 '하위 Byte (데이타 개수)
                    CRC = CRC16table_packet(Send, 6)
                    Send(6) = CRC And 255       ' crc16
                    Send(7) = Fix(CRC / 256) And 255
            End Select

            'TM4_N2SB_SendMsg = TM4_N2SB_ReceiveMsg & VB.Right("00" & Asc(RChar), 2) & " "

            'TM4_N2SB_SendMsg = Hex(Send(0)) & " " & Hex(Send(1)) & " " &
            '                    Hex(Send(2)) & " " & Hex(Send(3)) & " " &
            '                    Hex(Send(4)) & " " & Hex(Send(5)) & " " &
            '                    Hex(Send(6)) & " " & Hex(Send(7)) & " "
            ''Debug.Print(H_inedex & "_Tm4SendMsg = " & TM4_N2SB_SendMsg)
            'Debug.Print(H_inedex & "_Tm4SendMsg = " & TM4_N2SB_SendMsg & "_" & Channel & "_" & Asc(Send(3)))

        End If


        'UP35A_SendMsg = Hex(Send(0)) & " " & Hex(Send(1)) & " " &
        '                        Hex(Send(2)) & " " & Hex(Send(3)) & " " &
        '                        Hex(Send(4)) & " " & Hex(Send(5)) & " " &
        '                        Hex(Send(6)) & " " & Hex(Send(7)) & " "
        'Debug.Print(H_inedex & "_Tm4SendMsg = " & TM4_N2SB_SendMsg)

        If TM4_1GroupCnt_ > H_inedex Then
            '** TM4 1Group
            If SIO_UP35A.IsOpen = True Then
                SIO_UP35A.Write(Send, 0, 8)
                'If Cmd = 6 Then Temp_SV_Set_Req = False
                UP35A_TimeChk = GetTickCount + 500

            Else
                'StatusMsg = "Invalid COM port"
            End If

        Else
            '** TM4 2Group
            If SIO_UP35A1.IsOpen = True Then
                SIO_UP35A1.Write(Send, 0, 8)
                'If Cmd = 6 Then Temp_SV_Set_Req = False
                UP35A_TimeChk = GetTickCount + 500

            Else
                'StatusMsg = "Invalid COM port"
            End If
        End If



    End Sub

    Private Sub BalanceThreadScheduling()
        System.Threading.Thread.Sleep(0)
    End Sub

    Private Sub btnHeaterON_Click(sender As Object, e As EventArgs) Handles btnHeaterON.Click
        If Alarm_Bit(1) = True Then Exit Sub    '** EMO
        If SIO_UP35A.IsOpen = False Then MsgDisplay("히터 콘트롤 통신포트(" & tIni.tEQValIni.UP35A_Com_Port & ")가 닫혀있습니다...", Color.Yellow)
        If SIO_UP35A1.IsOpen = False Then MsgDisplay("히터 콘트롤 통신포트(" & tIni.tEQValIni.UP35A1_Com_Port & ")가 닫혀있습니다...", Color.Yellow)

        '** MC ON
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13C", 1, 1) 'bit    
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13D", 1, 1) 'bit
        '** SCR ON
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13E", 1, 1) 'bit
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13F", 1, 1) 'bit

    End Sub

    Private Sub btnHeaterOFF_Click(sender As Object, e As EventArgs) Handles btnHeaterOFF.Click
        '** MC Off
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13C", 1, 0) 'bit
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13D", 1, 0) 'bit
        '** SCR Off
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13E", 1, 0) 'bit
        iReturnCode = AxActUtlType1.WriteDeviceRandom("Y13F", 1, 0) 'bit
        UP35A_Temp_Control_Start_Flag = False
    End Sub

    Private Sub tmrTemp_Tick(sender As Object, e As EventArgs) Handles tmrTemp.Tick
        Dim row1 As DataRow
        Dim row2 As DataRow
        row1 = tblUnit1.NewRow()
        row2 = tblUnit2.NewRow()

        If UP35A_ReceiveOK = True Then Exit Sub
        If UP35A_ReceiveOK1 = True Then Exit Sub

        Select Case TempSeq
            Case 0  'PV Read
                If GetTickCount < UP35A_PV_interval Then
                Else
                    Call UP35A_Send(3,,, 2)
                    Call UP35A_Send1(3,,, 2)
                    UP35A_PV_Save_Flag = True
                    UP35A_PV_interval = GetTickCount + 1000 '500
                End If
                TempSeq += 1

            Case 1  'PV Save & Set Data Read
                If UP35A_PV_Save_Flag = True Then
                    lblTemp1.Text = UP35A_temp
                    lblTemp2.Text = UP35A_temp1
                    'DataSet
                    row1(0) = UP35A_temp
                    row2(0) = UP35A_temp1
                    tblUnit1.Rows.Add(row1)
                    tblUnit2.Rows.Add(row2)
                    Chart1.DataBind()
                    Chart2.DataBind()

                    If tblUnit1.Rows.Count >= 10 Then
                        tblUnit1.Rows.RemoveAt(0)
                        'DataGridView1.FirstDisplayedScrollingRowIndex = 0
                        'DataGridView1.Rows.Item(0).Selected = True
                    End If
                    If tblUnit2.Rows.Count >= 10 Then
                        tblUnit2.Rows.RemoveAt(0)
                        'DataGridView1.FirstDisplayedScrollingRowIndex = 0
                        'DataGridView1.Rows.Item(0).Selected = True
                    End If

                    Dim currDateTime As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                    Call ResultFileSave(True, currDateTime & ", " & UP35A_temp & ", " & UP35A_temp1)
                    UP35A_PV_Save_Flag = False
                End If

                Call UP35A_Send(3,,, 3)
                Call UP35A_Send1(3,,, 3)
                TempSeq += 1

            Case 2  'Run / Stop Read
                If UP35A_StartFlag = True Then
                    TempSeq = 10
                ElseIf UP35A_StopFlag = True Then
                    TempSeq = 11
                ElseIf UP35A_SetDataTransFlag = True Then
                    TempSeq = 12
                Else
                    Call UP35A_Send(3,,, 4)
                    Call UP35A_Send1(3,,, 4)
                    TempSeq = 0
                End If

            Case 10  'Run Write
                Call UP35A_Send(16,,, 1, )
                Call UP35A_Send1(16,,, 1, )
                UP35A_StartFlag = False
                UP35A_DualRunChkFlag = True
                UP35A_DualRunChkTime = GetTickCount + 1000
                TempSeq = 0

            Case 11  'Stop Write
                Call UP35A_Send(16,,, 0, )
                Call UP35A_Send1(16,,, 0, )
                UP35A_StopFlag = False
                TempSeq = 0

            Case 12  'Set Data Write (Select Prg=1, Seg=1)
                Call UP35A_Send(16,,, 2, 1)
                Call UP35A_Send1(16,,, 2, 1)
                numTempSV1.Enabled = False
                numTempSV2.Enabled = False
                numTagetTime1.Enabled = False
                numTagetTime2.Enabled = False
                TempSeq += 1

            Case 13  'Set Data Write (Write)
                Call UP35A_Send(16, numTempSV1.Value, numTagetTime1.Value, 3, 1)
                Call UP35A_Send1(16, numTempSV1.Value, numTagetTime1.Value, 3, 1)
                TempSeq += 1

            Case 14  'Set Data Write (Select Prg=1, Seg=2)
                Call UP35A_Send(16,,, 2, 2)
                Call UP35A_Send1(16,,, 2, 2)
                TempSeq += 1

            Case 15  'Set Data Write (Write) 
                Call UP35A_Send(16, numTempSV1.Value, 900, 3, 2)
                Call UP35A_Send1(16, numTempSV1.Value, 900, 3, 2)
                TempSeq += 1

            Case 16  'Set Data Write (Select Prg=1, Seg=1)
                Call UP35A_Send(16,,, 2, 1)
                Call UP35A_Send1(16,,, 2, 1)
                numTempSV1.Enabled = True
                numTempSV2.Enabled = True
                numTagetTime1.Enabled = True
                numTagetTime2.Enabled = True
                Temp_Set_Focus = False
                TempSeq = 0
        End Select

        If Temp_Set_Focus = False Then
            numTempSV1.Value = UP35A_TSP
            numTempSV2.Value = UP35A_TSP1
            numTagetTime1.Value = UP35A_TSP_Time
            numTagetTime2.Value = UP35A_TSP_Time1
        End If

        '** Heater Dual Run Err chk
        If UP35A_DualRunChkFlag = True Then
            If GetTickCount > UP35A_DualRunChkTime Then
                If UP35A_RunStop = 1 And UP35A_RunStop1 = 1 Then
                    UP35A_DualRunChkFlag = False
                Else
                    If UP35A_RunStop <> 1 Then
                        MsgDisplay("히터 1번 런이 안됩니다...", Color.Red)
                        lst_Alarm.Items.Add("히터 1번 런이 안됩니다...")
                    End If
                    If UP35A_RunStop1 <> 1 Then
                        MsgDisplay("히터 2번 런이 안됩니다...", Color.Red)
                        lst_Alarm.Items.Add("히터 2번 런이 안됩니다...")
                    End If

                    lst_Alarm.SelectedIndex = lst_Alarm.Items.Count - 1
                    If lst_Alarm.Items.Count > 100 Then lst_Alarm.Items.RemoveAt(0)

                    Call btnHeaterOFF_Click(Nothing, Nothing)
                    iReturnCode = AxActUtlType1.WriteDeviceRandom("Y123", 1, 1) 'bit Buzzer ON 
                    UP35A_DualRunChkFlag = False
                End If

            Else
                If UP35A_RunStop = 1 And UP35A_RunStop1 = 1 Then
                    UP35A_Temp_Control_Start_Flag = True
                    UP35A_DualRunChkFlag = False
                    'Start temp remember
                End If
            End If

        End If

        'numTempDeviation  Err
        'workdata.

    End Sub


End Class
