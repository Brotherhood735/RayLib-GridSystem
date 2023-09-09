using ConsoleApp1.src.GUI;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.src
{
    internal class GridSystem
    {
        private List<GUI_Base> m_Elements = new();
        private int m_Columns;
        private int m_Rows;
        private int m_MaxElements;
        public int columns { get { return m_Columns; } }
        public int rows { get { return m_Rows; } }

        public GridSystem(int maxColumns, int maxRows) 
        {
            m_Columns = maxColumns;
            m_Rows = maxRows;
            m_MaxElements = m_Columns * m_Rows;
        }
        
        public void AddLabel(string text, int size, Color color)
        {
            Guid guid = Guid.NewGuid();
            var str = guid.ToString();
            var element = new GUI_Label(str, text, size, color);
            AddElement(element);
        }
        public void AddTexture2D(Texture2D tex, Color tint)
        {
            Guid guid = Guid.NewGuid();
            var str = guid.ToString();
            var element = new GUI_Texture2D(str, tex, tint);
            AddElement(element);
        }
        private void AddElement(GUI_Base element)
        {
            if (m_Elements.Count >= m_MaxElements)
            {
                Console.WriteLine("Grid System Elements Limit reached!!!");
                return;
            }
            m_Elements.Add(element);
        }
        public void Draw()
        {
            //TODO:: redo the loop
            /*
             * need a max height var to not go through element above
             * and need to re-implement the width calculation method.
             */
            int curRow = 1;
            int curCol = 1;

            int posX = 0;
            int posY = 0;
            foreach (var element in m_Elements)
            {
                element.Draw(posX,posY);
                //column counter
                if (curCol >= m_Columns)
                {
                    //go to the new line
                    curCol = 1;
                    curRow++;
                    posX = 0;
                    posY += element.height;
                }
                else
                {
                    curCol++;
                    posX += element.width;
                }
            }
        }
    }
}

