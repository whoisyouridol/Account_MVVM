using Account_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
namespace Account_MVVM.Command
{
    public class CloseSignUpButtonCommand : BaseButton
    {
        private readonly SignUpViewModel signUpViewModel;
        public CloseSignUpButtonCommand(SignUpViewModel signUpViewModel) => this.signUpViewModel = signUpViewModel; 
        public override void Execute(object parameter)
        {
            signUpViewModel.CloseSignUp();
        }
    }
}
