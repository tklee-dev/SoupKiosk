using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    public class PrintPdf
    {
        public static int GetPageCount(string pdfFilePath)
        {
            var lib = new PDFLibrary("DebenuPDFLibraryDLL1311.dll");
            if (lib.LibraryLoaded() == false)
                throw new Exception("PDF Library Load 실패");

            try
            {
                if (lib.Unlocked() != 1)
                {
                    if (lib.UnlockKey("j56ki5wi5t65j97hb3r48gb6y") != 1)
                        throw new Exception("PDF Library Unlock 실패");
                }

                var rv = lib.LoadFromFile(pdfFilePath, "");
                if (rv != 1)
                    throw new Exception("Pdf 파일 로드 실패 - " + pdfFilePath);

                var rtn = lib.PageCount();
                if (rtn > 0)
                    return rtn;
                else
                    throw new Exception("Pdf 페이지수가 0보다 작음 - " + pdfFilePath);
            }
            finally
            {
                lib.ReleaseLibrary();
            }
        }

        public static int GetPageCount(byte[] pdf)
        {
            var lib = new PDFLibrary("DebenuPDFLibraryDLL1311.dll");
            if (lib.LibraryLoaded() == false)
                throw new Exception("PDF Library Load 실패");

            try
            {
                if (lib.Unlocked() != 1)
                {
                    if (lib.UnlockKey("j56ki5wi5t65j97hb3r48gb6y") != 1)
                        throw new Exception("PDF Library Unlock 실패");
                }

                var rv = lib.LoadFromString(pdf, "");
                if (rv != 1)
                    throw new Exception("Pdf 파일 로드 실패");

                var rtn = lib.PageCount();
                if (rtn > 0)
                    return rtn;
                else
                    throw new Exception("Pdf 페이지수가 0보다 작음");
            }
            finally
            {
                lib.ReleaseLibrary();
            }
        }

        public static void Print(string pdfFilePath, bool useDebenuRenderer = false)
        {
            var lib = new PDFLibrary("DebenuPDFLibraryDLL1311.dll");
            if (lib.LibraryLoaded() == false)
                throw new Exception("PDF Library Load 실패");

            try
            {
                if (lib.Unlocked() != 1)
                {
                    if (lib.UnlockKey("j56ki5wi5t65j97hb3r48gb6y") != 1)
                        throw new Exception("PDF Library Unlock 실패");
                }

                if (useDebenuRenderer)
                {
                    //var render = lib.SetPDFiumFileName("QPL1311PDFium32.dll");
                    var render = lib.SetDPLRFileName("DebenuPDFRendererDLL1311.dll");
                    if (render != 1)
                        throw new Exception("PDF Library Renderer 로드 실패");
                    //1 = GDI+
                    //2 = Cairo
                    //3 = DPLR (AGG)
                    //4 = PDFium
                    render = lib.SelectRenderer(3);

                    if (render != 3)
                        throw new Exception("PDF Library Renderer 설정 실패");
                }

                var rv = lib.LoadFromFile(pdfFilePath, "");
                if (rv != 1)
                    throw new Exception("Pdf 파일 로드 실패 - " + pdfFilePath);

                var iPrintOptions = lib.PrintOptions(0, 0, "Nts Certificate");
                rv = lib.PrintDocument(lib.GetDefaultPrinterName(), 1, lib.PageCount(), iPrintOptions);

                if (rv != 1)
                    throw new Exception("Pdf 파일 출력 실패 - " + pdfFilePath);
            }
            finally
            {
                lib.ReleaseLibrary();
            }
        }

        public static void Print(byte[] pdf)
        {
            var lib = new PDFLibrary("DebenuPDFLibraryDLL1311.dll");
            if (lib.LibraryLoaded() == false)
                throw new Exception("PDF Library Load 실패");

            try
            {
                if (lib.Unlocked() != 1)
                {
                    if (lib.UnlockKey("j56ki5wi5t65j97hb3r48gb6y") != 1)
                        throw new Exception("PDF Library Unlock 실패");
                }

                var rv = lib.LoadFromString(pdf, "");
                if (rv != 1)
                    throw new Exception("Pdf 파일 로드 실패 - " + rv.ToString());

                var iPrintOptions = lib.PrintOptions(0, 0, "Nts Certificate");
                rv = lib.PrintDocument(lib.GetDefaultPrinterName(), 1, lib.PageCount(), iPrintOptions);

                if (rv != 1)
                    throw new Exception("Pdf 파일 출력 실패 - " + rv.ToString());
            }
            finally
            {
                lib.ReleaseLibrary();
            }
        }
    }
}

