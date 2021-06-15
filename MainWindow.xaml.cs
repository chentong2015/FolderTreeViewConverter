using System.IO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using TreeViewsValueConverters.Directory.ViewModel;

namespace TreeViewsValueConverters {

    /// <summary>
    /// partial类中代码的简洁性 !!!!
    /// </summary>
    public partial class MainWindow:Window {

        public MainWindow() {
            InitializeComponent();
            // The Root of the UI of binding 
            DataContext = new DirectoryStructureViewModel();

            //在不绑定UI的情况下面，测试ViewModel的逻辑和获取的数据
            //var d = new DirectoryStructureViewModel();
            //var item1 = d.Items[0];
            //d.Items[0].ExpandCommand.Execute(null);
        }

        //#region On loaded
        ///// <summary>
        ///// when the application first opens 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Window_Load(object sender,RoutedEventArgs e) {
        //    // 获取系统的逻辑盘的数目
        //    foreach(var drive in System.IO.Directory.GetLogicalDrives()) {
        //        // 使用定义好的TreeViewItem的Data的模板来加载
        //        var item = new TreeViewItem {
        //            // Set the header 硬盘的名称赋值给文件的名称  ==> View绑定的text的内容
        //            Header = drive,
        //            // And full path drive 完整的路径赋值给Tag
        //            Tag = drive
        //        };
        //        // Add a dummy item 添加扩展的下拉便签 
        //        item.Items.Add(null);
        //        // Listen out for item being expanded 定义事件，使用事件处理器(点击扩展子标签的时候触发)
        //        item.Expanded += Folder_Expanded;
        //        FloderView.Items.Add(item);
        //    }
        //}
        //#endregion

        // #region Folder Expanded
        /// <summary>
        /// when the folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Folder_Expanded(object sender,RoutedEventArgs e) {
        //    var item = (TreeViewItem)sender;
        //    // If the item only contains the dummy data, do not find the deeper floder 
        //    if(item.Items.Count != 1 || item.Items[0] != null) {
        //        return;
        //    }
        //    item.Items.Clear();
        //    var fullPath = (string)item.Tag;

        //    /// Get Folders 获取所有的目录
        //    var directories = new List<string>();
        //    try {
        //        var dirs = System.IO.Directory.GetDirectories(fullPath);
        //        if(dirs.Length > 0) {
        //            directories.AddRange(dirs);
        //        }
        //    } catch {
        //    }
        //    directories.ForEach(directoryPath => {
        //        var subItem = new TreeViewItem() {
        //            Header = Helper.Helper.GetFloderFileName(directoryPath),
        //            // And tag as full path
        //            Tag = directoryPath
        //        };
        //        // Add dummy item so we can expand folder 
        //        subItem.Items.Add(null);
        //        // handle expanding 迭代自身的目录查找功能，循环层查找所有的目录文件
        //        subItem.Expanded += Folder_Expanded;
        //        // Add the subItem to parent item 添加的SubItem不只是目录
        //        item.Items.Add(subItem);
        //    });

        //    /// Get Files 获取所有的文件，没有向下Expand的功能(事件处理器)
        //    var files = new List<string>();
        //    try {
        //        var fs = System.IO.Directory.GetFiles(fullPath);
        //        if(fs.Length > 0) {
        //            files.AddRange(fs);
        //        }
        //    } catch {
        //    }
        //    files.ForEach(filePaeh => {
        //        var subItem = new TreeViewItem() {
        //            Header = Helper.Helper.GetFloderFileName(filePaeh),
        //            Tag = filePaeh
        //        };
        //        item.Items.Add(subItem);
        //    });
        //}
        //#endregion

    }
}
