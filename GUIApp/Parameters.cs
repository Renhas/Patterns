using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIApp
{
    public class Parameters
    {
        public int Rows { get; }
        public int Columns { get; }
        public int NotNull { get; }
        public double Max { get; }

        public Parameters(int rows, int columns, int notNull,
            double max) 
        {
            Rows = rows;
            Columns = columns;
            NotNull = notNull;
            Max = max;
        }
    }
}
