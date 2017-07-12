$(document).ready(function () {
    LoadInventory();
});

$('#btnItem').click(function () {
    if ($('#ddlInventory').val() != "0") {
        $.ajax({
            type: 'POST',
            url: yourApp.Urls.getItem,
            dataType: 'json',
            data: { idProduct: $("#txtProduct").val() },
            success: function (product) { ajaxItem(product) },
            error: function (ex) {
                alert('No se pudo Ingresar el producto.' + ex);
            }
        });
    } else {
        alert('El inventario debe seleccionarse');
    }

});

$('#btnCreate').click(function () {
    if ($('#ddlInventory').val() != "0") {
        $.ajax({
            type: 'POST',
            url: yourApp.Urls.getItem,
            dataType: 'json',
            data: { idProduct: $("#txtProduct").val() },
            success: function (product) { ajaxItem(product) },
            error: function (ex) {
                alert('No se pudo Ingresar el producto.' + ex);
            }
        });
    } else {
        alert('El inventario debe seleccionarse');
    }

});
function LoadInventory(){
    $.ajax({  
        type: 'POST',  
        url: yourApp.Urls.getAllInventory,
        dataType: 'json',   
        success: function (inventorys) { ajaxInventory(inventorys) },
        error: function (ex) {  
            alert('No se pudo cargar la lista.' + ex);  
        }  
    });   
}

function ajaxInventory(inventorys) {
    // states contains the JSON formatted list  
    // of states passed from the controller  
    $.each(inventorys, function (i, inventory) {
        $("#ddlInventory").append('<option value="'
    + inventory.LIdInventory + '">'
    + inventory.LNameInventory + '</option>');
        });
}

function ajaxItem(product) {

     $("#tableOrder").append('<tr><td>'
        + $("#ddlInventory option:selected").text() + '</td><td>"'
        + product.LNameProduct + '"</td><td>'
        + product.LValue + '</td><td>'
        + $("#txtCntProduct").val() + '</td><td>'
        + product.LValue * $("#txtCntProduct").val() + '</td>'
    + '</tr>');
}