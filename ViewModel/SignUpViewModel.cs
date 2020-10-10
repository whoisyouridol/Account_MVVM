using Account_MVVM.Command;

namespace Account_MVVM.ViewModel
{
    public class SignUpViewModel
    {
        private static SignUp Sign;
        public CloseSignUpButtonCommand CloseSignUpCommand { get; set; }
        public SignUpViewModel()
        {
            CloseSignUpCommand = new CloseSignUpButtonCommand(this);
        }
        public static SignUp GetSignUpInstance(SignUp sign) => Sign = sign;
        internal void CloseSignUp()
        {
            MainWindow mainWindow = new MainWindow();
            Sign.Close();
            mainWindow.ShowDialog();
        }
    }
}
