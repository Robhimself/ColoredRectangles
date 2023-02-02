namespace ColoredRectangles
{
    internal class App
    {
        private readonly List<Rectangle> _rectangles;

        public App()
        {
            _rectangles = new List<Rectangle>
            {
                new Rectangle(ConsoleColor.DarkBlue, "A", 4, 4,  10, 4),
                new Rectangle(ConsoleColor.White, "B", 5, 5, 12, 5),
                new Rectangle(ConsoleColor.Red, "C", 6, 6, 14, 6),
            };
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowRectangles();
                ShowMenu();
                Console.Write("Hva vil du gjøre? ");
                var cmd = Console.ReadLine();
                if (cmd == "F")
                {
                    Console.WriteLine("Hvilken firkant vil du gjøre dette med? ");
                    var id = Console.ReadLine();
                    RemoveRectangle(id);
                }

                if (cmd == "+")
                {
                    AddRectangle();
                }

                if (cmd == "M")
                {
                    MoveRectangleToTop();
                }
            }
        }

        private void ShowMenu()
        {
            var menuHeight = FindMenuHeight();
            Console.CursorTop = menuHeight;
            Console.WriteLine();
            Console.WriteLine("F = Fjerne firkant");
            Console.WriteLine("+ = Legg til firkant");
            Console.WriteLine("M = Flytt firkant til toppen");
        }

        private void RemoveRectangle(string id)
        {
            var rectangleIndex = GetRectangleIndex(id);
            _rectangles.RemoveAt(rectangleIndex);
        }

        private int GetRectangleIndex(string id)
        {
            for (var index = 0; index < _rectangles.Count; index++)
            {
                var rectangle = _rectangles[index];
                if (rectangle.Id == id) return index;
            }

            return -1;
        }

        private void ShowRectangles()
        {
            foreach (var rectangle in _rectangles)
            {
                rectangle.Show();
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void AddRectangle()
        {
            var newRectangle = new Rectangle(ConsoleColor.Green, "D", 8, 8, 10, 10);
            _rectangles.Add(newRectangle);
        }

        private void MoveRectangleToTop()
        {
            Console.WriteLine("Hvilken firkant vil du gjøre dette med? ");
            string rectangleId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(rectangleId))
            {
                MoveRectangleToTop();
                return;
            }

            var rectangleIndex = GetRectangleIndex(rectangleId);
            var oldRectangle = _rectangles[rectangleIndex];
            
            RemoveRectangle(rectangleId);
            _rectangles.Add(oldRectangle);
        }

        private int FindMenuHeight()
        {
            var biggestHeight = _rectangles.Max(rect => rect.GetMaxHeight());
            return biggestHeight;
        }

    }
}
