namespace MSS.HexagonalGridToolkit
{
    public class HexGrid
    {
        private HexLayout layout;
        private HexShape shape;
        private HexCoords[] hexMap;

        public HexGrid(HexLayout _layout, HexShape _shape, Coords2 _size)
        {
            layout = _layout;
            shape = _shape;

            hexMap = shape.GenerateHaxMap(_size);
        }

        public Point2[] GetHexCornersLocalPositions()
        {
            return layout.CornersLocalPositions;
        }

        public Point2[] GetHexesPositions()
        {
            Point2[] positions = new Point2[hexMap.Length];
            for (int i = 0; i <hexMap.Length; i++) {
                positions[i] = layout.ConvertHexCoordsToWorldPosition(hexMap[i]);
            }
            return positions;
        }
    }
}
