using MinimalApi.Wpf.Core.Base;
using MinimalApi.Wpf.Core.Commands;
using System;

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
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand AboutViewCommand { get; set; }
        public RelayCommand GroupProjectViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand ResourceViewCommand { get; set; }
        public RelayCommand VideoPortalViewCommand { get; set; }


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
        }

        // Commands //
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
    }
}
