Option Explicit On
'Imports ceSDK = Manual_OVC_Tester_1d.Shared_cEIP_Motion.ceSDK_Net
Imports VB = Microsoft.VisualBasic
Imports System.IO

Module modCommon

    'Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpSectionName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal Size As Short, ByVal lpFileName As String) As Short
    'Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    Declare Function SetSystemTime Lib "kernel32" Alias "SetSystemTime" (ByRef lpSystemTime As SYSTEMTIME) As Integer

    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" _
    (ByVal lpSectionName As String,
     ByVal lpKeyName As String,
     ByVal lpDefault As String,
     ByVal lpReturnedString As System.Text.StringBuilder,
     ByVal Size As Short,
     ByVal lpFileName As String) As Integer

    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" _
    (ByVal lpApplicationName As String,
     ByVal lpKeyName As String,
     ByVal lpString As String,
     ByVal lpFileName As String) As Integer


    Public Declare Function GetTickCount Lib "kernel32" () As Integer

    Public Model As String
    Public Result_Title As String
    Public MsgClearTime As Integer
    Public MsgClearReq As Boolean
    Public Err_Msg As String
    Public Old_Msg As String

    Public Pos_inLet_ID_Old(5, 0) As String
    Public Pos_Buffer_ID_Old(5, 0) As String
    Public Pos_inStacker_ID_Old(5, 0) As String
    Public Pos_outStacker_ID_Old(5, 0) As String
    Public Pos_Work_ID_Old(5, 0) As String
    Public Pos_ByPass_ID_Old(5, 0) As String
    Public Pos_OutLet_EndCode_Old(5, 0) As String

    Public Structure SYSTEMTIME
        Public wYear As UInt16
        Public wMonth As UInt16
        Public wDayOfWeek As UInt16
        Public wDay As UInt16
        Public wHour As UInt16
        Public wMinute As UInt16
        Public wSecond As UInt16
        Public wMilliseconds As UInt16
    End Structure


    '    Public Function DoubleDataRead(ByVal Read_Pos As Integer) As Long
    Public Function DoubleDataRead(ByVal Data1 As Short, ByVal Data2 As Short) As Double
        Dim Double_Buf As Integer

        Try
            'DoubleDataRead = Val("&H" & VB.Right("00" & Hex(Data1), 2) & VB.Right("00" & Hex(Data2), 2))

            'DoubleDataRead = Val("&H" & VB.Right("0000" & Hex(Data1), 4) & VB.Right("0000" & Hex(Data2), 4))

            ' DoubleDataRead = Val("&H" & VB.Right("0000" & Hex(Data2), 4) & VB.Right("0000" & Hex(Data1), 4))

            'Debug.Print(Hex(Data1)) '2174
            'Debug.Print("&H" & VB.Right("00" & Hex(Data1), 2))  ':&H74
            'Debug.Print("&H" & VB.Right("0000" & Hex(Data1), 4))  ':&H2174
            'Debug.Print("&H" & VB.Right("0000" & Hex(Data2), 4))  ':&H00A
            'Debug.Print(Val("&H" & "A" & "2174"))  ':&H2174

            ''------------ Loading/Good/Failure Count
            'Double_Buf = PlcData(Read_Pos + 1)
            'DoubleDataRead = Int(PlcData(Read_Pos) And &H7FFF + 32768) + CLng(Double_Buf << 16)
            'DoubleDataRead = Int((Data1) And &H7FFF + 32768) + CLng(Data2 << 16)

            DoubleDataRead = Convert.ToInt32(Strings.Right("0000" & Hex(Data2), 4) & Strings.Right("0000" & Hex(Data1), 4), 16)
        Catch ex As Exception
            Debug.Print("DoubleDataRead Err = " & ex.Message)
        End Try

    End Function

    Public Sub DoubleDataWrite(ByVal AddrIni As String, ByVal Addr As Integer, ByVal Data As String)
        Dim buf As String
        Dim dec1 As String
        Dim dec2 As String
        Dim iReturnCode As Integer

        buf = Hex(Data)
        If Len(buf) > 4 Then
            dec1 = Convert.ToInt16(Mid(buf, 5, 4), 16)
            dec2 = Convert.ToInt16(Mid(buf, 1, 4 - (8 - Len(buf))), 16)
            iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr, 1, dec1)
            iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr + 1, 1, dec2)
        Else
            dec1 = Convert.ToInt16(Mid(buf, 1, 4 - (4 - Len(buf))), 16)
            iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr, 1, dec1)
            iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr + 1, 1, 0)
        End If
    End Sub

    Public Sub DoubleData_ReturnEach(ByVal Data As String, ByRef dec1 As String, ByRef dec2 As String)
        Dim buf As String
        Dim iReturnCode As Integer

        buf = Hex(Data)
        If Len(buf) > 4 Then
            dec1 = Convert.ToInt16(Mid(buf, 5, 4), 16)
            dec2 = Convert.ToInt16(Mid(buf, 1, 4 - (8 - Len(buf))), 16)
            'iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr, 1, dec1)
            'iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr + 1, 1, dec2)
        Else
            dec1 = Convert.ToInt16(Mid(buf, 1, 4 - (4 - Len(buf))), 16)
            dec2 = 0
            'iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr, 1, dec1)
            'iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock(AddrIni & Addr + 1, 1, dec2)
        End If
    End Sub
    Public Sub SetTime(ByVal dTime As Date)
        ' Call the native GetSystemTime method
        ' with the defined structure.
        Dim st As New SYSTEMTIME

        Try
            dTime = dTime.AddHours(-9)      '시간을 맞추기위해 -9를 한다 (GMT+09:00)

            st.wYear = dTime.ToString("yyyy")
            st.wMonth = dTime.ToString("MM")
            st.wDay = dTime.ToString("dd")
            st.wHour = dTime.ToString("HH")
            st.wMinute = dTime.ToString("mm")
            st.wSecond = dTime.ToString("ss")

            Call SetSystemTime(st)

        Catch ex As Exception
            Debug.Print("Time Set Err : " & ex.Message)
        End Try

    End Sub


    Public Sub ResultFileCopy(ByRef Source As String, ByRef D_FileName As String)
        'Dim OpenCHK As Boolean
        'Dim TogoPath As String

        'TogoPath = tIni.tEQVaiIni.VisionDataSavePath

        ''** Data 하위 폴더에 연월일 폴더 확인 후 생성
        'OpenCHK = ReportFolderStatus(TogoPath & Now.Year & "\" & Format(Now.Month, "00") & "\" & Format(Now.Day, "00"))
        'If OpenCHK = True Then
        '    Call MkDir(TogoPath & Now.Year & "\" & Format(Now.Month, "00") & "\" & Format(Now.Day, "00"))
        'End If

        'TogoPath = TogoPath & Now.Year & "\" & Format(Now.Month, "00") & "\" & Format(Now.Day, "00") & "\" & D_FileName
        'CopyedFilePath = TogoPath

        ''** ToDo Copy
        'IO.File.Copy(Source, TogoPath)

    End Sub

    Public Sub ResultFileSave(ByRef Result As Boolean, ByRef Msg As String)
        Dim OpenCHK As Boolean
        Dim sDate As String
        Dim DataPath As String


        DataPath = "C:\Data"    'tIni.tEQVaiIni.Save_Path   '"c:\OCV"
        '** Drive Chk
        OpenCHK = ReportDriveStatus(Mid(DataPath, 1, 3))
        If OpenCHK = True Then
            DataPath = "C:\" & Mid(DataPath, 4, Len(DataPath) - 3)
        End If

        sDate = Now.Year & "\" & Format(Now.Month, "00") & "\" & Format(Now.Day, "00")


        '** Data 하위 폴더에 연월일 폴더 확인 후 생성
        OpenCHK = ReportFolderStatus(DataPath & "\" & "TempData\" & sDate)
        If OpenCHK = True Then
            Call MkDir(DataPath & "\" & "TempData\" & sDate)
        End If

        'DataPath = DataPath & "\" & "Data\" & sDate & "\" & "Measure_data_" & sDate & ".Csv"
        DataPath = DataPath & "\" & "TempData\" & sDate & "\" & Model & ".csv"

        If (ReportFileStatus(DataPath)) Then
            FileOpen(1, DataPath, OpenMode.Append)
            PrintLine(1, Result_Title)
            FileClose(1)
        End If

        'Debug.Print(DataPath)

        FileOpen(1, DataPath, OpenMode.Append)
        PrintLine(1, Msg)
        FileClose(1)

    End Sub

    Public Function GetSystemSettings() As Object
        '' gets some data from the Windows NT registry
        '' regedt32.exe -> HKEY_CURRENT_USER on Local Machine \ Software \ VB and VBA Program Settings :

        'gLastModelindex = CShort(GetSetting("Manual_OVC_Tester", "Settings\Security", "LastModelindex", CStr(0)))
        'gCurrentPassword = GetSetting("Manual_OVC_Tester", "Settings\Security", "CurrentPassword", "administrator")
        'gOperatorPassword = GetSetting("Manual_OVC_Tester", "Settings\Security", "OperatorPassword", "operator")
        'gEngineerPassword = GetSetting("Manual_OVC_Tester", "Settings\Security", "EngineerPassword", "engineer")
        'gAdministratorPassword = GetSetting("Manual_OVC_Tester", "Settings\Security", "AdministratorPassword", "administrator")
    End Function


    Public Function SaveSystemSettings() As Object
        'SaveSetting("Manual_OVC_Tester", "Settings\Security", "LastModelindex", CStr(gLastModelindex))
        'SaveSetting("Manual_OVC_Tester", "Settings\Security", "CurrentPassword", gCurrentPassword)
        'SaveSetting("Manual_OVC_Tester", "Settings\Security", "OperatorPassword", gOperatorPassword)
        'SaveSetting("Manual_OVC_Tester", "Settings\Security", "EngineerPassword", gEngineerPassword)
        'SaveSetting("Manual_OVC_Tester", "Settings\Security", "AdministratorPassword", gAdministratorPassword)
    End Function

    Public Function SavePrgLive() As Object
        SaveSetting("VacuumFormLive", "Settings\Live", "PrgLive", CStr(gPrgLive))
    End Function

    Public Function GetIniString(ByRef sTitle As String, ByRef sValueID As String, ByRef sDefault As String, ByVal sPath As String) As String

        Dim sRetValue As String
        Dim lRet As Integer
        'Dim aValue As New VB6.FixedLengthString(1024)
        Dim sValue As New System.Text.StringBuilder(255)

        'sValue.Remove(0, 254)
        'sValue.Clear()
        lRet = GetPrivateProfileString(sTitle, sValueID, sDefault, sValue, 255, sPath)
        sRetValue = Trim(Left(sValue.ToString, lRet))
        GetIniString = sRetValue.ToString

    End Function
    Public Function WriteIniString(ByRef sTitle As String, ByRef sValueID As String, ByRef sDefault As String, ByVal sPath As String) As String

        Dim sRetValue As String
        Dim lRet As Integer
        '    Dim aValue              As String * 1024

        lRet = WritePrivateProfileString(sTitle, sValueID, sDefault, sPath)

        '    sRetValue = Trim$(Left(aValue, lRet))
        '    GetIniString = sRetValue

    End Function

    Public Sub MsgDisplay(ByRef Msg As String, ByRef Color As Color, Optional Index As Short = 0)
        If Old_Msg = Msg Then Exit Sub

        frmMain.lblMessage.ForeColor = Color
        frmMain.lblMessage.Text = Msg
        Old_Msg = Msg
    End Sub

    Public Function FileFind(ByVal Directory As String, ByVal FilePattern As String) As String

        Dim count As Integer

        ' 명시된 디렉토리로부터 모든 파일의 목록을 가져옴
        ' Get recursive List of all files starting in this directory.
        Dim list As List(Of String) = GetFilesRecursive(Directory, FilePattern)

        ' 찾은 파일이 없다면 list의 목록갯수는 0이므로 Null값 리턴
        If list.Count = 0 Then Return ""
        If list.Count >= 1 Then Return list(count) '** 1개 이상일경우

        '** 파일명으로 찾기
        'For count = 0 To list.Count - 1
        '    ' 서브디렉토리까지 모두 검사하므로 몇개의 같은 파일이 목록에 들어올 수 있음.
        '    ' 예를 들어 jre7이라는 디렉토리에 있는 원본 java.exe를 찾고 싶으면 아래내용를 바꿔주면 됨
        '    If InStr(list(count), "\jre7") > 0 Then
        '        Return list(count)
        '    End If
        'Next

        ' 원하는 패턴이 없으면 Null값 리턴
        Return ""
    End Function

    ' 모든 파일을 찾는 재귀호출펑션
    Public Function GetFilesRecursive(ByVal initial As String, ByVal filepattern As String) As List(Of String)

        ' result에 모든 파일의 목록이 저장됨
        Dim result As New List(Of String)

        ' stack을 이용해 모든 디렉토리를 저장함
        Dim stack As New Stack(Of String)

        ' 최초에 받은 디렉토리를 첫 스택에 저장
        stack.Push(initial)

        ' 각각의 stack에 저장된 디렉토리에 대한 검사 시작 (스택의 카운트가 0이 될때까지)
        Do While (stack.Count > 0)
            ' 상위 스택의 디렉토리명 가지고 옴
            Dim dir As String = stack.Pop
            Try
                ' 지정한 패일 패턴에 맞는 모든 파일의 패스를 result에 추가
                result.AddRange(IO.Directory.GetFiles(dir, filepattern))

                ' 모든 하위 디렉토리를 스택에 저장
                Dim directoryName As String
                For Each directoryName In IO.Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

                ' 각종 Exception오류 특히 소유자 오류등이 발생하는 디렉토리는 검색에서 제외함
            Catch ex As Exception
            End Try
        Loop
        ' 저장된 파일의 목록을 돌려줌
        Return result

    End Function


    Function ReportFileStatus(ByRef filespec As Object) As Boolean

        Dim fso As Object ',msg
        Dim Msg As Boolean

        fso = CreateObject("Scripting.FileSystemObject")
        'UPGRADE_WARNING: fso.FileExists 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If (fso.FileExists(filespec)) Then
            '    msg = filespec & "이(가) 있습니다."
            Msg = False
        Else
            '    msg = filespec & "이(가) 없습니다."
            Msg = True
        End If

        ReportFileStatus = Msg

    End Function


    Function ReportFolderStatus(ByRef folderspec As Object) As Boolean

        Dim fso As Object ',msg
        Dim Msg As Boolean

        fso = CreateObject("Scripting.FileSystemObject")
        'UPGRADE_WARNING: fso.FolderExists 개체의 기본 속성을 확인할 수 없습니다. 자세한 내용은 다음을 참조하십시오. 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If (fso.FolderExists(folderspec)) Then
            '    msg = filespec & "이(가) 있습니다."
            Msg = False
        Else
            '    msg = filespec & "이(가) 없습니다."
            Msg = True
        End If
        ReportFolderStatus = Msg

    End Function

    Function ReportDriveStatus(ByRef folderspec As Object) As Boolean

        Dim fso As Object ',msg
        Dim d As Object
        Dim Msg As Boolean

        Try
            fso = CreateObject("Scripting.FileSystemObject")

            d = fso.GetDrive(folderspec)

            If (d.isready) Then
                '    msg = Drive & "이(가) 있습니다."
                Msg = False
            Else
                '    msg = Drive & "이(가) 없습니다."
                Msg = True
            End If
            ReportDriveStatus = Msg

        Catch ex As Exception
            Debug.Print("ReportDrive Err: " & ex.Message)
            If InStr(ex.Message, "CTL_E_DEVICEUNAVAILABLE") Then
                ReportDriveStatus = True
            End If

        End Try


    End Function


    Public Sub WriteLogInText(ByVal strlog As String)
        Dim OpenCHK As Boolean

        OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\LOG")
        If OpenCHK = True Then
            Call MkDir(My.Application.Info.DirectoryPath & "\LOG")
        End If

        Dim currDateTime As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
        Dim WriteStream As New StreamWriter(My.Application.Info.DirectoryPath & "\LOG\" + currDateTime.Substring(0, 10) + ".txt", True)

        'WriteStream.WriteLine(currDateTime + " , " + strlog)
        WriteStream.WriteLine(strlog)
        WriteStream.Close()
    End Sub


    Public Sub Save_EQ_Val_ini()
        Dim OpenCHK As Boolean
        Dim i, lRet As Integer
        Dim sIniFile As String

        '    Dim aValue              As String * 1024

        '** Data 하위 폴더에 연월 폴더 확인 후 생성
        OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\SetData")
        If OpenCHK = True Then
            Call MkDir(My.Application.Info.DirectoryPath & "\SetData")
        End If

        sIniFile = My.Application.Info.DirectoryPath & "\SetData\EQ_VAL.INI"

        With tIni.tEQValIni

            .numTempDeviation = frmMain.numTempDeviation.Value
            .UP35A_SV = frmMain.numTempSV1.Value
            .UP35A_SV_Time = frmMain.numTagetTime1.Value
            .UP35A1_SV = frmMain.numTempSV2.Value
            .UP35A1_SV_Time = frmMain.numTagetTime2.Value

            lRet = WritePrivateProfileString("CONFIG", "numTempDeviation", .numTempDeviation, sIniFile)
            lRet = WritePrivateProfileString("CONFIG", "UP35A_SV", .UP35A_SV, sIniFile)
            lRet = WritePrivateProfileString("CONFIG", "UP35A_SV_Time", .UP35A_SV_Time, sIniFile)
            lRet = WritePrivateProfileString("CONFIG", "UP35A1_SV", .UP35A1_SV, sIniFile)
            lRet = WritePrivateProfileString("CONFIG", "UP35A1_SV_Time", .UP35A1_SV_Time, sIniFile)


        End With



    End Sub



    Public Sub Load_EQ_Val_ini()
        Dim i As Integer = 0
        Dim CamNum As Integer = 0
        Dim PRONO As String = 1
        Dim str As String
        Dim sIniFile As String

        Try
            sIniFile = My.Application.Info.DirectoryPath & "\SetData\EQ_VAL.INI"

            If (ReportFileStatus(sIniFile)) Then
                MsgDisplay("Do not find EQ_VAL File", Color.Red, 0)
                'WorkStatus = ERROR_
                'Default
                With tIni.tEQValIni
                    .UP35A_Com_Port = "com3"
                    .UP35A_Com_Set = "19200,2,8,1,0"
                    .UP35A1_Com_Port = "com4"
                    .UP35A1_Com_Set = "19200,2,8,1,0"

                End With

                Exit Sub
            Else
            End If


            With tIni.tEQValIni
                .numTempDeviation = GetIniString("CONFIG", "numTempDeviation", PRONO, sIniFile)
                .UP35A_Com_Port = GetIniString("CONFIG", "UP35A_Com_Port", PRONO, sIniFile)
                .UP35A_Com_Set = GetIniString("CONFIG", "UP35A_Com_Set", PRONO, sIniFile)
                .UP35A_SV = GetIniString("CONFIG", "UP35A_SV", PRONO, sIniFile)
                .UP35A_SV_Time = GetIniString("CONFIG", "UP35A_SV_Time", PRONO, sIniFile)
                .UP35A1_Com_Port = GetIniString("CONFIG", "UP35A1_Com_Port", PRONO, sIniFile)
                .UP35A1_Com_Set = GetIniString("CONFIG", "UP35A1_Com_Set", PRONO, sIniFile)
                .UP35A1_SV = GetIniString("CONFIG", "UP35A1_SV", PRONO, sIniFile)
                .UP35A1_SV_Time = GetIniString("CONFIG", "UP35A1_SV_Time", PRONO, sIniFile)

                frmMain.numTempDeviation.Value = .numTempDeviation
                frmMain.numTempSV1.Value = .UP35A_SV
                frmMain.numTagetTime1.Value = .UP35A_SV_Time
                frmMain.numTempSV2.Value = .UP35A1_SV
                frmMain.numTagetTime2.Value = .UP35A1_SV_Time
            End With


        Catch ex As Exception
            Debug.Print("Load EQ Val Err : " & ex.Message)
        End Try




    End Sub


    Public Sub Load_PosOldVal_ini()
        Dim i As Integer = 0
        Dim CamNum As Integer = 0
        Dim PRONO As String = 1
        Dim str As String
        Dim sIniFile As String

        Try
            sIniFile = My.Application.Info.DirectoryPath & "\SetData\PosOldVal.INI"

            If (ReportFileStatus(sIniFile)) Then
                MsgDisplay("Do not find PosOldVal File", Color.Red, 0)
                'WorkStatus = ERROR_
                'Default


                Exit Sub
            Else
            End If


            With tIni.tPosOldVal
                .inLet = GetIniString("SET", "inLet", PRONO, sIniFile)

                .inStacker = GetIniString("SET", "inStacker", PRONO, sIniFile)
                .OutStacker = GetIniString("SET", "OutStacker", PRONO, sIniFile)
                .Buffer_1 = GetIniString("SET", "Buffer 1", PRONO, sIniFile)
                .Buffer_2 = GetIniString("SET", "Buffer 2", PRONO, sIniFile)
                .Buffer_3 = GetIniString("SET", "Buffer 3", PRONO, sIniFile)
                .Buffer_4 = GetIniString("SET", "Buffer 4", PRONO, sIniFile)
                .Buffer_5 = GetIniString("SET", "Buffer 5", PRONO, sIniFile)
                .Buffer_6 = GetIniString("SET", "Buffer 6", PRONO, sIniFile)
                .Work_1 = GetIniString("SET", "Work 1", PRONO, sIniFile)
                .Work_2 = GetIniString("SET", "Work 2", PRONO, sIniFile)
                .Work_3 = GetIniString("SET", "Work 3", PRONO, sIniFile)
                .Work_4 = GetIniString("SET", "Work 4", PRONO, sIniFile)
                .Work_5 = GetIniString("SET", "Work 5", PRONO, sIniFile)
                .Work_6 = GetIniString("SET", "Work 6", PRONO, sIniFile)
                .ByPass_1 = GetIniString("SET", "ByPass 1", PRONO, sIniFile)
                .ByPass_2 = GetIniString("SET", "ByPass 2", PRONO, sIniFile)
                .ByPass_3 = GetIniString("SET", "ByPass 3", PRONO, sIniFile)
                .OutLet_1 = GetIniString("SET", "OutLet 1", PRONO, sIniFile)
                .OutLet_2 = GetIniString("SET", "OutLet 2", PRONO, sIniFile)
                .OutLet_3 = GetIniString("SET", "OutLet 3", PRONO, sIniFile)
                .OutLet_4 = GetIniString("SET", "OutLet 4", PRONO, sIniFile)
                .OutLet_5 = GetIniString("SET", "OutLet 5", PRONO, sIniFile)
                .OutLet_6 = GetIniString("SET", "OutLet 6", PRONO, sIniFile)

                Pos_inLet_ID_Old(0, 0) = .inLet
                Pos_inStacker_ID_Old(0, 0) = .inStacker
                Pos_outStacker_ID_Old(0, 0) = .OutStacker

                Pos_Buffer_ID_Old(0, 0) = .Buffer_1
                Pos_Buffer_ID_Old(1, 0) = .Buffer_2
                Pos_Buffer_ID_Old(2, 0) = .Buffer_3
                Pos_Buffer_ID_Old(3, 0) = .Buffer_4
                Pos_Buffer_ID_Old(4, 0) = .Buffer_5
                Pos_Buffer_ID_Old(5, 0) = .Buffer_6

                Pos_Work_ID_Old(0, 0) = .Work_1
                Pos_Work_ID_Old(1, 0) = .Work_2
                Pos_Work_ID_Old(2, 0) = .Work_3
                Pos_Work_ID_Old(3, 0) = .Work_4
                Pos_Work_ID_Old(4, 0) = .Work_5
                Pos_Work_ID_Old(5, 0) = .Work_6

                Pos_ByPass_ID_Old(0, 0) = .ByPass_1
                Pos_ByPass_ID_Old(1, 0) = .ByPass_2
                Pos_ByPass_ID_Old(2, 0) = .ByPass_3

                Pos_OutLet_EndCode_Old(0, 0) = .OutLet_1
                Pos_OutLet_EndCode_Old(1, 0) = .OutLet_2
                Pos_OutLet_EndCode_Old(2, 0) = .OutLet_3
                Pos_OutLet_EndCode_Old(3, 0) = .OutLet_4
                Pos_OutLet_EndCode_Old(4, 0) = .OutLet_5
                Pos_OutLet_EndCode_Old(5, 0) = .OutLet_6


            End With


        Catch ex As Exception
            Debug.Print("Load PosOldVal Err : " & ex.Message)
        End Try

    End Sub

    Public Sub Save_PosOldVal_ini(ByVal Pos As String, ByVal iDVal As String)
        Dim OpenCHK As Boolean
        Dim i, lRet As Integer
        Dim sIniFile As String

        Try
            '** Data 하위 폴더에 연월 폴더 확인 후 생성
            OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\SetData")
            If OpenCHK = True Then
                Call MkDir(My.Application.Info.DirectoryPath & "\SetData")
            End If

            sIniFile = My.Application.Info.DirectoryPath & "\SetData\PosOldVal.INI"

            With tIni.tPosOldVal
                If iDVal = Nothing Then iDVal = ""
                lRet = WritePrivateProfileString("SET", Pos, iDVal, sIniFile)

            End With
        Catch ex As Exception
            Debug.Print("Save_PosOldVal_ini Err = " & ex.Message)
        End Try

    End Sub
    Public Sub Save_TempOffset_ini()
        Dim OpenCHK As Boolean
        Dim i, lRet As Integer
        Dim sIniFile As String


        '** Data 하위 폴더에 연월 폴더 확인 후 생성
        OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\SetData")
        If OpenCHK = True Then
            Call MkDir(My.Application.Info.DirectoryPath & "\SetData")
        End If

        sIniFile = My.Application.Info.DirectoryPath & "\SetData\TempOffset.INI"

        With tIni.tTempOffset
            lRet = WritePrivateProfileString("SET", "TempCNT", 119, sIniFile)
            For i = 0 To 119 - 1
                lRet = WritePrivateProfileString("SET", "T" & i + 1, i + 1, sIniFile)

            Next
        End With

    End Sub

    Public Sub Load_TempOffset_ini()
        Dim i As Integer = 0
        Dim CamNum As Integer = 0
        Dim PRONO As String = 1
        Dim str As String
        Dim sIniFile As String


        Try

            If (ReportFileStatus(My.Application.Info.DirectoryPath & "\SetData\TempOffset.INI")) Then
                MsgDisplay("Do not find TempOffset File", Color.Green, 0)
                'WorkStatus = ERROR_
                Exit Sub
            Else
            End If

            sIniFile = My.Application.Info.DirectoryPath & "\SetData\TempOffset.INI"

            With tIni.tTempOffset
                .TempCNT = CInt(GetIniString("SET", "TempCNT", PRONO, sIniFile))

                ReDim .tOffset(.TempCNT - 1)
                For i = 0 To .TempCNT - 1
                    .tOffset(i) = CInt(GetIniString("SET", "T" & i + 1, PRONO, sIniFile))
                Next
                MsgDisplay("Temp Offset Load OK.", Color.Green, 0)
            End With

        Catch ex As Exception
            Debug.Print("Load_TempOffset Err : " & ex.Message)

        End Try
    End Sub

    Public Sub Save_CNT_Data()
        'Dim OpenCHK As Boolean
        'Dim i, lRet As Integer
        'Dim sIniFile As String

        ''    Dim aValue              As String * 1024

        ''** Data 하위 폴더에 연월 폴더 확인 후 생성
        'OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\SetData")
        'If OpenCHK = True Then
        '    Call MkDir(My.Application.Info.DirectoryPath & "\SetData")
        'End If

        'sIniFile = My.Application.Info.DirectoryPath & "\SetData\CNT_Data.set"

        'lRet = WritePrivateProfileString("Set", "OK_Count", OK_CNT, sIniFile)
        'lRet = WritePrivateProfileString("Set", "NG_Count", NG_CNT, sIniFile)


    End Sub



    Public Sub Load_CNT_Data()
        'Dim i As Integer = 0
        'Dim CamNum As Integer = 0
        'Dim PRONO As String = 1
        'Dim str As String
        'Dim sIniFile As String

        'Try

        '    If (ReportFileStatus(My.Application.Info.DirectoryPath & "\SetData\CNT_Data.set")) Then
        '        MsgDisplay("Do not find Count Data File", Color.Green, 0)
        '        'WorkStatus = ERROR_

        '        Exit Sub
        '    Else
        '    End If

        '    sIniFile = My.Application.Info.DirectoryPath & "\SetData\CNT_Data.set"

        '    OK_CNT = GetIniString("Set", "OK_Count", PRONO, sIniFile)
        '    NG_CNT = GetIniString("Set", "NG_Count", PRONO, sIniFile)

        '    'frmMain.lblOK_Cnt.Text = "OK : " & OK_CNT
        '    'frmMain.lblNG_Cnt.Text = "NG : " & NG_CNT
        '    frmMain.lblOK_Cnt.Text = OK_CNT
        '    frmMain.lblNG_Cnt.Text = NG_CNT
        '    frmMain.lblTotal_Cnt.Text = OK_CNT + NG_CNT

        'Catch ex As Exception
        '    Debug.Print("Load_CNT_Data Err : " & ex.Message)
        'End Try


    End Sub

    Public Sub LoadFile_Model()
        Dim tempmodel As String
        '    If Model <> "" Then
        FileOpen(1, My.Application.Info.DirectoryPath & "\SetData\Model.set", OpenMode.Input)
        If LOF(1) <> 0 Then
            Do While Not EOF(1)
                Input(1, tempmodel)
                frmMain.cboModel.Items.Add(tempmodel)
                frmMain.LstModel.Items.Add(tempmodel)
                '            FrmSetting.LstModel.AddItem tempmodel
            Loop
        End If
        FileClose(1)
        '    End If
    End Sub


    Public Sub SaveFile_Model()
        Dim i As Byte
        Dim model_infor() As String
        Dim sDate As String
        Dim stime As String

        Kill(My.Application.Info.DirectoryPath & "\SetData\Model.set")
        FileOpen(1, My.Application.Info.DirectoryPath & "\SetData\Model.set", OpenMode.Output)

        If frmMain.LstModel.Items.Count <> 0 Then
            For i = 0 To frmMain.LstModel.Items.Count - 1

                WriteLine(1, frmMain.LstModel.Items(i))

            Next i
        End If

        FileClose()


    End Sub

    Public Sub SaveFile_Model_Old()
        Dim i As Byte
        Dim model_infor() As String
        Dim sDate As String
        Dim stime As String

        Kill(My.Application.Info.DirectoryPath & "\SetData\Model.set")
        FileOpen(1, My.Application.Info.DirectoryPath & "\SetData\Model.set", OpenMode.Output)

        If frmMain.LstModel.Items.Count <> 0 Then
            For i = 0 To frmMain.LstModel.Items.Count - 1
                'WriteLine(1, VB6.GetItemString(frmMain.LstModel, i))

                model_infor = Split(frmMain.LstModel.Items(i), ",")

                'model_infor(0) = frmMain.LstModel.Items(i)
                Dim ModleFile_info As New System.IO.FileInfo(My.Application.Info.DirectoryPath & "\SetData\" & model_infor(0) & "_Work.set")
                WriteLine(1, model_infor(0) & ", " & Format(ModleFile_info.LastWriteTime, "yyMMdd" & "_" & "HHmmss"))

                'WriteLine(1, frmMain.LstModel.Items(i))

            Next i
        End If

        FileClose()


    End Sub


    Public Function LoadFile_Work(ByRef ModelName As String) As Boolean
        Dim str As String
        Dim SD_Num As Integer
        Dim PRONO As String = 1
        Dim sIniFile As String


        Try
            If (ReportFileStatus(My.Application.Info.DirectoryPath & "\SetData" & "\" & ModelName & "_" & "Work.set")) Then
                MsgDisplay("Work File이 존재하지 않습니다.", Color.Green, 0)
                WorkStatus = ERROR_

                Exit Function
            Else
            End If


            sIniFile = My.Application.Info.DirectoryPath & "\SetData" & "\" & ModelName & "_" & "Work.set"

            ReDim WorkData.ZR(4, 129)

            With WorkData

                .StepCNT = GetIniString("SET", "StepCNT", PRONO, sIniFile)

                For i = 0 To 0  '4
                    For j = 1 To 129
                        .ZR(i, j) = GetIniString("SET", "ZR" & i & "_" & j, PRONO, sIniFile)
                    Next
                Next

            End With

            Call Work_Data_Display()



            LoadFile_Work = True

            Debug.Print("Model_Load OK")

        Catch ex As Exception
            LoadFile_Work = False
            Debug.Print("LoadFile_Work Err : " & ex.Message)
        End Try



    End Function


    Public Sub SaveFile_Work_Old2(ByRef ModelName As String)

        Dim OpenCHK As Boolean
        Dim sIniFile As String
        Dim lRet As Integer
        '    Dim aValue              As String * 1024


        '** Data 하위 폴더에 연월 폴더 확인 후 생성
        OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\SetData")
        If OpenCHK = True Then
            Call MkDir(My.Application.Info.DirectoryPath & "\SetData")
        End If

        sIniFile = My.Application.Info.DirectoryPath & "\SetData" & "\" & ModelName & "_" & "Work.set"

        With WorkData

            Call WriteIniString("SET", "StepCNT", .StepCNT, sIniFile)

            For i = 0 To 4
                For j = 1 To 129
                    .ZR(i, j) = 0
                    Call WriteIniString("SET", "ZR" & i & "_" & j, .ZR(i, j), sIniFile)
                Next
            Next

        End With

        'Call Work_Data_Display()
    End Sub
    Public Sub SaveFile_Work(ByRef ModelName As String)

        Dim OpenCHK As Boolean
        Dim sIniFile As String
        Dim lRet As Integer
        '    Dim aValue              As String * 1024


        '** Data 하위 폴더에 연월 폴더 확인 후 생성
        OpenCHK = ReportFolderStatus(My.Application.Info.DirectoryPath & "\SetData")
        If OpenCHK = True Then
            Call MkDir(My.Application.Info.DirectoryPath & "\SetData")
        End If

        sIniFile = My.Application.Info.DirectoryPath & "\SetData" & "\" & ModelName & "_" & "Work.set"

        With WorkData
            Call WriteIniString("SET", "StepCNT", .StepCNT.ToString, sIniFile)
            For i = 0 To 0  '4
                For j = 1 To 129
                    Call WriteIniString("SET", "ZR" & i & "_" & j, .ZR(i, j).ToString, sIniFile)
                Next
            Next

        End With

        Call Work_Data_Display()
        Call MsgDisplay("Save Okay ~", Color.Lime, 0)
    End Sub
    Public Function Work_data_String_D(ByVal start_adr As Integer, ByVal Word As Integer) As String
        Dim i As Byte
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String


        'On Error Resume Next
        Try
            Work_id = ""
            For i = 0 To Word - 1
                PLC_Read = Strings.Right("0000" & Hex(PlcData_D0(start_adr + i)), 4)
                Buf1 = Mid(PLC_Read, 1, 2)
                Buf2 = Mid(PLC_Read, 3, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf2))
                Work_id = Work_id & Chr(Val("&H" & Buf1))

                'PLC_Read = Hex(PlcData_D0(start_adr + i))
                'If Len(PLC_Read) = 4 Then
                '    Buf1 = Mid(PLC_Read, 1, 2)
                '    Buf2 = Mid(PLC_Read, 3, 2)
                '    Work_id = Work_id & Chr(Val("&H" & Buf2))
                '    Work_id = Work_id & Chr(Val("&H" & Buf1))
                'ElseIf Len(PLC_Read) = 2 Then
                '    Buf1 = Mid(PLC_Read, 1, 2)
                '    Work_id = Work_id & Chr(Val("&H" & Buf1))
                'End If
            Next
            Work_data_String_D = Trim(Work_id)

            'Debug.Print(Replace(Work_data_String, vbNullChar, ""))

            Work_data_String_D = Replace(Work_data_String_D, vbNullChar, "")

            Return Work_data_String_D
        Catch ex As Exception
            Debug.Print("WordDataString D Err : " & ex.Message)
        End Try

    End Function

    Public Function Work_data_String_ZR(ByVal start_adr As Integer, ByVal Word As Integer) As String
        Dim i As Byte
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String


        'On Error Resume Next
        Try
            Work_id = ""
            For i = 0 To Word - 1
                PLC_Read = Strings.Right("0000" & Hex(PlcData_ZR(start_adr + i)), 4)
                Buf1 = Mid(PLC_Read, 1, 2)
                Buf2 = Mid(PLC_Read, 3, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf2))
                Work_id = Work_id & Chr(Val("&H" & Buf1))

                'PLC_Read = Hex(PlcData_D0(start_adr + i))
                'If Len(PLC_Read) = 4 Then
                '    Buf1 = Mid(PLC_Read, 1, 2)
                '    Buf2 = Mid(PLC_Read, 3, 2)
                '    Work_id = Work_id & Chr(Val("&H" & Buf2))
                '    Work_id = Work_id & Chr(Val("&H" & Buf1))
                'ElseIf Len(PLC_Read) = 2 Then
                '    Buf1 = Mid(PLC_Read, 1, 2)
                '    Work_id = Work_id & Chr(Val("&H" & Buf1))
                'End If
            Next
            Work_data_String_ZR = Trim(Work_id)

            'Debug.Print(Replace(Work_data_String, vbNullChar, ""))

            Work_data_String_ZR = Replace(Work_data_String_ZR, vbNullChar, "")

            Return Work_data_String_ZR
        Catch ex As Exception
            Debug.Print("WordDataString ZR Err : " & ex.Message)
        End Try

    End Function

    Public Function Work_data_String_Recipe(ByVal start_adr As Integer, ByVal Word As Integer, ByVal iStep As Integer) As String
        Dim i As Byte
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String


        'On Error Resume Next
        Try
            Work_id = ""
            For i = 0 To Word - 1
                PLC_Read = Strings.Right("0000" & Hex(WorkData.ZR(iStep, start_adr + i)), 4)
                Buf1 = Mid(PLC_Read, 1, 2)
                Buf2 = Mid(PLC_Read, 3, 2)
                Work_id = Work_id & Chr(Val("&H" & Buf2))
                Work_id = Work_id & Chr(Val("&H" & Buf1))

                'PLC_Read = Hex(PlcData_D0(start_adr + i))
                'If Len(PLC_Read) = 4 Then
                '    Buf1 = Mid(PLC_Read, 1, 2)
                '    Buf2 = Mid(PLC_Read, 3, 2)
                '    Work_id = Work_id & Chr(Val("&H" & Buf2))
                '    Work_id = Work_id & Chr(Val("&H" & Buf1))
                'ElseIf Len(PLC_Read) = 2 Then
                '    Buf1 = Mid(PLC_Read, 1, 2)
                '    Work_id = Work_id & Chr(Val("&H" & Buf1))
                'End If
            Next
            Work_data_String_Recipe = Trim(Work_id)

            'Debug.Print(Replace(Work_data_String, vbNullChar, ""))

            Work_data_String_Recipe = Replace(Work_data_String_Recipe, vbNullChar, "")

            Return Work_data_String_Recipe
        Catch ex As Exception
            Debug.Print("WordDataString ZR Err : " & ex.Message)
        End Try

    End Function

    Public Sub Work_data_String_Write_D(ByVal start_adr As Integer, ByVal Word As Integer, ByVal str As String)
        Dim i, j As Integer
        Dim iReturnCode As Integer
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String
        Dim pad As String = " "

        Try
            j = 0
            Work_id = ""
            If Len(str) Mod 2 <> 0 Then str = str & " " 'vbNullChar

            'str = str.PadLeft(Word * 2, pad)
            str = str.PadRight(Word * 2, pad)

            For i = 1 To (Word * 2) Step 2
                Buf1 = Hex(Asc(Mid(str, i, 1)))
                Buf2 = Hex(Asc(Mid(str, i + 1, 1)))

                Work_id = Convert.ToInt16(Buf2 & Buf1, 16)
                'Debug.Print("covert = " & Work_id)
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D" & start_adr + j, 1, Work_id)
                j += 1
            Next

        Catch ex As Exception
            Debug.Print("WordDataString Write D Err : " & ex.Message)
        End Try

    End Sub

    Public Sub Work_data_String_Write_ZR(ByVal start_adr As Integer, ByVal Word As Integer, ByVal str As String)
        Dim i, j As Integer
        Dim iReturnCode As Integer
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String
        Dim pad As String = " "

        Try
            j = 0
            Work_id = ""
            If Len(str) Mod 2 <> 0 Then str = str & " " 'vbNullChar

            'str = str.PadLeft(Word * 2, pad)
            str = str.PadRight(Word * 2, pad)

            For i = 1 To (Word * 2) Step 2
                Buf1 = Hex(Asc(Mid(str, i, 1)))
                Buf2 = Hex(Asc(Mid(str, i + 1, 1)))

                Work_id = Convert.ToInt16(Buf2 & Buf1, 16)
                'Debug.Print("covert = " & Work_id)
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR" & start_adr + j, 1, Work_id)
                j += 1
            Next

        Catch ex As Exception
            Debug.Print("WordDataString Write ZR Err : " & ex.Message)
        End Try

    End Sub

    Public Sub Work_data_String_ReturnEach(ByVal Word As Integer, ByVal str As String, ByRef Dec() As String)
        Dim i, j As Integer
        Dim Work_id As String
        Dim PLC_Read As String
        Dim Buf1 As String
        Dim Buf2 As String
        Dim pad As String = " "

        Try
            j = 0
            Work_id = ""
            ReDim Dec(Word)
            If Len(str) Mod 2 <> 0 Then str = str & " " 'vbNullChar

            'str = str.PadLeft(Word * 2, pad)
            str = str.PadRight(Word * 2, pad)

            For i = 1 To (Word * 2) Step 2
                Buf1 = Hex(Asc(Mid(str, i, 1)))
                Buf2 = Hex(Asc(Mid(str, i + 1, 1)))

                Work_id = Convert.ToInt16(Buf2 & Buf1, 16)
                'Debug.Print("covert = " & Work_id)
                'frmMain.iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR" & start_adr + j, 1, Work_id)
                Dec(j) = Work_id
                j += 1
            Next

        Catch ex As Exception
            Debug.Print("WordDataString Write ZR Err : " & ex.Message)
        End Try

    End Sub

    ' Convert four Byte array elements to a Single and display it. (ieee 754 32bit float)
    Public Function BAToSingle(bytes() As Byte, index As Integer) As Single

        Dim value As Single = BitConverter.ToSingle(bytes, index)

        BAToSingle = value

        'Console.WriteLine(formatter, index,
        '    BitConverter.ToString(bytes, index, 4), value)
    End Function
    Public Sub Work_Data_Display()
        Dim iReturnCode As Integer
        Dim i As Integer

        Try

            With WorkData
                'frmMain.lblStep_SV.Text = .StepCNT
                frmMain.numStepCNT.Value = .StepCNT
                frmMain.DataGridView1.Columns.Item(6).ReadOnly = True
                frmMain.DataGridView1.Columns.Item(6).DefaultCellStyle.BackColor = Color.LightGray
                Select Case .StepCNT
                    Case 1
                        frmMain.DataGridView1.Columns.Item(1).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(2).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(3).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(4).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(5).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(1).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(2).DefaultCellStyle.BackColor = Color.LightGray
                        frmMain.DataGridView1.Columns.Item(3).DefaultCellStyle.BackColor = Color.LightGray
                        frmMain.DataGridView1.Columns.Item(4).DefaultCellStyle.BackColor = Color.LightGray
                        frmMain.DataGridView1.Columns.Item(5).DefaultCellStyle.BackColor = Color.LightGray
                    Case 2
                        frmMain.DataGridView1.Columns.Item(1).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(2).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(3).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(4).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(5).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(1).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(2).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(3).DefaultCellStyle.BackColor = Color.LightGray
                        frmMain.DataGridView1.Columns.Item(4).DefaultCellStyle.BackColor = Color.LightGray
                        frmMain.DataGridView1.Columns.Item(5).DefaultCellStyle.BackColor = Color.LightGray
                    Case 3
                        frmMain.DataGridView1.Columns.Item(1).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(2).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(3).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(4).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(5).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(1).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(2).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(3).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(4).DefaultCellStyle.BackColor = Color.LightGray
                        frmMain.DataGridView1.Columns.Item(5).DefaultCellStyle.BackColor = Color.LightGray
                    Case 4
                        frmMain.DataGridView1.Columns.Item(1).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(2).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(3).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(4).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(5).ReadOnly = True
                        frmMain.DataGridView1.Columns.Item(1).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(2).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(3).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(4).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(5).DefaultCellStyle.BackColor = Color.LightGray
                    Case 5
                        frmMain.DataGridView1.Columns.Item(1).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(2).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(3).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(4).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(5).ReadOnly = False
                        frmMain.DataGridView1.Columns.Item(1).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(2).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(3).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(4).DefaultCellStyle.BackColor = Color.Empty
                        frmMain.DataGridView1.Columns.Item(5).DefaultCellStyle.BackColor = Color.Empty
                End Select
                ' ZR
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR20", 1, .ZR(0, 20))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR22", 1, .ZR(0, 22))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR30", 1, .ZR(0, 30))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR31", 1, .ZR(0, 31))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR40", 1, .ZR(0, 40))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR41", 1, .ZR(0, 41))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR60", 1, .ZR(0, 60))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR61", 1, .ZR(0, 61))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR70", 1, .ZR(0, 70))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR71", 1, .ZR(0, 71))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR50", 1, .ZR(0, 50))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR54", 1, .ZR(0, 54))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR80", 1, .ZR(0, 80))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR81", 1, .ZR(0, 81))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR82", 1, .ZR(0, 82))
                Call DoubleDataWrite("ZR", 92, .ZR(0, 92))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("ZR110", 1, .ZR(0, 110))
                Call DoubleDataWrite("ZR", 112, .ZR(0, 112))
                Call DoubleDataWrite("ZR", 94, .ZR(0, 94))
                Call DoubleDataWrite("ZR", 96, .ZR(0, 96))
                Call DoubleDataWrite("ZR", 90, .ZR(0, 90))
                Call DoubleDataWrite("ZR", 98, .ZR(0, 98))
                Call DoubleDataWrite("ZR", 102, .ZR(0, 102))
                Call DoubleDataWrite("ZR", 104, .ZR(0, 104))
                Call DoubleDataWrite("ZR", 100, .ZR(0, 100))
                Call DoubleDataWrite("ZR", 106, .ZR(0, 106))
                Call DoubleDataWrite("ZR", 108, .ZR(0, 108))
                ' D
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1020", 1, .ZR(0, 20))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1022", 1, .ZR(0, 22))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1030", 1, .ZR(0, 30))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1031", 1, .ZR(0, 31))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1040", 1, .ZR(0, 40))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1041", 1, .ZR(0, 41))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1060", 1, .ZR(0, 60))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1061", 1, .ZR(0, 61))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1070", 1, .ZR(0, 70))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1071", 1, .ZR(0, 71))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1050", 1, .ZR(0, 50))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1054", 1, .ZR(0, 54))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1080", 1, .ZR(0, 80))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1081", 1, .ZR(0, 81))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1082", 1, .ZR(0, 82))
                Call DoubleDataWrite("D", 1092, .ZR(0, 92))
                iReturnCode = frmMain.AxActUtlType1.WriteDeviceBlock("D1110", 1, .ZR(0, 110))
                Call DoubleDataWrite("D", 1112, .ZR(0, 112))
                Call DoubleDataWrite("D", 1094, .ZR(0, 94))
                Call DoubleDataWrite("D", 1096, .ZR(0, 96))
                Call DoubleDataWrite("D", 1090, .ZR(0, 90))
                Call DoubleDataWrite("D", 1098, .ZR(0, 98))
                Call DoubleDataWrite("D", 1102, .ZR(0, 102))
                Call DoubleDataWrite("D", 1104, .ZR(0, 104))
                Call DoubleDataWrite("D", 1100, .ZR(0, 100))
                Call DoubleDataWrite("D", 1106, .ZR(0, 106))
                Call DoubleDataWrite("D", 1108, .ZR(0, 108))


                For i = 0 To 0  '4
                    frmMain.DataGridView1(i + 1, 0).Value = .ZR(i, 20)
                    frmMain.DataGridView1(i + 1, 1).Value = .ZR(i, 22) / 10
                    frmMain.DataGridView1(i + 1, 2).Value = .ZR(i, 30) / 10
                    frmMain.DataGridView1(i + 1, 3).Value = .ZR(i, 31)
                    frmMain.DataGridView1(i + 1, 4).Value = .ZR(i, 40) / 10
                    frmMain.DataGridView1(i + 1, 5).Value = .ZR(i, 41)
                    frmMain.DataGridView1(i + 1, 6).Value = .ZR(i, 60) / 10
                    frmMain.DataGridView1(i + 1, 7).Value = .ZR(i, 61)
                    frmMain.DataGridView1(i + 1, 8).Value = .ZR(i, 70) / 10
                    frmMain.DataGridView1(i + 1, 9).Value = .ZR(i, 71)
                    frmMain.DataGridView1(i + 1, 10).Value = .ZR(i, 50)
                    frmMain.DataGridView1(i + 1, 11).Value = .ZR(i, 54)
                    frmMain.DataGridView1(i + 1, 12).Value = Work_data_String_Recipe(80, 3, i)
                    frmMain.DataGridView1(i + 1, 13).Value = DoubleDataRead(.ZR(i, 92), .ZR(i, 93)) / 10
                    frmMain.DataGridView1(i + 1, 14).Value = .ZR(i, 110)
                    frmMain.DataGridView1(i + 1, 15).Value = DoubleDataRead(.ZR(i, 112), .ZR(i, 113)) / 10
                    frmMain.DataGridView1(i + 1, 16).Value = DoubleDataRead(.ZR(i, 94), .ZR(i, 95)) / 10
                    frmMain.DataGridView1(i + 1, 17).Value = DoubleDataRead(.ZR(i, 96), .ZR(i, 97)) / 10
                    frmMain.DataGridView1(i + 1, 18).Value = DoubleDataRead(.ZR(i, 90), .ZR(i, 91)) / 10
                    frmMain.DataGridView1(i + 1, 19).Value = DoubleDataRead(.ZR(i, 98), .ZR(i, 99)) / 10
                    frmMain.DataGridView1(i + 1, 20).Value = DoubleDataRead(.ZR(i, 102), .ZR(i, 103)) / 10
                    frmMain.DataGridView1(i + 1, 21).Value = DoubleDataRead(.ZR(i, 104), .ZR(i, 105)) / 10
                    frmMain.DataGridView1(i + 1, 22).Value = DoubleDataRead(.ZR(i, 100), .ZR(i, 101)) / 10
                    frmMain.DataGridView1(i + 1, 23).Value = DoubleDataRead(.ZR(i, 106), .ZR(i, 107)) / 10
                    frmMain.DataGridView1(i + 1, 24).Value = DoubleDataRead(.ZR(i, 108), .ZR(i, 109)) / 10
                Next

                ''Current Colums
                'frmMain.DataGridView1(6, 0).Value = frmMain.DataGridView1(1, 0).Value
                'frmMain.DataGridView1(6, 1).Value = frmMain.DataGridView1(1, 1).Value
                'frmMain.DataGridView1(6, 2).Value = frmMain.DataGridView1(1, 2).Value
                'frmMain.DataGridView1(6, 3).Value = frmMain.DataGridView1(1, 3).Value
                'frmMain.DataGridView1(6, 4).Value = frmMain.DataGridView1(1, 4).Value
                'frmMain.DataGridView1(6, 5).Value = frmMain.DataGridView1(1, 5).Value
                'frmMain.DataGridView1(6, 6).Value = frmMain.DataGridView1(1, 6).Value
                'frmMain.DataGridView1(6, 7).Value = frmMain.DataGridView1(1, 7).Value
                'frmMain.DataGridView1(6, 8).Value = frmMain.DataGridView1(1, 8).Value
                'frmMain.DataGridView1(6, 9).Value = frmMain.DataGridView1(1, 9).Value
                'frmMain.DataGridView1(6, 10).Value = frmMain.DataGridView1(1, 10).Value
                'frmMain.DataGridView1(6, 11).Value = frmMain.DataGridView1(1, 11).Value
                'frmMain.DataGridView1(6, 12).Value = frmMain.DataGridView1(1, 12).Value
                'frmMain.DataGridView1(6, 13).Value = frmMain.DataGridView1(1, 13).Value
                'frmMain.DataGridView1(6, 14).Value = frmMain.DataGridView1(1, 14).Value
                'frmMain.DataGridView1(6, 15).Value = frmMain.DataGridView1(1, 15).Value
                'frmMain.DataGridView1(6, 16).Value = frmMain.DataGridView1(1, 16).Value
                'frmMain.DataGridView1(6, 17).Value = frmMain.DataGridView1(1, 17).Value
                'frmMain.DataGridView1(6, 18).Value = frmMain.DataGridView1(1, 18).Value
                'frmMain.DataGridView1(6, 19).Value = frmMain.DataGridView1(1, 19).Value
                'frmMain.DataGridView1(6, 20).Value = frmMain.DataGridView1(1, 20).Value
                'frmMain.DataGridView1(6, 21).Value = frmMain.DataGridView1(1, 21).Value
                'frmMain.DataGridView1(6, 22).Value = frmMain.DataGridView1(1, 22).Value
                'frmMain.DataGridView1(6, 23).Value = frmMain.DataGridView1(1, 23).Value
            End With


        Catch ex As Exception
            Debug.Print("WorkDisplay Err : " & ex.Message)

        End Try


    End Sub
    Public Function PulseTomm(ByVal Pulse As Double, ByVal Axis As Byte) As Double



        'Select Case Axis
        '    Case TopForm_UpDn_1AX_
        '        'PulseTomm = Pulse * .TopForm_UpDn_1AX_PitchPerRev / .TopForm_UpDn_1AX_PulsePerRev
        '        PulseTomm = Pulse * 5 / 10000

        '    Case TopForm_UpDn_2AX_
        '        PulseTomm = Pulse * 5 / 10000

        '    Case TopForm_UpDn_3AX_
        '        PulseTomm = Pulse * 5 / 10000

        '    Case TopForm_UpDn_4AX_
        '        PulseTomm = Pulse * 5 / 10000

        '    Case Cutting_5AX_
        '        PulseTomm = Pulse * 20 / 10000

        '    Case Feeding_6AX_
        '        PulseTomm = Pulse * 20 / 10000

        'End Select




        'With tIni.tEQVaiIni
        '    Select Case Axis
        '        Case TopForm_UpDn_1AX_
        '            'PulseTomm = Pulse * MagnetStationWorkData.PitchPerRev_MagnetStation(Axis) / MagnetStationWorkData.PulsePerRev_MagnetStation(Axis)
        '            PulseTomm = Pulse * .TopForm_UpDn_1AX_PitchPerRev / .TopForm_UpDn_1AX_PulsePerRev
        '            'If frmMain.LoadOKFlag = True Then PulseTomm = PulseTomm * -1

        '        Case TopForm_UpDn_2AX_
        '            PulseTomm = Pulse * .TopForm_UpDn_2AX_PitchPerRev / .TopForm_UpDn_2AX_PulsePerRev

        '        Case TopForm_UpDn_3AX_
        '            PulseTomm = Pulse * .TopForm_UpDn_3AX_PitchPerRev / .TopForm_UpDn_3AX_PulsePerRev

        '        Case TopForm_UpDn_4AX_
        '            PulseTomm = Pulse * .TopForm_UpDn_4AX_PitchPerRev / .TopForm_UpDn_4AX_PulsePerRev

        '        Case Cutting_5AX_
        '            PulseTomm = Pulse * .Cutting_5AX_PitchPerRev / .Cutting_5AX_PulsePerRev

        '        Case Feeding_6AX_
        '            PulseTomm = Pulse * .Feeding_6AX_PitchPerRev / .Feeding_6AX_PulsePerRev

        '    End Select
        'End With


    End Function


    Public Function mmToPulse(ByVal mm As Double, ByVal Axis As Byte) As Double



        'Select Case Axis
        '    Case TopForm_UpDn_1AX_
        '        'mmToPulse = .Transfer_Y_1AX_PulsePerRev * mm / .Transfer_Y_1AX_PitchPerRev
        '        mmToPulse = 10000 * mm / 5

        '    Case TopForm_UpDn_2AX_
        '        mmToPulse = 10000 * mm / 5

        '    Case TopForm_UpDn_3AX_
        '        mmToPulse = 10000 * mm / 5

        '    Case TopForm_UpDn_4AX_
        '        mmToPulse = 10000 * mm / 5

        '    Case Cutting_5AX_
        '        mmToPulse = 10000 * mm / 20

        '    Case Feeding_6AX_
        '        mmToPulse = 10000 * mm / 20
        'End Select



        'With tIni.tEQVaiIni
        '    Select Case Axis
        '        Case TopForm_UpDn_1AX_
        '            'mmToPulse = MagnetStationWorkData.PulsePerRev_MagnetStation(Axis) * mm / MagnetStationWorkData.PitchPerRev_MagnetStation(Axis)
        '            mmToPulse = .TopForm_UpDn_1AX_PulsePerRev * mm / .TopForm_UpDn_1AX_PitchPerRev
        '            'If frmMain.LoadOKFlag = True Then mmToPulse = mmToPulse * -1

        '        Case TopForm_UpDn_2AX_
        '            mmToPulse = .TopForm_UpDn_2AX_PulsePerRev * mm / .TopForm_UpDn_2AX_PitchPerRev

        '        Case TopForm_UpDn_3AX_
        '            mmToPulse = .TopForm_UpDn_3AX_PulsePerRev * mm / .TopForm_UpDn_3AX_PitchPerRev

        '        Case TopForm_UpDn_4AX_
        '            mmToPulse = .TopForm_UpDn_4AX_PulsePerRev * mm / .TopForm_UpDn_4AX_PitchPerRev

        '        Case Cutting_5AX_
        '            mmToPulse = .Cutting_5AX_PulsePerRev * mm / .Cutting_5AX_PitchPerRev

        '        Case Feeding_6AX_
        '            mmToPulse = .Feeding_6AX_PulsePerRev * mm / .Feeding_6AX_PitchPerRev
        '    End Select

        'Debug.Print(.TopForm_UpDn_1AX_PulsePerRev)
        'Debug.Print(.TopForm_UpDn_1AX_PitchPerRev)
        'End With


    End Function

    '///////////////////////////////////////////////////////////////////////////////////////////////////
    ' TextBox 용 델리게이트함수
    ' 1   dTextBoxTextAdd  (c As TextBox, s As String)    '텍스트 박스속성을 멀티라인으로 바꾸고 사용할 것.
    '
    ' Label 용 델리게이트함수
    ' 2   dLabelText            (c As Label, s As String)
    '     라벨
    'ProgressBar 용 델리게이트함수
    ' 3   dProgressValue     (c As ProgressBar, i As Integer)
    '

    '바로아래 함수와 셋트임
    Delegate Sub DelegateTextBoxAdd(c As TextBox, s As String)
    Public Sub dTextBoxTextAdd(c As TextBox, s As String)
        If c.IsHandleCreated = False Then Exit Sub
        If c.InvokeRequired = True Then
            Dim dlg As New DelegateTextBoxAdd(AddressOf dTextBoxTextAdd)
            Try
                c.Invoke(dlg, New Object() {c, s})
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        Else
            Try
                c.Text = c.Text & s & vbCrLf
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
    End Sub

    '바로아래 함수와 셋트임
    Delegate Sub DelegateLabelText(c As Label, s As String)
    Public Sub dLabelText(c As Label, s As String)
        If c.IsHandleCreated = False Then Exit Sub
        If c.InvokeRequired = True Then
            Dim dlg As New DelegateLabelText(AddressOf dLabelText)
            Try
                c.Invoke(dlg, New Object() {c, s})
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        Else
            Try
                c.Text = s
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
    End Sub

    '바로아래 함수와 셋트임 
    Delegate Sub DelegateProgressValue(c As ProgressBar, i As Integer)
    Public Sub dProgressValue(c As ProgressBar, i As Integer)
        If c.IsHandleCreated = False Then Exit Sub
        If c.InvokeRequired = True Then
            Dim dlg As New DelegateProgressValue(AddressOf dProgressValue)
            Try
                c.Invoke(dlg, New Object() {c, i})
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        Else
            Try
                c.Value = i
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
    End Sub


    Dim CRC16_table(0 To 255) As Long

    Public Sub CRC16_init()
        Dim TempTable As Object
        Dim i As Integer
        'Dim TempTable() As Object = 
        TempTable = New Object() {&H0, &HC0C1, &HC181, &H140, &HC301, &H3C0, &H280, &HC241, &HC601, &H6C0, &H780, &HC741, &H500, &HC5C1, &HC481, &H440, _
                                &HCC01, &HCC0, &HD80, &HCD41, &HF00, &HCFC1, &HCE81, &HE40, &HA00, &HCAC1, &HCB81, &HB40, &HC901, &H9C0, &H880, &HC841, _
                                &HD801, &H18C0, &H1980, &HD941, &H1B00, &HDBC1, &HDA81, &H1A40, &H1E00, &HDEC1, &HDF81, &H1F40, &HDD01, &H1DC0, &H1C80, &HDC41, _
                                &H1400, &HD4C1, &HD581, &H1540, &HD701, &H17C0, &H1680, &HD641, &HD201, &H12C0, &H1380, &HD341, &H1100, &HD1C1, &HD081, &H1040, _
                                &HF001, &H30C0, &H3180, &HF141, &H3300, &HF3C1, &HF281, &H3240, &H3600, &HF6C1, &HF781, &H3740, &HF501, &H35C0, &H3480, &HF441, _
                                &H3C00, &HFCC1, &HFD81, &H3D40, &HFF01, &H3FC0, &H3E80, &HFE41, &HFA01, &H3AC0, &H3B80, &HFB41, &H3900, &HF9C1, &HF881, &H3840, _
                                &H2800, &HE8C1, &HE981, &H2940, &HEB01, &H2BC0, &H2A80, &HEA41, &HEE01, &H2EC0, &H2F80, &HEF41, &H2D00, &HEDC1, &HEC81, &H2C40, _
                                &HE401, &H24C0, &H2580, &HE541, &H2700, &HE7C1, &HE681, &H2640, &H2200, &HE2C1, &HE381, &H2340, &HE101, &H21C0, &H2080, &HE041, _
                                &HA001, &H60C0, &H6180, &HA141, &H6300, &HA3C1, &HA281, &H6240, &H6600, &HA6C1, &HA781, &H6740, &HA501, &H65C0, &H6480, &HA441, _
                                &H6C00, &HACC1, &HAD81, &H6D40, &HAF01, &H6FC0, &H6E80, &HAE41, &HAA01, &H6AC0, &H6B80, &HAB41, &H6900, &HA9C1, &HA881, &H6840, _
                                &H7800, &HB8C1, &HB981, &H7940, &HBB01, &H7BC0, &H7A80, &HBA41, &HBE01, &H7EC0, &H7F80, &HBF41, &H7D00, &HBDC1, &HBC81, &H7C40, _
                                &HB401, &H74C0, &H7580, &HB541, &H7700, &HB7C1, &HB681, &H7640, &H7200, &HB2C1, &HB381, &H7340, &HB101, &H71C0, &H7080, &HB041, _
                                &H5000, &H90C1, &H9181, &H5140, &H9301, &H53C0, &H5280, &H9241, &H9601, &H56C0, &H5780, &H9741, &H5500, &H95C1, &H9481, &H5440, _
                                &H9C01, &H5CC0, &H5D80, &H9D41, &H5F00, &H9FC1, &H9E81, &H5E40, &H5A00, &H9AC1, &H9B81, &H5B40, &H9901, &H59C0, &H5880, &H9841, _
                                &H8801, &H48C0, &H4980, &H8941, &H4B00, &H8BC1, &H8A81, &H4A40, &H4E00, &H8EC1, &H8F81, &H4F40, &H8D01, &H4DC0, &H4C80, &H8C41, _
                                &H4400, &H84C1, &H8581, &H4540, &H8701, &H47C0, &H4680, &H8641, &H8201, &H42C0, &H4380, &H8341, &H4100, &H81C1, &H8081, &H4040}


        'TempTable = Array( _
        '    &H0, &HC0C1, &HC181, &H140, &HC301, &H3C0, &H280, &HC241, &HC601, &H6C0, &H780, &HC741, &H500, &HC5C1, &HC481, &H440, _
        '    &HCC01, &HCC0, &HD80, &HCD41, &HF00, &HCFC1, &HCE81, &HE40, &HA00, &HCAC1, &HCB81, &HB40, &HC901, &H9C0, &H880, &HC841, _
        '    &HD801, &H18C0, &H1980, &HD941, &H1B00, &HDBC1, &HDA81, &H1A40, &H1E00, &HDEC1, &HDF81, &H1F40, &HDD01, &H1DC0, &H1C80, &HDC41, _
        '    &H1400, &HD4C1, &HD581, &H1540, &HD701, &H17C0, &H1680, &HD641, &HD201, &H12C0, &H1380, &HD341, &H1100, &HD1C1, &HD081, &H1040, _
        '    &HF001, &H30C0, &H3180, &HF141, &H3300, &HF3C1, &HF281, &H3240, &H3600, &HF6C1, &HF781, &H3740, &HF501, &H35C0, &H3480, &HF441, _
        '    &H3C00, &HFCC1, &HFD81, &H3D40, &HFF01, &H3FC0, &H3E80, &HFE41, &HFA01, &H3AC0, &H3B80, &HFB41, &H3900, &HF9C1, &HF881, &H3840, _
        '    &H2800, &HE8C1, &HE981, &H2940, &HEB01, &H2BC0, &H2A80, &HEA41, &HEE01, &H2EC0, &H2F80, &HEF41, &H2D00, &HEDC1, &HEC81, &H2C40, _
        '    &HE401, &H24C0, &H2580, &HE541, &H2700, &HE7C1, &HE681, &H2640, &H2200, &HE2C1, &HE381, &H2340, &HE101, &H21C0, &H2080, &HE041, _
        '    &HA001, &H60C0, &H6180, &HA141, &H6300, &HA3C1, &HA281, &H6240, &H6600, &HA6C1, &HA781, &H6740, &HA501, &H65C0, &H6480, &HA441, _
        '    &H6C00, &HACC1, &HAD81, &H6D40, &HAF01, &H6FC0, &H6E80, &HAE41, &HAA01, &H6AC0, &H6B80, &HAB41, &H6900, &HA9C1, &HA881, &H6840, _
        '    &H7800, &HB8C1, &HB981, &H7940, &HBB01, &H7BC0, &H7A80, &HBA41, &HBE01, &H7EC0, &H7F80, &HBF41, &H7D00, &HBDC1, &HBC81, &H7C40, _
        '    &HB401, &H74C0, &H7580, &HB541, &H7700, &HB7C1, &HB681, &H7640, &H7200, &HB2C1, &HB381, &H7340, &HB101, &H71C0, &H7080, &HB041, _
        '    &H5000, &H90C1, &H9181, &H5140, &H9301, &H53C0, &H5280, &H9241, &H9601, &H56C0, &H5780, &H9741, &H5500, &H95C1, &H9481, &H5440, _
        '    &H9C01, &H5CC0, &H5D80, &H9D41, &H5F00, &H9FC1, &H9E81, &H5E40, &H5A00, &H9AC1, &H9B81, &H5B40, &H9901, &H59C0, &H5880, &H9841, _
        '    &H8801, &H48C0, &H4980, &H8941, &H4B00, &H8BC1, &H8A81, &H4A40, &H4E00, &H8EC1, &H8F81, &H4F40, &H8D01, &H4DC0, &H4C80, &H8C41, _
        '    &H4400, &H84C1, &H8581, &H4540, &H8701, &H47C0, &H4680, &H8641, &H8201, &H42C0, &H4380, &H8341, &H4100, &H81C1, &H8081, &H4040)

        For i = 0 To UBound(TempTable)
            CRC16_table(i) = TempTable(i) And 65535
        Next i
    End Sub


    Function CRC16table_packet(ByRef Packet() As Byte, ByRef Size As Integer) As Long
        Dim CRC As Long
        Dim CRCt As Long
        Dim t As Integer
        Dim i As Integer

        CRC = 65535
        For i = 0 To Size - 1
            t = (Packet(i) Xor CRC) And 255
            CRCt = Fix(CRC / 256)
            CRC = (CRCt Xor CRC16_table(t)) And 65535
        Next i

        CRC16table_packet = CRC
    End Function

    Function Crc8(ByVal data As Byte(), ByVal size As Integer) As Byte
        Dim checksum As Byte = 0
        For i As Integer = 0 To size - 1
            checksum = (CInt(checksum) + data(i)) Mod 256
        Next
        If checksum = 0 Then
            Return 0
        Else
            Return CByte(256 - checksum)
        End If
    End Function

    'Public Sub WaitTimer(ByRef Time As Single)
    '    Dim hTimer As Single
    '    hTimer = Timer + (Time / 100)
    '    Do
    '        DoEvents()
    '    Loop Until hTimer < Timer
    'End Sub

End Module
