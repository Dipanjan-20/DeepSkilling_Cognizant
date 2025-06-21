using System;

namespace FactoryMethodPattern
{
    // Document interface
    public interface IDocument
    {
        void Open();
    }

    // Concrete document types
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Word document opened.");
        }
    }

    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("PDF document opened.");
        }
    }

    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Excel document opened.");
        }
    }

    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    // Concrete factories
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DocumentFactory factory;

            // Create Word document
            factory = new WordDocumentFactory();
            IDocument wordDoc = factory.CreateDocument();
            wordDoc.Open();

            // Create PDF document
            factory = new PdfDocumentFactory();
            IDocument pdfDoc = factory.CreateDocument();
            pdfDoc.Open();

            // Create Excel document
            factory = new ExcelDocumentFactory();
            IDocument excelDoc = factory.CreateDocument();
            excelDoc.Open();
        }
    }
}
