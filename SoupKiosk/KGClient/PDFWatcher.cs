using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGClient
{
    //특정경로 PDF 생성 탐지
    public class PDFWatcher
    {
        MainWindow mainWindow = null;
        public PDFWatcher(MainWindow mainWindow, string path)
        {
            try
            {
                this.mainWindow = mainWindow;

                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher = new FileSystemWatcher(path, "*.pdf");

                // 생성
                watcher.Created += watcher_Created;
                // 삭제
                watcher.Deleted += watcher_Deleted;
                //// 이름
                //watcher.Renamed += watcher_Renamed;
                //// 에러
                //watcher.Error += watcher_Error;
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString());
            }
        }


        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            mainWindow.PDFCreated(e);
        }
        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            mainWindow.PDFDeleted(e.FullPath);
        }
    
    }
}
