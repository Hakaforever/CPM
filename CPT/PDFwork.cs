using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.api;
using iTextSharp.testutils;

using System.IO;

namespace CPT
{
    class PDFwork
    {
        public CPM myOwner;

        public PDFwork(CPM owner)
        {
            myOwner = owner;
        }

        public bool CreatePDF(string fName, string[] nFiles)
        {
            bool result;

            using (FileStream stream = new FileStream(fName, FileMode.Create))
            {
                Document newPDF = new Document();
                PdfCopy pdf = new PdfCopy(newPDF, stream);
                PdfReader reader = null;
                int pages = 0;

                

                myOwner.progressBar.Minimum = 0;
                myOwner.progressBar.Maximum = nFiles.Length;

                myOwner.progressBar.Visible = true;
                myOwner.progressBar.Value = 0;

                try
                {
                    newPDF.Open();
                    foreach (string f in nFiles)
                    {
                        if (f != null)
                        {
                            reader = new PdfReader(f);
                            pdf.AddDocument(reader);
                            reader.Close();
                            if (myOwner.progressBar.Value < myOwner.progressBar.Maximum)
                                myOwner.progressBar.Value = myOwner.progressBar.Value + 1;
                            pages++;
                        }
                    }
                    result = true;
                }
                catch(Exception)
                {
                    if (reader != null)
                        reader.Close();
                    result = false;
                }
                finally
                {
                    if (newPDF != null && pages != 0)
                        newPDF.Close();
                }
            }
            myOwner.progressBar.Visible = false;
            return result;
        }
    }
}
