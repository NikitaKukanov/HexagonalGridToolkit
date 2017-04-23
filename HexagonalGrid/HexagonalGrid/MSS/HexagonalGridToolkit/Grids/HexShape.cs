using System;

namespace MSS.HexagonalGridToolkit
{
    public class HexMap
    {
        private HexCoords[][] hexMap;
        private Func<int, int, Coords2> indexAccesser;

        public HexMap(HexCoords[][] _map, Func<int, int, Coords2> _indexAccesser)
        {
            hexMap = _map;
            indexAccesser = _indexAccesser;
        }

        // TODO: Why do we need this?
        public HexCoords GetCoords(int q, int r)
        {
            Coords2 indexes = indexAccesser(q, r);
            return hexMap[q][r];
        }
    }

    public class HexShape
    {
        private HexShapLoopParamsGetter outerLoop;
        private HexShapLoopParamsGetter innerLoop;

        public HexShape(HexShapLoopParamsGetter _outerLoopGetter,
                        HexShapLoopParamsGetter _innerLoopGetter)
        {
            outerLoop = _outerLoopGetter;
            innerLoop = _innerLoopGetter;
        }

        public HexMap GenerateHaxMap(int _mapSize)
        {
            return GenerateHaxMap(new Coords2(_mapSize, _mapSize));
        }

        public HexMap GenerateHaxMap(Coords2 _mapSize)
        {
            var outerParams = outerLoop.GetLoopParams(_mapSize.x);
            HexCoords[][] hexes = new HexCoords[outerParams.Length][];
            for (int q = outerParams.From; q <= outerParams.Max; q++) {
                var innerParams = innerLoop.GetLoopParams(_mapSize.y, q);
                int i = q - outerParams.From;
                hexes[i] = new HexCoords[innerParams.Length];
                for (int r = innerParams.From; r <= innerParams.Max; r++) {
                    hexes[i][r - innerParams.From] = new HexCoords(q, r); // same
                }
            }

            return new HexMap(hexes, (q, r) => {
                var innerParams = innerLoop.GetLoopParams(_mapSize.y, q); 
                return new Coords2(q, r - innerParams.From); // same
            });
        }
    }

    internal struct HexShapeLoopParams
    {
        public int From { get; private set; }
        public int Max { get; private set; }
        public int Length { get; private set; }

        public HexShapeLoopParams(int _from, int _max)
        {
            From = _from;
            Max = _max;
            Length = Max - From + 1;
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

        internal HexShapeLoopParams GetLoopParams(params int[] _params)
        {
            return new HexShapeLoopParams(fromGetter.Invoke(_params), maxGetter.Invoke(_params));
        }
    }

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
