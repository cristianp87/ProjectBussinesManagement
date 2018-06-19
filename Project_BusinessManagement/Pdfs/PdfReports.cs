using iTextSharp.text;
using iTextSharp.text.pdf;
using Project_BusinessManagement.Models.Reports;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Enums;
using System.Linq;
using System;

namespace Project_BusinessManagement.Pdfs
{
    public static class PdfReports
    {
        #region variables and constant
        private static string _lRouteSales = ConfigurationManager.AppSettings["RoutePdfSales"];
        private static string _lRouteAccountReceivable = ConfigurationManager.AppSettings["RoutePdfAccountReceivable"];
        private static string _lRouteInventory = ConfigurationManager.AppSettings["RoutePdfInventory"];
        private static string _lRouteCashRegister = ConfigurationManager.AppSettings["RoutePdfCashRegister"];
        #endregion
        public static void GeneratePdfSales( List<MReportSales> report)
        {
            // Creamos el documento con el tamaño de página tradicional
            var doc = new Document(PageSize.LETTER);
            string pathToFiles = HttpContext.Current.Server.MapPath(_lRouteSales);
            // Indicamos donde vamos a guardar el documento
            var writer = PdfWriter.GetInstance(doc,
                                        new FileStream(pathToFiles, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Ventas ");
            doc.AddCreator("Gestion Digital");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Ventas VideoJuegos RT"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable lTblReport = new PdfPTable(5);
            lTblReport.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla

            var lCdInvoice= new PdfPCell(new Phrase("Codigo", _standardFont));
            lCdInvoice.BorderWidth = 0;
            lCdInvoice.BorderWidthBottom = 0.45f;

            var lCdProduct = new PdfPCell(new Phrase("Codigo Producto", _standardFont));
            lCdProduct.BorderWidth = 0;
            lCdProduct.BorderWidthBottom = 0.45f;

            var lNameProduct = new PdfPCell(new Phrase("Nombre Producto", _standardFont));
            lNameProduct.BorderWidth = 0;
            lNameProduct.BorderWidthBottom = 0.45f;

            var lCreationDate = new PdfPCell(new Phrase("Fecha", _standardFont));
            lCreationDate.BorderWidth = 0;
            lCreationDate.BorderWidthBottom = 0.45f;

            var lValue = new PdfPCell(new Phrase("Total", _standardFont));
            lValue.BorderWidth = 0;
            lValue.BorderWidthBottom = 0.45f;

            // Añadimos las celdas a la tabla
            lTblReport.AddCell(lCdInvoice);
            lTblReport.AddCell(lCdProduct);
            lTblReport.AddCell(lNameProduct);
            lTblReport.AddCell(lCreationDate);
            lTblReport.AddCell(lValue);
            report.ForEach(x => {
                // Llenamos la tabla con información
                lCdInvoice = new PdfPCell(new Phrase(x.LCode, _standardFont));
                lCdInvoice.BorderWidth = 0;

                lCdProduct = new PdfPCell(new Phrase(x.LProduct.LCdProduct, _standardFont));
                lCdProduct.BorderWidth = 0;

                lNameProduct = new PdfPCell(new Phrase(x.LProduct.LNameProduct, _standardFont));
                lNameProduct.BorderWidth = 0;

                lCreationDate = new PdfPCell(new Phrase(x.LCreationDate.ToLongDateString(), _standardFont));
                lCreationDate.BorderWidth = 0;

                lValue = new PdfPCell(new Phrase(x.LValuetotal.ToString(), _standardFont));
                lValue.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                lTblReport.AddCell(lCdInvoice);
                lTblReport.AddCell(lCdProduct);
                lTblReport.AddCell(lNameProduct);
                lTblReport.AddCell(lCreationDate);
                lTblReport.AddCell(lValue);
            });
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(lTblReport);
            var lsumSalesValue = report.Sum(x => x.LValuetotal);
            var lSumSupplierValue = report.Sum(x => x.LProduct.LValueSupplier * x.LQty);
            var lspace = new Paragraph(new Phrase(" ", _standardFont));
            lspace.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lspace);
            var lFood1 = new Paragraph(new Phrase("Total Venta: " + lsumSalesValue, _standardFont));
            lFood1.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood1);
            doc.Add(lspace);
            var lFood2 = new Paragraph(new Phrase("Total Proveedor: " + lSumSupplierValue, _standardFont));
            lFood2.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood2);
            doc.Add(lspace);
            var lFood3 = new Paragraph(new Phrase("Total: " + (lsumSalesValue - lSumSupplierValue), _standardFont));
            lFood3.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood3);
            doc.Close();
            writer.Close();
        }

        public static void GeneratePdfAccountReceivable(List<MReportAccountReceivable> report)
        {
            // Creamos el documento con el tamaño de página tradicional
            var doc = new Document(PageSize.LETTER);
            string pathToFiles = HttpContext.Current.Server.MapPath(_lRouteAccountReceivable);
            // Indicamos donde vamos a guardar el documento
            var writer = PdfWriter.GetInstance(doc,
                                        new FileStream(pathToFiles, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Cuentas Por Cobrar ");
            doc.AddCreator("Gestion Digital");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Cuentas Por Cobrar VideoJuegos RT"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable lTblReport = new PdfPTable(3);
            lTblReport.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla

            var lIdOrder = new PdfPCell(new Phrase("Num. Pedido(Id)", _standardFont));
            lIdOrder.BorderWidth = 0;
            lIdOrder.BorderWidthBottom = 0.75f;

            var lNamecustomer = new PdfPCell(new Phrase("Nombre Cliente", _standardFont));
            lNamecustomer.BorderWidth = 0;
            lNamecustomer.BorderWidthBottom = 0.75f;

            var lValue = new PdfPCell(new Phrase("Total", _standardFont));
            lValue.BorderWidth = 0;
            lValue.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            lTblReport.AddCell(lIdOrder);
            lTblReport.AddCell(lNamecustomer);
            lTblReport.AddCell(lValue);
            report.ForEach(x => {
                // Llenamos la tabla con información
                lIdOrder = new PdfPCell(new Phrase(x.LId.ToString(), _standardFont));
                lIdOrder.BorderWidth = 0;

                lNamecustomer = new PdfPCell(new Phrase(x.LCustomer.LNameCustomer + EMessages.LSpace + x.LCustomer.LLastNameCustomer, _standardFont));
                lNamecustomer.BorderWidth = 0;

                lValue = new PdfPCell(new Phrase(x.LValueDebt.ToString(), _standardFont));
                lValue.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                lTblReport.AddCell(lIdOrder);
                lTblReport.AddCell(lNamecustomer);
                lTblReport.AddCell(lValue);
            });
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(lTblReport);

            var lspace = new Paragraph(new Phrase(" ", _standardFont));
            lspace.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lspace);
            var lFood1 = new Paragraph(new Phrase("Total cuentas A Cobrar: " + report.Sum(x => x.LValueDebt), _standardFont));
            lFood1.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood1);

            doc.Close();
            writer.Close();
        }

        public static void GeneratePdfInventory(List<MInventoryItem> report)
        {
            // Creamos el documento con el tamaño de página tradicional
            var doc = new Document(PageSize.LETTER);
            string pathToFiles = HttpContext.Current.Server.MapPath(_lRouteInventory);
            // Indicamos donde vamos a guardar el documento
            var writer = PdfWriter.GetInstance(doc,
                                        new FileStream(pathToFiles, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Inventario");
            doc.AddCreator("Gestion Digital");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);
            
            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Inventario VideoJuegos RT"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable lTblReport = new PdfPTable(5);
            lTblReport.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla

            var lNameInventory = new PdfPCell(new Phrase("Inventario", _standardFont));
            lNameInventory.BorderWidth = 0;
            lNameInventory.BorderWidthBottom = 0.45f;

            var lCdProduct = new PdfPCell(new Phrase("Codigo Producto", _standardFont));
            lCdProduct.BorderWidth = 0;
            lCdProduct.BorderWidthBottom = 0.45f;

            var lNameProduct = new PdfPCell(new Phrase("Nombre Producto", _standardFont));
            lNameProduct.BorderWidth = 0;
            lNameProduct.BorderWidthBottom = 0.45f;

            var lQtySellable = new PdfPCell(new Phrase("Cantidad Vendible", _standardFont));
            lQtySellable.BorderWidth = 0;
            lQtySellable.BorderWidthBottom = 0.45f;

            var lQtyNonSellable = new PdfPCell(new Phrase("Cantidad No Vendible", _standardFont));
            lQtyNonSellable.BorderWidth = 0;
            lQtyNonSellable.BorderWidthBottom = 0.45f;

            // Añadimos las celdas a la tabla
            lTblReport.AddCell(lNameInventory);
            lTblReport.AddCell(lCdProduct);
            lTblReport.AddCell(lNameProduct);
            lTblReport.AddCell(lQtySellable);
            lTblReport.AddCell(lQtyNonSellable);
            report.ForEach(x => {
                // Llenamos la tabla con información
                lNameInventory = new PdfPCell(new Phrase(x.LInventory.LNameInventory, _standardFont));
                lNameInventory.BorderWidth = 0;

                lCdProduct = new PdfPCell(new Phrase(x.LProduct.LCdProduct, _standardFont));
                lCdProduct.BorderWidth = 0;

                lNameProduct = new PdfPCell(new Phrase(x.LProduct.LNameProduct, _standardFont));
                lNameProduct.BorderWidth = 0;

                lQtySellable = new PdfPCell(new Phrase(x.LQtySellable.ToString(), _standardFont));
                lQtySellable.BorderWidth = 0;

                lQtyNonSellable = new PdfPCell(new Phrase(x.LQtyNonSellable.ToString(), _standardFont));
                lQtyNonSellable.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                lTblReport.AddCell(lNameInventory);
                lTblReport.AddCell(lCdProduct);
                lTblReport.AddCell(lNameProduct);
                lTblReport.AddCell(lQtySellable);
                lTblReport.AddCell(lQtyNonSellable);
            });          
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(lTblReport);
            var lspace = new Paragraph(new Phrase(" ", _standardFont));
            lspace.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lspace);
            var lFood1 = new Paragraph(new Phrase("Total Cantidad Vendible: " + report.Sum(x => x.LQtySellable), _standardFont));
            lFood1.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood1);
            doc.Add(lspace);
            var lFood2 = new Paragraph(new Phrase("Total Cantidad No Vendible: " + report.Sum(x => x.LQtyNonSellable), _standardFont));
            lFood2.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood2);

            doc.Close();
            writer.Close();
        }

        public static void GeneratePdfCashRegister(List<MCashRegister> report)
        {
            // Creamos el documento con el tamaño de página tradicional
            var doc = new Document(PageSize.LETTER);
            string pathToFiles = HttpContext.Current.Server.MapPath(_lRouteCashRegister);
            // Indicamos donde vamos a guardar el documento
            var writer = PdfWriter.GetInstance(doc,
                                        new FileStream(pathToFiles, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Caja");
            doc.AddCreator("Gestion Digital");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            Font _standardFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Caja VideoJuegos RT"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable lTblReport = new PdfPTable(4);
            lTblReport.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla

            var lTypeCash = new PdfPCell(new Phrase("Tipo", _standardFont));
            lTypeCash.BorderWidth = 0;
            lTypeCash.BorderWidthBottom = 0.55f;

            var lDateCreate = new PdfPCell(new Phrase("Fecha", _standardFont));
            lDateCreate.BorderWidth = 0;
            lDateCreate.BorderWidthBottom = 0.55f;

            var lDescription = new PdfPCell(new Phrase("Descripcion", _standardFont));
            lDescription.BorderWidth = 0;
            lDescription.BorderWidthBottom = 0.60f;

            var lValue = new PdfPCell(new Phrase("Valor", _standardFont));
            lValue.BorderWidth = 0;
            lValue.BorderWidthBottom = 0.55f;



            // Añadimos las celdas a la tabla
            lTblReport.AddCell(lTypeCash);
            lTblReport.AddCell(lDateCreate);
            lTblReport.AddCell(lDescription);
            lTblReport.AddCell(lValue);
            report.ForEach(x => {
                // Llenamos la tabla con información
                lTypeCash = new PdfPCell(new Phrase(x.LIsInput? "Entrada" : "Salida", _standardFont));
                lTypeCash.BorderWidth = 0;

                lDateCreate = new PdfPCell(new Phrase(x.LCreationDate.ToLongDateString(), _standardFont));
                lDateCreate.BorderWidth = 0;

                lDescription = new PdfPCell(new Phrase(x.LDescription, _standardFont));
                lDescription.BorderWidth = 0;

                lValue = new PdfPCell(new Phrase(x.LValue.ToString(), _standardFont));
                lValue.BorderWidth = 0;


                // Añadimos las celdas a la tabla
                lTblReport.AddCell(lTypeCash);
                lTblReport.AddCell(lDateCreate);
                lTblReport.AddCell(lDescription);
                lTblReport.AddCell(lValue);
            });
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(lTblReport);
            var lspace = new Paragraph(new Phrase(" ", _standardFont));
            lspace.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lspace);
            var lFood1 = new Paragraph(new Phrase("Total En Caja: " + (report.Where(y => y.LIsInput == true).Sum(x => x.LValue) - report.Where(y => y.LIsInput == false).Sum(x => x.LValue)), _standardFont));
            lFood1.Alignment = Element.ALIGN_RIGHT;
            doc.Add(lFood1);

            doc.Close();
            writer.Close();
        }
    }
}