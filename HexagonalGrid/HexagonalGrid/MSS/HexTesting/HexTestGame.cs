using MSS.HexagonalGridToolkit;
using System.Drawing;

namespace MSS.HexTesting
{
    public class HexTestGame
    {
        private HexTestForm form;
        private HexTestGrid grid;

        public HexTestGame()
        {
            form = new HexTestForm();
            form.Init();

            grid = new HexTestGrid(30, HexOrientation.PointyOrientation, HexShape.Rectangle, new Coords2(7,7));

            var localCorners = grid.grid.GetHexCornersLocalPositions(); // ? grid-grid??
            Point[] centeredPoints = new Point[localCorners.Length];
            for (int i = 0; i < localCorners.Length; i++) {
                centeredPoints[i] = new Point((int)localCorners[i].x+400, (int)localCorners[i].y+200);
            }

            var worldPositions = grid.grid.GetHexesPositions();
            for (int i = 0; i < worldPositions.Length; i++) {
                var worldCorners = new Point[centeredPoints.Length];
                for (int j = 0; j < centeredPoints.Length; j++) {
                    worldCorners[j] = new Point(centeredPoints[j].X + (int)worldPositions[i].x, centeredPoints[j].Y + (int)worldPositions[i].y);
                }
                form.DrawPolygon(worldCorners, true);
            }

            form.Run();
        }
    }
}
