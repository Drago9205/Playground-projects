var Greyhound = (function () {
    //private properties
    var sortNameAsc = true;
    var sortOddsAsc = true;

    //private
    function fillTable(data) {
        var items = '';;
        $.each(data, function (i, race) {
            items += "<div><b>Race name - </b>" + race.Name + "</div><div><b>Race distance - </b>" + race.Distance + "</div><div><b>Race start - </b>" + new Date(parseInt(race.EventDate.substr(6))) + "</div><div><b>Race end - </b>" + new Date(parseInt(race.FinishTime.substr(6))) + "</div>";
            items += "<div><b>Entries</b></div>";
            items += '<table border="1|0"><tr><th>Id</th><th>Name</th><th>Odds</th></tr>';
            $.each(race.Entries, function (i, entry) {
                items += "<tr><td>" + entry.Id + "</td><td>" + entry.Name + "</td><td>" + entry.OddsDecimal + "</td></tr>";
            });
            items += "</table><br><br>";

        });

        $('#rData').html(items);
    }

    //private
    function getSortedData(criteria, isAscending) {
        $.getJSON('/Home/GetViewData',
        {
            sortCriteria: criteria,
            isAscending: isAscending
        },
        function (data) {
            fillTable(data);
        });
    }

    //private
    function getData() {
        $.getJSON('/Home/GetViewData', function (data) {
            fillTable(data);
        });
    }

    function init() {
        $('#sortName').click(function () {
            getSortedData("Name", sortNameAsc);
            sortNameAsc = !sortNameAsc;
        });
        $('#sortOdds').click(function () {
            getSortedData("Odds", sortOddsAsc);
            sortOddsAsc = !sortOddsAsc;
        });
        $('#reload').click(function () {
            getData();
            sortNameAsc = true;
            sortOddsAsc = true;
        });

        getData();
    }

    init();

    return {
        //Making getData public
        getData: getData
    };
})();