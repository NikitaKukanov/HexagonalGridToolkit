using System;
namespace MSS.HexagonalGridToolkit
{
    public class HexShape
    {
        private delegate HexCoords[] ShapeForm(Coords2 hexMapSize);
        private ShapeForm shapeFormingFunc;

        private HexShape(ShapeForm _shapeFormingFunc)
        {
            shapeFormingFunc = _shapeFormingFunc;
        }

        public HexCoords[] GenerateHaxMap(int _mapSize)
        {
            return GenerateHaxMap(new Coords2(_mapSize, _mapSize));
        }

        public HexCoords[] GenerateHaxMap(Coords2 _mapSize)
        {
            return shapeFormingFunc.Invoke(_mapSize);
        }

        #region Shapes

        public static HexShape Single = new HexShape(new ShapeForm(
            (size) => {
                return new HexCoords[] { new HexCoords(0, 0) };
            }));

        public static HexShape Triangle1 = new HexShape(new ShapeForm(
            (size) => {
                HexCoords[] hexes = new HexCoords[HexMath.CalcNumElementsInTriangle(size.x)];
                int l = 0;
                for (int q = 0; q <= size.x; q++) {
                    for (int r = 0; r <= size.x - q; r++) {
                        hexes[l++] = new HexCoords(q, r);
                    }
                }
                return hexes;
            }));

        public static HexShape Triangle2 = new HexShape(new ShapeForm(
            (size) => {
                HexCoords[] hexes = new HexCoords[HexMath.CalcNumElementsInTriangle(size.x)];
                int l = 0;
                for (int q = 0; q <= size.x; q++) {
                    for (int r = size.x - q; r <= size.x; r++) {
                        hexes[l++] = new HexCoords(q, r);
                    }
                }
                return hexes;
            }));

        public static HexShape Parallelogram = new HexShape(new ShapeForm(
            (size) => {
                HexCoords[] hexes = new HexCoords[size.x * size.y];
                int l = 0;
                for (int q = 0; q <= size.x; q++) {
                    for (int r = 0; r <= size.y; r++) {
                        hexes[l++] = new HexCoords(q, r);
                    }
                }
                return hexes;
            }));

        public static HexShape Hexagon = new HexShape(new ShapeForm(
            (size) => {
                HexCoords[] hexes = new HexCoords[HexMath.CalcNumElementsInHexagon(size.x)];
                int l = 0;
                for (int q = -size.x; q <= size.x; q++) {
                    for (int r = Math.Max(-size.x, -q - size.x); r <= Math.Min(size.x, -q + size.x); r++) {
                        hexes[l++] = new HexCoords(q, r);
                    }
                }
                return hexes;
            }));

        public static HexShape Rectangle = new HexShape(new ShapeForm(
            (size) => {
                HexCoords[] hexes = new HexCoords[size.x * size.y];
                int l = 0;
                for (int r = 0; r <= size.y; r++) {
                    int r_offset = (int)Math.Floor(r / 2.0);
                    for (int q = -r_offset; q < size.x - r_offset; q++) { 
                        hexes[l++] = new HexCoords(q, r);
                    }
                }
                return hexes;
            }));

        #endregion

    } 
}
