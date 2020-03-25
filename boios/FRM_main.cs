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
        Random rng;

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
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Boio boio in boios)
            {
                boio.GetDrawing(ref g);
            }
        }

        private void TIM_main_Tick(object sender, EventArgs e)
        {
            foreach (Boio boio in boios)
            {
                boio.Step(alignment, seperation, cohesion, boios.ToArray(), ref rng);
            }
            PB_main.Refresh();
        }

        private void FRM_main_Load(object sender, EventArgs e)
        {
            alignment = 1; cohesion = 1; seperation = 1;
            boios = new List<Boio>();
            rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                boios.Add(new Boio(Color.Red, Convert.ToSingle(Math.PI), new PointF(rng.Next(0, PB_main.Width), rng.Next(0, PB_main.Height / 2)), 0.3f));
            }
        }

        public FRM_main()
        {
            InitializeComponent();
        }
    }
    public class Boio
    {
        private static readonly float TRIANGLEWIDTH = 6, TRIANGLEHEIGHT = 15, TRIANGLERATIO = 0.7f, OCCLUDE = 100, AVOID = 10;
        private float direction, speed;
        private PointF position;
        private Color color;
        
        public Boio(Color _color, float _direction, PointF _position, float _speed)
        {
            color = _color; direction = _direction; position = _position; speed = _speed;
        }
        public void GetDrawing(ref Graphics g)
        {
            PointF[] trianglePoints = new PointF[3];
            PointF triangleBaseCenter;
            trianglePoints[0] = GetPointRelativeTo(position, direction, TRIANGLERATIO * TRIANGLEHEIGHT);
            triangleBaseCenter = GetPointRelativeTo(position, direction + Convert.ToSingle(Math.PI), (1 - TRIANGLERATIO) * TRIANGLEHEIGHT);
            trianglePoints[1] = GetPointRelativeTo(triangleBaseCenter, direction - Convert.ToSingle(Math.PI / 2), TRIANGLEWIDTH / 2);
            trianglePoints[2] = GetPointRelativeTo(triangleBaseCenter, direction + Convert.ToSingle(Math.PI / 2), TRIANGLEWIDTH / 2);
            g.FillPolygon(new SolidBrush(color), trianglePoints);
        }
        public void Step(int alignment, int seperation, int cohesion, Boio[] others, ref Random rng) 
        {
            PointF avgPos1, avgPos2, avgPos3;
            float sumX = 0, sumY = 0, directionSum = 0;
            float avoidSumX = 0, avoidSumY = 0;
            int counter = 0;
            int avoidCounter = 0;
            float targetX, targetY;
            PointF target;
            float bearing;
            float bearingDisparity;
            foreach (Boio boio in others)
            {
                if (GetDistanceTo(boio.GetPosition()) < OCCLUDE && GetDistanceTo(boio.GetPosition()) != 0)
                {
                    if (GetDistanceTo(boio.GetPosition()) < AVOID)
                    {
                        avoidSumX += -GetVectorTo(boio.position).X;
                        avoidSumY += -GetVectorTo(boio.position).Y;
                        avoidCounter++;
                    }
                    sumX += boio.GetPosition().X; sumY += boio.GetPosition().Y;
                    directionSum += boio.GetDirection();
                    counter++;
                }
            }
            avgPos1 = new PointF(sumX / counter, sumY / counter);
            avgPos2 = GetPointRelativeTo(position, directionSum / counter, OCCLUDE);
            avgPos3 = new PointF(avoidSumX / avoidCounter, avoidSumY / avoidCounter);
            targetX = (avgPos1.X * cohesion + avgPos2.X * alignment + avgPos3.X * seperation) / (alignment + seperation + cohesion);
            targetY = (avgPos1.Y * cohesion + avgPos2.Y * alignment + avgPos3.Y * seperation) / (alignment + seperation + cohesion);
            target = new PointF(targetX, targetY);

            bearing = GetDirectionTo(target);
            bearingDisparity = bearing - direction;
            if (bearingDisparity > Convert.ToSingle(Math.PI)) { bearing = -Convert.ToSingle(2 * Math.PI) - bearing; }
            if (bearingDisparity < Convert.ToSingle(-Math.PI)) { bearing = Convert.ToSingle(2 * Math.PI) + bearing; }

            direction += Convert.ToSingle(Math.Sin(bearing));
            
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
            result = new PointF(O.X + distance * Convert.ToSingle(Math.Sin(direction)), O.Y + distance * Convert.ToSingle(Math.Cos(direction)));
            return result;
        }
        private float GetDirectionTo(PointF p)
        {
            float angleOutput;
            PointF direction = new PointF(p.X - position.X, p.Y - position.Y);
            if (direction.X > 0 && direction.Y > 0)
            {
                angleOutput = Convert.ToSingle(Math.Atan2(direction.X, direction.Y)); 
            }
            else if (direction.X > 0 && direction.Y < 0)
            {
                angleOutput = Convert.ToSingle(Math.PI - Math.Atan2(direction.X, Math.Abs(direction.Y)));
            }
            else if (direction.X < 0 && direction.Y < 0)
            {
                angleOutput = Convert.ToSingle(Math.PI + Math.Atan2(Math.Abs(direction.X), Math.Abs(direction.Y)));
            }
            else
            {
                angleOutput = Convert.ToSingle((2 * Math.PI) - Math.Atan2(Math.Abs(direction.X), direction.Y));
            }
            return angleOutput;
        }
        private float GetDistanceTo(PointF p)
        {
            return Convert.ToSingle(Math.Sqrt(Math.Pow(p.X - position.X, 2) + Math.Pow(p.Y - position.Y, 2))); 
        }
        private PointF GetVectorTo(PointF p)
        {
            return new PointF(p.X - position.X, p.Y - position.Y);
        }
        public PointF GetPosition()
        {
            return position;
        }
        public float GetDirection()
        {
            return direction;
        }
    }
}
