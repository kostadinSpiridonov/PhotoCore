using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCore1._1.Models
{
    public  class Language
    {
        public static ObservableCollection<string> Bulgarian = new ObservableCollection<string>()
        {
            "Начало","Текст","Функции","Постави","Нов","Отвори","Копирай","Изрежи","Съхрани","Маркирай","Oразмери","Кроп","Добави","Опции изображение","Инструменти",
            "Размер","Цветове","Снимката е твърде голяма","Нов лист","Съхрани като","Изход","Шрифт","Шкаф","Камера","Ефекти","Колаж","Рамки"," Видима","Премахни","Рамки",
            "Искате ли да запазите тази картинка?","Опции","Цвят на прозореца","Снимай","Минимизиране","Изход","Цвят на рамката","Дебелина на рамката","Радиус на заобляне",
            "Съхрани","Отвори в редактора","Изберете шаблон","Изчисти всички ефекти","Яркост","Контраст","Гама","Медиан","Черно-бяло","Инвертиране","Въртене","Сферичност",
            "Приложи","Червено","Зеленено","Синьо","Изберете област от снимката","Изберете вид ефект","Черно и бяло","Цветно","Цялата картинка","Част от картинка",
            "Смяна на цвят","Изостряне","Сепия","Нюанс","Гладкост","Релеф","Ръбове","Замъгляване","1.Изберете цвят с капкомера от картинката.","2.Изберете район от снимката",
            "3.Изберете цвят от \nпалитрата","4.Настиснете Приложи","Избран цвят","Замени с","Втори цвят","Вълни","Пикселизация","Рисунка","Заобляне","Оттенък","Сливане",
            "Размазване","Смяна канали","Ъгъл","Стойност на оттенъка","Избери","Изберете снимка за сливане","Слей","Премахни снимката","Постеризация","Прозрачност",
            "Едноцветно","Соларизация","Дълбочина","Скрийте или премахнете рамката","Език","Преоразмеряване(проценти):","Хоризонтално:","Вертикално:","Вертикално=Хоризонтално",
            "Изкривяване(градуси):","Отмени","Капкомер" 
        };
        public static ObservableCollection<string> English = new ObservableCollection<string>()
        {
            "Home","Text","Functions","Paste","New","Open","Copy","Cut","Save","Select","Resize","Crop","Add","Picture functions","Tools","Size","Colors",
            "The image is too large !","New list","Save as","Exit","Font","Library","Capture","Effects","Collage","Frames","Visible","Remove","Frames",
            "Do you want to save the image?","Options","Window color","Capture","Minimize","Close","Border Color","Border Thikness","Corner Radius",
            "Save","Open in editor","Chose pattern","Clear all effects","Brightness","Contrast","Gamma","Median","Grayscale","Invert","Swirl","Sphere","Apply",
            "Red","Green","Blue","Chose area from the image","Chose type of the effect","Black and White","Color","Whole image","Part of the image","Change color",
            "Sharpen","Sepia","Tint","Smooth","Emboss","Edge","Jitter","1.Chose color with picker from the image.","2.Chose area from the image","3.Chose second color from palette",
            "4.Press Apply","Chosen color","Replace with","Second color","Water","Pixellete","Cartoon","Rounding","Hue","Merge","Oil","Channel rotate","Angle","Hue value",
            "Browse","Browse image for merge","Merge","Clear merge image","Posterization","Transperenty","Monochrome","Solarise","Wrap","Hide or remove the frame !!!","Language",
            "Resize (Percent):","Horizontal:","Vertical:","Vertical = Horizontal","Skew(Degree):","Cancel","Picker"

        };

        public static ObservableCollection<string> CurrentLanguage = English;

      
    }
}
