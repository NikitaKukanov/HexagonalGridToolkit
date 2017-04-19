using System;

namespace MSS.HexagonalGridToolkit
{
    public class HexLayout
    {
        #region Properties
        public HexOrientation Orientation { get; private set; }
        public float Size { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float VerticalDistance { get; private set; }
        public float HorizontalDistance { get; private set; }
        public Point2[] CornersLocalPositions { get; private set; }
        #endregion

        #region Orientations
        public static readonly HexOrientation PointyOrientation = new HexOrientation() {
            ConvertionMatrix = new Matrix(new float[,] {
                { (float)Math.Sqrt(3), (float)Math.Sqrt(3)/2.0f },
                { 0.0f, 3.0f/2.0f } }),
            ConvertionInverseMatrix = new Matrix(new float[,] {
                { (float)Math.Sqrt(3)/3.0f, -1.0f/3.0f},
                { 0.0f, 2.0f/3.0f} }),
            StartAngle = 30.0f,
            HeightCalc = 1.0f,
            WidthCalc = (float)Math.Sqrt(3) / 2.0f,
            HorizontalDistCalc = 1.0f,
            VerticalDistCalc = 3.0f / 4.0f
        };
        public static readonly HexOrientation FlatOrientation = new HexOrientation() {
            ConvertionMatrix = new Matrix(new float[,] {
                { 3.0f/2.0f, 0 },
                { (float)Math.Sqrt(3)/2.0f, (float)Math.Sqrt(3) } }),
            ConvertionInverseMatrix = new Matrix(new float[,] {
                { 2.0f/3.0f, 0.0f },
                { -1.0f/3.0f, (float)Math.Sqrt(3)/3.0f } }),
            StartAngle = 0.0f,
            HeightCalc = (float)Math.Sqrt(3) / 2.0f,
            WidthCalc = 1.0f,
            HorizontalDistCalc = 3.0f / 4.0f,
            VerticalDistCalc = 1.0f
        };
        #endregion

        public HexLayout(float _hexSize, HexOrientation _orientation)
        {
            Size = _hexSize;
            Orientation = _orientation;
            Width = Orientation.WidthCalc * Size * 2;
            Height = Orientation.HeightCalc * Size * 2;
            HorizontalDistance = Width * Orientation.WidthCalc;
            VerticalDistance = Height * Orientation.HeightCalc;
            CornersLocalPositions = CalculateCorners();
        } 

        public Point2 ConvertHexCoordsToWorldPosition(HexCoords _coords)
        {
            Matrix resultMatrixOfSize2 = 
                this.Size * 
                this.Orientation.ConvertionMatrix * 
                new Matrix(new float[,] { { _coords.q }, { _coords.r } });

            return new Point2(resultMatrixOfSize2[0, 0], resultMatrixOfSize2[0, 1]);
        }

        public HexCoords ConvertWorldPositionToHexCoords(Point2 _worldPosition)
        {
            Matrix resultMatrixOfSize2 =                
                this.Orientation.ConvertionInverseMatrix *
                new Matrix(new float[,] { { _worldPosition.x }, { _worldPosition.y } }) /
                this.Size;

            return new HexCoords(resultMatrixOfSize2[0, 0], resultMatrixOfSize2[0, 1]);
        }

        private Point2[] CalculateCorners()
        {
            Point2[] corners = new Point2[6];
            for (int i = 0; i < corners.Length; i++) {
                float angleDeg = Orientation.StartAngle - i * 360.0f / corners.Length;
                float angleRadian = (float)Math.PI / 180.0f * angleDeg;                
                Point2 pos = new Point2(Size * (float)Math.Cos(angleRadian), Size * (float)Math.Sin(angleRadian));
                corners[i] = pos;
            }
            return corners;
        }
    }

    public struct HexOrientation
    {
        public Matrix ConvertionMatrix;
        public Matrix ConvertionInverseMatrix;
        public float StartAngle; // used for corners calculation
        public float WidthCalc;
        public float HeightCalc;
        public float HorizontalDistCalc;
        public float VerticalDistCalc;
    }
}
