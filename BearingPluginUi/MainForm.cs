using System;
using System.Windows.Forms;
using BearingPlugin.Libary;
using System.Text.RegularExpressions;
using BearingPlugin.UI;
using TextBox = System.Windows.Forms.TextBox;
using System.Collections.Generic;

namespace BearingPluginUi
{
    public partial class MainForm : Form
    {
        private KompasConnector _connector;

        public MainForm()
        {
            InitializeComponent();
            _connector = new KompasConnector();
                FormButtons_enable(true, false, false);
        }

        private void OpenCompasButton_Click(object sender, EventArgs e)
        {
            _connector.OpenKompas();
            FormButtons_enable(false, true, true);
        }

        private void CloseCompasButton_Click(object sender, EventArgs e)
        {
            _connector.CloseKompas();
            FormButtons_enable(true, false, false);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            var errorMsg = string.Empty;
            var dict = new Dictionary<TextBox, string>
            {
                {ExternalDiametrOutRim, "Некорректный внешний диаметр внешнего обода\n "},
                {ExternalDiametrInRim, "Некорректный внешний диаметр внутреннего обода\n "},
                {InternalDiametrInRim, "Некорректный внутренний диаметр внутреннего обода\n "},
                {BearingWidth, "Некорректная ширина подшипника\n "},
            };
            var valueParams = new List<double>();
            foreach (var keyValuePair in dict)
            {
                var curentParameter = 0.0;
                if (!double.TryParse(keyValuePair.Key.Text, out curentParameter))
                {
                    errorMsg += keyValuePair.Value;
                }

                valueParams.Add(curentParameter);
            }
            
            bool.TryParse(this.SupportShuft.Text, out bool supportShuft);
           

            if (errorMsg != String.Empty)
            {
                ShowMessage(errorMsg);
                return;
            }

            try
            {
                var parameters = new BearingParametrs(valueParams[0], 
                    valueParams[1], valueParams[2], valueParams[3],
                    supportShuft);

            }
            catch (FormatException ex)
            {
                ShowMessage(ex.Message);
                return;
            }
            catch (ArgumentException ex)
            {
                ShowMessage(ex.Message);
                return;
            }

        }

        /// <summary>
        /// Метод активации/деактивации кнопок формы
        /// </summary>
        /// <param name="openButton">Кнопка "Открыть компас"</param>
        /// <param name="closeButton">"Кнопка "Закрыть компас"</param>
        /// <param name="buildButton">"Кнопка "Построить"</param>
        private void FormButtons_enable(bool openButton, bool closeButton, bool buildButton)
        {
            OpenCompasButton.Enabled = openButton;
            CloseCompasButton.Enabled = closeButton;
            BuildButton.Enabled = buildButton;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message,
                "Предупреждение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Валидатор на ввод double 
        /// </summary>
        private void ValidateDoubleTextBoxs_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), @"[\d\b,]");
        }

        private void ExternalDiametrOutRim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
