using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using ClassLibrary;

namespace View
{
    public partial class MainForm : Form
    {
        public readonly List<IShape> ListShapes = new List<IShape>();

        public MainForm()
        {
            InitializeComponent();
        }

        public void AddListItem (IShape s1)
        {
            ListShapes.Add(s1);
            MainDataGridView.Rows.Add(s1.Name(), s1.Show());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddForm { Owner = this }.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ListShapes.RemoveAt(MainDataGridView.SelectedRows[0].Index);
                MainDataGridView.Rows.RemoveAt(MainDataGridView.SelectedRows[0].Index);
            }
            catch (Exception)
            {
                MessageBox.Show("Выбрана пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#if RandomOn
        private void RandomButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int s1, s2, s3;
            switch (random.Next(3))
            {
                case 0:
                    s1 = random.Next(1, 1000);
                    if (MessageBox.Show($"Шар радиуса {s1}?", 
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        AddListItem(new Ball(s1));
                    }
                    break;
                case 1:
                    s1 = random.Next(1, 1000);
                    s2 = random.Next(1, 1000);
                    if (MessageBox.Show($"Пирамида со площадью основания {s1} и высотой {s2}?",
                        "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        AddListItem(new ClassLibrary.Pyramid(s1, s2));
                    }
                    break;
                case 2:
                    while (true)
                    {
                        int r = random.Next(20, 1000);
                        s1 = r + random.Next(-10, 10);
                        s2 = r + random.Next(-10, 10);
                        s3 = r + random.Next(-10, 10);

                        float p = (s1 + s2 + s3) / (float)2.0;
                        float S = p * (p - s1) * (p - s2) * (p - s3);
                        if (S <= 0)
                            continue;

                        if (MessageBox.Show($"Параллелепипед со сторонами {s1}, {s2} и {s3}?",
                            "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            AddListItem(new Parallelepiped(s1, s2, s3));
                        }

                        break;
                    }
                    break;
            }
        }
#endif
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (ListShapes.Count == 0)
                MessageBox.Show("Список элементов пуст", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else new SearchForm { Owner = this }.ShowDialog();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog.Filter = "shps files (*.shps)|*.shps|All files (*.*)|*.*";
            SaveFileDialog.FilterIndex = 1;
            try
            {
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (SaveFileDialog.FilterIndex == 2)
                    {
                        FileStream file = File.Create($"{SaveFileDialog.FileName}.shps");
                        new BinaryFormatter().Serialize(file, ListShapes);
                        file.Close();
                    }
                    else
                    {
                        FileStream file = File.Create($"{SaveFileDialog.FileName}");
                        new BinaryFormatter().Serialize(file, ListShapes);
                        file.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog.Filter = "shps files (*.shps)|*.shps|All files (*.*)|*.*";
            OpenFileDialog.FilterIndex = 1;
            try
            {
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = File.OpenRead(OpenFileDialog.FileName);
                    List<IShape> Shapes = new BinaryFormatter().Deserialize(file) as List<IShape>;

                    ListShapes.Clear();
                    MainDataGridView.Rows.Clear();

                    if (Shapes != null)
                    {
                        foreach (var item in Shapes)
                        {
                            AddListItem(item);
                        }
                    }
                    file.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
