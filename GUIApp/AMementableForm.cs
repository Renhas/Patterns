using CommandsLib.Memento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIApp
{
    public abstract partial class AMementableForm : Form, IMementable
    {
        public AMementableForm()
        {
            InitializeComponent();
            MementableSystem.Instance.Registry(this);
        }
        public abstract IMemento CreateMemento();

        ~AMementableForm()
        {
            MementableSystem.Instance.Unregistry(this);
        }
    }
}
