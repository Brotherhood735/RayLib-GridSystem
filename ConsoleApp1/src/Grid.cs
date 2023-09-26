using GridSystem.src.GUI;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSystem.src
{
    public class Grid
    {
        private List<GUI_Base> m_Elements = new();
        private int m_Columns;
        private int m_Rows;
        private int m_MaxElements;
        private int m_MaxColumnWidth = 0;
        private int m_MaxRowHeight = 0;
        private GridRenderType m_RenderType;
        public int columns { get { return m_Columns; } }
        public int rows { get { return m_Rows; } }
        public int maxElements { get { return m_MaxElements; } }
        public Grid(int maxColumns, int maxRows, GridRenderType renderType) 
        {
            m_Columns = maxColumns;
            m_Rows = maxRows;
            m_RenderType = renderType;
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
            if (m_RenderType == GridRenderType.EqualSpaced)
            {
                // if we're using the equal spaced method we need to set these variables
                // to have consistent spaces
                if (element.width > m_MaxColumnWidth)
                {
                    m_MaxColumnWidth = element.width;
                }
                if (element.height > m_MaxRowHeight)
                {
                    m_MaxRowHeight = element.height;
                }
            }
            if (m_Elements.Count >= m_MaxElements)
            {
                Console.WriteLine("Grid System Elements Limit reached!!!");
                return;
            }
            m_Elements.Add(element);
        }
        public void Draw()
        {
            switch (m_RenderType)
            {
                case GridRenderType.Compact:
                    DrawCompact();
                    return;
                case GridRenderType.EqualSpaced:
                    DrawEqualSpaced();
                    return;
            }
        }

        private void DrawEqualSpaced()
        {
            int curRow = 1;
            int curCol = 1;

            int posX = 0;
            int posY = 0;
            foreach (var element in m_Elements)
            {
                element.Draw(posX, posY);
                //column counter
                if (curCol >= m_Columns)
                {
                    //go to the new Row
                    curCol = 1;
                    curRow++;
                    posX = 0;
                    posY += m_MaxRowHeight;
                    continue;
                }
                //go to the new Column
                curCol++;
                posX += m_MaxColumnWidth;
            }
        }

        private void DrawCompact()
        {
            int curRow = 1;
            int curCol = 1;

            int posX = 0;
            int posY = 0;
            foreach (var element in m_Elements)
            {
                element.Draw(posX, posY);
                //column counter
                if (curCol >= m_Columns)
                {
                    //go to the new Row
                    curCol = 1;
                    curRow++;
                    posX = 0;
                    posY += element.height;
                    continue;
                }
                //go to the new Column
                curCol++;
                posX += element.width;
            }
        }
    }
}

public enum GridRenderType
{
    Compact = 0,
    EqualSpaced = 1
}