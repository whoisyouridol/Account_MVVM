using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_MVVM.Model
{
    public class SignInModel
    {
        #region Properties
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                }
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value) _city = value;
            }
        }  
        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value) _gender = value;
            }
        }
        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                } }
        }
        #endregion
    }
}
