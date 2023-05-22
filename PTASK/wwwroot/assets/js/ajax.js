function getWorksByIdProject(projectId) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            $.ajax({
                url: "/api/works/" + projectId,
                method: "GET",
                success: function (data) {
                    // Tạo datalist từ dữ liệu nhận về
                    resolve(data);
                },
                error: function (error) {
                    reject(error);
                }
            });
        }, 1000); // Đặt độ trễ là 1000ms (có thể điều chỉnh theo nhu cầu)
    });
}

function getMembersByIdWork(workId) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            $.ajax({
                url: '/api/members/getbyworkid/' + workId,
                method: "GET",
                success: function (data) {
                    // Tạo datalist từ dữ liệu nhận về
                    resolve(data);
                },
                error: function (error) {
                    reject(error);
                }
            });
        }, 500); // Đặt độ trễ là 1000ms (có thể điều chỉnh theo nhu cầu)
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
            var dataList = document.querySelectorAll('.selectedTeam');
            var defaultOption = document.createElement("option");
            defaultOption.value = 0;
            defaultOption.text = "-----------";

            if (dataList != null) {
                dataList.forEach(function (item) {
                    item.insertBefore(defaultOption.cloneNode(true), item.firstChild);
                    data.forEach(function (value) {
                        var option = document.createElement("option");
                        option.value = value._id;
                        option.text = value.teamName;
                        item.appendChild(option);
                        $("#leaderId").val(value.leaderId);
                        $("#leaderIdDetailWork").val(value.leaderId);
                    });
                });
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(`Error: ${errorThrown}`);
        }
    });
}

function getUserById(id) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/api/users/getUserById/' + id,
            method: "GET",
            success: function (data) {
                // Tạo datalist từ dữ liệu nhận về
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

function getTeamByWorkId(workId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/api/teams/getTeamByWorkId/' + workId,
            method: "GET",
            success: function (data) {
                // Tạo datalist từ dữ liệu nhận về
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

function getTaskById(taskId) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            $.ajax({
                url: "/api/task/getbyid/" + taskId,
                method: "GET",
                success: function (data) {
                    // Tạo datalist từ dữ liệu nhận về
                    resolve(data);
                },
                error: function (error) {
                    reject(error);
                }
            });
        }, 500); // Đặt độ trễ là 1000ms (có thể điều chỉnh theo nhu cầu)
    });
}

function getTaskByWorkId(workId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "api/task/getByWorkId/" + workId,
            headers: {
                "Cache-Control": "no-cache",
                "Pragma": "no-cache"
            },
            method: "GET",
            success: function (data) {
                // Tạo datalist từ dữ liệu nhận về
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

function getWorkById(workId) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            $.ajax({
                url: "/api/work/getWorkById/" + workId,
                method: "GET",
                success: function (data) {
                    // Tạo datalist từ dữ liệu nhận về
                    resolve(data);
                },
                error: function (error) {
                    reject(error);
                }
            });
        }, 500); // Đặt độ trễ là 1000ms (có thể điều chỉnh theo nhu cầu)
    });
}

function getUserByTaskId(taskId) {
    return new Promise(function (resolve, reject) {
        setTimeout(function () {
            $.ajax({
                url: "api/users/getUserByTaskId/" + taskId,
                method: "GET",
                success: function (data) {
                    // Tạo datalist từ dữ liệu nhận về
                    resolve(data);
                },
                error: function (error) {
                    reject(error);
                }
            });
        }, 500); // Đặt độ trễ là 1000ms (có thể điều chỉnh theo nhu cầu)
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

function getTeamById(teamId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: "/api/teams/getTeamById/" + teamId,
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

function getAllIdLeaders() {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/api/team/getAllIdLeader',
            method: "GET",
            success: function (data) {
                // Tạo datalist từ dữ liệu nhận về
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

function getCommentByTaskId(taskId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: 'https://ptask.cyclic.app/api/notes/task/' + taskId,
            method: "GET",
            success: function (data) {
                // Tạo datalist từ dữ liệu nhận về
                resolve(data);
            },
            error: function (error) {
                reject(error);
            }
        });
    });
}

function getCommentByWorkId(workId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: 'https://ptask.cyclic.app/api/notes/work/' + workId,
            method: "GET",
            success: function (data) {
                // Tạo datalist từ dữ liệu nhận về
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

    var username = $("<span></span>").addClass("ms-2").text(data.fullName);
    divWrapper.append(username);

    listItem.append(divWrapper);
    var index = listRemove.indexOf(data._id);
    var removeButton = createRemoveButton(listItem, listRemove, id, index)
    listItem.append(removeButton);
    parentItem.append(listItem);
}

// Execute
searchTeam();
