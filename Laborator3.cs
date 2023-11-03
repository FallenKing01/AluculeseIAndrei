using AluculeseiAndrei3131b;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;

/*
 ************************************************
 *                                              
 *      ALUCULESEI ANDREI-BOGDAN                                           
 *      LAST UPDATE: 1/11/23                                        
 *      GRUPA: 3131b                                        
 *                                              
 *                                                                                               
 *                                              
 *                                              
 ************************************************
 */
namespace AluculeseiAndrei3131b
{
    public class Laborator3
    {
        class SimpleWindow : GameWindow
        {
            functiiFisier f1 = new functiiFisier("coordonate.txt");
            List<Punct> points = new List<Punct>();
            float objectX = 0.0f;
            bool isDragging = false;
            bool useRandomColor = true;
            public int XYZ_SIZE = 75;
            random randomColor = new random(251, 0, 251);
            Vector2 previousMousePosition;



            public SimpleWindow() : base(600, 800)
            {
                points = f1.citireFisier();
                VSync = VSyncMode.On;
                KeyDown += Keyboard_KeyDown;
                MouseDown += Mouse_ButtonDown;
                MouseUp += Mouse_ButtonUp;
                MouseMove += Mouse_Move;
            }

            void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
            {
                if (e.Key == Key.A)
                    objectX -= 0.1f;
                if (e.Key == Key.D)
                    objectX += 0.1f;

                // Toggle color when the "C" key is pressed
                if (e.Key == Key.C)
                {
                    useRandomColor = !useRandomColor;
                    randomColor.createColor();
                    Console.WriteLine("x: " + randomColor.x.ToString() + "  y: " + randomColor.y.ToString() + "  z: " + randomColor.z.ToString());
                }
            }

            void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (e.Button == MouseButton.Left)
                {
                    isDragging = true;
                    previousMousePosition = new Vector2(e.X, e.Y);
                }
            }

            void Mouse_ButtonUp(object sender, MouseButtonEventArgs e)
            {
                if (e.Button == MouseButton.Left)
                {
                    isDragging = false;
                }
            }

            void Mouse_Move(object sender, MouseMoveEventArgs e)
            {
                if (isDragging)
                {
                    float deltaX = e.X - previousMousePosition.X;
                    float deltaY = e.Y - previousMousePosition.Y;

                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.Translate(deltaX * 0.01f, deltaY * 0.01f, 0);

                    previousMousePosition = new Vector2(e.X, e.Y);
                }
            }

            protected override void OnLoad(EventArgs e)
            {
                GL.ClearColor(Color.MidnightBlue);
                GL.Enable(EnableCap.DepthTest);
                GL.DepthFunc(DepthFunction.Less);
                GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            }

            protected override void OnResize(EventArgs e)
            {
                GL.Viewport(0, 0, Width, Height);

                double aspect_ratio = Width / (double)Height;

                Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);

                Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref lookat);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                this.SwapBuffers();
            }

            protected override void OnRenderFrame(FrameEventArgs e)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.Begin(PrimitiveType.TriangleFan);

                for (int i = 0; i < points.Count; i++)
                {
                    GL.Color3(randomColor.x / 255.0, randomColor.y / 255.0, randomColor.z / 255.0);
                    GL.Vertex3(points[i].x, points[i].y, points[i].z);
                }

                GL.End();
                this.SwapBuffers();
            }

           
        }
       
        public void run()
        {
            utils u = new utils();

            using (SimpleWindow window = new SimpleWindow())
            {
                u.helpLab3();

                window.Run(2.0, 0);
            }
        }
    }
}
