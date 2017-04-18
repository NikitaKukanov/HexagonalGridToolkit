using System;

namespace MSS.HexagonalGridToolkit
{
    public enum HexOrientation
    {
        PointyTopped = 0,
        FlatTopped = 1
    }

    public class HexGeometry
    {
        public HexOrientation Orientation { get; private set; }
        public HexCoords Position { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float Size { get; private set; }
        public float VerticalDistance { get; private set; }
        public float HorizontalDistance { get; private set; }
        public Point2[] CornersWorldPositions { get; private set; }

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
            CornersWorldPositions = new Point2[6];
            for (int i = 0; i < CornersWorldPositions.Length; i++) {
                var angle_deg = 60 * i; // TODO: orientation!!!
                var angle_rad = Math.PI / 180 * angle_deg;
                CornersWorldPositions[i] = new Point2(Size * (float)Math.Cos(angle_rad), Size * (float)Math.Sin(angle_rad));
            }
        }

        private void CalculateMeasures()
        {
            float[] hparams = new float[2];
            float[] hdists = new float[2];
            hparams[0] = Size * 2;            
            hparams[1] = (float)Math.Sqrt(3) / 2 * hparams[0];
            hdists[0] = hparams[0] * 3 / 4;
            hdists[1] = hparams[0];

            Height = hparams[(int)Orientation];
            VerticalDistance = hdists[(int)Orientation];
            Width = hparams[1-(int)Orientation]; 
            HorizontalDistance = hdists[1-(int)Orientation];
        }
    }
}
