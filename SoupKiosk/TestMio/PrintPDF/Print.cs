using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMio
{
    class Print
    {
        public async Task<int> GetPageCountAsync(string pdfFilePath)
        {
            return await Task.Run(() => GetPageCount(pdfFilePath));
        }

        public int GetPageCount(string pdfFilePath)
        {
            try
            {
            
                var page = PrintPdf.GetPageCount(pdfFilePath);
                return page > 0 ? page : -1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return -1;
            }
        }

        public async Task<int> PrintFileAsync(string pdfFilePath)
        {
            return await Task.Run(() => PrintFile(pdfFilePath));
        }

        public int PrintFile(string pdfFilePath)
        {
            try
            {
                PrintPdf.Print(pdfFilePath);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return -1;
            }
        }
    }
}
