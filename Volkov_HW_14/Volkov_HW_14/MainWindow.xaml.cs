﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Volkov_HW_14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeSelect(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null) 
                SetFlowDocument(listBox.SelectedIndex);
        }
        private void AddRecept(string text)
        {
            ListItem item = new ListItem();
            Paragraph paragraph = new Paragraph(new Run(text));
            paragraph.Style = (Style)FindResource("ParagraphStyle");
            item.Blocks.Add(paragraph);
            list.ListItems.Add(item);
        }

        private void SetFlowDocument(int index)
        {
            str.Text = "Ингредиенты:";
            foreach (var item in list.ListItems.ToList())
            {
                list.ListItems.Remove(item);
            }   
            description.Inlines.Clear();
            if(index == 0)
            {
                title.Content = "Борщ";
                img.Source = new BitmapImage(new Uri("img/Borsh.jpg", UriKind.Relative));
                AddRecept("Вода – 1,5-2 л.");
                AddRecept("Свинина или говядина на кости – 400 г");
                AddRecept("Картофель – 4 шт. (средние)");
                AddRecept("Свекла – 2 шт. (небольшие)");
                AddRecept("Морковь – 1 шт.");
                AddRecept("Лук – 3 шт. (средние)");
                AddRecept("Капуста белокочанная свежая – 300 г");
                AddRecept("Томатная паста – 2 ст. л.");
                AddRecept("Подсолнечное масло – 4-5 ст. л.");
                AddRecept("Лимонная кислота – щепотка");
                AddRecept("Соль, лавровый лист, зелень – по вкусу.");
                description.Inlines.Add(new Run("Сначала варим бульон. В кастрюлю наливаем 1,5-2 литра воды. Добавляем мясо и ставим на средний огонь. Перед закипанием снимаем пену. Как только бульон закипит, накрываем крышкой " +
                    "и варим на медленном огне час-полтора. Тем временем готовим зажарку.Чистим свеклу, морковь и лук." +
                    "Свеклу натираем на крупной терке, а морковь – на средней.Лук нарезаем кубиками.На среднем огне в сковороде разогреваем растительное масло, высыпаем туда лук и морковь, жарим 5 минут.Затем добавляем свеклу" +
                    "(его можно посыпать лимонной кислотой или сбрызнуть соком свежего лимона – так борщ будет по - настоящему красным).Жарим овощи еще 5 минут, добавляем томатную пасту, " +
                    "перемешиваем и жарим все еще 5 - 7 минут. А теперь варим сам борщ. Из бульона вынимаем мясо и, пока оно остывает, бросаем в бульон нашинкованную капусту. Через 5-10 минут добавляем нарезанный соломкой картофель. " +
                    "Отделяем мясо от кости и нарезаем кубиками. Возвращаем мясо в борщ, солим его и добавляем зажарку. Перемешиваем борщ, кладем лавровый лист и мелко порубленную зелень, накрываем крышкой и варим все еще 5-7 минут." +
                    "\r\n\r\nПодаем борщ со сметаной и зеленью."));
            }
            else if(index == 1)
            {
                title.Content = "Макароны по-флотски";
                img.Source = new BitmapImage(new Uri("Images/spaghetti.jpg", UriKind.Relative));
                AddRecept("Макароны (перья с бороздками, спиральки и т.п.) - 225 г");
                AddRecept("Говядина - 275 г");
                AddRecept("Лук репчатый - 175 г");
                AddRecept("Масло сливочное - 50 г");
                AddRecept("Масло растительное - 3 ст. ложки");
                AddRecept("Соль - по вкусу");
                AddRecept("Перец чёрный молотый - по вкусу");
                AddRecept("Вода - 1,25 л");
                description.Inlines.Add(new Run("Легендарный рецепт макарон по-флотски, придуманный, по одной из версий, " +
                    "советским поваром в середине прошлого века и представленный на кулинарном конкурсе в Риме. " +
                    "Главная особенность этого рецепта - добавление сливочного масла, причём на двух этапах приготовления блюда. " +
                    "Рецепт также отличается способом обжаривания фарша и лука. Макароны желательно выбирать с бороздками, " +
                    "чтобы фарш хорошо удерживался на них. Подготовить продукты по списку. Очищенный лук нарезать небольшими кубиками. " +
                    "(В оригинальном рецепте лук нарезается перьями.) В сковороде разогреть 1 ст. ложку растительного масла. " +
                    "Выложить нарезанный лук и жарить, помешивая, 7-8 минут, до золотистого цвета. После этого добавить к луку 25 г сливочного масла. " +
                    "Растопить масло и поджарить лук ещё 1-2 минуты на небольшом огне, пока не появится приятный сливочно-луковый аромат. Говядину нарезать " +
                    "кусочками и пропустить через мясорубку со средней решёткой. Выложить мясной фарш на отдельную, хорошо разогретую сковороду. " +
                    "Постоянно разбивать фарш лопаткой, чтобы не оставалось крупных комочков. Жарить на огне чуть выше среднего, пока весь сок не испарится и фарш не поменяет цвет на серый, около 5 минут." +
                    "После этого влить в сковороду с фаршем 1 ст. ложку растительного масла, немного уменьшить огонь и жарить фарш до золотистого цвета и приятного аромата жареного мяса, " +
                    "ещё минут 7-8. В процессе жарки фарш не солить и не перчить. Готовый мясной фарш и обжаренный лук соединить. Добавить соль и перец, перемешать и оставить немного настояться. " +
                    "В кастрюле довести воду до кипения, добавить щепотку соли. Опустить макароны в кипящую воду и варить до готовности по инструкции на упаковке, примерно 10 минут " +
                    "(в рецепте отмечалось, что именно до мягкости, а не альденте).Отваренные макароны откинуть на дуршлаг, чтобы стекла вся вода, вернуть в кастрюлю. " +
                    "К макаронам добавить 25 г сливочного масла. Перемешать. Добавить к макаронам в кастрюле фарш с луком. Всё хорошо перемешать. Выложить макароны по-флотски в тарелку и подавать к столу." +
                    "Это самые вкусные, сытные и аппетитные макароны! Приятного вам аппетита!"));
            }
            else if(index == 2)
            {
                title.Content = "Паста \"Карбонара\"";
                img.Source = new BitmapImage(new Uri("Images/Spaghetti2.jpg", UriKind.Relative));
                AddRecept("Спагетти - 400 г");
                AddRecept("Грудинка варено-копчёная - 200 г");
                AddRecept("Яйцо куриное - 1 шт.");
                AddRecept("Сливочное масло 60г");
                AddRecept("Желтки - 3 шт.");
                AddRecept("Сыр пармезан - 75 г");
                AddRecept("Масло сливочное - 2 ст.ложки");
                AddRecept("Масло оливковое - 1 ст.ложка");
                AddRecept("Чеснок - 2 зубчика");
                AddRecept("Соль - по вкусу");
                AddRecept("Перец черный - по вкусу");
                description.Inlines.Add(new Run("Как приготовить пасту \"Карбонара\": Нарезать грудинку мелкими кубиками. Разогреть сковороду, растопить 1 ст. ложку сливочного масла и отправить туда грудинку. " +
                    "Добавить 2 зубчика чеснока, предварительно раздавленных ножом. Грудинку обжаривать на маленьком огне 10 минут, из неё должен вытопиться жир, но она должна остаться мягкой. " +
                    "После обжаривания чеснок убрать.В кипящую воду добавляем 1 ст. ложку соли, 1 ст. ложку оливкового масла и спагетти. Варим так, " +
                    "как указано на упаковке спагетти, - важно соблюдать указанное время варки, чтобы сварить спагетти правильно. У трёх яиц отделить белки от желтков. " +
                    "Отправить в миску 3 желтка и одно яйцо с белком, посолить и поперчить (по 1 щепотке), хорошо взбить и добавить 2 ст. ложки натертого сыра. Перемешать. " +
                    "Готовые спагетти откинуть на дуршлаг, предварительно оставив 1,5 стакана воды, в которой они варились. Выключить огонь под сковородой с грудинкой, отправить туда спагетти, " +
                    "добавить 1 ст. ложку сливочного масла и вылить взбитые яйца с сыром. Все тщательно перемешать, " +
                    "постепенно добавить 1 стакан воды от спагетти и 2 ст. ложки сыра, постоянно перемешивая, чтобы яйца не свернулись. Распределить спагетти по тарелкам, сверху добавить грудинку, посыпать черным молотым перцем и тертым сыром. " +
                    "Паста карбонара готова.Всегда вкусно!"));
            }
            else if (index == 3)
            {
                title.Content = "Лазанья";
                img.Source = new BitmapImage(new Uri("Images/Lazania.jpg", UriKind.Relative));
                AddRecept("Листы для лазаньи (сухие) - 6 шт.");
                AddRecept("Фарш мясной (свинина/говядина) - 750 г");
                AddRecept("Лук репчатый - 1 шт.");
                AddRecept("Бульон мясной - 200 мл");
                AddRecept("Сыр твёрдый - 250 г");
                AddRecept("Томатная паста - 2 ст. ложки");
                AddRecept("Масло растительное - 1 ст. ложка");
                AddRecept("Соль - по вкусу");
                AddRecept("Перец чёрный молотый - по вкусу");
                AddRecept("Для соуса бешамель:");
                AddRecept("Молоко - 500 мл");
                AddRecept("Масло сливочное - 80 г");
                AddRecept("Мука пшеничная - 60 г");
                AddRecept("Мускатный орех молотый - 0,5 ч. ложки");
                AddRecept("Соль - по вкусу");

                description.Inlines.Add(new Run("Подготавливаем все необходимые ингредиенты. Лук нарезаем мелкими кубиками. Лук обжариваем на растительном масле до золотистости." +
                    "Как только лук стал золотистым и мягким, добавляем к нему фарш. Томатную пасту разводим мясным бульоном. " +
                    "Фарш солим, перчим, добавляем томатную пасту, смешанную с бульоном, и тушим минут 10. Готовим соус бешамель.В сковороде растапливаем сливочное масло, добавляем просеянную муку, непрерывно помешивая венчиком. " +
                    "Тонкой струйкой вливаем молоко, продолжая помешивать. Как только соус начнёт густеть, добавляем соль и мускатный орех. Когда соус начнёт кипеть, выключаем огонь. Сыр натираем на крупной тёрке. " +
                    "Духовку разогреваем до 200 градусов.Собираем лазанью.Дно формы для запекания смазываем соусом бешамель. Затем выкладываем слой листов лазаньи (их можно свободно ломать). " +
                    "Сверху добавляем мясную начинку и равномерно распределяем. На мясную начинку - снова соус бешамель. Посыпаем сыром. Все слои выкладываем в том же порядке. " +
                    "Последним слоем должен быть сыр. Форму с лазаньей отправляем в разогретую до 200 градусов духовку примерно на 30 минут (ориентируйтесь на свою духовку)."));
            }
            else if (index == 4)
            {
                title.Content = "Домашние сырные палочки";
                img.Source = new BitmapImage(new Uri("Images/Chees.jpg", UriKind.Relative));
                AddRecept("Сыр твердый - 300 г");
                AddRecept("Яйцо - 1 шт.");
                AddRecept("Мука - 30 г (1 ст. ложка с горкой)");
                AddRecept("Масло растительное - 70 мл");
                description.Inlines.Add(new Run("Приготовим продукты для сырных палочек. Сыр натереть на мелкой терке, добавить муку, яйцо. Перемешать." +
                    "Сформировать сырные палочк. Обжарить их в растительном масле до золотистого цвета."));
            }
        }
    }
}
