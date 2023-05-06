function allWorks() {
    $.ajax({
        url: "/api/works",
        method: "GET",
        success: function (data) {
            // Tạo datalist từ dữ liệu nhận về
            var datalist = $("#datalistWorks");
            datalist.empty(); // Xóa các option cũ trong datalist
            $.each(data, function (index, item) {
                datalist.append(`<option value="${item.name}" id="${item._id}"></option>`);
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(`Error: ${errorThrown}`);
        }
    });
}

function getMembersByIdWork(workId) {
    $.ajax({
        url: '/api/members/getbyworkid/' + workId,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var datalist = $("#datalistMembers");
            $.each(data, function (index, team) {
                // Duyệt qua từng member trong danh sách listMembers
                datalist.empty();
                $.each(team.listMembers, function (i, member) {
                    // Tạo ra một option mới trong datalist
                    datalist.append(`<option value="${member.fullName}" id="${member.id}"></option>`);
                });
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            
        }
    });
}

function searchUser(email) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/api/users/email/" + email,
            method: "GET",
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

function searchTeam() {
    $.ajax({
        url: "/api/teams",
        method: "GET",
        success: function (data) {
            var dataList = document.getElementById("dataListTeam");
            var defaultOption = document.createElement("option");
            defaultOption.value = 0;
            defaultOption.text = "-----------";

            if (dataList != null) {
                dataList.insertBefore(defaultOption, dataList.firstChild);
                data.forEach(function (value) {
                    var option = document.createElement("option");
                    option.value = value._id;
                    option.text = value.teamName;
                    dataList.appendChild(option);
                    $("#leaderId").val(value.leaderId);
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(`Error: ${errorThrown}`);
        }
    });
}

function getTaskById(taskId) {
    $.ajax({
        url: "/api/task/getbyid/" + taskId,
        method: "GET",
        success: function (data) {
            $("#nameTask").text(data.name);
            $("#descriptTask").text(data.description);
            if (data.level == 1) {
                $('#rdoNormal').prop('checked', true);
            } else if (data.level == 2) {
                $('#rdoWarning').prop('checked', true);
            } else {
                $('#rdoDanger').prop('checked', true);
            }
            if (data.status) {
                $('#rdoSuccess').prop('checked', true);
            } else {
                $('#rdoDoing').prop('checked', true);
            }
            $('#time-start').val(convertTime(data.startHour));
            $('#time-end').val(convertTime(data.endHour));
            $('#date-start').val(convertDate(data.startDay));
            $('#date-end').val(convertDate(data.endDay));
            getUserByTaskId(taskId);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(`Error: ${errorThrown}`);
        }

    });
}

function getUserByTaskId(taskId) {
    $.ajax({
        url: "api/users/getUserByTaskId/" + taskId,
        method: "GET",
        success: function (data) {
            var memberList = [];
            var ul = $(".membersInDetailTask");
            ul.empty();
            data.forEach(function (item, index) {
                memberList.push(item._id)
                generateItemUser(item, ul, $("#listMemberDetail"), memberList);
            });
            $("#listMemberDetail").val(memberList.join(','));
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(`Error: ${errorThrown}`);
        }

    });
}

function getMemberByTeamId(teamId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/api/members/getmemberbyidteam/" + teamId,
            method: "GET",
            success: function (data) {
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

//Function
function convertTime(time) {
    var hours = new Date(time);
    let formattedTime = hours.toLocaleTimeString("vi-VN", {
        hour: "2-digit",
        minute: "2-digit"
    });
    return formattedTime.split(" ")[0];
}

function convertDate(date) {
    var converDate = new Date(date);
    let dateString = converDate.toLocaleDateString("vi-VN", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
    })

    let dateParts = dateString.split("/");
    let year = dateParts[2];
    let month = dateParts[1];
    let day = dateParts[0];

    return `${year}-${month}-${day}`;
}

function createRemoveButton(listItem, listRemove, id, index) {

    var removeButton = $("<button></button>").addClass("btn btn-sm btn-danger ms-2").html('<i class="bx bx-x"></i>');
    removeButton.on("click", function () {
        listRemove.splice(index, 1);
        listItem.remove();
        id.val(listRemove.join(','));
    });
    return removeButton;
}

function generateItemUser(data, parentItem,id, listRemove) {
    var listItem = $("<li></li>").addClass("list-group-item d-flex justify-content-between");
    var divWrapper = $("<div></div>").addClass("d-flex align-items-center");
    if (data.avatar != null) {
        var avatar = $("<img>").attr({
            src: data.avatar,
            alt: "Avatar",
            class: "rounded-circle",
            width: "30"
        });
        divWrapper.append(avatar);
    }

    var username = $("<strong></strong>").addClass("ms-2").text(data.fullName);
    divWrapper.append(username);

    listItem.append(divWrapper);
    var index = listRemove.indexOf(data._id);
    var removeButton = createRemoveButton(listItem, listRemove, id, index)
    listItem.append(removeButton);
    parentItem.append(listItem);
}

// Execute
allWorks();
searchTeam();
