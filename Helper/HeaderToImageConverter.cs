using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TreeViewsValueConverters.Directory;
using TreeViewsValueConverters.Directory.Data;

namespace TreeViewsValueConverters.Helper {

    /// <summary>
    /// Convert a full path to a specific image type of a drive
    /// </summary>
    /// 

    // 表明特性，源类型和目标类型 ==> 在使用Binding绑定的时候，converter能够找到 !!!!
    [ValueConversion(typeof(DirectoryItemType),typeof(BitmapImage))]
    public class HeaderToImageConverter:IValueConverter {

        // 创建一个静态的实例，用于直接访问内部的方法
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        // Convert from back data to UI View
        // 这里传入的value是full path路径(也就是UI View绑定的Tag属性) !!!!!!
        public object Convert(object value,Type targetType,object parameter,CultureInfo culture) {
            //var path = (string)value;
            //if(path == null) {
            //    return null;
            //}
            //var name = DirectoryStructure.GetFloderFileName(path);
            //var image = "Images/file.jpg";

            //// if the name is blank, we presume it's a drive as we cannot have a blank file or folder name
            //if(string.IsNullOrEmpty(name)) {
            //    image = "Images/drive.jpg";
            //} else {
            //    // 判断一个path是否是一个目录， 直接从文件的信息中获取FileAttributes...
            //    if(new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory)) {
            //        image = "Images/folderClose.jpg";
            //    }
            //}

            //直接通过DirectoryItemType类型来转换成BitmapImage 加载到前端
            var image = "Images/file.jpg";
            switch((DirectoryItemType)value) {
                case DirectoryItemType.Dirve:
                    image = "Images/drive.jpg";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/folderClose.jpg";
                    break;
                case DirectoryItemType.FolderOpen:
                    image = "Images/folderOpen.jpg";
                    break;
                default:
                    break;
            }
            // 使用pack://application:,,,定义相对的路径，访问到resources的资源信息
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        // Convert back data from UI View
        public object ConvertBack(object value,Type targetType,object parameter,CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

}
