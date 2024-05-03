using OurGame2k.Commands;
using OurGame2k.Converters;
using OurGame2k.Models;
using OurGame2k.Views;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OurGame2k.ViewModels
{
    public class MainViewModel
    {
        public ICommand SwapCommand { get; set; }
        public ICommand AuthCommand { get; set; }

        public MainViewModel() 
        { 
            SwapCommand = new RelayCommand(Swap, CanSwap);
            AuthCommand = new RelayCommand(Auth, CanAuth);
        }

        private bool CanAuth(object obj)
        {
            return true;
        }


        private void Auth(object obj)
        {
            var values = (object[]) obj;
            if (values[5].Equals(Visibility.Visible))
            {
                // if (
                //     values[0] is string logInName &&
                //     values[1] is string logInPassword
                //     )
                // {
                    //User user = User.GetFromDB(logInName, logInPassword);
                    //if (user != null)
                    //{
                        Views.GameView game = new Views.GameView();
                        game.Show();
                    //} 
                    //else
                    //{

                    //}
                    
                //}
            } else if (values[5].Equals(Visibility.Hidden))
            {
                if (
                    values[2] is string signUpName &&
                    values[3] is string signUpPassword &&
                    values[4] is string signUpPassoword
                    )
                {
                    User user = new User(signUpName, signUpPassword);
                    user.Save();
                }
            }
        }

        private bool CanSwap(object obj)
        {
            return true;
        }

        private void Swap(object obj)
        {
            var values = (object[]) obj;
            if (
                values[0] is FrameworkElement elementToHide && 
                values[1] is FrameworkElement elementToShow 
                )
            {
                elementToHide.Visibility = Visibility.Hidden;
                elementToShow.Visibility = Visibility.Visible;
            }
        }
    }
}
