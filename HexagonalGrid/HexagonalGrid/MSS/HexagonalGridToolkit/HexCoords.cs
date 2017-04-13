using System;
using System.Diagnostics;

namespace MSS.HexagonalGridToolkit
{
    public struct HexCoords
    {
        public int q { get; private set; }
        public int r { get; private set; }
        public int s { get { return -q - s; } }
        public static HexCoords[] Neighbors { get; private set; }
        
        public HexCoords(int _q, int _r)
        {
            q = _q;
            r = _r;
            Debug.Assert(q + r + s == 0);

            Neighbors = new HexCoords[] {
                this+new HexCoords(1, 0),
                this+new HexCoords(1, -1),
                this+new HexCoords(0, -1),
                this+new HexCoords(-1, 0),
                this+new HexCoords(-1, 1),
                this+new HexCoords(0, 1),
            };
        }

        public static int Distance(HexCoords a, HexCoords b)
        {
            return (Math.Abs(a.q - b.q) + Math.Abs(a.r - b.r) + Math.Abs(a.s - b.s)) / 2;
        }

        #region Operators

        public static bool operator == (HexCoords a, HexCoords b)
        {
            return a.q == b.q && a.r == b.r && a.s == b.s;
        }

        public static bool operator != (HexCoords a, HexCoords b)
        {
            return !(a == b);
        }

        public static HexCoords operator + (HexCoords a, HexCoords b)
        {
            return new HexCoords(a.q + b.q, a.r + b.r);
        }

        public static HexCoords operator - (HexCoords a, HexCoords b)
        {
            return new HexCoords(a.q - b.q, a.r - b.r);
        }

        public static HexCoords operator * (HexCoords a, int k)
        {
            return new HexCoords(a.q * k, a.r * k);
        }

        #endregion
    }

    public struct HexGeometryParams
    {
        public float Size { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public float HorizontalDistance { get; private set; }
        public float VerticalDistance { get; private set; }
        public HexOrientation Orientation { get; private set; }
        public Point2[] Corners { get; private set; }

        public HexGeometryParams(HexOrientation _orientation, float _size)
        {
            Orientation = _orientation;
            Size = _size;

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

            Corners = new Point2[6];
            for (int i = 0; i < Corners.Length; i++) {
                var angle_deg = 60 * i;
                var angle_rad = Math.PI / 180 * angle_deg;
                Corners[i] = new Point2(Size * (float)Math.Cos(angle_rad), Size * (float)Math.Sin(angle_rad));
            }
        }
    }
}
