using System.Windows;
using System.Windows.Input;
using Account_MVVM.Command;
using Account_MVVM.Model;
using Account_MVVM.View;

namespace Account_MVVM.ViewModel
{
    public class MainViewModel  : Main 
    {
        #region SignIn
        public ICommand SignIn
        {
            get
            {
                return new ActionCommand(() =>
                {
                    if (WorkWithDB.WorkWithDB.CheckUser(Login,Password))
                    {
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        SignIn signIn = new SignIn();
                        if (mainWindow != null) mainWindow.Close();
                        SignInViewModel.LoginFromMainViewModel = Login;
                        SignInViewModel.SignInInstance = signIn;
                        //_ = new SignInViewModel(Login);
                        signIn.ShowDialog();
                    }
                });
            }
        }
        #endregion
        #region SignUp
        public ICommand SignUp
        {
            get
            {
                return new ActionCommand(() =>
                {
                    if (WorkWithDB.WorkWithDB.RegisterUser(Login,Password)/*If here is true, then the user can register*/)
                    {
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        SignUp sign_Up = new SignUp();
                        SignUpViewModel.GetSignUpInstance(sign_Up);
                        if (mainWindow != null) mainWindow.Close();
                        sign_Up.ShowDialog();
                    }
                });
            }
        }
        #endregion
    }
}
