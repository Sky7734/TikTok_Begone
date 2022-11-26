using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WMPLib;
using System.Numerics;

namespace WinFormsApp1
{
    public partial class Form1 : Form{
        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Debug.WriteLine(files[0]);
            foreach (string file in files) {
                var player = new WindowsMediaPlayer();
                var dur = player.newMedia(file);
                var time = TimeSpan.FromSeconds(dur.duration);
                TimeSpan subtract = new TimeSpan(0, 0, 0, 3, 750);
                Debug.WriteLine(time);
                Process.Start("ffmpeg.exe", $"-to {time - subtract} -i {file} -c copy {file}_purged.mp4 -y");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
//        Process.Start("ffmpeg.exe", "-to 8 -i 8c34039a59e6060073ef0aded39c2b06.mp4 -c copy test.mp4");