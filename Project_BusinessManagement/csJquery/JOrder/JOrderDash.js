$(document).ready(function () {
    LoadInventory();
});
var arrayOrderItem = new Array();

$('#btnItem').click(function () {
    if ($('#ddlInventory').val() != "0") {
        $.ajax({
            type: 'POST',
            url: yourApp.Urls.getItem,
            dataType: 'json',
            data: { idProduct: $("#txtProduct").val() },
            success: function (product) {
                if (product.Success) {
                    ajaxItem(product.Content)
                } else {
                    alert('No se pudo Ingresar el producto.' + product.Message);
                }
            },
            error: function (ex) {
                alert('No se pudo Ingresar el producto.' + ex);
            }
        });
    } else {
        alert('El inventario debe seleccionarse');
    }

});

$('#btnCreateOrder').click(function () {
    if ($('#ddlInventory').val() != "0") {
        OrderItemAll();
        $.ajax({
            type: 'POST',
            url: yourApp.Urls.CreateOrderItem,
            dataType: 'json',
            data: { pListItems: JSON.stringify(arrayOrderItem) },
            success: function (product) { ajaxItem(product) },
            error: function (ex) {
                alert('No se pudo Ingresar el pedido.' + ex);
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

function OrderItemAll() {
    var lListOrderItem = new Array();
    $("#tableOrder tbody tr").each(function (index) {
        var lCodProduct, lsumTaxeprd, lValueProduct, lTotal, lCantProduct;
        $(this).children("td").each(function (index2) {
            switch (index2) {
                case 1:
                    lCodProduct = $(this).text();
                    break;
                case 4:
                    lCantProduct = parseFloat($(this).text());
                    break;
                case 6:
                    lTotal = parseFloat($(this).text());
                    break;
            }
        });
        addOrderItemArray(new MOrderItem(lCodProduct, lCantProduct, lTotal));
    });
}

function addOrderItemArray(pOrderItem) {
    arrayOrderItem.push(pOrderItem);
}

function MOrderItem(lCodProduct, lCantProduct, lTotal) {
    this.LProduct = new MProduct(lCodProduct);
    this.LQty = parseFloat(0);
    this.LValueTotal = parseFloat(0);
    this.LQty = lCantProduct;
    this.LValueTotal = lTotal;
}

function MProduct(lCodProduct) {
    this.LCdProduct = lCodProduct;
}

function ajaxItem(product) {
    var sumTaxe = sumTaxes(product);
    var updateProduct = false;
    $("#tableOrder tbody tr").each(function (index) {
        var lCodProduct, lsumTaxeprd, lValueProduct, lTotal, lCantProduct ;
        $(this).children("td").each(function (index2) {
            switch (index2) {              
                case 1:
                    lCodProduct = $(this).text();
                    if (lCodProduct == product.LCdProduct) {                        
                        updateProduct = true;
                    }
                    break;
                case 4:
                    if(updateProduct){
                        lCantProduct = parseFloat($(this).text());
                        lCantProduct = lCantProduct + parseFloat($("#txtCntProduct").val());
                        $(this).text(lCantProduct);
                    }
                    break;
                case 6:
                    if(updateProduct){
                        lTotal = (product.LValue + sumTaxe) * lCantProduct;
                        $(this).text(lTotal);
                    }
                    break;
            }
        });
    });
    if (!updateProduct) {
        $("#tableOrder").append('<tr id="row' + $("#tableOrder")["0"].rows.length + '"><td>'
        + $("#ddlInventory option:selected").text() + '</td><td>'
        + product.LCdProduct + '</td><td>'
        + product.LNameProduct + '</td><td>'
        + product.LValue + '</td><td>'
        + $("#txtCntProduct").val() + '</td><td>'
        + sumTaxe + '</td><td>'
        + (product.LValue + sumTaxe) * $("#txtCntProduct").val() + '</td><td>'
        + '<input id="btnDeleterow" type="button" value="Eliminar" onclick="deleteRow(' + $("#tableOrder")["0"].rows.length + ');" /></td>'
    + '</tr>');
    }
    
}

function sumTaxes(product){
    var sumTaxes = 0;
    for(var i = 0; product.LListTaxe.length > i; i++){
        if(product.LListTaxe[i].LIsPercent == false){
            sumTaxes = sumTaxes + product.LListTaxe[i].LValueTaxe
        }else{
            sumTaxes = sumTaxes + (product.LValue * product.LListTaxe[i].LValueTaxe)/100;
        }        
    }
    return  sumTaxes;
}

function deleteRow(index) {
    $('#row' + index).remove();
}

$(document).on("click",".btnDeleterow",function(){
    var parent = $(this).parents().get(0);
    $(parent).remove();
});