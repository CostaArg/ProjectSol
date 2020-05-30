$(function () {
    var accessToken;

    $("#spotify").click(function () {

        $.ajax({
            type: "POST",
            data: {
                grant_type: "client_credentials"
            },
            url: "https://accounts.spotify.com/api/token",
            headers: {
                "Authorization": "Basic " + "ZjcwNTMyODYyN2YwNDNjODlkNDYzZjY4Y2E1NTUwZDg6ZDY3MGZlMjkzMzAwNDExY2EzNDkxMDA1YWU4YjhlMTE="
            },
            success: function (result) {
                accessToken = result.access_token;

                var apiPartialString = "https://api.spotify.com/v1/albums/";
                var spotifyId = $("#SpotifyAlbumId").val();
                var apiFullString = apiPartialString + spotifyId;
                var albumPhoto;
                var albumId = $("#AlbumId").val();

                $.ajax({
                    type: "GET",
                    contentType: "application/json",
                    url: apiFullString,
                    headers: {
                        "Authorization": "Bearer " + accessToken
                    },
                    success: function (data) {
                        albumPhoto = { PhotoUrl: data.images[0].url, Id: albumId };

                        $.ajax({
                            type: "POST",
                            contentType: "application/json",
                            data: JSON.stringify(albumPhoto),
                            url: "/Admin/Album/SpotifyPhoto",
                            success: function () {
                                alert("Photo inserted to the Database!");
                            },
                            error: function (result) {
                                alert("Something went wrong with sending the data");
                            }
                        });
                    },
                    error: function (result) {
                        alert("Something went wrong with the API ");
                        console.log(result.responseText);
                    }
                });
            },
            error: function (result) {
                alert("Something went wrong with the API");
            }
        });
    })
});