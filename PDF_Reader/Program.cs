using System;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text;

public class PDF
{
    public static void main(string[] args)
    {
        var PDF = new PDF();
        PDF.ReadPdfFile("‪C:\\Users\\a.ramesh\\Desktop\\bill.pdf");
    }

    public string ReadPdfFile(string fileName)
    {
        StringBuilder text = new StringBuilder();

        if (File.Exists(fileName))
        {
            PdfReader pdfReader = new PdfReader(fileName);

            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                currentText =
                    Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8,
                        Encoding.Default.GetBytes(currentText)));
                text.Append(currentText);

                Console.WriteLine(currentText);    //fg  
                Console.Read();
            }
            pdfReader.Close();
        }
        return text.ToString();
    }
}
