namespace Lab15_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "Первый";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "Второй";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "Третий";
        }

        private void SetStartLabel(object sender, EventArgs e)
        {
            label2.Text = "Начало работы";
        }
        private void SetEndLabel(object sender, EventArgs e)
        {
            label2.Text = "Конец работы";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var inputRub = Convert.ToInt32(textBox1.Text);
            var distant = Convert.ToInt32(textBox2.Text);
            var costForOne = Convert.ToInt32(textBox3.Text);
            double oilVolume = distant / 10;
            var totalCost = costForOne * oilVolume;
            if (inputRub >= totalCost)
            {
                label5.Text = "Бензина хватит";
            }
            else
            {
                label5.Text = "Бензина не хватает";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var text = "";
            for (var i = 100; i < 1000; i++)
            {
                var num = i;
                var temp1 = num % 10;
                num /= 10;
                var temp2 = num % 10;
                if (temp1 > temp2)
                {
                    text += i + " ";
                }
            }
            label9.Text = text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = Convert.ToDouble(textBox4.Text);
            var b = Convert.ToDouble(textBox5.Text);
            var h = Convert.ToDouble(textBox6.Text);

            var perimetr = a + b + 2 * h;
            var square = (a + b) / 2 * h;

            if (checkBox1.Checked)
            {
                perimetr = Math.Round(perimetr);
                square = Math.Round(square);
            }
            label15.Text = $"Perimetr: {perimetr}";
            label14.Text = $"Square: {square}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = new List<Distantion>();
            for (var i = 1; i < 21; i++)
            {
                list.Add(new Distantion(i, Math.Round(i * 0.621371, 2)));
            }
            dataGridView1.DataSource = list;
        }
        private class Distantion
        {
            public int Km { get; set; }
            public double Mili { get; set; }

            public Distantion(int km, double mili)
            {
                Km=km;
                Mili=mili;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var m = Convert.ToInt32(textBox7.Text);
            var n = Convert.ToInt32(textBox8.Text);
            var a = Convert.ToInt32(textBox9.Text);
            var b = Convert.ToInt32(textBox10.Text);
            var array = new int[m, n];
            var rnd = new Random();
            var minSum = 999999;
            var numberRow = 0;
            var maxFromMinSum = 0;
            for (int i = 0; i < m; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rnd.Next(a, b);
                    list.Add(array[i, j]);
                }
                if (list.Sum() < minSum)
                {
                    minSum = list.Sum();
                    numberRow = i + 1;
                    maxFromMinSum = list.Max();
                }
            }


            for (int i = 0; i < n; i++)
            {
                string column = string.Format($"Column{i + 1}");
                dataGridView2.Columns.Add(column, column);
            }
            for (int row = 0; row < m; row++)
            {
                string[] currentColumn = new string[n];

                for (int col = 0; col < n; col++)
                    currentColumn[col] = array[row, col].ToString();

                dataGridView2.Rows.Add(currentColumn);
            }

            label22.Text = $"Row: {numberRow} | Sum: {minSum} | Max: {maxFromMinSum}";
        }
    }
}