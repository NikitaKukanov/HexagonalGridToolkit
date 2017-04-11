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

        public HexGeometryParams(HexOrientation _orientation, float _size)
        {
            Orientation = _orientation;
            Size = _size;
            switch (_orientation) {
                case HexOrientation.PointyTopped:
                    break;
                case HexOrientation.FlatTopped:
                    break;
                default:
                    break;
            }
        }
    }
}
