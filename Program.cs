using AluculeseiAndrei3131b;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Drawing;
using System.Xml.Linq;


/*
 ************************************************
 *                                              
 *      ALUCULESEI ANDREI-BOGDAN                                           
 *      LAST UPDATE: 15/10/23                                        
 *      GRUPA: 3131b                                        
 *                                              
 *                                                                                               
 *                                              
 *                                              
 ************************************************
 */


namespace OpenTK_SimpleMovement
{
    class SimpleWindow : GameWindow
    {

        float objectX=0.0f;
        bool isDragging=false;
        float previousMouseX;
        public SimpleWindow():base(600,800) 
        {
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

        }
        void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == MouseButton.Left)
            {
                isDragging = true;
                previousMouseX = e.X;//retin coordonata initiala a mouselui
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
                float deltaX = e.X - previousMouseX;//calc distanta dintre pozitia curenta si pozitia anterioara a cursorului
                objectX += deltaX * -0.001f; //mut obiectul
                previousMouseX = e.X;//reactualizez pozitia cursorului
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(objectX, 0, 0);


            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -0.5f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(0.5f, 0.5f);
            GL.End();

            this.SwapBuffers();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(objectX, 0, 0);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -0.5f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(0.2f, 0.2f);
            GL.End();
           
            this.SwapBuffers();
        }
      

        [STAThread]
        static void Main(string[] args)
        {
            int opt = 1;
            utils u = new utils();

            u.meniu();
            opt = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (opt)
            {
                case 1:
                    Console.WriteLine("ATI ALES LABORATORUL 2");
                    using (SimpleWindow window = new SimpleWindow())
                    {   
                        u.helpLab2();
                        window.Run(2.0, 0);
                    }
                    break;
                case 2:
                    Console.WriteLine("ATI ALES LABORATORUL 3");
                    Laborator3 laborator3 = new Laborator3();
                    laborator3.run();
                    break;
                default:
                    Console.WriteLine("ATI ALES O OPTIUNE INEXISTENTA");
                    Console.ReadLine();
                    break;
            }




        }
    }
}
