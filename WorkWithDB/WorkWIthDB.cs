using Account_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Account_MVVM.WorkWithDB
{
    public static class WorkWithDB
    {
        //Connection string
        const string con = "data source =.;database = Account ; integrated security=SSPI";
        #region RegisterUser
        public static bool RegisterUser(string enteredLog, string enteredPass)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string _check = "SELECT Login FROM Information";
                SqlCommand _checkUnique = new SqlCommand(_check, connection);
                connection.Open();
                SqlDataReader dataReader = _checkUnique.ExecuteReader();
                HashSet<string> vs = new HashSet<string>();
                while (dataReader.Read())
                {
                    string currLogFromDB = Convert.ToString(dataReader["Login"]);
                    if (!vs.Add(currLogFromDB) || currLogFromDB == enteredLog || enteredLog == null)
                    {
                        MessageBox.Show(enteredLog);
                        MessageBox.Show("This account is already created");
                        return false;
                    }
                }
                dataReader.Dispose();
                // Information is our table with columns : Login, Password,City, Age, Gender, Salary. 
                //Here I just "register" user in my "system".
                //Then user can sign IN in his own account and add some data
                string cm = $"INSERT INTO Information (Login, Password) VALUES ('{enteredLog}', '{enteredPass}') ";
                SqlCommand sqlCommand = new SqlCommand(cm, connection);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
        }
        #endregion
        #region AddDataAboutUser
        public static void AddDataAboutUser(string trueLogin, string enteredCity, int enteredAge, string enteredGender, double enteredSalary)
        {
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                string cm = $"UPDATE Information SET" +
                    $" City = '{enteredCity}'," +
                    $" Age = {enteredAge}," +
                    $" Gender = '{enteredGender}'," +
                    $" Salary = {enteredSalary}" +
                    $" WHERE Login = '{trueLogin}'";
                SqlCommand sqlCommand = new SqlCommand(cm, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion
        #region CheckUser
        public static bool CheckUser(string enteredLog, string enteredPass)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string _check = "SELECT Login,Password FROM Information";
                SqlCommand _checkUnique = new SqlCommand(_check, connection);
                connection.Open();
                SqlDataReader dataReader = _checkUnique.ExecuteReader();
                while (dataReader.Read())
                {
                    string currLogFromDB = dataReader["Login"].ToString();
                    string currPassFromDB = dataReader["Password"].ToString();
                    if (currLogFromDB == enteredLog && currPassFromDB == enteredPass)
                    {
                        // if here is true, this means that login and password are correct and user can sign in
                        return true;
                    }
                }
                MessageBox.Show("Incorrect login or password!");
                return false;
            }
        }
        #endregion
        #region GetUser 
        public static SignInModel GetUsersData(string login)
        {
            SignInModel user = new SignInModel();
            using (SqlConnection sqlConnection = new SqlConnection(con))
            {
                string cm = $"SELECT * FROM Information WHERE Login = '{login}'";
                SqlCommand command = new SqlCommand(cm, sqlConnection);
                sqlConnection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                user.Age = Convert.ToInt32(dataReader["Age"]);
                user.City = dataReader["City"].ToString();
                user.Salary = float.Parse(dataReader["Salary"].ToString());
                user.Gender = dataReader["Gender"].ToString();
            }
            return user;
        }
        #endregion
    }
}

