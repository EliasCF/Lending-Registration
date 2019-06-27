$(function () {
    LoadUsersReservedComputers($('#userId')[0].value);
    LoadAllUnreaservedComputers();

    $.scrollify({
        section: '.panel',
        scrollbars: true,
        before: function (index, sections) {
            var ref = '#' + sections[index].attr("data-section-name");

            //Update which menu item is active
            for (var i = 0; i < $('.menu-pagination li').length; i++) {
                const sectionHref = $('.menu-pagination li a')[i];
                const listElement = $('.menu-pagination li')[i];

                if ($(sectionHref).attr('href') !== ref) {
                    $(listElement).removeClass('active-section');
                } else {
                    $(listElement).addClass('active-section');
                }
            }
        },
        afterRender: function () {
            //Move to new section
            $(".menu-pagination a").on("click", function () {
                $.scrollify.move($(this).attr("href"));
            });

            $('.check-out-button').on('click', function () {
                let toBeDeleted = $.makeArray($('.forDeletion')).filter(fd => fd.checked === true);

                //Check computer(s) out asynchronous
                const start = async function () {
                    await asyncForEach(toBeDeleted, async function (computer) {
                        await $.ajax({
                            url: `/api/loanedComputer/${computer.value}`,
                            type: 'DELETE',
                            success: function () {
                                //Remove deleted computer from table
                                $('#row-' + computer.name).remove();
                            }
                        });
                    });
                };

                start().then(function () {
                    LoadAllUnreaservedComputers();
                });
            });

            $('.reserve-button').on('click', function () {
                let toBeAdded = $.makeArray($('.forAdding')).filter(fd => fd.checked === true);

                //Reserve computer(s) asynchronous
                const start = async function () {
                    await asyncForEach(toBeAdded, async function (item) {
                        await $.post('/api/loanedComputer', {
                            computerId: item.value,
                            loaned_Date: $('#from-date').val(),
                            loanExpiration_Date: $('#to-date').val(),
                            userId: $('#userId')[0].value
                        }
                        );
                    });
                };

                start().then(function () {
                    LoadUsersReservedComputers($('#userId')[0].value);
                    LoadAllUnreaservedComputers();
                });
            });

            //Make sure scrollify doesn't scroll when using overflow table
            $('#loans-table').hover(function () {
                $.scrollify.disable();
            }, function () {
                $.scrollify.enable();
            });
        }
    });
});

async function asyncForEach(array, callback) {
    for (let index = 0; index < array.length; index++) {
        await callback(array[index], index, array);
    }
}

//Load the computers reserved by a specific user
function LoadUsersReservedComputers(userId) {
    $('#loan-table-rows').empty();

    $.get('/api/loanedComputer/user/' + userId, (result) => {
        result.forEach((item, i) => {
            $('#loan-table-rows').append(`
                    <tr id="row-${i}">
                        <td><input type="checkbox" value="${item.id}" name="${i}" class="forDeletion"></td>
                        <td>${item.computer.name}</td>
                        <td>${item.loaned_Date.replace('T', ' ')}</td>
                        <td>${item.loanExpiration_Date.replace('T', ' ')}</td>
                    </tr>`);
        });
    });
}

//Load all unreserved computers
function LoadAllUnreaservedComputers() {
    $('#unreserved-table-rows').empty();

    $.get('/api/computer/unreserved', (result) => {
        result.forEach((item, i) => {
            $('#unreserved-table-rows').append(`
                    <tr id="row-${i}">
                        <td><input type="checkbox" value="${item.id}" name="${i}" id="check-${i}" class="forAdding"></td>
                        <td>${item.name}</td>
                        <td>${item.model.brand.brand_Name}</td>
                        <td>${item.mouse.name}</td>
                        <td>${item.mouse.type}</td>
                        <td>${item.mouse.brand.brand_Name}</td>
                    </tr>`);
        });
    });
}