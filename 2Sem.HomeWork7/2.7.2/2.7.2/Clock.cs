using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2._7._2
{
    public partial class Clock : Form
    {
        private int secondHandLength = 140;
        private int minuteHandLength = 110;
        private int hourHandLength = 80;
        private Timer timer = new Timer();
        private int widthClock = 300;
        private int heightClock = 300;
        private Bitmap bitmap;
        private Graphics graphics;
        private Coordinate clockCenter = new Coordinate(240, 165);

        /// <summary>
        /// Coordinate for hands.
        /// </summary>
        private class Coordinate
        {
            public int x;
            public int y;

            /// <summary>
            /// Coordinate constructor with x and y.
            /// </summary>
            /// <param name="x">Coordinate x</param>
            /// <param name="y">Coordinate y</param>
            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            /// <summary>
            /// Coordinate constructor without x and y.
            /// </summary>
            public Coordinate()
            {
            }
        }

        /// <summary>
        /// Clock`s coustructor.
        /// </summary>
        public Clock()
        {
            InitializeComponent();
            DrawDial();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.Tick);
            timer.Start();
        }

        /// <summary>
        /// Draws a dial.
        /// </summary>
        private void DrawDial()
        {
            bitmap = new Bitmap(picture.Width, picture.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.DrawEllipse(new Pen(Color.Black, 3), 90, 20, widthClock, heightClock);

            graphics.DrawString("12", new Font("Arial", 15), Brushes.Black, new PointF(228, 22));
            graphics.DrawString("3", new Font("Arial", 15), Brushes.Black, new PointF(371, 155));
            graphics.DrawString("6", new Font("Arial", 15), Brushes.Black, new PointF(235, 295));
            graphics.DrawString("9", new Font("Arial", 15), Brushes.Black, new PointF(95, 157));

            graphics.DrawString("1", new Font("Arial", 15), Brushes.Black, new PointF(298, 42));
            graphics.DrawString("2", new Font("Arial", 15), Brushes.Black, new PointF(346, 91));
            graphics.DrawString("4", new Font("Arial", 15), Brushes.Black, new PointF(352, 226));
            graphics.DrawString("5", new Font("Arial", 15), Brushes.Black, new PointF(298, 277));

            graphics.DrawString("7", new Font("Arial", 15), Brushes.Black, new PointF(168, 270));
            graphics.DrawString("8", new Font("Arial", 15), Brushes.Black, new PointF(114, 226));
            graphics.DrawString("10", new Font("Arial", 15), Brushes.Black, new PointF(114, 95));
            graphics.DrawString("11", new Font("Arial", 15), Brushes.Black, new PointF(163, 42));
        }

        /// <summary>
        /// Clock`s tick.
        /// </summary>
        private void Tick(object sender, EventArgs e)
        {
            Bitmap tickBitmap = (Bitmap)bitmap.Clone();
            graphics = Graphics.FromImage(tickBitmap);
            int seconds = DateTime.Now.Second;
            int minutes = DateTime.Now.Minute;
            int hours = DateTime.Now.Hour;
            Coordinate handCoordinate = new Coordinate();

            handCoordinate = GetCoordinatesForTheMinuteOrSecondHands(seconds, secondHandLength);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(clockCenter.x, clockCenter.y), new Point(handCoordinate.x, handCoordinate.y));

            handCoordinate = GetCoordinatesForTheMinuteOrSecondHands(minutes, minuteHandLength);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(clockCenter.x, clockCenter.y), new Point(handCoordinate.x, handCoordinate.y));

            handCoordinate = GetCoordinatesForTheHourHand(hours % 12, minutes, hourHandLength);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(clockCenter.x, clockCenter.y), new Point(handCoordinate.x, handCoordinate.y));
            picture.Image = tickBitmap;
        }

        /// <summary>
        /// Get coordinates for the minute or seconds hands.
        /// </summary>
        /// <param name="value">Second`s or minute`s value</param>
        /// <param name="handLength">Clock`s hand length</param>
        /// <returns>Coordinate for clock hand`s drawing.</returns>
        private Coordinate GetCoordinatesForTheMinuteOrSecondHands(int value, int handLength)
        {
            var currentCoordinate = new Coordinate(); 
            value *= 6;  
            if (value >= 0 && value <= 180)
            {
                currentCoordinate.x = clockCenter.x + (int)(handLength * Math.Sin(Math.PI * value / 180));
                currentCoordinate.y = clockCenter.y - (int)(handLength * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                currentCoordinate.x = clockCenter.x - (int)(handLength * -Math.Sin(Math.PI * value / 180));
                currentCoordinate.y = clockCenter.y - (int)(handLength * Math.Cos(Math.PI * value / 180));
            }
            return currentCoordinate;
        }

        /// <summary>
        /// Get coordinates for the hour hand.
        /// </summary>
        /// <param name="hourValue">Hour value</param>
        /// <param name="minuteValue">Minute value</param>
        /// <param name="handLength">Clock`s hand length</param>
        /// <returns>Coordinate for clock hand`s drawing.</returns>
        private Coordinate GetCoordinatesForTheHourHand(int hourValue, int minuteValue, int handLength)
        {
            var currentCoordinate = new Coordinate();
            int value = (int)((hourValue * 30) + (minuteValue * 0.5));
            if (value >= 0 && value <= 180)
            {
                currentCoordinate.x = clockCenter.x + (int)(handLength * Math.Sin(Math.PI * value / 180));
                currentCoordinate.y = clockCenter.y - (int)(handLength * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                currentCoordinate.x = clockCenter.x - (int)(handLength * -Math.Sin(Math.PI * value / 180));
                currentCoordinate.y = clockCenter.y - (int)(handLength * Math.Cos(Math.PI * value / 180));
            }
            return currentCoordinate;
        }
    }
}

