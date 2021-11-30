using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UserWpf.Model;

namespace UserWpf.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private User currentUser;
        private UserCollection userList;
        private ListCollectionView userListView;

        private string filteringText;


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

        public UserCollection UserList
        {
            get { return userList; }
            set
            {
                if (userList == value)
                {
                    return;
                }
                userList = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserList"));
            }

        }

        public ListCollectionView UserListView
        {
            get { return userListView; }
            set
            {
                if (userListView == value)
                {
                    return;
                }
                userListView = value;
                OnPropertyChanged(new PropertyChangedEventArgs("userListView"));
            }

        }

        public string FilteringText 
        {
            get { return filteringText; }
            set
            {
                if (filteringText == value)
                {
                    return;
                }
                filteringText = value;
                OnPropertyChanged(new PropertyChangedEventArgs("userListView"));
            }

        }


        public MainWindowViewModel()
        {
            this.PropertyChanged += MainWindowViewModel_PropertyChanged;

            UserList = UserCollection.GetAllUsers();

            UserListView = new ListCollectionView(UserList);
            UserListView.Filter = UserFilter;

            CurrentUser = new User();

        }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("FilteringText"))
            {
                UserListView.Refresh();
            }
        }

        private bool UserFilter(object obj)
        {
            if (FilteringText == null) return true;
            if (FilteringText.Equals("")) return true;

            User user = obj as User;
            return (user.DisplayName.ToLower().StartsWith(FilteringText.ToLower()) || user.UserName.ToLower().StartsWith(FilteringText.ToLower()));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}

