using System;

namespace MSS.HexagonalGridToolkit
{
    public class HexShape
    {
        public int MaxItems { get; private set; }
        HexShapLoopParamsGetter outerLoop;
        HexShapLoopParamsGetter innerLoop;

        public HexCoords[][] GenerateHex(int _sizeOuter, int _sizeInner)
        {
            var outerParams = outerLoop.GetLoopParams(_sizeOuter);
            HexCoords[][] hexes = new HexCoords[outerParams.Size][];
            for (int q = outerParams.From; q <= outerParams.Max; q++) {
                var innerParams = innerLoop.GetLoopParams(_sizeInner, q);
                int i = q - outerParams.From;
                hexes[i] = new HexCoords[innerParams.Size];
                for (int r = innerParams.From; r <= innerParams.Max; r++) {
                    hexes[i][r-innerParams.From] = new HexCoords(q, r);
                }
            }
            return hexes;
        }

        public struct HexShapeLoopParams
        {
            public int From { get; private set; }
            public int Max { get; private set; }
            public int Size { get; private set; }

            public HexShapeLoopParams(int _from, int _max)
            {
                From = _from;
                Max = _max;
                Size = Max - From + 1;
            }
        }

        public class HexShapLoopParamsGetter
        {
            private Func<int[], int> fromGetter;
            private Func<int[], int> maxGetter;

            public HexShapLoopParamsGetter(Func<int[], int> _fromGetter, Func<int[], int> _maxGetter)
            {
                fromGetter = _fromGetter;
                maxGetter = _maxGetter;
            }

            public HexShapeLoopParams GetLoopParams(params int[] _params)
            {
                return new HexShapeLoopParams(fromGetter.Invoke(_params), maxGetter.Invoke(_params));
            }
        }

        //public virtual HexCoords GetHexCoordsFromOnedimentionalIndex(int _index)
        //{
        //    return new HexCoords();
        //}

        //public virtual int GetOnedimensionalHexIndex(int q, int r)
        //{
        //    return 0;
        //}

        // Parallelograms
        //unordered_set<Hex> map;
        //for (int q = q1; q <= q2; q++) {
        //    for (int r = r1; r <= r2; r++) {
        //        map.insert(Hex(q, r, -q-r)));
        //    }
        //}

        // Triangles #1
        //unordered_set<Hex> map;
        //for (int q = 0; q <= map_size; q++) {
        //    for (int r = 0; r <= map_size - q; r++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}

        // Triangles #2
        //unordered_set<Hex> map;
        //for (int q = 0; q <= map_size; q++) {
        //    for (int r = map_size - q; r <= map_size; r++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}

        // Hexagon
        //unordered_set<Hex> map;
        //for (int q = -map_radius; q <= map_radius; q++) {
        //    for (int r = max(-map_radius, -q - map_radius); r <= min(map_radius, -q + map_radius); r++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}

        // Ractangle
        //unordered_set<Hex> map;
        //for (int r = 0; r<map_height; r++) {
        //    int r_offset = floor(r / 2); // or r>>1
        //    for (int q = -r_offset; q<map_width - r_offset; q++) {
        //        map.insert(Hex(q, r, -q-r));
        //    }
        //}
    }
}
