using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GraphPaths
{
    public partial class Form1 : Form
    {
        string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private int size = 40;

        bool isVertexWait = false;
        bool IsClicked = false;
        bool IsNumberWait = false;
        int activeVertex = 1;
        int sourseVertex = 1;

        List<List<int>> matrix = new List<List<int>> { new List<int> { 0 } };
        List<List<int>> FloydMatrix = new List<List<int>>();

        Graphics g;
        Pen pen = new Pen(Color.Black, 4);

        string res;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            pen.EndCap = LineCap.ArrowAnchor;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (redact.Checked)
            {
                if (IsNumberWait)
                {
                    StrokeNumber();
                    return;
                }
                if (isVertexWait)
                {
                    isVertexWait = false;
                    Controls.Find(matrix[0][activeVertex].ToString(), true)[0].BackColor = Color.RosyBrown;
                    return;
                }
                string s = AddVertex().ToString();
                CreateButton(new Point(e.X, e.Y), s);
            }
        }

        private void CreateButton(Point pos, string text)
        {
            RoundButton b = new RoundButton();
            b.MouseUp += new System.Windows.Forms.MouseEventHandler(roundButton1_MouseUp);
            b.MouseClick += new System.Windows.Forms.MouseEventHandler(roundButton1_MouseClick);
            b.MouseDown += new System.Windows.Forms.MouseEventHandler(roundButton1_MouseDown);
            b.Size = new Size(size, size);
            b.Location = new Point(pos.X - size / 2, pos.Y - size / 2);
            b.Text = (IsLetters.Checked) ? GetLetter(int.Parse(text)) : text;
            b.BackColor = Color.RosyBrown;
            b.Name = text;
            this.Controls.Add(b);
        }

        private int AddVertex()
        {
            int n = matrix[matrix.Count - 1][0] + 1;
            matrix.Add(new List<int>());
            matrix[matrix.Count - 1].Add(n);
            for (int i = 1; i < matrix.Count - 1; i++) matrix[matrix.Count - 1].Add(0);
            for (int i = 0; i < matrix.Count; i++) matrix[i].Add(0);
            for (int i = 1; i < matrix.Count; i++) matrix[0][i] = matrix[i][0];
            return n;
        }

        private void DeleteVertex(int n)
        {
            activeVertex = 1;
            sourseVertex = 1;
            int ind = matrix[0].IndexOf(n);
            for (int i = 0; i < matrix.Count; i++) matrix[i].RemoveAt(ind);
            matrix.RemoveAt(ind);
            Controls.Remove((RoundButton)Controls.Find(n.ToString(), true)[0]);

        }

        private void DrawGraph(bool clearing)
        {
            if(clearing) g.Clear(SystemColors.ActiveCaption);

            for (int i = 1; i < matrix.Count; i++)
                ((RoundButton)Controls.Find(matrix[0][i].ToString(), true)[0]).BackColor = Color.RosyBrown;

            for (int i = 1; i < matrix.Count; i++)
            {
                for (int j = 1; j < matrix.Count; j++)
                {
                    if (matrix[i][j] != 0)
                    {
                        RoundButton a = (RoundButton)Controls.Find(matrix[i][0].ToString(), true)[0];
                        RoundButton b = (RoundButton)Controls.Find(matrix[0][j].ToString(), true)[0];

                        if (IsOriented.Checked)
                        {
                            int dx = b.Location.X - a.Location.X;
                            int dy = b.Location.Y - a.Location.Y;

                            float dl = (float)Math.Sqrt(dx * dx + dy * dy);

                            float delta = 1 - 22f / dl;

                            if (matrix[i][j] != 0 && matrix[j][i] == 0)
                                g.DrawLine(pen, a.Location.X + size / 2, a.Location.Y + size / 2, size / 2 + a.Location.X + (int)(dx * delta), size / 2 + a.Location.Y + (int)(dy * delta));
                            else if (matrix[i][j] == 0 && matrix[j][i] != 0)
                                g.DrawLine(pen, b.Location.X + size / 2, b.Location.Y + size / 2, size / 2 + b.Location.X - (int)(dx * delta), size / 2 + b.Location.Y - (int)(dy * delta));
                            else
                                g.DrawLine(pen, a.Location.X + size / 2, a.Location.Y + size / 2, b.Location.X + size / 2, b.Location.Y + size / 2);

                            g.DrawString(matrix[i][j].ToString(), new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Blue), a.Location.X + dx / 2, a.Location.Y + dy / 2);
                        }
                        else
                        {
                            g.DrawLine(pen, a.Location.X + size / 2, a.Location.Y + size / 2, b.Location.X + size / 2, b.Location.Y + size / 2);
                        }
                    }
                }
            }
        }

        private void roundButton1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (redact.Checked)
                {
                    DeleteVertex(int.Parse(((RoundButton)sender).Name));
                    //Controls.Remove((Button)sender);
                    DrawGraph(true);
                    return;
                }
                if (distances.Checked)
                {
                    sourseVertex = matrix[0].IndexOf(int.Parse(((RoundButton)sender).Name));
                    DrawGraph(true);
                    //DrawDistance();
                    distances_CheckedChanged(sender, e);
                }
            }
        }

        private void roundButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsClicked)
            {
                IsClicked = false;
                return;
            }
            if (redact.Checked)
            {
                ((RoundButton)sender).Location = new Point(MousePosition.X - this.Location.X - 19, MousePosition.Y - this.Location.Y - 39);
                DrawGraph(true);
                //if (distances.Checked) DrawDistance();
            }
        }

        private void roundButton1_MouseClick(object sender, MouseEventArgs e)
        {
            IsClicked = true;
            if (redact.Checked)
            {
                if (IsNumberWait)
                {
                    StrokeNumber();
                    return;
                }
                if (isVertexWait)
                {
                    sourseVertex = matrix[0].IndexOf(int.Parse(((RoundButton)sender).Name));
                    if (sourseVertex == activeVertex) return;
                    System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox
                    {
                        Text = (matrix[activeVertex][sourseVertex] == 0) ? "1" : matrix[activeVertex][sourseVertex].ToString(),
                        Name = "inputBox",
                        Location = new Point(((RoundButton)sender).Location.X, ((RoundButton)sender).Location.Y - 30)
                    };
                    this.Controls.Add(tb);
                    tb.Focus();
                    isVertexWait = false;
                    IsNumberWait = true;
                    Controls.Find(matrix[0][activeVertex].ToString(), true)[0].BackColor = Color.RosyBrown;
                    return;
                }
                isVertexWait = true;
                ((RoundButton)sender).BackColor = Color.Yellow;
                activeVertex = matrix[0].IndexOf(int.Parse(((RoundButton)sender).Name));
            }
            if (distances.Checked)
            {
                activeVertex = matrix[0].IndexOf(int.Parse(((RoundButton)sender).Name));
                DrawGraph(true);
                //DrawDistance();
                distances_CheckedChanged(sender, e);
            }
        }

        private void StrokeNumber()
        {
            if (IsNumberWait)
            {
                System.Windows.Forms.TextBox inBox = (System.Windows.Forms.TextBox)Controls.Find("inputBox", true)[0];
                int value;
                try
                {
                    value = int.Parse(inBox.Text);
                }
                catch { value = 1; }
                if (IsOriented.Checked)
                {
                    matrix[activeVertex][sourseVertex] = value;
                    matrix[sourseVertex][activeVertex] = 0;
                }
                else
                {
                    matrix[activeVertex][sourseVertex] = value;
                    matrix[sourseVertex][activeVertex] = value;
                }
                Controls.Remove(inBox);
                DrawGraph(true);
                isVertexWait = false;
                IsNumberWait = false;
                Controls.Find(matrix[0][activeVertex].ToString(), true)[0].BackColor = Color.RosyBrown;
            }
        }

        private string GetLetter(int n)
        {
            string res = "";
            if (n == 0) return "0";
            while (n > 0)
            {
                if (n > 26) res += "A";
                else res += ABC[n - 1];
                n -= 26;
            }
            return res;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void DeleteGraph()
        {
            while (matrix.Count != 1)
            {
                DeleteVertex(matrix[0][1]);
            }
            DrawGraph(true);
            activeVertex = 1;
            sourseVertex = 1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (IsNumberWait)
                {
                    StrokeNumber();
                    return;
                }
            }
        }

        private void IsLetters_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < matrix.Count(); i++)
            {
                RoundButton b = (RoundButton)Controls.Find(matrix[0][i].ToString(), true)[0];

                if (IsLetters.Checked) b.Text = GetLetter(matrix[0][i]);
                else b.Text = b.Name;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("graphsFile.txt"))
            {
                string s = ReadGraphs("graphsFile.txt");
                string[] names = GetGraphNames(s);
                comboBox1.Items.Clear();
                foreach (var w in names) if (w != null) comboBox1.Items.Add(w);
            }
        }


        // С О Х Р А Н Е Н И Я

        private void button2_Click(object sender, EventArgs e)
        {
            if (matrix.Count < 2)
            {
                MessageBox.Show("Пустой граф нельзя сохранить");
                return;
            }

            string graphName = textBox1.Text;

            if (graphName.Length == 0)
            {
                MessageBox.Show("Имя графа не может быть пустым");
                return;
            }
            string s = "";
            string h;
            if (File.Exists("graphsFile.txt"))
            {
                s = ReadGraphs("graphsFile.txt");
                string[] names = GetGraphNames(s);
                if (names.Contains(graphName))
                {
                    if (MessageBox.Show("Такое имя графа уже существует\nИзменить граф?", "Изменение графа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int ind = Array.IndexOf(names, graphName);
                        string[] graphs = s.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        //s = s.Replace("\n", "\n");
                        h = GraphToString(graphName);
                        for (int i = 0; i < graphs.Length; i++)
                        {
                            if (graphs[i].Split('+')[0].Replace("\n", "") == graphName)
                            {
                                graphs[i] = h;
                                break;
                            }
                        }
                        s = String.Join("/", graphs);
                        WriteGraphs("graphsFile.txt", s);

                        MessageBox.Show("Успешно");
                    }
                    return;
                }
            }

            h = GraphToString(graphName);
            s += "/" + h;

            WriteGraphs("graphsFile.txt", s);

            comboBox1.Items.Add(graphName);

            MessageBox.Show("Успешно");
        }

        private string GraphToString(string graphName)
        {
            string s = "";
            string matr = PrintMatrix(matrix, false);
            string pos = "";
            for (int i = 1; i < matrix.Count; i++)
            {
                RoundButton b = (RoundButton)Controls.Find(matrix[0][i].ToString(), true)[0];
                pos += b.Location.X + " " + b.Location.Y;
                pos += "\n";
            }
            string curGraphString = "\n" + graphName + "\n+\n" + matr + "+\n" + pos;
            s += curGraphString;
            return s;
        }

        private string ReadGraphs(string filename)
        {
            string s = "";
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    s = sr.ReadToEnd();
                }
            }
            catch { MessageBox.Show("Непредвиденная ошибка при загрузке данных"); }
            return s;
        }
        private void WriteGraphs(string filename, string graphsString)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(filename, false))
                {
                    sr.Write(graphsString);
                }
            }
            catch { MessageBox.Show("Непридвиденная ошибка при сохранении данных"); }
        }
        private string[] GetGraphNames(string s)
        {
            s = s.Replace("\n", "");
            string[] graphs = s.Split('/');
            string[] names = new string[graphs.Length];
            for (int i = 0; i < graphs.Length; i++)
                if (graphs[i].Length > 4) names[i] = graphs[i].Split('+')[0].Replace("\n", "");
            return names;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Для начала, выберите какой - либо граф из спика");
                return;
            }

            string s = ReadGraphs("graphsFile.txt");
            //s = s.Replace("\r\n", "\n");

            List<string> graphs = s.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            graphs.RemoveAt(comboBox1.SelectedIndex);
            s = string.Join("/", graphs);

            WriteGraphs("graphsFile.txt", s);

            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            comboBox1.SelectedIndex = -1;

            DeleteGraph();

            MessageBox.Show("Успешно");
        }

        private void MatrixButton_Click(object sender, EventArgs e)
        {
            PrintMatrix(matrix, true);
        }


        // В Ы В О Д  М А Т Р И Ц Ы

        private string PrintMatrix(List<List<int>> arr, bool IsShowing)
        {
            string s = "";
            string sOut = "";
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Count; j++)
                {
                    if(i == 0 || j == 0)
                    {
                        s += arr[i][j] + " ";
                        sOut += (IsLetters.Checked) ? GetLetter(arr[i][j]) + "\t" : arr[i][j] + "\t";
                    }
                    else
                    {
                        s += arr[i][j] + " ";
                        sOut += arr[i][j] + "\t";
                    }
                }
                s += "\n";
                sOut += "\r\n";
            }

            if (IsShowing)
            {
                Form2 f2 = new Form2();
                f2.Controls.Find("textBox1", true)[0].Text = sOut;
                f2.Show();
            }

            return s;
        }
        private string PrintMatrix(List<int> arr, bool IsShowing)
        {
            string s = "";
            string sOut = "";
            for (int i = 0; i < arr.Count; i++)
            {
                s += (IsLetters.Checked) ? GetLetter(arr[i]) + " " : arr[i] + " ";
                sOut += (IsLetters.Checked) ? GetLetter(arr[i]) + " " : arr[i] + " ";
            }
            s += "\n";
            sOut += "\r\n";

            if (IsShowing)
            {
                Form2 f2 = new Form2();
                f2.Controls.Find("textBox1", true)[0].Text = sOut;
                f2.Show();
            }

            return s;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;

            DeleteGraph();

            string graphname = comboBox1.Text;
            string s = ReadGraphs("graphsFile.txt");
            //s = s.Replace("\n", "\n");
            string[] graphs = s.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < graphs.Length; i++)
            {
                string[] curGraph = graphs[i].Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                //Парсинг имени
                curGraph[0] = curGraph[0].Replace("\n", "");
                if (curGraph[0] == graphname)
                {
                    //Парсинг матрицы
                    string[] rows = curGraph[1].Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    matrix = new List<List<int>>();
                    for (int j = 0; j < rows.Length; j++)
                    {
                        string[] items = rows[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        matrix.Add(new List<int>());
                        for (int x = 0; x < items.Length; x++)
                        {
                            matrix[matrix.Count - 1].Add(int.Parse(items[x]));
                        }
                    }

                    //Парсинг позиций
                    string[] posns = curGraph[2].Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < posns.Length; j++)
                    {
                        string[] curPos = posns[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        RoundButton b = new RoundButton();
                        b.MouseUp += new System.Windows.Forms.MouseEventHandler(roundButton1_MouseUp);
                        b.MouseClick += new System.Windows.Forms.MouseEventHandler(roundButton1_MouseClick);
                        b.MouseDown += new System.Windows.Forms.MouseEventHandler(roundButton1_MouseDown);
                        b.Size = new Size(size, size);
                        b.Location = new Point(int.Parse(curPos[0]), int.Parse(curPos[1]));
                        b.Text = matrix[0][j + 1].ToString();
                        b.Name = matrix[0][j + 1].ToString();
                        this.Controls.Add(b);
                    }

                    //Вывод графа

                    DrawGraph(true);
                    redact.Checked = true;

                    break;
                }
            }
        }

        private void WayDraw(int start, int finish, List<int> path)
        {
            g.Clear(SystemColors.ActiveCaption);
            RoundButton SB = (RoundButton)Controls.Find(matrix[0][activeVertex].ToString(), true)[0];
            RoundButton FB = (RoundButton)Controls.Find(matrix[0][sourseVertex].ToString(), true)[0];

            for(int i = 1; i < path.Count(); i++)
            {
                RoundButton a = (RoundButton)Controls.Find(matrix[0][path[i - 1]].ToString(), true)[0];
                RoundButton b = (RoundButton)Controls.Find(matrix[0][path[i]].ToString(), true)[0];

                g.DrawLine(new Pen(Color.Yellow, 10), a.Location.X + size / 2, a.Location.Y + size / 2, b.Location.X + size / 2, b.Location.Y + size / 2);
            }
            DrawGraph(false);

            SB.BackColor = Color.Yellow;
            FB.BackColor = Color.Magenta;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteGraph();
            isVertexWait = false;
            activeVertex = 1; sourseVertex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", "graphsFile.txt");
            }
            catch { MessageBox.Show("Не удаётся открыть файл"); }
        }



        // ПОИСК КРАТЧАЙШИХ ПУТЕЙ

        private void Dijkstra()
        {
            List<int> d = new List<int>();
            for (int i = 0; i < matrix.Count; i++) d.Add(100000);
            d[activeVertex] = 0;

            List<bool> u = new List<bool>();
            for (int i = 0; i < matrix.Count; i++) u.Add(false);
            u[0] = true;

            List<int> p = new List<int>();
            for (int i = 0; i < matrix.Count; i++) p.Add(-1);

            while(u.IndexOf(false) > 0)
            {
                int v = 1;
                int minim = 1000000;
                for(int i = 1; i < d.Count; i++)
                {
                    if (!u[i] && d[i] < minim)
                    {
                        v = i; minim = d[i];
                    }
                }

                for(int to = 1; to < matrix.Count; to++)
                {
                    if (matrix[v][to] > 0 && !u[to])
                    {
                        int len = matrix[v][to];
                        if (d[v] + len < d[to])
                        {
                            d[to] = d[v] + len;
                            p[to] = v;
                        }
                    }
                }

                u[v] = true;
            }

            List<int> wayBack = new List<int>();
            int length = 0;

            if (activeVertex != sourseVertex)
            {
                length = d[sourseVertex];
                int pt = sourseVertex;
                wayBack.Add(pt);
                while (p[pt] != activeVertex)
                {
                    wayBack.Add(p[pt]);
                    pt = p[pt];
                    if(pt == -1)
                    {
                        WayDraw(activeVertex, sourseVertex, new List<int>());
                        res = "Невозможно найти путь";
                        return;
                    }
                }
                wayBack.Add(activeVertex);
                wayBack.Reverse();
            }

            res = "Длина пути из " + ((IsLetters.Checked) ? GetLetter(activeVertex) : activeVertex.ToString()) + " в " +
                                    ((IsLetters.Checked) ? GetLetter(sourseVertex) : sourseVertex.ToString()) + ": " + length + "\n";
            res += PrintMatrix(wayBack, false);
            WayDraw(activeVertex, sourseVertex, wayBack);
        }

        private void Floyd_Algorithm()
        {
            List<List<int>> d = new List<List<int>>();
            for(int i = 0; i < matrix.Count; i++)
            {
                d.Add(new List<int>());
                for (int j = 0; j < matrix.Count; j++)
                {
                    if(i == 0 || j == 0) d[d.Count - 1].Add(matrix[i][j]);
                    else if (matrix[i][j] > 0) d[d.Count - 1].Add(matrix[i][j]);
                    else d[d.Count - 1].Add(100000);
                }
            }

            for (int k = 1; k < matrix.Count; k++)
            {
                for(int i = 1; i < matrix.Count; i++)
                {
                    for(int j = 1; j < matrix.Count; j++)
                    {
                        if (d[i][k] + d[k][j] < d[i][j])
                        {
                            d[i][j] = d[i][k] + d[k][j];
                        }
                    }
                }
            }

            FloydMatrix = d;

            List<int> wayBack = WayBackFromTable(activeVertex, sourseVertex, d);
            if (d[activeVertex][sourseVertex] >= 100000)
            {
                res = "Пути не существует";
                WayDraw(activeVertex, sourseVertex, wayBack);
                return;
            }

            res = "Длина пути из " + ((IsLetters.Checked) ? GetLetter(activeVertex) : activeVertex.ToString()) + " в " +
                                    ((IsLetters.Checked) ? GetLetter(sourseVertex) : sourseVertex.ToString()) + ": " + d[activeVertex][sourseVertex] + "\n";
            res += PrintMatrix(wayBack, false);
            WayDraw(activeVertex, sourseVertex, wayBack);
        }
        private List<int> WayBackFromTable(int from, int to, List<List<int>> d)
        {
            if (matrix[from][to] > 0) return new List<int>() { from, to };
            int dist = d[from][to];
            if(dist >= 100000) return new List<int>();
            List<int> way = new List<int>();
            for(int i = 1; i < d.Count; i++)
            {
                if (d[from][i] + d[i][to] == dist)
                {
                    List<int> w1 = WayBackFromTable(from, i, d);
                    List<int> w2 = WayBackFromTable(i, to, d);
                    foreach(var j in w1) if(!way.Contains(j)) way.Add(j);
                    foreach(var j in w2) if(!way.Contains(j)) way.Add(j);
                    break;
                }
            }
            return way;
        }

        private void Ford_Bellman()
        {
            List<int> d = new List<int>();
            for (int i = 0; i < matrix.Count; i++) d.Add(100000);
            d[activeVertex] = 0;

            List<int> p = new List<int>();
            for (int i = 0; i < matrix.Count; i++) p.Add(-1);

            for (int iter = 1; iter < matrix.Count; iter++)
            {
                for(int v = 1; v < matrix.Count; v++)
                {
                    for(int to = 1; to < matrix.Count; to++)
                    {
                        if (matrix[v][to] != 0)
                        {
                            int len = matrix[v][to];
                            if (d[v] + len < d[to])
                            {
                                d[to] = d[v] + len;
                                p[to] = v;
                            }
                        }
                    }
                }
            }

            //MessageBox.Show(PrintMatrix(d, false));

            List<int> wayBack = new List<int>();
            int length = 0;

            if (activeVertex != sourseVertex)
            {
                length = d[sourseVertex];
                int pt = sourseVertex;
                wayBack.Add(pt);
                while (p[pt] != activeVertex)
                {
                    wayBack.Add(p[pt]);
                    pt = p[pt];
                    if (pt == -1 || wayBack.Count > matrix.Count + 2)
                    {
                        WayDraw(activeVertex, sourseVertex, new List<int>());
                        res = "Невозможно найти путь";
                        return;
                    }
                }
                wayBack.Add(activeVertex);
                wayBack.Reverse();
            }

            res = "Длина пути из " + ((IsLetters.Checked) ? GetLetter(activeVertex) : activeVertex.ToString()) + " в " +
                                    ((IsLetters.Checked) ? GetLetter(sourseVertex) : sourseVertex.ToString()) + ": " + length + "\n";
            res += PrintMatrix(wayBack, false);
            WayDraw(activeVertex, sourseVertex, wayBack);

            //Финальная итерация
            for (int v = 1; v < matrix.Count; v++)
            {
                for (int to = 1; to < matrix.Count; to++)
                {
                    if (matrix[v][to] != 0)
                    {
                        int len = matrix[v][to];
                        if (d[v] + len < d[to])
                        {
                            d[to] = d[v] + len;
                            MessageBox.Show("Есть цикл отрицательного веса");
                            return;
                        }
                    }
                }
            }
        }

        private void distances_CheckedChanged(object sender, EventArgs e)
        {
            res = "";
            if (matrix.Count < 2) return;
            if (!distances.Checked) return;

            if (Deykstra.Checked)
            {
                Dijkstra();
            }

            if (Floyd.Checked)
            {
                Floyd_Algorithm();
            }

            if (FordBellman.Checked)
            {
                Ford_Bellman();
            }
        }

        private void redact_CheckedChanged(object sender, EventArgs e)
        {
            if(!redact.Checked) return;

            DrawGraph(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(res);
        }

        private void floydMatrix_Click(object sender, EventArgs e)
        {
            PrintMatrix(FloydMatrix, true);
        }

        private void Deykstra_CheckedChanged(object sender, EventArgs e)
        {
            distances_CheckedChanged(sender, e);
        }

        private void Floyd_CheckedChanged(object sender, EventArgs e)
        {
            distances_CheckedChanged(sender, e);
        }

        private void FordBellman_CheckedChanged(object sender, EventArgs e)
        {
            distances_CheckedChanged(sender, e);
        }
    }
}
