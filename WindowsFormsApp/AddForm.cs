using System;
using System.Windows.Forms;

using ClassLibrary;

namespace View
{
    public partial class AddForm : Form
    {
        int Index = -1;

        public AddForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Index = CoiceComboBox.SelectedIndex;

            label1.Visible = true;
            textBox1.Visible = true;

            if (Index == 0)
            {
                label1.Text = "Радиус";

                label2.Visible = false;
                label3.Visible = false;

                textBox2.Visible = false;
                textBox3.Visible = false;
            }
            else if (Index == 1)
            {
                label1.Text = "Площадь основания";
                label2.Text = "Высота";

                label2.Visible = true;
                label3.Visible = false;

                textBox2.Visible = true;
                textBox3.Visible = false;
            }
            else if (Index == 2)
            {
                label1.Text = "Сторона 1";
                label2.Text = "Сторона 2";
                label3.Text = "Сторона 3";

                label2.Visible = true;
                label3.Visible = true;

                textBox2.Visible = true;
                textBox3.Visible = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            MainForm MainForm = (MainForm)Owner;

            try
            {
                if (Index == -1)
                    throw new Exception("Произведите выбор фигуры");
                else if (Index == 0)
                {
                    if (textBox1.Text != "")
                        MainForm.AddListItem(new Ball(float.Parse(textBox1.Text)));
                    else throw new Exception("Данные не введены");
                }
                else if (Index == 1)
                {
                    if (textBox1.Text != "")
                        MainForm.AddListItem(new ClassLibrary.Pyramid(float.Parse(textBox1.Text), float.Parse(textBox2.Text)));
                    else throw new Exception("Данные не введены");
                }
                else if (Index == 2)
                {
                    if (textBox1.Text != "")
                    {
                        IShape S1 = new Parallelepiped(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                        S1.Volume();
                        MainForm.AddListItem(S1);
                    }
                    else throw new Exception("Данные не введены");
                }
                Close();
            }
            catch (Exception exp)
            { 
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
