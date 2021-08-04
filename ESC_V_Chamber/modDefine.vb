Option Explicit On

Module modDefine

    Public PlcData_M_Test(0) As Short

    '** PLC Data
    'Public Const PLC_Data_CNT_ = 1900   '1800
    'Public PlcData(PLC_Data_CNT_ - 1) As Short
    Public Const PLC_L_CNT_ = 1040  '1038
    Public PlcData_L((PLC_L_CNT_ / 16) - 1) As Short
    Public PlcData_L_bit(PLC_L_CNT_ - 1) As Short

    Public Const PLC_M_CNT_ = 416   '411
    Public PlcData_M((PLC_M_CNT_ / 16) - 1) As Short
    Public PlcData_M_bit(PLC_M_CNT_ - 1) As Short

    Public Const PLC_X_CNT_ = 4176  '2656  '1056  '1046      '0123456789ABCDEF
    Public PlcData_X((PLC_X_CNT_ / 16) - 1) As Short
    Public PlcData_X_bit((PLC_X_CNT_ / 16) - 1, 15) As Short

    Public Const PLC_Y_CNT_ = 4176  '2656  '1056  '1046      '0123456789ABCDEF
    Public PlcData_Y((PLC_Y_CNT_ / 16) - 1) As Short
    Public PlcData_Y_bit((PLC_Y_CNT_ / 16) - 1, 15) As Short

    Public Const PLC_F_CNT_ = 112   '100
    Public PlcData_F((PLC_F_CNT_ / 16) - 1) As Short
    Public PlcData_F_bit(PLC_F_CNT_ - 1) As Short

    Public Const PLC_D0_CNT_ = 212
    Public PlcData_D0(505521) As Short
    Public PlcData_D700(0) As Short
    Public PlcData_D800(0) As Short
    Public Const PLC_D900_CNT_ = 1105
    Public PlcData_D900(PLC_D900_CNT_ - 1) As Short
    Public PlcData_D8530(0) As Short
    Public PlcData_D8531(0) As Short
    Public Const PLC_D10401_CNT_ = 1603
    Public PlcData_D10401(PLC_D10401_CNT_ - 1) As Short
    Public Const PLC_D30450_CNT_ = 101
    Public PlcData_D30450(PLC_D30450_CNT_ - 1) As Short
    Public Const PLC_D50450_CNT_ = 102
    Public PlcData_D50450(PLC_D50450_CNT_ - 1) As Short

    Public Const PLC_ZR_CNT_ = 122
    Public PlcData_ZR(PLC_ZR_CNT_ - 1) As Short

    Public PlcData_M6(0) As Short
    Public Const PLC_Step_CNT_ = 20
    Public Const PLC_Step_Complete_ = 21

    Public Const Temp_of_10sec_Ref_ = 0.1666    ''60초 : 1도 = 10초 : ?도
    Public AutoStatFlag As Boolean
    Public UP35A_PV_Chk_Time As Integer
    Public UP35A_PV_Chk_TimeStep As Integer
    Public Temp_Limit_10Sec As Double
    Public Temp_Deviation As Double
    Public Temp_Deviation1 As Double
    Public Temp_1_2_Deviation As Double
    'Public UP35A_PV_Chk_Time_Per_Min As Integer
    Public UP35A_PV_interval As Integer
    Public UP35A_Temp_Control_Start_Flag As Boolean
    Public UP35A_temp_old As Short
    Public UP35A_temp_old1 As Short
    Public UP35A_temp As Short
    Public UP35A_temp1 As Short
    Public UP35A_RunStop As Short
    Public UP35A_RunStop1 As Short
    Public UP35A_TSP As Short       'Target Set Point (SV)
    Public UP35A_TSP1 As Short
    Public UP35A_TSP_Time As Short
    Public UP35A_TSP_Time1 As Short
    Public UP35A_DualRunChkTime As Integer
    Public UP35A_DualRunChkFlag As Integer
    Public Chart1Count As Long
    Public Chart2Count As Long
    Public Temp_Reading_Count As Long
    Public TM4_temp(120) As Short
    Public Heater_PVIndex_CntChk As Integer
    Public Const TM4_1GroupCnt_ = 60
    Public Const HeaterCNT_ = 119   '60   ' 119

    Public Chart1Data(100, 5000) As Single  '(히터번호, 온도데이타)
    Public Chart2Data(20, 5000) As Single   '(히터번호, 온도데이타)


    Public WorkOderData(239) As Short
    Public WorkOderSVData(59) As Short
    Public WorkRunData(5) As Short
    Public LoadCellData(5) As Short
    Public Stacker_Path_Data(5) As Short

    '**** Work Status
    Public WorkStatus As Byte
    Public Const INITIAL_ As Short = 1
    Public Const AUTOMODE_ As Short = 2
    Public Const MANUALMODE_ As Short = 3
    Public Const CuttingModeTest_ = 4

    Public Const RUN_ As Short = 10
    Public Const STOP_ As Short = 11
    Public Const PAUSE_ As Short = 12
    Public Const ERROR_ As Short = 13
    Public Const RESET_ As Short = 14
    Public Const EndProgram_ As Short = 15
    Public Const CYCLE_ As Short = 16
    Public Const CYCLE_END_ As Short = 17

    Public Modelindex As Integer

    '**** MES
    Public MesConnectStart As Boolean
    Public MesConnectEnd As Boolean
    Public MES_ReceiveChk As Boolean
    Public ReceiveChkTime As Integer
    Public HeartChk As Boolean
    Public HeartChkTime As Integer

    Public DB_Updating_Flag As Boolean
    Public DB_Conn_OK As Boolean
    Public DB_Updating_Flag1 As Boolean
    Public DB_Conn_OK1 As Boolean


    Structure typeEQValini
        Dim numTempDeviation As String
        Dim UP35A_Com_Port As String       '** 온도 컨트롤러 1Group (485)
        Dim UP35A_Com_Set As String
        Dim UP35A_SV As String
        Dim UP35A_SV_Time As String
        Dim UP35A1_Com_Port As String      '** 온도 컨트롤러 2Group (485)
        Dim UP35A1_Com_Set As String
        Dim UP35A1_SV As String
        Dim UP35A1_SV_Time As String
    End Structure
    Structure typePosition_OLD_Val
        Dim inLet As String
        Dim inStacker As String
        Dim OutStacker As String
        Dim Buffer_1 As String
        Dim Buffer_2 As String
        Dim Buffer_3 As String
        Dim Buffer_4 As String
        Dim Buffer_5 As String
        Dim Buffer_6 As String
        Dim Work_1 As String
        Dim Work_2 As String
        Dim Work_3 As String
        Dim Work_4 As String
        Dim Work_5 As String
        Dim Work_6 As String
        Dim ByPass_1 As String
        Dim ByPass_2 As String
        Dim ByPass_3 As String
        Dim OutLet_1 As String
        Dim OutLet_2 As String
        Dim OutLet_3 As String
        Dim OutLet_4 As String
        Dim OutLet_5 As String
        Dim OutLet_6 As String

    End Structure

    Structure typeTempOffset
        Dim TempCNT As Integer
        Dim tOffset() As Integer

    End Structure

    Public Structure WorkDataList
        Dim StepCNT As String
        Dim ZR(,) As String
        'Dim ZR() As String

        'Dim RecipeName As String
        'Dim Plasma_MFC_Sccm As String
        'Dim BSP_MFC_Sccm As String
        'Dim Chamber_Hi_Vacuum_Pressure As String
        'Dim Chamber_Hi_Vacuum_Pressure_Square As String
        'Dim Chamber_Low_Vacuum_Pressure As String
        'Dim Chamber_Low_Vacuum_Pressure_Square As String
        'Dim Chamber_Slow_Rough_OK_Pressure As String
        'Dim Chamber_Slow_Rough_OK_Pressure_Square As String
        'Dim Line_Vacuum_OK_Pressure As String
        'Dim Line_Vacuum_OK_Pressure_Square As String
        'Dim DC_Power_Output_Voltage As String
        'Dim RF_Power_Set_Point As String
        'Dim Baraton_Gauge_Pressure As String
        'Dim Auto_DC_Power_On_Delay As String   '(Gas Flow)
        'Dim DC_Power_ONLY_USE As String
        'Dim DC_Power_ONLY_USE_TIME As String
        'Dim Auto_5Sccm_Ar_Gas_Flow_Delay As String
        'Dim Auto_200Sccm_Ar_Gas_Flow_Delay As String
        'Dim Auto_RF_Power_On_Delay As String
        'Dim Auto_RF_Power_Off_Check_Delay As String
        'Dim Auto_200_Sccm_Ar_Gas_Flow_Off_Check_Delay As String
        'Dim Auto_5_Sccm_Ar_Gas_Flow_Off_Check_Delay As String
        'Dim DC_Power_Off_Delay As String
        'Dim Throttle_Valve_Pressure_CNT_Check_Delay As String

    End Structure

    Public WorkData As WorkDataList

    Public Structure CountDataList
        Dim Total As Double
        Dim Good As Double
        Dim Ng As Double
        Dim imsi02 As Double
        Dim Imsi03 As Double
    End Structure
    Public WorkCount As CountDataList


    Structure typeIni
        Dim tEQValIni As typeEQValini
        Dim tPosOldVal As typePosition_OLD_Val
        Dim tTempOffset As typeTempOffset
        'tCrtIni                     As typeCrtIni
    End Structure
    Public tIni As typeIni

    Public gPrgLive As Short = 1

    ' Password stuff
    Public gLastModelindex As Short
    Public gCurrentPassword As String = ""
    Public gOperatorPassword As String = ""
    Public gEngineerPassword As String = "Engineer"
    Public gAdministratorPassword As String = ""
    Public PassOk As Boolean



End Module
