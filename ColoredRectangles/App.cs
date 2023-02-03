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

                var cmd = GetUserInput();
                if (IsValidInput(cmd) == false)
                {
                    Console.WriteLine($"\"{cmd}\" er ikke en gyldig kommando. ");
                    Console.WriteLine("Trykk en tast for å fortsette...");
                    Console.ReadLine();
                    
                    continue;
                }
                
                if (cmd is "+") AddRectangle();
                if (cmd is "f" or "m") EditRectangle(cmd);
                if (cmd is "x" or "exit") break; // Avslutter programmet
            }
        }

        private static string GetUserInput()
        {
            Console.Write("Hva vil du gjøre? ");
            return Console.ReadLine().ToLower();
        }

        private static bool IsValidInput(string cmd)
        {
            if (cmd is "f" or "m" or "+" or "x" or "exit")
            {
                return true;
            }
            return false;
        }

        private bool IsValidRectangle(string id)
        {
            var idToCheck = GetRectangleIndex(id);
            return idToCheck >= 0 && idToCheck < _rectangles.Count;
        }

        private void ShowMenu()
        {
            Console.CursorTop = _rectangles.Max(rect => rect.GetMaxHeight());
            Console.WriteLine();
            Console.WriteLine("F = Fjerne firkant");
            Console.WriteLine("M = Flytt firkant til toppen");
            Console.WriteLine("+ = Legg til firkant");
            Console.WriteLine("X = For å avslutte programmet");
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
            /* Liten kladd for å generere random firkant. 
             * 
             * var color = 
             * var id = 
             * var x = _rectangles.Count + 4;
             * var y = 
             * var w = 
             * var h = 
             * var newRectangle = new Rectangle(ConsoleColor.Green, id, x, y, w, h);
             * _rectangles.Add(newRectangle);
             */
            
            var newRectangle = new Rectangle(ConsoleColor.Green, "D", 7, 7, 10, 10);
            _rectangles.Add(newRectangle);
        }

        private void MoveRectangleToTop(string id)
        {
            var rectangleIndex = GetRectangleIndex(id);
            var oldRectangle = _rectangles[rectangleIndex];
            
            RemoveRectangle(id);
            _rectangles.Add(oldRectangle);
        }

        private void EditRectangle(string cmd)
        {
            Console.Write("Hvilken firkant vil du gjøre dette med?: ");
            var id = Console.ReadLine();

            while (IsValidRectangle(id) == false)
            {
                Console.Write($"\"{id}\" finnes ikke. Vennligst tast inn bokstaven til en av firkantene over (case sensitive): ");
                id = Console.ReadLine();
            }

            if (cmd == "f")
                RemoveRectangle(id);
            else
                MoveRectangleToTop(id);
        }
        
    }
}
