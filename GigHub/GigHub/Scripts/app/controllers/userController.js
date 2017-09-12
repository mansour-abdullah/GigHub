var UserController = function (followingService) {
    var button
    var init = function (container) {
        $(".js-toggle-follow").click(toggleFollow);
        //$(container).on("click", ".js-toggle-follow", toggleFollow);
    };
    var toggleFollow = function (e) {
        button = $(e.target);
        var followeeId = button.attr("data-user-id");
        if (button.hasClass("btn-default"))
            followingService.follow(followeeId, done, fail);
        else
            followingService.unFollow(followeeId, done, fail);


    };
    var fail = function () {
        alert("Something failed!");

    };
    var done = function () {
        var text = (button.text() === "Follow") ? "Following" : "Follow";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    return {
        init: init
    };
}(FollowingService);