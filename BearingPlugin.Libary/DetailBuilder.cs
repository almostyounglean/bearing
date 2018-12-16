
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
        const int widthHalf = 5; //Половина толщины подшипника
        const double chamferDepth = 1.5; //Глубина выемки для шарика
        const int rimSpacing = 2; //Расстояние между двумя ободами

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

            var externalRadiusOutRim = parameters.ExternalRadiusOutRim * toMM;
            var externalRadiusInRim = parameters.ExternalRadiusInRim * toMM;
            var internalRadiusInRim = parameters.InternalRadiusInRim * toMM;
            var widthBearing = parameters.WidthBearing * toMM;
            var supportShuft = parameters.SupportShuft;

            _doc3D = (ksDocument3D)_kompas.ActiveDocument3D();
            _part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);

        
            InRimSketch(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);
            OutRimSketch(externalRadiusOutRim, externalRadiusInRim, internalRadiusInRim, widthBearing);

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
        /// Метод эскиз внутреннего обода
        /// </summary>
        /// <param name="externalRadiusOutRim">Внешний диаметр внешнего обода</param>
        /// <param name="externalRadiusInRim">Внешний диаметр внутреннего обода</param>
        /// <param name="internalRadiusInRim">Внутренний диаметр внутреннего обода</param>
        /// <param name="widthBearing">Ширина подшипника</param>
        private void InRimSketch(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
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
        /// Эскиз внешнего обода
        /// </summary>
        /// <param name="externalRadiusOutRim"></param>
        /// <param name="externalRadiusInRim"></param>
        /// <param name="internalRadiusInRim"></param>
        /// <param name="widthBearing"></param>
        private void OutRimSketch(double externalRadiusOutRim, double externalRadiusInRim, double internalRadiusInRim, double widthBearing)
        {
            CreateSketch((short)Obj3dType.o3d_planeYOZ);
            _sketchEdit = (ksDocument2D)_sketchDefinition.BeginEdit();
            //Внешний обод
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
               ( origin - widthHalf, externalRadiusInRim + rimSpacing, origin - widthHalf, externalRadiusInRim + 3.5, 1);
            _sketchEdit.ksLineSeg
                (origin + widthHalf, externalRadiusInRim + rimSpacing, origin + widthHalf, externalRadiusInRim + 3.5, 1);
            _sketchEdit.ksLineSeg
                (origin + widthHalf, externalRadiusInRim + 3.5, origin - widthHalf, externalRadiusInRim + 3.5, 1);
            _sketchEdit.ksLineSeg
                (-20, origin, 20, origin, 3);
            _sketchDefinition.EndEdit();
            RotateSketch();
        }

        /// <summary>
        /// Метод для выдавливания вращением осовного эскиза
        /// </summary>
        private void RotateSketch()
        {
            var entityRotated =
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseRotated);
            var entityRotatedDefinition =
                (ksBaseRotatedDefinition)entityRotated.GetDefinition();

            entityRotatedDefinition.directionType = 0;
            entityRotatedDefinition.SetSideParam(true, 360);
            entityRotatedDefinition.SetSketch(_entitySketch);
            entityRotated.Create();
        }

    }

}
