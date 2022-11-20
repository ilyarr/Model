using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using Ninject;

namespace WinFormsView
{
    public partial class Form1 : Form
    {        
        Form2 f2;

        IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        Logic BL;

        public Form1()
        {
            InitializeComponent();
            listView1.Clear();

            BL = ninjectKernel.Get<Logic>();

            listView1.View = View.Details;

            listView1.Columns.Add("Имя", 150);
            listView1.Columns.Add("Cпециальность", 150);
            listView1.Columns.Add("Группа", 150);

            for (int i = 0; i < BL.ListOfStudents().Count; i += 3)
            {
                ListViewItem newitem = new ListViewItem(BL.ListOfStudents().ElementAt(i));
                newitem.SubItems.Add(BL.ListOfStudents().ElementAt(i + 1));
                newitem.SubItems.Add(BL.ListOfStudents().ElementAt(i + 2));

                listView1.Items.Add(newitem);
            }

            comboBox1.Items.AddRange(new string[] { "ПИ", "ИСИТ", "ПИнж" });
        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 0 && comboBox1.Text.Length != 0 && textBox2.Text.Length != 0)
            {
                BL.AddStudent(textBox3.Text, comboBox1.Text, textBox2.Text);
                ListViewItem additem = new ListViewItem(textBox3.Text);
                additem.SubItems.Add(comboBox1.Text);
                additem.SubItems.Add(textBox2.Text);

                listView1.Items.Add(additem);
                if (f2 != null) f2.UpdateGraphs(BL);
            }
        }

        private void ShowGraphs_Click(object sender, EventArgs e)
        {
            f2 = new Form2(BL);
            f2.Show();
        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {
            if (BL.ListOfStudents().Count != 0)
            {
                BL.DeleteStudent(listView1.SelectedIndices[0]);
                listView1.Items.Remove(listView1.SelectedItems[0]);
                if (f2 != null) f2.UpdateGraphs(BL);
            }
        }
    }
}
