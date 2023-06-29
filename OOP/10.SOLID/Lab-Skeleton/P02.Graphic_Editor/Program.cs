using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var rectangle = new Rectangle();
            var square = new Square();

            var editor = new GraphicEditor();
            editor.DrawShape(circle);
            editor.DrawShape(rectangle);
            editor.DrawShape(square);
        }
    }
}
