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
        /// Внешний диаметр внешнего обода
        /// </summary>
        public double ExternalDiametrOutRim { get; private set; }

        /// <summary>
        /// Внешний диаметр внутреннего обода
        /// </summary>
        public double ExternalDiametrInRim { get; private set; }

        /// <summary>
        /// Внутренний диаметр внутренного обода
        /// </summary>
        public double InternalDiametrInRim { get; private set; }

        /// <summary>
        /// Опорный вал
        /// </summary>
        public bool SupportShuft { get; private set; }

        /// <summary>
        /// Ширина подшипника
        /// </summary>
        public double WidthBearing { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="externalDiametrOutRim">Внешний диаметр внешнего обода</param>
        /// <param name="externalDiametrInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="internalDiametrInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="supportShuft">Опорный вал</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        public BearingParametrs(double externalDiametrOutRim, 
            double externalDiametrInRim, 
            double internalDiametrInRim, 
             double widthBearing, bool supportShuft)
        {
            ExternalDiametrOutRim = externalDiametrOutRim;
            ExternalDiametrInRim = externalDiametrInRim;
            InternalDiametrInRim = internalDiametrInRim;
            WidthBearing = widthBearing;
            SupportShuft = supportShuft; ;

            ValueValidation();
            TypeValidation();
        }

        /// <summary>
        /// Валидация параметров по диапазону значения
        /// </summary>
        private void ValueValidation()
        {
            var errorMessage = new List<String>();

            if (ExternalDiametrOutRim < (ExternalDiametrInRim + 1.8) 
                || ExternalDiametrOutRim > 5)
            {
                errorMessage.Add("Внешний диаметр внешнего обода должен " +
                                 "быть больше внешнего диаметра внутреннего обода + 1.8 и меньше 5 см  ");
            }

            if (ExternalDiametrInRim < (InternalDiametrInRim + 0.2))
            {
                errorMessage.Add("Внешний диаметр внутреннего обода должен " +
                                 "быть больше чем внутренний диаметр внутреннего обода + 0.2 ");
            }

            if (InternalDiametrInRim >= (ExternalDiametrInRim / 2) || InternalDiametrInRim < 1)
            {
                errorMessage.Add("Внутренний диаметр внутреннего обода " +
                                 "должен быть больше 1 см и не больше " +
                                 "половины внешнего диаметра внутреннего обода");
            }

            if (WidthBearing < 1 || WidthBearing > 6)
            {
                errorMessage.Add("Толщина подшипника должна быть в диапазоне от 1 до 6 сантиметров");
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

            if (double.IsNaN(ExternalDiametrOutRim))
            {
                errorMessage.Add("Внешний диаметр внешнего обода должен быть числом\n"); 
            }
            if (double.IsNaN(ExternalDiametrInRim))
            {
                errorMessage.Add("Внешний диаметр внутреннего обода должен быть числом\n");
            }
            if (double.IsNaN(InternalDiametrInRim))
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
