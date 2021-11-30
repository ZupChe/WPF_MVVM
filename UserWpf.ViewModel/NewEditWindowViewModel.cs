using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserWpf.Model;

namespace UserWpf.ViewModel
{
    public class NewEditWindowViewModel : INotifyPropertyChanged
    {

        private User currentUser;
        private string windowTitle;

        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser == value)
                {
                    return;
                }
                currentUser = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
        }


        public string WindowTitle
        {
            get { return windowTitle; }
            set
            {
                if (windowTitle == value)
                {
                    return;
                }
                windowTitle = value;
                OnPropertyChanged(new PropertyChangedEventArgs("windowTitle"));
            }
        }

        public NewEditWindowViewModel(User user)
        {
            CurrentUser = user;
            WindowTitle = "Edit User";
        }

        public NewEditWindowViewModel()
        {
            CurrentUser = new User();
            WindowTitle = "New User";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
