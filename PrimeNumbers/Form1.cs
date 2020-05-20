using System;
using System.Threading;
using System.Windows.Forms;

namespace PrimeNumbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Range
        {
            public int from, to;

            public Range() { }

            public Range(int from, int to)
            {
                this.from = from;
                this.to = to;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            int parts = trackBar1.Value;
            uint from, to;

            try
            {
                from = Convert.ToUInt32(textBox1.Text);
                to = Convert.ToUInt32(textBox2.Text);
                if (from > to)
                {
                    throw new Exception("Лицам до 18 регистрация запрещена");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Входные данные - положительные, целые числа");
                
            }
            catch (OverflowException)
            {
                MessageBox.Show("Входные данные - положительные, целые числа");
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный диапозон");
            }

            switch (parts)
            {
                case 1:
                    Range nor = new Range();
                    nor.from = Convert.ToInt32(textBox1.Text);
                    nor.to = Convert.ToInt32(textBox2.Text);
                    Thread thread1 = new Thread(new ParameterizedThreadStart(prime));
                    thread1.Start(nor);
                    break;
                case 2:
                    Range nor21 = new Range();
                    nor21.from = Convert.ToInt32(textBox1.Text);
                    nor21.to = Convert.ToInt32(textBox2.Text)/2;
                    Thread thread2 = new Thread(new ParameterizedThreadStart(prime));
                    thread2.Start(nor21);

                    Range nor22 = new Range();
                    nor22.from = Convert.ToInt32(textBox2.Text) / 2 + 1;
                    nor22.to = Convert.ToInt32(textBox2.Text);
                    Thread thread22 = new Thread(new ParameterizedThreadStart(prime));
                    thread22.Start(nor22);
                    break;
                case 3:
                    Range nor31 = new Range();
                    nor31.from = Convert.ToInt32(textBox1.Text);
                    nor31.to = Convert.ToInt32(textBox2.Text) / 3;
                    Thread thread3 = new Thread(new ParameterizedThreadStart(prime));
                    thread3.Start(nor31);

                    Range nor32 = new Range();
                    nor32.from = Convert.ToInt32(textBox2.Text) / 3 + 1;
                    nor32.to = Convert.ToInt32(textBox2.Text) / 3 * 2;
                    Thread thread33 = new Thread(new ParameterizedThreadStart(prime));
                    thread33.Start(nor32);

                    Range nor33 = new Range();
                    nor33.from = Convert.ToInt32(textBox2.Text) / 3 * 2 + 1;
                    nor33.to = Convert.ToInt32(textBox2.Text);
                    Thread thread333 = new Thread(new ParameterizedThreadStart(prime));
                    thread333.Start(nor33);
                    break;
                case 4:
                    Range nor41 = new Range();
                    nor41.from = Convert.ToInt32(textBox1.Text);
                    nor41.to = Convert.ToInt32(textBox2.Text) / 4;
                    Thread thread4 = new Thread(new ParameterizedThreadStart(prime));
                    thread4.Start(nor41);

                    Range nor42 = new Range();
                    nor42.from = Convert.ToInt32(textBox2.Text) / 4 + 1;
                    nor42.to = Convert.ToInt32(textBox2.Text) / 4 * 2;
                    Thread thread44 = new Thread(new ParameterizedThreadStart(prime));
                    thread44.Start(nor42);

                    Range nor43 = new Range();
                    nor43.from = Convert.ToInt32(textBox2.Text) / 4 * 2 + 1;
                    nor43.to = Convert.ToInt32(textBox2.Text) / 4 * 3;
                    Thread thread444 = new Thread(new ParameterizedThreadStart(prime));
                    thread444.Start(nor43);

                    Range nor44 = new Range();
                    nor44.from = Convert.ToInt32(textBox2.Text) / 4 * 3 + 1;
                    nor44.to = Convert.ToInt32(textBox2.Text);
                    Thread thread4444 = new Thread(new ParameterizedThreadStart(prime));
                    thread4444.Start(nor44);
                    break;
                default:
                    break;
            }
        }

        public void prime(object x)
        {
            int from = (x as Range).from;
            int to= (x as Range).to; 

            for (int i = from ; i <= to; i++)
            {
                if (IsPrimeNumber(i))
                {
                    textBox4.Invoke(
                (ThreadStart)delegate ()
                {
                    textBox4.Text += i + " ";
                });
                }
            }
        }

        public static bool IsPrimeNumber(int n)
        {
            var result = true;

            if (n > 1)
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
