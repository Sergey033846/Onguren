using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace LoadMeteoCSV2SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "onguren_dbDataSet_SNTotal.table_sn_total". При необходимости она может быть перемещена или удалена.
            this.table_sn_totalTableAdapter.Fill(this.onguren_dbDataSet_SNTotal.table_sn_total);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "onguren_dbDataSet_Power.table_power". При необходимости она может быть перемещена или удалена.
            this.table_powerTableAdapter.Fill(this.onguren_dbDataSet_Power.table_power);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "oNGUREN_DBDataSet.table_meteo". При необходимости она может быть перемещена или удалена.
            this.table_meteoTableAdapter.Fill(this.oNGUREN_DBDataSet.table_meteo);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "onguren_dbDataSet_WindTotal.table_wind_total". При необходимости она может быть перемещена или удалена.
            this.table_wind_totalTableAdapter.Fill(this.onguren_dbDataSet_WindTotal.table_wind_total);        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            
            this.openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (String file in this.openFileDialog1.FileNames)
                    //if ((myStream = this.openFileDialog1.OpenFile()) != null)
                    {
                       // using (myStream)
                        //{
                            //string[] data = File.ReadAllLines(this.openFileDialog1.FileName);
                            string[] data = File.ReadAllLines(file);
                            
                            string[] data2 = {"","","","","","","","",""};
                            //string[] col = { "Дата", "Время", "Т", "В", "СВ", "НВ", "ИНС","EMP", "НВ_id" };

                            for (int i = 0; i < data.Length; i++)
                            {
                                string[] row = data[i].Split(';');

                                data2[0] = row[0].Trim('"') + " " + row[1].Trim('"');

                                CultureInfo ci = new CultureInfo("ru-Ru");
                                ci.DateTimeFormat.DateSeparator = "/";
                                DateTime date_time = DateTime.Parse(data2[0]);
                                data2[0] = date_time.ToString();
                                                                
                                data2[1] = row[2].Trim('"'); // температура
                                data2[2] = row[3].Trim('"'); // влажность
                                data2[3] = row[4].Trim('"'); // скорость ветра
                                data2[4] = row[5].Trim('"'); // направление в градусах
                                data2[5] = row[6].Trim('"'); // инсоляция
                                data2[6] = row[7].Trim('"'); // давление, гПа

                                // давление, мм рт ст
                                Single pressure_gPa = Convert.ToSingle(data2[6]);
                                Single pressure_mm = pressure_gPa * Convert.ToSingle(0.75);
                                data2[7] = pressure_mm.ToString();

                                // направление ветра - текст, id
                                Single wind_angle = Convert.ToSingle(data2[4]);
                                string wind_name = ""; ;
                                if ((wind_angle > 337.5) || (wind_angle < 22.5)) { wind_name = "с"; data2[8] = "0"; }
                                if ((wind_angle > 157.5) && (wind_angle < 202.5)) { wind_name = "ю"; data2[8] = "4"; }
                                if ((wind_angle > 247.5) && (wind_angle < 292.5)) { wind_name = "з"; data2[8] = "6"; }
                                if ((wind_angle > 67.5) && (wind_angle < 112.5)) { wind_name = "в"; data2[8] = "2"; }
                                if ((wind_angle >= 22.5) && (wind_angle <= 67.5)) { wind_name = "св"; data2[8] = "1"; }
                                if ((wind_angle >= 112.5) && (wind_angle <= 157.5)) { wind_name = "юв"; data2[8] = "3"; }
                                if ((wind_angle >= 202.5) && (wind_angle <= 247.5)) { wind_name = "юз"; data2[8] = "5"; }
                                if ((wind_angle >= 292.5) && (wind_angle <= 337.5)) { wind_name = "сз"; data2[8] = "7"; }
                                //data2[6] = wind_name;
                                                                
                                //for (int j = 0; j < data2.Length; j++) this.listBox1.Items.Add(data2[j]);

                                // проверка на наличие записи с данной временной отметкой (исключение дублей)
                                DateTime d_t = Convert.ToDateTime(data2[0]);
                                oNGUREN_DBDataSet.table_meteoRow fRow = this.oNGUREN_DBDataSet.table_meteo.FindBydate_time(d_t);

                                string date_time_date = "0"; // Отдельное поле для даты
                                date_time_date = d_t.ToShortDateString();

                                //строка с такой временной отметкой отсутствует
                                if (fRow == null)
                                {
                                    this.oNGUREN_DBDataSet.table_meteo.Rows.
                                        Add(data2[0], data2[1], data2[2], data2[3], data2[4], data2[5], data2[6], data2[7], data2[8], date_time_date);

                                    this.table_meteoTableAdapter.Update(this.oNGUREN_DBDataSet.table_meteo);
                                }
                            }
                       // }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }   
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            this.openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  if ((myStream = this.openFileDialog1.OpenFile()) != null)
                  {
                    using (myStream)
                    {
                       string[] data = File.ReadAllLines(this.openFileDialog1.FileName, Encoding.GetEncoding("windows-1251"));
                       string[] data2 = { "", "", "" }; // Дата/Время, Коэффициент, Значение
                       string wind_delta_str = "0";
                       string sn_delta_str = "0";
                       string date_time_date = "0"; // Отдельное поле для даты

                       // начальная инициализация
                       DateTime d_t = Convert.ToDateTime("01.01.1980 00:00:00");
                       DateTime prev_date_time = Convert.ToDateTime("01.01.1980 00:00:00");
                       //-----------
                       
                       for (int i = 0; i < data.Length; i++)                            
                       {
                           string[] row = data[i].Split(',');
                           string gen_id = row[1].Trim('"');
                           gen_id = gen_id.Trim(' ');

                           data2[0] = row[4].Trim('"');
                           data2[1] = row[5].Trim('"');
                           data2[2] = row[6].Trim(';'); 
                           data2[2] = data2[2].Trim('"');
                             
                           // подсчет относительного значения генерации ветра data2[3] ???
                           double wt_last=0, wt_curr=0, wt_delta=0;

                           // подсчет относительного значения собственных нужд
                           double snt_last = 0, snt_curr = 0, snt_delta = 0;

                           //---------------------------------------------------------

                           d_t = Convert.ToDateTime(data2[0]);
                           DateTime d_t2 = d_t;
                           if (d_t.Hour == 0) d_t2 = d_t.AddDays(-1);
                           date_time_date = d_t2.ToShortDateString();
                           int date_time_month = d_t2.Month;
                           int date_time_year = d_t2.Year;

                           // для отсекания последней строки с 0:00 следующего дня в Поселок, СП, ДЭС (накопительные показания)
                           bool flag_right_day = false;
                           if (gen_id == "Поселок" || gen_id == "СП" || gen_id == "ДЭС")
                               if (d_t.TimeOfDay >= prev_date_time.TimeOfDay) flag_right_day = true;

                           if (gen_id == "Ветер" || gen_id == "СН") flag_right_day = true;
                           //------------------

                           if (flag_right_day)
                           {                                                      
                                onguren_dbDataSet_Power.table_powerRow fRow = this.onguren_dbDataSet_Power.table_power.FindBydate_time(d_t);
                                
                                //-----------
                                this.textBox1.Text = d_t.ToString();
                                //-----------

                                if (gen_id == "Ветер")
                                {
                                    onguren_dbDataSet_WindTotal.table_wind_totalRow fwRow = this.onguren_dbDataSet_WindTotal.table_wind_total.FindBydate_time(d_t);
                                    if (fwRow == null)
                                    {
                                        // берем последнюю строку
                                        if (this.onguren_dbDataSet_WindTotal.table_wind_total.Rows.Count != 0)
                                        {
                                            onguren_dbDataSet_WindTotal.table_wind_totalRow fRow_last = this.onguren_dbDataSet_WindTotal.table_wind_total.Last();
                                            wt_last = fRow_last.value_wind_total;
                                            wt_curr = Convert.ToSingle(data2[2]);
                                            wt_delta = wt_curr - wt_last;
                                            wind_delta_str = wt_delta.ToString();
                                        }
   
                                        //-добавляем "накопительную" строку в отдельную таблицу
                                        this.onguren_dbDataSet_WindTotal.table_wind_total.Rows.Add(data2[0], data2[2]);
                                        this.table_wind_totalTableAdapter.Update(this.onguren_dbDataSet_WindTotal.table_wind_total);
                                    }
                                }

                                if (gen_id == "СН")
                                {
                                    onguren_dbDataSet_SNTotal.table_sn_totalRow fsnRow = this.onguren_dbDataSet_SNTotal.table_sn_total.FindBydate_time(d_t);
                                    if (fsnRow == null)
                                    {
                                        // берем последнюю строку
                                        if (this.onguren_dbDataSet_SNTotal.table_sn_total.Rows.Count != 0)                                        
                                        {
                                            onguren_dbDataSet_SNTotal.table_sn_totalRow fRow_last = this.onguren_dbDataSet_SNTotal.table_sn_total.Last();
                                            snt_last = fRow_last.value_sn_total;
                                            snt_curr = Convert.ToSingle(data2[2]);
                                            snt_delta = snt_curr - snt_last;
                                            sn_delta_str = snt_delta.ToString();
                                        }

                                        //-добавляем "накопительную" строку в отдельную таблицу
                                        this.onguren_dbDataSet_SNTotal.table_sn_total.Rows.Add(data2[0], data2[2]);                                                                                
                                        this.table_sn_totalTableAdapter.Update(this.onguren_dbDataSet_SNTotal.table_sn_total);
                                    }
                                }

                                if (fRow != null)
                                {
                                    if (gen_id == "Поселок") fRow.value_poselok = Convert.ToSingle(data2[2]);
                                    if (gen_id == "СП") fRow.value_sun = Convert.ToSingle(data2[2]);
                                    if (gen_id == "ДЭС") fRow.value_diesel = Convert.ToSingle(data2[2]);
                                    if (gen_id == "СН")
                                    {
                                        fRow.value_sn = Convert.ToSingle(sn_delta_str);
                                    }
                                    if (gen_id == "Ветер")
                                    {
                                        fRow.value_wind = Convert.ToSingle(data2[2]);//???смотри с/н
                                    }
                                    this.table_powerTableAdapter.Update(fRow); 
                                }
                                else
                                {                                    
                                    if (gen_id == "Поселок")
                                        this.onguren_dbDataSet_Power.table_power.Rows.Add(data2[0], "0", "0", "0", data2[2], "0", date_time_date, date_time_month, date_time_year);
                                    if (gen_id == "СП")
                                        this.onguren_dbDataSet_Power.table_power.Rows.Add(data2[0], data2[2], "0", "0", "0", "0", date_time_date, date_time_month, date_time_year);
                                    if (gen_id == "ДЭС")
                                        this.onguren_dbDataSet_Power.table_power.Rows.Add(data2[0], "0", data2[2], "0", "0", "0", date_time_date, date_time_month, date_time_year);
                                    if (gen_id == "СН")
                                        this.onguren_dbDataSet_Power.table_power.Rows.Add(data2[0], "0", "0", "0", "0", sn_delta_str, date_time_date, date_time_month, date_time_year);
                                    if (gen_id == "Ветер")
                                        this.onguren_dbDataSet_Power.table_power.Rows.Add(data2[0], "0", "0", wind_delta_str, "0", "0", date_time_date, date_time_month, date_time_year);
                                                                        
                                    this.table_powerTableAdapter.Update(this.onguren_dbDataSet_Power.table_power);
                                }
                                //-----
                           }

                           prev_date_time = d_t;

                       } // for (int i = 0; i < data.Length; i++)
                    } // using (myStream)
                  } // if ((myStream = this.openFileDialog1.OpenFile()) != null)
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }   
        }
        
    }
}
