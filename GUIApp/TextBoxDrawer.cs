using MatVec.Matrices.Drawers;
using System.Windows.Forms;

namespace GUIApp
{
    internal class TextBoxDrawer : ConsoleDrawer
    {
        private TextBoxBase _box;
        public TextBoxDrawer(TextBoxBase box, bool border = true) 
            : base(border)
        {
            _box = box;
        }

        protected override void PrintLine(string str)
        {
            _box.Text += str + "\n";
        }

        public override void Clear()
        {
            base.Clear();
            _box.Text = string.Empty;
        }

    }
}
