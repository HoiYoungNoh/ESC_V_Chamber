<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cboModel = New System.Windows.Forms.ComboBox()
        Me.lblChamberRangeOver = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblBaratonGauge_PV = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.lblHi_Vacuum = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.lblLine_Vacuum = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.lblBSP_Pressure = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.lblBSP_MFC = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.lblPlasma_MFC = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.lblBSP_Pressure_Warning_Lamp = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.lblATM_CHECK_Lamp = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.lblBASE_PRESSURE_Lamp = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.lblLeak_Current_N = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.lblLeak_Current_P = New System.Windows.Forms.Label()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.lblDC_Power_PV = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.lblDC_Power_SV = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.lblRF_Power_Ref = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.lblRF_Power_Fwd = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.lblRF_Power_SV = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.lblTN = New System.Windows.Forms.Label()
        Me.lblLD = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblESC_MSG = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.lblESCStep = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblATM_MSG = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.lblATMStep = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStandby_MSG = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStandbyStep = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnManualValveEnable = New System.Windows.Forms.Button()
        Me.btnESC_PWR_Stop = New System.Windows.Forms.Button()
        Me.btnESC_PWR_Auto = New System.Windows.Forms.Button()
        Me.btnATMStop = New System.Windows.Forms.Button()
        Me.btnATM = New System.Windows.Forms.Button()
        Me.btnStandyStop = New System.Windows.Forms.Button()
        Me.btnStandy = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label182 = New System.Windows.Forms.Label()
        Me.Label181 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.numBSP_Pressure_Alarm_SV = New System.Windows.Forms.NumericUpDown()
        Me.numBSP_Pressure_Alarm_SV_Square = New System.Windows.Forms.NumericUpDown()
        Me.numDC_Power_SV1 = New System.Windows.Forms.NumericUpDown()
        Me.numRF_Power_SV1 = New System.Windows.Forms.NumericUpDown()
        Me.numMFC2_SV = New System.Windows.Forms.NumericUpDown()
        Me.numMFC1_SV = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.panValve = New System.Windows.Forms.Panel()
        Me.grpValve = New System.Windows.Forms.GroupBox()
        Me.btnValvePannelClose = New System.Windows.Forms.Button()
        Me.grpBaratonGauge = New System.Windows.Forms.GroupBox()
        Me.numBaratonGauge_SV = New System.Windows.Forms.NumericUpDown()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.btnBaratonGaugeSV_Change = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblBaratonGauge_PV1 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblThrottleValve_Position_PV = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.btnThrottleValve_PositionMove = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblPressureinterlock_Lamp = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblCloseinterlock_Lamp = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblOpeninterlock_Lamp = New System.Windows.Forms.Label()
        Me.btnValveClose = New System.Windows.Forms.Button()
        Me.btnValveOpen = New System.Windows.Forms.Button()
        Me.grpManualPowerSupply = New System.Windows.Forms.GroupBox()
        Me.numPowerSupply_SV = New System.Windows.Forms.NumericUpDown()
        Me.lblPowerSupply_PV = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.panManual_ESC_Step = New System.Windows.Forms.Panel()
        Me.lblESC_MSG1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblESCStep1 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.lblBSP_Pressure_Warning_Lamp1 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.lblHi_Vacuum1 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.lblLine_Vacuum1 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.lblBSP_Pressure1 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lblBSP_Pressure2 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnManualValveEnable1 = New System.Windows.Forms.Button()
        Me.btnESC_PWR_Stop1 = New System.Windows.Forms.Button()
        Me.btnESC_PWR_Auto1 = New System.Windows.Forms.Button()
        Me.btnATMStop1 = New System.Windows.Forms.Button()
        Me.btnATM1 = New System.Windows.Forms.Button()
        Me.btnStandyStop1 = New System.Windows.Forms.Button()
        Me.btnStandy1 = New System.Windows.Forms.Button()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.lblLeak_Current_N1 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblLeak_Current_P1 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblDC_Power_Keysight = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblDC_Power_PV1 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnDCPWR_HV_OFF = New System.Windows.Forms.Button()
        Me.btnDCPWR_HV_ON = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblRF_Power_Ref1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblRF_Power_Fwd1 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblTN1 = New System.Windows.Forms.Label()
        Me.lblLD1 = New System.Windows.Forms.Label()
        Me.btnSV_Change = New System.Windows.Forms.Button()
        Me.btnRFOFF = New System.Windows.Forms.Button()
        Me.btnRFON = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numDry_Off_Delay_SV = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblDry_Off_Delay_PV = New System.Windows.Forms.Label()
        Me.picDry21___Y132_4 = New System.Windows.Forms.PictureBox()
        Me.picDry21_Y132_4 = New System.Windows.Forms.PictureBox()
        Me.picDry21__Y132_4 = New System.Windows.Forms.PictureBox()
        Me.btnDRY_Pump_Off = New System.Windows.Forms.Button()
        Me.picDry1_Y136 = New System.Windows.Forms.PictureBox()
        Me.picDry1__Y136 = New System.Windows.Forms.PictureBox()
        Me.picDry1__X14D = New System.Windows.Forms.PictureBox()
        Me.picDry1_T_X14D = New System.Windows.Forms.PictureBox()
        Me.picDry1_X14D = New System.Windows.Forms.PictureBox()
        Me.picDry1_VV_Y136 = New System.Windows.Forms.PictureBox()
        Me.btnTMP_OFF = New System.Windows.Forms.Button()
        Me.btnThrottle_Valve = New System.Windows.Forms.Button()
        Me.btnGate_Valve = New System.Windows.Forms.Button()
        Me.picDry2_X14D = New System.Windows.Forms.PictureBox()
        Me.picDry21___X14D = New System.Windows.Forms.PictureBox()
        Me.picDry2_T_X14D = New System.Windows.Forms.PictureBox()
        Me.picDry21__X14D = New System.Windows.Forms.PictureBox()
        Me.picDry22_X14D = New System.Windows.Forms.PictureBox()
        Me.picDry21_X14D = New System.Windows.Forms.PictureBox()
        Me.picDry22_Y132_4 = New System.Windows.Forms.PictureBox()
        Me.picDry2_T_Y132_4 = New System.Windows.Forms.PictureBox()
        Me.picDry21_VV_Y132 = New System.Windows.Forms.PictureBox()
        Me.picDry22_VV_Y134 = New System.Windows.Forms.PictureBox()
        Me.picDry2_Y132_4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.picAr2____Y130 = New System.Windows.Forms.PictureBox()
        Me.picN2_Y130 = New System.Windows.Forms.PictureBox()
        Me.picN2__Y128 = New System.Windows.Forms.PictureBox()
        Me.picAr2___Y130 = New System.Windows.Forms.PictureBox()
        Me.picAr2__Y130 = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.picAr2__X106 = New System.Windows.Forms.PictureBox()
        Me.picAr2___X106 = New System.Windows.Forms.PictureBox()
        Me.picAr1__X106 = New System.Windows.Forms.PictureBox()
        Me.picAr2_Y130 = New System.Windows.Forms.PictureBox()
        Me.picAr2_VV1_Y130 = New System.Windows.Forms.PictureBox()
        Me.picN2_VV_Y15C = New System.Windows.Forms.PictureBox()
        Me.lblMFC2_PV = New System.Windows.Forms.Label()
        Me.picAr2_T_X106 = New System.Windows.Forms.PictureBox()
        Me.picAr2_VV_Y12E = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.picAr2_X106 = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.picAr1_VV1_Y12C = New System.Windows.Forms.PictureBox()
        Me.lblMFC1_PV = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.picAr1_T_X106 = New System.Windows.Forms.PictureBox()
        Me.picAr1__Y12C = New System.Windows.Forms.PictureBox()
        Me.picAr1_VV_Y12A = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.picAr1_X106 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblThrottleValve_DataRD_Pressure = New System.Windows.Forms.Label()
        Me.lblChamberRangeOver1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.picN2_Y128 = New System.Windows.Forms.PictureBox()
        Me.picN2_VV_Y128 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picN2_X105 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.pan_DC_RF = New System.Windows.Forms.Panel()
        Me.lblDC_RF = New System.Windows.Forms.Label()
        Me.lblOnly_DC = New System.Windows.Forms.Label()
        Me.numStepCNT = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDataSave = New System.Windows.Forms.Button()
        Me.TxtModelName = New System.Windows.Forms.TextBox()
        Me.butInPutModelName = New System.Windows.Forms.Button()
        Me.butDelModel = New System.Windows.Forms.Button()
        Me.LstModel = New System.Windows.Forms.ListBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lst_Alarm = New System.Windows.Forms.ListBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.numTempDeviation = New System.Windows.Forms.NumericUpDown()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.numTagetTime2 = New System.Windows.Forms.NumericUpDown()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.numTagetTime1 = New System.Windows.Forms.NumericUpDown()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.btnTempSV_Save = New System.Windows.Forms.Button()
        Me.numTempSV2 = New System.Windows.Forms.NumericUpDown()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.numTempSV1 = New System.Windows.Forms.NumericUpDown()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.lblTemp2 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lblTemp1 = New System.Windows.Forms.Label()
        Me.btnHeaterOFF = New System.Windows.Forms.Button()
        Me.btnHeaterON = New System.Windows.Forms.Button()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.AxActUtlType1 = New AxActUtlTypeLib.AxActUtlType()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblCycleTime = New System.Windows.Forms.Label()
        Me.LblModel = New System.Windows.Forms.Label()
        Me.lblAutoSeq = New System.Windows.Forms.Label()
        Me.btnAlarmReset = New System.Windows.Forms.Button()
        Me.btnBuzzerStop = New System.Windows.Forms.Button()
        Me.tmrTemp = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.numBSP_Pressure_Alarm_SV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBSP_Pressure_Alarm_SV_Square, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDC_Power_SV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRF_Power_SV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMFC2_SV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMFC1_SV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panValve.SuspendLayout()
        Me.grpValve.SuspendLayout()
        Me.grpBaratonGauge.SuspendLayout()
        CType(Me.numBaratonGauge_SV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.grpManualPowerSupply.SuspendLayout()
        CType(Me.numPowerSupply_SV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panManual_ESC_Step.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numDry_Off_Delay_SV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21___Y132_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21_Y132_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21__Y132_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry1_Y136, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry1__Y136, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry1__X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry1_T_X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry1_X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry1_VV_Y136, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry2_X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21___X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry2_T_X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21__X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry22_X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21_X14D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry22_Y132_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry2_T_Y132_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry21_VV_Y132, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry22_VV_Y134, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDry2_Y132_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2____Y130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picN2_Y130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picN2__Y128, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2___Y130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2__Y130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2__X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2___X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr1__X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2_Y130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2_VV1_Y130, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picN2_VV_Y15C, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2_T_X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2_VV_Y12E, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr2_X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr1_VV1_Y12C, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr1_T_X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr1__Y12C, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr1_VV_Y12A, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAr1_X106, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picN2_Y128, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picN2_VV_Y128, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picN2_X105, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.pan_DC_RF.SuspendLayout()
        CType(Me.numStepCNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.numTempDeviation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTagetTime2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTagetTime1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTempSV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTempSV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxActUtlType1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(22, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ESC Vacuum Chamber"
        '
        'lblMessage
        '
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessage.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.White
        Me.lblMessage.Location = New System.Drawing.Point(15, 892)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(1037, 50)
        Me.lblMessage.TabIndex = 27
        Me.lblMessage.Text = "Message"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage3)
        Me.TabControl.Controls.Add(Me.TabPage4)
        Me.TabControl.Controls.Add(Me.TabPage5)
        Me.TabControl.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TabControl.Location = New System.Drawing.Point(15, 81)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1233, 791)
        Me.TabControl.TabIndex = 53
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.TabPage1.Controls.Add(Me.cboModel)
        Me.TabPage1.Controls.Add(Me.lblChamberRangeOver)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.lblBaratonGauge_PV)
        Me.TabPage1.Controls.Add(Me.Label111)
        Me.TabPage1.Controls.Add(Me.Label112)
        Me.TabPage1.Controls.Add(Me.lblHi_Vacuum)
        Me.TabPage1.Controls.Add(Me.Label114)
        Me.TabPage1.Controls.Add(Me.Label115)
        Me.TabPage1.Controls.Add(Me.lblLine_Vacuum)
        Me.TabPage1.Controls.Add(Me.Label117)
        Me.TabPage1.Controls.Add(Me.Label118)
        Me.TabPage1.Controls.Add(Me.lblBSP_Pressure)
        Me.TabPage1.Controls.Add(Me.Label105)
        Me.TabPage1.Controls.Add(Me.lblBSP_MFC)
        Me.TabPage1.Controls.Add(Me.Label107)
        Me.TabPage1.Controls.Add(Me.Label108)
        Me.TabPage1.Controls.Add(Me.lblPlasma_MFC)
        Me.TabPage1.Controls.Add(Me.Label110)
        Me.TabPage1.Controls.Add(Me.Label103)
        Me.TabPage1.Controls.Add(Me.Label101)
        Me.TabPage1.Controls.Add(Me.lblBSP_Pressure_Warning_Lamp)
        Me.TabPage1.Controls.Add(Me.Label99)
        Me.TabPage1.Controls.Add(Me.lblATM_CHECK_Lamp)
        Me.TabPage1.Controls.Add(Me.Label98)
        Me.TabPage1.Controls.Add(Me.lblBASE_PRESSURE_Lamp)
        Me.TabPage1.Controls.Add(Me.Label94)
        Me.TabPage1.Controls.Add(Me.lblLeak_Current_N)
        Me.TabPage1.Controls.Add(Me.Label96)
        Me.TabPage1.Controls.Add(Me.Label91)
        Me.TabPage1.Controls.Add(Me.lblLeak_Current_P)
        Me.TabPage1.Controls.Add(Me.Label93)
        Me.TabPage1.Controls.Add(Me.Label88)
        Me.TabPage1.Controls.Add(Me.lblDC_Power_PV)
        Me.TabPage1.Controls.Add(Me.Label90)
        Me.TabPage1.Controls.Add(Me.Label86)
        Me.TabPage1.Controls.Add(Me.lblDC_Power_SV)
        Me.TabPage1.Controls.Add(Me.Label85)
        Me.TabPage1.Controls.Add(Me.Label82)
        Me.TabPage1.Controls.Add(Me.lblRF_Power_Ref)
        Me.TabPage1.Controls.Add(Me.Label84)
        Me.TabPage1.Controls.Add(Me.Label79)
        Me.TabPage1.Controls.Add(Me.lblRF_Power_Fwd)
        Me.TabPage1.Controls.Add(Me.Label81)
        Me.TabPage1.Controls.Add(Me.Label78)
        Me.TabPage1.Controls.Add(Me.lblRF_Power_SV)
        Me.TabPage1.Controls.Add(Me.Label77)
        Me.TabPage1.Controls.Add(Me.lblTN)
        Me.TabPage1.Controls.Add(Me.lblLD)
        Me.TabPage1.Controls.Add(Me.Label73)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label182)
        Me.TabPage1.Controls.Add(Me.Label181)
        Me.TabPage1.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1225, 756)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "MAIN"
        '
        'cboModel
        '
        Me.cboModel.FormattingEnabled = True
        Me.cboModel.Location = New System.Drawing.Point(898, 347)
        Me.cboModel.Name = "cboModel"
        Me.cboModel.Size = New System.Drawing.Size(306, 29)
        Me.cboModel.TabIndex = 221
        '
        'lblChamberRangeOver
        '
        Me.lblChamberRangeOver.BackColor = System.Drawing.Color.White
        Me.lblChamberRangeOver.Font = New System.Drawing.Font("굴림", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblChamberRangeOver.ForeColor = System.Drawing.Color.Black
        Me.lblChamberRangeOver.Location = New System.Drawing.Point(919, 432)
        Me.lblChamberRangeOver.Name = "lblChamberRangeOver"
        Me.lblChamberRangeOver.Size = New System.Drawing.Size(141, 28)
        Me.lblChamberRangeOver.TabIndex = 202
        Me.lblChamberRangeOver.Text = "Range Over"
        Me.lblChamberRangeOver.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(806, 447)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 19)
        Me.Label7.TabIndex = 219
        Me.Label7.Text = "Torr"
        '
        'lblBaratonGauge_PV
        '
        Me.lblBaratonGauge_PV.BackColor = System.Drawing.Color.White
        Me.lblBaratonGauge_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBaratonGauge_PV.ForeColor = System.Drawing.Color.Black
        Me.lblBaratonGauge_PV.Location = New System.Drawing.Point(741, 441)
        Me.lblBaratonGauge_PV.Name = "lblBaratonGauge_PV"
        Me.lblBaratonGauge_PV.Size = New System.Drawing.Size(64, 27)
        Me.lblBaratonGauge_PV.TabIndex = 218
        Me.lblBaratonGauge_PV.Text = "12345"
        Me.lblBaratonGauge_PV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.White
        Me.Label111.Location = New System.Drawing.Point(990, 688)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(46, 19)
        Me.Label111.TabIndex = 217
        Me.Label111.Text = "Torr"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label112.ForeColor = System.Drawing.Color.White
        Me.Label112.Location = New System.Drawing.Point(619, 669)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(142, 38)
        Me.Label112.TabIndex = 216
        Me.Label112.Text = "Hi Vacuum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "전대역-GUAGE"
        '
        'lblHi_Vacuum
        '
        Me.lblHi_Vacuum.AutoSize = True
        Me.lblHi_Vacuum.BackColor = System.Drawing.Color.DimGray
        Me.lblHi_Vacuum.Font = New System.Drawing.Font("굴림", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblHi_Vacuum.ForeColor = System.Drawing.Color.Yellow
        Me.lblHi_Vacuum.Location = New System.Drawing.Point(758, 674)
        Me.lblHi_Vacuum.Name = "lblHi_Vacuum"
        Me.lblHi_Vacuum.Size = New System.Drawing.Size(226, 35)
        Me.lblHi_Vacuum.TabIndex = 215
        Me.lblHi_Vacuum.Text = "1.2 X10 -12"
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.White
        Me.Label114.Location = New System.Drawing.Point(990, 626)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(46, 19)
        Me.Label114.TabIndex = 214
        Me.Label114.Text = "Torr"
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label115.ForeColor = System.Drawing.Color.White
        Me.Label115.Location = New System.Drawing.Point(619, 607)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(124, 38)
        Me.Label115.TabIndex = 213
        Me.Label115.Text = "Line Vacuum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LINE-GUAGE"
        '
        'lblLine_Vacuum
        '
        Me.lblLine_Vacuum.AutoSize = True
        Me.lblLine_Vacuum.BackColor = System.Drawing.Color.DimGray
        Me.lblLine_Vacuum.Font = New System.Drawing.Font("굴림", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLine_Vacuum.ForeColor = System.Drawing.Color.Yellow
        Me.lblLine_Vacuum.Location = New System.Drawing.Point(758, 612)
        Me.lblLine_Vacuum.Name = "lblLine_Vacuum"
        Me.lblLine_Vacuum.Size = New System.Drawing.Size(226, 35)
        Me.lblLine_Vacuum.TabIndex = 212
        Me.lblLine_Vacuum.Text = "1.2 X10 -12"
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label117.ForeColor = System.Drawing.Color.White
        Me.Label117.Location = New System.Drawing.Point(990, 565)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(46, 19)
        Me.Label117.TabIndex = 211
        Me.Label117.Text = "Torr"
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label118.ForeColor = System.Drawing.Color.White
        Me.Label118.Location = New System.Drawing.Point(619, 546)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(133, 38)
        Me.Label118.TabIndex = 210
        Me.Label118.Text = "BSP Pressure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GUAGE"
        '
        'lblBSP_Pressure
        '
        Me.lblBSP_Pressure.AutoSize = True
        Me.lblBSP_Pressure.BackColor = System.Drawing.Color.DimGray
        Me.lblBSP_Pressure.Font = New System.Drawing.Font("굴림", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBSP_Pressure.ForeColor = System.Drawing.Color.Yellow
        Me.lblBSP_Pressure.Location = New System.Drawing.Point(758, 551)
        Me.lblBSP_Pressure.Name = "lblBSP_Pressure"
        Me.lblBSP_Pressure.Size = New System.Drawing.Size(226, 35)
        Me.lblBSP_Pressure.TabIndex = 209
        Me.lblBSP_Pressure.Text = "1.2 X10 -12"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label105.ForeColor = System.Drawing.Color.White
        Me.Label105.Location = New System.Drawing.Point(806, 498)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(59, 19)
        Me.Label105.TabIndex = 208
        Me.Label105.Text = "Sccm"
        '
        'lblBSP_MFC
        '
        Me.lblBSP_MFC.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBSP_MFC.ForeColor = System.Drawing.Color.Yellow
        Me.lblBSP_MFC.Location = New System.Drawing.Point(756, 498)
        Me.lblBSP_MFC.Name = "lblBSP_MFC"
        Me.lblBSP_MFC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblBSP_MFC.Size = New System.Drawing.Size(53, 19)
        Me.lblBSP_MFC.TabIndex = 207
        Me.lblBSP_MFC.Text = "1234"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label107.ForeColor = System.Drawing.Color.White
        Me.Label107.Location = New System.Drawing.Point(619, 498)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(91, 19)
        Me.Label107.TabIndex = 206
        Me.Label107.Text = "BSP MFC"
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label108.ForeColor = System.Drawing.Color.White
        Me.Label108.Location = New System.Drawing.Point(806, 473)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(59, 19)
        Me.Label108.TabIndex = 205
        Me.Label108.Text = "Sccm"
        '
        'lblPlasma_MFC
        '
        Me.lblPlasma_MFC.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPlasma_MFC.ForeColor = System.Drawing.Color.Yellow
        Me.lblPlasma_MFC.Location = New System.Drawing.Point(756, 473)
        Me.lblPlasma_MFC.Name = "lblPlasma_MFC"
        Me.lblPlasma_MFC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPlasma_MFC.Size = New System.Drawing.Size(53, 19)
        Me.lblPlasma_MFC.TabIndex = 204
        Me.lblPlasma_MFC.Text = "1234"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.White
        Me.Label110.Location = New System.Drawing.Point(619, 473)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(120, 19)
        Me.Label110.TabIndex = 203
        Me.Label110.Text = "Plasma MFC"
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.White
        Me.Label103.Location = New System.Drawing.Point(621, 441)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(86, 19)
        Me.Label103.TabIndex = 201
        Me.Label103.Text = "Baratron"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.White
        Me.Label101.Location = New System.Drawing.Point(647, 402)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(211, 19)
        Me.Label101.TabIndex = 200
        Me.Label101.Text = "BSP Pressure Warning"
        '
        'lblBSP_Pressure_Warning_Lamp
        '
        Me.lblBSP_Pressure_Warning_Lamp.AutoSize = True
        Me.lblBSP_Pressure_Warning_Lamp.BackColor = System.Drawing.Color.DarkRed
        Me.lblBSP_Pressure_Warning_Lamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBSP_Pressure_Warning_Lamp.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBSP_Pressure_Warning_Lamp.ForeColor = System.Drawing.Color.White
        Me.lblBSP_Pressure_Warning_Lamp.Location = New System.Drawing.Point(623, 400)
        Me.lblBSP_Pressure_Warning_Lamp.Name = "lblBSP_Pressure_Warning_Lamp"
        Me.lblBSP_Pressure_Warning_Lamp.Size = New System.Drawing.Size(18, 21)
        Me.lblBSP_Pressure_Warning_Lamp.TabIndex = 199
        Me.lblBSP_Pressure_Warning_Lamp.Text = " "
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.White
        Me.Label99.Location = New System.Drawing.Point(647, 377)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(118, 19)
        Me.Label99.TabIndex = 198
        Me.Label99.Text = "ATM CHECK"
        '
        'lblATM_CHECK_Lamp
        '
        Me.lblATM_CHECK_Lamp.AutoSize = True
        Me.lblATM_CHECK_Lamp.BackColor = System.Drawing.Color.DarkRed
        Me.lblATM_CHECK_Lamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblATM_CHECK_Lamp.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblATM_CHECK_Lamp.ForeColor = System.Drawing.Color.White
        Me.lblATM_CHECK_Lamp.Location = New System.Drawing.Point(623, 375)
        Me.lblATM_CHECK_Lamp.Name = "lblATM_CHECK_Lamp"
        Me.lblATM_CHECK_Lamp.Size = New System.Drawing.Size(18, 21)
        Me.lblATM_CHECK_Lamp.TabIndex = 197
        Me.lblATM_CHECK_Lamp.Text = " "
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.White
        Me.Label98.Location = New System.Drawing.Point(647, 352)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(161, 19)
        Me.Label98.TabIndex = 196
        Me.Label98.Text = "BASE PRESSURE"
        '
        'lblBASE_PRESSURE_Lamp
        '
        Me.lblBASE_PRESSURE_Lamp.AutoSize = True
        Me.lblBASE_PRESSURE_Lamp.BackColor = System.Drawing.Color.DarkRed
        Me.lblBASE_PRESSURE_Lamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBASE_PRESSURE_Lamp.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBASE_PRESSURE_Lamp.ForeColor = System.Drawing.Color.White
        Me.lblBASE_PRESSURE_Lamp.Location = New System.Drawing.Point(623, 350)
        Me.lblBASE_PRESSURE_Lamp.Name = "lblBASE_PRESSURE_Lamp"
        Me.lblBASE_PRESSURE_Lamp.Size = New System.Drawing.Size(18, 21)
        Me.lblBASE_PRESSURE_Lamp.TabIndex = 195
        Me.lblBASE_PRESSURE_Lamp.Text = " "
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label94.ForeColor = System.Drawing.Color.White
        Me.Label94.Location = New System.Drawing.Point(696, 310)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(33, 19)
        Me.Label94.TabIndex = 194
        Me.Label94.Text = "uA"
        '
        'lblLeak_Current_N
        '
        Me.lblLeak_Current_N.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLeak_Current_N.ForeColor = System.Drawing.Color.Yellow
        Me.lblLeak_Current_N.Location = New System.Drawing.Point(633, 310)
        Me.lblLeak_Current_N.Name = "lblLeak_Current_N"
        Me.lblLeak_Current_N.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLeak_Current_N.Size = New System.Drawing.Size(64, 19)
        Me.lblLeak_Current_N.TabIndex = 193
        Me.lblLeak_Current_N.Text = "12345"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label96.ForeColor = System.Drawing.Color.White
        Me.Label96.Location = New System.Drawing.Point(619, 286)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(141, 19)
        Me.Label96.TabIndex = 192
        Me.Label96.Text = "Leak Current -"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.White
        Me.Label91.Location = New System.Drawing.Point(696, 253)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(33, 19)
        Me.Label91.TabIndex = 191
        Me.Label91.Text = "uA"
        '
        'lblLeak_Current_P
        '
        Me.lblLeak_Current_P.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLeak_Current_P.ForeColor = System.Drawing.Color.Yellow
        Me.lblLeak_Current_P.Location = New System.Drawing.Point(633, 253)
        Me.lblLeak_Current_P.Name = "lblLeak_Current_P"
        Me.lblLeak_Current_P.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLeak_Current_P.Size = New System.Drawing.Size(64, 19)
        Me.lblLeak_Current_P.TabIndex = 190
        Me.lblLeak_Current_P.Text = "12345"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label93.ForeColor = System.Drawing.Color.White
        Me.Label93.Location = New System.Drawing.Point(619, 229)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(141, 19)
        Me.Label93.TabIndex = 189
        Me.Label93.Text = "Leak Current +"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.White
        Me.Label88.Location = New System.Drawing.Point(696, 197)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(43, 19)
        Me.Label88.TabIndex = 188
        Me.Label88.Text = "Vdc"
        '
        'lblDC_Power_PV
        '
        Me.lblDC_Power_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDC_Power_PV.ForeColor = System.Drawing.Color.Yellow
        Me.lblDC_Power_PV.Location = New System.Drawing.Point(633, 197)
        Me.lblDC_Power_PV.Name = "lblDC_Power_PV"
        Me.lblDC_Power_PV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDC_Power_PV.Size = New System.Drawing.Size(64, 19)
        Me.lblDC_Power_PV.TabIndex = 187
        Me.lblDC_Power_PV.Text = "12345"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.White
        Me.Label90.Location = New System.Drawing.Point(619, 173)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(173, 19)
        Me.Label90.TabIndex = 186
        Me.Label90.Text = "DC Power Monitor"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.White
        Me.Label86.Location = New System.Drawing.Point(696, 139)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(43, 19)
        Me.Label86.TabIndex = 185
        Me.Label86.Text = "Vdc"
        '
        'lblDC_Power_SV
        '
        Me.lblDC_Power_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDC_Power_SV.ForeColor = System.Drawing.Color.Yellow
        Me.lblDC_Power_SV.Location = New System.Drawing.Point(633, 139)
        Me.lblDC_Power_SV.Name = "lblDC_Power_SV"
        Me.lblDC_Power_SV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDC_Power_SV.Size = New System.Drawing.Size(64, 19)
        Me.lblDC_Power_SV.TabIndex = 184
        Me.lblDC_Power_SV.Text = "12345"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.White
        Me.Label85.Location = New System.Drawing.Point(619, 115)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(134, 19)
        Me.Label85.TabIndex = 183
        Me.Label85.Text = "DC Power Set"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.White
        Me.Label82.Location = New System.Drawing.Point(806, 77)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(25, 19)
        Me.Label82.TabIndex = 182
        Me.Label82.Text = "W"
        '
        'lblRF_Power_Ref
        '
        Me.lblRF_Power_Ref.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblRF_Power_Ref.ForeColor = System.Drawing.Color.Yellow
        Me.lblRF_Power_Ref.Location = New System.Drawing.Point(756, 77)
        Me.lblRF_Power_Ref.Name = "lblRF_Power_Ref"
        Me.lblRF_Power_Ref.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRF_Power_Ref.Size = New System.Drawing.Size(53, 19)
        Me.lblRF_Power_Ref.TabIndex = 181
        Me.lblRF_Power_Ref.Text = "1234"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label84.ForeColor = System.Drawing.Color.White
        Me.Label84.Location = New System.Drawing.Point(619, 77)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(131, 19)
        Me.Label84.TabIndex = 180
        Me.Label84.Text = "RF Power Ref"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.White
        Me.Label79.Location = New System.Drawing.Point(806, 52)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(25, 19)
        Me.Label79.TabIndex = 177
        Me.Label79.Text = "W"
        '
        'lblRF_Power_Fwd
        '
        Me.lblRF_Power_Fwd.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblRF_Power_Fwd.ForeColor = System.Drawing.Color.Yellow
        Me.lblRF_Power_Fwd.Location = New System.Drawing.Point(756, 52)
        Me.lblRF_Power_Fwd.Name = "lblRF_Power_Fwd"
        Me.lblRF_Power_Fwd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRF_Power_Fwd.Size = New System.Drawing.Size(53, 19)
        Me.lblRF_Power_Fwd.TabIndex = 176
        Me.lblRF_Power_Fwd.Text = "1234"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label81.ForeColor = System.Drawing.Color.White
        Me.Label81.Location = New System.Drawing.Point(619, 52)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(138, 19)
        Me.Label81.TabIndex = 175
        Me.Label81.Text = "RF Power Fwd"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label78.ForeColor = System.Drawing.Color.White
        Me.Label78.Location = New System.Drawing.Point(806, 27)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(25, 19)
        Me.Label78.TabIndex = 174
        Me.Label78.Text = "W"
        '
        'lblRF_Power_SV
        '
        Me.lblRF_Power_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblRF_Power_SV.ForeColor = System.Drawing.Color.Yellow
        Me.lblRF_Power_SV.Location = New System.Drawing.Point(756, 27)
        Me.lblRF_Power_SV.Name = "lblRF_Power_SV"
        Me.lblRF_Power_SV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRF_Power_SV.Size = New System.Drawing.Size(53, 19)
        Me.lblRF_Power_SV.TabIndex = 173
        Me.lblRF_Power_SV.Text = "1234"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.White
        Me.Label77.Location = New System.Drawing.Point(619, 27)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(131, 19)
        Me.Label77.TabIndex = 172
        Me.Label77.Text = "RF Power Set"
        '
        'lblTN
        '
        Me.lblTN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTN.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTN.ForeColor = System.Drawing.Color.Yellow
        Me.lblTN.Location = New System.Drawing.Point(512, 52)
        Me.lblTN.Name = "lblTN"
        Me.lblTN.Size = New System.Drawing.Size(81, 19)
        Me.lblTN.TabIndex = 171
        Me.lblTN.Text = "ABCDEF"
        '
        'lblLD
        '
        Me.lblLD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLD.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLD.ForeColor = System.Drawing.Color.Yellow
        Me.lblLD.Location = New System.Drawing.Point(512, 27)
        Me.lblLD.Name = "lblLD"
        Me.lblLD.Size = New System.Drawing.Size(81, 19)
        Me.lblLD.TabIndex = 65
        Me.lblLD.Text = "ABCDEF"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.White
        Me.Label73.Location = New System.Drawing.Point(474, 52)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(33, 19)
        Me.Label73.TabIndex = 170
        Me.Label73.Text = "TN"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblESC_MSG)
        Me.Panel3.Controls.Add(Me.Label71)
        Me.Panel3.Controls.Add(Me.lblESCStep)
        Me.Panel3.Location = New System.Drawing.Point(12, 203)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(364, 82)
        Me.Panel3.TabIndex = 169
        '
        'lblESC_MSG
        '
        Me.lblESC_MSG.AutoSize = True
        Me.lblESC_MSG.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblESC_MSG.ForeColor = System.Drawing.Color.White
        Me.lblESC_MSG.Location = New System.Drawing.Point(13, 45)
        Me.lblESC_MSG.Name = "lblESC_MSG"
        Me.lblESC_MSG.Size = New System.Drawing.Size(339, 19)
        Me.lblESC_MSG.TabIndex = 64
        Me.lblESC_MSG.Text = "123456789012345678901234567890"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label71.ForeColor = System.Drawing.Color.White
        Me.Label71.Location = New System.Drawing.Point(13, 12)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(171, 19)
        Me.Label71.TabIndex = 61
        Me.Label71.Text = "ESC Power STEP."
        '
        'lblESCStep
        '
        Me.lblESCStep.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblESCStep.ForeColor = System.Drawing.Color.Yellow
        Me.lblESCStep.Location = New System.Drawing.Point(223, 12)
        Me.lblESCStep.Name = "lblESCStep"
        Me.lblESCStep.Size = New System.Drawing.Size(53, 19)
        Me.lblESCStep.TabIndex = 63
        Me.lblESCStep.Text = "1234"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblATM_MSG)
        Me.Panel2.Controls.Add(Me.Label68)
        Me.Panel2.Controls.Add(Me.lblATMStep)
        Me.Panel2.Location = New System.Drawing.Point(12, 115)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(364, 82)
        Me.Panel2.TabIndex = 168
        '
        'lblATM_MSG
        '
        Me.lblATM_MSG.AutoSize = True
        Me.lblATM_MSG.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblATM_MSG.ForeColor = System.Drawing.Color.White
        Me.lblATM_MSG.Location = New System.Drawing.Point(13, 45)
        Me.lblATM_MSG.Name = "lblATM_MSG"
        Me.lblATM_MSG.Size = New System.Drawing.Size(339, 19)
        Me.lblATM_MSG.TabIndex = 64
        Me.lblATM_MSG.Text = "123456789012345678901234567890"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.White
        Me.Label68.Location = New System.Drawing.Point(13, 12)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(197, 19)
        Me.Label68.TabIndex = 61
        Me.Label68.Text = "Chamber ATM STEP."
        '
        'lblATMStep
        '
        Me.lblATMStep.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblATMStep.ForeColor = System.Drawing.Color.Yellow
        Me.lblATMStep.Location = New System.Drawing.Point(223, 12)
        Me.lblATMStep.Name = "lblATMStep"
        Me.lblATMStep.Size = New System.Drawing.Size(53, 19)
        Me.lblATMStep.TabIndex = 63
        Me.lblATMStep.Text = "1234"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblStandby_MSG)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblStandbyStep)
        Me.Panel1.Location = New System.Drawing.Point(12, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(364, 82)
        Me.Panel1.TabIndex = 167
        '
        'lblStandby_MSG
        '
        Me.lblStandby_MSG.AutoSize = True
        Me.lblStandby_MSG.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblStandby_MSG.ForeColor = System.Drawing.Color.White
        Me.lblStandby_MSG.Location = New System.Drawing.Point(13, 45)
        Me.lblStandby_MSG.Name = "lblStandby_MSG"
        Me.lblStandby_MSG.Size = New System.Drawing.Size(339, 19)
        Me.lblStandby_MSG.TabIndex = 64
        Me.lblStandby_MSG.Text = "123456789012345678901234567890"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 19)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "STANDBY STEP."
        '
        'lblStandbyStep
        '
        Me.lblStandbyStep.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblStandbyStep.ForeColor = System.Drawing.Color.Yellow
        Me.lblStandbyStep.Location = New System.Drawing.Point(223, 12)
        Me.lblStandbyStep.Name = "lblStandbyStep"
        Me.lblStandbyStep.Size = New System.Drawing.Size(53, 19)
        Me.lblStandbyStep.TabIndex = 63
        Me.lblStandbyStep.Text = "1234"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnManualValveEnable)
        Me.GroupBox3.Controls.Add(Me.btnESC_PWR_Stop)
        Me.GroupBox3.Controls.Add(Me.btnESC_PWR_Auto)
        Me.GroupBox3.Controls.Add(Me.btnATMStop)
        Me.GroupBox3.Controls.Add(Me.btnATM)
        Me.GroupBox3.Controls.Add(Me.btnStandyStop)
        Me.GroupBox3.Controls.Add(Me.btnStandy)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(898, 27)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(306, 302)
        Me.GroupBox3.TabIndex = 166
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MENU"
        '
        'btnManualValveEnable
        '
        Me.btnManualValveEnable.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualValveEnable.ForeColor = System.Drawing.Color.Black
        Me.btnManualValveEnable.Location = New System.Drawing.Point(6, 224)
        Me.btnManualValveEnable.Name = "btnManualValveEnable"
        Me.btnManualValveEnable.Size = New System.Drawing.Size(294, 58)
        Me.btnManualValveEnable.TabIndex = 172
        Me.btnManualValveEnable.Text = "Manual Valve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enable"
        Me.btnManualValveEnable.UseVisualStyleBackColor = True
        '
        'btnESC_PWR_Stop
        '
        Me.btnESC_PWR_Stop.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnESC_PWR_Stop.ForeColor = System.Drawing.Color.Black
        Me.btnESC_PWR_Stop.Location = New System.Drawing.Point(155, 159)
        Me.btnESC_PWR_Stop.Name = "btnESC_PWR_Stop"
        Me.btnESC_PWR_Stop.Size = New System.Drawing.Size(145, 58)
        Me.btnESC_PWR_Stop.TabIndex = 171
        Me.btnESC_PWR_Stop.Text = "ESC PWR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop"
        Me.btnESC_PWR_Stop.UseVisualStyleBackColor = True
        '
        'btnESC_PWR_Auto
        '
        Me.btnESC_PWR_Auto.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnESC_PWR_Auto.ForeColor = System.Drawing.Color.Black
        Me.btnESC_PWR_Auto.Location = New System.Drawing.Point(6, 159)
        Me.btnESC_PWR_Auto.Name = "btnESC_PWR_Auto"
        Me.btnESC_PWR_Auto.Size = New System.Drawing.Size(145, 58)
        Me.btnESC_PWR_Auto.TabIndex = 170
        Me.btnESC_PWR_Auto.Text = "ESC PWR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AUTO"
        Me.btnESC_PWR_Auto.UseVisualStyleBackColor = True
        '
        'btnATMStop
        '
        Me.btnATMStop.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnATMStop.ForeColor = System.Drawing.Color.Black
        Me.btnATMStop.Location = New System.Drawing.Point(155, 95)
        Me.btnATMStop.Name = "btnATMStop"
        Me.btnATMStop.Size = New System.Drawing.Size(145, 58)
        Me.btnATMStop.TabIndex = 169
        Me.btnATMStop.Text = "ATM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop"
        Me.btnATMStop.UseVisualStyleBackColor = True
        '
        'btnATM
        '
        Me.btnATM.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnATM.ForeColor = System.Drawing.Color.Black
        Me.btnATM.Location = New System.Drawing.Point(6, 95)
        Me.btnATM.Name = "btnATM"
        Me.btnATM.Size = New System.Drawing.Size(145, 58)
        Me.btnATM.TabIndex = 168
        Me.btnATM.Text = "Chamber" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ATM"
        Me.btnATM.UseVisualStyleBackColor = True
        '
        'btnStandyStop
        '
        Me.btnStandyStop.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStandyStop.ForeColor = System.Drawing.Color.Black
        Me.btnStandyStop.Location = New System.Drawing.Point(155, 31)
        Me.btnStandyStop.Name = "btnStandyStop"
        Me.btnStandyStop.Size = New System.Drawing.Size(145, 58)
        Me.btnStandyStop.TabIndex = 167
        Me.btnStandyStop.Text = "Standby" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop"
        Me.btnStandyStop.UseVisualStyleBackColor = True
        '
        'btnStandy
        '
        Me.btnStandy.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStandy.ForeColor = System.Drawing.Color.Black
        Me.btnStandy.Location = New System.Drawing.Point(6, 31)
        Me.btnStandy.Name = "btnStandy"
        Me.btnStandy.Size = New System.Drawing.Size(145, 58)
        Me.btnStandy.TabIndex = 166
        Me.btnStandy.Text = "Chamber" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Standby"
        Me.btnStandy.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ESC_V_Chamber.My.Resources.Resources.Equip
        Me.PictureBox1.Location = New System.Drawing.Point(12, 297)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(419, 405)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 64
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(479, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 19)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "LD"
        '
        'Label182
        '
        Me.Label182.AutoSize = True
        Me.Label182.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label182.ForeColor = System.Drawing.Color.White
        Me.Label182.Location = New System.Drawing.Point(6, 375)
        Me.Label182.Name = "Label182"
        Me.Label182.Size = New System.Drawing.Size(0, 19)
        Me.Label182.TabIndex = 2
        '
        'Label181
        '
        Me.Label181.AutoSize = True
        Me.Label181.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label181.ForeColor = System.Drawing.Color.White
        Me.Label181.Location = New System.Drawing.Point(6, 16)
        Me.Label181.Name = "Label181"
        Me.Label181.Size = New System.Drawing.Size(0, 19)
        Me.Label181.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.Controls.Add(Me.numBSP_Pressure_Alarm_SV)
        Me.TabPage2.Controls.Add(Me.numBSP_Pressure_Alarm_SV_Square)
        Me.TabPage2.Controls.Add(Me.numDC_Power_SV1)
        Me.TabPage2.Controls.Add(Me.numRF_Power_SV1)
        Me.TabPage2.Controls.Add(Me.numMFC2_SV)
        Me.TabPage2.Controls.Add(Me.numMFC1_SV)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.panValve)
        Me.TabPage2.Controls.Add(Me.grpManualPowerSupply)
        Me.TabPage2.Controls.Add(Me.panManual_ESC_Step)
        Me.TabPage2.Controls.Add(Me.Label65)
        Me.TabPage2.Controls.Add(Me.lblBSP_Pressure_Warning_Lamp1)
        Me.TabPage2.Controls.Add(Me.Label61)
        Me.TabPage2.Controls.Add(Me.Label62)
        Me.TabPage2.Controls.Add(Me.lblHi_Vacuum1)
        Me.TabPage2.Controls.Add(Me.Label58)
        Me.TabPage2.Controls.Add(Me.Label59)
        Me.TabPage2.Controls.Add(Me.lblLine_Vacuum1)
        Me.TabPage2.Controls.Add(Me.Label55)
        Me.TabPage2.Controls.Add(Me.Label56)
        Me.TabPage2.Controls.Add(Me.lblBSP_Pressure1)
        Me.TabPage2.Controls.Add(Me.Label52)
        Me.TabPage2.Controls.Add(Me.Label53)
        Me.TabPage2.Controls.Add(Me.lblBSP_Pressure2)
        Me.TabPage2.Controls.Add(Me.Label51)
        Me.TabPage2.Controls.Add(Me.Label50)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.Label46)
        Me.TabPage2.Controls.Add(Me.lblLeak_Current_N1)
        Me.TabPage2.Controls.Add(Me.Label48)
        Me.TabPage2.Controls.Add(Me.Label43)
        Me.TabPage2.Controls.Add(Me.lblLeak_Current_P1)
        Me.TabPage2.Controls.Add(Me.Label45)
        Me.TabPage2.Controls.Add(Me.Label40)
        Me.TabPage2.Controls.Add(Me.lblDC_Power_Keysight)
        Me.TabPage2.Controls.Add(Me.Label42)
        Me.TabPage2.Controls.Add(Me.Label37)
        Me.TabPage2.Controls.Add(Me.lblDC_Power_PV1)
        Me.TabPage2.Controls.Add(Me.Label39)
        Me.TabPage2.Controls.Add(Me.Label34)
        Me.TabPage2.Controls.Add(Me.Label36)
        Me.TabPage2.Controls.Add(Me.btnDCPWR_HV_OFF)
        Me.TabPage2.Controls.Add(Me.btnDCPWR_HV_ON)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.lblRF_Power_Ref1)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.lblRF_Power_Fwd1)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.lblTN1)
        Me.TabPage2.Controls.Add(Me.lblLD1)
        Me.TabPage2.Controls.Add(Me.btnSV_Change)
        Me.TabPage2.Controls.Add(Me.btnRFOFF)
        Me.TabPage2.Controls.Add(Me.btnRFON)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.picDry21___Y132_4)
        Me.TabPage2.Controls.Add(Me.picDry21_Y132_4)
        Me.TabPage2.Controls.Add(Me.picDry21__Y132_4)
        Me.TabPage2.Controls.Add(Me.btnDRY_Pump_Off)
        Me.TabPage2.Controls.Add(Me.picDry1_Y136)
        Me.TabPage2.Controls.Add(Me.picDry1__Y136)
        Me.TabPage2.Controls.Add(Me.picDry1__X14D)
        Me.TabPage2.Controls.Add(Me.picDry1_T_X14D)
        Me.TabPage2.Controls.Add(Me.picDry1_X14D)
        Me.TabPage2.Controls.Add(Me.picDry1_VV_Y136)
        Me.TabPage2.Controls.Add(Me.btnTMP_OFF)
        Me.TabPage2.Controls.Add(Me.btnThrottle_Valve)
        Me.TabPage2.Controls.Add(Me.btnGate_Valve)
        Me.TabPage2.Controls.Add(Me.picDry2_X14D)
        Me.TabPage2.Controls.Add(Me.picDry21___X14D)
        Me.TabPage2.Controls.Add(Me.picDry2_T_X14D)
        Me.TabPage2.Controls.Add(Me.picDry21__X14D)
        Me.TabPage2.Controls.Add(Me.picDry22_X14D)
        Me.TabPage2.Controls.Add(Me.picDry21_X14D)
        Me.TabPage2.Controls.Add(Me.picDry22_Y132_4)
        Me.TabPage2.Controls.Add(Me.picDry2_T_Y132_4)
        Me.TabPage2.Controls.Add(Me.picDry21_VV_Y132)
        Me.TabPage2.Controls.Add(Me.picDry22_VV_Y134)
        Me.TabPage2.Controls.Add(Me.picDry2_Y132_4)
        Me.TabPage2.Controls.Add(Me.PictureBox18)
        Me.TabPage2.Controls.Add(Me.PictureBox17)
        Me.TabPage2.Controls.Add(Me.picAr2____Y130)
        Me.TabPage2.Controls.Add(Me.picN2_Y130)
        Me.TabPage2.Controls.Add(Me.picN2__Y128)
        Me.TabPage2.Controls.Add(Me.picAr2___Y130)
        Me.TabPage2.Controls.Add(Me.picAr2__Y130)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.picAr2__X106)
        Me.TabPage2.Controls.Add(Me.picAr2___X106)
        Me.TabPage2.Controls.Add(Me.picAr1__X106)
        Me.TabPage2.Controls.Add(Me.picAr2_Y130)
        Me.TabPage2.Controls.Add(Me.picAr2_VV1_Y130)
        Me.TabPage2.Controls.Add(Me.picN2_VV_Y15C)
        Me.TabPage2.Controls.Add(Me.lblMFC2_PV)
        Me.TabPage2.Controls.Add(Me.picAr2_T_X106)
        Me.TabPage2.Controls.Add(Me.picAr2_VV_Y12E)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.picAr2_X106)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.picAr1_VV1_Y12C)
        Me.TabPage2.Controls.Add(Me.lblMFC1_PV)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.picAr1_T_X106)
        Me.TabPage2.Controls.Add(Me.picAr1__Y12C)
        Me.TabPage2.Controls.Add(Me.picAr1_VV_Y12A)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.picAr1_X106)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.lblThrottleValve_DataRD_Pressure)
        Me.TabPage2.Controls.Add(Me.lblChamberRangeOver1)
        Me.TabPage2.Controls.Add(Me.PictureBox3)
        Me.TabPage2.Controls.Add(Me.picN2_Y128)
        Me.TabPage2.Controls.Add(Me.picN2_VV_Y128)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.picN2_X105)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(1225, 756)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "MANUAL"
        '
        'numBSP_Pressure_Alarm_SV
        '
        Me.numBSP_Pressure_Alarm_SV.BackColor = System.Drawing.Color.DarkGray
        Me.numBSP_Pressure_Alarm_SV.DecimalPlaces = 1
        Me.numBSP_Pressure_Alarm_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numBSP_Pressure_Alarm_SV.ForeColor = System.Drawing.Color.Yellow
        Me.numBSP_Pressure_Alarm_SV.Location = New System.Drawing.Point(997, 355)
        Me.numBSP_Pressure_Alarm_SV.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numBSP_Pressure_Alarm_SV.Name = "numBSP_Pressure_Alarm_SV"
        Me.numBSP_Pressure_Alarm_SV.Size = New System.Drawing.Size(63, 29)
        Me.numBSP_Pressure_Alarm_SV.TabIndex = 198
        Me.numBSP_Pressure_Alarm_SV.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'numBSP_Pressure_Alarm_SV_Square
        '
        Me.numBSP_Pressure_Alarm_SV_Square.BackColor = System.Drawing.Color.DarkGray
        Me.numBSP_Pressure_Alarm_SV_Square.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numBSP_Pressure_Alarm_SV_Square.ForeColor = System.Drawing.Color.Yellow
        Me.numBSP_Pressure_Alarm_SV_Square.Location = New System.Drawing.Point(1107, 355)
        Me.numBSP_Pressure_Alarm_SV_Square.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numBSP_Pressure_Alarm_SV_Square.Minimum = New Decimal(New Integer() {99, 0, 0, -2147483648})
        Me.numBSP_Pressure_Alarm_SV_Square.Name = "numBSP_Pressure_Alarm_SV_Square"
        Me.numBSP_Pressure_Alarm_SV_Square.Size = New System.Drawing.Size(54, 29)
        Me.numBSP_Pressure_Alarm_SV_Square.TabIndex = 199
        Me.numBSP_Pressure_Alarm_SV_Square.Value = New Decimal(New Integer() {12, 0, 0, -2147483648})
        '
        'numDC_Power_SV1
        '
        Me.numDC_Power_SV1.BackColor = System.Drawing.Color.DarkGray
        Me.numDC_Power_SV1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numDC_Power_SV1.ForeColor = System.Drawing.Color.Yellow
        Me.numDC_Power_SV1.Location = New System.Drawing.Point(216, 599)
        Me.numDC_Power_SV1.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numDC_Power_SV1.Name = "numDC_Power_SV1"
        Me.numDC_Power_SV1.Size = New System.Drawing.Size(86, 29)
        Me.numDC_Power_SV1.TabIndex = 197
        Me.numDC_Power_SV1.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'numRF_Power_SV1
        '
        Me.numRF_Power_SV1.BackColor = System.Drawing.Color.DarkGray
        Me.numRF_Power_SV1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numRF_Power_SV1.ForeColor = System.Drawing.Color.Yellow
        Me.numRF_Power_SV1.Location = New System.Drawing.Point(147, 432)
        Me.numRF_Power_SV1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numRF_Power_SV1.Name = "numRF_Power_SV1"
        Me.numRF_Power_SV1.Size = New System.Drawing.Size(68, 29)
        Me.numRF_Power_SV1.TabIndex = 196
        Me.numRF_Power_SV1.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'numMFC2_SV
        '
        Me.numMFC2_SV.BackColor = System.Drawing.Color.Lime
        Me.numMFC2_SV.DecimalPlaces = 1
        Me.numMFC2_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numMFC2_SV.Location = New System.Drawing.Point(268, 340)
        Me.numMFC2_SV.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numMFC2_SV.Name = "numMFC2_SV"
        Me.numMFC2_SV.Size = New System.Drawing.Size(68, 29)
        Me.numMFC2_SV.TabIndex = 195
        Me.numMFC2_SV.Value = New Decimal(New Integer() {12345, 0, 0, 0})
        '
        'numMFC1_SV
        '
        Me.numMFC1_SV.BackColor = System.Drawing.Color.Lime
        Me.numMFC1_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numMFC1_SV.Location = New System.Drawing.Point(268, 185)
        Me.numMFC1_SV.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numMFC1_SV.Name = "numMFC1_SV"
        Me.numMFC1_SV.Size = New System.Drawing.Size(68, 29)
        Me.numMFC1_SV.TabIndex = 194
        Me.numMFC1_SV.Value = New Decimal(New Integer() {12345, 0, 0, 0})
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DimGray
        Me.Label26.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Yellow
        Me.Label26.Location = New System.Drawing.Point(1062, 354)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 29)
        Me.Label26.TabIndex = 189
        Me.Label26.Text = "X10"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panValve
        '
        Me.panValve.BackColor = System.Drawing.Color.Gray
        Me.panValve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panValve.Controls.Add(Me.grpValve)
        Me.panValve.Location = New System.Drawing.Point(890, 695)
        Me.panValve.Name = "panValve"
        Me.panValve.Size = New System.Drawing.Size(405, 259)
        Me.panValve.TabIndex = 184
        Me.panValve.Visible = False
        '
        'grpValve
        '
        Me.grpValve.Controls.Add(Me.btnValvePannelClose)
        Me.grpValve.Controls.Add(Me.grpBaratonGauge)
        Me.grpValve.Controls.Add(Me.btnThrottleValve_PositionMove)
        Me.grpValve.Controls.Add(Me.GroupBox6)
        Me.grpValve.Controls.Add(Me.btnValveClose)
        Me.grpValve.Controls.Add(Me.btnValveOpen)
        Me.grpValve.Location = New System.Drawing.Point(3, 10)
        Me.grpValve.Name = "grpValve"
        Me.grpValve.Size = New System.Drawing.Size(393, 237)
        Me.grpValve.TabIndex = 3
        Me.grpValve.TabStop = False
        Me.grpValve.Text = "VALVE OPERATION"
        '
        'btnValvePannelClose
        '
        Me.btnValvePannelClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnValvePannelClose.Image = Global.ESC_V_Chamber.My.Resources.Resources.dismiss_contrast_white
        Me.btnValvePannelClose.Location = New System.Drawing.Point(346, 14)
        Me.btnValvePannelClose.Name = "btnValvePannelClose"
        Me.btnValvePannelClose.Size = New System.Drawing.Size(45, 43)
        Me.btnValvePannelClose.TabIndex = 186
        Me.btnValvePannelClose.UseVisualStyleBackColor = True
        '
        'grpBaratonGauge
        '
        Me.grpBaratonGauge.Controls.Add(Me.numBaratonGauge_SV)
        Me.grpBaratonGauge.Controls.Add(Me.Label47)
        Me.grpBaratonGauge.Controls.Add(Me.btnBaratonGaugeSV_Change)
        Me.grpBaratonGauge.Controls.Add(Me.Label41)
        Me.grpBaratonGauge.Controls.Add(Me.lblBaratonGauge_PV1)
        Me.grpBaratonGauge.Controls.Add(Me.Label38)
        Me.grpBaratonGauge.Controls.Add(Me.Label32)
        Me.grpBaratonGauge.Controls.Add(Me.lblThrottleValve_Position_PV)
        Me.grpBaratonGauge.Controls.Add(Me.Label29)
        Me.grpBaratonGauge.Location = New System.Drawing.Point(148, 28)
        Me.grpBaratonGauge.Name = "grpBaratonGauge"
        Me.grpBaratonGauge.Size = New System.Drawing.Size(239, 131)
        Me.grpBaratonGauge.TabIndex = 200
        Me.grpBaratonGauge.TabStop = False
        Me.grpBaratonGauge.Visible = False
        '
        'numBaratonGauge_SV
        '
        Me.numBaratonGauge_SV.BackColor = System.Drawing.Color.Lime
        Me.numBaratonGauge_SV.DecimalPlaces = 3
        Me.numBaratonGauge_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numBaratonGauge_SV.Location = New System.Drawing.Point(6, 98)
        Me.numBaratonGauge_SV.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numBaratonGauge_SV.Name = "numBaratonGauge_SV"
        Me.numBaratonGauge_SV.Size = New System.Drawing.Size(92, 29)
        Me.numBaratonGauge_SV.TabIndex = 201
        Me.numBaratonGauge_SV.Value = New Decimal(New Integer() {12345, 0, 0, 0})
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(5, 59)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(163, 19)
        Me.Label47.TabIndex = 198
        Me.Label47.Text = "PRESSURE (Torr)"
        '
        'btnBaratonGaugeSV_Change
        '
        Me.btnBaratonGaugeSV_Change.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBaratonGaugeSV_Change.Location = New System.Drawing.Point(169, 75)
        Me.btnBaratonGaugeSV_Change.Name = "btnBaratonGaugeSV_Change"
        Me.btnBaratonGaugeSV_Change.Size = New System.Drawing.Size(69, 52)
        Me.btnBaratonGaugeSV_Change.TabIndex = 199
        Me.btnBaratonGaugeSV_Change.Text = "SV" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Change"
        Me.btnBaratonGaugeSV_Change.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(99, 81)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(33, 19)
        Me.Label41.TabIndex = 197
        Me.Label41.Text = "PV"
        '
        'lblBaratonGauge_PV1
        '
        Me.lblBaratonGauge_PV1.BackColor = System.Drawing.Color.Yellow
        Me.lblBaratonGauge_PV1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBaratonGauge_PV1.ForeColor = System.Drawing.Color.Black
        Me.lblBaratonGauge_PV1.Location = New System.Drawing.Point(102, 100)
        Me.lblBaratonGauge_PV1.Name = "lblBaratonGauge_PV1"
        Me.lblBaratonGauge_PV1.Size = New System.Drawing.Size(64, 27)
        Me.lblBaratonGauge_PV1.TabIndex = 196
        Me.lblBaratonGauge_PV1.Text = "12345"
        Me.lblBaratonGauge_PV1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(15, 80)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(33, 19)
        Me.Label38.TabIndex = 194
        Me.Label38.Text = "SV"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(173, 22)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(24, 19)
        Me.Label32.TabIndex = 193
        Me.Label32.Text = "%"
        '
        'lblThrottleValve_Position_PV
        '
        Me.lblThrottleValve_Position_PV.BackColor = System.Drawing.Color.White
        Me.lblThrottleValve_Position_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblThrottleValve_Position_PV.ForeColor = System.Drawing.Color.Black
        Me.lblThrottleValve_Position_PV.Location = New System.Drawing.Point(101, 21)
        Me.lblThrottleValve_Position_PV.Name = "lblThrottleValve_Position_PV"
        Me.lblThrottleValve_Position_PV.Size = New System.Drawing.Size(73, 19)
        Me.lblThrottleValve_Position_PV.TabIndex = 192
        Me.lblThrottleValve_Position_PV.Text = "ABCDE"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(5, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 19)
        Me.Label29.TabIndex = 191
        Me.Label29.Text = "POSITION"
        '
        'btnThrottleValve_PositionMove
        '
        Me.btnThrottleValve_PositionMove.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnThrottleValve_PositionMove.Location = New System.Drawing.Point(261, 166)
        Me.btnThrottleValve_PositionMove.Name = "btnThrottleValve_PositionMove"
        Me.btnThrottleValve_PositionMove.Size = New System.Drawing.Size(122, 58)
        Me.btnThrottleValve_PositionMove.TabIndex = 190
        Me.btnThrottleValve_PositionMove.Text = "PRESSURE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SET MOVE"
        Me.btnThrottleValve_PositionMove.UseVisualStyleBackColor = True
        Me.btnThrottleValve_PositionMove.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.lblPressureinterlock_Lamp)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.lblCloseinterlock_Lamp)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.lblOpeninterlock_Lamp)
        Me.GroupBox6.ForeColor = System.Drawing.Color.White
        Me.GroupBox6.Location = New System.Drawing.Point(11, 28)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(133, 119)
        Me.GroupBox6.TabIndex = 189
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "interlock"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(40, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 19)
        Me.Label22.TabIndex = 188
        Me.Label22.Text = "Pressure"
        '
        'lblPressureinterlock_Lamp
        '
        Me.lblPressureinterlock_Lamp.AutoSize = True
        Me.lblPressureinterlock_Lamp.BackColor = System.Drawing.Color.DarkRed
        Me.lblPressureinterlock_Lamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPressureinterlock_Lamp.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPressureinterlock_Lamp.ForeColor = System.Drawing.Color.White
        Me.lblPressureinterlock_Lamp.Location = New System.Drawing.Point(22, 29)
        Me.lblPressureinterlock_Lamp.Name = "lblPressureinterlock_Lamp"
        Me.lblPressureinterlock_Lamp.Size = New System.Drawing.Size(18, 21)
        Me.lblPressureinterlock_Lamp.TabIndex = 187
        Me.lblPressureinterlock_Lamp.Text = " "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(40, 89)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 19)
        Me.Label21.TabIndex = 186
        Me.Label21.Text = "Close"
        '
        'lblCloseinterlock_Lamp
        '
        Me.lblCloseinterlock_Lamp.AutoSize = True
        Me.lblCloseinterlock_Lamp.BackColor = System.Drawing.Color.DarkRed
        Me.lblCloseinterlock_Lamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCloseinterlock_Lamp.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblCloseinterlock_Lamp.ForeColor = System.Drawing.Color.White
        Me.lblCloseinterlock_Lamp.Location = New System.Drawing.Point(22, 89)
        Me.lblCloseinterlock_Lamp.Name = "lblCloseinterlock_Lamp"
        Me.lblCloseinterlock_Lamp.Size = New System.Drawing.Size(18, 21)
        Me.lblCloseinterlock_Lamp.TabIndex = 185
        Me.lblCloseinterlock_Lamp.Text = " "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(40, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 19)
        Me.Label15.TabIndex = 184
        Me.Label15.Text = "Open"
        '
        'lblOpeninterlock_Lamp
        '
        Me.lblOpeninterlock_Lamp.AutoSize = True
        Me.lblOpeninterlock_Lamp.BackColor = System.Drawing.Color.DarkRed
        Me.lblOpeninterlock_Lamp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOpeninterlock_Lamp.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblOpeninterlock_Lamp.ForeColor = System.Drawing.Color.White
        Me.lblOpeninterlock_Lamp.Location = New System.Drawing.Point(22, 59)
        Me.lblOpeninterlock_Lamp.Name = "lblOpeninterlock_Lamp"
        Me.lblOpeninterlock_Lamp.Size = New System.Drawing.Size(18, 21)
        Me.lblOpeninterlock_Lamp.TabIndex = 183
        Me.lblOpeninterlock_Lamp.Text = " "
        '
        'btnValveClose
        '
        Me.btnValveClose.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnValveClose.Location = New System.Drawing.Point(129, 166)
        Me.btnValveClose.Name = "btnValveClose"
        Me.btnValveClose.Size = New System.Drawing.Size(122, 58)
        Me.btnValveClose.TabIndex = 2
        Me.btnValveClose.Text = "CLOSE"
        Me.btnValveClose.UseVisualStyleBackColor = True
        '
        'btnValveOpen
        '
        Me.btnValveOpen.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnValveOpen.Location = New System.Drawing.Point(11, 167)
        Me.btnValveOpen.Name = "btnValveOpen"
        Me.btnValveOpen.Size = New System.Drawing.Size(105, 56)
        Me.btnValveOpen.TabIndex = 1
        Me.btnValveOpen.Text = "OPEN"
        Me.btnValveOpen.UseVisualStyleBackColor = True
        '
        'grpManualPowerSupply
        '
        Me.grpManualPowerSupply.Controls.Add(Me.numPowerSupply_SV)
        Me.grpManualPowerSupply.Controls.Add(Me.lblPowerSupply_PV)
        Me.grpManualPowerSupply.Controls.Add(Me.Label4)
        Me.grpManualPowerSupply.Controls.Add(Me.Label19)
        Me.grpManualPowerSupply.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.grpManualPowerSupply.ForeColor = System.Drawing.Color.White
        Me.grpManualPowerSupply.Location = New System.Drawing.Point(434, 3)
        Me.grpManualPowerSupply.Name = "grpManualPowerSupply"
        Me.grpManualPowerSupply.Size = New System.Drawing.Size(225, 72)
        Me.grpManualPowerSupply.TabIndex = 134
        Me.grpManualPowerSupply.TabStop = False
        Me.grpManualPowerSupply.Visible = False
        '
        'numPowerSupply_SV
        '
        Me.numPowerSupply_SV.BackColor = System.Drawing.Color.Lime
        Me.numPowerSupply_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numPowerSupply_SV.Location = New System.Drawing.Point(6, 39)
        Me.numPowerSupply_SV.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numPowerSupply_SV.Name = "numPowerSupply_SV"
        Me.numPowerSupply_SV.Size = New System.Drawing.Size(92, 29)
        Me.numPowerSupply_SV.TabIndex = 196
        Me.numPowerSupply_SV.Value = New Decimal(New Integer() {123456, 0, 0, 0})
        '
        'lblPowerSupply_PV
        '
        Me.lblPowerSupply_PV.BackColor = System.Drawing.Color.Yellow
        Me.lblPowerSupply_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPowerSupply_PV.ForeColor = System.Drawing.Color.Black
        Me.lblPowerSupply_PV.Location = New System.Drawing.Point(123, 39)
        Me.lblPowerSupply_PV.Name = "lblPowerSupply_PV"
        Me.lblPowerSupply_PV.Size = New System.Drawing.Size(73, 29)
        Me.lblPowerSupply_PV.TabIndex = 132
        Me.lblPowerSupply_PV.Text = "123456"
        Me.lblPowerSupply_PV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(120, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 19)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "PV"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(20, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(33, 19)
        Me.Label19.TabIndex = 130
        Me.Label19.Text = "SV"
        '
        'panManual_ESC_Step
        '
        Me.panManual_ESC_Step.Controls.Add(Me.lblESC_MSG1)
        Me.panManual_ESC_Step.Controls.Add(Me.Label8)
        Me.panManual_ESC_Step.Controls.Add(Me.lblESCStep1)
        Me.panManual_ESC_Step.Location = New System.Drawing.Point(21, 6)
        Me.panManual_ESC_Step.Name = "panManual_ESC_Step"
        Me.panManual_ESC_Step.Size = New System.Drawing.Size(364, 57)
        Me.panManual_ESC_Step.TabIndex = 183
        Me.panManual_ESC_Step.Visible = False
        '
        'lblESC_MSG1
        '
        Me.lblESC_MSG1.AutoSize = True
        Me.lblESC_MSG1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblESC_MSG1.ForeColor = System.Drawing.Color.White
        Me.lblESC_MSG1.Location = New System.Drawing.Point(13, 32)
        Me.lblESC_MSG1.Name = "lblESC_MSG1"
        Me.lblESC_MSG1.Size = New System.Drawing.Size(339, 19)
        Me.lblESC_MSG1.TabIndex = 64
        Me.lblESC_MSG1.Text = "123456789012345678901234567890"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(13, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(171, 19)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "ESC Power STEP."
        '
        'lblESCStep1
        '
        Me.lblESCStep1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblESCStep1.ForeColor = System.Drawing.Color.Yellow
        Me.lblESCStep1.Location = New System.Drawing.Point(223, 4)
        Me.lblESCStep1.Name = "lblESCStep1"
        Me.lblESCStep1.Size = New System.Drawing.Size(53, 19)
        Me.lblESCStep1.TabIndex = 63
        Me.lblESCStep1.Text = "1234"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.White
        Me.Label65.Location = New System.Drawing.Point(988, 401)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(211, 19)
        Me.Label65.TabIndex = 182
        Me.Label65.Text = "BSP Pressure Warning"
        '
        'lblBSP_Pressure_Warning_Lamp1
        '
        Me.lblBSP_Pressure_Warning_Lamp1.AutoSize = True
        Me.lblBSP_Pressure_Warning_Lamp1.BackColor = System.Drawing.Color.DarkRed
        Me.lblBSP_Pressure_Warning_Lamp1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBSP_Pressure_Warning_Lamp1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBSP_Pressure_Warning_Lamp1.ForeColor = System.Drawing.Color.White
        Me.lblBSP_Pressure_Warning_Lamp1.Location = New System.Drawing.Point(970, 401)
        Me.lblBSP_Pressure_Warning_Lamp1.Name = "lblBSP_Pressure_Warning_Lamp1"
        Me.lblBSP_Pressure_Warning_Lamp1.Size = New System.Drawing.Size(18, 21)
        Me.lblBSP_Pressure_Warning_Lamp1.TabIndex = 181
        Me.lblBSP_Pressure_Warning_Lamp1.Text = " "
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(1158, 661)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(46, 19)
        Me.Label61.TabIndex = 180
        Me.Label61.Text = "Torr"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.White
        Me.Label62.Location = New System.Drawing.Point(886, 652)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(142, 38)
        Me.Label62.TabIndex = 179
        Me.Label62.Text = "Hi Vacuum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "전대역-GUAGE"
        '
        'lblHi_Vacuum1
        '
        Me.lblHi_Vacuum1.BackColor = System.Drawing.Color.DimGray
        Me.lblHi_Vacuum1.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblHi_Vacuum1.ForeColor = System.Drawing.Color.Yellow
        Me.lblHi_Vacuum1.Location = New System.Drawing.Point(1025, 657)
        Me.lblHi_Vacuum1.Name = "lblHi_Vacuum1"
        Me.lblHi_Vacuum1.Size = New System.Drawing.Size(132, 21)
        Me.lblHi_Vacuum1.TabIndex = 178
        Me.lblHi_Vacuum1.Text = "1.2 X10 -12"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.White
        Me.Label58.Location = New System.Drawing.Point(1158, 599)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(46, 19)
        Me.Label58.TabIndex = 177
        Me.Label58.Text = "Torr"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.White
        Me.Label59.Location = New System.Drawing.Point(886, 590)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(124, 38)
        Me.Label59.TabIndex = 176
        Me.Label59.Text = "Line Vacuum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LINE-GUAGE"
        '
        'lblLine_Vacuum1
        '
        Me.lblLine_Vacuum1.BackColor = System.Drawing.Color.DimGray
        Me.lblLine_Vacuum1.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLine_Vacuum1.ForeColor = System.Drawing.Color.Yellow
        Me.lblLine_Vacuum1.Location = New System.Drawing.Point(1025, 595)
        Me.lblLine_Vacuum1.Name = "lblLine_Vacuum1"
        Me.lblLine_Vacuum1.Size = New System.Drawing.Size(132, 21)
        Me.lblLine_Vacuum1.TabIndex = 175
        Me.lblLine_Vacuum1.Text = "1.2 X10 -12"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.White
        Me.Label55.Location = New System.Drawing.Point(1158, 538)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(46, 19)
        Me.Label55.TabIndex = 174
        Me.Label55.Text = "Torr"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.White
        Me.Label56.Location = New System.Drawing.Point(886, 529)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(133, 38)
        Me.Label56.TabIndex = 173
        Me.Label56.Text = "BSP Pressure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GUAGE"
        '
        'lblBSP_Pressure1
        '
        Me.lblBSP_Pressure1.BackColor = System.Drawing.Color.DimGray
        Me.lblBSP_Pressure1.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBSP_Pressure1.ForeColor = System.Drawing.Color.Yellow
        Me.lblBSP_Pressure1.Location = New System.Drawing.Point(1025, 534)
        Me.lblBSP_Pressure1.Name = "lblBSP_Pressure1"
        Me.lblBSP_Pressure1.Size = New System.Drawing.Size(132, 21)
        Me.lblBSP_Pressure1.TabIndex = 172
        Me.lblBSP_Pressure1.Text = "1.2 X10 -12"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.White
        Me.Label52.Location = New System.Drawing.Point(1158, 479)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 19)
        Me.Label52.TabIndex = 171
        Me.Label52.Text = "Torr"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.White
        Me.Label53.Location = New System.Drawing.Point(886, 470)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(133, 38)
        Me.Label53.TabIndex = 170
        Me.Label53.Text = "BSP Pressure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GUAGE"
        '
        'lblBSP_Pressure2
        '
        Me.lblBSP_Pressure2.BackColor = System.Drawing.Color.DimGray
        Me.lblBSP_Pressure2.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBSP_Pressure2.ForeColor = System.Drawing.Color.Yellow
        Me.lblBSP_Pressure2.Location = New System.Drawing.Point(1025, 475)
        Me.lblBSP_Pressure2.Name = "lblBSP_Pressure2"
        Me.lblBSP_Pressure2.Size = New System.Drawing.Size(132, 21)
        Me.lblBSP_Pressure2.TabIndex = 169
        Me.lblBSP_Pressure2.Text = "1.2 X10 -12"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.White
        Me.Label51.Location = New System.Drawing.Point(1162, 360)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(46, 19)
        Me.Label51.TabIndex = 168
        Me.Label51.Text = "Torr"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.White
        Me.Label50.Location = New System.Drawing.Point(879, 352)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(120, 32)
        Me.Label50.TabIndex = 167
        Me.Label50.Text = "BSP Pressure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Alarm Setting"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnManualValveEnable1)
        Me.GroupBox2.Controls.Add(Me.btnESC_PWR_Stop1)
        Me.GroupBox2.Controls.Add(Me.btnESC_PWR_Auto1)
        Me.GroupBox2.Controls.Add(Me.btnATMStop1)
        Me.GroupBox2.Controls.Add(Me.btnATM1)
        Me.GroupBox2.Controls.Add(Me.btnStandyStop1)
        Me.GroupBox2.Controls.Add(Me.btnStandy1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(898, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(306, 302)
        Me.GroupBox2.TabIndex = 165
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MENU"
        '
        'btnManualValveEnable1
        '
        Me.btnManualValveEnable1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualValveEnable1.ForeColor = System.Drawing.Color.Black
        Me.btnManualValveEnable1.Location = New System.Drawing.Point(6, 224)
        Me.btnManualValveEnable1.Name = "btnManualValveEnable1"
        Me.btnManualValveEnable1.Size = New System.Drawing.Size(294, 58)
        Me.btnManualValveEnable1.TabIndex = 172
        Me.btnManualValveEnable1.Text = "Manual Valve" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enable"
        Me.btnManualValveEnable1.UseVisualStyleBackColor = True
        '
        'btnESC_PWR_Stop1
        '
        Me.btnESC_PWR_Stop1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnESC_PWR_Stop1.ForeColor = System.Drawing.Color.Black
        Me.btnESC_PWR_Stop1.Location = New System.Drawing.Point(155, 159)
        Me.btnESC_PWR_Stop1.Name = "btnESC_PWR_Stop1"
        Me.btnESC_PWR_Stop1.Size = New System.Drawing.Size(145, 58)
        Me.btnESC_PWR_Stop1.TabIndex = 171
        Me.btnESC_PWR_Stop1.Text = "ESC PWR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop"
        Me.btnESC_PWR_Stop1.UseVisualStyleBackColor = True
        '
        'btnESC_PWR_Auto1
        '
        Me.btnESC_PWR_Auto1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnESC_PWR_Auto1.ForeColor = System.Drawing.Color.Black
        Me.btnESC_PWR_Auto1.Location = New System.Drawing.Point(6, 159)
        Me.btnESC_PWR_Auto1.Name = "btnESC_PWR_Auto1"
        Me.btnESC_PWR_Auto1.Size = New System.Drawing.Size(145, 58)
        Me.btnESC_PWR_Auto1.TabIndex = 170
        Me.btnESC_PWR_Auto1.Text = "ESC PWR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AUTO"
        Me.btnESC_PWR_Auto1.UseVisualStyleBackColor = True
        '
        'btnATMStop1
        '
        Me.btnATMStop1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnATMStop1.ForeColor = System.Drawing.Color.Black
        Me.btnATMStop1.Location = New System.Drawing.Point(155, 95)
        Me.btnATMStop1.Name = "btnATMStop1"
        Me.btnATMStop1.Size = New System.Drawing.Size(145, 58)
        Me.btnATMStop1.TabIndex = 169
        Me.btnATMStop1.Text = "ATM" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop"
        Me.btnATMStop1.UseVisualStyleBackColor = True
        '
        'btnATM1
        '
        Me.btnATM1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnATM1.ForeColor = System.Drawing.Color.Black
        Me.btnATM1.Location = New System.Drawing.Point(6, 95)
        Me.btnATM1.Name = "btnATM1"
        Me.btnATM1.Size = New System.Drawing.Size(145, 58)
        Me.btnATM1.TabIndex = 168
        Me.btnATM1.Text = "Chamber" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ATM"
        Me.btnATM1.UseVisualStyleBackColor = True
        '
        'btnStandyStop1
        '
        Me.btnStandyStop1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStandyStop1.ForeColor = System.Drawing.Color.Black
        Me.btnStandyStop1.Location = New System.Drawing.Point(155, 31)
        Me.btnStandyStop1.Name = "btnStandyStop1"
        Me.btnStandyStop1.Size = New System.Drawing.Size(145, 58)
        Me.btnStandyStop1.TabIndex = 167
        Me.btnStandyStop1.Text = "Standby" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Stop"
        Me.btnStandyStop1.UseVisualStyleBackColor = True
        '
        'btnStandy1
        '
        Me.btnStandy1.BackColor = System.Drawing.SystemColors.Control
        Me.btnStandy1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStandy1.ForeColor = System.Drawing.Color.Black
        Me.btnStandy1.Location = New System.Drawing.Point(6, 31)
        Me.btnStandy1.Name = "btnStandy1"
        Me.btnStandy1.Size = New System.Drawing.Size(145, 58)
        Me.btnStandy1.TabIndex = 166
        Me.btnStandy1.Text = "Chamber" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Standby"
        Me.btnStandy1.UseVisualStyleBackColor = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(305, 725)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(33, 19)
        Me.Label46.TabIndex = 164
        Me.Label46.Text = "uA"
        '
        'lblLeak_Current_N1
        '
        Me.lblLeak_Current_N1.BackColor = System.Drawing.Color.DimGray
        Me.lblLeak_Current_N1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLeak_Current_N1.ForeColor = System.Drawing.Color.Yellow
        Me.lblLeak_Current_N1.Location = New System.Drawing.Point(214, 725)
        Me.lblLeak_Current_N1.Name = "lblLeak_Current_N1"
        Me.lblLeak_Current_N1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLeak_Current_N1.Size = New System.Drawing.Size(89, 19)
        Me.lblLeak_Current_N1.TabIndex = 163
        Me.lblLeak_Current_N1.Text = "12345"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(20, 725)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(141, 19)
        Me.Label48.TabIndex = 162
        Me.Label48.Text = "Leak Current -"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(305, 695)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(33, 19)
        Me.Label43.TabIndex = 161
        Me.Label43.Text = "uA"
        '
        'lblLeak_Current_P1
        '
        Me.lblLeak_Current_P1.BackColor = System.Drawing.Color.DimGray
        Me.lblLeak_Current_P1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLeak_Current_P1.ForeColor = System.Drawing.Color.Yellow
        Me.lblLeak_Current_P1.Location = New System.Drawing.Point(216, 695)
        Me.lblLeak_Current_P1.Name = "lblLeak_Current_P1"
        Me.lblLeak_Current_P1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLeak_Current_P1.Size = New System.Drawing.Size(87, 19)
        Me.lblLeak_Current_P1.TabIndex = 160
        Me.lblLeak_Current_P1.Text = "12345"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(20, 695)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(141, 19)
        Me.Label45.TabIndex = 159
        Me.Label45.Text = "Leak Current +"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(305, 665)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(43, 19)
        Me.Label40.TabIndex = 158
        Me.Label40.Text = "Vdc"
        '
        'lblDC_Power_Keysight
        '
        Me.lblDC_Power_Keysight.BackColor = System.Drawing.Color.DimGray
        Me.lblDC_Power_Keysight.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDC_Power_Keysight.ForeColor = System.Drawing.Color.Yellow
        Me.lblDC_Power_Keysight.Location = New System.Drawing.Point(216, 665)
        Me.lblDC_Power_Keysight.Name = "lblDC_Power_Keysight"
        Me.lblDC_Power_Keysight.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDC_Power_Keysight.Size = New System.Drawing.Size(87, 19)
        Me.lblDC_Power_Keysight.TabIndex = 157
        Me.lblDC_Power_Keysight.Text = "1234567"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(20, 665)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(196, 19)
        Me.Label42.TabIndex = 156
        Me.Label42.Text = "DC Power-KEYSIGHT"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(305, 634)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(43, 19)
        Me.Label37.TabIndex = 155
        Me.Label37.Text = "Vdc"
        '
        'lblDC_Power_PV1
        '
        Me.lblDC_Power_PV1.BackColor = System.Drawing.Color.DimGray
        Me.lblDC_Power_PV1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDC_Power_PV1.ForeColor = System.Drawing.Color.Yellow
        Me.lblDC_Power_PV1.Location = New System.Drawing.Point(216, 634)
        Me.lblDC_Power_PV1.Name = "lblDC_Power_PV1"
        Me.lblDC_Power_PV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDC_Power_PV1.Size = New System.Drawing.Size(87, 19)
        Me.lblDC_Power_PV1.TabIndex = 154
        Me.lblDC_Power_PV1.Text = "12345"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(20, 634)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(173, 19)
        Me.Label39.TabIndex = 153
        Me.Label39.Text = "DC Power Monitor"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(305, 600)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(43, 19)
        Me.Label34.TabIndex = 152
        Me.Label34.Text = "Vdc"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(20, 600)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(134, 19)
        Me.Label36.TabIndex = 150
        Me.Label36.Text = "DC Power Set"
        '
        'btnDCPWR_HV_OFF
        '
        Me.btnDCPWR_HV_OFF.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDCPWR_HV_OFF.Location = New System.Drawing.Point(189, 531)
        Me.btnDCPWR_HV_OFF.Name = "btnDCPWR_HV_OFF"
        Me.btnDCPWR_HV_OFF.Size = New System.Drawing.Size(160, 58)
        Me.btnDCPWR_HV_OFF.TabIndex = 149
        Me.btnDCPWR_HV_OFF.Text = "DC PWR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "HV OFF"
        Me.btnDCPWR_HV_OFF.UseVisualStyleBackColor = True
        '
        'btnDCPWR_HV_ON
        '
        Me.btnDCPWR_HV_ON.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDCPWR_HV_ON.Location = New System.Drawing.Point(21, 531)
        Me.btnDCPWR_HV_ON.Name = "btnDCPWR_HV_ON"
        Me.btnDCPWR_HV_ON.Size = New System.Drawing.Size(160, 58)
        Me.btnDCPWR_HV_ON.TabIndex = 148
        Me.btnDCPWR_HV_ON.Text = "DC PWR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "HV ON"
        Me.btnDCPWR_HV_ON.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(217, 493)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(25, 19)
        Me.Label31.TabIndex = 147
        Me.Label31.Text = "W"
        '
        'lblRF_Power_Ref1
        '
        Me.lblRF_Power_Ref1.BackColor = System.Drawing.Color.DimGray
        Me.lblRF_Power_Ref1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblRF_Power_Ref1.ForeColor = System.Drawing.Color.Yellow
        Me.lblRF_Power_Ref1.Location = New System.Drawing.Point(151, 493)
        Me.lblRF_Power_Ref1.Name = "lblRF_Power_Ref1"
        Me.lblRF_Power_Ref1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRF_Power_Ref1.Size = New System.Drawing.Size(64, 19)
        Me.lblRF_Power_Ref1.TabIndex = 146
        Me.lblRF_Power_Ref1.Text = "12345"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(17, 493)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(131, 19)
        Me.Label33.TabIndex = 145
        Me.Label33.Text = "RF Power Ref"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(217, 466)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(25, 19)
        Me.Label28.TabIndex = 144
        Me.Label28.Text = "W"
        '
        'lblRF_Power_Fwd1
        '
        Me.lblRF_Power_Fwd1.BackColor = System.Drawing.Color.DimGray
        Me.lblRF_Power_Fwd1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblRF_Power_Fwd1.ForeColor = System.Drawing.Color.Yellow
        Me.lblRF_Power_Fwd1.Location = New System.Drawing.Point(151, 466)
        Me.lblRF_Power_Fwd1.Name = "lblRF_Power_Fwd1"
        Me.lblRF_Power_Fwd1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRF_Power_Fwd1.Size = New System.Drawing.Size(64, 19)
        Me.lblRF_Power_Fwd1.TabIndex = 143
        Me.lblRF_Power_Fwd1.Text = "12345"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(17, 466)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(138, 19)
        Me.Label30.TabIndex = 142
        Me.Label30.Text = "RF Power Fwd"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(217, 434)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(25, 19)
        Me.Label27.TabIndex = 141
        Me.Label27.Text = "W"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(17, 434)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 19)
        Me.Label25.TabIndex = 139
        Me.Label25.Text = "RF Power Set"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(433, 484)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(33, 19)
        Me.Label24.TabIndex = 138
        Me.Label24.Text = "TN"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(433, 453)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(31, 19)
        Me.Label23.TabIndex = 137
        Me.Label23.Text = "LD"
        '
        'lblTN1
        '
        Me.lblTN1.BackColor = System.Drawing.Color.DimGray
        Me.lblTN1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTN1.ForeColor = System.Drawing.Color.Yellow
        Me.lblTN1.Location = New System.Drawing.Point(468, 484)
        Me.lblTN1.Name = "lblTN1"
        Me.lblTN1.Size = New System.Drawing.Size(64, 19)
        Me.lblTN1.TabIndex = 136
        Me.lblTN1.Text = "12345"
        '
        'lblLD1
        '
        Me.lblLD1.BackColor = System.Drawing.Color.DimGray
        Me.lblLD1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblLD1.ForeColor = System.Drawing.Color.Yellow
        Me.lblLD1.Location = New System.Drawing.Point(468, 453)
        Me.lblLD1.Name = "lblLD1"
        Me.lblLD1.Size = New System.Drawing.Size(64, 19)
        Me.lblLD1.TabIndex = 135
        Me.lblLD1.Text = "12345"
        '
        'btnSV_Change
        '
        Me.btnSV_Change.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSV_Change.Location = New System.Drawing.Point(250, 434)
        Me.btnSV_Change.Name = "btnSV_Change"
        Me.btnSV_Change.Size = New System.Drawing.Size(99, 58)
        Me.btnSV_Change.TabIndex = 134
        Me.btnSV_Change.Text = "SV Data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Change"
        Me.btnSV_Change.UseVisualStyleBackColor = True
        '
        'btnRFOFF
        '
        Me.btnRFOFF.BackColor = System.Drawing.SystemColors.Control
        Me.btnRFOFF.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFOFF.Location = New System.Drawing.Point(189, 370)
        Me.btnRFOFF.Name = "btnRFOFF"
        Me.btnRFOFF.Size = New System.Drawing.Size(160, 58)
        Me.btnRFOFF.TabIndex = 133
        Me.btnRFOFF.Text = "RF OFF"
        Me.btnRFOFF.UseVisualStyleBackColor = False
        '
        'btnRFON
        '
        Me.btnRFON.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRFON.Location = New System.Drawing.Point(21, 370)
        Me.btnRFON.Name = "btnRFON"
        Me.btnRFON.Size = New System.Drawing.Size(160, 58)
        Me.btnRFON.TabIndex = 132
        Me.btnRFON.Text = "RF ON"
        Me.btnRFON.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numDry_Off_Delay_SV)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblDry_Off_Delay_PV)
        Me.GroupBox1.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(472, 630)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 87)
        Me.GroupBox1.TabIndex = 131
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DRY OFF DELAY (sec)"
        '
        'numDry_Off_Delay_SV
        '
        Me.numDry_Off_Delay_SV.BackColor = System.Drawing.Color.Lime
        Me.numDry_Off_Delay_SV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numDry_Off_Delay_SV.Location = New System.Drawing.Point(15, 47)
        Me.numDry_Off_Delay_SV.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numDry_Off_Delay_SV.Name = "numDry_Off_Delay_SV"
        Me.numDry_Off_Delay_SV.Size = New System.Drawing.Size(93, 29)
        Me.numDry_Off_Delay_SV.TabIndex = 200
        Me.numDry_Off_Delay_SV.Value = New Decimal(New Integer() {123456, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(120, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 19)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "PV"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(20, 25)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 19)
        Me.Label14.TabIndex = 130
        Me.Label14.Text = "SV"
        '
        'lblDry_Off_Delay_PV
        '
        Me.lblDry_Off_Delay_PV.BackColor = System.Drawing.Color.Yellow
        Me.lblDry_Off_Delay_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDry_Off_Delay_PV.ForeColor = System.Drawing.Color.Black
        Me.lblDry_Off_Delay_PV.Location = New System.Drawing.Point(120, 47)
        Me.lblDry_Off_Delay_PV.Name = "lblDry_Off_Delay_PV"
        Me.lblDry_Off_Delay_PV.Size = New System.Drawing.Size(83, 29)
        Me.lblDry_Off_Delay_PV.TabIndex = 132
        Me.lblDry_Off_Delay_PV.Text = "123456"
        Me.lblDry_Off_Delay_PV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picDry21___Y132_4
        '
        Me.picDry21___Y132_4.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry21___Y132_4.Location = New System.Drawing.Point(544, 405)
        Me.picDry21___Y132_4.Name = "picDry21___Y132_4"
        Me.picDry21___Y132_4.Size = New System.Drawing.Size(25, 48)
        Me.picDry21___Y132_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21___Y132_4.TabIndex = 129
        Me.picDry21___Y132_4.TabStop = False
        '
        'picDry21_Y132_4
        '
        Me.picDry21_Y132_4.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picDry21_Y132_4.Location = New System.Drawing.Point(578, 370)
        Me.picDry21_Y132_4.Name = "picDry21_Y132_4"
        Me.picDry21_Y132_4.Size = New System.Drawing.Size(39, 25)
        Me.picDry21_Y132_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21_Y132_4.TabIndex = 128
        Me.picDry21_Y132_4.TabStop = False
        '
        'picDry21__Y132_4
        '
        Me.picDry21__Y132_4.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_r_Off
        Me.picDry21__Y132_4.Location = New System.Drawing.Point(540, 366)
        Me.picDry21__Y132_4.Name = "picDry21__Y132_4"
        Me.picDry21__Y132_4.Size = New System.Drawing.Size(40, 40)
        Me.picDry21__Y132_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21__Y132_4.TabIndex = 127
        Me.picDry21__Y132_4.TabStop = False
        '
        'btnDRY_Pump_Off
        '
        Me.btnDRY_Pump_Off.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDRY_Pump_Off.Location = New System.Drawing.Point(703, 650)
        Me.btnDRY_Pump_Off.Name = "btnDRY_Pump_Off"
        Me.btnDRY_Pump_Off.Size = New System.Drawing.Size(127, 57)
        Me.btnDRY_Pump_Off.TabIndex = 126
        Me.btnDRY_Pump_Off.Text = "DRY PUMP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OFF"
        Me.btnDRY_Pump_Off.UseVisualStyleBackColor = True
        '
        'picDry1_Y136
        '
        Me.picDry1_Y136.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry1_Y136.Location = New System.Drawing.Point(751, 268)
        Me.picDry1_Y136.Name = "picDry1_Y136"
        Me.picDry1_Y136.Size = New System.Drawing.Size(25, 20)
        Me.picDry1_Y136.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry1_Y136.TabIndex = 125
        Me.picDry1_Y136.TabStop = False
        '
        'picDry1__Y136
        '
        Me.picDry1__Y136.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry1__Y136.Location = New System.Drawing.Point(751, 460)
        Me.picDry1__Y136.Name = "picDry1__Y136"
        Me.picDry1__Y136.Size = New System.Drawing.Size(25, 27)
        Me.picDry1__Y136.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry1__Y136.TabIndex = 124
        Me.picDry1__Y136.TabStop = False
        '
        'picDry1__X14D
        '
        Me.picDry1__X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry1__X14D.Location = New System.Drawing.Point(750, 618)
        Me.picDry1__X14D.Name = "picDry1__X14D"
        Me.picDry1__X14D.Size = New System.Drawing.Size(25, 34)
        Me.picDry1__X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry1__X14D.TabIndex = 123
        Me.picDry1__X14D.TabStop = False
        '
        'picDry1_T_X14D
        '
        Me.picDry1_T_X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_T_L_Off
        Me.picDry1_T_X14D.Location = New System.Drawing.Point(732, 562)
        Me.picDry1_T_X14D.Name = "picDry1_T_X14D"
        Me.picDry1_T_X14D.Size = New System.Drawing.Size(50, 57)
        Me.picDry1_T_X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry1_T_X14D.TabIndex = 122
        Me.picDry1_T_X14D.TabStop = False
        '
        'picDry1_X14D
        '
        Me.picDry1_X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry1_X14D.Location = New System.Drawing.Point(750, 541)
        Me.picDry1_X14D.Name = "picDry1_X14D"
        Me.picDry1_X14D.Size = New System.Drawing.Size(25, 21)
        Me.picDry1_X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry1_X14D.TabIndex = 121
        Me.picDry1_X14D.TabStop = False
        '
        'picDry1_VV_Y136
        '
        Me.picDry1_VV_Y136.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_R_Off
        Me.picDry1_VV_Y136.Location = New System.Drawing.Point(745, 484)
        Me.picDry1_VV_Y136.Name = "picDry1_VV_Y136"
        Me.picDry1_VV_Y136.Size = New System.Drawing.Size(55, 57)
        Me.picDry1_VV_Y136.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry1_VV_Y136.TabIndex = 120
        Me.picDry1_VV_Y136.TabStop = False
        '
        'btnTMP_OFF
        '
        Me.btnTMP_OFF.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTMP_OFF.Location = New System.Drawing.Point(703, 403)
        Me.btnTMP_OFF.Name = "btnTMP_OFF"
        Me.btnTMP_OFF.Size = New System.Drawing.Size(127, 58)
        Me.btnTMP_OFF.TabIndex = 119
        Me.btnTMP_OFF.Text = "TMP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OFF"
        Me.btnTMP_OFF.UseVisualStyleBackColor = True
        '
        'btnThrottle_Valve
        '
        Me.btnThrottle_Valve.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThrottle_Valve.Location = New System.Drawing.Point(703, 344)
        Me.btnThrottle_Valve.Name = "btnThrottle_Valve"
        Me.btnThrottle_Valve.Size = New System.Drawing.Size(127, 58)
        Me.btnThrottle_Valve.TabIndex = 118
        Me.btnThrottle_Valve.Text = "Throttle Valve"
        Me.btnThrottle_Valve.UseVisualStyleBackColor = True
        '
        'btnGate_Valve
        '
        Me.btnGate_Valve.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGate_Valve.Location = New System.Drawing.Point(703, 286)
        Me.btnGate_Valve.Name = "btnGate_Valve"
        Me.btnGate_Valve.Size = New System.Drawing.Size(127, 58)
        Me.btnGate_Valve.TabIndex = 117
        Me.btnGate_Valve.Text = "GATE V/V"
        Me.btnGate_Valve.UseVisualStyleBackColor = True
        '
        'picDry2_X14D
        '
        Me.picDry2_X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picDry2_X14D.Location = New System.Drawing.Point(675, 578)
        Me.picDry2_X14D.Name = "picDry2_X14D"
        Me.picDry2_X14D.Size = New System.Drawing.Size(57, 25)
        Me.picDry2_X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry2_X14D.TabIndex = 116
        Me.picDry2_X14D.TabStop = False
        '
        'picDry21___X14D
        '
        Me.picDry21___X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picDry21___X14D.Location = New System.Drawing.Point(580, 576)
        Me.picDry21___X14D.Name = "picDry21___X14D"
        Me.picDry21___X14D.Size = New System.Drawing.Size(39, 25)
        Me.picDry21___X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21___X14D.TabIndex = 115
        Me.picDry21___X14D.TabStop = False
        '
        'picDry2_T_X14D
        '
        Me.picDry2_T_X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_T_U_Off
        Me.picDry2_T_X14D.Location = New System.Drawing.Point(618, 560)
        Me.picDry2_T_X14D.Name = "picDry2_T_X14D"
        Me.picDry2_T_X14D.Size = New System.Drawing.Size(57, 50)
        Me.picDry2_T_X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry2_T_X14D.TabIndex = 114
        Me.picDry2_T_X14D.TabStop = False
        '
        'picDry21__X14D
        '
        Me.picDry21__X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_L_Off
        Me.picDry21__X14D.Location = New System.Drawing.Point(540, 562)
        Me.picDry21__X14D.Name = "picDry21__X14D"
        Me.picDry21__X14D.Size = New System.Drawing.Size(40, 40)
        Me.picDry21__X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21__X14D.TabIndex = 113
        Me.picDry21__X14D.TabStop = False
        '
        'picDry22_X14D
        '
        Me.picDry22_X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry22_X14D.Location = New System.Drawing.Point(634, 509)
        Me.picDry22_X14D.Name = "picDry22_X14D"
        Me.picDry22_X14D.Size = New System.Drawing.Size(25, 53)
        Me.picDry22_X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry22_X14D.TabIndex = 112
        Me.picDry22_X14D.TabStop = False
        '
        'picDry21_X14D
        '
        Me.picDry21_X14D.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry21_X14D.Location = New System.Drawing.Point(544, 509)
        Me.picDry21_X14D.Name = "picDry21_X14D"
        Me.picDry21_X14D.Size = New System.Drawing.Size(25, 53)
        Me.picDry21_X14D.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21_X14D.TabIndex = 111
        Me.picDry21_X14D.TabStop = False
        '
        'picDry22_Y132_4
        '
        Me.picDry22_Y132_4.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry22_Y132_4.Location = New System.Drawing.Point(634, 410)
        Me.picDry22_Y132_4.Name = "picDry22_Y132_4"
        Me.picDry22_Y132_4.Size = New System.Drawing.Size(25, 43)
        Me.picDry22_Y132_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry22_Y132_4.TabIndex = 110
        Me.picDry22_Y132_4.TabStop = False
        '
        'picDry2_T_Y132_4
        '
        Me.picDry2_T_Y132_4.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_T_L_Off
        Me.picDry2_T_Y132_4.Location = New System.Drawing.Point(616, 354)
        Me.picDry2_T_Y132_4.Name = "picDry2_T_Y132_4"
        Me.picDry2_T_Y132_4.Size = New System.Drawing.Size(50, 57)
        Me.picDry2_T_Y132_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry2_T_Y132_4.TabIndex = 109
        Me.picDry2_T_Y132_4.TabStop = False
        '
        'picDry21_VV_Y132
        '
        Me.picDry21_VV_Y132.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_R_Off
        Me.picDry21_VV_Y132.Location = New System.Drawing.Point(538, 453)
        Me.picDry21_VV_Y132.Name = "picDry21_VV_Y132"
        Me.picDry21_VV_Y132.Size = New System.Drawing.Size(55, 57)
        Me.picDry21_VV_Y132.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry21_VV_Y132.TabIndex = 108
        Me.picDry21_VV_Y132.TabStop = False
        '
        'picDry22_VV_Y134
        '
        Me.picDry22_VV_Y134.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_R_Off
        Me.picDry22_VV_Y134.Location = New System.Drawing.Point(629, 453)
        Me.picDry22_VV_Y134.Name = "picDry22_VV_Y134"
        Me.picDry22_VV_Y134.Size = New System.Drawing.Size(55, 57)
        Me.picDry22_VV_Y134.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry22_VV_Y134.TabIndex = 107
        Me.picDry22_VV_Y134.TabStop = False
        '
        'picDry2_Y132_4
        '
        Me.picDry2_Y132_4.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picDry2_Y132_4.Location = New System.Drawing.Point(634, 268)
        Me.picDry2_Y132_4.Name = "picDry2_Y132_4"
        Me.picDry2_Y132_4.Size = New System.Drawing.Size(25, 89)
        Me.picDry2_Y132_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDry2_Y132_4.TabIndex = 106
        Me.picDry2_Y132_4.TabStop = False
        '
        'PictureBox18
        '
        Me.PictureBox18.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PictureBox18.Location = New System.Drawing.Point(566, 217)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(25, 72)
        Me.PictureBox18.TabIndex = 105
        Me.PictureBox18.TabStop = False
        '
        'PictureBox17
        '
        Me.PictureBox17.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PictureBox17.Location = New System.Drawing.Point(546, 204)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(216, 14)
        Me.PictureBox17.TabIndex = 104
        Me.PictureBox17.TabStop = False
        '
        'picAr2____Y130
        '
        Me.picAr2____Y130.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picAr2____Y130.Location = New System.Drawing.Point(566, 285)
        Me.picAr2____Y130.Name = "picAr2____Y130"
        Me.picAr2____Y130.Size = New System.Drawing.Size(25, 23)
        Me.picAr2____Y130.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2____Y130.TabIndex = 103
        Me.picAr2____Y130.TabStop = False
        '
        'picN2_Y130
        '
        Me.picN2_Y130.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picN2_Y130.Location = New System.Drawing.Point(415, 276)
        Me.picN2_Y130.Name = "picN2_Y130"
        Me.picN2_Y130.Size = New System.Drawing.Size(25, 41)
        Me.picN2_Y130.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picN2_Y130.TabIndex = 102
        Me.picN2_Y130.TabStop = False
        '
        'picN2__Y128
        '
        Me.picN2__Y128.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picN2__Y128.Location = New System.Drawing.Point(415, 118)
        Me.picN2__Y128.Name = "picN2__Y128"
        Me.picN2__Y128.Size = New System.Drawing.Size(25, 104)
        Me.picN2__Y128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picN2__Y128.TabIndex = 101
        Me.picN2__Y128.TabStop = False
        '
        'picAr2___Y130
        '
        Me.picAr2___Y130.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_J_Off
        Me.picAr2___Y130.Location = New System.Drawing.Point(553, 307)
        Me.picAr2___Y130.Name = "picAr2___Y130"
        Me.picAr2___Y130.Size = New System.Drawing.Size(40, 40)
        Me.picAr2___Y130.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2___Y130.TabIndex = 100
        Me.picAr2___Y130.TabStop = False
        '
        'picAr2__Y130
        '
        Me.picAr2__Y130.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picAr2__Y130.Location = New System.Drawing.Point(516, 317)
        Me.picAr2__Y130.Name = "picAr2__Y130"
        Me.picAr2__Y130.Size = New System.Drawing.Size(39, 25)
        Me.picAr2__Y130.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2__Y130.TabIndex = 99
        Me.picAr2__Y130.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(268, 287)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 19)
        Me.Label18.TabIndex = 98
        Me.Label18.Text = "MFC02"
        '
        'picAr2__X106
        '
        Me.picAr2__X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picAr2__X106.Location = New System.Drawing.Point(179, 281)
        Me.picAr2__X106.Name = "picAr2__X106"
        Me.picAr2__X106.Size = New System.Drawing.Size(25, 22)
        Me.picAr2__X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2__X106.TabIndex = 97
        Me.picAr2__X106.TabStop = False
        '
        'picAr2___X106
        '
        Me.picAr2___X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_L_Off
        Me.picAr2___X106.Location = New System.Drawing.Point(175, 303)
        Me.picAr2___X106.Name = "picAr2___X106"
        Me.picAr2___X106.Size = New System.Drawing.Size(40, 40)
        Me.picAr2___X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2___X106.TabIndex = 96
        Me.picAr2___X106.TabStop = False
        '
        'picAr1__X106
        '
        Me.picAr1__X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_i_Off
        Me.picAr1__X106.Location = New System.Drawing.Point(179, 204)
        Me.picAr1__X106.Name = "picAr1__X106"
        Me.picAr1__X106.Size = New System.Drawing.Size(25, 22)
        Me.picAr1__X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr1__X106.TabIndex = 95
        Me.picAr1__X106.TabStop = False
        '
        'picAr2_Y130
        '
        Me.picAr2_Y130.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picAr2_Y130.Location = New System.Drawing.Point(333, 317)
        Me.picAr2_Y130.Name = "picAr2_Y130"
        Me.picAr2_Y130.Size = New System.Drawing.Size(132, 25)
        Me.picAr2_Y130.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2_Y130.TabIndex = 94
        Me.picAr2_Y130.TabStop = False
        '
        'picAr2_VV1_Y130
        '
        Me.picAr2_VV1_Y130.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_Off
        Me.picAr2_VV1_Y130.Location = New System.Drawing.Point(464, 291)
        Me.picAr2_VV1_Y130.Name = "picAr2_VV1_Y130"
        Me.picAr2_VV1_Y130.Size = New System.Drawing.Size(53, 55)
        Me.picAr2_VV1_Y130.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2_VV1_Y130.TabIndex = 93
        Me.picAr2_VV1_Y130.TabStop = False
        '
        'picN2_VV_Y15C
        '
        Me.picN2_VV_Y15C.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_R_Off
        Me.picN2_VV_Y15C.Location = New System.Drawing.Point(410, 220)
        Me.picN2_VV_Y15C.Name = "picN2_VV_Y15C"
        Me.picN2_VV_Y15C.Size = New System.Drawing.Size(55, 57)
        Me.picN2_VV_Y15C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picN2_VV_Y15C.TabIndex = 92
        Me.picN2_VV_Y15C.TabStop = False
        '
        'lblMFC2_PV
        '
        Me.lblMFC2_PV.BackColor = System.Drawing.Color.Yellow
        Me.lblMFC2_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblMFC2_PV.ForeColor = System.Drawing.Color.Black
        Me.lblMFC2_PV.Location = New System.Drawing.Point(268, 310)
        Me.lblMFC2_PV.Name = "lblMFC2_PV"
        Me.lblMFC2_PV.Size = New System.Drawing.Size(64, 29)
        Me.lblMFC2_PV.TabIndex = 90
        Me.lblMFC2_PV.Text = "12345"
        Me.lblMFC2_PV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picAr2_T_X106
        '
        Me.picAr2_T_X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_T_L_Off
        Me.picAr2_T_X106.Location = New System.Drawing.Point(161, 225)
        Me.picAr2_T_X106.Name = "picAr2_T_X106"
        Me.picAr2_T_X106.Size = New System.Drawing.Size(50, 57)
        Me.picAr2_T_X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2_T_X106.TabIndex = 89
        Me.picAr2_T_X106.TabStop = False
        '
        'picAr2_VV_Y12E
        '
        Me.picAr2_VV_Y12E.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_Off
        Me.picAr2_VV_Y12E.Location = New System.Drawing.Point(214, 291)
        Me.picAr2_VV_Y12E.Name = "picAr2_VV_Y12E"
        Me.picAr2_VV_Y12E.Size = New System.Drawing.Size(53, 55)
        Me.picAr2_VV_Y12E.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2_VV_Y12E.TabIndex = 88
        Me.picAr2_VV_Y12E.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(89, 244)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 19)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "->"
        '
        'picAr2_X106
        '
        Me.picAr2_X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picAr2_X106.Location = New System.Drawing.Point(127, 242)
        Me.picAr2_X106.Name = "picAr2_X106"
        Me.picAr2_X106.Size = New System.Drawing.Size(39, 25)
        Me.picAr2_X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr2_X106.TabIndex = 86
        Me.picAr2_X106.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(50, 244)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 19)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "Ar2"
        '
        'picAr1_VV1_Y12C
        '
        Me.picAr1_VV1_Y12C.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_Off
        Me.picAr1_VV1_Y12C.Location = New System.Drawing.Point(335, 139)
        Me.picAr1_VV1_Y12C.Name = "picAr1_VV1_Y12C"
        Me.picAr1_VV1_Y12C.Size = New System.Drawing.Size(53, 55)
        Me.picAr1_VV1_Y12C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr1_VV1_Y12C.TabIndex = 84
        Me.picAr1_VV1_Y12C.TabStop = False
        '
        'lblMFC1_PV
        '
        Me.lblMFC1_PV.BackColor = System.Drawing.Color.Yellow
        Me.lblMFC1_PV.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblMFC1_PV.ForeColor = System.Drawing.Color.Black
        Me.lblMFC1_PV.Location = New System.Drawing.Point(270, 155)
        Me.lblMFC1_PV.Name = "lblMFC1_PV"
        Me.lblMFC1_PV.Size = New System.Drawing.Size(64, 29)
        Me.lblMFC1_PV.TabIndex = 82
        Me.lblMFC1_PV.Text = "12345"
        Me.lblMFC1_PV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(270, 133)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 19)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "MFC01"
        '
        'picAr1_T_X106
        '
        Me.picAr1_T_X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe_T_D_Off
        Me.picAr1_T_X106.Location = New System.Drawing.Point(165, 155)
        Me.picAr1_T_X106.Name = "picAr1_T_X106"
        Me.picAr1_T_X106.Size = New System.Drawing.Size(53, 50)
        Me.picAr1_T_X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr1_T_X106.TabIndex = 80
        Me.picAr1_T_X106.TabStop = False
        '
        'picAr1__Y12C
        '
        Me.picAr1__Y12C.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picAr1__Y12C.Location = New System.Drawing.Point(387, 165)
        Me.picAr1__Y12C.Name = "picAr1__Y12C"
        Me.picAr1__Y12C.Size = New System.Drawing.Size(137, 25)
        Me.picAr1__Y12C.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr1__Y12C.TabIndex = 79
        Me.picAr1__Y12C.TabStop = False
        '
        'picAr1_VV_Y12A
        '
        Me.picAr1_VV_Y12A.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_Off
        Me.picAr1_VV_Y12A.Location = New System.Drawing.Point(216, 139)
        Me.picAr1_VV_Y12A.Name = "picAr1_VV_Y12A"
        Me.picAr1_VV_Y12A.Size = New System.Drawing.Size(53, 55)
        Me.picAr1_VV_Y12A.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr1_VV_Y12A.TabIndex = 78
        Me.picAr1_VV_Y12A.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(89, 168)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 19)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "->"
        '
        'picAr1_X106
        '
        Me.picAr1_X106.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picAr1_X106.Location = New System.Drawing.Point(127, 166)
        Me.picAr1_X106.Name = "picAr1_X106"
        Me.picAr1_X106.Size = New System.Drawing.Size(39, 25)
        Me.picAr1_X106.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAr1_X106.TabIndex = 76
        Me.picAr1_X106.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(50, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 19)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Ar1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(543, 180)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 16)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "BAR-GAUAGE"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(631, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 16)
        Me.Label9.TabIndex = 71
        Me.Label9.Text = "Torr"
        '
        'lblThrottleValve_DataRD_Pressure
        '
        Me.lblThrottleValve_DataRD_Pressure.AutoSize = True
        Me.lblThrottleValve_DataRD_Pressure.BackColor = System.Drawing.Color.White
        Me.lblThrottleValve_DataRD_Pressure.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThrottleValve_DataRD_Pressure.ForeColor = System.Drawing.Color.Black
        Me.lblThrottleValve_DataRD_Pressure.Location = New System.Drawing.Point(542, 98)
        Me.lblThrottleValve_DataRD_Pressure.Name = "lblThrottleValve_DataRD_Pressure"
        Me.lblThrottleValve_DataRD_Pressure.Size = New System.Drawing.Size(88, 21)
        Me.lblThrottleValve_DataRD_Pressure.TabIndex = 70
        Me.lblThrottleValve_DataRD_Pressure.Text = "ABCDEF"
        '
        'lblChamberRangeOver1
        '
        Me.lblChamberRangeOver1.AutoSize = True
        Me.lblChamberRangeOver1.BackColor = System.Drawing.Color.White
        Me.lblChamberRangeOver1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChamberRangeOver1.ForeColor = System.Drawing.Color.Black
        Me.lblChamberRangeOver1.Location = New System.Drawing.Point(542, 143)
        Me.lblChamberRangeOver1.Name = "lblChamberRangeOver1"
        Me.lblChamberRangeOver1.Size = New System.Drawing.Size(133, 25)
        Me.lblChamberRangeOver1.TabIndex = 69
        Me.lblChamberRangeOver1.Text = "Range Over"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox3.Location = New System.Drawing.Point(524, 79)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(304, 188)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        '
        'picN2_Y128
        '
        Me.picN2_Y128.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picN2_Y128.Location = New System.Drawing.Point(234, 94)
        Me.picN2_Y128.Name = "picN2_Y128"
        Me.picN2_Y128.Size = New System.Drawing.Size(290, 25)
        Me.picN2_Y128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picN2_Y128.TabIndex = 67
        Me.picN2_Y128.TabStop = False
        '
        'picN2_VV_Y128
        '
        Me.picN2_VV_Y128.Image = Global.ESC_V_Chamber.My.Resources.Resources.Valve_Off
        Me.picN2_VV_Y128.Location = New System.Drawing.Point(182, 69)
        Me.picN2_VV_Y128.Name = "picN2_VV_Y128"
        Me.picN2_VV_Y128.Size = New System.Drawing.Size(53, 55)
        Me.picN2_VV_Y128.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picN2_VV_Y128.TabIndex = 66
        Me.picN2_VV_Y128.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(89, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 19)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "->"
        '
        'picN2_X105
        '
        Me.picN2_X105.Image = Global.ESC_V_Chamber.My.Resources.Resources.Pipe___Off1
        Me.picN2_X105.Location = New System.Drawing.Point(127, 94)
        Me.picN2_X105.Name = "picN2_X105"
        Me.picN2_X105.Size = New System.Drawing.Size(58, 25)
        Me.picN2_X105.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picN2_X105.TabIndex = 64
        Me.picN2_X105.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(50, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 19)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "N2"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Controls.Add(Me.pan_DC_RF)
        Me.TabPage3.Controls.Add(Me.numStepCNT)
        Me.TabPage3.Controls.Add(Me.Label35)
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Controls.Add(Me.btnDataSave)
        Me.TabPage3.Controls.Add(Me.TxtModelName)
        Me.TabPage3.Controls.Add(Me.butInPutModelName)
        Me.TabPage3.Controls.Add(Me.butDelModel)
        Me.TabPage3.Controls.Add(Me.LstModel)
        Me.TabPage3.Location = New System.Drawing.Point(4, 31)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Size = New System.Drawing.Size(1225, 756)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "RECIPE"
        '
        'pan_DC_RF
        '
        Me.pan_DC_RF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pan_DC_RF.Controls.Add(Me.lblDC_RF)
        Me.pan_DC_RF.Controls.Add(Me.lblOnly_DC)
        Me.pan_DC_RF.Location = New System.Drawing.Point(1045, 558)
        Me.pan_DC_RF.Name = "pan_DC_RF"
        Me.pan_DC_RF.Size = New System.Drawing.Size(167, 112)
        Me.pan_DC_RF.TabIndex = 115
        '
        'lblDC_RF
        '
        Me.lblDC_RF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDC_RF.ForeColor = System.Drawing.Color.White
        Me.lblDC_RF.Location = New System.Drawing.Point(5, 55)
        Me.lblDC_RF.Name = "lblDC_RF"
        Me.lblDC_RF.Size = New System.Drawing.Size(151, 43)
        Me.lblDC_RF.TabIndex = 117
        Me.lblDC_RF.Text = "DC-RF Use"
        Me.lblDC_RF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOnly_DC
        '
        Me.lblOnly_DC.BackColor = System.Drawing.Color.Black
        Me.lblOnly_DC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOnly_DC.ForeColor = System.Drawing.Color.White
        Me.lblOnly_DC.Location = New System.Drawing.Point(5, 12)
        Me.lblOnly_DC.Name = "lblOnly_DC"
        Me.lblOnly_DC.Size = New System.Drawing.Size(151, 43)
        Me.lblOnly_DC.TabIndex = 116
        Me.lblOnly_DC.Text = "Only DC Use"
        Me.lblOnly_DC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numStepCNT
        '
        Me.numStepCNT.Location = New System.Drawing.Point(1167, 696)
        Me.numStepCNT.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numStepCNT.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStepCNT.Name = "numStepCNT"
        Me.numStepCNT.Size = New System.Drawing.Size(45, 32)
        Me.numStepCNT.TabIndex = 114
        Me.numStepCNT.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStepCNT.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(1065, 698)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(108, 21)
        Me.Label35.TabIndex = 113
        Me.Label35.Text = "스텝 수 : "
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DataGridView1.Location = New System.Drawing.Point(5, 6)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1033, 745)
        Me.DataGridView1.TabIndex = 112
        '
        'Column1
        '
        Me.Column1.HeaderText = "Name / Step"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.HeaderText = "Step1"
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.HeaderText = "Step2"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.HeaderText = "Step3"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        Me.Column5.HeaderText = "Step4"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column6
        '
        Me.Column6.HeaderText = "Step5"
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column7
        '
        Me.Column7.HeaderText = "Current"
        Me.Column7.Name = "Column7"
        '
        'btnDataSave
        '
        Me.btnDataSave.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnDataSave.ForeColor = System.Drawing.Color.Blue
        Me.btnDataSave.Location = New System.Drawing.Point(1045, 225)
        Me.btnDataSave.Name = "btnDataSave"
        Me.btnDataSave.Size = New System.Drawing.Size(89, 52)
        Me.btnDataSave.TabIndex = 111
        Me.btnDataSave.Text = "저  장"
        Me.btnDataSave.UseVisualStyleBackColor = True
        '
        'TxtModelName
        '
        Me.TxtModelName.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TxtModelName.Location = New System.Drawing.Point(1045, 155)
        Me.TxtModelName.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtModelName.Name = "TxtModelName"
        Me.TxtModelName.Size = New System.Drawing.Size(174, 29)
        Me.TxtModelName.TabIndex = 110
        '
        'butInPutModelName
        '
        Me.butInPutModelName.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.butInPutModelName.Location = New System.Drawing.Point(1045, 188)
        Me.butInPutModelName.Margin = New System.Windows.Forms.Padding(4)
        Me.butInPutModelName.Name = "butInPutModelName"
        Me.butInPutModelName.Size = New System.Drawing.Size(174, 25)
        Me.butInPutModelName.TabIndex = 109
        Me.butInPutModelName.Text = "레시피명 입력"
        Me.butInPutModelName.UseVisualStyleBackColor = True
        '
        'butDelModel
        '
        Me.butDelModel.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.butDelModel.Location = New System.Drawing.Point(1141, 225)
        Me.butDelModel.Margin = New System.Windows.Forms.Padding(4)
        Me.butDelModel.Name = "butDelModel"
        Me.butDelModel.Size = New System.Drawing.Size(78, 52)
        Me.butDelModel.TabIndex = 108
        Me.butDelModel.Text = "레시피 삭제"
        Me.butDelModel.UseVisualStyleBackColor = True
        '
        'LstModel
        '
        Me.LstModel.BackColor = System.Drawing.Color.Silver
        Me.LstModel.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LstModel.FormattingEnabled = True
        Me.LstModel.ItemHeight = 19
        Me.LstModel.Location = New System.Drawing.Point(1045, 6)
        Me.LstModel.Margin = New System.Windows.Forms.Padding(4)
        Me.LstModel.Name = "LstModel"
        Me.LstModel.Size = New System.Drawing.Size(174, 137)
        Me.LstModel.TabIndex = 107
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Black
        Me.TabPage4.Controls.Add(Me.lst_Alarm)
        Me.TabPage4.Location = New System.Drawing.Point(4, 31)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage4.Size = New System.Drawing.Size(1225, 756)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "ALARM"
        '
        'lst_Alarm
        '
        Me.lst_Alarm.BackColor = System.Drawing.Color.Black
        Me.lst_Alarm.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lst_Alarm.ForeColor = System.Drawing.Color.White
        Me.lst_Alarm.FormattingEnabled = True
        Me.lst_Alarm.HorizontalScrollbar = True
        Me.lst_Alarm.ItemHeight = 16
        Me.lst_Alarm.Location = New System.Drawing.Point(34, 45)
        Me.lst_Alarm.Name = "lst_Alarm"
        Me.lst_Alarm.Size = New System.Drawing.Size(654, 564)
        Me.lst_Alarm.TabIndex = 61
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label76)
        Me.TabPage5.Controls.Add(Me.Label75)
        Me.TabPage5.Controls.Add(Me.numTempDeviation)
        Me.TabPage5.Controls.Add(Me.Label74)
        Me.TabPage5.Controls.Add(Me.numTagetTime2)
        Me.TabPage5.Controls.Add(Me.Label70)
        Me.TabPage5.Controls.Add(Me.Label72)
        Me.TabPage5.Controls.Add(Me.numTagetTime1)
        Me.TabPage5.Controls.Add(Me.Label44)
        Me.TabPage5.Controls.Add(Me.Label49)
        Me.TabPage5.Controls.Add(Me.btnTempSV_Save)
        Me.TabPage5.Controls.Add(Me.numTempSV2)
        Me.TabPage5.Controls.Add(Me.Label67)
        Me.TabPage5.Controls.Add(Me.numTempSV1)
        Me.TabPage5.Controls.Add(Me.Label69)
        Me.TabPage5.Controls.Add(Me.Label64)
        Me.TabPage5.Controls.Add(Me.Label66)
        Me.TabPage5.Controls.Add(Me.Label63)
        Me.TabPage5.Controls.Add(Me.Label60)
        Me.TabPage5.Controls.Add(Me.Label54)
        Me.TabPage5.Controls.Add(Me.lblTemp2)
        Me.TabPage5.Controls.Add(Me.Label57)
        Me.TabPage5.Controls.Add(Me.lblTemp1)
        Me.TabPage5.Controls.Add(Me.btnHeaterOFF)
        Me.TabPage5.Controls.Add(Me.btnHeaterON)
        Me.TabPage5.Controls.Add(Me.Chart2)
        Me.TabPage5.Controls.Add(Me.Chart1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 31)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1225, 756)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TEMP"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(913, 633)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(34, 21)
        Me.Label76.TabIndex = 221
        Me.Label76.Text = "+-"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(1039, 633)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(32, 21)
        Me.Label75.TabIndex = 220
        Me.Label75.Text = "'C"
        '
        'numTempDeviation
        '
        Me.numTempDeviation.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numTempDeviation.Location = New System.Drawing.Point(951, 618)
        Me.numTempDeviation.Name = "numTempDeviation"
        Me.numTempDeviation.Size = New System.Drawing.Size(82, 39)
        Me.numTempDeviation.TabIndex = 219
        Me.numTempDeviation.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(920, 594)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(150, 21)
        Me.Label74.TabIndex = 218
        Me.Label74.Text = "편차 알람설정"
        '
        'numTagetTime2
        '
        Me.numTagetTime2.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numTagetTime2.Location = New System.Drawing.Point(580, 684)
        Me.numTagetTime2.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numTagetTime2.Name = "numTagetTime2"
        Me.numTagetTime2.Size = New System.Drawing.Size(82, 39)
        Me.numTagetTime2.TabIndex = 217
        Me.numTagetTime2.Value = New Decimal(New Integer() {123, 0, 0, 0})
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(525, 681)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(54, 42)
        Me.Label70.TabIndex = 216
        Me.Label70.Text = "도달" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "시간"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(668, 699)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(32, 21)
        Me.Label72.TabIndex = 215
        Me.Label72.Text = "분"
        '
        'numTagetTime1
        '
        Me.numTagetTime1.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numTagetTime1.Location = New System.Drawing.Point(94, 676)
        Me.numTagetTime1.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numTagetTime1.Name = "numTagetTime1"
        Me.numTagetTime1.Size = New System.Drawing.Size(82, 39)
        Me.numTagetTime1.TabIndex = 214
        Me.numTagetTime1.Value = New Decimal(New Integer() {123, 0, 0, 0})
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(39, 673)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(54, 42)
        Me.Label44.TabIndex = 213
        Me.Label44.Text = "도달" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "시간"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(182, 691)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(32, 21)
        Me.Label49.TabIndex = 212
        Me.Label49.Text = "분"
        '
        'btnTempSV_Save
        '
        Me.btnTempSV_Save.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnTempSV_Save.Location = New System.Drawing.Point(1074, 200)
        Me.btnTempSV_Save.Name = "btnTempSV_Save"
        Me.btnTempSV_Save.Size = New System.Drawing.Size(124, 66)
        Me.btnTempSV_Save.TabIndex = 211
        Me.btnTempSV_Save.Text = "온도 설정 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "저장"
        Me.btnTempSV_Save.UseVisualStyleBackColor = True
        '
        'numTempSV2
        '
        Me.numTempSV2.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numTempSV2.Location = New System.Drawing.Point(580, 633)
        Me.numTempSV2.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numTempSV2.Name = "numTempSV2"
        Me.numTempSV2.Size = New System.Drawing.Size(82, 39)
        Me.numTempSV2.TabIndex = 210
        Me.numTempSV2.Value = New Decimal(New Integer() {123, 0, 0, 0})
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(668, 648)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(32, 21)
        Me.Label67.TabIndex = 209
        Me.Label67.Text = "'C"
        '
        'numTempSV1
        '
        Me.numTempSV1.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numTempSV1.Location = New System.Drawing.Point(94, 628)
        Me.numTempSV1.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numTempSV1.Name = "numTempSV1"
        Me.numTempSV1.Size = New System.Drawing.Size(82, 39)
        Me.numTempSV1.TabIndex = 208
        Me.numTempSV1.Value = New Decimal(New Integer() {123, 0, 0, 0})
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(528, 640)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(46, 21)
        Me.Label69.TabIndex = 207
        Me.Label69.Text = "SV:"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(48, 635)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(46, 21)
        Me.Label64.TabIndex = 204
        Me.Label64.Text = "SV:"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(182, 643)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(32, 21)
        Me.Label66.TabIndex = 203
        Me.Label66.Text = "'C"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(527, 594)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(45, 21)
        Me.Label63.TabIndex = 201
        Me.Label63.Text = "PV:"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(48, 589)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(45, 21)
        Me.Label60.TabIndex = 200
        Me.Label60.Text = "PV:"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(641, 594)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(32, 21)
        Me.Label54.TabIndex = 199
        Me.Label54.Text = "'C"
        '
        'lblTemp2
        '
        Me.lblTemp2.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTemp2.Location = New System.Drawing.Point(569, 589)
        Me.lblTemp2.Name = "lblTemp2"
        Me.lblTemp2.Size = New System.Drawing.Size(66, 36)
        Me.lblTemp2.TabIndex = 198
        Me.lblTemp2.Text = "000"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(154, 589)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(32, 21)
        Me.Label57.TabIndex = 197
        Me.Label57.Text = "'C"
        '
        'lblTemp1
        '
        Me.lblTemp1.Font = New System.Drawing.Font("굴림", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTemp1.Location = New System.Drawing.Point(89, 584)
        Me.lblTemp1.Name = "lblTemp1"
        Me.lblTemp1.Size = New System.Drawing.Size(66, 36)
        Me.lblTemp1.TabIndex = 196
        Me.lblTemp1.Text = "000"
        '
        'btnHeaterOFF
        '
        Me.btnHeaterOFF.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnHeaterOFF.Location = New System.Drawing.Point(1074, 79)
        Me.btnHeaterOFF.Name = "btnHeaterOFF"
        Me.btnHeaterOFF.Size = New System.Drawing.Size(124, 49)
        Me.btnHeaterOFF.TabIndex = 195
        Me.btnHeaterOFF.Text = "Heater" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OFF"
        Me.btnHeaterOFF.UseVisualStyleBackColor = True
        '
        'btnHeaterON
        '
        Me.btnHeaterON.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnHeaterON.Location = New System.Drawing.Point(1074, 24)
        Me.btnHeaterON.Name = "btnHeaterON"
        Me.btnHeaterON.Size = New System.Drawing.Size(124, 49)
        Me.btnHeaterON.TabIndex = 194
        Me.btnHeaterON.Text = "Heater" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ON"
        Me.btnHeaterON.UseVisualStyleBackColor = True
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.Black
        Me.Chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Interval = 0R
        ChartArea1.AxisX.LabelStyle.IntervalOffset = 0R
        ChartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MajorGrid.Interval = 0R
        ChartArea1.AxisX.MajorGrid.IntervalOffset = 0R
        ChartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea1.AxisX.MaximumAutoSize = 10.0!
        ChartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.Red
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        ChartArea1.AxisX2.IsLabelAutoFit = False
        ChartArea1.CursorX.AutoScroll = False
        ChartArea1.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea1)
        Legend1.Enabled = False
        Legend1.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend1)
        Me.Chart2.Location = New System.Drawing.Point(541, 24)
        Me.Chart2.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.Chart2.Name = "Chart2"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(507, 546)
        Me.Chart2.TabIndex = 3
        Me.Chart2.Text = "Chart3"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.Black
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center
        ChartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelStyle.Interval = 0R
        ChartArea2.AxisX.LabelStyle.IntervalOffset = 0R
        ChartArea2.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.MajorGrid.Interval = 0R
        ChartArea2.AxisX.MajorGrid.IntervalOffset = 0R
        ChartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.[Auto]
        ChartArea2.AxisX.MaximumAutoSize = 10.0!
        ChartArea2.AxisX.ScrollBar.BackColor = System.Drawing.Color.Red
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        ChartArea2.AxisX2.IsLabelAutoFit = False
        ChartArea2.CursorX.AutoScroll = False
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Enabled = False
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(22, 24)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(507, 546)
        Me.Chart1.TabIndex = 2
        Me.Chart1.Text = "Chart2"
        '
        'Timer1
        '
        '
        'AxActUtlType1
        '
        Me.AxActUtlType1.Enabled = True
        Me.AxActUtlType1.Location = New System.Drawing.Point(434, 21)
        Me.AxActUtlType1.Name = "AxActUtlType1"
        Me.AxActUtlType1.OcxState = CType(resources.GetObject("AxActUtlType1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxActUtlType1.Size = New System.Drawing.Size(32, 32)
        Me.AxActUtlType1.TabIndex = 64
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Pipe_-_Off.jpg")
        Me.ImageList1.Images.SetKeyName(1, "Pipe_-_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(2, "Pipe_-_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(3, "Pipe_i_Off.jpg")
        Me.ImageList1.Images.SetKeyName(4, "Pipe_i_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(5, "Pipe_i_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(6, "Pipe_L_Off.jpg")
        Me.ImageList1.Images.SetKeyName(7, "Pipe_L_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(8, "Pipe_L_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(9, "Pipe_J_Off.jpg")
        Me.ImageList1.Images.SetKeyName(10, "Pipe_J_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(11, "Pipe_J_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(12, "Pipe_r_Off.jpg")
        Me.ImageList1.Images.SetKeyName(13, "Pipe_r_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(14, "Pipe_r_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(15, "Pipe_T_U_Off.jpg")
        Me.ImageList1.Images.SetKeyName(16, "Pipe_T_U_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(17, "Pipe_T_U_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(18, "Pipe_T_L-Off.jpg")
        Me.ImageList1.Images.SetKeyName(19, "Pipe_T_L_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(20, "Pipe_T_L_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(21, "Pipe_T_D_Off.jpg")
        Me.ImageList1.Images.SetKeyName(22, "Pipe_T_D_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(23, "Pipe_T_D_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(24, "Valve_Off.jpg")
        Me.ImageList1.Images.SetKeyName(25, "Valve_On_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(26, "Valve_On_Red.jpg")
        Me.ImageList1.Images.SetKeyName(27, "Valve_R_Off.jpg")
        Me.ImageList1.Images.SetKeyName(28, "Valve_On_R_Blue.jpg")
        Me.ImageList1.Images.SetKeyName(29, "Valve_On_R_Red.jpg")
        '
        'lblCycleTime
        '
        Me.lblCycleTime.AutoSize = True
        Me.lblCycleTime.ForeColor = System.Drawing.Color.DimGray
        Me.lblCycleTime.Location = New System.Drawing.Point(1206, 9)
        Me.lblCycleTime.Name = "lblCycleTime"
        Me.lblCycleTime.Size = New System.Drawing.Size(11, 12)
        Me.lblCycleTime.TabIndex = 65
        Me.lblCycleTime.Text = "0"
        '
        'LblModel
        '
        Me.LblModel.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblModel.ForeColor = System.Drawing.Color.Yellow
        Me.LblModel.Location = New System.Drawing.Point(860, 34)
        Me.LblModel.Name = "LblModel"
        Me.LblModel.Size = New System.Drawing.Size(388, 44)
        Me.LblModel.TabIndex = 67
        Me.LblModel.Text = "Label6"
        Me.LblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAutoSeq
        '
        Me.lblAutoSeq.AutoSize = True
        Me.lblAutoSeq.ForeColor = System.Drawing.Color.DimGray
        Me.lblAutoSeq.Location = New System.Drawing.Point(1142, 9)
        Me.lblAutoSeq.Name = "lblAutoSeq"
        Me.lblAutoSeq.Size = New System.Drawing.Size(11, 12)
        Me.lblAutoSeq.TabIndex = 68
        Me.lblAutoSeq.Text = "0"
        '
        'btnAlarmReset
        '
        Me.btnAlarmReset.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAlarmReset.Location = New System.Drawing.Point(1058, 891)
        Me.btnAlarmReset.Name = "btnAlarmReset"
        Me.btnAlarmReset.Size = New System.Drawing.Size(90, 49)
        Me.btnAlarmReset.TabIndex = 193
        Me.btnAlarmReset.Text = "Alarm Reset"
        Me.btnAlarmReset.UseVisualStyleBackColor = True
        '
        'btnBuzzerStop
        '
        Me.btnBuzzerStop.Font = New System.Drawing.Font("굴림", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnBuzzerStop.Location = New System.Drawing.Point(1154, 892)
        Me.btnBuzzerStop.Name = "btnBuzzerStop"
        Me.btnBuzzerStop.Size = New System.Drawing.Size(90, 49)
        Me.btnBuzzerStop.TabIndex = 194
        Me.btnBuzzerStop.Text = "Buzzer Stop"
        Me.btnBuzzerStop.UseVisualStyleBackColor = True
        '
        'tmrTemp
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1260, 961)
        Me.Controls.Add(Me.btnBuzzerStop)
        Me.Controls.Add(Me.btnAlarmReset)
        Me.Controls.Add(Me.lblAutoSeq)
        Me.Controls.Add(Me.LblModel)
        Me.Controls.Add(Me.lblCycleTime)
        Me.Controls.Add(Me.AxActUtlType1)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmMain"
        Me.Text = "MAIN"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.numBSP_Pressure_Alarm_SV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBSP_Pressure_Alarm_SV_Square, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDC_Power_SV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRF_Power_SV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMFC2_SV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMFC1_SV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panValve.ResumeLayout(False)
        Me.grpValve.ResumeLayout(False)
        Me.grpBaratonGauge.ResumeLayout(False)
        Me.grpBaratonGauge.PerformLayout()
        CType(Me.numBaratonGauge_SV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.grpManualPowerSupply.ResumeLayout(False)
        Me.grpManualPowerSupply.PerformLayout()
        CType(Me.numPowerSupply_SV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panManual_ESC_Step.ResumeLayout(False)
        Me.panManual_ESC_Step.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numDry_Off_Delay_SV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21___Y132_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21_Y132_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21__Y132_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry1_Y136, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry1__Y136, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry1__X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry1_T_X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry1_X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry1_VV_Y136, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry2_X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21___X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry2_T_X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21__X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry22_X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21_X14D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry22_Y132_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry2_T_Y132_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry21_VV_Y132, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry22_VV_Y134, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDry2_Y132_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2____Y130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picN2_Y130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picN2__Y128, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2___Y130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2__Y130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2__X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2___X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr1__X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2_Y130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2_VV1_Y130, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picN2_VV_Y15C, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2_T_X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2_VV_Y12E, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr2_X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr1_VV1_Y12C, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr1_T_X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr1__Y12C, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr1_VV_Y12A, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAr1_X106, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picN2_Y128, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picN2_VV_Y128, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picN2_X105, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.pan_DC_RF.ResumeLayout(False)
        CType(Me.numStepCNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.numTempDeviation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTagetTime2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTagetTime1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTempSV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTempSV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxActUtlType1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblMessage As Label
    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label182 As Label
    Friend WithEvents Label181 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents AxActUtlType1 As AxActUtlTypeLib.AxActUtlType
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lst_Alarm As ListBox
    Friend WithEvents lblStandbyStep As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents picN2_X105 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents picN2_VV_Y128 As PictureBox
    Friend WithEvents lblChamberRangeOver1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents picN2_Y128 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblThrottleValve_DataRD_Pressure As Label
    Friend WithEvents picAr1_T_X106 As PictureBox
    Friend WithEvents picAr1__Y12C As PictureBox
    Friend WithEvents picAr1_VV_Y12A As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents picAr1_X106 As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents picAr1_VV1_Y12C As PictureBox
    Friend WithEvents lblMFC1_PV As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents picN2_VV_Y15C As PictureBox
    Friend WithEvents lblMFC2_PV As Label
    Friend WithEvents picAr2_T_X106 As PictureBox
    Friend WithEvents picAr2_VV_Y12E As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents picAr2_X106 As PictureBox
    Friend WithEvents Label17 As Label
    Friend WithEvents picAr2_Y130 As PictureBox
    Friend WithEvents picAr2_VV1_Y130 As PictureBox
    Friend WithEvents picAr1__X106 As PictureBox
    Friend WithEvents picAr2___X106 As PictureBox
    Friend WithEvents Label18 As Label
    Friend WithEvents picAr2__X106 As PictureBox
    Friend WithEvents picAr2___Y130 As PictureBox
    Friend WithEvents picAr2__Y130 As PictureBox
    Friend WithEvents picAr2____Y130 As PictureBox
    Friend WithEvents picN2_Y130 As PictureBox
    Friend WithEvents picN2__Y128 As PictureBox
    Friend WithEvents PictureBox18 As PictureBox
    Friend WithEvents PictureBox17 As PictureBox
    Friend WithEvents picDry2_T_X14D As PictureBox
    Friend WithEvents picDry21__X14D As PictureBox
    Friend WithEvents picDry22_X14D As PictureBox
    Friend WithEvents picDry21_X14D As PictureBox
    Friend WithEvents picDry22_Y132_4 As PictureBox
    Friend WithEvents picDry2_T_Y132_4 As PictureBox
    Friend WithEvents picDry21_VV_Y132 As PictureBox
    Friend WithEvents picDry22_VV_Y134 As PictureBox
    Friend WithEvents picDry2_Y132_4 As PictureBox
    Friend WithEvents btnTMP_OFF As Button
    Friend WithEvents btnThrottle_Valve As Button
    Friend WithEvents btnGate_Valve As Button
    Friend WithEvents picDry2_X14D As PictureBox
    Friend WithEvents picDry21___X14D As PictureBox
    Friend WithEvents picDry1_Y136 As PictureBox
    Friend WithEvents picDry1__Y136 As PictureBox
    Friend WithEvents picDry1__X14D As PictureBox
    Friend WithEvents picDry1_T_X14D As PictureBox
    Friend WithEvents picDry1_X14D As PictureBox
    Friend WithEvents picDry1_VV_Y136 As PictureBox
    Friend WithEvents btnDRY_Pump_Off As Button
    Friend WithEvents picDry21__Y132_4 As PictureBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents btnDCPWR_HV_OFF As Button
    Friend WithEvents btnDCPWR_HV_ON As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents lblRF_Power_Ref1 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblRF_Power_Fwd1 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblTN1 As Label
    Friend WithEvents lblLD1 As Label
    Friend WithEvents btnSV_Change As Button
    Friend WithEvents btnRFOFF As Button
    Friend WithEvents btnRFON As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblDry_Off_Delay_PV As Label
    Friend WithEvents picDry21___Y132_4 As PictureBox
    Friend WithEvents picDry21_Y132_4 As PictureBox
    Friend WithEvents Label46 As Label
    Friend WithEvents lblLeak_Current_N1 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents lblLeak_Current_P1 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents lblDC_Power_Keysight As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents lblDC_Power_PV1 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents lblBSP_Pressure_Warning_Lamp1 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents lblHi_Vacuum1 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents lblLine_Vacuum1 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents lblBSP_Pressure1 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents lblBSP_Pressure2 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnManualValveEnable1 As Button
    Friend WithEvents btnESC_PWR_Stop1 As Button
    Friend WithEvents btnESC_PWR_Auto1 As Button
    Friend WithEvents btnATMStop1 As Button
    Friend WithEvents btnATM1 As Button
    Friend WithEvents btnStandyStop1 As Button
    Friend WithEvents btnStandy1 As Button
    Friend WithEvents Label111 As Label
    Friend WithEvents Label112 As Label
    Friend WithEvents lblHi_Vacuum As Label
    Friend WithEvents Label114 As Label
    Friend WithEvents Label115 As Label
    Friend WithEvents lblLine_Vacuum As Label
    Friend WithEvents Label117 As Label
    Friend WithEvents Label118 As Label
    Friend WithEvents lblBSP_Pressure As Label
    Friend WithEvents Label105 As Label
    Friend WithEvents lblBSP_MFC As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents Label108 As Label
    Friend WithEvents lblPlasma_MFC As Label
    Friend WithEvents Label110 As Label
    Friend WithEvents lblChamberRangeOver As Label
    Friend WithEvents Label103 As Label
    Friend WithEvents Label101 As Label
    Friend WithEvents lblBSP_Pressure_Warning_Lamp As Label
    Friend WithEvents Label99 As Label
    Friend WithEvents lblATM_CHECK_Lamp As Label
    Friend WithEvents Label98 As Label
    Friend WithEvents lblBASE_PRESSURE_Lamp As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents lblLeak_Current_N As Label
    Friend WithEvents Label96 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents lblLeak_Current_P As Label
    Friend WithEvents Label93 As Label
    Friend WithEvents Label88 As Label
    Friend WithEvents lblDC_Power_PV As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents lblDC_Power_SV As Label
    Friend WithEvents Label85 As Label
    Friend WithEvents Label82 As Label
    Friend WithEvents lblRF_Power_Ref As Label
    Friend WithEvents Label84 As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents lblRF_Power_Fwd As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents lblRF_Power_SV As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents lblTN As Label
    Friend WithEvents lblLD As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblESC_MSG As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents lblESCStep As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblATM_MSG As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents lblATMStep As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblStandby_MSG As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnManualValveEnable As Button
    Friend WithEvents btnESC_PWR_Stop As Button
    Friend WithEvents btnESC_PWR_Auto As Button
    Friend WithEvents btnATMStop As Button
    Friend WithEvents btnATM As Button
    Friend WithEvents btnStandyStop As Button
    Friend WithEvents btnStandy As Button
    Friend WithEvents lblCycleTime As Label
    Friend WithEvents grpManualPowerSupply As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblPowerSupply_PV As Label
    Friend WithEvents panManual_ESC_Step As Panel
    Friend WithEvents lblESC_MSG1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblESCStep1 As Label
    Friend WithEvents panValve As Panel
    Friend WithEvents btnValveOpen As Button
    Friend WithEvents btnValvePannelClose As Button
    Friend WithEvents btnValveClose As Button
    Friend WithEvents grpValve As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents lblCloseinterlock_Lamp As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblOpeninterlock_Lamp As Label
    Friend WithEvents grpBaratonGauge As GroupBox
    Friend WithEvents Label47 As Label
    Friend WithEvents btnBaratonGaugeSV_Change As Button
    Friend WithEvents Label41 As Label
    Friend WithEvents lblBaratonGauge_PV1 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents lblThrottleValve_Position_PV As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents btnThrottleValve_PositionMove As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents lblPressureinterlock_Lamp As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents numMFC2_SV As NumericUpDown
    Friend WithEvents numMFC1_SV As NumericUpDown
    Friend WithEvents numPowerSupply_SV As NumericUpDown
    Friend WithEvents numRF_Power_SV1 As NumericUpDown
    Friend WithEvents numDC_Power_SV1 As NumericUpDown
    Friend WithEvents numBSP_Pressure_Alarm_SV As NumericUpDown
    Friend WithEvents numBSP_Pressure_Alarm_SV_Square As NumericUpDown
    Friend WithEvents numDry_Off_Delay_SV As NumericUpDown
    Friend WithEvents numBaratonGauge_SV As NumericUpDown
    Friend WithEvents lblBaratonGauge_PV As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnDataSave As Button
    Friend WithEvents TxtModelName As TextBox
    Friend WithEvents butInPutModelName As Button
    Friend WithEvents butDelModel As Button
    Friend WithEvents LstModel As ListBox
    Friend WithEvents LblModel As Label
    Friend WithEvents cboModel As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents numStepCNT As NumericUpDown
    Friend WithEvents Label35 As Label
    Friend WithEvents pan_DC_RF As Panel
    Friend WithEvents lblDC_RF As Label
    Friend WithEvents lblOnly_DC As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents lblAutoSeq As Label
    Friend WithEvents btnAlarmReset As Button
    Friend WithEvents btnBuzzerStop As Button
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents btnHeaterOFF As Button
    Friend WithEvents btnHeaterON As Button
    Friend WithEvents Label54 As Label
    Friend WithEvents lblTemp2 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents lblTemp1 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents btnTempSV_Save As Button
    Friend WithEvents numTempSV2 As NumericUpDown
    Friend WithEvents Label67 As Label
    Friend WithEvents numTempSV1 As NumericUpDown
    Friend WithEvents numTagetTime2 As NumericUpDown
    Friend WithEvents Label70 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents numTagetTime1 As NumericUpDown
    Friend WithEvents Label44 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents tmrTemp As Timer
    Friend WithEvents Label76 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents numTempDeviation As NumericUpDown
    Friend WithEvents Label74 As Label
End Class
