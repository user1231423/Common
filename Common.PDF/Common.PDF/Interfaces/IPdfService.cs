using Common.PDF.Models;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.PDF.Interfaces
{
    public interface IPdfService
    {
        Task<Stream> AddPagination(Stream pdfFile);

        Task<Stream> CombineDocuments(List<Stream> documents);

        Task<bool> PageContainsText(Stream pdfDocument, int pageNumber, string text);

        Task<bool> PageContainsText(PdfDocument pdfDocument, int pageNumber, string text);

        Task<Stream> HtmlToPdf(string html);

        Task HtmlToPdf(string html, string destPath);
    }
}
