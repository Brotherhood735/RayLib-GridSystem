using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSystem.src.GUI
{
    abstract internal class GUI_Base
    {
        protected string m_Id;
        protected int m_Width;
        protected int m_Height;
        public string Id { get { return m_Id; } }
        public int width { get { return m_Width; } }
        public int height { get { return m_Height; } }
        public GUI_Base(string id, int width, int height)
        {
            m_Id = id;
            m_Width = width;
            m_Height = height;
        }
        public GUI_Base(string id)
        {
            m_Id = id;
        }
        protected void Init(int width, int height)
        {
            m_Width = width;
            m_Height = height;
        }
        public abstract void Draw(int posX, int posY);
    }
}
