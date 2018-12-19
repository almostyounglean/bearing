
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

        //Константы
        const int toMM = 10; //Для перевода пареметров в миллиметры
        const int origin = 0; //Начало координат
        const int widthHalf = 5; //Половина толщины выемки
        const double chamferDepth = 2.5; //Глубина выемки для шарика
        const int rimSpacing = 2; //Расстояние между двумя ободами
        const int ballDiametr = 10; //Диаметр шарика подшипника

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="kompas">Интерфейс API КОМПАС</param>
        public DetailBuilder(KompasObject kompas)
        {
            _kompas = kompas;
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
        /// Метод для выдавливания вращением осовного эскиза
        /// </summary>
        private ksEntity RotateSketch()
        {
            var entityRotated =
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseRotated);
            var entityRotatedDefinition =
                (ksBaseRotatedDefinition)entityRotated.GetDefinition();

            entityRotatedDefinition.directionType = 0;
            entityRotatedDefinition.SetSideParam(true, 360);
            entityRotatedDefinition.SetSketch(_entitySketch);
            entityRotated.Create();
            return entityRotated;
        }

        /// <summary> 
        /// Метод выдавливания эскиза
        /// </summary> 
        /// <returns>Ссылка на результат выдавливания 
        private ksEntity MakeExtrude(double depth)
        {
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            var entityExtrudeDefinition = (ksBaseExtrusionDefinition)entityExtrude.GetDefinition();
            entityExtrudeDefinition.SetSideParam(true, 0, depth, 0, true);
            entityExtrudeDefinition.SetSketch(_entitySketch);
            entityExtrude.Create();
            return entityExtrude;
        }

        /// <summary> 
        /// Круговое копирование 
        /// </summary> 
        /// <param name="part">Ссылка на объект</param> 
        /// <param name="count">Количество </param> 
        /// <param name="entityForExtrusion">Эскиз для операции</param> 
        /// <returns>Ссылка на эскиз.</returns> 
        public ksEntity CircularEntity(ksPart part, int count, object entityForExtrusion)
        {
            var entityArray = (ksEntity)part.NewEntity((short)Obj3dType.o3d_circularCopy);
            var circularCopy = (ksCircularCopyDefinition)entityArray.GetDefinition();
            var baseAxisOZ =
            (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_axisOZ);
            circularCopy.count1 = 1;
            circularCopy.SetAxis(baseAxisOZ);
            circularCopy.SetCopyParamAlongDir(count, 360 / count, false, false);
            var collection = (ksEntityCollection)circularCopy.GetOperationArray();
            collection.Clear();
            collection.Add(entityForExtrusion);
            entityArray.Create();
            return entityArray;
        }

        /// <summary>
        /// Эскиз опорного вала
        /// </summary>
        /// <param name="internalRadiusInRim">Внутренний радиус внутреннего обода</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        private void SupportShuftSketch(double internalRadiusInRim)
        {
            CreateSketch((short)Obj3dType.o3d_planeXOY);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksCircle(origin, origin, internalRadiusInRim, 1);
            _sketchDefinition.EndEdit();
            MakeExtrude(50);
        }

        /// <summary>
        /// Эскиз ролика
        /// </summary>
        /// <param name="externalRadiusInRim"></param>
        /// <param name="widthBearing"></param>
        private ksEntity RollSketch(double externalRadiusInRim, double widthBearing)
        {
             CreateSketch((short)Obj3dType.o3d_planeXOY);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksCircle(origin ,externalRadiusInRim + rimSpacing / 2 ,3.5, 1);
            _sketchDefinition.EndEdit();
            return MakeExtrude(widthBearing);
            
        }

        /// <summary>
        /// Эскиз шара
        /// </summary>
        /// <param name="externalRadiusInRim">Внешний радиус внутреннего обода</param>
        private ksEntity BallSketch(double externalRadiusInRim)
        {
            CreateSketch((short)Obj3dType.o3d_planeXOY);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksArcBy3Points(origin + widthHalf, externalRadiusInRim, origin, externalRadiusInRim+5.5f, origin-widthHalf, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg(origin + widthHalf, externalRadiusInRim, origin - widthHalf, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg(origin + widthHalf, externalRadiusInRim, origin - widthHalf, externalRadiusInRim, 3);
            _sketchDefinition.EndEdit();
            return RotateSketch();

        }

        /// <summary>
        /// Метод эскиз внутреннего обода для роликового подшипника
        /// </summary>
        /// <param name="externalRadiusOutRim">Внешний диаметр внешнего обода</param>
        /// <param name="externalRadiusInRim">Внешний диаметр внутреннего обода</param>
        /// <param name="internalRadiusInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        private void InRimSketchForRollBearing(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
        {
            CreateSketch((short)Obj3dType.o3d_planeYOZ);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksLineSeg
                (origin, internalRadiusInRim, origin - widthBearing , internalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin, internalRadiusInRim, origin, externalRadiusInRim - chamferDepth, 1);
            _sketchEdit.ksLineSeg
                (origin -  widthBearing , internalRadiusInRim, origin - widthBearing , externalRadiusInRim - chamferDepth, 1);
            _sketchEdit.ksLineSeg
                (origin - widthBearing, externalRadiusInRim - chamferDepth, origin, externalRadiusInRim - chamferDepth, 1);
            _sketchEdit.ksLineSeg
            (-20, origin, 20, origin, 3);
            _sketchDefinition.EndEdit();
            RotateSketch();
        }

        /// <summary>
        /// Эскиз внешнего обода для роликового подшипника
        /// </summary>
        /// <param name="externalRadiusOutRim">Внешний диаметр внешнего обода</param>
        /// <param name="externalRadiusInRim">Внешний диаметр внутреннего обода</param>
        /// <param name="internalRadiusInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        private void OutRimSketchForRollBearing(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
        {
            CreateSketch((short)Obj3dType.o3d_planeYOZ);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksLineSeg
                (origin - widthBearing , externalRadiusOutRim, origin, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthBearing, externalRadiusInRim + rimSpacing + chamferDepth, origin - widthBearing, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (origin, externalRadiusInRim + rimSpacing + chamferDepth, origin, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthBearing , externalRadiusInRim + rimSpacing + chamferDepth, origin, externalRadiusInRim + rimSpacing + chamferDepth, 1);
            _sketchEdit.ksLineSeg
               (-20, origin, 20, origin, 3);
            _sketchDefinition.EndEdit();
            RotateSketch();
        }
            /// <summary>
            ///  Эскиз внутреннего обода для шарикового подшипника
            /// </summary>
            /// <param name="externalRadiusOutRim">Внешний диаметр внешнего обода</param>
            /// <param name="externalRadiusInRim">Внешний диаметр внутреннего обода</param>
            /// <param name="internalRadiusInRim">Внутренний диаметр внутреннего обода</param>
            /// <param name="widthBearing">Ширина подшипника</param>
            private void InRimSketchForBallBearing(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
        {
            CreateSketch((short)Obj3dType.o3d_planeYOZ);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksLineSeg
                (origin - widthBearing / 2, internalRadiusInRim, origin + widthBearing / 2, internalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthBearing / 2, internalRadiusInRim, origin - widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin + widthBearing / 2, internalRadiusInRim, origin + widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin + widthHalf, externalRadiusInRim, origin + widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthHalf, externalRadiusInRim, origin - widthBearing / 2, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin + widthHalf, externalRadiusInRim - chamferDepth, origin + widthHalf, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthHalf, externalRadiusInRim - chamferDepth, origin - widthHalf, externalRadiusInRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthHalf, externalRadiusInRim - chamferDepth, origin + widthHalf, externalRadiusInRim - chamferDepth, 1);
            _sketchEdit.ksLineSeg
                (-20, origin, 20, origin, 3);
            _sketchDefinition.EndEdit();
            RotateSketch();
        }

        /// <summary>
        /// Эскиз внешнего обода для шарикового подшипника
        /// </summary>
        /// <param name="externalRadiusOutRim"></param>
        /// <param name="externalRadiusInRim"></param>
        /// <param name="internalRadiusInRim"></param>
        /// <param name="widthBearing"></param>
        private void OutRimSketchForBallBearing(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
        {
            CreateSketch((short)Obj3dType.o3d_planeYOZ);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            _sketchEdit.ksLineSeg
                (origin - widthBearing / 2, externalRadiusOutRim, origin + widthBearing / 2, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (origin - widthBearing / 2, externalRadiusInRim + rimSpacing, origin - widthBearing / 2, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (origin + widthBearing / 2, externalRadiusInRim + rimSpacing, origin + widthBearing / 2, externalRadiusOutRim, 1);
            _sketchEdit.ksLineSeg
                (origin + widthBearing / 2, externalRadiusInRim + rimSpacing, origin + widthHalf, externalRadiusInRim + 2, 1);
            _sketchEdit.ksLineSeg
                (origin - widthBearing / 2, externalRadiusInRim + rimSpacing, origin - widthHalf, externalRadiusInRim + 2, 1);
            _sketchEdit.ksLineSeg
               (origin - widthHalf, externalRadiusInRim + rimSpacing, origin - widthHalf, externalRadiusInRim + 5.5, 1);
            _sketchEdit.ksLineSeg
                (origin + widthHalf, externalRadiusInRim + rimSpacing, origin + widthHalf, externalRadiusInRim + 5.5, 1);
            _sketchEdit.ksLineSeg
                (origin + widthHalf, externalRadiusInRim + 5.5, origin - widthHalf, externalRadiusInRim + 5.5, 1);
            _sketchEdit.ksLineSeg
                (-20, origin, 20, origin, 3);
            _sketchDefinition.EndEdit();
            RotateSketch();
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

            var externalRadiusOutRim = parameters.ExternalRadiusOutRim * toMM;
            var externalRadiusInRim = parameters.ExternalRadiusInRim * toMM;
            var internalRadiusInRim = parameters.InternalRadiusInRim * toMM;
            var widthBearing = parameters.WidthBearing * toMM;
            var supportShuft = parameters.SupportShuft;
            var ballChecked = parameters.BallChecked;

            _doc3D = (ksDocument3D)_kompas.ActiveDocument3D();
            _part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);

            if (ballChecked == true)
            {
                InRimSketchForBallBearing(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);
                OutRimSketchForBallBearing(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);
                var ball = BallSketch(externalRadiusInRim);
                CircularEntity(_part, 5, ball);

                if (supportShuft == true)
                {
                    SupportShuftSketch(internalRadiusInRim);
                }
            }
            else
            {
               
                    InRimSketchForRollBearing(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);
                    OutRimSketchForRollBearing(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);
                    var roll = RollSketch(externalRadiusInRim,widthBearing);
                    CircularEntity(_part, 7, roll);

                    if (supportShuft == true)
                    {
                        SupportShuftSketch(internalRadiusInRim);
                    }
                
            }
        }

    }

}
