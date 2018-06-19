using System.IO;
using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Web.Mvc;
using Neodynamic.SDK.Web;
using Project_BusinessManagement.Models;

namespace Project_BusinessManagement.Printer
{
    public class Printing
    {
        private System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();

        // Print the file.
        public void PrintingInvoice()
        {
            try
            {
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                    pd.Print();
            }
            catch (Exception ex)
            {
                var lstr = ex.Message;
            }
        }

        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Single yPos = 0;
            Single leftMargin = e.MarginBounds.Left;
            Single topMargin = e.MarginBounds.Top;
           //mage img = Image.FromFile("logo.bmp");
            Rectangle logo = new Rectangle(40, 40, 50, 50);
            using (Font printFont = new Font("Arial", 10.0f))
            {
                //Graphics.DrawImage(img, logo);
                e.Graphics.DrawString("Testing!", printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
            }
        }

        public void PrintInvoice(string useDefaultPrinter, string printerName, MInvoice lInvoice)
        {
            var lLengthName = 8;
            var lLengthCDProduct = 10;
            var lLengthQtyProduct = 4;
            var lLengthTotal = 7;
            var lTotalInvoice = 0;
            //Create ESC/POS commands for sample receipt
            string ESC = "0x1B"; //ESC byte in hex notation
            string NewLine = "0x0A"; //LF byte in hex notation

            string cmds = ESC + "@"; //Initializes the printer (ESC @)
            cmds += ESC + "!" + "0x38"; //Emphasized + Double-height + Double-width mode selected (ESC ! (8 + 16 + 32)) 56 dec => 38 hex
            
            cmds += "VideoJuegos RT"; //text to print
            cmds += ESC + "!" + "0x16";
            cmds += NewLine;
            cmds += "Dirección: " + "Calle 38 No 7-73 C.C. BACAL Local 27-28 y 47";
            cmds += NewLine;
            cmds += "Telefono: " + "3124121752";
            cmds += NewLine + NewLine;
            cmds += "Factura De Venta: " + lInvoice.LCdInvoice;
            cmds += NewLine;
            var lNamecompleted = lInvoice.LCustomer.LNameCustomer;
            if (!string.IsNullOrEmpty(lInvoice.LCustomer.LLastNameCustomer))
                lNamecompleted += " " + lInvoice.LCustomer.LLastNameCustomer;
            cmds += "Nombre cliente: " + lNamecompleted;
            cmds += NewLine + NewLine;
            cmds += ESC + "!" + "0x00"; //Character font A selected (ESC ! 0)
            cmds += "Codigo     Nombre     Cantidad     Total ";
            cmds += NewLine;
            lInvoice.LListMInvoiceItem.ForEach(x =>
            {
                var lCdProduct = x.LProduct.LCdProduct.PadRight(lLengthCDProduct);
                if(lCdProduct.Length > lLengthCDProduct)
                    lCdProduct = lCdProduct.Substring(0, lLengthCDProduct);
                var lName = x.LProduct.LNameProduct.PadRight(lLengthName);
                if (lName.Length > lLengthName)
                    lName = lName.Substring(0, lLengthName);
                var lQty = Convert.ToInt32(x.LQuantity);
                var lTotal = Convert.ToInt32(x.LValueTotal);
                lTotalInvoice += lTotal;
                cmds += lCdProduct + " " + lName + "   " + lQty.ToString().PadRight(lLengthQtyProduct) + "   " + lTotal.ToString().PadRight(lLengthTotal);
                cmds += NewLine;
            });
            cmds += NewLine;
            cmds += "SUBTOTAL            " + lTotalInvoice;
            cmds += NewLine;
            cmds += "TOTAL               " + lTotalInvoice;
            cmds += NewLine + NewLine;
            cmds += ESC + "!" + "0x18"; //Emphasized + Double-height mode selected (ESC ! (16 + 8)) 24 dec => 18 hex
            cmds += "# PRODUCTOS VENDIDOS";
            cmds += ESC + "!" + "0x00"; //Character font A selected (ESC ! 0)
            cmds += NewLine;
            cmds += DateTime.Now.ToLongDateString();
            cmds += NewLine;
            cmds += DateTime.Now.ToLongTimeString();
            cmds += NewLine + NewLine + NewLine + NewLine + NewLine + NewLine + NewLine + NewLine + NewLine;

            //Create a ClientPrintJob and send it back to the client!
            ClientPrintJob cpj = new ClientPrintJob();
            //set  ESCPOS commands to print...
            cpj.PrinterCommands = cmds;
            cpj.FormatHexValues = true;

            //set client printer...
            if (useDefaultPrinter == "checked" || printerName == "null")
                cpj.ClientPrinter = new DefaultPrinter();
            else
                cpj.ClientPrinter = new InstalledPrinter(printerName);

            //send it...
            System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
            System.Web.HttpContext.Current.Response.BinaryWrite(cpj.GetContent());
            System.Web.HttpContext.Current.Response.End();

        }
    }
}