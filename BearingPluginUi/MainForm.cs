using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BearingPlugin.Libary;

namespace BearingPluginUi
{
    public partial class MainForm : Form
    {
        private KompasConnector _connector;

        public MainForm()
        {
            InitializeComponent();
            _connector = new KompasConnector();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- Внешний диаметр внешнего обода (D1) должен быть больше, чем D2 + 1.8 * Диаметр Шарика и меньше, чем 200мм;\n"
                            + "- Внешний диаметр внутреннего обода (D2) должен быть больше, чем D3 + 0.2 * Диаметр Шарика;\n"
                            + "- Внутренний диаметр внутреннего обода (D3), размерностью не больше половины внешнего диаметра внутреннего обода (D2);\n"
                            + "- Толщина подшипшика должна быть от 15 до 30 мм;\n"
                            +"- Для построения опорного вала внутренний диаметр должен быть не меньше 10мм.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void OpenCompasButton_Click(object sender, EventArgs e)
        {
            _connector.OpenKompas();
        }

        private void CloseCompasButton_Click(object sender, EventArgs e)
        {
            _connector.CloseKompas();
            ;
        }
    }
}
