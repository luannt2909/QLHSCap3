using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace GUI
{
    public class InDuLieuRaPdf
    {
        public void In(DataTable tempb)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);


            try
            {
                pdfDoc.Open();

                Font fnt = FontFactory.GetFont("Times New Roman", 15);
                DataTable temp = tempb;

                if(temp != null)
                {
                    PdfPTable PdfTable = new PdfPTable(temp.Columns.Count);
                    PdfPCell PdfPCell = null;

                    for (int rows = 0; rows < temp.Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            for (int column = 0; column < temp.Columns.Count; column++)
                            {
                                PdfPCell = new PdfPCell(new Phrase(new Chunk(temp.Columns[column].ColumnName.ToString(), fnt)));
                                PdfTable.AddCell(PdfPCell);
                            }
                        }
                        for (int column = 0; column < temp.Columns.Count; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(temp.Rows[rows][column].ToString(), fnt)));
                            PdfTable.AddCell(PdfPCell);
                        }
                    }
                    pdfDoc.Add(PdfTable);
                }
                pdfDoc.Close();
            }
        }
    }
}
