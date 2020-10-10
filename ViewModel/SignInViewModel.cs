using Account_MVVM.Command;
using Account_MVVM.Model;
using Account_MVVM.View;
using System.Windows;
using System.Windows.Input;
namespace Account_MVVM.ViewModel
{
    public class SignInViewModel : SignInModel
    {
        public ICommand ShowData
        {
            get
            {
                return new ActionCommand(() =>
                {
                    if (City != null || Gender != null || Age != 0 || Salary != 0 /*This works if data is changed*/)
                    {

                        MessageBox.Show($"User`s city is : {City}, gender : {Gender}, age : {Age}, salary : {Salary}$");
                    }
                    else //This works if data was not inputed then we get data from database
                    {
                        var user = WorkWithDB.WorkWithDB.GetUsersData(LoginFromMainViewModel);
                        MessageBox.Show($"User`s city is : {user.City}, gender : {user.Gender}, age : {user.Age}, salary : {user.Salary}$");
                    }
                });
            }
        }
        public static SignIn SignInInstance { get; set; }
        public static string LoginFromMainViewModel { get; set; }
        public ICommand SaveDataAndCloseWindow
        {
            get
            {
                return new ActionCommand(() =>
                {
                    //Saving
                    WorkWithDB.WorkWithDB.AddDataAboutUser(LoginFromMainViewModel, City, Age, Gender, Salary);
                    //Closing
                    SignInInstance.Close();
                });
            }
        }
    }
}
