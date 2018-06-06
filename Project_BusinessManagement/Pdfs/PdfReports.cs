using iTextSharp.text;
using iTextSharp.text.pdf;
using Project_BusinessManagement.Models.Reports;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web;
using Project_BusinessManagement.Models;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Pdfs
{
    public static class PdfReports
    {
        #region variables and constant
        private static string _lRouteSales = ConfigurationManager.AppSettings["RoutePdfSales"];
        private static string _lRouteAccountReceivable = ConfigurationManager.AppSettings["RoutePdfAccountReceivable"];
        private static string _lRouteInventory = ConfigurationManager.AppSettings["RoutePdfInventory"];
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

            doc.Close();
            writer.Close();
        }
    }
}