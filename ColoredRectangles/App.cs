namespace ColoredRectangles
{
    internal class App
    {
        private readonly List<Rectangle> _rectangles;

        public App()
        {
            _rectangles = new List<Rectangle>
            {
                new Rectangle(ConsoleColor.DarkBlue, "A", 10, 10,  30, 4),
                new Rectangle(ConsoleColor.White, "B", 12, 12, 30, 5),
                new Rectangle(ConsoleColor.Red, "C", 14, 14, 30, 6),
            };
        }

        public void Run()
        {
            ShowRectangles();
            //while (true)
            //{
            //    Console.Clear();
            //    ShowRectangles();
            //    //ShowMenu();
            //    Console.Write("Hva vil du gjøre? ");
            //    var cmd = Console.ReadLine();
            //    if (cmd == "F")
            //    {
            //        //RemoveRectangle();
            //    }
            //}
        }

        private void ShowRectangles()
        {
            foreach (var rectangle in _rectangles)
            {
                rectangle.Show();
            }
        }
    }
}
