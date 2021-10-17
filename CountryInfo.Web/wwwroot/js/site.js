

$(document).ready(function () {
    getAllCountries();
});


$('#ddlCountry').change(function () {
    getYearlyHoliday();
});


function getAllCountries() {
    $.get("/Home/GetCountries", function (data) {
        fillCountryData(data, '#ddlCountry');
        getYearlyHoliday();
    });
}

function fillCountryData(countryData, selectElementId) {
    $.each(countryData, function (index, value) {
        $(selectElementId).append($('<option>').text(value.name).val(value.countryCode));
    });
    $(selectElementId).selectpicker();
}

function getYearlyHoliday() {
    $.get("/Home/GetYearlyHolidayByCountry", { countryCode: $('#ddlCountry').val(), year: currrentYear }, function (data) {
        var titleOfColumns = new Array("Kod", "Açıklama");
        createDynamicTable("#divOlumlu", data, titleOfColumns);
    });
}

function createDynamicTable(elementId, dataList, titleOfColumnList) {

    var columns = Object.keys(dataList[0]);
    var tablehtml = "<table class='table table-striped' id='tblOlumlu'><thead>"
    for (var i = 0; i < columns.length; i++) {
        tablehtml += '<th>' + columns[i] + '</th>';
    }

    tablehtml += "</thead><tbody>";

    var alldatahtml = '';
    for (var i = 0; i < dataList.length; i++) {
        alldatahtml += '<tr>'
        for (var j = 0; j < columns.length; j++) {
            var cellData = dataList[i][columns[j]];

            if (cellData != undefined && cellData != "" && cellData != "null") {
                 
                alldatahtml += '<td>' + dataList[i][columns[j]] + '</td>';
            }
            else {
                alldatahtml += '<td>' + "-" + '</td>';
            } 
        }
        alldatahtml += '</tr>';
    }
    tablehtml += alldatahtml + "</tbody></table>";


    var tableDiv = $(elementId);
    tableDiv.html("");
    tableDiv.append(tablehtml);
    $('#tblOlumlu').DataTable({
        responsive: true,

        "pageLength": 10,
        "lengthChange": false,
        "ordering": false
    });
}