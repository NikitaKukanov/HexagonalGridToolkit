using MSS.HexagonalGridToolkit;

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

            grid = new HexTestGrid(20, HexOrientation.PointyOrientation, HexShape.Single, new Coords2(1,1));

            form.Run();
        }
    }
}
