using System.ComponentModel;
using System.Threading.Tasks;

// 可以减少命名空间的使用
namespace TreeViewsValueConverters.Directory.ViewModel {

    class ViewModelSample:INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged = (sender,e) => { };

        // 定义自身的属性，用于属性绑定
        // public string Test { get; set; } = "My Property";

        private string _test;

        public string Test {
            get { return _test; }
            set {
                if(_test == value) {
                    return;
                } else {
                    _test = value;
                    // 使用nameof()动态的关联属性的名称，避免写错
                    // 触发属性变化的事件
                    PropertyChanged(this,new PropertyChangedEventArgs(nameof(Test)));
                }
            }
        }

        // Test for binging：属性的变化从ViewModel流到前端View
        public ViewModelSample() {
            // 多线程，异步lambda表达式
            Task.Run(async () => {
                int i = 0;
                while(true) {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                    // 触发属性变化大的事件，前端绑定的值随之变化
                    // PropertyChanged(this,new PropertyChangedEventArgs("Test"));
                }
            });
        }

        // 重新父类的ToString()方法，在绑定的时候放回的值
        //public override string ToString() {
        //    return "Test Button";
        //}
    }

}
