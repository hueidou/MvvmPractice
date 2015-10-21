/*
  ViewModel定位器，包含了所有ViewModel的引用，作用是在xaml中提供这些ViewModel的入口点。

  在App.xaml中：
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MvvmPractice" x:Key="Locator" />
  </Application.Resources>

  在视图中：
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  如果需要添加其他ViewModel的入口，可参考MainViewModel的如下代码。
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MvvmPractice.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// MainViewModel的实例引用入口
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}