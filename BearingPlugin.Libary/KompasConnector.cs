using System;
using Kompas6API5;

namespace BearingPlugin.Libary
{
    public class KompasConnector
    {
        private KompasObject _kompas;

        /// <summary>
        /// Запуск Компас 3D
        /// </summary>
        public void OpenKompas()
        {
            if (_kompas == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(type);
            }

            if (_kompas != null)
            {
                _kompas.Visible = true;
                _kompas.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Закрыть Компас 3D
        /// </summary>
        public void CloseKompas()
        {
            try
            {
                _kompas.Quit();
                _kompas = null;
            }
            catch
            {
                _kompas = null;
            }

        }

        public KompasObject Kompas
        {
            get { return _kompas; }
            set { _kompas = value; }
        }
    }
}

