using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordLoginForm2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Joshua Saetern
    /// 04.18.2024
    /// Assignment 1 - Password login form
    /// Computer Programming II
    public partial class MainWindow : Window
    {
        List<String> usernames = new List<String>();
        List<String> passwords = new List<String>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            String username = txtBoxUsername.Text;
            String password = txtBoxPassword.Text;
            MessageBox.Show(checkUsernameAndPassword(username, password));
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            String username = txtBoxUsername.Text;
            String password = txtBoxPassword.Text;
            MessageBox.Show(createAccount(username, password));
        }
        public Boolean checkIfAvailable(String username)
        {
            //Check if username exists already
            for (int i = 0; i < usernames.Count; i++)
            {
                if (username == usernames[i])
                {
                    return false;
                }
            }
            //Runs if username is not taken
            return true;
        }
        public String createAccount(String username, String password)
        {
            //Checks if username or password is blank
            if (String.IsNullOrEmpty(username))
            {
                return "Cannot leave username empty";
            }
            if (String.IsNullOrEmpty(password))
            {
                return "Cannot leave password empty";
            }
            //Runs if username isnt taken
            if (checkIfAvailable(username))
            {
                //Proceeds if password is longer than 8 characters 
                if (password.Length > 8)
                {
                    //Everything past this point is valid for making an account
                    usernames.Add(username);
                    passwords.Add(password);
                    return "Account created";
                }
                else
                {
                    return "Password must be longer than 8 characters";
                }
            }
            else
            {
                return "Username is in use";
            }
        }
        public String checkUsernameAndPassword(String username, String password)
        {
            //Checks if username or password is blank
            if (String.IsNullOrEmpty(username))
            {
                return "Cannot leave username empty";
            }
            if (String.IsNullOrEmpty(password))
            {
                return "Cannot leave password empty";
            }
            bool usernameExists = false;
            //Checks if username exists in array
            for (int i = 0; i < usernames.Count; i++)
            {
                if (username.Equals(usernames[i]))
                {
                    usernameExists = true;
                    break;
                }
            }
            if (usernameExists)
            {
                //Gets the corresponding password of the username
                String realPassword = passwords[usernames.IndexOf(username)];
                if (password == realPassword)
                {
                    return "Log in successful";
                }
                else
                {
                    return "Invalid password";
                }
            }
            else
            {
                return "Cannot find account";
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}