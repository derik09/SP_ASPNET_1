$("#dialog").dialog({
    autoOpen: false,
    modal: true,
    title: "View Details"
});

function editRoles(userId) {
    //$('#dialog').dialog('open');
        
    //$.ajax({
    //    type: "POST",
    //    url: "/Home/Details",
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "html",
    //    success: function (response) {
    //        $('#dialog').html(response);
    //        $('#dialog').dialog('open');
    //    },
    //    failure: function (response) {
    //        alert(response.responseText);
    //    },
    //    error: function (response) {
    //        alert(response.responseText);
    //    }
    //});
    $('#dialog').dialog('open');
}