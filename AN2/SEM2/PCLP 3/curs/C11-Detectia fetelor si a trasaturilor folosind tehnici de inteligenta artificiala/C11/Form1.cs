using Accord.Imaging.Filters;
using Accord.Video.FFMPEG;
using FaceRecognitionDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VideoFileReader vfr;
        ResizeBilinear filter = new ResizeBilinear(1366, 768);
        int crtFrame = 0;
        FaceRecognition _FaceRecognition = FaceRecognition.Create("models");
        Model model = FaceRecognitionDotNet.Model.Cnn;

        private void Form1_Load(object sender, EventArgs e)
        {
            vfr = new VideoFileReader();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            vfr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vfr.Open(@"d:\Rick Astley1.mp4");
            timer1.Interval = (int)(1000/vfr.FrameRate);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (crtFrame>vfr.FrameCount)
            {
                timer1.Enabled = false;
            }

            if (crtFrame<5) { crtFrame++; return; }

            Bitmap frame = vfr.ReadVideoFrame();
            frame = filter.Apply(frame);

            var faceFrame = FaceRecognition.LoadImage(frame);
            var faceLocations = _FaceRecognition.FaceLocations(faceFrame, 0, model).ToArray();
            IDictionary<FacePart, IEnumerable<FacePoint>>[] landMarks = null;
            if (faceLocations != null && faceLocations.Length != 0)
            {
                landMarks = _FaceRecognition.FaceLandmark(faceFrame, faceLocations, PredictorModel.Large, model).ToArray();
            }
            //var faceEncodings = _FaceRecognition.FaceEncodings(faceFrame, faceLocations, 1, PredictorModel.Large, model).ToArray();

            Graphics g = Graphics.FromImage(frame);

            g.FillRectangle(Brushes.White, frame.Width - 200, frame.Height - 50, 200, 50);
            g.DrawString(crtFrame + "/" + vfr.FrameCount, DefaultFont, Brushes.Black, frame.Width - 200, frame.Height - 50);

            for (int k = 0; k < faceLocations.Length; k++)
            {
                var faceLocation = faceLocations[k];
                //var faceEncoding = faceEncodings[k];

                

                int w = faceLocation.Right - faceLocation.Left;
                int h = faceLocation.Bottom - faceLocation.Top;

                g.DrawRectangle(Pens.Red, faceLocation.Left, faceLocation.Top, w, h);

                IDictionary<FacePart, IEnumerable<FacePoint>> landMark = null;
                if (landMarks != null)
                {
                    landMark = landMarks[k];
                    foreach (var el in landMark)
                    {
                        int x = -1;
                        int y = -1;
                        foreach (var fp in el.Value)
                        {
                            if (x == -1)
                            {
                                x = fp.Point.X;
                                y = fp.Point.Y;
                                g.FillEllipse(Brushes.Green, x - 2, y - 2, 4, 4);
                                continue;
                            }
                            g.DrawLine(Pens.Green, x, y, fp.Point.X, fp.Point.Y);
                            x = fp.Point.X;
                            y = fp.Point.Y;
                            g.FillEllipse(Brushes.Green, x - 2, y - 2, 4, 4);
                        }
                    }
                }
            }

            pictureBox1.Image = frame;
            pictureBox1.Refresh();
            crtFrame++;
        }
    }
}
