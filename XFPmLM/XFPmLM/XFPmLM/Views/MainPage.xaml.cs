using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XFPmLM.Models;

namespace XFPmLM.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnType.Clicked += (s, e) =>
            {
                IUnityContainer myContainer = (App.Current as PrismApplication).Container;

                #region 註冊介面對應到一個類別或這具體的型別
                // 註冊一個預設、沒有命名名稱的型別對應，並且使用短暫(transient)生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>();
                // 取得新產生的執行個體
                var fooObject = myContainer.Resolve<IMyClass>();

                // 註冊一個預設、有命名名稱的型別對應，並且使用短暫(transient)生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>("MyMapping");
                // 使用已經命名名稱，取得新產生的執行個體
                fooObject = myContainer.Resolve<IMyClass>("MyMapping");

                // 註冊一個預設、沒有命名名稱的型別對應，並且使用每個執行緒(per thread)生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>(new PerThreadLifetimeManager());
                // 在相同執行續下，將會取得相同 singleton 執行個體，容器將會持有僅僅一個弱參考的執行個體
                // https://msdn.microsoft.com/zh-tw/library/ms404247(v=vs.110).aspx
                fooObject = myContainer.Resolve<IMyClass>();

                // 註冊一個預設、沒有命名名稱的型別對應，並且使用額外控制(externally-controlled)生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>(new ExternallyControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會持有僅僅一個弱參考的執行個體
                fooObject = myContainer.Resolve<IMyClass>();

                // 註冊一個預設、有命名名稱的型別對應，並且使用額外控制(externally-controlled)生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>("MyMapping", new ExternallyControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會持有僅僅一個弱參考的執行個體
                fooObject = myContainer.Resolve<IMyClass>("MyMapping");
                #endregion

                #region 註冊一個類別或者型別，但具有 singleton 執行個體
                // https://msdn.microsoft.com/en-us/library/dn507499(v=pandp.30).aspx

                // 註冊一個預設、沒有命名名稱的型別對應，並且使用 singleton 生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>(new ContainerControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會負責接管該物件生命週期管理
                fooObject = myContainer.Resolve<IMyClass>();

                // 註冊一個預設、有命名名稱的型別對應，並且使用 singleton 生命週期(lifetime)管理
                myContainer.RegisterType<IMyClass, MyClass>("MyMapping", new ContainerControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會負責接管該物件生命週期管理
                myContainer.Resolve<IMyClass>();

                // 註冊一個沒有型別對應，並且使用 singleton 生命週期(lifetime)管理，使用容器僅建置 singletone 行為
                myContainer.RegisterType<MyClass>(new ContainerControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會負責接管該物件生命週期管理
                fooObject = myContainer.Resolve<MyClass>();

                // 註冊一個有命名名稱，但沒有型別對應，並且使用 singleton 生命週期(lifetime)管理，使用容器僅建置 singletone 行為
                myContainer.RegisterType<MyClass>("MyMapping", new ContainerControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會負責接管該物件生命週期管理
                fooObject = myContainer.Resolve<MyClass>("MyMapping");
                #endregion
            };

            btnObject.Clicked += (s, e) =>
            {
                IUnityContainer myContainer = (App.Current as PrismApplication).Container;

                #region 註冊一個存在物件，使其成為 singleton 執行個體
                var fooMyClassObject = new MyClass();

                // 註冊一個存在物件為預設、沒有命名名稱、使用預設容器控制器(container-controlled)生命週期管理
                myContainer.RegisterInstance<IMyClass>(fooMyClassObject);
                // 取得 singleton 執行個體，容器將會接管這個物件的生命週期管理
                var fooObject = myContainer.Resolve<IMyClass>();

                // 註冊一個存在物件為預設、有命名名稱、使用預設容器控制器(container-controlled)生命週期管理
                myContainer.RegisterInstance<IMyClass>("MySingleton", fooMyClassObject);
                // 取得 singleton 執行個體，容器將會接管這個物件的生命週期管理
                fooObject = myContainer.Resolve<IMyClass>("MySingleton");

                // 註冊一個存在物件為預設、有命名名稱、使用指定容器控制器(container-controlled) ContainerControlledLifetimeManager 生命週期管理
                myContainer.RegisterInstance<IMyClass>("MySingleton", fooMyClassObject, new ContainerControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會接管這個物件的生命週期管理
                fooObject = myContainer.Resolve<IMyClass>("MySingleton");

                // 註冊一個存在物件為預設、沒有命名名稱、使用額外控制(externally controlled)生命週期管理
                myContainer.RegisterInstance<IMyClass>(fooMyClassObject, new ExternallyControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會持有僅僅一個弱參考的物件
                fooObject = myContainer.Resolve<IMyClass>();

                // 註冊一個存在物件為預設、有命名名稱、使用額外控制(externally controlled)生命週期管理
                myContainer.RegisterInstance<IMyClass>("MySingleton", fooMyClassObject, new ExternallyControlledLifetimeManager());
                // 取得 singleton 執行個體，容器將會持有僅僅一個弱參考的物件
                fooObject = myContainer.Resolve<IMyClass>("MySingleton");

                // 註冊一個存在物件為預設、有命名名稱、使用每個執行續(per thread)生命週期管理
                myContainer.RegisterInstance<IMyClass>("MySingleton", fooMyClassObject, new PerThreadLifetimeManager());
                // 取得 singleton 執行個體，容器將會持有僅僅一個弱參考的物件
                fooObject = myContainer.Resolve<IMyClass>("MySingleton");
                #endregion
            };
        }
    }
}
