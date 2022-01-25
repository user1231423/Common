using Common.PDF.Extensions;
using Common.PDF.Interfaces;
using Common.PDF.Models;
using iText.Html2pdf;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PDF.Services
{
    public class PdfService : IPdfService
    {
        public async Task<Stream> AddPagination(Stream pdfFile)
        {
            using MemoryStream finalDocument = new MemoryStream();
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(pdfFile), new PdfWriter(finalDocument));
            Document doc = new Document(pdfDoc);

            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                Paragraph header = new Paragraph($"Page {i} of {pdfDoc.GetNumberOfPages()}")
                   .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                   .SetFontSize(14)
                   .SetFontColor(ColorConstants.RED);

                Rectangle pageSize = pdfDoc.GetPage(i).GetPageSize();
                float x = pageSize.GetWidth() - 20;
                float y = pageSize.GetBottom() + 5;
                doc.ShowTextAligned(header, x, y, i, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
            }

            doc.Close();

            return await Task.Run(() => new MemoryStream(finalDocument.ToArray()));
        }

        public async Task<Stream> CombineDocuments(List<Stream> documents)
        {
            using MemoryStream finalDocument = new MemoryStream();
            using PdfWriter pdfWriter = new PdfWriter(finalDocument);
            using PdfDocument pdfDocument = new PdfDocument(pdfWriter);

            documents.ForEach(document =>
            {
                using PdfReader currentPdfReader = new PdfReader(document);
                using PdfDocument currentDocument = new PdfDocument(currentPdfReader);

                pdfWriter.SetCloseStream(false);

                currentDocument.CopyPagesTo(1, currentDocument.GetNumberOfPages(), pdfDocument);
            });

            pdfDocument.Close();

            return await Task.Run(() => new MemoryStream(finalDocument.ToArray()));
        }

        public async Task<Stream> HtmlToPdf(string html)
        {
            using MemoryStream pdfDocument = new MemoryStream();
            
            await Task.Run(() => HtmlConverter.ConvertToPdf(html, pdfDocument));

            return pdfDocument;
        }

        public async Task HtmlToPdf(string html, string destPath)
        {
            await Task.Run(() => HtmlConverter.ConvertToPdf(html, new FileStream(destPath, FileMode.Create)));
        }

        public async Task<bool> PageContainsText(Stream pdfDocument, int pageNumber, string text)
        {
            return await Task.Run(() => pdfDocument.PageToText(pageNumber).Contains(text));
        }

        public async Task<bool> PageContainsText(PdfDocument pdfDocument, int pageNumber, string text)
        {
            return await Task.Run(() => pdfDocument.PageToText(pageNumber).Contains(text));
        }
    }
}
