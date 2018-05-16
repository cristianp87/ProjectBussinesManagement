using iTextSharp.text;
using iTextSharp.text.pdf;
using Project_BusinessManagement.Models.Reports;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Web;

namespace Project_BusinessManagement.Pdfs
{
    public static class PdfReports
    {
        #region variables and constant
        private static string _lRouteSales = ConfigurationManager.AppSettings["RoutePdfSales"];
        #endregion
        public static void GeneratePdfSales( List<MReportSales> report)
        {
            // Creamos el documento con el tamaño de página tradicional
            var doc = new Document(PageSize.LETTER);
            string pathToFiles = HttpContext.Current.Server.MapPath("/Pdfs/files/") + _lRouteSales;
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
            doc.Add(new Paragraph("Ventas VideoJuegos RM"));
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

                lCreationDate = new PdfPCell(new Phrase(x.LProduct.LCreationDate.ToShortDateString(), _standardFont));
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
    }
}