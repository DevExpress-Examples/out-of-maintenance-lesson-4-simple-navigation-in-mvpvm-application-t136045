using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvpvmNavigation.Model;
using DevExpress.Mvvm;
using DevExpress.XtraNavBar;
using DevExpress.Mvvm.POCO;
using MvpvmNavigation.ViewModels;
using MvpvmNavigation.Presenter;
using DevExpress.XtraBars.Navigation;


namespace MvpvmNavigation {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.viewModelCore = ViewModelSource.Create<MainFormViewModel>();
            this.presenterCore = CreatePresenter();
        }

        MainFormViewModel viewModelCore;
        MainFormPresenter presenterCore;

        public MainFormViewModel ViewModel {
            get { return viewModelCore; }
        }

        public MainFormPresenter Presenter {
            get { return presenterCore; }
        }

        protected virtual MainFormPresenter CreatePresenter() {
            return new MainFormPresenter(panelControl1, ViewModel);
        }

        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            ModuleType[] modules = new ModuleType[] {
                ModuleType.ModuleA, ModuleType.ModuleB
            };
            ViewModel.SelectedModuleType = modules[0];
            RegisterNavigationItems(modules);
        }
        void RegisterNavigationItems(ModuleType[] modules) {
            NavBarGroup[] groups = new NavBarGroup[modules.Length];
            for (int i = 0; i < modules.Length; i++) {
                NavBarGroup navGroup = new NavBarGroup();
                navGroup.Tag = modules[i];
                navGroup.Name = "navGroup" + MainFormPresenter.GetName(modules[i]);
                navGroup.Caption = MainFormPresenter.GetDisplayText(modules[i]);
                groups[i] = navGroup;
            }
            navBarControl1.Groups.AddRange(groups);
        }

        private void officeNavigationBar1_RegisterItem(object sender, NavigationBarNavigationClientItemEventArgs e) {
            NavBarGroup navGroup = (NavBarGroup)e.NavigationItem;
            var type = (ModuleType)navGroup.Tag;
            e.Item.Tag = type;
            e.Item.Text = MainFormPresenter.GetDisplayText(type);
            e.Item.Name = "navItem" + MainFormPresenter.GetName(type);
            e.Item.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => type);
        }
    }
}
