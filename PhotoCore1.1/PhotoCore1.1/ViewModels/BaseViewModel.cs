using PhotoCore1._1.Models;
using System;
using System.Linq;
using System.Windows;

namespace PhotoCore1._1.ViewModels
{
    /// <summary>
    /// Declare all antother viewmodels
    /// </summary>
    public class BaseViewModel:DependencyObject
    {
        private TopPanelViewModel top = new TopPanelViewModel();
        public TopPanelViewModel TopPanelViewModel
        {
            get
            {
                return top;
            }
            set
            {
                this.top = value;
            }
        }

        private LanguageViewModel lan = new LanguageViewModel();
        public LanguageViewModel LangiageViewModel
        {
            get
            {
                return lan;
            }
            set
            {
                this.lan = value;
            }
        }

        private ColorsViewModel col = new ColorsViewModel();
        public ColorsViewModel ColorsViewModel
        {
            get
            {
                return col;
            }
            set
            {
                this.col = value;
            }
        }

        public VisibilityProperties VisibilityPropertiesViewModel
        {
            get
            {
                return VisibilityProperties.Instance;
            }
        }

        public Images ImagesViewModel
        {
            get
            {
                return Images.Instance;
            }
        }
        public StaticFunctionClasses.StaticCollections StaticCollectionBind
        {
            get
            {
                return StaticFunctionClasses.StaticCollections.Instance;
            }
        }

        private InkCanvasViewModel drawingcanvasviewmodel = new InkCanvasViewModel();
        public InkCanvasViewModel DrawingCanvasViewmodel
        {
            get
            {
                return this.drawingcanvasviewmodel;
            }
            set
            {
                this.drawingcanvasviewmodel = value;
            }
        }

        private OptionsViewModel optionsviewmodel= new OptionsViewModel();
        public OptionsViewModel OptionsVModel
        {
            get
            {
                return this.optionsviewmodel;
            }
            set
            {
                this.optionsviewmodel = value;
            }
        }

        private LibraryViewModel libraryviewmodel = new LibraryViewModel();
        public LibraryViewModel LibraryViewModel
        {
            get
            {
                return this.libraryviewmodel;
            }
            set
            {
                this.libraryviewmodel = value;
            }
        }

        private CollageViewModel colaggeviewmodel = new CollageViewModel();
        public CollageViewModel CollageViewModel
        {
            get
            {
                return this.colaggeviewmodel;
            }
            set
            {
                this.colaggeviewmodel = value;
            }
        }

        private FirstPageEffects firstpageeffects = new FirstPageEffects();
        public FirstPageEffects FirstPageEffects
        {
            get
            {
                return this.firstpageeffects;
            }
            set
            {
                this.firstpageeffects = value;
            }
        }

        private SecondPageEffects secondpageffects = new SecondPageEffects();
        public SecondPageEffects SecondPageEffects
        {
            get
            {
                return this.secondpageffects;
            }
            set
            {
                this.secondpageffects = value;
            }
        }

        private ThirdPageEffects thirdpageeffects = new ThirdPageEffects();
        public ThirdPageEffects ThirdPageEffects
        {
            get
            {
                return this.thirdpageeffects;
            }
            set
            {
                this.thirdpageeffects = value;
            }
        }
      
        private FourPageEffects fourpageeffects = new FourPageEffects();
        public FourPageEffects FourPageEffects
        {
            get
            {
                return this.fourpageeffects;
            }
            set
            {
                this.fourpageeffects = value;
            }
        }

        private FramesViewModel frameviewmodel = new FramesViewModel();
        public FramesViewModel FrameViewModel
        {
            get
            {
                return this.frameviewmodel;
            }
            set
            {
                this.frameviewmodel = value;
            }
        }

        private ResizeViewModel resizeviewmodel = new ResizeViewModel();
        public ResizeViewModel ResizeVModel
        {
            get
            {
                return this.resizeviewmodel;
            }
            set
            {
                this.resizeviewmodel = value;
            }
        }
    }
}
