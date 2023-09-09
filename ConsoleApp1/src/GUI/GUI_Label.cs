using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSystem.src.GUI
{
    internal class GUI_Label : GUI_Base
    {
        private string m_Text;
        private int m_Size;
        private Color m_Color;

        public string text { get { return m_Text; } }
        public int size { get { return m_Size; } }
        public Color color { get { return m_Color; } }


        public GUI_Label(string id, string text, int size, Color color) : base(id)
        {
            m_Text = text;
            m_Size = size;
            var width = Raylib.MeasureText(text, size);
            //for now the 5 is the padding will add this feature later on
            Init(width + 5, size);
            m_Color = color;
        }
        public override void Draw(int posX, int posY)
        {
            Raylib.DrawText(m_Text, posX, posY, m_Size, m_Color);
        }
    }
}
