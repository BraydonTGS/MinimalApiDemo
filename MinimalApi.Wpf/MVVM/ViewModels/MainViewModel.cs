using MinimalApi.Wpf.Core.Base;
using MinimalApi.Wpf.Core.Commands;
using System;
using System.Windows.Input;

namespace MinimalApi.Wpf.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        // ViewModels //
        public HomeViewModel HomeViewModel { get; set; }
        public AboutViewModel AboutViewModel { get; set; }
        public GroupProjectsViewModel GroupProjectsViewModel { get; set; }
        public HelpViewModel HelpViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
        public ResourceViewModel ResourceViewModel { get; set; }
        public VideoPortalViewModel VideoPortalViewModel { get; set; }

        // Commands for Navigation //
        public ICommand HomeViewCommand { get; set; }
        public ICommand AboutViewCommand { get; set; }
        public ICommand GroupProjectViewCommand { get; set; }
        public ICommand HelpViewCommand { get; set; }
        public ICommand LoginViewCommand { get; set; }
        public ICommand ResourceViewCommand { get; set; }
        public ICommand VideoPortalViewCommand { get; set; }

        // Close and Minimize //
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }


        // Current View On Property Changed //
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            // ViewModels //
            HomeViewModel = new HomeViewModel();
            AboutViewModel = new AboutViewModel();
            GroupProjectsViewModel = new GroupProjectsViewModel();
            HelpViewModel = new HelpViewModel();
            LoginViewModel = new LoginViewModel();
            ResourceViewModel = new ResourceViewModel();
            VideoPortalViewModel = new VideoPortalViewModel();

            // Current View //
            CurrentView = HomeViewModel;

            // Set up Commands //
            SetUpCommands();
        }

        private void SetUpCommands()
        {
            HomeViewCommand = new RelayCommand(obj => ShowHomeView());
            AboutViewCommand = new RelayCommand(obj => ShowAboutView());
            GroupProjectViewCommand = new RelayCommand(obj => ShowGroupProjectView());
            HelpViewCommand = new RelayCommand(obj => ShowHelpView());
            LoginViewCommand = new RelayCommand(obj => ShowLoginView());
            ResourceViewCommand = new RelayCommand(obj => ShowResourceView());
            VideoPortalViewCommand = new RelayCommand(obj => ShowVideoPortalView());
            MinimizeWindowCommand = new RelayCommand(obj => MinimizeWindow());
            CloseWindowCommand = new RelayCommand(obj => CloseWindow());
        }



        // Navigation Commands //
        private void ShowHomeView()
        {
            CurrentView = HomeViewModel;
        }

        private void ShowAboutView()
        {
            CurrentView = AboutViewModel;
        }

        private void ShowGroupProjectView()
        {
            CurrentView = GroupProjectsViewModel;
        }

        private void ShowHelpView()
        {
            CurrentView = HelpViewModel;
        }

        private void ShowLoginView()
        {
            CurrentView = LoginViewModel;
        }

        private void ShowResourceView()
        {
            CurrentView = ResourceViewModel;
        }

        private void ShowVideoPortalView()
        {
            CurrentView = VideoPortalViewModel;
        }

        private void CloseWindow()
        {
            // Use the Close method to close the window
            App.Current.MainWindow.Close();
        }

        private void MinimizeWindow()
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
