using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_1_Francisco_Argueta
{
    public partial class Form1 : Form
    {
        List<estudiante> estu = new List<estudiante>();
        List<libros> li = new List<libros>();
        Boolean h = false;
        int c= 0;
        public Form1()
        {
            InitializeComponent();
        }
        void escribirestudiante()
        {
            FileStream stream = new FileStream("estudiante.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in estu)
            {
                write.WriteLine(d.Carnet1);
                write.WriteLine(d.Nombre);
                write.WriteLine(d.Direc);
                
            }
            write.Close();
        }
        void leerestudiantes()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "estudiante.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                estudiante a = new estudiante();
                a.Carnet1 = reader.ReadLine();
                a.Nombre = reader.ReadLine();
                a.Direc = reader.ReadLine();
                estu.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = estu;
                dataGridView1.Refresh();
            }
            reader.Close();
        }
        void escribirlibros()
        {
            FileStream stream = new FileStream("libros.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in li)
            {
                write.WriteLine(d.Codigo);
                write.WriteLine(d.Tiulo);
                write.WriteLine(d.Autor);
                write.WriteLine(d.FechaN);
                write.WriteLine(d.FechaS);
                write.WriteLine(d.Año);

            }
            write.Close();
        }
        void leerlibro()
        {
            OpenFileDialog op = new OpenFileDialog();
            string filename = "libros.txt";
            FileStream st = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                libros a = new libros();
                a.Codigo = reader.ReadLine();
                a.Tiulo = reader.ReadLine();
                a.Autor = reader.ReadLine();
                a.FechaN = reader.ReadLine();
                a.FechaS = reader.ReadLine();
                a.Año = reader.ReadLine();
                li.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = estu;
                dataGridView1.Refresh();
            }
            reader.Close();
        }
        void agregar()
        {
            estudiante a = new estudiante();
            a.Carnet1 = textBox1.Text;
            a.Nombre = textBox2.Text;
            a.Direc = textBox3.Text;
            
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                agregar();
                //repetidos();
                estudiante f = new estudiante();
                libros s = new libros();
                if (h)
                {
                    MessageBox.Show("el carnet ya esta en uso");
                    textBox1.Clear();
                }
                else
                {
                    s.Codigo = textBox4.Text;
                    s.Tiulo = textBox5.Text;
                    s.Autor = textBox6.Text;
                    s.Año = textBox7.Text;
                    s.FechaN = dateTimePicker1.Value.ToString();
                    s.FechaS = dateTimePicker2.Value.ToString();
                    f.Carnet1 = textBox1.Text;
                    f.Nombre = textBox2.Text;
                    f.Direc = textBox3.Text;
                    
                    estu.Add(f);
                    li.Add(s);
                    MessageBox.Show("Se ha agregado correctamente en la base de datos");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    escribirlibros();
                    escribirestudiante();
                }
            }
            else
            {
                MessageBox.Show("Debe de llenar todos los campos");
            }
            h = false;
            c = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerestudiantes();
            leerlibro();
        }
    }
    }

