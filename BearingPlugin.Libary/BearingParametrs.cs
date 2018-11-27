using System;
using System.Collections.Generic;
using System.Text;

namespace BearingPlugin.UI
{
    class BearingParametrs
    {
        private double _externalDiametrOutRim;
        private double _externalDiametrInRim;
        private double _internalDiametrInRim;
        private bool _supportShuft;
        private double _widthBearing;


        public double ExternalDiametrOutRim
        {
            get { return _externalDiametrOutRim; }

            private set { _externalDiametrOutRim = value; }
        }

        public double ExternalDiametrInRim
        {
            get { return _externalDiametrInRim; }

            private set { _externalDiametrInRim = value; }
        }

        public double InternalDiametrInRim
        {
            get { return _internalDiametrInRim; }

            private set { _internalDiametrInRim = value; }
        }

        public bool SupportShuft
        {
            get { return _supportShuft; }

            private set { _supportShuft = value; }
        }

        public double WidthBearing
        {
            get { return _widthBearing; }

            private set { _widthBearing = value; }
        }

        public BearingParametrs(double externalDiametrOutRim, 
            double externalDiametrInRim, 
            double internalDiametrInRim, 
            bool supportShuft, double widthBearing)
        {
            //TODO: Валидация по границам типа
            ExternalDiametrOutRim = externalDiametrOutRim;
            ExternalDiametrInRim = externalDiametrInRim;
            InternalDiametrInRim = internalDiametrInRim;
            SupportShuft = supportShuft;
            WidthBearing = widthBearing;

            Validation();

        }

        private void Validation()
        {
            //TODO: Список?
            var errorMessage = new List<String>();

            if (ExternalDiametrOutRim < (ExternalDiametrInRim + 1.8) 
                || ExternalDiametrOutRim > 2)
            {
                errorMessage.Add("Внешний диаметр внешнего обода должен быть больше внешнего диаметра внутреннего обода + 1.8 и меньше 2 см  ");
            }

            if (ExternalDiametrInRim > (InternalDiametrInRim + 0.2))
            {
                errorMessage.Add("Внешний диаметр внешнего обода должен быть больше чем внутренний диаметр внутреннего обода + 0.2 ");
            }

            if (InternalDiametrInRim >= (ExternalDiametrOutRim / 2) || InternalDiametrInRim < 1)
            {
                errorMessage.Add("Внутренний диаметр внутреннего обода должен быть больше 1 см и не больше половины внешнего диаметра внутреннего обода");
            }

            if (WidthBearing < 1)
            {
                errorMessage.Add("Толщина подшипника должна быть больше 1 см");
            }

            if (errorMessage.Count > 0)
            {
                throw new ArgumentException(errorMessage.ToString());
            }
        }
    }
}
