$(document).ready(function () {
    $('.nav-link').click(function () {
        var status = $(this).data('status');

        $.ajax({
            url: '/UserDashboard/GetServicesByStatus',
            type: 'GET',
            data: { status: status },
            success: function (result) {
                $('#serviceListContainer').html(result);
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});
