﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCore1._1.Models
{
    public class ToolTips
    {
        public ObservableCollection<string> ToolTipsBg = new ObservableCollection<string>()
        {
            "Поставяне(Ctrl+V)\nПоставяне на съдържанието от Клипборда",
            "Нов\nСъздаване на нова картинка",
            "Отвори\nОтваряне на съществуваща картинка",
            "Копиране(Ctrl+C)\nКопиране на маркираната част от полето или на цялото съдържание в клипборда",
            "Изрязване(Ctrl+X)\nИзрязване на маркираната част от полето и поставяне в клипборда",
            "Запазване(Ctrl+S)\nСъхраняване на текущата картина",
            "Маркиране\nМаркиране на част от картинката",
            "Преоразмеряване\nПреоразмеряване и изкривяване на картинката",
            "Завъртане на дясно",
            "Огледално завъртане по вертикала",
            "Израязване на маркираната част",
            "Завъртане на ляво",
            "Огледално завъртане по хоризонтала",
            "Капкомер\nВземи цвят от снимката",
            "Молив\nРисувай криви линии с избраната дебелина",
            "Текст\\nВмъкни текс в картинката",
            "Гумичка\nИзтрий част от картинката",
            "Избере дебелина за посочения инструмент",
            "Преден цвят",
            "Цветове\nИзбере цвят от палитрата",
            "Удебеляване на текста",
            "Накланяне",
            "Подчертаване",
            "Зачертаване",
            "Изберете размер на шрифта",
            "Изберете шрифт",
            "Шкаф\nВсички временни състояние от обработката",
            "Камера\n Снимане на екрана",
            "Ефекти\nДобави ефект върху снимката",
            "Колаж\nСъздай колаж",
            "Рамки\nДобави рамка върхи снимката",
            "Скрий или покажи рамката",
            "Премахни рамката",
            "Назад(Ctrl+Z)",
            "Напред(Ctrl+Y)",
            "Отвори в редактора",
            "Съхрани тази картинка",
            "Предишна",
            "Отвори на цял екран",
            "Следваща",
            "Съхрани всички от шкафа",
            "Назад към шкафа",
            "Снимай маркираната част",
            "Минимизиране",
            "Изход",
            "Зареди снимка",
            "Назад към шаблоните",
            "Съхрани колажа",
            "Отвори колажа в редактора"
        };

        public ObservableCollection<string> ToolTipsAE = new ObservableCollection<string>()
        {
            "Paste(Ctrl+V)\n Paste the contents of the Clipboard",
            "New\nCreate a new picture",
            "Open\n Open a exiting picture",
            "Copy(Ctrl+C)\n Copy the selection from canvas or the whole canvas content and put it in Clipboard",
            "Cut(Ctrl+X)\n Cut the selection from canvas and put it in Clipboard",
            "Save(Ctrl+S)\nSave the current picture",
            "Selection\nSelect a part of the picture",
            "Resize\nResize and skew the picture",
            "Rotate right",
            "Vertical skew",
            "Crop the selection",
            "Rotate left",
            "Horizontal skew",
            "Color picker\nPick the color from the picture",
            "Pencil\nDraw a free-form lines with the selected line width",
            "Text\nInsert text into the picture",
            "Eraser\nErase part of the picture",
            "Select the width for the selected width",
            "Foreground color",
            "Colors\nSelect a color drom the coolor palette",
            "Bold style",
            "Italic style",
            "Underline style",
            "Strikeout style",
            "Choose font size",
            "Choose font",
            "Lybrary\nAll temporary conditions of processing",
            "Caprute\nCaprute the screen",
            "Effects\nAdd effect to the picture",
            "Collage\nCreate collage",
            "Frames\nAdd frame to the image",
            "Hide ot show the frame",
            "Remove the frame",
            "Undo(Ctrl+Z)",
            "Redo(Ctrl+Y)",
            "Open in Editor",
            "Save this",
            "Previous",
            "Fullscreen",
            "Next",
            "Save all from library",
            "Back to library",
            "Capture the selected area",
            "Minimize",
            "Close",
            "Load picture",
            "Back two pattern",
            "Save the collage",
            "Open the collage in the editor"
        };
    }
}
