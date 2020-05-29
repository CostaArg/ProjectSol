$(function () {
    $("#spotify").click(function () {
        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: "https://api.spotify.com/v1/albums/0sNOF9WDwhWunNAHPD3Baj",
            success: function (data) {
                var albumPhoto = { PhotoUrl: data.images[0].url };
                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(albumPhoto),
                    url: "/Admin/Album/Spotify",
                    success: function () {
                        alert("SUCCESS");
                    },
                    error: function (result) {
                        alert("Something went wrong with sending the data");
                    }
                });
            },
            error: function (result) {
                alert("Something went wrong with the API");
            }
        });
    })
});