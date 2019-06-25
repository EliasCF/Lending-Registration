$(function () {
    $.scrollify({
        section: '.panel',
        scrollbars: true,
        overflowScroll: true,
        touchScroll: false,
        afterRender: function () {
            $(".menu-pagination a").on("click", function () {
                //Give 'active-section' class to the new chosen section
                //and remove it from the old section
                for (var i = 0; i < $('.menu-pagination li').length; i++) {
                    console.log($('.menu-pagination li')[i]);

                    const sectionHref = $('.menu-pagination li a')[i];
                    const listElement = $('.menu-pagination li')[i];

                    if ($(sectionHref).attr('href') !== $(this).attr('href')) {
                        $(listElement).removeClass('active-section');
                    } else {
                        $(listElement).addClass('active-section');
                    }
                }

                //Move to new section
                $.scrollify.move($(this).attr("href"));
            });

            $('.check-out-button').on('click', function () {
                let toBeDeleted = $.makeArray($('.forDeletion')).filter(fd => fd.checked === true);

                toBeDeleted.forEach(function (computer) {
                    $.ajax({
                        url: `/api/loanedComputer/${computer.value}`,
                        type: 'DELETE',
                        success: function () {
                            //Remove deleted computer from table
                            $('#row-' + computer.name).remove();
                        }
                    });
                });
            });

            $('#loans-table').hover(function () {
                    $.scrollify.disable();
            }, function () {
                    $.scrollify.enable();
                    });
        }
    });
});