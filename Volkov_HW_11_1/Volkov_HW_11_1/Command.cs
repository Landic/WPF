using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Volkov_HW_11_1
{
    public class CommandAdd
    {
        private static RoutedUICommand add;

        static CommandAdd()
        {
            InputGestureCollection input = new InputGestureCollection();
            add = new RoutedUICommand("Добавить", "Add", typeof(CommandAdd), input);
        }

        public static RoutedUICommand Add
        {
            get { return add;}
        }
    }

    public class CommandDel
    {
        private static RoutedUICommand del;

        static CommandDel()
        {
            InputGestureCollection input = new InputGestureCollection();
            del = new RoutedUICommand("Удалить", "Del", typeof(CommandAdd), input);
        }

        public static RoutedUICommand Del
        {
            get { return del; }
        }
    }

    public class CommandEdit
    {
        private static RoutedUICommand edit;

        static CommandEdit()
        {
            InputGestureCollection input = new InputGestureCollection();
            edit = new RoutedUICommand("Редактировать", "Edit", typeof(CommandAdd), input);
        }

        public static RoutedUICommand Edit
        {
            get { return edit; }
        }
    }

    public class CommandSaveJson
    {
        private static RoutedUICommand save;

        static CommandSaveJson()
        {
            InputGestureCollection input = new InputGestureCollection();
            save = new RoutedUICommand("Сохранить", "Save", typeof(CommandAdd), input);
        }

        public static RoutedUICommand Save
        {
            get { return save; }
        }
    }

    public class CommandLoadJson
    {
        private static RoutedUICommand load;

        static CommandLoadJson()
        {
            InputGestureCollection input = new InputGestureCollection();
            load = new RoutedUICommand("Загрузить", "Load", typeof(CommandAdd), input);
        }

        public static RoutedUICommand Load
        {
            get { return load; }
        }
    }

    public class CommandSelection
    {
        private static RoutedUICommand selection;

        static CommandSelection()
        {
            InputGestureCollection input = new InputGestureCollection();
            selection = new RoutedUICommand("Выбор", "Selection", typeof(CommandAdd), input);
        }

        public static RoutedUICommand Selection
        {
            get { return selection; }
        }
    }
}
