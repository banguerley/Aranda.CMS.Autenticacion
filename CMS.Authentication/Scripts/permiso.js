$('a[name*="btnPermiso"]').click(function (eve) {
    var id = eve.currentTarget.dataset.id;
    console.log("Id : ", id);
    $("#modal-content").load("/Rol/Permisos/"+ id);
});