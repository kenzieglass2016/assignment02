using System;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace Animation
{
    public partial class Form1 : Form
    {
        public static SoundPlayer player = new SoundPlayer(Properties.Resources.YEE);
        MeSprite thing = new MeSprite();
        public static Form form;
        public static Thread thread;
        public static double running_fps = 30.0;
        public static int fps = 30;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            form = this;
            thing.Image = Animation.Properties.Resources.dalekKahn;
            thing.Scale = 0.25f;
            thing.Y += 20;
            player.PlayLooping();
            thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }

        public static void Update()
        {
            DateTime last = DateTime.Now;
            DateTime now = last;
            TimeSpan frameTime = new TimeSpan(10000000 / fps);
            while (true)
            {
                DateTime temp = DateTime.Now;
                running_fps = .9 * running_fps + .1 * 1000.0 / (temp - now).TotalMilliseconds;
                Console.WriteLine(running_fps);
                now = temp;
                TimeSpan diff = now - last;
                if (diff.TotalMilliseconds < frameTime.TotalMilliseconds)
                    Thread.Sleep((frameTime - diff).Milliseconds);
                last = DateTime.Now;
                form.Invoke(new MethodInvoker(form.Refresh));
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            thread.Abort();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            thing.act();
            thing.render(e.Graphics);
        }
    }
}
