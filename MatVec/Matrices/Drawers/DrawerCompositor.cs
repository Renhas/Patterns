using CommandsLib.Memento;
using System.Collections.Generic;

namespace MatVec.Matrices.Drawers
{
    public class DrawerCompositor : AMementableDrawer, IDrawer
    {
        private List<IDrawer> _drawers;
        private bool _border;
        public bool Border
        {
            get
            {
                return _border;
            }
            set
            {
                _border = value;
                BorderSet();
            }
        }

        public DrawerCompositor() 
        {
            _border = true;
            _drawers = new List<IDrawer>();
        }

        public DrawerCompositor(List<IDrawer> drawers) : this()
        {
            foreach(var drawer in drawers)
                Add(drawer);
        }

        private void BorderSet() 
        {
            foreach (var drawer in _drawers)
                drawer.Border = _border;
        }

        public void Add(IDrawer drawer) 
        {
            _drawers.Add(drawer);
        }

        public void Clear()
        {
            foreach(var drawer in _drawers) 
            {
                drawer.Clear();
            }
        }

        public void DrawBorder(IMatrix matrix)
        {
            foreach (var drawer in _drawers)
            {
                drawer.DrawBorder(matrix);
            }
        }

        public void DrawElement(IMatrix matrix, int row, int column)
        {
            foreach (var drawer in _drawers)
            {
                drawer.DrawElement(matrix, row, column);
            }
        }

        public void Flush()
        {
            foreach (var drawer in _drawers)
            {
                drawer.Flush();
            }
        }

        public void MakeCanvas(IMatrix matrix)
        {
            foreach (var drawer in _drawers)
            {
                drawer.MakeCanvas(matrix);
            }
        }
        #region Mementable
        class MementoDrawerCompositor : IMemento 
        {
            private List<IDrawer> _drawers;
            private bool _border;
            private DrawerCompositor _owner;

            public MementoDrawerCompositor(DrawerCompositor owner) 
            {
                _owner = owner;
                _drawers = new List<IDrawer>(_owner._drawers);
                _border = _owner._border;
            }

            public void Restore()
            {
                _owner._drawers = _drawers;
                _owner._border = _border;
            }
        }
        public override IMemento CreateMemento()
        {
            return new MementoDrawerCompositor(this);
        }
        #endregion
    }
}
