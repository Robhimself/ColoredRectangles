namespace ColoredRectangles
{
    internal class Rectangle
    {
        private readonly ConsoleColor _color;
        private readonly string _id;
        private readonly int _x;
        private readonly int _y;
        private readonly int _width;
        private readonly int _height;

        public Rectangle(ConsoleColor color, string id, int x, int y, int width, int height)
        {
            _color = color;
            _id = id;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public void Show()
        {
            for (var y = _y; y < _height + y; y++)
            {
                ShowRow(y);
            }
        }

        private void ShowRow(int y)
        {
            Console.CursorLeft = _x;
            Console.CursorTop = y;
            Console.BackgroundColor = _color;
            var text = y == _y ? _id : string.Empty;
            Console.Write(text.PadRight(_width));
        }
    }
}
