using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PDF.Extensions
{
    public static class PdfExtensions
    {
        public static string ToText(this Stream pdfDocument)
        {
            using PdfReader pdfReader = new PdfReader(pdfDocument);

            return string.Join(Environment.NewLine, GetLinesFrom(pdfReader));
        }

        public static string PageToText(this Stream pdfDocument, int pageNumber)
        {
            StringBuilder sb = new StringBuilder();

            using PdfReader pdfReader = new PdfReader(pdfDocument);
            using PdfDocument pdfDoc = new PdfDocument(pdfReader);

            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            string currentPageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNumber), strategy);

            currentPageText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentPageText)));
            sb.Append(currentPageText);

            return sb.ToString();
        }

        public static string PageToText(this PdfDocument pdfDocument, int pageNumber)
        {
            StringBuilder sb = new StringBuilder();

            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            string currentPageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber), strategy);

            currentPageText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentPageText)));
            sb.Append(currentPageText);

            return sb.ToString();
        }

        public static int CountPages(this Stream pdfDocument)
        {
            using PdfReader pdfReader = new PdfReader(pdfDocument);
            using PdfDocument pdfDoc = new PdfDocument(pdfReader);

            return pdfDoc.GetNumberOfPages();
        }

        public static int CountPages(this PdfReader pdfReader)
        {
            using PdfDocument pdfDocument = new PdfDocument(pdfReader);

            return pdfDocument.GetNumberOfPages();
        }

        public static IEnumerable<string> GetLinesFrom(PdfReader pdfReader)
        {
            using PdfDocument pdfDocument = new PdfDocument(pdfReader);

            SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

            return Enumerable
                .Range(1, pdfDocument.GetNumberOfPages())
                .Select(p => PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(p), strategy));
        }
    }
}
