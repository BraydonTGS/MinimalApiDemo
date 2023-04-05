using MinimalApi.Wpf.Core.Base;
using MinimalApi.Wpf.Core.Commands;

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

            // Commands //
            HomeViewCommand = new RelayCommand(obj =>
            {
                CurrentView = HomeViewModel;
            });

            AboutViewCommand = new RelayCommand(obj =>
            {
                CurrentView = AboutViewModel;
            });

            GroupProjectViewCommand = new RelayCommand(obj =>
            {
                CurrentView = GroupProjectsViewModel;
            });

            HelpViewCommand = new RelayCommand(obj =>
            {
                CurrentView = HelpViewModel;
            });

            LoginViewCommand = new RelayCommand(obj =>
            {
                CurrentView = LoginViewModel;
            });

            ResourceViewCommand = new RelayCommand(obj =>
            {
                CurrentView = ResourceViewModel;
            });

            VideoPortalViewCommand = new RelayCommand(obj =>
            {
                CurrentView = VideoPortalViewModel;
            });
        }
    }
}
