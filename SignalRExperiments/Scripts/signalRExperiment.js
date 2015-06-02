// basic playground to start with...

$(function () {

	$("#messageContainer").draggable();

	var conn = $.connection.hub;
	var hubProxy = $.connection.playGround;
	console.log(hubProxy);

	hubProxy.client.SuccessfullyJoinedGroup = function (data) {
		$('<div>', {
			"class": "crGroup btn"

		}).text(data).appendTo("#createdGroup");
	};


	hubProxy.client.AlreadyExists = function (data) {
		$('<div>', {
			"class": "alreadyExists label label-danger"

		}).text(data).appendTo("#alreadyExists").delay(3000).fadeOut();
	};


	hubProxy.client.sendMessage = function (data) {
		$('<div>', {
			"class": "response"

		}).text(data).appendTo("#response");
	};


	hubProxy.client.PopulateActiveGroups = function (data) {
		
		$.each(data, function (key,val) {
			$('<div>', {
				"class": "crGroup btn"

			}).text(val).appendTo("#createdGroup");


		});
		
	};

	//server calls
	conn.start().done(function () {

		hubProxy.server.getActiveGroups();
	});


	$("#btnCreateGroup").on("click", function (e) {
		var groupName = $("#txtCreateGroup").val();

		conn.start().done(function () {

			hubProxy.server.createGroup(groupName);
		});
	});




	$("#btnMessage").on("click", function (e) {
		var message = $("#message").val();

		conn.start().done(function () {
			hubProxy.server.sendMessage($("#currentGroup").val(), message);
		});
	});



	$("body").on("click", ".crGroup", function () {
		console.log($(this).text().trim());
		var groupName = $(this).text().trim();
		$("#currentGroup").val(groupName);
	

		$(".crGroup").css("background-color", "deeppink");
		$(this).css("background-color", "rgb(206, 15, 75)");


		conn.start().done(function () {
			hubProxy.server.joinGroup(groupName);
		});


	});


});//End of $ wrapper.