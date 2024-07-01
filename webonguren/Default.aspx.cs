using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

public partial class MainForm : System.Web.UI.Page
{
    protected void Application_Start(Object sender, EventArgs e)
    {
        // устранение ошибки "Eo.Web"
        EO.Web.Runtime.DebugLevel = 0;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DateTime now_date = DateTime.Now;
            //this.DatePickerGlobalDay.SelectedDateString = now_date.AddDays(-1).ToShortDateString();
            this.DatePickerGlobalDay.SelectedDateString = "02.02.2014";
            
            //----------------------------------                       
            string[] monthNames = {"Январь","Февраль","Март","Апрель","Май","Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"};
            this.MonthList.DataSource = monthNames;
            this.MonthList.DataBind();
            //this.MonthList.SelectedIndex = now_date.Month-1;
            this.MonthList.SelectedIndex = 7;

            string[] yearNames = { "2015", "2014", "2013", "2012" };
            this.YearList.DataSource = yearNames;
            this.YearList.DataBind();
            this.YearList.SelectedIndex = 1;

            //this.YearList.SelectedValue = now_date.Year.ToString();
            //----------------------------------
            /*this.Slide1.DataSource = new string[]
            {          
            "~/Images/slideshow/slide1.jpg",                      
            "~/Images/slideshow/slide1_1.jpg",                      
            "~/Images/slideshow/slide2.jpg",                      
            "~/Images/slideshow/slide3.jpg",                      
            "~/Images/slideshow/slide4.jpg",
            "~/Images/slideshow/slide5.jpg"
            };           
            this.Slide1.DataBind();            
            this.Slide1.Interval = 10000;            
            this.Slide1.AutoStart = true;*/
        }

        //DrawWindRoseChart("01.11.2012", "01.11.2012");

//        DrawWindGenerateFromMeteoChart();
  //      DrawSunGenerateFromMeteoChart();
        //Slide1.Interval = 10000;
    }
    protected void IsAiiskueGraphView_CheckedChanged(object sender, EventArgs e)
    {
        //убрать
    }
    protected void IsAiiskueTableView_CheckedChanged(object sender, EventArgs e)
    {
        //убрать
    }
        
    protected void DrawWindRoseChart(string start_date,string end_date)
    {
        string fexpr = "";
        switch (this.RadioButtonPeriodType.SelectedValue)
        {
            case "День":
                fexpr = "date_time>'" + start_date + "' and date_time<='" + end_date + "'";
                break;
            case "Месяц":
                fexpr = "value_date>='" + start_date + "' and value_date<='" + end_date + "'";
                break;
            case "Год": //???
                fexpr = "value_date>='" + start_date + "' and value_date<='" + end_date + "'";
                break;
        }

        string sel_str = "SELECT wind_direct_id, COUNT(*) AS c_wind_dir FROM table_meteo WHERE "+fexpr+" GROUP BY wind_direct_id";

        this.ChartWindRose.Series[0].Points.Clear();
        this.SqlDataSourceMeteoRepWind.SelectCommand = sel_str;
        
        DataView dv = (DataView)this.SqlDataSourceMeteoRepWind.Select(DataSourceSelectArguments.Empty);
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!! { 5, 7 }
        int[,] wr = new int[8, 2] { { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 } };

        //--
        //this.ChartWindRose.Titles[0].Text = start_date + " / " + end_date;
        //this.TextBoxTemp.Text = sel_str;
        //this.GridViewTemp.DataBind();
        //--

        //LabelTemp.Text = dv.Table.Rows.Count.ToString();
        //LabelTemp.Text = dv.Table.Columns.Count.ToString();
        for (int i = 0; i < dv.Table.Rows.Count; i++)
        {
            string wid_str = dv.Table.Rows[i]["wind_direct_id"].ToString();
            string wc_str = dv.Table.Rows[i]["c_wind_dir"].ToString();
            int wid = Convert.ToInt16(wid_str);
            int wc = Convert.ToInt16(wc_str);
            wr[wid, 1] = wc;
        }

        int count_0_winds = 0;
        for (int i = 0; i < 8; i++)
        {
            this.ChartWindRose.Series[0].Points.AddXY(wr[i, 0], wr[i, 1]);
            if (wr[i, 1] == 0) count_0_winds++;
        }

        if (count_0_winds == 7) this.ChartWindRose.Series[0].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.Circle;
        else this.ChartWindRose.Series[0].MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
    }

    protected void DrawGenerateDeltaChart()
    {
        /*DataView dv = (DataView)this.SqlDataSourceGenDiesel.Select(DataSourceSelectArguments.Empty);
        this.ChartGenEnergy.Series[0].Points.DataBind(dv, "date_time_diesel", "value_dieselkilo", "");
        
        dv = (DataView)this.SqlDataSourceGenSun.Select(DataSourceSelectArguments.Empty);
        this.ChartGenEnergy.Series[1].Points.DataBind(dv, "date_time_sun", "value_sunkilo", "");
                       
        dv = (DataView)this.SqlDataSourceGenWind.Select(DataSourceSelectArguments.Empty);
        this.ChartGenEnergy.Series[2].Points.DataBind(dv, "date_time_wind", "value_windkilo", "");           */

        /*dv = (DataView)this.SqlDataSourceGenPoselok.Select(DataSourceSelectArguments.Empty);
        this.ChartGenEnergy.Series[4].Points.DataBind(dv, "date_time_pos", "value_poskilo", "");

        dv = (DataView)this.SqlDataSourceGenPotreblenie.Select(DataSourceSelectArguments.Empty);
        this.ChartGenEnergy.Series[3].Points.DataBind(dv, "date_time_potr", "value_potrkilo", "");*/

        //-------------------------------------------------------------------------
        // рисование диаграммы генерации/потребления
        //dv = (DataView)this.SqlDataSourceGenPoselok.Select(DataSourceSelectArguments.Empty);
        //this.ChartGenPotr.Series[1].Points.DataBind(dv, "date_time_pos", "value_poskilo", "");           
    }
        
    protected void DrawWindGenerateFromMeteoChart()
    {
        DataView dv;

        DateTime start_date = GetGlobalStartDate();
        DateTime end_date = GetGlobalEndDate();
        this.ChartGenWindFromMeteo.ChartAreas[0].AxisX.Minimum = start_date.ToOADate();
        this.ChartGenWindFromMeteo.ChartAreas[0].AxisX2.Minimum = start_date.ToOADate();
        this.ChartGenWindFromMeteo.ChartAreas[0].AxisX.Maximum = end_date.ToOADate();
        this.ChartGenWindFromMeteo.ChartAreas[0].AxisX2.Maximum = end_date.ToOADate();

        dv = (DataView)this.SqlDataSourceMeteo.Select(DataSourceSelectArguments.Empty);        
        this.ChartGenWindFromMeteo.Series[1].Points.DataBind(dv, "date_time", "wind_speed", "");
                
        //dv = (DataView)this.SqlDataSourceTotalGen.Select(DataSourceSelectArguments.Empty);
        dv = (DataView)this.SqlDataSourceTotalGenForZav.Select(DataSourceSelectArguments.Empty);
        this.ChartGenWindFromMeteo.Series[0].Points.DataBind(dv, "date_time", "value_wind_kilo", "");
    }

    protected void DrawSunGenerateFromMeteoChart()
    {
        DataView dv;

        DateTime start_date = GetGlobalStartDate();
        DateTime end_date = GetGlobalEndDate();
        this.ChartGenSunFromMeteo.ChartAreas[0].AxisX.Minimum = start_date.ToOADate();
        this.ChartGenSunFromMeteo.ChartAreas[0].AxisX2.Minimum = start_date.ToOADate();
        this.ChartGenSunFromMeteo.ChartAreas[0].AxisX.Maximum = end_date.ToOADate();
        this.ChartGenSunFromMeteo.ChartAreas[0].AxisX2.Maximum = end_date.ToOADate();

        dv = (DataView)this.SqlDataSourceMeteo.Select(DataSourceSelectArguments.Empty);        
        this.ChartGenSunFromMeteo.Series[1].Points.DataBind(dv, "date_time", "insolation", "");

        //dv = (DataView)this.SqlDataSourceTotalGen.Select(DataSourceSelectArguments.Empty);
        dv = (DataView)this.SqlDataSourceTotalGenForZav.Select(DataSourceSelectArguments.Empty);
        this.ChartGenSunFromMeteo.Series[0].Points.DataBind(dv, "date_time", "value_sun_kilo", "");
    }
    
    protected void EOCBP1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        //Label11.Text = "Oooops!";
    }
    
    protected void SetGenIntervalBtn_Click(object sender, EventArgs e)
    {
      /*  string fexpr_aiiskue = "";
      
        fexpr_aiiskue = "date_time>='" + this.DatePickerGen1.SelectedDate + "' and date_time<='" + this.DatePickerGen2.SelectedDate + "'";

        this.SqlDataSourceTotalGen.FilterExpression = fexpr_aiiskue;
        this.SQLDataSourceTotalGenDescSort.FilterExpression = fexpr_aiiskue;
      
        DrawWindGenerateFromMeteoChart();
        DrawSunGenerateFromMeteoChart();*/
    }
    
    protected void SetMeteoIntervalBtn_Click(object sender, EventArgs e)
    {
/*        string fexpr = "";
        
        fexpr = "date_time>='" + this.DatePickerMeteo1.SelectedDate + "' and date_time<='" + this.DatePickerMeteo2.SelectedDate + "'";

        this.SqlDataSourceMeteo.FilterExpression = fexpr;
        this.SqlDataSourceMeteoRepWind.FilterExpression = fexpr;
                
        DrawWindGenerateFromMeteoChart();
        DrawSunGenerateFromMeteoChart();*/
    }

    protected DateTime GetGlobalStartDate()
    {
        string start_date = "";
        DateTime rValue = DateTime.Today;

        switch (this.RadioButtonPeriodType.SelectedValue)
        {
            case "День":
                rValue = this.DatePickerGlobalDay.SelectedDate;        
                break;
            case "Месяц":
                start_date = "01."+(this.MonthList.SelectedIndex+1).ToString()+".";
                start_date += this.YearList.SelectedValue.ToString();                
                start_date += " 00:00:00";
                rValue = Convert.ToDateTime(start_date);
                break;
            case "Год":
                start_date = "01.01." + this.YearList.SelectedValue;

                //if (this.YearList.SelectedIndex == 0) start_date = "01.01.2013";
                //if (this.YearList.SelectedIndex == 1) start_date = "01.01.2012";
                //start_date = "01.01." + this.YearList.Text;

                rValue = Convert.ToDateTime(start_date);
                break;
            case "Период":
                rValue = this.DatePickerInterval1.SelectedDate;        
                break;
        }
        //----------------------
        /*if (this.GlobalPeriodIsDay.Checked) rValue = this.DatePickerGlobalDay.SelectedDate;        
        
        if (this.GlobalPeriodIsMounth.Checked)
        {
            if (this.MonthList.SelectedValue == "Ноябрь") start_date = "01.11.2012 00:00:00";        
            
            else
                if (this.MonthList.SelectedValue == "Декабрь") start_date = "01.12.2012 00:00:00";                    
                
            rValue = Convert.ToDateTime(start_date);
        }*/

        return rValue;
    }

    protected DateTime GetGlobalEndDate()
    {        
        DateTime rValue = GetGlobalStartDate();
        //DateTime start_date = GetGlobalStartDate();

        switch (this.RadioButtonPeriodType.SelectedValue)
        {
            case "День":
                rValue = rValue.AddDays(1);
                break;
            case "Месяц":
                string syear = this.YearList.SelectedValue;
                int smonth = this.MonthList.SelectedIndex + 1;
                int c_days_month = DateTime.DaysInMonth(Convert.ToInt16(syear), smonth);
                rValue = rValue.AddDays(c_days_month);
                break;
            case "Год":                
                //rValue = Convert.ToDateTime("01.01." + (Convert.ToInt16(this.YearList.SelectedValue)+1).ToString());
                rValue = Convert.ToDateTime("01.01." + (Convert.ToInt16(this.YearList.SelectedValue)+1).ToString());
                break;
            case "Период":
                rValue = this.DatePickerInterval2.SelectedDate;
                break;
        }
        //------------------
        /*if (this.GlobalPeriodIsDay.Checked) rValue = rValue.AddDays(1);
        if (this.GlobalPeriodIsMounth.Checked)
        {
            if (this.MonthList.SelectedValue == "Ноябрь") rValue = Convert.ToDateTime("01.12.2012 00:00:00");
            if (this.MonthList.SelectedValue == "Декабрь") rValue = Convert.ToDateTime("01.01.2013 00:00:00");
        }*/

        return rValue;
    }
    
    protected void SetGlobalIntervalBtn_Click(object sender, EventArgs e)
    {
        //Slide1.AutoStart = true;        
        
        // установка "глобального" периода
        string fexpr_standard = "";        
        
        DateTime start_date = this.GetGlobalStartDate();
        DateTime end_date = this.GetGlobalEndDate();
        //fexpr_standard = "date_time>='" + start_date + "' and date_time<='" + end_date + "'";
        
        // отбрасывание "предыдущих 00:00"
        fexpr_standard = "date_time>'" + start_date + "' and date_time<='" + end_date + "'";
        //this.ChartMeteoT.Titles[0].Text = fexpr_standard;

        //--- отображение генерации
        string date_label_format = "t";
        string fexpr_generation = "";
        string xvalue_generation = "";
        bool show_metka_generation = false;

        bool show_meteo_markers = false;

        string fexpr1 = "";
        switch (this.RadioButtonPeriodType.SelectedValue)
        {
            case "День":
                fexpr_generation = "SELECT date_time, value_sun/1000 AS value_sun_kilo, value_diesel/1000 AS value_diesel_kilo, value_wind/1000 AS value_wind_kilo, value_sn/1000 AS value_sn_kilo, value_poselok/1000 AS value_poselok_kilo, (value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE " + fexpr_standard;
                xvalue_generation = "date_time";

                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;

                this.AiiskueGrid.Columns[2].Visible = false;
                this.AiiskueGrid.Columns[1].Visible = true;
                this.AiiskueGrid.Columns[0].Visible = true;
                this.AiiskueGrid.DataSourceID = this.SQLDataSourceTotalGenDescSort.ID;

                this.AiiskueGrid.PageSize = 24;

                show_meteo_markers = true;
                break;

            case "Месяц":
                //fexpr1 = "value_month='" + start_date.Month + "'"; было
                fexpr1 = "value_year='" + start_date.Year + "'" + "and value_month='" + start_date.Month + "'";
                fexpr_generation = "SELECT value_year, value_month, value_date, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE "+fexpr1+" GROUP BY value_year, value_month, value_date";                
                xvalue_generation = "value_date";
                date_label_format = "d";                
                show_metka_generation = true;

                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Days;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Days;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Days;

                // масштабирование диаграммы
                this.ChartGenEnergy2.ChartAreas[0].AxisX.Minimum = start_date.ToOADate()-1;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.Maximum = end_date.ToOADate();
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.Minimum = start_date.ToOADate()-1;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.Maximum = end_date.ToOADate();
                //--------------------------

                this.AiiskueGrid.Columns[2].Visible = false;
                this.AiiskueGrid.Columns[1].Visible = false;
                this.AiiskueGrid.Columns[0].Visible = true;
                this.AiiskueGrid.DataSourceID = this.SqlDataSourceTotalGen.ID;

                this.AiiskueGrid.PageSize = 31;
                break;

            case "Год":
                fexpr1 = "value_year='" + start_date.Year + "'";
                //fexpr_generation = "SELECT value_year, value_month, value_date, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE " + fexpr1 + " GROUP BY value_year, value_month, value_date";                
                //fexpr_generation = "SELECT value_year, value_month, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE " + fexpr1 + " GROUP BY value_year, value_month";
                fexpr_generation = "SELECT value_year, value_month, CAST(('01.'+CAST(value_month as varchar)+'.'+CAST(value_year as varchar)) as date) AS value_y_m, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE " + fexpr1 + " GROUP BY value_year, value_month ORDER BY value_year, value_month";
                //fexpr_generation = "SELECT value_year, value_month, CAST('01.11.2012' as date) AS value_y_m, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE " + fexpr1 + " GROUP BY value_year, value_month";
                xvalue_generation = "value_y_m";
                date_label_format = "y";
                show_metka_generation = true;

                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Months;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Months;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Months;

                // масштабирование диаграммы
                this.ChartGenEnergy2.ChartAreas[0].AxisX.Minimum = start_date.ToOADate()-31;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.Maximum = end_date.ToOADate();
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.Minimum = start_date.ToOADate()-31;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.Maximum = end_date.ToOADate();
                //--------------------------

                this.AiiskueGrid.Columns[2].Visible = true;
                this.AiiskueGrid.Columns[1].Visible = false;
                this.AiiskueGrid.Columns[0].Visible = false;
                this.AiiskueGrid.DataSourceID = this.SqlDataSourceTotalGen.ID;

                this.AiiskueGrid.PageSize = 12;
                break;

            case "Период":
                //fexpr_standard = "date_time>'" + this.DatePickerInterval1.SelectedDate + "' and date_time<='" + this.DatePickerInterval1.SelectedDate + "'";
                fexpr_generation = "SELECT date_time, value_sun/1000 AS value_sun_kilo, value_diesel/1000 AS value_diesel_kilo, value_wind/1000 AS value_wind_kilo, value_sn/1000 AS value_sn_kilo, value_poselok/1000 AS value_poselok_kilo, (value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE " + fexpr_standard;
                xvalue_generation = "date_time";
                date_label_format = "g";  

                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenPotr.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergy2.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalOffsetType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.NotSet;
                this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Hours;

                this.AiiskueGrid.Columns[2].Visible = false;
                this.AiiskueGrid.Columns[1].Visible = true;
                this.AiiskueGrid.Columns[0].Visible = true;
                this.AiiskueGrid.DataSourceID = this.SQLDataSourceTotalGenDescSort.ID;

                this.AiiskueGrid.PageSize = 24;

                show_meteo_markers = true;
                break;
        }

        this.SqlDataSourceTotalGen.SelectCommand = fexpr_generation;
        //----------------------------
        this.ChartGenPotr.ChartAreas[0].AxisX.LabelStyle.Format = date_label_format;
        this.ChartGenEnergy2.ChartAreas[0].AxisX.LabelStyle.Format = date_label_format;
        this.ChartGenEnergyWindSun.ChartAreas[0].AxisX.LabelStyle.Format = date_label_format;
        //----------------------------
        this.ChartGenPotr.Series[0].XValueMember = xvalue_generation;
        this.ChartGenPotr.Series[1].XValueMember = xvalue_generation;
        this.ChartGenPotr.Series[2].XValueMember = xvalue_generation;

        this.ChartGenEnergy2.Series[0].XValueMember = xvalue_generation;
        this.ChartGenEnergy2.Series[1].XValueMember = xvalue_generation;
        this.ChartGenEnergy2.Series[2].XValueMember = xvalue_generation;
        //----------------------------        
        this.ChartGenEnergyWindSun.Series[1].XValueMember = xvalue_generation;
        this.ChartGenEnergyWindSun.Series[2].XValueMember = xvalue_generation;
        //----------------------------
        this.ChartGenPotr.Series[0].IsValueShownAsLabel = show_metka_generation;
        this.ChartGenPotr.Series[1].IsValueShownAsLabel = show_metka_generation;
        this.ChartGenPotr.Series[2].IsValueShownAsLabel = show_metka_generation;

        this.ChartGenEnergy2.Series[0].IsValueShownAsLabel = show_metka_generation;
        this.ChartGenEnergy2.Series[1].IsValueShownAsLabel = show_metka_generation;
        this.ChartGenEnergy2.Series[2].IsValueShownAsLabel = show_metka_generation;

        this.ChartGenEnergyWindSun.Series[1].IsValueShownAsLabel = show_metka_generation;
        this.ChartGenEnergyWindSun.Series[2].IsValueShownAsLabel = show_metka_generation;
        //----------------------------
        System.Web.UI.DataVisualization.Charting.MarkerStyle meteo_marker = System.Web.UI.DataVisualization.Charting.MarkerStyle.None;
        if (show_meteo_markers) meteo_marker = System.Web.UI.DataVisualization.Charting.MarkerStyle.Circle;
        this.ChartMeteoT.Series[0].MarkerStyle = meteo_marker;
        this.ChartMeteoWindSpeed.Series[0].MarkerStyle = meteo_marker;
        this.ChartMeteoInsolation.Series[0].MarkerStyle = meteo_marker;

        this.ChartGenSunFromMeteo.Series[0].MarkerStyle = meteo_marker;
        this.ChartGenSunFromMeteo.Series[1].MarkerStyle = meteo_marker;
        this.ChartGenWindFromMeteo.Series[0].MarkerStyle = meteo_marker;
        this.ChartGenWindFromMeteo.Series[1].MarkerStyle = meteo_marker;
        //-----------------------------------
        this.SqlDataSourceTotalGenForZav.FilterExpression = fexpr_standard;
        this.SQLDataSourceTotalGenDescSort.FilterExpression = fexpr_standard;
        this.SqlDataSourceMeteo.FilterExpression = fexpr_standard;

        //-----------------------------------
        this.SqlDataSourceMeteo.SelectCommand = "SELECT * FROM table_meteo WHERE " + fexpr_standard;        

        //-----------------------------------
        this.AiiskueGrid.DataBind();
        this.MeteoGrid.DataBind();
        this.MeteoGrid.PageIndex = this.MeteoGrid.PageCount - 1;
        //-----------------------------------
        if (this.RadioButtonPeriodType.SelectedValue != "Период") DrawWindRoseChart(start_date.ToString(),end_date.ToString());
        DrawWindGenerateFromMeteoChart();
        DrawSunGenerateFromMeteoChart();
        //-----------------------------------
        DrawKIUM();
        
        //Slide1.Interval = 10000;
        //Slide1.AutoStart = true;        
    }
    
    protected void EOCBPMain_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        // EOCallBackPanel
        //SetGlobalIntervalBtn_Click(sender, e);
    }
    protected void MultiPage1_Load(object sender, EventArgs e)
    {
        //this.SetGlobalIntervalBtn_Click(sender, e);
    }

    protected void FillYearList()
    {
    /*    string sel_str = "SELECT value_year FROM table_power GROUP BY value_year";
        this.SqlDataSourceTotalGen.SelectCommand = sel_str;
        DataView dv = (DataView)this.SqlDataSourceTotalGen.Select(DataSourceSelectArguments.Empty);
        this.YearList.Items.Clear();
        for (int i = 0; i < dv.Table.Rows.Count; i++) this.YearList.Items.Add(dv.Table.Rows[i]["value_year"].ToString());

        this.YearList.SelectedValue = DateTime.Now.Year.ToString();*/
    }

    protected void SqlDataSourceTotalGen_Load(object sender, EventArgs e)
    {
        //if (sender.Equals(this.SetGlobalIntervalBtn))        
        //{
        //this.LabelGlobalPeriodType.Text = DateTime.Now.TimeOfDay.ToString();
        //Slide1.AutoStart = true;        
        FillYearList();
        //RadioButtonPeriodType_SelectedIndexChanged(sender, e);
        SetGlobalIntervalBtn_Click(sender, e);
        //}
    }
    protected void EOCBPPeriod_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        //execute        
    }

    protected void EOCBPSlide_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        //execute
    }
    protected void Slide1_Scroll(object sender, EventArgs e)
    {
        //scroll
    }

    protected void DrawKIUM()
    {
        string select_str = "";

        // считаем количество дней работы
        DateTime start_date = Convert.ToDateTime("24.11.2012 00:00:00");
        DateTime now_date = DateTime.Now.Date;
        int work_days = 366 - start_date.DayOfYear + 365 + now_date.DayOfYear; // т.к. данные у нас на вчерашний день, то +1 надо убрать
        //int work_days = now_date.DayOfYear - start_date.DayOfYear + 1;

        /*select_str = "SELECT COUNT(DISTINCT value_date) AS value_workdays FROM table_power WHERE value_year='2012'";
        DataView dv = (DataView)this.SqlDataSourceKIUM.Select(DataSourceSelectArguments.Empty);*/
        //----------------
        //select_str = "SELECT value_year, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power WHERE value_year='2012' GROUP BY value_year";
        select_str = "SELECT value_year, SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power GROUP BY value_year";
        //select_str = "SELECT SUM(value_sun)/1000 AS value_sun_kilo, SUM(value_diesel)/1000 AS value_diesel_kilo, SUM(value_wind)/1000 AS value_wind_kilo, SUM(value_sn)/1000 AS value_sn_kilo, SUM(value_poselok)/1000 AS value_poselok_kilo, SUM(value_sun + value_diesel + value_wind)/1000 AS value_gen_total_kilo FROM table_power";

        this.SqlDataSourceKIUM.SelectCommand = select_str;
        DataView dv = (DataView)this.SqlDataSourceKIUM.Select(DataSourceSelectArguments.Empty);

        int t_col_offset = 2;

        // diesel-100 sun-81 wind-15
        float kium_diesel_ust = 100;
        float kium_sun_ust = 81;
        float kium_wind_ust = 15;

        float kium_diesel_ras = 100;
        float kium_sun_ras = 50;
        float kium_wind_ras = 10;

        // Количество дней работы электростанции 31+7 посчитано вручную (ИСПРАВИТЬ)
        //int ndays = 38;
        // расчет по солнцу = 12 часов в день, по остальным 24
        int work_hours_not_sun = work_days * 24;
        int work_hours_sun = work_days * 12;
                
        float[,] tkium = new float[5, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }};

        // сделано на 2012 год (т.е. одна запись по select) (ИПРАВИТЬ)        
        if (dv.Table.Rows.Count > 0)
        {
            // установленная мощность
            //tkium[0, 0] = work_hours * kium_diesel;
            tkium[0, 0] = kium_diesel_ust;
            //tkium[0, 1] = work_hours * kium_sun;
            tkium[0, 1] = kium_sun_ust;
            //tkium[0, 2] = work_hours * kium_wind;
            tkium[0, 2] = kium_wind_ust;
            tkium[0, 3] = tkium[0, 0] + tkium[0, 1] + tkium[0, 2];

            for (int i = 0; i < 4; i++) this.KUIMTable.Rows[1].Cells[i + t_col_offset].Text = String.Format("{0:N}",tkium[0, i]);
            //-------------

            // располагаемая мощность
            tkium[1, 0] = kium_diesel_ras;
            tkium[1, 1] = kium_sun_ras;
            tkium[1, 2] = kium_wind_ras;
            tkium[1, 3] = tkium[1, 0] + tkium[1, 1] + tkium[1, 2];

            for (int i = 0; i < 4; i++) this.KUIMTable.Rows[2].Cells[i + t_col_offset].Text = String.Format("{0:N}", tkium[1, i]);
            //-------------

            // производство (у нас 3 года!!!)
            //2014
            tkium[2, 0] = Convert.ToSingle(dv.Table.Rows[0]["value_diesel_kilo"]);
            tkium[2, 1] = Convert.ToSingle(dv.Table.Rows[0]["value_sun_kilo"]);
            tkium[2, 2] = Convert.ToSingle(dv.Table.Rows[0]["value_wind_kilo"]);
            tkium[2, 3] = Convert.ToSingle(dv.Table.Rows[0]["value_gen_total_kilo"]);

            //+2013
            tkium[2, 0] += Convert.ToSingle(dv.Table.Rows[1]["value_diesel_kilo"]);
            tkium[2, 1] += Convert.ToSingle(dv.Table.Rows[1]["value_sun_kilo"]);
            tkium[2, 2] += Convert.ToSingle(dv.Table.Rows[1]["value_wind_kilo"]);
            tkium[2, 3] += Convert.ToSingle(dv.Table.Rows[1]["value_gen_total_kilo"]);
            
            //+2012
            tkium[2, 0] += Convert.ToSingle(dv.Table.Rows[2]["value_diesel_kilo"]);
            tkium[2, 1] += Convert.ToSingle(dv.Table.Rows[2]["value_sun_kilo"]);
            tkium[2, 2] += Convert.ToSingle(dv.Table.Rows[2]["value_wind_kilo"]);
            tkium[2, 3] += Convert.ToSingle(dv.Table.Rows[2]["value_gen_total_kilo"]);

            for (int i = 0; i < 4; i++) this.KUIMTable.Rows[3].Cells[i + t_col_offset].Text = String.Format("{0:N}",tkium[2, i]);
            //-------------

            // потребление (также 3 года)
            tkium[3, 3] = Convert.ToSingle(dv.Table.Rows[0]["value_poselok_kilo"]);
            
            tkium[3, 3] += Convert.ToSingle(dv.Table.Rows[1]["value_poselok_kilo"]);
            
            tkium[3, 3] += Convert.ToSingle(dv.Table.Rows[2]["value_poselok_kilo"]);
            
            this.KUIMTable.Rows[4].Cells[3 + t_col_offset].Text = String.Format("{0:N}",tkium[3, 3]);
            //-------------

            // КИУМ
            /*if (tkium[0, 3] != 0) tkium[3, 3] = (tkium[1, 3] / (tkium[0, 3] * work_hours)) * 100;
            this.KUIMTable.Rows[4].Cells[3 + t_col_offset].Text = String.Format("{0:N}", tkium[3, 3]);*/

            // из-за 12-часового расчета по солнцу делаем расчет общей "располагаемой мощности" для расчета общего КИУМ
            float total_hours_diesel = tkium[1, 0] * work_hours_not_sun;
            float total_hours_sun = tkium[1, 1] * work_hours_sun;
            float total_hours_wind = tkium[1, 2] * work_hours_not_sun;
            float total_hours_ras = total_hours_diesel + total_hours_sun + total_hours_wind;
            // дизель
            if (tkium[1, 0] != 0) tkium[4, 0] = (tkium[2, 0] / total_hours_diesel) * 100;
            // солнце
            if (tkium[1, 1] != 0) tkium[4, 1] = (tkium[2, 1] / total_hours_sun) * 100;
            // ветер
            if (tkium[1, 2] != 0) tkium[4, 2] = (tkium[2, 2] / total_hours_wind) * 100;
            // общий
            if (tkium[1, 3] != 0) tkium[4, 3] = (tkium[2, 3] / total_hours_ras) * 100;

            for (int i = 0; i < 4; i++) this.KUIMTable.Rows[5].Cells[i + t_col_offset].Text = String.Format("{0:N}", tkium[4, i]);
            //-------------       
        }
    }

    //----------------------
    HSSFWorkbook hssfworkbook;

    MemoryStream WriteToStream()
        { 
            //Write the stream data of workbook to the root directory
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }

        void GenerateData_aiiskue()
        {
            ISheet sheet1 = hssfworkbook.CreateSheet("Учет электроэнергии");            
            IDataFormat format = hssfworkbook.CreateDataFormat();

            int drow = 3;
            
            DataView dv = (DataView)this.SqlDataSourceTotalGen.Select(DataSourceSelectArguments.Empty);
            
            // стили ячеек
            ICellStyle cellStyle_h = hssfworkbook.CreateCellStyle();
            cellStyle_h.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
            cellStyle_h.Alignment = HorizontalAlignment.CENTER;
            cellStyle_h.VerticalAlignment = VerticalAlignment.CENTER;
            cellStyle_h.WrapText = true;
            IFont font_h = hssfworkbook.CreateFont();
            font_h.Boldweight = short.MaxValue;           
            cellStyle_h.SetFont(font_h);

            ICellStyle cellStyle_value = hssfworkbook.CreateCellStyle();
            cellStyle_value.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
            cellStyle_value.Alignment = HorizontalAlignment.CENTER;
            cellStyle_value.VerticalAlignment = VerticalAlignment.CENTER;

            ICellStyle cellStyle_center = hssfworkbook.CreateCellStyle();
            cellStyle_center.Alignment = HorizontalAlignment.CENTER;
            cellStyle_center.VerticalAlignment = VerticalAlignment.CENTER;
            //---------------

            IRow row_period = sheet1.CreateRow(drow-2);
            row_period.CreateCell(0).SetCellValue("Период:");

            IRow row = sheet1.CreateRow(drow);

            int col_period_count_table = 0;
            int col_period_count_grid = 0;
            string s;

            switch (this.RadioButtonPeriodType.SelectedValue)
            {
                case "День":
                    col_period_count_table = 1;
                    col_period_count_grid = 2;

                    sheet1.SetColumnWidth(0, 13*256); // Период
                    sheet1.SetColumnWidth(1, 11*256); // Время
                    sheet1.SetColumnWidth(2, 13*256); // СП
                    sheet1.SetColumnWidth(3, 13*256); // ДЭС
                    sheet1.SetColumnWidth(4, 18*256); // Ветер
                    sheet1.SetColumnWidth(5, 14*256); // СН
                    sheet1.SetColumnWidth(6, 20*256); // Поселок

                    row_period.CreateCell(1).SetCellValue(this.GetGlobalStartDate().ToShortDateString());                    
                    
                    break;
                case "Месяц":
                    col_period_count_table = 3;
                    col_period_count_grid = 1;

                    sheet1.SetColumnWidth(0, 13*256); // Период
                    sheet1.SetColumnWidth(1, 13*256); // СП
                    sheet1.SetColumnWidth(2, 13*256); // ДЭС
                    sheet1.SetColumnWidth(3, 18*256); // Ветер
                    sheet1.SetColumnWidth(4, 14*256); // СН
                    sheet1.SetColumnWidth(5, 20*256); // Поселок
                                        
                    s = MonthList.Items[this.GetGlobalStartDate().Month-1].Value;
                    s += ", ";
                    s += this.GetGlobalStartDate().Year.ToString();
                    row_period.CreateCell(1).SetCellValue(s);
                    
                    break;
                case "Год":
                    col_period_count_table = 3;
                    col_period_count_grid = 1;

                    sheet1.SetColumnWidth(0, 13*256); // Период
                    sheet1.SetColumnWidth(1, 13*256); // СП
                    sheet1.SetColumnWidth(2, 13*256); // ДЭС
                    sheet1.SetColumnWidth(3, 18*256); // Ветер
                    sheet1.SetColumnWidth(4, 14*256); // СН
                    sheet1.SetColumnWidth(5, 20*256); // Поселок

                    row_period.CreateCell(1).SetCellValue(this.GetGlobalStartDate().Year.ToString());

                    break;
                case "Период":
                    col_period_count_table = 1;
                    col_period_count_grid = 2;

                    sheet1.SetColumnWidth(0, 13*256); // Период
                    sheet1.SetColumnWidth(1, 11*256); // Время
                    sheet1.SetColumnWidth(2, 13*256); // СП
                    sheet1.SetColumnWidth(3, 13*256); // ДЭС
                    sheet1.SetColumnWidth(4, 18*256); // Ветер
                    sheet1.SetColumnWidth(5, 14*256); // СН
                    sheet1.SetColumnWidth(6, 20*256); // Поселок

                    s = this.GetGlobalStartDate().ToShortDateString();
                    s += " - ";
                    s += this.GetGlobalEndDate().ToShortDateString();
                    row_period.CreateCell(1).SetCellValue(s);
                    
                    break;
            }

            // создание заголовков столбцов - генерация-потребление            
            int k2 = 0;
            for (int k = 0; k < this.AiiskueGrid.Columns.Count; k++)
            {
                if (this.AiiskueGrid.Columns[k].Visible)
                {
                    ICell hcell = row.CreateCell(k2);
                    hcell.CellStyle = cellStyle_h;
                    hcell.SetCellValue(this.AiiskueGrid.Columns[k].ToString());
                    k2++;
                }
            }
            //-----------------------------

            ICell cell;
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                row = sheet1.CreateRow(i+drow+1);

                DateTime dt;
                switch (this.RadioButtonPeriodType.SelectedValue)
                {
                    case "День":
                        cell = row.CreateCell(0);
                        cell.CellStyle = cellStyle_center;
                        dt = Convert.ToDateTime(dv.Table.Rows[i]["date_time"].ToString());
                        cell.SetCellValue(dt.ToShortDateString());

                        cell = row.CreateCell(1);
                        cell.CellStyle = cellStyle_center;
                        cell.SetCellValue(dt.ToShortTimeString());
                        break;
                    case "Месяц":
                        cell = row.CreateCell(0);
                        cell.CellStyle = cellStyle_center;
                        dt = Convert.ToDateTime(dv.Table.Rows[i]["value_date"].ToString());                        
                        cell.SetCellValue(dt.ToShortDateString());
                        break;
                    case "Год":
                        cell = row.CreateCell(0);
                        cell.CellStyle = cellStyle_center;                        
                        s = dv.Table.Rows[i]["value_month"].ToString();
                        cell.SetCellValue(MonthList.Items[Convert.ToInt16(s)-1].Value);
                        break;
                    case "Период":
                        cell = row.CreateCell(0);
                        cell.CellStyle = cellStyle_center;
                        dt = Convert.ToDateTime(dv.Table.Rows[i]["date_time"].ToString());
                        cell.SetCellValue(dt.ToShortDateString());

                        cell = row.CreateCell(1);
                        cell.CellStyle = cellStyle_center;
                        cell.SetCellValue(dt.ToShortTimeString());
                        break;
                }

                int j2 = col_period_count_grid;
                for (int j = col_period_count_table; j < dv.Table.Columns.Count-1; j++) //Count-1 - убираем общую генерацию
                {
                        cell = row.CreateCell(j2++);
                        cell.CellStyle = cellStyle_value;
                        cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][j].ToString()));
                }
            }
        }

        void InitializeWorkbook()
        {
            hssfworkbook = new HSSFWorkbook();

            ////create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "Oblkommunenergo";
            hssfworkbook.DocumentSummaryInformation = dsi;

            ////create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "Onguren";
            hssfworkbook.SummaryInformation = si;
        }

    protected void btn2Excel_Click(object sender, EventArgs e)
    {
    //----------------------
        
            string filename="onguren.xls";
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}",filename));
            Response.Clear();

            InitializeWorkbook();
            GenerateData_aiiskue();            
            Response.BinaryWrite(WriteToStream().GetBuffer());
            Response.End();
    //----------------------
    }

    // экспорт метеоданных в Excel------------------------------------------------------
    void GenerateData_meteo()
    {
        ISheet sheet1 = hssfworkbook.CreateSheet("Погодные условия");
        IDataFormat format = hssfworkbook.CreateDataFormat();

        int drow = 3;

        DataView dv = (DataView)this.SqlDataSourceMeteo.Select(DataSourceSelectArguments.Empty);
        
        // стили ячеек
        ICellStyle cellStyle_h = hssfworkbook.CreateCellStyle();
        cellStyle_h.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
        cellStyle_h.Alignment = HorizontalAlignment.CENTER;
        cellStyle_h.VerticalAlignment = VerticalAlignment.CENTER;
        cellStyle_h.WrapText = true;
        IFont font_h = hssfworkbook.CreateFont();
        font_h.Boldweight = short.MaxValue;
        cellStyle_h.SetFont(font_h);

        ICellStyle cellStyle_value = hssfworkbook.CreateCellStyle();
        cellStyle_value.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
        cellStyle_value.Alignment = HorizontalAlignment.CENTER;
        cellStyle_value.VerticalAlignment = VerticalAlignment.CENTER;

        ICellStyle cellStyle_center = hssfworkbook.CreateCellStyle();
        cellStyle_center.Alignment = HorizontalAlignment.CENTER;
        cellStyle_center.VerticalAlignment = VerticalAlignment.CENTER;
        //---------------

        IRow row_period = sheet1.CreateRow(drow - 2);
        row_period.CreateCell(0).SetCellValue("Период:");

        IRow row = sheet1.CreateRow(drow);
                
        string s;

        int col_period_count_table = 1;
        int col_period_count_grid = 2;

        // длины столбцов
        sheet1.SetColumnWidth(0, 13 * 256); 
        sheet1.SetColumnWidth(1, 9 * 256); 
        sheet1.SetColumnWidth(2, 13 * 256); 
        sheet1.SetColumnWidth(3, 13 * 256); 
        sheet1.SetColumnWidth(4, 18 * 256); 
        sheet1.SetColumnWidth(5, 14 * 256); 
        sheet1.SetColumnWidth(6, 20 * 256); 
        sheet1.SetColumnWidth(7, 20 * 256); 
        sheet1.SetColumnWidth(8, 20 * 256); 

        switch (this.RadioButtonPeriodType.SelectedValue)
        {            
            case "День":
                row_period.CreateCell(1).SetCellValue(this.GetGlobalStartDate().ToShortDateString());
                break;
            case "Месяц":              
                s = MonthList.Items[this.GetGlobalStartDate().Month - 1].Value;
                s += ", ";
                s += this.GetGlobalStartDate().Year.ToString();
                row_period.CreateCell(1).SetCellValue(s);
                break;
            case "Год":                
                row_period.CreateCell(1).SetCellValue(this.GetGlobalStartDate().Year.ToString());
                break;
            case "Период":                
                s = this.GetGlobalStartDate().ToShortDateString();
                s += " - ";
                s += this.GetGlobalEndDate().ToShortDateString();
                row_period.CreateCell(1).SetCellValue(s);
                break;
        }

        // создание заголовков столбцов - погодные условия            
        int k2 = 0;
        ICell hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Дата"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Время"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Температура, °С"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Влажность, %"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Скорость ветра, м/с"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Направление ветра"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Направление ветра (градусы)"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Освещенность, Вт/м2"); k2++;
        hcell = row.CreateCell(k2); hcell.CellStyle = cellStyle_h; hcell.SetCellValue("Давление, мм рт. ст."); k2++;        
        //-----------------------------

        ICell cell;
        for (int i = 0; i < dv.Table.Rows.Count; i++)
        {
            row = sheet1.CreateRow(i + drow + 1);

            DateTime dt;

            cell = row.CreateCell(0);
            cell.CellStyle = cellStyle_center;
            dt = Convert.ToDateTime(dv.Table.Rows[i]["date_time"].ToString());
            cell.SetCellValue(dt.ToShortDateString());

            cell = row.CreateCell(1);
            cell.CellStyle = cellStyle_center;
            cell.SetCellValue(dt.ToShortTimeString());

            string[] windDirections = { "ю", "юз", "з", "сз", "с", "св", "в", "юв" };
            string wind_direction = windDirections[Convert.ToInt16(dv.Table.Rows[i][8])];

            int j2 = col_period_count_grid;          
            for (int j = 0; j < 7; j++)
            {
                cell = row.CreateCell(j2+j);
                cell.CellStyle = cellStyle_value;
                if (j == 0) cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][1].ToString())); // температура
                if (j == 1) cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][2].ToString())); // влажность
                if (j == 2) cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][3].ToString())); // скорость ветра
                if (j == 3) cell.SetCellValue(wind_direction); // направление (слово)
                if (j == 4) cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][4].ToString())); // направление (градусы)
                if (j == 5) cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][5].ToString())); // освещенность
                if (j == 6) cell.SetCellValue(Convert.ToSingle(dv.Table.Rows[i][7].ToString())); // давление (мм рт ст)
            }            
        }
    }

    protected void btn2Excel_meteo_Click(object sender, EventArgs e)
    {
        //----------------------
        string filename = "onguren_meteo.xls";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
        Response.Clear();

        InitializeWorkbook();
        GenerateData_meteo();
        Response.BinaryWrite(WriteToStream().GetBuffer());
        Response.End();
        //----------------------
    }
}
