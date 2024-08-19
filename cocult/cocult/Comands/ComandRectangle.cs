namespace cocult.Comands
{
    /// <summary>
    /// команда для нахождения периметра или площади прямоугольника
    /// </summary>
    class ComandRectangle : IComand, IExample
    {
        /// <summary>
        /// поле для хранения фигур
        /// </summary>
        ListFigure<Figure> listEnteredShapes;
        /// <summary>
        /// имя команды
        /// </summary>
        public string NameComand { get; set; }

        public ComandRectangle(ListFigure<Figure> listEnteredShapes)
        {
            NameComand = "прямоугольник";
            this.listEnteredShapes = listEnteredShapes;
        }

        /// <summary>
        /// метод выполнения команды
        /// </summary>
        /// <param name="data">параметры задания</param>
        public void Execute(string data)
        {
            Console.Clear();
            Rectangle sq = new Rectangle(ToParametrs(data));

            listEnteredShapes.Add(sq);

            Console.WriteLine("Вы желаете найти S(1) или P(2)");

            int comand = Convert.ToInt32(Console.ReadLine());

            if (comand == 1) Console.WriteLine($"S = {sq.S()}");
            else if (comand == 2) Console.WriteLine($"P = {sq.P()}");
        }

        /// <summary>
        /// метод для преобразования строки в параметры для фигур
        /// </summary>
        /// <param name="parametr"></param>
        /// <returns></returns>
        private List<int> ToParametrs(string parametr)
        {
            string[] a = parametr.Split();
            List<int> parametrs = new List<int>();

            foreach (var c in a)
            {

                if (int.TryParse(c, out int d))
                {
                    parametrs.Add(Convert.ToInt32(c));
                }
            }

            return parametrs;
        }

        public string Example()
        {
            return $"{NameComand} - находит сумму или периметр прямоугольника" +
                $"\nОписание: вы должны ввести данные прямоугольника,после чего на экране появляется выбор нахождения площади или периметра " +
                $"\nПример:{NameComand} 2 3";
        }
    }
}
