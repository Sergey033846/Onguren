<%@ Page Title="Комбинированная ветро-солнечная электростанция (Иркутская область, Ольхонский район, п. Онгурен)" Language="C#" MasterPageFile="~/MainPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MainForm" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>
<%@ Register Assembly="AjaxControlToolkit" TagPrefix="asp" Namespace="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="HeaderHolder" Runat="Server">        
        <h1 style="display: block; background-color: #63320A; color: #FFFFFF; line-height: 30px; text-indent: 5px; text-align: center; font-family: Arial, Helvetica, sans-serif; font-size: small; text-transform: uppercase; font-weight: bold; width: 100%;">Комбинированная ветро-солнечная электростанция (Иркутская область, Ольхонский район, п. Онгурен)</h1>
        <div style="margin-top: -6px;">

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>                
        <script runat="Server" type="text/C#">
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            return new AjaxControlToolkit.Slide[] { 
            new AjaxControlToolkit.Slide("images/slideshow/slide1.jpg", "", ""),
            new AjaxControlToolkit.Slide("images/slideshow/slide2.jpg", "", ""),
            new AjaxControlToolkit.Slide("images/slideshow/slide3.jpg", "", ""),
            new AjaxControlToolkit.Slide("images/slideshow/slide4.jpg", "", ""),
            new AjaxControlToolkit.Slide("images/slideshow/slide5.jpg", "", "")};
        }
        </script>
        
        <asp:Image ID="Image1" runat="server" />
    
        <asp:SlideShowExtender ID="SlideShowExtender1"
              AutoPlay="true"
               Loop="true" 
                PlayButtonText="Play" 
                 SlideShowServiceMethod="GetSlides" StopButtonText="Stop"
                  TargetControlID="Image1" runat="server" PlayInterval="10000">
        </asp:SlideShowExtender>                         
        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftHolder" Runat="Server">
    <div class="mainStyle">
    <p style="display: block; font-weight: bold; background-color: #63320A; color: #FFFFFF; line-height: 23px; text-indent: 5px; margin-right: 10px; text-align: center; font-family: Arial, Helvetica, sans-serif; margin-top: -1px;">ИНФОРМАЦИЯ</p>
    <div style="font-family: Arial, Helvetica, sans-serif; text-align: justify; margin-right: 15px;">
    <p>Посёлок Онгурён – один из самых труднодоступных населенных пунктов побережья Байкала. Поселок не имеет централизованного электроснабжения и получает энергию от старой дизельной электростанции (ДЭС), подающей электроэнергию не более 3-4 часов в сутки. Местные жители лишены возможности использовать даже самые необходимые бытовые приборы.</p>
    <p>Решение о строительстве комбинированной электростанции на возобновляемых источниках энергии было принято в 2011 году на заседании Научно-экспертного совета по энергоэффективности Иркутской области, с учётом необходимых климатических условий (ветровые нагрузки и число солнечных дней), обеспечивающих максимальную эффективность установки. Другие энергомощности в границах Прибайкальского национального парка возводить запрещено.</p>

    <div align="center">
        <eo:ImageZoom runat="server" Height="207px" Width="170px" ID="ImageInfoWind" 
            BigImageUrl="~/images/info/wind_resources_big.jpg" 
            SmallImageUrl="~/images/info/wind_resources_small.jpg" 
            ToolTip="нажмите, чтобы увеличить" 
            Description="с. Онгурен, Ольхонский район"
            LoadingPanelID="loading">            
            <ZoomPanelTemplate>
                <div style="text-align:center;padding-top:5px;">
                    {var:description}</div>
                <div>
                    {var:big_image}</div>
            </ZoomPanelTemplate>
            <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px; font-weight: bold; font-family: Arial; font-size: 14px;"></ZoomPanelStyle>
        </eo:ImageZoom>

        <eo:ImageZoom runat="server" Height="207px" Width="170px" ID="ImageInfoSun" 
            BigImageUrl="~/images/info/sun_resources_big.jpg" 
            SmallImageUrl="~/images/info/sun_resources_small.jpg"
            ToolTip="нажмите, чтобы увеличить" 
            Description="с. Онгурен, Ольхонский район"
            LoadingPanelID="loading">
            <ZoomPanelTemplate>
                <div style="text-align:center;padding-top:5px;">
                    {var:description}</div>
                <div>
                    {var:big_image}</div>
            </ZoomPanelTemplate>
            <ZoomPanelStyle CssText="background-color:#ffffff;border:solid #d0d0d0 1px;padding:5px; font-weight: bold; font-family: Arial; font-size: 14px;"></ZoomPanelStyle>
        </eo:ImageZoom>
    </div>
    <div id="loading" style="display:none; border: solid 1px black; background-color:#FFFFFF; padding: 3px 15px 3px 15px; color: #000000; font-size: small;">
    Загрузка...
    </div>

    <p>Мощность первой очереди электростанции составляет 50 кВт. Расчетная мощность всей установки – 100 кВт, этого достаточно, чтобы обеспечить электроэнергией данный населенный пункт. Особенность данной электростанции в том, что она может работать совместно с автоматической ДЭС, которая запускается, когда не хватает энергии ветра и солнца. Планируется строительство второй очереди.</p>
    <p>Проект и монтаж ветро-солнечной станции выполняла группа организаций, в том числе ОГУЭП «Облкоммунэнерго», которое построило линии электропередач до станции и провело реконструкцию электросети в посёлке. 
Результаты работы экспериментальной станции покажут целесообразность развития альтернативной энергетики на побережье Байкала и других регионах Иркутской области.</p>
    </div>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="AiiskueHolder" Runat="Server">
    
    <div class="mainStyle">
    <p style="display: block; font-weight: bold; background-color: #63320A; color: #FFFFFF; line-height: 23px; text-indent: 5px; margin-right: 0px; text-align: center; font-family: Arial, Helvetica, sans-serif; margin-top: -1px;">ПАРАМЕТРЫ</p>
        
        
     <eo:CallbackPanel runat="server" Height="50px" Width="865px" ID="EOCBPPeriod" 
            onexecute="EOCBPPeriod_Execute" 
            Triggers="">
        <div style="float: left; display: block;">
        <asp:Label ID="LabelGlobalPeriodType" runat="server" Text="Выберите период:" 
                CssClass="viewMode" Font-Bold="True" ForeColor="#663300"></asp:Label>  
         
        <asp:RadioButtonList runat="server" ID="RadioButtonPeriodType" 
                RepeatDirection="Horizontal" 
                AutoPostBack="False">
            <asp:ListItem>День</asp:ListItem>
            <asp:ListItem Selected="True">Месяц</asp:ListItem>
            <asp:ListItem>Год</asp:ListItem>
            <asp:ListItem>Период</asp:ListItem>
        </asp:RadioButtonList>

        </div>
        </div>

        <div style="float: left; display: block; margin-left: 25px;">
        <asp:Label ID="LabelGlobalPeriodValue" runat="server" Text="Выберите значение:" 
                CssClass="viewMode" Font-Bold="True" ForeColor="#663300"></asp:Label>  
        
        <div style="display: block; margin-top: 5px">
        <asp:Panel runat="server" ID="PanelPeriodValue" Width="332px">
            <div style="float:left">
            <asp:Label ID="LabelYearList" runat="server" Text="Год:" 
                CssClass="viewMode"></asp:Label>  
            <asp:DropDownList runat="server" ID="YearList" Width="120px">
            </asp:DropDownList> 
            </div>

            <div style="float:left; margin-left: 10px;">
            <asp:Label ID="LabelMonthList" runat="server" Text="Месяц:" 
                CssClass="viewMode"></asp:Label>  
            <asp:DropDownList runat="server" ID="MonthList" Width="120px">
            </asp:DropDownList>            
            </div>

            <div style="display: none" id="DatePickerDIVId">
            <eo:DatePicker ID="DatePickerGlobalDay" runat="server" 
            DayHeaderFormat="FirstLetter" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
            DayCellHeight="16" OtherMonthDayVisible="True" DayCellWidth="19" 
               TitleRightArrowImageUrl="DefaultSubMenuIcon" ControlSkinID="None" 
               PickerFormat="dd.MM.yyyy" 
               CssBlock="" DisabledDates="" SelectedDates="">                
            <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
            </DayHoverStyle>
            <TitleStyle CssText="background-color:goldenrod;color:white;font-family:Tahoma;font-size:12px;font-weight:bold;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
            </TitleStyle>
            <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
            <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DayStyle>
            <SelectedDayStyle CssText="background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </SelectedDayStyle>
            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
            <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
            </TodayStyle>
            <PickerStyle CssText="font-family:Arial;padding-left:5px;padding-right:5px;">
            </PickerStyle>
            <OtherMonthDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </OtherMonthDayStyle>
            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
            </CalendarStyle>
            <DisabledDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DisabledDayStyle>
            <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma">
            </MonthStyle>
           </eo:DatePicker> 
           </div>

            <div style="display: none" id="DatePickerDIVInterval">
            <eo:DatePicker ID="DatePickerInterval1" runat="server" 
            DayHeaderFormat="FirstLetter" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
            DayCellHeight="16" OtherMonthDayVisible="True" DayCellWidth="19" 
               TitleRightArrowImageUrl="DefaultSubMenuIcon" ControlSkinID="None" 
               PickerFormat="dd.MM.yyyy" 
               CssBlock="" DisabledDates="" SelectedDates="">                
            <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
            </DayHoverStyle>
            <TitleStyle CssText="background-color:goldenrod;color:white;font-family:Tahoma;font-size:12px;font-weight:bold;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
            </TitleStyle>
            <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
            <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DayStyle>
            <SelectedDayStyle CssText="background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </SelectedDayStyle>
            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
            <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
            </TodayStyle>
            <PickerStyle CssText="font-family:Arial;padding-left:5px;padding-right:5px;">
            </PickerStyle>
            <OtherMonthDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </OtherMonthDayStyle>
            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
            </CalendarStyle>
            <DisabledDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DisabledDayStyle>
            <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma">
            </MonthStyle>
           </eo:DatePicker> 

            <eo:DatePicker ID="DatePickerInterval2" runat="server" 
            DayHeaderFormat="FirstLetter" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
            DayCellHeight="16" OtherMonthDayVisible="True" DayCellWidth="19" 
               TitleRightArrowImageUrl="DefaultSubMenuIcon" ControlSkinID="None" 
               PickerFormat="dd.MM.yyyy" 
               CssBlock="" DisabledDates="" SelectedDates="">                
            <DayHoverStyle CssText="border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid">
            </DayHoverStyle>
            <TitleStyle CssText="background-color:goldenrod;color:white;font-family:Tahoma;font-size:12px;font-weight:bold;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;">
            </TitleStyle>
            <DayHeaderStyle CssText="border-bottom: #aca899 1px solid"></DayHeaderStyle>
            <DayStyle CssText="border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DayStyle>
            <SelectedDayStyle CssText="background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </SelectedDayStyle>
            <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
            <TodayStyle CssText="border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid">
            </TodayStyle>
            <PickerStyle CssText="font-family:Arial;padding-left:5px;padding-right:5px;">
            </PickerStyle>
            <OtherMonthDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </OtherMonthDayStyle>
            <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma">
            </CalendarStyle>
            <DisabledDayStyle CssText="color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid">
            </DisabledDayStyle>
            <MonthStyle CssText="font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px; font-family: tahoma">
            </MonthStyle>
           </eo:DatePicker> 
           </div>

           <br />         
        </asp:Panel>
                
        </div>
        </div>
                                      
        <div style="float:left; margin-top:4px; margin-left: 25px;">
            <p></p>
            <asp:Button runat="server" Text="применить" ID="SetGlobalIntervalBtn" 
                CssClass="buttonLabel" onclick="SetGlobalIntervalBtn_Click"/>
        </div>
     </eo:CallbackPanel>               
    
    <script src="j_period_controls.js" type="text/javascript"></script>

    <div style="border-top-style: solid; border-top-width: 2px; border-top-color: #663300;">                     
    <p></p>      
    </div>

    <eo:CallbackPanel runat="server" Height="150px" Width="200px" ID="EOCBPMain" 
            onexecute="EOCBPMain_Execute"             
            Triggers="{ControlID:MeteoGrid;Parameter:},{ControlID:AiiskueGrid;Parameter:},{ControlID:SetGlobalIntervalBtn;Parameter:}">
            
    <eo:TabStrip runat="server" ID="TabStrip1" ControlSkinID="None" 
            MultiPageID="MultiPage1">
            <LookItems>
                <eo:TabItem Image-BackgroundRepeat="RepeatX" Image-Mode="TextBackground" 
                    Image-SelectedUrl="00010225" Image-Url="00010222" ItemID="_Default" 
                    LeftIcon-SelectedUrl="00010224" LeftIcon-Url="00010221" 
                    NormalStyle-CssText="color: #606060" RightIcon-SelectedUrl="00010226" 
                    RightIcon-Url="00010223" 
                    SelectedStyle-CssText="color: #2f4761; font-weight: bold;">
                    <SubGroup OverlapDepth="8" 
                        Style-CssText="font-family: arial; font-size: 9pt; background-image: url(00010220); background-repeat: repeat-x; cursor: hand;">
                    </SubGroup>
                </eo:TabItem>
            </LookItems>
            <TopGroup>
                <Items>
                    <eo:TabItem Text-Html="Учет электроэнергии">                      
                    </eo:TabItem>
                    <eo:TabItem Text-Html="Погодные условия">                        
                    </eo:TabItem>
                    <eo:TabItem Text-Html="Метеозависимость">
                    </eo:TabItem>
                    <eo:TabItem Text-Html="Коэффициент использования установленной мощности">
                    </eo:TabItem>
                </Items>
            </TopGroup>
    </eo:TabStrip>
    <eo:MultiPage runat="server" Height='180px' Width='100%' ID="MultiPage1" 
            onload="MultiPage1_Load">
        
            <eo:PageView ID="PageView1" runat="server" Width="100%">
            <br />
                    
        <p style="clear:both"></p>
        
        <asp:Chart runat="server" ID="ChartGenPotr" 
            ImageLocation="~/images/charts/chart5.png" ImageStorageMode="UseImageLocation" 
            Width="970px" DataSourceID="SqlDataSourceTotalGen" Height="400px">
            <Series>
                <asp:Series Name="Генерация" ChartType="Line" 
                    CustomProperties="DrawingStyle=Cylinder" Legend="Legend1" BorderWidth="3" 
                    XValueMember="date_time" YValueMembers="value_gen_total_kilo" 
                    IsValueShownAsLabel="True" LabelBackColor="SteelBlue" LabelBorderColor="Black" 
                    LabelForeColor="White" LabelFormat="{0:f}" MarkerBorderColor="SteelBlue" 
                    MarkerColor="White" MarkerStyle="Circle" YValuesPerPoint="6">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Line" 
                    CustomProperties="DrawingStyle=Cylinder" Legend="Legend1" 
                    Name="Потребление" BorderWidth="3" XValueMember="date_time" 
                    YValueMembers="value_poselok_kilo" IsValueShownAsLabel="True" 
                    LabelBackColor="DarkGoldenrod" LabelBorderColor="Black" LabelForeColor="White" 
                    LabelFormat="{0:f}" MarkerBorderColor="Goldenrod" MarkerColor="White" 
                    MarkerStyle="Circle" YValuesPerPoint="6">
                </asp:Series>
                <asp:Series BorderWidth="3" ChartArea="ChartArea1" ChartType="Line" 
                    Color="0, 192, 0" IsValueShownAsLabel="True" LabelBackColor="Green" 
                    LabelBorderColor="Black" LabelForeColor="White" LabelFormat="{0:f}" 
                    Legend="Legend1" MarkerBorderColor="Green" MarkerColor="White" 
                    MarkerStyle="Circle" Name="Собственные нужды" XValueMember="date_time" 
                    YValueMembers="value_sn_kilo">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX Interval="1" IntervalAutoMode="VariableCount" IntervalType="Days" 
                        IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Angle="-45" Format="g" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" Alignment="Center" Docking="Top">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Генерация и потребление, кВт·ч">
                </asp:Title>
            </Titles>
        </asp:Chart>

        <asp:Chart runat="server" ID="ChartGenEnergy2" 
            DataSourceID="SqlDataSourceTotalGen" ImageLocation="~/images/charts/chart6.png" 
            ImageStorageMode="UseImageLocation" Width="970px" Height="400px">
            <Series>
                <asp:Series Name="Дизельный генератор" ChartType="StackedColumn" 
                    CustomProperties="DrawingStyle=Cylinder" XValueMember="date_time" 
                    YValueMembers="value_diesel_kilo" Legend="Legend1" 
                    Font="Microsoft Sans Serif, 8pt" IsValueShownAsLabel="True" 
                    LabelBackColor="SteelBlue" LabelBorderColor="Black" LabelForeColor="White" 
                    LabelFormat="{0:f}">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder" 
                    Name="Солнечные панели" XValueMember="date_time" 
                    YValueMembers="value_sun_kilo" ChartType="StackedColumn" Legend="Legend1" 
                    Font="Microsoft Sans Serif, 8pt" IsValueShownAsLabel="True" 
                    LabelBackColor="DarkGoldenrod" LabelBorderColor="Black" LabelForeColor="White" 
                    LabelFormat="{0:f}">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder" 
                    Name="Ветрогенераторы" XValueMember="date_time" 
                    YValueMembers="value_wind_kilo" ChartType="StackedColumn" Legend="Legend1" 
                    Font="Microsoft Sans Serif, 8pt" IsValueShownAsLabel="True" 
                    LabelBackColor="IndianRed" LabelBorderColor="Black" LabelForeColor="White" 
                    LabelFormat="{0:f}">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX Interval="1" IntervalAutoMode="VariableCount" IntervalType="Days" 
                        IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Angle="-45" Format="g" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" Docking="Top" Alignment="Center">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Доля генерации, кВт·ч">
                </asp:Title>
            </Titles>
        </asp:Chart>

        <asp:Chart runat="server" ID="ChartGenEnergyWindSun" 
            DataSourceID="SqlDataSourceTotalGen" ImageLocation="~/images/charts/chart9.png" 
            ImageStorageMode="UseImageLocation" Width="970px" Height="400px">
            <Series>
                <asp:Series ChartArea="ChartArea1" ChartType="StackedBar" Enabled="False" 
                    Legend="Legend1" Name="Дизельный генератор">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder" 
                    Name="Солнечные панели" XValueMember="date_time" 
                    YValueMembers="value_sun_kilo" ChartType="StackedColumn" Legend="Legend1" 
                    Font="Microsoft Sans Serif, 8pt" IsValueShownAsLabel="True" 
                    LabelBackColor="DarkGoldenrod" LabelBorderColor="Black" LabelForeColor="White" 
                    LabelFormat="{0:f}">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder" 
                    Name="Ветрогенераторы" XValueMember="date_time" 
                    YValueMembers="value_wind_kilo" ChartType="StackedColumn" Legend="Legend1" 
                    Font="Microsoft Sans Serif, 8pt" IsValueShownAsLabel="True" 
                    LabelBackColor="IndianRed" LabelBorderColor="Black" LabelForeColor="White" 
                    LabelFormat="{0:f}">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX Interval="1" IntervalAutoMode="VariableCount" IntervalType="Days" 
                        IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Angle="-45" Format="g" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1" Alignment="Center" Docking="Top">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Доля генерации (солнечные панели и ветрогенераторы), кВт·ч">
                </asp:Title>
            </Titles>
        </asp:Chart>
                
        <asp:SqlDataSource runat="server" ID="SqlDataSourceTotalGen" 
            ConnectionString="<%$ ConnectionStrings:onguren_dbConnectionString2 %>" 
            SelectCommand="SELECT *, value_sun/1000 AS value_sun_kilo, value_diesel/1000 AS value_diesel_kilo, value_wind/1000 AS value_wind_kilo, value_sn/1000 AS value_sn_kilo, (value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo, value_poselok/1000 AS value_poselok_kilo FROM table_power" 
                    onload="SqlDataSourceTotalGen_Load">
        </asp:SqlDataSource>

        <asp:SqlDataSource runat="server" ID="SqlDataSourceTotalGenForZav" 
            ConnectionString="<%$ ConnectionStrings:onguren_dbConnectionString2 %>" 
            SelectCommand="SELECT date_time, value_sun/1000 AS value_sun_kilo, value_diesel/1000 AS value_diesel_kilo, value_wind/1000 AS value_wind_kilo, value_sn/1000 AS value_sn_kilo, (value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo, value_poselok/1000 AS value_poselok_kilo FROM table_power">
        </asp:SqlDataSource>
        
    <br />

    <asp:ImageButton runat="server" ID="btn2Excel" onclick="btn2Excel_Click" ToolTip="экспорт в Excel" ImageUrl="~/images/ico/excel.jpg" />
    <asp:LinkButton runat="server" ID="btn2Excel_url" onclick="btn2Excel_Click" Text="экспорт в Excel"></asp:LinkButton>
    <br /><br />

    <asp:GridView ID="AiiskueGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SQLDataSourceTotalGenDescSort" 
        AllowPaging="True" Font-Names="Arial" Font-Size="Small" 
            HorizontalAlign="Justify" Width="824px" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="value_date" DataFormatString="{0:d}" 
                    HeaderText="Период" SortExpression="value_date" />
                <asp:BoundField DataField="date_time" 
                    HeaderText="Время" SortExpression="date_time" 
                    DataFormatString="{0:t}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="value_y_m" DataFormatString="{0:Y}" 
                    HeaderText="Период" SortExpression="value_y_m">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="value_sun_kilo" HeaderText="Солнечные панели, кВт·ч" 
                    SortExpression="value_sun_kilo" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="value_diesel_kilo" DataFormatString="{0:f}" 
                    HeaderText="Дизельный генератор, кВт·ч" SortExpression="value_diesel_kilo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="value_wind_kilo" HeaderText="Ветрогенераторы, кВт·ч" 
                    SortExpression="value_wind_kilo" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="value_sn_kilo" HeaderText="Собственные нужды, кВт·ч" 
                    SortExpression="value_sn_kilo" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="value_poselok_kilo" HeaderText="Отдано в распределительную сеть, кВт·ч" 
                    SortExpression="value_poselok_kilo" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle Font-Bold="False" Font-Names="Arial" Font-Size="Small" 
                BackColor="#5D7B9D" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
            <RowStyle ForeColor="#333333" Wrap="True" BackColor="#F7F6F3" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        
        <asp:SqlDataSource ID="SQLDataSourceTotalGenDescSort" runat="server" 
            ConnectionString="<%$ ConnectionStrings:onguren_dbConnectionString2 %>" 
            SelectCommand="SELECT date_time, value_date, value_month, value_year, value_sun/1000 AS value_sun_kilo, value_diesel/1000 AS value_diesel_kilo, value_wind/1000 AS value_wind_kilo, value_sn/1000 AS value_sn_kilo, (value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo, value_poselok/1000 AS value_poselok_kilo FROM table_power ORDER BY date_time" 
            ProviderName="<%$ ConnectionStrings:onguren_dbConnectionString2.ProviderName %>">
        </asp:SqlDataSource>
        </div>
                    
            </eo:PageView>
            
    <eo:PageView ID="PageView2" runat="server" Width="100%">
            <br />
                
        <p style="clear:both"></p>
                        
        <asp:Chart runat="server" ID="ChartMeteoT" 
            ImageLocation="~/images/charts/chart1.png" ImageStorageMode="UseImageLocation" 
            Width="920px" DataSourceID="SqlDataSourceMeteo" Height="350px" Palette="None">
            <Series>
                <asp:Series Name="Температура воздуха" ChartType="Line" 
                    CustomProperties="DrawingStyle=Cylinder" BorderWidth="3" 
                    XValueMember="date_time" YValueMembers="temp" Color="0, 192, 0" 
                    MarkerBorderColor="0, 192, 0" MarkerColor="White">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Format="g" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Температура воздуха, °С">
                </asp:Title>
            </Titles>
        </asp:Chart>
        <br />

        <asp:Chart runat="server" ID="ChartMeteoInsolation" 
            ImageLocation="~/images/charts/chart3.png" ImageStorageMode="UseImageLocation" 
            Width="920px" DataSourceID="SqlDataSourceMeteo" Height="350px" Palette="None">
            <Series>
                <asp:Series Name="Освещенность" ChartType="Line" 
                    CustomProperties="DrawingStyle=Cylinder" BorderWidth="3" 
                    XValueMember="date_time" YValueMembers="insolation" Color="255, 128, 0"
                     MarkerBorderColor="255, 128, 0" MarkerColor="White">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Format="g" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Освещенность, Вт/м2">
                </asp:Title>
            </Titles>
        </asp:Chart>
        <br />

        <asp:Chart runat="server" ID="ChartMeteoWindSpeed" 
            ImageLocation="~/images/charts/chart4.png" ImageStorageMode="UseImageLocation" 
            Width="920px" DataSourceID="SqlDataSourceMeteo" Height="350px">
            <Series>
                <asp:Series Name="Скорость ветра" ChartType="Line" 
                    CustomProperties="DrawingStyle=Cylinder" BorderWidth="3" 
                    XValueMember="date_time" YValueMembers="wind_speed"
                     MarkerBorderColor="SteelBlue" MarkerColor="White">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY>
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX IsLabelAutoFit="False" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Format="g" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Скорость ветра, м/с">
                </asp:Title>
            </Titles>
        </asp:Chart>

        <div style="margin-left: 300px">
        <asp:Chart ID="ChartWindRose" runat="server" 
            ImageLocation="~/images/charts/chart2.png" 
            ImageStorageMode="UseImageLocation" BorderlineColor="LightGray" 
            BorderlineDashStyle="Solid" Palette="None" PaletteCustomColors="SteelBlue">
            <Series>
                <asp:Series ChartType="Radar" Name="Series1" XValueMember="wind_direct_id" 
                    YValueMembers="c_wind_dir" BorderWidth="3" LabelBackColor="0, 192, 0" 
                    LabelBorderColor="Black" MarkerBorderColor="SteelBlue" MarkerColor="White" 
                    MarkerStyle="Circle">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" AlignmentOrientation="All">
                    <AxisY Interval="10" Minimum="0" LineColor="Gray" LineDashStyle="Dot">
                        <MajorTickMark LineColor="Yellow" Enabled="False" />
                        <MajorGrid LineColor="Silver" LineDashStyle="Dot" />
                        <LabelStyle Enabled="False" />
                    </AxisY>
                    <AxisX Interval="1" 
                        Maximum="10" Minimum="0" Enabled="True" IntervalAutoMode="VariableCount" 
                        IntervalOffset="1" IntervalOffsetType="Number" LineDashStyle="Dot">
                        <MajorGrid LineColor="Lime" Enabled="False" />
                        <MinorGrid LineColor="Red" />
                        <MajorTickMark LineColor="RoyalBlue" Enabled="False" />
                        <MinorTickMark LineColor="OrangeRed" />
                        <CustomLabels>
                            <asp:CustomLabel Text="с" />
                            <asp:CustomLabel Text="св" />
                            <asp:CustomLabel Text="в" />
                            <asp:CustomLabel Text="юв" />
                            <asp:CustomLabel Text="ю" />
                            <asp:CustomLabel Text="юз" />
                            <asp:CustomLabel Text="з" />
                            <asp:CustomLabel Text="сз" />
                        </CustomLabels>
                    </AxisX>
                    <AxisX2 Interval="1" Maximum="10" Minimum="0">
                    </AxisX2>
                    <AxisY2 LineWidth="0">
                    </AxisY2>
                    <Area3DStyle Inclination="10" Rotation="10" WallWidth="27" />
                </asp:ChartArea>
            </ChartAreas>
            <Titles>
                <asp:Title Font="Arial, 10pt, style=Bold" Name="Title1" Text="Роза ветров">
                </asp:Title>
            </Titles>
    </asp:Chart>
    </div>

    <asp:SqlDataSource ID="SqlDataSourceMeteoRepWind" runat="server" 
            ConnectionString="<%$ ConnectionStrings:onguren_dbConnectionString2 %>"     
                SelectCommand="SELECT wind_direct_id, COUNT(*) AS c_wind_dir FROM table_meteo WHERE value_date&gt;='01.01.1910' and value_date&lt;='01.01.1910' GROUP BY wind_direct_id">
    </asp:SqlDataSource>    
    <p></p><p></p>
        
    <asp:ImageButton runat="server" ID="btn2Excel_meteo" onclick="btn2Excel_meteo_Click" ToolTip="экспорт в Excel" ImageUrl="~/images/ico/excel.jpg" />
    <asp:LinkButton runat="server" ID="btn2Excel_url_meteo" onclick="btn2Excel_meteo_Click" Text="экспорт в Excel"></asp:LinkButton>
    <br /><br />

    <asp:GridView ID="MeteoGrid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceMeteo" 
        AllowPaging="True" Font-Names="Arial" Font-Size="Small" 
            HorizontalAlign="Center" Width="824px" CellPadding="4" 
            GridLines="None" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="date_time" HeaderText="Дата/Время" 
                    SortExpression="date_time" DataFormatString="{0:g}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="False" />
                </asp:BoundField>
                <asp:BoundField DataField="temp" HeaderText="Температура, °С" 
                    SortExpression="temp" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="vlaga" 
                    HeaderText="Влажность, %" SortExpression="vlaga" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="wind_speed" HeaderText="Скорость ветра, м/с" 
                    SortExpression="wind_speed" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="wind_direct_id" 
                    DataImageUrlFormatString="images/weather/wind/wind{0}.png" 
                    HeaderText="Направление ветра">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:ImageField>
                <asp:BoundField DataField="insolation" HeaderText="Освещенность, Вт/м2" 
                    SortExpression="insolation" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="pressure_gPa" HeaderText="Давление, гПа" 
                    SortExpression="pressure_gPa" DataFormatString="{0:f}" Visible="False">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="pressure_mm" HeaderText="Давление, мм рт. ст." 
                    SortExpression="pressure_mm" DataFormatString="{0:f}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle Font-Bold="True" />
            <HeaderStyle Font-Bold="False" Font-Names="Arial" Font-Size="Small" 
                BackColor="#5D7B9D" ForeColor="White" />
            <PagerStyle HorizontalAlign="Left" BackColor="#284775" ForeColor="White" />
            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        
        <asp:SqlDataSource ID="SqlDataSourceMeteo" runat="server" 
        ConnectionString="<%$ ConnectionStrings:onguren_dbConnectionString2 %>" 
        
            SelectCommand="SELECT [temp], [vlaga], [wind_speed], [wind_direct], [insolation], [date_time], [pressure_mm], [pressure_gPa], [wind_direct_id] FROM [table_meteo] ORDER BY [date_time] DESC" 
            
            ProviderName="<%$ ConnectionStrings:onguren_dbConnectionString2.ProviderName %>">
    </asp:SqlDataSource>
    </div>
    
    </eo:PageView>

            <eo:PageView ID="PageView3" runat="server" Width="100%">
    
    <br />

    <asp:Chart runat="server" ID="ChartGenSunFromMeteo" 
            ImageLocation="~/images/charts/chart8.png" ImageStorageMode="UseImageLocation" 
            Width="970px" Height="400px">
            <Series>
                <asp:Series Name="Генерация" CustomProperties="DrawingStyle=Cylinder" 
                    Legend="Legend1" XValueType="DateTime" ChartType="Line" BorderWidth="3"
                    MarkerBorderColor="SteelBlue" MarkerColor="White">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder" 
                    Legend="Legend1" Name="Освещенность" XValueType="DateTime" 
                    ChartType="Line" XAxisType="Secondary" YAxisType="Secondary" 
                    BorderWidth="3" MarkerBorderColor="Goldenrod" MarkerColor="White">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY Enabled="True" Title="кВт·ч">
                        <MajorGrid Enabled="True" LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX LabelAutoFitStyle="WordWrap" Enabled="True">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Format="g" />
                    </AxisX>
                    <AxisX2 Enabled="True" LabelAutoFitStyle="WordWrap">
                        <MajorGrid Enabled="False" LineDashStyle="Dot" />
                        <LabelStyle Format="g" Enabled="False" />
                    </AxisX2>
                    <AxisY2 Enabled="True" Title="Вт/м2">
                        <MajorGrid Enabled="False" LineDashStyle="Dot" />
                    </AxisY2>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend IsTextAutoFit="False" LegendStyle="Column" Name="Legend1" 
                    TextWrapThreshold="15">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Генерация (солнечные панели) / Освещенность">
                </asp:Title>
            </Titles>
        </asp:Chart>

    <asp:Chart runat="server" ID="ChartGenWindFromMeteo" 
            ImageLocation="~/images/charts/chart7.png" ImageStorageMode="UseImageLocation" 
            Width="970px" Height="400px">
            <Series>
                <asp:Series Name="Генерация" CustomProperties="DrawingStyle=Cylinder" 
                    Legend="Legend1" XValueType="DateTime" ChartType="Line" BorderWidth="3"
                    MarkerBorderColor="SteelBlue" MarkerColor="White">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" CustomProperties="DrawingStyle=Cylinder" 
                    Legend="Legend1" Name="Скорость ветра" XValueType="DateTime" 
                    ChartType="Line" XAxisType="Secondary" YAxisType="Secondary" 
                    BorderWidth="3" MarkerBorderColor="Goldenrod" MarkerColor="White">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisY Enabled="True" Title="кВт·ч">
                        <MajorGrid LineDashStyle="Dot" />
                    </AxisY>
                    <AxisX LabelAutoFitStyle="WordWrap" Enabled="True">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Format="g" />
                    </AxisX>
                    <AxisX2 Enabled="True" LabelAutoFitStyle="WordWrap">
                        <MajorGrid LineDashStyle="Dot" />
                        <LabelStyle Format="g" Enabled="False" />
                    </AxisX2>
                    <AxisY2 Enabled="True" Title="м/с">
                        <MajorGrid Enabled="False" LineDashStyle="Dot" />
                    </AxisY2>
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend IsTextAutoFit="False" LegendStyle="Column" Name="Legend1" 
                    TextWrapThreshold="15">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Font="Microsoft Sans Serif, 10pt, style=Bold" Name="Title1" 
                    Text="Генерация (ветрогенераторы) / Скорость ветра">
                </asp:Title>
            </Titles>
        </asp:Chart>

        </eo:PageView>

        <eo:PageView ID="PageView4" runat="server" Width="100%">
            <br />            

            <asp:SqlDataSource runat="server" ID="SqlDataSourceKIUM" 
            ConnectionString="<%$ ConnectionStrings:onguren_dbConnectionString2 %>" 
            SelectCommand="SELECT value_year, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE value_year='2012' GROUP BY value_year" 
                    onload="SqlDataSourceTotalGen_Load">
            </asp:SqlDataSource>

            <asp:Label runat="server" Text="Расчеты произведены за весь период наблюдений" Font-Bold="True"></asp:Label>
            <p></p>
            
            <asp:Table runat="server" ID="KUIMTable" 
                HorizontalAlign="Center" BorderStyle="NotSet" Font-Names="arial" 
                Font-Size="10pt" GridLines="Horizontal">
                <asp:TableRow runat="server" HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server">Ед. изм.</asp:TableCell>
                    <asp:TableCell runat="server">Дизельный генератор</asp:TableCell>
                    <asp:TableCell runat="server">Солнечные панели</asp:TableCell>
                    <asp:TableCell runat="server">Ветрогенераторы</asp:TableCell>
                    <asp:TableCell runat="server">Всего</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server">Установленная мощность</asp:TableCell>
                    <asp:TableCell runat="server">кВт</asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server">Располагаемая мощность</asp:TableCell>
                    <asp:TableCell runat="server">кВт</asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server">Производство</asp:TableCell>
                    <asp:TableCell runat="server">кВт·ч</asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center">
                    <asp:TableCell runat="server">Потребление</asp:TableCell>
                    <asp:TableCell runat="server">кВт·ч</asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                    <asp:TableCell runat="server">Коэффициент использования установленной мощности</asp:TableCell>
                    <asp:TableCell runat="server">%</asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </eo:PageView>

    </eo:MultiPage>
    </eo:CallbackPanel>
                    
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MeteoHolder" Runat="Server">
    
</asp:Content>

    <asp:Content ID="Content6" ContentPlaceHolderID="RightHolder" Runat="Server">
    </asp:Content>
        
    <asp:Content ID="Content9" ContentPlaceHolderID="FooterHolder" Runat="Server">    
        <div class="footerStyle" style="footerStyle">
        © 2012 Министерство жилищной политики и энергетики Иркутской области
        </div>
        <br />
    </asp:Content>




