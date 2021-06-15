using System.Linq;
using System.Windows.Input; // For ICommand
using System.Collections.ObjectModel;
using TreeViewsValueConverters.Directory.Data;

namespace TreeViewsValueConverters.Directory.ViewModel {

    //  整个的ViewModel的逻辑，具有高度的可移植性，跨平台性
    //  UI只需要重用代码的逻辑和属性，非常容易

    /// <summary>
    /// Connection between View and Data with View Model
    /// A view model for each directory item
    /// </summary>
    /// 
    // 可能出现重复的属性定义，这里包含的仅仅是用于前端View渲染需要的数据，所以是OK的
    class DirectoryItemViewModel:BaseViewModel {

        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory
        /// </summary>
        public string Name { get { return Type == DirectoryItemType.Dirve ? FullPath : DirectoryStructure.GetFloderFileName(FullPath); } }

        /// <summary>
        /// A list of all children inside this item
        /// </summary>
        // 看做是一个List使用，但是它实现了INotifyCollectionChanged，其中的Item变化的时候Fire触发属性变化的处理事件
        // 一个动态的数据集合，在添加删除和刷新的时候提供通知Notification
        // 特别适用在绑定数据方面
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// The command to expand this item ==> 可以绑定到UI，从而实现Expand()函数的调用 !!!!!
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        /// <summary>
        /// Indicates if this Item can be expanded
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        /// <summary>
        /// Inidicates if the current Item is expanded or not
        /// 如果需要展开，则展开，反之关闭的是清除展开的内容
        /// </summary>
        public bool IsExpand {
            get {
                // 计算至少有一个非空的子children
                return Children?.Count(f => f != null) > 0;
            }
            set {
                // If the UI tell us to expand or close...
                if(value == true) {
                    Expand();
                } else {
                    ClearExpandChildren();
                }
            }
        }

        /// <summary>
        ///  Set the Default Consturctor
        /// </summary>
        /// <param name="fullpath">The full path of this item</param>
        /// <param name="type">The type of item</param>
        public DirectoryItemViewModel(string fullpath,DirectoryItemType type) {
            // 使用接口的变量引用实现类的实例对象，初始化时传入Action委托的函数名称
            ExpandCommand = new RelayCommand(Expand);
            FullPath = fullpath;
            Type = type;
            // Set the children as needed
            ClearExpandChildren();
        }

        /// <summary>
        /// Expand this directory and find all children; 展开目录的时候，改变Icon图标
        /// </summary>
        private void Expand() {
            if(Type == DirectoryItemType.File) {
                return;
            }
            if(Type == DirectoryItemType.Folder) {
                Type = DirectoryItemType.FolderOpen;
            }
            // 对返回的结果进行Select筛选; 实例化每一个DirectoryItemViewModel的对象，并添加到动态的数据集合中
            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(children.Select(content => new DirectoryItemViewModel(content.FullPath,content.Type)));
        }

        /// <summary>
        /// Clear all children expanded from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClearExpandChildren() {
            Children = new ObservableCollection<DirectoryItemViewModel>();
            // Show the expand arrow if we are not a file
            // 对于File类型的文件来说，双击的时候也是会触发Expand()的操作，但是Expand()中直接返回了File这种类型
            if(Type != DirectoryItemType.File) {
                Children.Add(null);
                if(Type == DirectoryItemType.FolderOpen) {
                    Type = DirectoryItemType.Folder;
                }
            }
        }

    }
}
