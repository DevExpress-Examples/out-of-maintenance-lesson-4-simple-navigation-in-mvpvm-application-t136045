using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using MvpvmNavigation.Model;
using DevExpress.Mvvm.POCO;

namespace MvpvmNavigation.ViewModels {
    public class MainFormViewModel {
        public virtual ModuleType SelectedModuleType {
            get;
            set;
        }
        protected virtual void OnSelectedModuleTypeChanged() {
            this.RaiseCanExecuteChanged(x => x.SelectModule(ModuleType.None));
            RaiseSelectedModuleTypeChanged();
        }

        public event EventHandler SelectedModuleTypeChanged;

        void RaiseSelectedModuleTypeChanged() {
            var handler = SelectedModuleTypeChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        [Command(UseCommandManager = false)]
        public void SelectModule(ModuleType type) {
            SelectedModuleType = type;
        }
        public bool CanSelectModule(ModuleType type) {
            return type != SelectedModuleType;
        }
    }
}
