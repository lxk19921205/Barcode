/**********************************************
 *          
 *   名称：商业自动化课程设计 
 *   功能：EAN13条码的转换
 *   作者：谢珺，何小燕，龙宇航，陈婷婷，杨颖
 *   时间：2012-11-12
 *   
 * *******************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// 实现了bc类的编码
/// </summary>
namespace EAN8
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 存放从TextBox读取进来的13个数字
        /// </summary>
        int[] allNumbers = new Int32[13];

        // 最左边，但好像没用到，也许是b、c类编码没有用到这个？还是原本的实现是残缺的...
        int[] xc0 = new Int32[7];

        //左半区
        // xc 是一个个的0和1组成的数组，具体0和1的顺序是怎样看200多行的那个Dictionary
        int[] xc1 = new Int32[7];
        int[] xc2 = new Int32[7];
        int[] xc3 = new Int32[7];
        int[] xc4 = new Int32[7];
        int[] xc5 = new Int32[7];
        int[] xc6 = new Int32[7];

        //右半区
        int[] xc7 = new Int32[7];
        int[] xc8 = new Int32[7];
        int[] xc9 = new Int32[7];
        int[] xc10 = new Int32[7];
        int[] xc11 = new Int32[7];
        int[] xc12 = new Int32[7];

        /// <summary>
        /// 构造函数，里头调用的是C#自动生成的界面代码，不用管它
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            label1.Text = "谢珺，何小燕，龙宇航，陈婷婷，杨颖";
        }

        /// <summary>
        /// 别删，删了就会报错...
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 具体画图的函数，在界面上画那个条形码，同时也写上数字
        /// </summary>
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // 用白色清屏
            g.Clear(Color.White);

            // 画笔是黑色的，宽度是1
            Pen p = new Pen(Color.Black, 1);

            // 下边这两个是字体和画刷，在DrawString函数中用得到；实验证明，字体大小为6刚刚好
            Font drawFont = new Font("Arial", 6);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // 在这个x坐标上打印下一个数字
            int num_pos_x = 1;
            // 在这个y坐标上打印下一个数字
            const int num_pos_y = 90;
            // 打印类变量allNumbers数组里的哪一个出来
            int numberIndex = 0;

            // 最左边的数字
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            // 这个画完之后打印下一个数字，所以++
            numberIndex++;
            // 这里是硬编码，实践证明，12的位置作为左半区第一个数字的x坐标正好
            num_pos_x = 12;

            //下边两行画的是左起始码
            g.DrawLine(p, new Point(9, 10), new Point(9, 100));
            g.DrawLine(p, new Point(11, 10), new Point(11, 100));

            // 1st，循环里边是画线，我猜想是根据数值不同画粗细不同的线，嗯，应该就是这样！
            for (int cont3 = 12; cont3 < 19; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc1[cont3 - 12], 10 * xc1[cont3 - 12]), new Point(cont3 * xc1[cont3 - 12], 90 * xc1[cont3 - 12]));
            }
            // 画对应的数字，画完之后index++，x坐标+7是因为 19-12 == 7
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 2nd，和1st基本一样，下同，这么冗余的代码真是恶心啊
            for (int cont3 = 19; cont3 < 26; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc2[cont3 - 19], 10 * xc2[cont3 - 19]), new Point(cont3 * xc2[cont3 - 19], 90 * xc2[cont3 - 19]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 3rd
            for (int cont3 = 26; cont3 < 33; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc3[cont3 - 26], 10 * xc3[cont3 - 26]), new Point(cont3 * xc3[cont3 - 26], 90 * xc3[cont3 - 26]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 4th
            for (int cont3 = 33; cont3 < 40; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc4[cont3 - 33], 10 * xc4[cont3 - 33]), new Point(cont3 * xc4[cont3 - 33], 90 * xc4[cont3 - 33]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 5th
            for (int cont3 = 40; cont3 < 47; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc5[cont3 - 40], 10 * xc5[cont3 - 40]), new Point(cont3 * xc5[cont3 - 40], 90 * xc5[cont3 - 40]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 6th
            for (int cont3 = 47; cont3 < 54; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc6[cont3 - 47], 10 * xc6[cont3 - 47]), new Point(cont3 * xc6[cont3 - 47], 90 * xc6[cont3 - 47]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            //下边两行画的是正中间的两条长的
            g.DrawLine(p, new Point(54, 10), new Point(54, 100));
            g.DrawLine(p, new Point(57, 10), new Point(57, 100));
            num_pos_x += 3;

            // 7th
            for (int cont3 = 58; cont3 < 65; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc7[cont3 - 58], 10 * xc7[cont3 - 58]), new Point(cont3 * xc7[cont3 - 58], 90 * xc7[cont3 - 58]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 8th
            for (int cont3 = 65; cont3 < 72; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc8[cont3 - 65], 10 * xc8[cont3 - 65]), new Point(cont3 * xc8[cont3 - 65], 90 * xc8[cont3 - 65]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 9th
            for (int cont3 = 72; cont3 < 79; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc9[cont3 - 72], 10 * xc9[cont3 - 72]), new Point(cont3 * xc9[cont3 - 72], 90 * xc9[cont3 - 72]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 10th
            for (int cont3 = 79; cont3 < 86; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc10[cont3 - 79], 10 * xc10[cont3 - 79]), new Point(cont3 * xc10[cont3 - 79], 90 * xc10[cont3 - 79]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 11th
            for (int cont3 = 86; cont3 < 93; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc11[cont3 - 86], 10 * xc11[cont3 - 86]), new Point(cont3 * xc11[cont3 - 86], 90 * xc11[cont3 - 86]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            // 12th
            for (int cont3 = 93; cont3 < 100; cont3++)
            {
                g.DrawLine(p, new Point(cont3 * xc12[cont3 - 93], 10 * xc12[cont3 - 93]), new Point(cont3 * xc12[cont3 - 93], 90 * xc12[cont3 - 93]));
            }
            g.DrawString(allNumbers[numberIndex].ToString(), drawFont, drawBrush, new Point(num_pos_x, num_pos_y));
            numberIndex++;
            num_pos_x += 7;

            //下边两行画的是最右边的两条长的
            g.DrawLine(p, new Point(100, 10), new Point(100, 100));
            g.DrawLine(p, new Point(102, 10), new Point(102, 100));
        }

        /// <summary>
        /// 生成条码的button按了之后就执行这里
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // 长度得是13
            if (textBox1.Text.Length != 13)
            {
                MessageBox.Show("请输入13位EAN");
                return;
            }

            // 必须得是数字
            if (IsNum(textBox1.Text) == false)
            {
                MessageBox.Show("请输入数字");
                return;
            }

            // 这里先把输入的13个数字分开来存好
            char[] arr = textBox1.Text.ToCharArray();
            for (int j = 0; j < arr.Length; j++)
            {
                allNumbers[j] = int.Parse(arr[j].ToString());
            }

            // 这个应该就是什么编码表了吧，一个数对应一个string，里头有数字对应的01序列，$用来做分隔符
            // 其实不用这么麻烦做字符串解析的，不过原作者这么写了...
            Dictionary<int, string> d = new Dictionary<int, string>();
            d.Add(0, "0$1$0$0$1$1$1");
            d.Add(1, "0$1$1$0$0$1$1");
            d.Add(2, "0$0$1$1$0$1$1");
            d.Add(3, "0$1$0$0$0$0$1");
            d.Add(4, "0$0$1$1$1$0$1");
            d.Add(5, "0$1$1$1$0$0$1");
            d.Add(6, "0$0$0$0$1$0$1");
            d.Add(7, "0$0$1$0$0$0$1");
            d.Add(8, "0$0$0$1$0$0$1");
            d.Add(9, "0$0$1$0$1$1$1");

            // 这个是楼上那个的reverse
            Dictionary<int, string> dr = new Dictionary<int, string>();
            dr.Add(0, "1$1$1$0$0$1$0");
            dr.Add(1, "1$1$0$0$1$1$0");
            dr.Add(2, "1$1$0$1$0$1$0");
            dr.Add(3, "1$1$0$1$1$0$0");
            dr.Add(4, "1$0$1$1$1$0$0");
            dr.Add(5, "1$0$0$1$1$1$0");
            dr.Add(6, "1$0$1$0$0$0$0");
            dr.Add(7, "1$0$0$0$1$0$0");
            dr.Add(8, "1$0$0$1$0$0$0");
            dr.Add(9, "1$1$1$0$1$0$0");

            //不知为何把第0个给注释掉了，反正没用上
            //if (d.ContainsKey(allNumbers[0])) // True 
            //    {
            //        string p = d[arrk[0]];
            //        x0 = p.Split('$');//x[0]=0;x[1]=1;....
            //        for (int i = 0; i < x0.Length; i++)
            //        {
            //            xc0[i] = Convert.ToInt32(x0[i]);
            //        }
            //    }

            // 这个判断是一定true的，因为上头的dictionary里0-9都有了
            if (d.ContainsKey(allNumbers[1])) // True 2位
            {
                // 解析出每一个数字对应的01序列，存到xc里头
                string p = d[allNumbers[1]];
                string[] x1 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x1.Length; i++)
                {
                    xc1[i] = Convert.ToInt32(x1[i]);
                }
            }
            // 同LS
            if (d.ContainsKey(allNumbers[2])) // True 
            {
                string p = d[allNumbers[2]];
                string[] x2 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x2.Length; i++)
                {
                    xc2[i] = Convert.ToInt32(x2[i]);
                }
            }
            if (d.ContainsKey(allNumbers[3])) // True 
            {
                string p = d[allNumbers[3]];
                string[] x3 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x3.Length; i++)
                {
                    xc3[i] = Convert.ToInt32(x3[i]);
                }
            }
            if (d.ContainsKey(allNumbers[4])) // True 
            {
                string p = d[allNumbers[4]];
                string[] x4 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x4.Length; i++)
                {
                    xc4[i] = Convert.ToInt32(x4[i]);
                }
            }
            if (d.ContainsKey(allNumbers[5])) // True 
            {
                string p = d[allNumbers[5]];
                string[] x5 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x5.Length; i++)
                {
                    xc5[i] = Convert.ToInt32(x5[i]);
                }
            }
            if (d.ContainsKey(allNumbers[6])) // True 
            {
                string p = d[allNumbers[6]];
                string[] x6 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x6.Length; i++)
                {
                    xc6[i] = Convert.ToInt32(x6[i]);
                }
            }
            if (dr.ContainsKey(allNumbers[7])) // True 
            {
                string p = d[allNumbers[7]];
                string[] x7 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x7.Length; i++)
                {
                    xc7[i] = Convert.ToInt32(x7[i]);
                }
            }
            if (dr.ContainsKey(allNumbers[8])) // True 
            {
                string p = d[allNumbers[8]];
                string[] x8 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x8.Length; i++)
                {
                    xc8[i] = Convert.ToInt32(x8[i]);
                }
            }
            if (dr.ContainsKey(allNumbers[9])) // True 
            {
                string p = d[allNumbers[9]];
                string[] x9 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x9.Length; i++)
                {
                    xc9[i] = Convert.ToInt32(x9[i]);
                }
            }
            if (dr.ContainsKey(allNumbers[10])) // True 
            {
                string p = d[allNumbers[10]];
                string[] x10 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x10.Length; i++)
                {
                    xc10[i] = Convert.ToInt32(x10[i]);
                }
            }
            if (dr.ContainsKey(allNumbers[11])) // True 
            {
                string p = d[allNumbers[11]];
                string[] x11 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x11.Length; i++)
                {
                    xc11[i] = Convert.ToInt32(x11[i]);
                }
            }
            if (dr.ContainsKey(allNumbers[12])) // True 
            {
                string p = d[allNumbers[12]];
                string[] x12 = p.Split('$');//x[0]=0;x[1]=1;....
                for (int i = 0; i < x12.Length; i++)
                {
                    xc12[i] = Convert.ToInt32(x12[i]);
                }
            }

            // 这一行是为了让pictureBox1在要画图的时候能知道调用pictureBox1_Paint()这个函数
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(pictureBox1_Paint);
            // 以下两行是为了让界面刷新，原本没有Remove()就只会画一次
            this.Controls.Remove(pictureBox1);
            this.Controls.Add(pictureBox1);
        }

        /// <summary>
        /// 顾名思义
        /// </summary>
        public static bool IsNum(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsNumber(str, i))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 这个label不知道在哪里点，无视吧
        /// </summary>
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}