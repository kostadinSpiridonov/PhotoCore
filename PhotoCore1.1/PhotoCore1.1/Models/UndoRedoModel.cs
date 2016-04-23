using PhotoCore1._1.StaticFunctionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoCore1._1.Models
{
    public class UndoRedoModel
    {
        private static readonly UndoRedoModel instance = new UndoRedoModel();
        public UndoRedoModel() { }
        public static UndoRedoModel Instance
         {
             get
             {
                 return instance;
             }
         }
    
        /// <summary>
        /// Stack for undo
        /// </summary>
        private Stack<Bitmap> undostack = new Stack<Bitmap>();
        public Stack<Bitmap> UndoStack
        {
            get
            {
                return this.undostack;
            }
            set
            {
                this.undostack = value;
            }
        }

        /// <summary>
        /// Stack for redo
        /// </summary>
        private Stack<Bitmap> redostack = new Stack<Bitmap>();
        public Stack<Bitmap> RedoStack
        {
            get
            {
                return this.redostack;
            }
            set
            {
                this.redostack = value;
            }
        } 
    }
}
