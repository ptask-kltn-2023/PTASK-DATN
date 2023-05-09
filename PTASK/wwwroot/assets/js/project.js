"use strict";

function _createForOfIteratorHelper(o, allowArrayLike) { var it; if (typeof Symbol === "undefined" || o[Symbol.iterator] == null) { if (Array.isArray(o) || (it = _unsupportedIterableToArray(o)) || allowArrayLike && o && typeof o.length === "number") { if (it) o = it; var i = 0; var F = function F() { }; return { s: F, n: function n() { if (i >= o.length) return { done: true }; return { done: false, value: o[i++] }; }, e: function e(_e) { throw _e; }, f: F }; } throw new TypeError("Invalid attempt to iterate non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method."); } var normalCompletion = true, didErr = false, err; return { s: function s() { it = o[Symbol.iterator](); }, n: function n() { var step = it.next(); normalCompletion = step.done; return step; }, e: function e(_e2) { didErr = true; err = _e2; }, f: function f() { try { if (!normalCompletion && it["return"] != null) it["return"](); } finally { if (didErr) throw err; } } }; }

function _unsupportedIterableToArray(o, minLen) { if (!o) return; if (typeof o === "string") return _arrayLikeToArray(o, minLen); var n = Object.prototype.toString.call(o).slice(8, -1); if (n === "Object" && o.constructor) n = o.constructor.name; if (n === "Map" || n === "Set") return Array.from(o); if (n === "Arguments" || /^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(n)) return _arrayLikeToArray(o, minLen); }

function _arrayLikeToArray(arr, len) { if (len == null || len > arr.length) len = arr.length; for (var i = 0, arr2 = new Array(len); i < len; i++) { arr2[i] = arr[i]; } return arr2; }

document.addEventListener('DOMContentLoaded', function () {
    'use strict';

    feather.replace();

    (function () {
        var sidebar = document.querySelector('.sidebar'),
            catSubMenu = document.querySelector('.cat-sub-menu'),
            sidebarBtns = document.querySelectorAll('.sidebar-toggle');

        var _iterator = _createForOfIteratorHelper(sidebarBtns),
            _step;

        try {
            for (_iterator.s(); !(_step = _iterator.n()).done;) {
                var sidebarBtn = _step.value;

                if (sidebarBtn && sidebarBtn) {
                    sidebarBtn.addEventListener('click', function () {
                        var _iterator2 = _createForOfIteratorHelper(sidebarBtns),
                            _step2;

                        try {
                            for (_iterator2.s(); !(_step2 = _iterator2.n()).done;) {
                                var sdbrBtn = _step2.value;
                                sdbrBtn.classList.toggle('rotated');
                            }
                        } catch (err) {
                            _iterator2.e(err);
                        } finally {
                            _iterator2.f();
                        }

                        sidebar.classList.toggle('hidden');
                        /*catSubMenu.classList.remove('visible');*/
                    });
                }
            }
        } catch (err) {
            _iterator.e(err);
        } finally {
            _iterator.f();
        }
    })();

    (function () {
        var showCatBtns = document.querySelectorAll('.show-cat-btn');

        if (showCatBtns) {
            showCatBtns.forEach(function (showCatBtn) {
                var catSubMenu = showCatBtn.nextElementSibling;
                showCatBtn.addEventListener('click', function (e) {
                    e.preventDefault();
                    catSubMenu.classList.toggle('visible');
                    var catBtnToRotate = document.querySelector('.category__btn');
                    catBtnToRotate.classList.toggle('rotated');
                });
            });
        }
    })();

    (function () {
        var showMenu = document.querySelector('.lang-switcher');
        var langMenu = document.querySelector('.lang-menu');
        var layer = document.querySelector('.layer');

        if (showMenu) {
            showMenu.addEventListener('click', function () {
                langMenu.classList.add('active');
                layer.classList.add('active');
            });

            if (layer) {
                layer.addEventListener('click', function (e) {
                    if (langMenu.classList.contains('active')) {
                        langMenu.classList.remove('active');
                        layer.classList.remove('active');
                    }
                });
            }
        }
    })();

    (function () {
        var userDdBtnList = document.querySelectorAll('.dropdown-btn');
        var userDdList = document.querySelectorAll('.users-item-dropdown');
        var layer = document.querySelector('.layer');

        if (userDdList && userDdBtnList) {
            var _iterator3 = _createForOfIteratorHelper(userDdBtnList),
                _step3;

            try {
                for (_iterator3.s(); !(_step3 = _iterator3.n()).done;) {
                    var userDdBtn = _step3.value;
                    userDdBtn.addEventListener('click', function (e) {
                        layer.classList.add('active');

                        var _iterator4 = _createForOfIteratorHelper(userDdList),
                            _step4;

                        try {
                            for (_iterator4.s(); !(_step4 = _iterator4.n()).done;) {
                                var userDd = _step4.value;

                                if (e.currentTarget.nextElementSibling == userDd) {
                                    if (userDd.classList.contains('active')) {
                                        userDd.classList.remove('active');
                                    } else {
                                        userDd.classList.add('active');
                                    }
                                } else {
                                    userDd.classList.remove('active');
                                }
                            }
                        } catch (err) {
                            _iterator4.e(err);
                        } finally {
                            _iterator4.f();
                        }
                    });
                }
            } catch (err) {
                _iterator3.e(err);
            } finally {
                _iterator3.f();
            }
        }

        if (layer) {
            layer.addEventListener('click', function (e) {
                var _iterator5 = _createForOfIteratorHelper(userDdList),
                    _step5;

                try {
                    for (_iterator5.s(); !(_step5 = _iterator5.n()).done;) {
                        var userDd = _step5.value;

                        if (userDd.classList.contains('active')) {
                            userDd.classList.remove('active');
                            layer.classList.remove('active');
                        }
                    }
                } catch (err) {
                    _iterator5.e(err);
                } finally {
                    _iterator5.f();
                }
            });
        }
    })();

    (function () {
        Chart.defaults.backgroundColor = '#000';
        var darkMode = localStorage.getItem('darkMode');
        var darkModeToggle = document.querySelector('.theme-switcher');

        var enableDarkMode = function enableDarkMode() {
            document.body.classList.add('darkmode');
            localStorage.setItem('darkMode', 'enabled');
        };

        var disableDarkMode = function disableDarkMode() {
            document.body.classList.remove('darkmode');
            localStorage.setItem('darkMode', null);
        };

        if (darkMode === 'enabled') {
            enableDarkMode();
        }

        if (darkModeToggle) {
            darkModeToggle.addEventListener('click', function () {
                darkMode = localStorage.getItem('darkMode');

                if (darkMode !== 'enabled') {
                    enableDarkMode();
                } else {
                    disableDarkMode();
                }

                addData();
            });
        }
    })();

    (function () {
        var checkAll = document.querySelector('.check-all');
        var checkers = document.querySelectorAll('.check');

        if (checkAll && checkers) {
            checkAll.addEventListener('change', function (e) {
                var _iterator6 = _createForOfIteratorHelper(checkers),
                    _step6;

                try {
                    for (_iterator6.s(); !(_step6 = _iterator6.n()).done;) {
                        var checker = _step6.value;

                        if (checkAll.checked) {
                            checker.checked = true;
                            checker.parentElement.parentElement.parentElement.classList.add('active');
                        } else {
                            checker.checked = false;
                            checker.parentElement.parentElement.parentElement.classList.remove('active');
                        }
                    }
                } catch (err) {
                    _iterator6.e(err);
                } finally {
                    _iterator6.f();
                }
            });

            var _iterator7 = _createForOfIteratorHelper(checkers),
                _step7;

            try {
                var _loop = function _loop() {
                    var checker = _step7.value;
                    checker.addEventListener('change', function (e) {
                        checker.parentElement.parentElement.parentElement.classList.toggle('active');

                        if (!checker.checked) {
                            checkAll.checked = false;
                        }

                        var totalCheckbox = document.querySelectorAll('.users-table .check');
                        var totalChecked = document.querySelectorAll('.users-table .check:checked');

                        if (totalCheckbox && totalChecked) {
                            if (totalCheckbox.length == totalChecked.length) {
                                checkAll.checked = true;
                            } else {
                                checkAll.checked = false;
                            }
                        }
                    });
                };

                for (_iterator7.s(); !(_step7 = _iterator7.n()).done;) {
                    _loop();
                }
            } catch (err) {
                _iterator7.e(err);
            } finally {
                _iterator7.f();
            }
        }
    })();

    (function () {
        var checkAll = document.querySelector('.check-all');
        var checkers = document.querySelectorAll('.check');
        var checkedSum = document.querySelector('.checked-sum');

        if (checkedSum && checkAll && checkers) {
            checkAll.addEventListener('change', function (e) {
                var totalChecked = document.querySelectorAll('.users-table .check:checked');
                checkedSum.textContent = totalChecked.length;
            });

            var _iterator8 = _createForOfIteratorHelper(checkers),
                _step8;

            try {
                for (_iterator8.s(); !(_step8 = _iterator8.n()).done;) {
                    var checker = _step8.value;
                    checker.addEventListener('change', function (e) {
                        var totalChecked = document.querySelectorAll('.users-table .check:checked');
                        checkedSum.textContent = totalChecked.length;
                    });
                }
            } catch (err) {
                _iterator8.e(err);
            } finally {
                _iterator8.f();
            }
        }
    })();

    var charts = {};
    var gridLine;
    var titleColor;

    (function () {
        /* Add gradient to chart */
        var width, height, gradient;

        function getGradient(ctx, chartArea) {
            var chartWidth = chartArea.right - chartArea.left;
            var chartHeight = chartArea.bottom - chartArea.top;

            if (gradient === null || width !== chartWidth || height !== chartHeight) {
                width = chartWidth;
                height = chartHeight;
                gradient = ctx.createLinearGradient(0, chartArea.bottom, 0, chartArea.top);
                gradient.addColorStop(0, 'rgba(255, 255, 255, 0)');
                gradient.addColorStop(1, 'rgba(255, 255, 255, 0.4)');
            }

            return gradient;
        }
        /* Visitors chart */


        var ctx = document.getElementById('myChart');

        if (ctx) {
            var myCanvas = ctx.getContext('2d');
            var myChart = new Chart(myCanvas, {
                type: 'line',
                data: {
                    labels: ['Dec', 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
                    datasets: [{
                        label: 'Last 6 months',
                        data: [35, 27, 40, 15, 30, 25, 45],
                        cubicInterpolationMode: 'monotone',
                        tension: 0.4,
                        backgroundColor: ['rgba(95, 46, 234, 1)'],
                        borderColor: ['rgba(95, 46, 234, 1)'],
                        borderWidth: 2
                    }, {
                        label: 'Previous',
                        data: [20, 36, 16, 45, 29, 32, 10],
                        cubicInterpolationMode: 'monotone',
                        tension: 0.4,
                        backgroundColor: ['rgba(75, 222, 151, 1)'],
                        borderColor: ['rgba(75, 222, 151, 1)'],
                        borderWidth: 2
                    }]
                },
                options: {
                    scales: {
                        y: {
                            min: 0,
                            max: 100,
                            ticks: {
                                stepSize: 25
                            },
                            grid: {
                                display: false
                            }
                        },
                        x: {
                            grid: {
                                color: gridLine
                            }
                        }
                    },
                    elements: {
                        point: {
                            radius: 2
                        }
                    },
                    plugins: {
                        legend: {
                            position: 'top',
                            align: 'end',
                            labels: {
                                boxWidth: 8,
                                boxHeight: 8,
                                usePointStyle: true,
                                font: {
                                    size: 12,
                                    weight: '500'
                                }
                            }
                        },
                        title: {
                            display: true,
                            text: ['Visitor statistics', 'Nov - July'],
                            align: 'start',
                            color: '#171717',
                            font: {
                                size: 16,
                                family: 'Inter',
                                weight: '600',
                                lineHeight: 1.4
                            }
                        }
                    },
                    tooltips: {
                        mode: 'index',
                        intersect: false
                    },
                    hover: {
                        mode: 'nearest',
                        intersect: true
                    }
                }
            });
            charts.visitors = myChart;
        }
        /* Customers chart */


        var customersChart = document.getElementById('customersChart');

        if (customersChart) {
            var customersChartCanvas = customersChart.getContext('2d');
            var myCustomersChart = new Chart(customersChartCanvas, {
                type: 'line',
                data: {
                    labels: ['Dec', 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
                    datasets: [{
                        label: '+958',
                        data: [90, 10, 80, 20, 70, 30, 50],
                        tension: 0.4,
                        backgroundColor: function backgroundColor(context) {
                            var chart = context.chart;
                            var ctx = chart.ctx,
                                chartArea = chart.chartArea;

                            if (!chartArea) {
                                // This case happens on initial chart load
                                return null;
                            }

                            return getGradient(ctx, chartArea);
                        },
                        borderColor: ['#fff'],
                        borderWidth: 2,
                        fill: true
                    }]
                },
                options: {
                    scales: {
                        y: {
                            display: false
                        },
                        x: {
                            display: false
                        }
                    },
                    elements: {
                        point: {
                            radius: 1
                        }
                    },
                    plugins: {
                        legend: {
                            position: 'top',
                            align: 'end',
                            labels: {
                                color: '#fff',
                                size: 18,
                                fontStyle: 800,
                                boxWidth: 0
                            }
                        },
                        title: {
                            display: true,
                            text: ['New Customers', '28 Daily Avg.'],
                            align: 'start',
                            color: '#fff',
                            font: {
                                size: 16,
                                family: 'Inter',
                                weight: '600',
                                lineHeight: 1.4
                            },
                            padding: {
                                top: 20
                            }
                        }
                    },
                    maintainAspectRatio: false
                }
            });
            customersChart.customers = myCustomersChart;
        }
    })();
    /* Change data of all charts */


    function addData() {
        var darkMode = localStorage.getItem('darkMode');

        if (darkMode === 'enabled') {
            gridLine = '#37374F';
            titleColor = '#EFF0F6';
        } else {
            gridLine = '#EEEEEE';
            titleColor = '#171717';
        }

        if (charts.hasOwnProperty('visitors')) {
            charts.visitors.options.scales.x.grid.color = gridLine;
            charts.visitors.options.plugins.title.color = titleColor;
            charts.visitors.options.scales.y.ticks.color = titleColor;
            charts.visitors.options.scales.x.ticks.color = titleColor;
            charts.visitors.update();
        }
    }

    addData();

    (function () {
        var boxes = document.querySelectorAll('.box');
        var targetList = document.querySelectorAll('.target');
        var itemWork = document.querySelectorAll('.item-work');

        var currentTarget = null;

        targetList.forEach(target => {
            target.addEventListener('dragstart', function (e) {
                this.classList.add('dragging')
                currentTarget = this;

            })

            target.addEventListener('dragend', function (e) {
                this.classList.remove('dragging')
                currentTarget = this;
            })
        })

        itemWork.forEach(function (item) {
            var box = item.querySelector('.box');

            if (!box.querySelector('.target')) {
                box.style.height = null;
            } else { }
            item.addEventListener('dragover', function (e) {
                e.preventDefault();
                box.appendChild(currentTarget);

                boxes.forEach(function (boxElement) {
                    if (!boxElement.querySelector('.target')) {
                        boxElement.style.height = null;
                    }
                });
                if (box.querySelector('.target')) {
                    box.style.height = null;
                }
                if (box.offsetHeight > 463) {
                    box.style.overflowY = "scroll";
                    box.style.height = '465px';
                } else {
                    box.style.overflowY = null;
                    box.style.height = null;
                }
            })
            item.addEventListener('drop', function (e) {
                box.appendChild(currentTarget);
                if (box.offsetHeight > 463) {
                    box.style.overflowY = "scroll";
                    box.style.height = '465px';
                } else {
                    box.style.overflowY = 'auto';
                    box.style.height = null;
                }
            })
        })
    })();

    (function () {
        var input = document.querySelectorAll('.ip-list');
        input.forEach(function (item) {
            item.addEventListener('focus', function () {
                this.style.cursor = 'auto';
                this.style.backgroundColor = '#fff';
                this.style.border = '2px solid rgb(5, 126, 214)';
            })
            item.addEventListener('focusout', function () {
                this.style.backgroundColor = 'rgba(252, 250, 248, 0)';
                this.style.cursor = 'pointer';
                this.style.border = null;
            })
        })
    })();


    var frameMember = document.querySelector('.member-accept');
    if (frameMember !== null) {
        if (frameMember.offsetHeight > 400) {
            frameMember.style.overflowY = "scroll";
            frameMember.style.height = '401px';
        } else {
            frameMember.style.overflowY = 'auto';
            frameMember.style.height = 'auto';
        }
    }

    var listWorks = document.querySelector('.listWorks');
    if (listWorks !== null) {
        if (listWorks.offsetHeight > 500) {
            listWorks.style.overflowY = "scroll";
            listWorks.style.height = '501px';
        } else {
            listWorks.style.overflowY = 'auto';
            listWorks.style.height = 'auto';
        }
    }

    var listTask = document.querySelector('.listTask');
    if (listTask !== null) {
        if (listTask.offsetHeight > 500) {
            listTask.style.overflowY = "scroll";
            listTask.style.height = '501px';
        } else {
            listTask.style.overflowY = 'auto';
            listTask.style.height = 'auto';
        }
    }

    var user = "<li data-bs-toggle='tooltip' data-popup='tooltip-custom' data-bs-placement='top' class='avatar avatar-xs pull-up' title='Christina Parker'> <img src='../assets/img/avatars/5.png' alt='Avatar' class='rounded-circle' /> </li>"
    $('.btn-add-member').click(function () {
        $('#list-member-groups').append(user);
    })

    $("#addNewMember").click(function () {
        var email = document.getElementById("emailMember").value;
        addUser(email, true);
        document.getElementById("emailMember").value = '';
    });

    $("#addLeader").click(function () {
        var email = document.getElementById("emailLeader").value;
        addUser(email, false);
        document.getElementById("emailLeader").value = '';
    });

    var memberList = [];
    function addUser(email, isMember) {
        searchUser(email).then(function (data) {
            if (data._id != null) {
                if (isMember) {
                    var isExist = false;
                    if ($("#dataListTeam").length > 0) {
                        getMemberByTeamId($("#dataListTeam").val())
                            .then(function (members) {
                                members.forEach(function (item, index) {
                                    if (item._id == data._id) {
                                        alert("Thành viên này đã tham gia nhóm");
                                        isExist = true;
                                        return;
                                    }
                                });
                                addMemberInList(data, isExist);
                            })
                            .catch(function (error) {
                                console.log(error);
                            });
                    } else {
                        addMemberInList(data, isExist);
                    }
                } else {
                    if ($("#mainId").val() == data._id) {
                        alert("Không thể thêm trưởng nhóm là chủ dự án");
                    } else {
                        $("#leaderList").empty();
                        generateItemUser(data, $("#leaderList"), $("#leaderId"), memberList);
                        $("#leaderId").val(data._id)
                    }
                }
            } else {
                alert("Email này chưa có tài khoản")
            }
        }).catch(function (error) {
            console.log(error);
        });
    }

    function addMemberInList(data, isExist) {
        if (!memberList.includes(data._id) && !isExist) {
            if ($("#leaderId").val() == data._id) {
                alert("Không thể thêm thành viên là nhóm trưởng");
            } else if ($("#mainId").val() == data._id) {
                alert("Không thể thêm thành viên là chủ dự án");
            } else {
                memberList.push(data._id);
                generateItemUser(data, $("#memberList"), $("#listIdMember"), memberList);
            }
        }
        $("#listIdMember").val(memberList.join(','));
    }

    var idTeam = null;
    var teamName = null;
    var listTeam = [];

    function getSelectedOption() {
        // Lấy giá trị và nội dung của option được chọndataListTeam
        idTeam = $("#dataListTeam").val();
        teamName = $("#dataListTeam").find("option:selected").text();
    }

    function addTeam() {
        if (!listTeam.includes(idTeam)) {
            listTeam.push(idTeam);
            var formTeam = $("#formTeam");
            var li = $("<li></li>").addClass("list-group-item d-flex justify-content-between align-items-center").css("height", "100%");
            var span = $("<span></span>")
            var index = listTeam.indexOf(idTeam);
            var removeButton = $("<button></button>").addClass("btn btn-sm btn-danger ms-2").html('<i class="bx bx-x"></i>');
            removeButton.on("click", function () {
                listTeam.splice(index, 1);
                listItem.remove();
                $("#teamId").val(listRemove.join(','));
            });
            span.text(teamName);
            li.append(span);
            li.append(removeButton);
            formTeam.append(li);
        }
    }

    $("#dataListTeam").change(function () {
        getSelectedOption();
        updateTeamId();
    });

    $("#btnAddTeam").click(function () {
        getSelectedOption();
        addTeam();
        $("#teamId").val(listTeam.join(','));
    })

    // Lắng nghe sự kiện khi người dùng chọn một option trong datalist
    $("#selectWork").on("input", function () {
        var selectedOption = $("#datalistWorks option[value='" + $(this).val() + "']");
        if (selectedOption.length > 0) {
            $("#workId").val(selectedOption.attr("id"));
        }
        if ($("#workId").val() != '') {
            getMembersByIdWork($("#workId").val())
                .then(function (data) {
                    // Tiếp tục xử lý dữ liệu tại đây
                    var datalist = $("#datalistMembers");
                    datalist.empty(); // Xóa các option cũ trong datalist
                    $.each(data, function (index, item) {
                        $.each(item.listMembers, function (index, member) {
                            datalist.append(`<option value="${member.fullName}" id="${member.id}"></option>`);
                        });
                    });
                })
                .catch(function (error) {
                    console.error(error); // Xử lý lỗi (nếu có)
                });
        }
    });

    //Biến sử dụng cho phần phân công thành viên vào task
    var listNewMemberByWorkId = [];
    var listIdOfOldMember = [];
    var listIndex= [];

    $('#assignment').change(function () { 
        var selectedValue = $(this).val();

        if (!isEmail(selectedValue)) {
            var selectedOption = $("#datalistMembers option[value='" + $(this).val() + "']");
            getUserById(selectedOption.attr("id"))
                .then(function (data) {
                    genarateAssignment(data, false);
                    $("#memberId").val(listNewMemberByWorkId.join(','));
                    listNewMemberByWorkId = [];
                    $(this).val('');
                })
                .catch(function (error) {
                    console.error(error); // Xử lý lỗi (nếu có)
                });
        }
    });

    $('#emailMemberDetail').change(function () {
        var selectedValue = $(this).val();
        var elements = $("#listMemberDetail").val().split(",");

        if (elements.length > 0) {
            elements.forEach(function (item) {
                if (item != "") {
                    listIdOfOldMember.push(item.trim());
                }
            });
        }
        if (!isEmail(selectedValue)) {
            var selectedOption = $("#datalistDetail option[value='" + $(this).val() + "']");
            getUserById(selectedOption.attr("id"))
                .then(function (data) {
                    genarateAssignment(data, true);
                    // Gộp hai mảng lại thành một mảng mới
                    var mergedList = listNewMemberByWorkId.concat(listIdOfOldMember);

                    // Lọc các phần tử không trùng lặp bằng cách sử dụng Set
                    var uniqueList = Array.from(new Set(mergedList));

                    $("#listMemberDetail").val(uniqueList.join(','));
                    $(this).val('');
                })
                .catch(function (error) {
                    console.error(error); // Xử lý lỗi (nếu có)
                });
        }
    });

    $('#btnAssignment').click(function () {
        var email = $("#assignment").val();
        searchUser(email).then(function (data) {
            if (data._id != null) {
                if ($("#mainId").val() == data._id) {
                    alert("Không thể phân công thành viên là chủ dự án");
                } else if (!memberList.includes(data._id)) {
                    genarateAssignment(data, false);
                    $("#memberId").val(listNewMemberByWorkId.join(','));
                    listNewMemberByWorkId = [];
                    $(this).val('');
                }
            } else {
                alert("Email này chưa có tài khoản")
            }
        }).catch(function (error) {
            console.log(error);
        });
        $("#assignment").val("");
    });

    $('#btnAssignmentDetail').click(function () {
        var email = $("#emailMemberDetail").val();

        var elements = $("#listMemberDetail").val().split(",");

        if (elements.length > 0) {
            elements.forEach(function (item) {
                if (item != "") {
                    listIdOfOldMember.push(item.trim());
                }
            });
        }

        searchUser(email).then(function (data) {
            if (data._id != null) {
                if ($("#mainId").val() == data._id) {
                    alert("Không thể phân công thành viên là chủ dự án");
                } else if (!listIdOfOldMember.includes(data._id)) {
                    genarateAssignment(data, true);
                    // Gộp hai mảng lại thành một mảng mới
                    var mergedList = listNewMemberByWorkId.concat(listIdOfOldMember);

                    // Lọc các phần tử không trùng lặp bằng cách sử dụng Set
                    var uniqueList = Array.from(new Set(mergedList));

                    $("#listMemberDetail").val(uniqueList.join(','));

                    $(this).val('');
                }
            } else {
                alert("Email này chưa có tài khoản")
            }
        }).catch(function (error) {
            console.log(error);
        });
        $("#emailMemberDetail").val("");
    });

    //Check có phải email không
    function isEmail(input) {
        // Biểu thức chính quy để kiểm tra định dạng email
        const emailRegex = /^\S+@\S+\.\S+$/;
        // Kiểm tra xem chuỗi input có khớp với biểu thức chính quy hay không
        return emailRegex.test(input);
    }
    // Hàm tạo danh sách thành viên phân công
    function genarateAssignment(data, isDetail) {
        if (!listNewMemberByWorkId.includes(data._id)) {

            listNewMemberByWorkId.push(data._id);
            var listItem = $("<li></li>").addClass("list-group-item d-flex justify-content-between align-items-center");
            var removeButton = $("<button></button>").addClass("btn btn-sm btn-danger ms-2").html('<i class="bx bx-x"></i>');
            var index = listNewMemberByWorkId.indexOf(data._id);

            if (isDetail) {
                removeButton.on("click", function () {
                    if (listIndex.length > 0) {
                        index = listIndex.indexOf(data._id);
                    }
                    listNewMemberByWorkId.splice(index, 1);
                    listIndex = listNewMemberByWorkId;
                    listItem.remove();
                    $("#listMemberDetail").val(listNewMemberByWorkId.join(','));
                });
            } else {
                removeButton.on("click", function () {
                    listNewMemberByWorkId.splice(index, 1);
                    listItem.remove();
                    $("#memberId").val(listNewMemberByWorkId.join(','));
                });
            }

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
            listItem.append(removeButton);
            if (isDetail) {
                $('#dataListMemberDetail').append(listItem);
            } else {
                $('.list_assign').append(listItem);
            }
        }
    }
    
    // gán giá trị level lúc tạo task
    $('input[name="selectLevel"]').change(function () {
        var selectedValue = $('input[name="selectLevel"]:checked').val();
        $("#level").val(selectedValue);
    });

    $('input[name="statusRadio"]').change(function () {
        var selectedValue = $('input[name="statusRadio"]:checked').val();
        $("#level").val(selectedValue);
    });

    $('input[name="levelRadio"]').change(function () {
        var selectedValue = $('input[name="levelRadio"]:checked').val();
        $("#status").val(selectedValue);
    });

    // Click change status
    $(".btnStatus").click(function () {
        var id = $(this).data('id');
        $('#status-form-' + id ).submit();
    })

    // Click delete
    $(".btnDelete").click(function () {
        var id = $(this).data('id');
        $('#delete-form-' + id).submit();
    })

    //Edit task
    $(".edit-task").click(function () {
        var taskId = $(this).data('id');
        getTaskById(taskId)
            .then(function (data) {
                $("#_idUpdate").val(data._id);

                $("#nameTask").text(data.name);
                $("#hNameTask").val(data.name);

                $("#descriptTask").text(data.description);
                $("#hdescriptTask").val(data.description);

                $("#levelUpdate").val(data.level);
                if (data.level == 1) {
                    $('#rdoNormal').prop('checked', true);
                } else if (data.level == 2) {
                    $('#rdoWarning').prop('checked', true);
                } else {
                    $('#rdoDanger').prop('checked', true);
                }

                $("#statusUpdate").val(data.status);
                if (data.status) {
                    $('#rdoSuccess').prop('checked', true);
                } else {
                    $('#rdoDoing').prop('checked', true);
                }
                $('#time-start').val(convertTime(data.startHour));
                $('#time-end').val(convertTime(data.endHour));
                $('#date-start').val(convertDate(data.startDay));
                $('#date-end').val(convertDate(data.endDay));
                getUserByTaskId(taskId)
                    .then(function (userInTask) {
                        $.each(userInTask, function (index, item) {
                            genarateAssignment(item, true);
                        })
                        
                    })
                    .catch(function (error) {
                        console.error(error); // Xử lý lỗi (nếu có)
                    });
                getMembersByIdWork(data.workId)
                    .then(function (userInWork) {
                        // Tiếp tục xử lý dữ liệu tại đây
                        var datalist = $("#datalistDetail");
                        datalist.empty(); // Xóa các option cũ trong datalist
                        $.each(userInWork, function (index, item) {
                            $.each(item.listMembers, function (index, member) {
                                datalist.append(`<option value="${member.fullName}" id="${member.id}"></option>`);
                            });
                        });
                    })
                    .catch(function (error) {
                        console.error(error); // Xử lý lỗi (nếu có)
                    });
            })
            .catch(function (error) {
                console.error(error); // Xử lý lỗi (nếu có)
            });
    })

    //convert time to 24h
    $("#startHour").change(function () {
        var timeValue = $(this).val();
        changeTimeTo24h(timeValue);
    })

    $("#endHour").change(function () {
        var timeValue = $(this).val();
        changeTimeTo24h(timeValue);
    })

    function changeTimeTo24h(time) {
        const time24 = new Date("2000-01-01T" + time + ":00");
        const time24String = time24.toTimeString().slice(0, 5);
        $(this).val(time24String);
    }

    //Logout
    $("#btnLogout").click(function () {
        $('#form-logout').submit();
    })

    //Add Member
    function updateTeamId() {
        var selectedTeamId = $('#dataListTeam').val();
        if (selectedTeamId != 0) {
            $('#formAddMember').attr('action', '/Team/CreateMember?teamId=' + selectedTeamId);
        }
    }
});



