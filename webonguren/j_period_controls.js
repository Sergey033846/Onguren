
function showDayPeriodControls() {
    document.getElementById("ctl00_AiiskueHolder_LabelYearList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_YearList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_LabelMonthList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_MonthList").style.display = "none";
    document.getElementById("DatePickerDIVId").style.display = "";
    document.getElementById("DatePickerDIVInterval").style.display = "none";
    return true
};

function showMonthPeriodControls() {
    document.getElementById("DatePickerDIVId").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_LabelYearList").style.display = "";
    document.getElementById("ctl00_AiiskueHolder_YearList").style.display = "";
    document.getElementById("ctl00_AiiskueHolder_LabelMonthList").style.display = "";
    document.getElementById("ctl00_AiiskueHolder_MonthList").style.display = "";
    document.getElementById("DatePickerDIVInterval").style.display = "none";
    return true
};

function showYearPeriodControls() {
    document.getElementById("DatePickerDIVId").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_LabelMonthList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_MonthList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_LabelYearList").style.display = "";
    document.getElementById("ctl00_AiiskueHolder_YearList").style.display = "";
    document.getElementById("DatePickerDIVInterval").style.display = "none";
    return true
};

function showIntervalPeriodControls() {
    document.getElementById("DatePickerDIVId").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_LabelMonthList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_MonthList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_LabelYearList").style.display = "none";
    document.getElementById("ctl00_AiiskueHolder_YearList").style.display = "none";
    document.getElementById("DatePickerDIVInterval").style.display = "";
    return true
};

document.getElementById("ctl00_AiiskueHolder_RadioButtonPeriodType_0").onclick = showDayPeriodControls;
document.getElementById("ctl00_AiiskueHolder_RadioButtonPeriodType_1").onclick = showMonthPeriodControls;
document.getElementById("ctl00_AiiskueHolder_RadioButtonPeriodType_2").onclick = showYearPeriodControls;
document.getElementById("ctl00_AiiskueHolder_RadioButtonPeriodType_3").onclick = showIntervalPeriodControls; 
