using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class UserProcessor
    {
        public static int createUser(int UserID, string FirstName, string LastName,
                                     string Email, string Sex, string State)
        {
            UserModel data = new UserModel
            {
                UserID = UserID,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Sex = Sex,
                State = State
            };
            //string sql = @"INSERT INTO dbo.[User] VALUES (@UserID, @FirstName, @LastName, @Email, @Sex, @State);";
            string sql = @"INSERT INTO dbo.[User] (UserID, FirstName, LastName, Sex, Age, State, Username, Password, Email) 
                           VALUES (@UserID, @FirstName, @LastName, @Sex, @Age, @State, @Username, @Password, @Email);";
            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<UserModel> LoadUsers()
        {
            string sql = @"SELECT * FROM dbo.User;";
            return SQLDataAccess.LoadData<UserModel>(sql);
        }

    }
}
