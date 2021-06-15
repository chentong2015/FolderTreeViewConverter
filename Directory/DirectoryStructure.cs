using System.Linq;
using System.Collections.Generic;
using TreeViewsValueConverters.Directory.Data;

namespace TreeViewsValueConverters.Directory {

    /// <summary>
    /// A helper calss to query information about directories
    /// </summary>
    public static class DirectoryStructure {

        // 直接处理读取的逻辑盘的信息，返回DirectoryItem的List(模型化)
        /// <summary>
        /// Get all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives() {
            // Get every logical drive on the machine
            return System.IO.Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive,Type = DirectoryItemType.Dirve }).ToList();
        }

        /// <summary>
        /// Get the directory top-level content, contains folders and files
        /// </summary>
        /// <param name="fullPath">yhe full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath) {
            // Create empty list
            var items = new List<DirectoryItem>();
            try {
                var dirs = System.IO.Directory.GetDirectories(fullPath);
                if(dirs.Length > 0) {
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir,Type = DirectoryItemType.Folder }));
                }
            } catch { }
            try {
                var fs = System.IO.Directory.GetFiles(fullPath);
                if(fs.Length > 0) {
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file,Type = DirectoryItemType.File }));
                }
            } catch { }
            return items;
        }

        #region Helper
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFloderFileName(string filepath) {
            if(string.IsNullOrEmpty(filepath)) {
                // string.Empty 不是一个空的字符串，而是对空字符串的一个引用
                return string.Empty;
            }
            var normalizedPath = filepath.Replace('/','\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');
            if(lastIndex <= 0) {
                return filepath;
            }
            return filepath.Substring(lastIndex + 1);
        }
        #endregion

    }

}
