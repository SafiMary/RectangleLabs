using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RectangleLabs
{
    public partial class Ellipses : Form
    {
        int x, y; // Координаты мыши при событии MouseDown
        List<RectangleF> ellipses_lst;
        RectangleF workPlace;
        bool selected = false;
        bool IsLeftKeyPressed = false;
        public Ellipses()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            ellipses_lst = new List<RectangleF>();
            workPlace = new RectangleF(25, 25, this.Width - 75, this.Height - 75);
        }
        private void refreashForm()//обновление формы
        {

            if (ellipses_lst.Count > 0)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(BackColor);
                Brush brush = Brushes.Pink;
                foreach (var item in ellipses_lst)
                {
                    g.FillEllipse(brush, item);
                }
            }

        }
        private void Ellipses_MouseDown(object sender, MouseEventArgs e)
        {
         
            if (e.Button == MouseButtons.Right)
            {
             
                this.x = e.X;
                this.y = e.Y;
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    IsLeftKeyPressed = true;
                    this.x = e.X;
                    this.y = e.Y;
                    foreach (var item in ellipses_lst)
                    {
                        if (item.Contains(new PointF(x, y)))
                        {
                            selected = true;
                        }
                    }
                }
            }

                }
      
        private void addEllipse(RectangleF ellipse)//добавление элипсов чтоб не пересекались между собой
        {
            foreach (var item in ellipses_lst)
            {
                if (item.IntersectsWith(ellipse))
                {
                    return;
                }
            }
            if (!workPlace.Contains(new PointF(ellipse.X+25,ellipse.Y+25 )))
            {
                return;
            }
            ellipses_lst.Add(ellipse);
            Graphics g = this.CreateGraphics();
            g.Clear(BackColor);
            Brush brush = Brushes.Green;
            foreach (var item in ellipses_lst)
            {
                g.FillEllipse(brush, item);
            }
            
        }

        private void Ellipses_MouseUp(object sender, MouseEventArgs e)
        {
            var ellipse = new RectangleF(this.x - 25, this.y - 25, 50, 50);
            addEllipse(ellipse);

         
        }

        private void Ellipses_Resize(object sender, EventArgs e)
        {
            workPlace = new RectangleF(25,25,this.Width - 75, this.Height - 75);
            Graphics g = this.CreateGraphics();
            Brush brush = Brushes.DarkOrange;
            g.FillRectangle(brush, workPlace);
        }
       
        private void addMovingEllipses(Pen pen, RectangleF rectangle)//рисуем элипс, в который будут попадать элипсы и удаляться
        {
            refreashForm();
            Graphics g = this.CreateGraphics();
  
            g.DrawEllipse(pen,
             rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            workPlace = rectangle;
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsLeftKeyPressed)
            {
                refreashForm();
                int x1, y1, x2, y2;
                x1 = (x > e.X) ? e.X : x;
                y1 = (y > e.Y) ? e.Y : y;
                x2 = (x <= e.X) ? e.X : x;
                y2 = (y <= e.Y) ? e.Y : y;
                if (!selected)
                {
                    var ellips = new RectangleF(x1, y1, x2 - x1, y2 - y1);
                    var pen_foreColor = new Pen(Color.DarkRed, 2);
                    addMovingEllipses(pen_foreColor, ellips);
                }
                else
                {
                    var ellips = new RectangleF(e.X - 25, e.Y - 25, 50, 50);
                    foreach (var item in ellipses_lst)
                    {
                        if (item.IntersectsWith(ellips))
                        
                        {
                            ellipses_lst.Remove(item);
                            break; 
                        }
                    }
                    addEllipse(ellips);//убрала нью
                    refreashForm();
                }
            }

        }
    }
}
