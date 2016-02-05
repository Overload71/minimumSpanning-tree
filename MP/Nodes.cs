using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP
{
    class Nodes
    {
        public Graphics formGraphics,formGraphics2;
         public Point[] points =    //Nodes points
             {
                   new Point(70,150),     //0     
                   new Point(150,50),    //1     
                   new Point(250,50),    //2  
                   new Point(350,50),    //3
                   new Point(430,150),    //4  
                   new Point(350,250),    //5 
                   new Point(250,250),    //6  
                   new Point(150,250),    //7
                   new Point(250,150),    //8
                   new Point(250,50),    //9
             };
         public Point[] points_edge =    //Nodes points
             {
              
                   new Point(90,160),     //0     
                   new Point(170,70),    //1     
                   new Point(270,70),    //2  
                   new Point(370,70),    //3
                   new Point(450,170),    //4  
                   new Point(370,270),    //5 
                   new Point(270,270),    //6  
                   new Point(170,270),    //7
                   new Point(270,170),    //8
                   new Point(270,70),    //9
             };
        public Nodes(Panel panel1,Panel panel2)
        {
            formGraphics = panel1.CreateGraphics();
            formGraphics.DrawRectangle(new Pen(Color.Blue, 5), panel1.ClientRectangle);
            formGraphics2 = panel2.CreateGraphics();
            formGraphics2.DrawRectangle(new Pen(Color.Blue, 5), panel2.ClientRectangle);
        }

        public void draw_sol(int A,int B,int s)
        {
            SolidBrush br = new SolidBrush(Color.Black);
            formGraphics2.FillEllipse(br, new Rectangle(points[A], new Size(40, 40)));
            formGraphics2.DrawString(A.ToString(), new Font("Arial", 18), Brushes.White, new Point(points[A].X + 10, points[A].Y + 5));
            formGraphics2.FillEllipse(br, new Rectangle(points[B], new Size(40, 40)));
            formGraphics2.DrawString(B.ToString(), new Font("Arial", 18), Brushes.White, new Point(points[B].X + 10, points[B].Y + 5));
            formGraphics2.DrawString(s.ToString(), new Font("Arial", 10), Brushes.Black, new Point((points[A].X + points[B].X) / 2, (points[A].Y + points[B].Y) / 2));
            formGraphics2.DrawLine(new Pen(Color.Orange, 3), points_edge[A], points_edge[B]);
        }

        public void draw(int Node_number)
        {
          for (int i = 0; i < Node_number; i++)
            {
                SolidBrush br = new SolidBrush(Color.Black);
                formGraphics.FillEllipse(br, new Rectangle(points[i], new Size(40, 40)));
                formGraphics.DrawString(i.ToString(), new Font("Arial", 18), Brushes.White, new Point(points[i].X + 10, points[i].Y + 5));
            }
           // formGraphics.Dispose();
        }

        public void Draw_edge(int A,int B,string s)
        {
            formGraphics.DrawString(s, new Font("Arial", 10), Brushes.Black, new Point((points[A].X + points[B].X)/2,(points[A].Y + points[B].Y) /2));
            formGraphics.DrawLine(new Pen(Color.Orange,3),points_edge[A],points_edge[B]);
        }
    }
}
