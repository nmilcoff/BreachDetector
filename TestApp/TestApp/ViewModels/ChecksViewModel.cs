
using Xamarin.Forms;
using Plugin.BreachDetector;

namespace TestApp.ViewModels
{
    public class ChecksViewModel : BaseViewModel
    {
        public Command ExecuteChecksCommand { get; set; }

        public ChecksViewModel()
        {
            Title = "Checks";

            ExecuteChecksCommand = new Command(() => ExecuteChecks()); 
        }

        bool? _root;
        public bool? Root
        {
            get { return _root; }
            set { SetProperty(ref _root, value); }
        }

        bool? _virtualDevice;
        public bool? VirtualDevice
        {
            get { return _virtualDevice; }
            set { SetProperty(ref _virtualDevice, value); }
        }

        bool? _debug;
        public bool? Debug
        {
            get { return _debug; }
            set { SetProperty(ref _debug, value); }
        }

        bool? _store;
        public bool? Store
        {
            get { return _store; }
            set { SetProperty(ref _store, value); }
        }

        string _lockScreen = string.Empty;
        public string LockScreen
        {
            get { return _lockScreen; }
            set { SetProperty(ref _lockScreen, value); }
        }

        void ExecuteChecks()
        {
            if (IsBusy)
                return;

            Root = CrossBreachDetector.Current.IsRooted();
            VirtualDevice = CrossBreachDetector.Current.IsRunningOnVirtualDevice();
            Debug = CrossBreachDetector.Current.InDebugMode();
            Store = CrossBreachDetector.Current.InstalledFromStore();
            LockScreen = CrossBreachDetector.Current.GetDeviceLocalSecurityType().ToString();
        }
    }
}