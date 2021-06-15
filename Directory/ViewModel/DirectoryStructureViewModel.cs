using System.Linq;
using System.Collections.ObjectModel;

namespace TreeViewsValueConverters.Directory.ViewModel {

    /// <summary>
    /// The View Model for the Applcation main Directory View 
    /// 该主目录View只需要获取到GetLogicalDrives逻辑盘即可，后的展开和扩展由DirectoryItemViewModel控制
    /// </summary>
    class DirectoryStructureViewModel:BaseViewModel {

        /// <summary>
        /// A List of all directories on the machines
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectoryStructureViewModel() {
            var children = DirectoryStructure.GetLogicalDrives();
            Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath,Data.DirectoryItemType.Dirve)));
        }

    }

}
