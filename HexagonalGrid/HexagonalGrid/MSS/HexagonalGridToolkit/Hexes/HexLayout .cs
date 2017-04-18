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

        //const Orientation layout_pointy
        // = Orientation(sqrt(3.0), sqrt(3.0) / 2.0, 
        //               0.0,       3.0 / 2.0,
        //
        //               sqrt(3.0) / 3.0, -1.0 / 3.0, 
        //               0.0,              2.0 / 3.0,
        //  0.5);
        //const Orientation layout_flat
        //  = Orientation(3.0 / 2.0,       0.0, 
        //                sqrt(3.0) / 2.0, sqrt(3.0),
        //
        //                2.0 / 3.0, 0.0, 
        //                -1.0 / 3.0, sqrt(3.0) / 3.0,
        //  0.0);

        private Matrix[] convertionMatrices = {
            // Pointy
            new Matrix(new float[,] {
                { (float)Math.Sqrt(3), (float)Math.Sqrt(3)/2.0f },
                { 0, 3.0f/2.0f } }),
            // Flat
            new Matrix(new float[,] {
                { 3.0f/2.0f, 0 },
                { (float)Math.Sqrt(3)/2.0f, (float)Math.Sqrt(3) } }),            
        };
        

        //public Point2 ConvertWorldToHex(HexCoords _hex)
        //{
        //
        //}

        //public HexCoords ConvertHexToWorld(Point2 _world)
        //{
        //
        //}

        private void CalculateCorners()
        {
            //CornersLocalPositions = new Point2[6];
            //for (int i = 0; i < CornersLocalPositions.Length; i++) {
            //    var angle_deg = 60 * i;
            //    if (Orientation == HexOrientation.PointyTopped) {
            //        angle_deg += 30;
            //    }
            //    var angle_rad = Math.PI / 180 * angle_deg;
            //    CornersLocalPositions[i] = new Point2(Size * (float)Math.Cos(angle_rad), Size * (float)Math.Sin(angle_rad));
            //}
            //cornersCalculated = true;
        }

        private void CalculateMeasures()
        {
            //float[] hparams = new float[2];
            //float[] hdists = new float[2];
            //hparams[0] = Size * 2;            
            //hparams[1] = (float)Math.Sqrt(3) / 2 * hparams[0];
            //hdists[0] = hparams[0] * 3 / 4;
            //hdists[1] = hparams[0];

            //Height = hparams[(int)Orientation];
            //VerticalDistance = hdists[(int)Orientation];
            //Width = hparams[1-(int)Orientation]; 
            //HorizontalDistance = hdists[1-(int)Orientation];

            //measuresCalculated = true;
        }
    }

    public struct HexOrientation
    {
        public Matrix ConvertionMatrix { get; private set; }
        public Matrix ConvertionInverseMatrix { get; private set; }
        public float StartAngle { get; private set; }
        public float WidthCalc { get; private set; }
        public float HeightCalc { get; private set; }
        public float HorizontalDistCalc { get; private set; }
        public float VerticalDistCalc { get; private set; }
    }
}
