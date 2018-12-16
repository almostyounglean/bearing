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
                BuildButton_enable(true);
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            var errorMsg = string.Empty;
            var dict = new Dictionary<TextBox, string>
            {
                {ExternalDiametrOutRim, "Некорректный внешний радиус внешнего обода\n "},
                {ExternalDiametrInRim, "Некорректный внешний радиус внутреннего обода\n "},
                {InternalDiametrInRim, "Некорректный внутренний радиус внутреннего обода\n "},
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

            var supportShuft = SupportShuft.Checked;
           

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
                _connector.OpenKompas();
                var builder = new DetailBuilder(_connector.Kompas);
                builder.CreateDetail(parameters);
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
        /// <param name="buildButton">"Кнопка "Построить"</param>
        private void BuildButton_enable( bool buildButton)
        {
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
    }
}
