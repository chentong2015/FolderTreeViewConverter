using PropertyChanged;
using System.ComponentModel;
using System.Threading.Tasks;

namespace TreeViewsValueConverters.Directory.ViewModel {

    // [ImplementPropertyChanged]  
    // 新版本下的Fody.PropertyChanged不在需要添加该特性，对于实现INotifyPropertyChanged的类会自动的具备属性变化时候的触发事件
    class ViewModelCheck:INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged = (sender,e) => { };

        // public Attribute 始终使用属性向外暴露数据
        public string MyProperty { get; set; }

        public ViewModelCheck() {
            Task.Run(async () => {
                int i = 0;
                while(true) {
                    await Task.Delay(200);
                    MyProperty = (i++).ToString();
                }
            });
        }
    }
}
