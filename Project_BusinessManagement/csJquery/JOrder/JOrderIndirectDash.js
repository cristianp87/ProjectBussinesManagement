$(document).ready(function () {
    LoadTypeIdentification();
    LoadInventory();
    
});
var arrayOrderItem = new Array();
var lTotalizador = parseFloat(0);

$('#btnConfirmCustomer').click(function () {
    hideException();
    $.ajax({
        type: 'POST',
        url: yourApp.Urls.GetCustomer,
        dataType: 'json',
        data: { pIdtypeIdentification: $('#ddlTypeIdentification').val(), pNoIdentification: $('#txtDocCustomer').val() },
        success: function (customer) {           
            processOrderDash(customer);
        },
        error: function (ex) {
            showException('No se pudo Ingresar el producto error.' + ex);
        }
    });
});

function processOrderDash(customer)
{
    if (customer.Success) {
        $('#OrderDash').removeClass('hide');
        $('#linkCustomer > span').removeClass('glyphicon glyphicon-remove');
        $('#linkCustomer > span').removeClass('glyphicon glyphicon-ok');
        $('#linkCustomer > span').addClass('glyphicon glyphicon-ok');
        $('#linkCustomer').href = '#';
        $('#hdnIdcustomer').val(customer.Content.LIdCustomer);

    } else {
        $('#OrderDash').removeClass('hide');
        $('#OrderDash').addClass('hide');
        $('#linkCustomer > span').removeClass('glyphicon glyphicon-remove');       
        $('#linkCustomer > span').removeClass('glyphicon glyphicon-ok')
        $('#linkCustomer > span').addClass('glyphicon glyphicon-remove');
        $('#linkCustomer').prop("href", yourApp.Urls.GoCustomer);
    }
}



$('#btnItem').click(function () {
    hideException();
    if ($('#ddlInventory').val() != "0") {
        if ($('#txtCntProduct').val() != "") {
            $.ajax({
                type: 'POST',
                url: yourApp.Urls.getItem,
                dataType: 'json',
                data: { idProduct: $("#txtProduct").val() },
                success: function (product) {
                    if (product.Success) {
                        ajaxItem(product.Content)
                    } else {
                        showException('No se pudo Ingresar el producto.' + product.Message);
                    }
                },
                error: function (ex) {
                    showException('No se pudo Ingresar el producto.' + ex);
                }
            });
        } else {
            showException('Debe ingresar la cantidad del producto');
        }
       
    } else {
        showException('El inventario debe seleccionarse');
    }

});

$('#txtCntProduct').on('input', function (e) {
    if (!/^[0-9.]*$/i.test(this.value)) {
        this.value = this.value.replace(/[^0-9.]+/ig, "");
    }
});

$('#btnCreateOrder').click(function () {
    hideException();
    if ($('#ddlInventory').val() != "0") {
        OrderItemAll();
        $.ajax({
            type: 'POST',
            url: yourApp.Urls.CreateOrderItem,
            dataType: 'json',
            data: { pOrder: processOrder($('#hdnIdcustomer').val(), $('#ddlInventory').val()) },
            success: function (product) {
                if (product.Success){
                    showSuccess('Se ha generado el pedido.');
                    $('#linkInvoice').prop("href", yourApp.Urls.GoOrderDetails + "?pIdOrder=" + product.Content).text("Ver Pedido");
                }                   
                else
                    showException('No se pudo Ingresar el pedido.' + product.Content);
            },
            error: function (ex) {
                showException('No se pudo Ingresar el pedido.' + ex);
            }
        });
    } else {
        showException('El inventario debe seleccionarse.');
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
    $.each(inventorys, function (i, inventory) {
        $("#ddlInventory").append('<option value="'
    + inventory.LIdInventory + '">'
    + inventory.LNameInventory + '</option>');
        });
}

function ajaxTypeIdentification(pListTypeIdentification) {
    $.each(pListTypeIdentification, function (i, typeIdentification) {
        $("#ddlTypeIdentification").append('<option value="'
    + typeIdentification.Value + '">'
    + typeIdentification.Text + '</option>');
        });
}

function OrderItemAll() {
    this.clearVariables();
    var lListOrderItem = new Array();
    $("#tableOrder tbody tr").each(function (index) {
        var lCodProduct, lTotal, lCantProduct, lValueProduct, lValueTaxes;
        $(this).children("td").each(function (index2) {
            switch (index2) {
                case 1:
                    lCodProduct = $(this).text();
                    break;
                case 3:
                    lValueProduct = $(this).text();  
                    break;
                case 4:
                    lCantProduct = $(this).text();
                    break;
                case 5:
                    lValueTaxes = $(this).text();
                    break;
                case 6:
                    lTotal = $(this).text();
                    break;
            }
        });
        addOrderItemArray(new MOrderItem(lCodProduct, lValueProduct, '0', lValueTaxes, '0', lCantProduct, lTotal));
    });
}

function addOrderItemArray(pOrderItem) {
    arrayOrderItem.push(pOrderItem);
}

function processOrder(pIdCustomer, pIdInventory) {
    return new MOrder(arrayOrderItem, pIdCustomer, pIdInventory)
}

function MOrderItem(pCodProduct,pValue,pValueSupplier, pValueTaxes, pValueDesc, pCantProduct, pTotal) {
    this.LIdOrderItem = 0;
    this.LProduct = new MProduct(pCodProduct);
    this.LCreationDate = new Date();
    this.LStatus = null;
    this.LObject = null;
    this.LOrder = null;   
    this.LValueProduct = '0';
    this.LValueSupplier = '0';
    this.LValueTaxes = '0';
    this.LValueDesc = '0';
    this.LMessageException = "";
    this.LQty = '0';
    this.LValueTotal = '0';
    this.LValueProduct = ConvertToDecimal(pValue);
    this.LValueSupplier = ConvertToDecimal(pValueSupplier);
    this.LValueTaxes = ConvertToDecimal(pValueTaxes);
    this.LValueDesc = ConvertToDecimal(pValueDesc);
    this.LQty = ConvertToDecimal(pCantProduct);
    this.LValueTotal = ConvertToDecimal(pTotal);
}

function MOrder(pListOrderItem, pIdCustomer, pIdInventory) {
    this.LIdOrder = 0;
    this.LCreationDate = new Date();
    this.LStatus = null;
    this.LObject = null;
    this.LInventory = new MInventory(pIdInventory);
    this.LCustomer = new MCustomer(pIdCustomer);
    this.LMessageException;
    this.lListOrderItem = pListOrderItem;
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
                    if (updateProduct) {
                        var lbeforeTotal = parseFloat($(this).text());
                        lTotal = (product.LValue + sumTaxe) * lCantProduct;
                        $(this).text(lTotal);
                        lTotalizador = (lTotalizador - lbeforeTotal) + lTotal;
                        $("#lblTotalizador").text("" + lTotalizador + "$");
                    }
                    break;
            }
            
        });
    });
    if (!updateProduct) {
        lTotalizador = lTotalizador + (product.LValue + sumTaxe) * $("#txtCntProduct").val();
        $("#lblTotalizador").text("" + lTotalizador + "$");
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

function clearVariables() {
    arrayOrderItem = new Array();
    lTotalizador = 0;
}

function showException(message) {
    $('#dvException').removeClass("hide");
    $('#lblException').removeClass("alert-success").removeClass("alert-danger").addClass("alert-danger");
    $('#lblException').text(message);
}

function showSuccess(message) {
    $('#dvException').removeClass("hide");
    $('#lblException').removeClass("alert-danger").addClass("alert-success");
    $('#lblException').text(message);
}

function hideException() {
    $('#dvException').addClass("hide");
    $('#lblException').val("");
}

function ConvertToDecimal(value){
    return value.replace(".", ",")
}




