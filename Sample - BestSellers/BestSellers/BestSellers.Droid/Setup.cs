using System;
using System.Collections.Generic;
using Android.Content;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Plugins.Visibility;

namespace BestSellers.Droid
{
    public class Setup
        : MvxBaseAndroidBindingSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override MvxApplication CreateApp()
        {
            return new App();
        }

        public class Converters
        {
            public readonly MvxVisibilityConverter Visibility = new MvxVisibilityConverter();
        }

        protected override IEnumerable<Type> ValueConverterHolders
        {
            get { return new[] {typeof (Converters)}; }
        }

        protected override void InitializeLastChance()
        {
            var errorHandler = new ErrorDisplayer(ApplicationContext);
            Cirrious.MvvmCross.Plugins.Visibility.PluginLoader.Instance.EnsureLoaded();
            base.InitializeLastChance();
        }
    }
}