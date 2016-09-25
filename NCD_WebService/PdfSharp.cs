using NCD_Model;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace NCD_WebService
{
    public static class PdfSharp
    {
        public static Attachment MakePdf(CriminalPerson item)
        {
            //make pdf document
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            gfx.DrawString(String.Format("Name: {0}", item.Name), font, XBrushes.Black, new XRect(20, 40, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(String.Format("Age: {0}", item.Age), font, XBrushes.Black, new XRect(20, 80, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(String.Format("Sex: {0}", item.Sex), font, XBrushes.Black, new XRect(20, 120, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(String.Format("Height: {0}", item.Height), font, XBrushes.Black, new XRect(20, 160, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(String.Format("Weight: {0}", item.Weight), font, XBrushes.Black, new XRect(20, 200, page.Width, page.Height), XStringFormats.TopLeft);

            //save it to memory stream
            var stream = new MemoryStream();
            document.Save(stream, false);
            document.Dispose();
            return new Attachment(stream, item.Name, MediaTypeNames.Application.Pdf);
        }
    }
}