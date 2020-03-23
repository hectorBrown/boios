using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boios
{
    public partial class FRM_main : Form
    {
        private int alignment, cohesion, seperation;
        List<Boio> boios;

        private void TB_alignment_Scroll(object sender, EventArgs e)
        {
            alignment = TB_alignment.Value;
        }

        private void TB_seperation_Scroll(object sender, EventArgs e)
        {
            seperation = TB_seperation.Value;
        }

        private void TB_cohesion_Scroll(object sender, EventArgs e)
        {
            cohesion = TB_cohesion.Value;
        }

        private void PB_main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Boio boio in boios)
            {
                Tuple<Color, PointF[]> triangleInfo;
                triangleInfo = boio.GetDrawing();
                g.FillPolygon(new SolidBrush(triangleInfo.Item1), triangleInfo.Item2);
            }
        }

        private void TIM_main_Tick(object sender, EventArgs e)
        {
            foreach (Boio boio in boios)
            {
                boio.Step(alignment, seperation, cohesion);
            }
            PB_main.Refresh();
        }

        private void FRM_main_Load(object sender, EventArgs e)
        {
            alignment = 0; cohesion = 0; seperation = 0;
            boios = new List<Boio>();
            boios.Add(new Boio(Color.Red, 0, new PointF(PB_main.Width / 2, PB_main.Height / 2), 0.3f));
        }

        public FRM_main()
        {
            InitializeComponent();
        }
    }
    public class Boio
    {
        private static readonly float TRIANGLEWIDTH = 6, TRIANGLEHEIGHT = 15, TRIANGLERATIO = 0.7f;
        private float direction, speed;
        private PointF position;
        private Color color;
        
        public Boio(Color _color, float _direction, PointF _position, float _speed)
        {
            color = _color; direction = _direction; position = _position; speed = _speed;
        }
        public Tuple<Color, PointF[]> GetDrawing()
        {
            PointF[] trianglePoints = new PointF[3];
            PointF triangleBaseCenter;
            trianglePoints[0] = GetPointRelativeTo(position, direction, TRIANGLERATIO * TRIANGLEHEIGHT);
            triangleBaseCenter = GetPointRelativeTo(position, direction + Convert.ToSingle(Math.PI), (1 - TRIANGLERATIO) * TRIANGLEHEIGHT);
            trianglePoints[1] = GetPointRelativeTo(triangleBaseCenter, direction - Convert.ToSingle(Math.PI / 2), TRIANGLEWIDTH / 2);
            trianglePoints[2] = GetPointRelativeTo(triangleBaseCenter, direction + Convert.ToSingle(Math.PI / 2), TRIANGLEWIDTH / 2);
            return new Tuple<Color, PointF[]>(color, trianglePoints);
        }
        public void Step(int alignment, int seperation, int cohesion)
        {
            PointF newPosition = GetPointRelativeTo(position, direction, speed);
            position = newPosition;
        }
        public static PointF GetPointRelativeTo(PointF O, float direction, float distance)
        {
            PointF result;
            while (direction >= 2 * Math.PI)
            {
                direction -= Convert.ToSingle(2 * Math.PI);
            }
            while (direction < 0)
            {
                direction += Convert.ToSingle(2 * Math.PI);
            }
            if (direction == 0) { result = new PointF(O.X, O.Y - distance); }
            else if (direction > 0 && direction < Math.PI / 2) { result = new PointF(O.X + distance * Convert.ToSingle(Math.Sin(direction)), 
                O.Y - distance * Convert.ToSingle(Math.Cos(direction))); }
            else if (direction == Math.PI / 2) { result = new PointF(O.X + direction, O.Y); }
            else if (direction > Math.PI / 2 && direction < Math.PI ) { result = new PointF(O.X + distance * Convert.ToSingle(Math.Cos(direction - Math.PI / 2)),
                O.Y + Convert.ToSingle(Math.Sin(direction - Math.PI / 2))); }
            else if (direction == Math.PI) { result = new PointF(O.X, O.Y + distance); }
            else if (direction > Math.PI && direction < (3 * Math.PI) / 2) { result = new PointF(O.X + distance * Convert.ToSingle(Math.Sin(direction - Math.PI)),
                O.Y + distance * Convert.ToSingle(Math.Cos(direction - Math.PI))); }
            else if (direction == (3 * Math.PI) / 2) { result = new PointF(O.X - direction, O.Y); }
            else { result = new PointF(O.X - direction * Convert.ToSingle(Math.Cos(direction - (3 * Math.PI) / 2)),
             O.Y - direction * Convert.ToSingle(Math.Sin(direction - (3 * Math.PI) / 2))); }
            return result;
        }
    }
}
