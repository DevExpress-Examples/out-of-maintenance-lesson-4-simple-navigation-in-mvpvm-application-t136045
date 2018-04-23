using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using MvpvmNavigation.ViewModels;
using DevExpress.Mvvm;
using MvpvmNavigation.Model;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MvpvmNavigation.Presenter {
    public class MainFormPresenter {
        public MainFormPresenter(PanelControl modulesPanel, MainFormViewModel viewModel) {
            modulesCache = new Dictionary<ModuleType, System.Windows.Forms.UserControl>();
            this.modulesPanel = modulesPanel;
            this.viewModelCore = viewModel;
            ViewModel.SelectedModuleTypeChanged += ViewModel_SelectedModuleTypeChanged;
        }

        MainFormViewModel viewModelCore;
        PanelControl modulesPanel;
        Dictionary<ModuleType, System.Windows.Forms.UserControl> modulesCache;

        public static string GetName(object parameter) {
            return parameter.ToString();
        }
        public static string GetDisplayText(object parameter) {
            return DevExpress.XtraEditors.EnumDisplayTextHelper.GetDisplayText(parameter);
        }

        public void Dispose() {
            ViewModel.SelectedModuleTypeChanged -= ViewModel_SelectedModuleTypeChanged;
            foreach (System.Windows.Forms.UserControl module in modulesCache.Values)
                module.Dispose();
            modulesCache.Clear();
        }
        public MainFormViewModel ViewModel {
            get { return viewModelCore; }
        }
        void ViewModel_SelectedModuleTypeChanged(object sender, System.EventArgs e) {
            modulesPanel.Controls.Clear();
            ModuleType type = ViewModel.SelectedModuleType;
            if (type == ModuleType.None)
                return;
            System.Windows.Forms.UserControl module;
            if (!modulesCache.TryGetValue(type, out module)) {
                switch (type) {
                    case ModuleType.ModuleA:
                        module = new Views.View1();
                        break;
                    case ModuleType.ModuleB:
                        module = new Views.View2();
                        break;
                }
                module.Dock = DockStyle.Fill;
                modulesCache.Add(type, module);
            }
            modulesPanel.Controls.Add(module);
        }
    }
}
