using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.src.GUI
{
    internal class GUI_Texture2D : GUI_Base
    {
        private Texture2D m_Texture;
        private Color m_Tint;
        public Texture2D Texture { get { return m_Texture; } }
        public Color tint { get { return m_Tint; } }

        public GUI_Texture2D(string id, Texture2D texture, Color tint)
            : base(id)
        {
            m_Texture = texture;
            m_Tint = tint;
            Init(texture.width, texture.height);
        }

        public override void Draw(int posX, int posY)
        {
            Raylib.DrawTexture(m_Texture, posX, posY, m_Tint);
        }
    }
}
