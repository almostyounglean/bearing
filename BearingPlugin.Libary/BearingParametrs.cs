using System;
using System.Collections.Generic;
using System.Text;

namespace BearingPlugin.UI
{
    /// <summary>
    /// Класс с параметрами подшипника
    /// </summary>
    public class BearingParametrs
    {
        /// <summary>
        /// Внешний радиус внешнего обода
        /// </summary>
        public double ExternalRadiusOutRim { get; private set; }

        /// <summary>
        /// Внешний радиус внутреннего обода
        /// </summary>
        public double ExternalRadiusInRim { get; private set; }

        /// <summary>
        /// Внутренний радиус внутренного обода
        /// </summary>
        public double InternalRadiusInRim { get; private set; }

        /// <summary>
        /// Опорный вал
        /// </summary>
        public bool SupportShuft { get; private set; }

        /// <summary>
        /// Ширина подшипника
        /// </summary>
        public double WidthBearing { get; private set; }

        /// <summary>
        /// Построение шарикового подшипника
        /// </summary>
        public bool BallChecked { get; private set; }

    

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="externalRadiusOutRim">Внешний диаметр внешнего обода</param>
        /// <param name="externalRadiusInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="internalRadiusInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="supportShuft">Опорный вал</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        /// <param name="BallChecked">Шариковый тип подшипника</param>
        public BearingParametrs(double externalRadiusOutRim, 
            double externalRadiusInRim, 
            double internalRadiusInRim, 
             double widthBearing, bool supportShuft, bool ballChecked)
        {
            ExternalRadiusOutRim = externalRadiusOutRim;
            ExternalRadiusInRim = externalRadiusInRim;
            InternalRadiusInRim = internalRadiusInRim;
            WidthBearing = widthBearing;
            SupportShuft = supportShuft;
            BallChecked = ballChecked;


            ValueValidation();
            TypeValidation();
        }

        /// <summary>
        /// Валидация параметров по диапазону значения
        /// </summary>
        private void ValueValidation()
        {
            var errorMessage = new List<String>();

            if (ExternalRadiusOutRim < (ExternalRadiusInRim + 1) 
                || ExternalRadiusOutRim > 5)
            {
                errorMessage.Add("Внешний радиус внешнего обода должен " +
                                 "быть больше внешнего радиуса внутреннего обода + 1 и меньше 5 см  ");
            }

            if (ExternalRadiusInRim < (InternalRadiusInRim + 0.2))
            {
                errorMessage.Add("Внешний радиус внутреннего обода должен " +
                                 "быть больше чем внутренний радиус внутреннего обода + 0.2 ");
            }

            if (InternalRadiusInRim >= (ExternalRadiusInRim / 2) || InternalRadiusInRim < 0.5)
            {
                errorMessage.Add("Внутренний радиус внутреннего обода " +
                                 "должен быть больше 0.5 см и не больше " +
                                 "половины внешнего радиуса внутреннего обода");
            }

            if (WidthBearing < 1.5 || WidthBearing > 3)
            {
                errorMessage.Add("Толщина подшипника должна быть в диапазоне от 1,5 до 3 сантиметров");
            }

            if (errorMessage.Count > 0)
            {
                throw new ArgumentException(string.Join("\n", errorMessage));
            }
        }

        /// <summary>
        /// Валидация параметров по типу данных
        /// </summary>
        private void TypeValidation()
        {
            var errorMessage = new List<String>();

            if (double.IsNaN(ExternalRadiusOutRim))
            {
                errorMessage.Add("Внешний диаметр внешнего обода должен быть числом\n"); 
            }
            if (double.IsNaN(ExternalRadiusInRim))
            {
                errorMessage.Add("Внешний диаметр внутреннего обода должен быть числом\n");
            }
            if (double.IsNaN(InternalRadiusInRim))
            {
                errorMessage.Add("Внутренний диаметр внутреннего обода должен быть числом\n");
            }
            if (double.IsNaN(WidthBearing))
            {
                errorMessage.Add("Ширина подшипника должна быть числом");
            }

            if (errorMessage.Count > 0)
            {
                throw new ArgumentException(string.Join("\n", errorMessage));
            }
        }

    }
}
