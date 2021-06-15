using System;
using System.Windows.Input;

namespace TreeViewsValueConverters.Directory.ViewModel {

    /// <summary>
    /// 绑定Button和ICommand，CanExecute(object parameter)表示按钮是处于可点击状态与否
    /// </summary>

    /// A basic command that runs an Action
    public class RelayCommand:ICommand {

        // Create a blank funciton lambda for this event
        // public event EventHandler CanExecuteChanged;
        /// <summary>
        /// The event thats fired when the CanExcute() value has changed 
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender,e) => { };

        //不带返回参数的委托Action，用来间接的调用函数
        /// <summary>
        /// The Action to run 
        /// </summary>
        private Action mAction;

        /// <summary>
        /// Set Constructor，action委托的函数建会被间接的执行
        /// </summary>
        public RelayCommand(Action action) {
            mAction = action;
        }

        /// <summary>
        /// A Relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) {
            return true;
        }

        /// <summary>
        /// Run the commands Action, 通过委托间接的调用函数
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) {
            mAction();
        }

    }

}
