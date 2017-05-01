using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MSS.HexagonalGridToolkit
{
    public struct HexCoords
    {
        public int q { get; private set; }
        public int r { get; private set; }
        public int s { get { return -q - r; } }

        private static HexCoords[] s_neighborsCoords = {
            new HexCoords(1, 0),
            new HexCoords(1, -1),
            new HexCoords(0, -1),
            new HexCoords(-1, 0),
            new HexCoords(-1, 1),
            new HexCoords(0, 1)
        };

        public HexCoords(int _q, int _r)
        {
            q = _q;
            r = _r;
            Debug.Assert(q + r + s == 0);
        }

        public HexCoords(float f_q, float f_r, float f_s)
        {           
            q = (int)(Math.Round(f_q));
            r = (int)(Math.Round(f_r));
            int i_s = (int)(Math.Round(f_s));
            double q_diff = Math.Abs(q - f_q);
            double r_diff = Math.Abs(r - f_r);
            double s_diff = Math.Abs(i_s - f_s);
            if (q_diff > r_diff && q_diff > s_diff) {
                q = -r - i_s;
            } else if (r_diff > s_diff) {
                r = -q - i_s;
            }
            Debug.Assert(q + r + s == 0);
        }

        public HexCoords(float f_q, float f_r) : this(f_q, f_r, -f_q - f_r) { }

        public IEnumerator<HexCoords> Neighbors()
        {
            for (int i = 0; i < s_neighborsCoords.Length; i++) {
                yield return this + s_neighborsCoords[i];
            }
        }

        #region Static

        public HexCoords[] GetLineOfHexCoords(HexCoords _from, HexCoords _to)
        {
            int distance = HexCoords.Distance(_from, _to);
            if (distance <= 2) {
                return new HexCoords[] { _from, _to };
            }
            HexCoords[] lineOfHexes = new HexCoords[distance];
            float step = 1.0f / distance;
            for (int i = 0; i < distance; i++) {
                lineOfHexes[i] = HexCoords.Lerp(_from, _to, i * step);
            }
            return lineOfHexes;
        }

        public static HexCoords Lerp(HexCoords a, HexCoords b, float t)
        {
            return new HexCoords(
                a.q * (1 - t) + b.q * t, 
                a.r * (1 - t) + b.r * t, 
                a.s * (1 - t) + b.s * t);
        }

        public static int Distance(HexCoords a, HexCoords b)
        {
            return (Math.Abs(a.q - b.q) + Math.Abs(a.r - b.r) + Math.Abs(a.s - b.s)) / 2;
        }

        #endregion

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
}
