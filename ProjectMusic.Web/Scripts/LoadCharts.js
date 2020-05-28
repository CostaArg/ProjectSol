$(function () {
    $.ajax({
        type: "GET",
        contentType: "application/json",
        //data: "{entity:" + JSON.stringify(entity) + "}",
        url: "/AdminStats/GetTopFiveAlbums",
        success: function (data) {

            var albumNames = [];
            var albumPurchases = [];

            data.forEach(element => {
                albumNames.push(element.AlbumName);
                albumPurchases.push(element.AlbumPurchases);
            });

            var ctx = document.getElementById('pieChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: albumNames,
                    datasets: [{
                        label: 'Album Purchases',
                        data: albumPurchases,
                        backgroundColor: [
                            'rgb(255, 99, 132)',
                            'rgb(54, 162, 235)',
                            'rgb(255, 206, 86)',
                            'rgb(75, 192, 192)',
                            'rgb(153, 102, 255)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: false,
                    maintainAspectRatio: false
                }
            });
        },
        error: function (result) {
            alert("Something went wrong");
        }
    });
    $.ajax({
        type: "GET",
        contentType: "application/json",
        //data: "{entity:" + JSON.stringify(entity) + "}",
        url: "/AdminStats/GetTopThreeUsers",
        success: function (data) {

            var userNames = [];
            var albumPurchases = [];

            data.forEach(element => {
                userNames.push(element.UserName);
                albumPurchases.push(element.Count);
            });

            var ctx = document.getElementById('barChart');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: userNames,
                    datasets: [{
                        label: '# of Album Purchases',
                        data: albumPurchases,
                        backgroundColor: [
                            'rgb(255, 99, 132)',
                            'rgb(54, 162, 235)',
                            'rgb(255, 206, 86)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: false,
                    maintainAspectRatio: false,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }],
                        xAxes: [{
                            display: true
                        }]
                    }
                }
            });
        },
        error: function (result) {
            alert("Something went wrong");
        }
    });
});