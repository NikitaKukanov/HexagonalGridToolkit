﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MSS.HexTesting
{
    public class HexTestForm
    {
        private static Label consoleLabel;
        private Form form;

        private List<Point[]> linesToDraw;

        public void Init()
        {
            form = new Form();
            form.BackColor = Color.White;
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.Bounds = new Rectangle(0, 0, 1000, 600);

            form.Paint += Form_Paint;

            consoleLabel = new Label();
            consoleLabel.AutoSize = true;
            consoleLabel.ForeColor = Color.Black;            
            consoleLabel.Parent = form;
            consoleLabel.TextAlign = ContentAlignment.BottomLeft;
            consoleLabel.Location = new Point(30, consoleLabel.Parent.Bounds.Height-90);
            Log("Start...");            
        }

        public void Run()
        {
            Application.EnableVisualStyles();
            Application.Run(form);
        }

        public void DrawLine(Point a, Point b)
        {
            DrawPolygon(new Point[] { a, b });
        }

        public void DrawPolygon(Point[] _points)
        {
            if (linesToDraw == null) {
                linesToDraw = new List<Point[]>();
            }
            linesToDraw.Add(_points);
        }

        public static void Log(string _msg)
        {
            consoleLabel.Text += _msg + "\n";
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            if (linesToDraw == null) {
                return;
            }
            for (int i = 0; i < linesToDraw.Count; i++) {
                e.Graphics.DrawLines(Pens.Black, linesToDraw[i]);
            }
        }
    }
}
