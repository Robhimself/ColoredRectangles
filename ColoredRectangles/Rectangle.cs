namespace ColoredRectangles
{
    internal class Rectangle
    {
        public string Id { get; }
        private readonly ConsoleColor _color;
        private readonly int _x;
        private readonly int _y;
        private readonly int _width;
        private readonly int _height;
        private readonly int _maxHeight;

        public int GetMaxHeight() => _maxHeight;


        public Rectangle(ConsoleColor color, string id, int x, int y, int width, int height)
        {
            _color = color;
            Id = id;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _maxHeight = _x + _height;
        }

        public void Show()
        {
            for (var dy = 0; dy < _height; dy++)
            {
                ShowRow(_y + dy);
            }
        }

        private void ShowRow(int y)
        {
            Console.CursorLeft = _x;
            Console.CursorTop = y;
            Console.BackgroundColor = _color;
            var text = y == _y ? Id : string.Empty;
            Console.Write(text.PadRight(_width));
        }
    }
}
