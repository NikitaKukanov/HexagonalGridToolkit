namespace MSS.HexagonalGridToolkit
{
    public interface IHex
    {
        //HexOrientation Orientation { get; } ???
        HexCoords Position { get; }
        float Width { get; }
        float Height { get; }
        float Size { get; }
        float VerticalDistance { get; }
        float HorizontalDistance { get; }
        Point2[] Corners { get; }
        IHex[] Neighbors { get; }

        Point2 GetWorldCoords();
    }
}
