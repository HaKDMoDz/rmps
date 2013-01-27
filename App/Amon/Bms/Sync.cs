using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Me.Amon.Bms
{
    class Sync
    {

        public void Run(List<Dirs> dirs)
        {
            FileSystemWatcher watcher;
            foreach (Dirs dir in dirs)
            {
                watcher = new FileSystemWatcher();
                watcher.Path = dir.Path;
                watcher.IncludeSubdirectories = dir.Subs;
                watcher.Filter = dir.Filter;

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.Deleted += new FileSystemEventHandler(OnDeleted);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);

                // Begin watching.
                watcher.EnableRaisingEvents = true;
            }
        }

        private void TryRead()
        {
            //while (!IsFileReady(e.FullPath))
            //{
            //    if (!File.Exists(e.FullPath))
            //    {
            //        return;
            //    }
            //    Thread.Sleep(100);
            //}
        }

        private bool IsFileReady(string filename)
        {
            FileStream fs = null;
            try
            {
                File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        private void OnChanged(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void OnCreated(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void OnDeleted(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void OnRenamed(object sender, System.IO.RenamedEventArgs e)
        {

        }
    }
}
