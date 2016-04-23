using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCore1._1.StaticFunctionClasses
{
    public class StaticCollections
    {
       private static readonly StaticCollections instance = new StaticCollections();
       public static StaticCollections Instance
       {
           get
           {
               return instance;
           }
       }
       public StaticCollections() { }
       private ObservableCollection<int> fontsize = new ObservableCollection<int>
       {
           9,10,11,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,56,72
       };
       public ObservableCollection<int> FontSize
       {
           get
           {
               return this.fontsize;
           }
       }
    }
}
