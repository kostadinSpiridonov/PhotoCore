using PhotoCore1._1.Commands;
using PhotoCore1._1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoCore1._1.ViewModels
{
    public class LanguageViewModel:INotifyPropertyChanged
    {
        ToolTips tooltips = new ToolTips();

        public LanguageViewModel()
        {
            currentlanguage = Language.CurrentLanguage;
            currenttooltips = tooltips.ToolTipsAE;
        }
        private ObservableCollection<string> currentlanguage;
        public ObservableCollection<string> CurrentLanguage
        {
            get
            {
                return this.currentlanguage;
            }
            set
            {
                this.currentlanguage = value;
            }
        }

        private ObservableCollection<string> currenttooltips;
        public ObservableCollection<string> CurrentToolTips
        {
            get
            {
                return this.currenttooltips;
            }
            set
            {
                this.currenttooltips = value;
            }
        }

        /// <summary>
        /// Change language to english
        /// </summary>
        private ICommand changelanguageae;
        public ICommand ChangeLanguageAE
        {
            get
            {
                if (this.changelanguageae == null)
                {
                   this.changelanguageae = new RelayCommand(this.AE);
                }
                return this.changelanguageae;
            }
        } 
        private void AE(object obj)
        {
            Language.CurrentLanguage = Language.English;
            this.CurrentLanguage = Language.CurrentLanguage;
            this.currenttooltips = tooltips.ToolTipsAE;
            NotifyPropertyChanged("CurrentLanguage");
            NotifyPropertyChanged("CurrentToolTips");
        }
  
        /// <summary>
        /// Change language to Buglarian
        /// </summary>
        private ICommand changelanguagebg;
        public ICommand ChangeLanguageBG
        {
            get
            {
                if (this.changelanguagebg == null)
                {
                    this.changelanguagebg = new RelayCommand(this.BG);
                }
                return this.changelanguagebg;
            }
        }
        private void BG(object obj)
        {
            this.currenttooltips = tooltips.ToolTipsBg;
            Language.CurrentLanguage = Language.Bulgarian;
            this.CurrentLanguage = Language.CurrentLanguage;
            NotifyPropertyChanged("CurrentLanguage");
            NotifyPropertyChanged("CurrentToolTips");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        } 
    }
}
