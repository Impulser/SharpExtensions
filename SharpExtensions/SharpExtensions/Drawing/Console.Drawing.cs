using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpExtensions.Annotations;
using SharpExtensions.Extensions.Collection;
using SharpExtensions.Extensions.String;

namespace SharpExtensions.IO
{
    public static partial class Console
    {
        private static List<RenderedBlock> _renderedBlocks = new List<RenderedBlock>();
        private static List<RenderedText> _renderedTexts = new List<RenderedText>(); 

        public interface IBounds
        {
             int X { get; set; }
        }

        public struct RenderedText : IEquatable<RenderedText>
        {
            public static readonly RenderedText Empty = new RenderedText();

            public RenderedText(int x, int y, string format, params object[] arguments)
                : this()
            {
                Format = format;
                FormatArguments = arguments;
                Render = Format.Build(arguments);
                BoundingRectangle = new Rectangle(x, y, Render.Length, 1);
                var x = new TextBox().Bounds
            }

            public Rectangle BoundingRectangle { get; private set;}
            public string Render { get; private set; }
            public string Format { get; private set; }
            public object[] FormatArguments { get; private set; }

            public bool Equals(RenderedText other)
            {
                return other.BoundingRectangle.Location == BoundingRectangle.Location;
            }

            public void ClearScreen()
            {
                MoveBufferArea(BoundingRectangle.X, BoundingRectangle.Y, Render.Length, 1, -BoundingRectangle.Width, -BoundingRectangle.Height, ' ', ForegroundColor, BackgroundColor);
            }
        }

        public struct RenderedBlock : IEquatable<RenderedBlock>
        {
            public RenderedBlock(int x, int y, int width, int height, ConsoleColor fillColour)
                : this(new Rectangle(x, y, width, height), fillColour)
            {
         
            }

            public RenderedBlock(Rectangle boundingRectangle, ConsoleColor fillColour)
                : this()
            {
                BoundingRectangle = boundingRectangle;
                FillColour = fillColour;
            }

            public Rectangle BoundingRectangle { get; private set; }
            public ConsoleColor FillColour { get; private set; }

            public void ClearScreen()
            {
                SetCursorPosition(BoundingRectangle.X, BoundingRectangle.Y);
                var clearText = new StringBuilder();
                var cleanLine = new string(' ', BoundingRectangle.Width);
                for (var i = 0; i < BoundingRectangle.Height; i++)
                {
                    clearText.AppendLine(cleanLine);
                }
                SystemWrite(clearText.ToString());
            }

            public bool Equals(RenderedBlock other)
            {
                return object.Equals(this, other) || other.BoundingRectangle.Location == BoundingRectangle.Location;
            }
        }

		public static void FillRectangle(Rectangle rectangle, ConsoleColor fillColor)
		{
            var renderedRectangle = new RenderedBlock(rectangle, fillColor);
            MoveBufferArea(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, rectangle.Right, rectangle.Bottom, ' ', ForegroundColor, fillColor);
            _renderedBlocks.Add(renderedRectangle);
        }

        public static void FillRectangle(int x, int y, int w, int h, ConsoleColor fillColor)
        {
            FillRectangle(new Rectangle(x, y, w, h), fillColor);
        }

        public static void DrawRectangle(Rectangle rectangle, ConsoleColor fillColor)
        {
            //Top
            FillRectangle(rectangle.X, rectangle.Y, rectangle.Width, 1, fillColor);

            //Left
            FillRectangle(rectangle.X, rectangle.Y, 1, rectangle.Height, fillColor);

            //Bottom
            FillRectangle(rectangle.X, rectangle.Bottom, rectangle.Width + 1, 1, fillColor);

            //Right
            FillRectangle(rectangle.Right, rectangle.Y, 1, rectangle.Height, fillColor);
        }

        public static void DrawRectangle(int x, int y, int w, int h, ConsoleColor fillColor)
        {
            DrawRectangle(new Rectangle(x, y, w, h), fillColor);
        }

        [StringFormatMethod("format")]
        public static int DrawText(int x, int y, string format, params object[] arguments)
		{
		    SetCursorPosition(x, y);
            var renderBlock = new RenderedText(x, y, format, arguments);
            var existingBlock = _renderedTexts.Where(text => text.BoundingRectangle.IntersectsWith(renderBlock.BoundingRectangle));
            _renderedTexts.Add(renderBlock);
            _renderedTexts.RemoveAll(existingBlock.Contains);
            existingBlock.AsCollection().ForEach(text => text.ClearScreen());
            CustomWrite(renderBlock.Render);
            return format.Length;
		}

        public static void ClearRendered()
        {
            _renderedTexts.ForEach(renderedText => renderedText.ClearScreen());
        }

        public static Task StartRenderingLoop(Action renderLoop)
        {
            return Task.Factory.StartNew(renderLoop);
        }
    }
}
