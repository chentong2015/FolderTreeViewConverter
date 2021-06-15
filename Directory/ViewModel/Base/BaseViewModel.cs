using System.ComponentModel;

namespace TreeViewsValueConverters.Directory.ViewModel {

    // 所有的ViewModel所使用的基础; Fire触发属性变化事件(处理器)
    /// <summary>
    /// A Base view model that fires Property Changed events as needed
    /// </summary>
    /// 
    // 不同显示的添加[ImplementPropertyChanged]
    class BaseViewModel:INotifyPropertyChanged {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender,e) => { };
    }

}
