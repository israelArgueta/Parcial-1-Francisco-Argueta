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
        List<prestamos> pre = new List<prestamos>();
        Boolean h = false;
        Boolean l = false;
        int ls = 0;
        Boolean es = false;
        int et = 0;
        Boolean p = false;
        int pd = 0;
        Boolean p1 = false;
        int pd1 = 0;
        Boolean p2 = false;
        int pd2 = 0;
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
                a.Año = reader.ReadLine();
                li.Add(a);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = li;
                dataGridView1.Refresh();
            }
            reader.Close();
        }
        void escribirPrestamo()
        {
            FileStream stream = new FileStream("prestamos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter write = new StreamWriter(stream);
            foreach (var d in pre)
            {
                write.WriteLine(d.Nom);
                write.WriteLine(d.Libro);
                write.WriteLine(d.FechN);
                write.WriteLine(d.FechS);
            }
            write.Close();
        }

        void leerPrestamo()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName = "prestamos.txt";
            FileStream st = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(st);
            while (reader.Peek() > -1)
            {
                prestamos d = new prestamos();
                d.Nom = reader.ReadLine();
                d.Libro = reader.ReadLine();
                d.FechN = reader.ReadLine();
                d.FechS = reader.ReadLine();
                pre.Add(d);
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
      

        void repetidosLibros()
        {
            while (l == false && ls < li.Count)
            {
                if (li[ls].Codigo.CompareTo(textBox4.Text) == 0)
                {
                    l = true;
                }
                else
                {
                    ls++;
                }
            }
        }

        void repetidosPrestamos()
        {
            while (p == false && pd < pre.Count)
            {
                if (pre[pd].Nom.CompareTo(textBox9.Text) == 0)
                {
                    p = true;
                }
                else
                {
                    pd++;
                }
            }
        }
        void repetidosEstudiantes()
        {
            while (es == false && et < estu.Count)
            {
                if (estu[et].Carnet1.CompareTo(textBox1.Text) == 0)
                {
                    es = true;
                }
                else
                {
                    et++;
                }
            }
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
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leerestudiantes();
            leerlibro();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                prestamos d = new prestamos();
                
                d.Nom = textBox9.Text;
               
                leerlibro();
                if (p1)
                {
                    d.Libro = textBox8.Text;
                    
                    leerestudiantes();
                    if (p2)
                    {
                        repetidosPrestamos();
                        if (p)
                        {
                            MessageBox.Show("El libro con el código introducido ya se encuentra prestado");
                            textBox8.Clear();
                            p = false;
                            pd = 0;
                        }
                        else
                        {
                            d.FechN = dateTimePicker1.Value.ToString();
                            d.FechS = dateTimePicker2.Value.ToString();
                            
                            pre.Add(d);
                            escribirPrestamo();
                            
                           
                            pd = 0;
                            textBox8.Clear();
                            textBox9.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estudiante introducido no se encuentra en la base de datos");
                        textBox8.Clear();
                        p2 = false;
                        pd2 = 0;
                    }
                }
                else
                {
                    MessageBox.Show("El libro introducido no se encuentra en la base de datos");
                    textBox9.Clear();
                    p1 = false;
                    pd1 = 0;
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }

        }
    }
    }

