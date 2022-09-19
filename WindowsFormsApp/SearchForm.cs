using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ClassLibrary;

namespace View
{
    public partial class SearchForm : Form
    {
        int Index = -1;
        public readonly List<IShape> ListFind = new List<IShape>();
        

        public SearchForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            MainForm MainForm = (MainForm)Owner;
            MainForm.MainDataGridView.Rows.Clear();
            foreach (IShape item in MainForm.ListShapes)
            {
                MainForm.MainDataGridView.Rows.Add(item.Name(), item.Show());
            }
            Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            MainForm MainForm = (MainForm)Owner;
            MainForm.MainDataGridView.Rows.Clear();
            ListFind.Clear();
            try
            {
                if (Index == -1)
                    throw new Exception("Произведите выбор фигуры");
                else if (Index == 0)
                {
                    if (textBox1.Text != "")
                    {
                        foreach (var item in MainForm.ListShapes)
                        {
                            if (item.Volume() >= float.Parse(textBox1.Text) && item.Volume() <= float.Parse(textBox2.Text)
                                && item.Name() == "Шар")
                                ListFind.Add(item);
                        }
                        foreach (IShape figure in ListFind)
                        {
                            MainForm.MainDataGridView.Rows.Add(figure.Name(), figure.Show());
                        }
                    }
                    else throw new Exception("Данные не введены");
                }
                else if (Index == 1)
                {
                    if (textBox1.Text != "")
                    {
                        foreach (var item in MainForm.ListShapes)
                        {
                            if (item.Volume() >= float.Parse(textBox1.Text) && item.Volume() <= float.Parse(textBox2.Text)
                                && item.Name() == "Пирамида")
                                ListFind.Add(item);
                        }
                        foreach (IShape figure in ListFind)
                        {
                            MainForm.MainDataGridView.Rows.Add(figure.Name(), figure.Show());
                        }
                    }
                    else throw new Exception("Данные не введены");
                }
                else if (Index == 2)
                {
                    if (textBox1.Text != "")
                    {
                        foreach (var item in MainForm.ListShapes)
                        {
                            if (item.Volume() >= float.Parse(textBox1.Text) && item.Volume() <= float.Parse(textBox2.Text)
                                && item.Name() == "Параллелепипед")
                                ListFind.Add(item);
                        }
                        foreach (IShape figure in ListFind)
                        {
                            MainForm.MainDataGridView.Rows.Add(figure.Name(), figure.Show());
                        }
                    }
                    else throw new Exception("Данные не введены");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Index = SearchComboBox.SelectedIndex;
        }
    }
}
