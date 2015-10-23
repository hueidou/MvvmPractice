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

namespace MvvmLearn.ViewModel
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
            /*
            * 服务器定位器（ServiceLocator）指定IOC
            * 因为IOC的实现有多种
            */
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

            /*
            * IOC类似一个对象容器，
            * 需要先依类型注册，当外部调用需要这个类型的对象时，会自动创建该实例，并缓存起来，供再次使用
            *
            * 这里是将MainViewModel类型注册，以在将来提供其实例
            */
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SimpleViewModel>();
            SimpleIoc.Default.Register<AlbumViewModel>();
        }

        /// <summary>
        /// SimpleViewModel的实例引用入口
        /// </summary>
        public SimpleViewModel Simple
        {
            get
            {
                /*
                * ServiceLocator已指定SimpleIoc作为IOC来贮存对象实例
                * 
                * 这里是获取了SimpleViewModel贮存在IOC中的实例
                */
                return ServiceLocator.Current.GetInstance<SimpleViewModel>();
            }
        }

        /// <summary>
        /// SimpleViewModel的实例引用入口
        /// </summary>
        public SimpleViewModel Simple2
        {
            get
            {
                /*
                * ServiceLocator已指定SimpleIoc作为IOC来贮存对象实例
                * 
                * 这里是获取了SimpleViewModel贮存在IOC中的实例
                */
                return ServiceLocator.Current.GetInstance<SimpleViewModel>("Simple2");
            }
        }

        /// <summary>
        /// MainViewModel的实例引用入口
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                /*
                * ServiceLocator已指定SimpleIoc作为IOC来贮存对象实例
                * 
                * 这里是获取了MainViewModel贮存在IOC中的实例
                */
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// AlbumViewModel的实例引用入口
        /// </summary>
        public AlbumViewModel Album
        {
            get
            {
                /*
                * ServiceLocator已指定SimpleIoc作为IOC来贮存对象实例
                * 
                * 这里是获取了AlbumViewModel贮存在IOC中的实例
                */
                return ServiceLocator.Current.GetInstance<AlbumViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}