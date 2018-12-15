using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearingPlugin.UI;
using Kompas6API5;
using Kompas6Constants3D;

namespace BearingPlugin.Libary
{
    /// <summary>
    /// Класс построения детали
    /// </summary>
   public class DetailBuilder
    {
        private KompasObject _kompas;

        private ksDocument3D _doc3D;

        private ksPart _part;

        private ksEntity _entitySketch;

        private ksSketchDefinition _sketchDefinition;

        private ksDocument2D _sketchEdit;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="kompas">Интерфейс API КОМПАС</param>
        public DetailBuilder(KompasObject kompas)
        {
            _kompas = kompas;
        }

        /// <summary>
        /// Построение детали
        /// </summary>
        /// <param name="parameters">Параметры подшипника</param>
        public void CreateDetail(BearingParametrs parameters)
        {
            if (_kompas != null)
            {
                _doc3D = (ksDocument3D)_kompas.Document3D();
                _doc3D.Create(false, true);
            }

            var externalRadiusOutRim = parameters.ExternalRadiusOutRim * 10;
            var externalRadiusInRim = parameters.ExternalRadiusInRim * 10;
            var internalRadiusInRim = parameters.InternalRadiusInRim * 10;
            var widthBearing = parameters.WidthBearing * 10;
            var supportShuft = parameters.SupportShuft;

            _doc3D = (ksDocument3D)_kompas.ActiveDocument3D();
            _part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);

            RimSketch(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);

        }

        /// <summary>
        /// Метод, создающий эскиз
        /// </summary>
        /// <param name="plane">Плоскость, эскиз которой будет создан</param>
        private void CreateSketch(short plane)
        {
            var currentPlane = (ksEntity)_part.GetDefaultEntity(plane);

            _entitySketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_entitySketch.GetDefinition();
            _sketchDefinition.SetPlane(currentPlane);
            _entitySketch.Create();
        }

        /// <summary>
        /// Метод эскиза внутреннего и внешнего ободов
        /// </summary>
        /// <param name="externalRadiusOutRim">Внешний диаметр внешнего обода</param>
        /// <param name="externalRadiusInRim">Внешний диаметр внутреннего обода</param>
        /// <param name="internalRadiusInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        private void RimSketch(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
        {
            CreateSketch((short)Obj3dType.o3d_planeYOZ);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();

            //Внутренний обод
            _sketchEdit.ksLineSeg
                (0 - widthBearing / 2, internalRadiusInRim, 0 + widthBearing / 2, internalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 - widthBearing / 2, internalRadiusInRim, 0 - widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 + widthBearing / 2, internalRadiusInRim, 0 + widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 + 5, externalRadiusInRim, 0 + widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 - 5, externalRadiusInRim, 0 - widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 + 5, externalRadiusInRim - 1.5, 0 + 5, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 - 5, externalRadiusInRim - 1.5, 0 - 5, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (0 - 5, externalRadiusInRim - 1.5, 0 + 5, externalRadiusInRim - 1.5, 1);

            //Внешний обод
            _sketchEdit.ksLineSeg
                (0 - widthBearing / 2, externalRadiusOutRim, 0 + widthBearing / 2, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (0 - widthBearing / 2, externalRadiusInRim + 2, 0 - widthBearing / 2, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (0 + widthBearing / 2, externalRadiusInRim + 2, 0 + widthBearing / 2, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (0 + widthBearing / 2, externalRadiusInRim + 2, 0 + 5, externalRadiusInRim + 2, 1);
            _sketchEdit.ksLineSeg
                (0 - widthBearing / 2, externalRadiusInRim + 2, 0 - 5, externalRadiusInRim + 2, 1);
            _sketchEdit.ksLineSeg
               ( 0 - 5, externalRadiusInRim + 2, 0 - 5, externalRadiusInRim + 3.5, 1);
            _sketchEdit.ksLineSeg
                (0 + 5, externalRadiusInRim + 2, 0 + 5, externalRadiusInRim + 3.5, 1);
            _sketchEdit.ksLineSeg
                (0 + 5, externalRadiusInRim + 3.5, 0 - 5, externalRadiusInRim + 3.5, 1);
            _sketchDefinition.EndEdit();

        }

    }

}
