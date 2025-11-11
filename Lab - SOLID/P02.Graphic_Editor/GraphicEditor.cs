using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            var result = shape.Draw();

            Console.WriteLine(result);
        }
    }
}
