﻿$(document).ready(function () {
    LoadTypeIdentification();
    LoadInventory();
    
});
var arrayOrderItem = new Array();

$('#btnConfirmCustomer').click(function () {
    $.ajax({
        type: 'POST',
        url: yourApp.Urls.GetCustomer,
        dataType: 'json',
        data: { pIdtypeIdentification: $("#ddltypeIdentification").val(), pNoIdentification: $("#txtDocCustomer").val() },
        success: function (customer) {
            if (customer.Success) {
                ajaxItem(product.Content)
            } else {
                alert('No se pudo Ingresar el producto.' + product.Message);
            }
        },
        error: function (ex) {
            alert('No se pudo Ingresar el producto.' + ex);
        }
    });
});

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
            data: { pListItems: arrayOrderItem },
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

function LoadTypeIdentification(){
    $.ajax({  
        type: 'POST',  
        url: yourApp.Urls.GetListTypeIdentification,
        dataType: 'json',   
        success: function (listTypeIdentification) { ajaxTypeIdentification(listTypeIdentification) },
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

function ajaxTypeIdentification(pListTypeIdentification) {
    // states contains the JSON formatted list  
    // of states passed from the controller  
    $.each(pListTypeIdentification, function (i, typeIdentification) {
        $("#ddlTypeIdentification").append('<option value="'
    + typeIdentification.Value + '">'
    + typeIdentification.Text + '</option>');
        });
}

function OrderItemAll() {
    var lListOrderItem = new Array();
    $("#tableOrder tbody tr").each(function (index) {
        var lCodProduct, lTotal, lCantProduct;
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
    this.LIdOrderItem = 0;
    this.LProduct = new MProduct(lCodProduct);
    this.LCreationDate = new Date();
    this.LStatus = null;
    this.LObject = null;
    this.LOrder = null;   
    this.LValueProduct = parseFloat(0);
    this.LValueSupplier = parseFloat(0);
    this.LValueTaxes = parseFloat(0);
    this.LValueDesc = parseFloat(0);
    this.LMessageException = "";
    this.LQty = parseFloat(0);
    this.LValueTotal = parseFloat(0);
    this.LQty = lCantProduct;
    this.LValueTotal = lTotal;
}

function MOrder(lCodProduct, lCantProduct, lTotal) {
    this.LIdOrder = 0;
    this.LCreationDate = new Date();
    this.LStatus = null;
    this.LObject = null;
    this.LInventory = null;
    this.LCustomer = new MCustomer(0);
    this.LMessageException;
    this.lListOrderItem;
}

function MCustomer(lIdcustomer) {
    this.LIdCustomer = 0;
    this.LNameCustomer = "";
    this.LLastNameCustomer = "";
    this.LCreationDate = new Date();
    this.LTypeIdentification = null;
    this.LNoIdentification = "";
    this.LStatus = null;
    this.LObject = null;
    this.LListTypeIdentification = null;
    this.LListStatus = null;
    this.LMessageException = "";
    this.LModificationDate = new Date();
    this.LIdCustomer = lIdcustomer;
}

function MInventory(lIdInventory) {
    this.LIdInventory = 0;
    this.LNameInventory = "";
    this.LCreationDate = new Date();
    this.LStatus = null;
    this.LObject = null;
    this.LListInventoryItem = null;
    this.LListStatus = null;
    this.LMessageException = "";
    this.LIdInventory = lIdInventory;
}




function MProduct(lCodProduct) {
    this.LIdProduct = 0;
    this.LNameProduct = "";
    this.LCdProduct = "";
    this.LCreationDate = new Date();
    this.LUnit = null;
    this.LValue = parseFloat(0);
    this.LSupplier;
    this.LValueSupplier;
    this.LObject = null;
    this.LStatus = null;
    this.LListStatus = null;
    this.LListUnit = null;
    this.LListSupplier = null;
    this.LMessageException = null;
    this.LListSelectTaxe = null;
    this.LListTaxe = null;
    this.LTaxe = null;
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