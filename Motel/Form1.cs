using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motel.Model;

namespace Motel
{
    public partial class Form1 : Form
    {
        MyModel db = new MyModel();
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                if (MessageBox.Show("Удалить запись", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = (int)dataGridView1[0, index].Value;
                    Clients row = db.Clients.Find(id);
                    db.Clients.Remove(row);
                    db.SaveChanges();
                    LoadDate();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "motelDataSet.ViewType". При необходимости она может быть перемещена или удалена.
            this.viewTypeTableAdapter.Fill(this.motelDataSet.ViewType);
            dataGridView1.DataSource = db.Clients.ToList();
            dataGridView2.DataSource = db.Numbers.ToList();
            dataGridView3.DataSource = db.Registrations.ToList();
            comboBox1.DataSource = db.Numbers.ToList();
        }
        private void LoadDate()
        {
            comboBox1.DataSource = db.Numbers.ToList();
            dataGridView1.DataSource = db.Clients.ToList();
            dataGridView2.DataSource = db.Numbers.ToList();
            dataGridView3.DataSource = db.Registrations.ToList();
            viewTypeTableAdapter.Fill(motelDataSet.ViewType);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fClient f = new fClient();
            if(f.ShowDialog()==DialogResult.OK)
            {
                Clients row = new Clients();
                row.FName = f.textBox1.Text;
                row.LName = f.textBox2.Text;
                row.MName = f.textBox3.Text;
                row.Phone = f.textBox4.Text;
                row.Address = f.textBox5.Text;
                row.PassNumber = f.textBox6.Text;
                db.Clients.Add(row);
                db.SaveChanges();
                LoadDate();
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = (int)dataGridView1[0, index].Value;
                Clients row = db.Clients.Find(id);
                fClient f = new fClient();
                f.textBox1.Text = row.FName;
                f.textBox2.Text = row.LName;
                f.textBox3.Text = row.MName;
                f.textBox4.Text = row.Phone;
                f.textBox5.Text = row.Address;
                f.textBox6.Text = row.PassNumber;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    row.FName = f.textBox1.Text;
                    row.LName = f.textBox2.Text;
                    row.MName = f.textBox3.Text;
                    row.Phone = f.textBox4.Text;
                    row.Address = f.textBox5.Text;
                    row.PassNumber = f.textBox6.Text;
                    db.Entry(row).State=System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    LoadDate();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fNumber f = new fNumber();
            if(f.ShowDialog()==DialogResult.OK)
            {
                Numbers row = new Numbers();
                row.Type_number = f.textBox1.Text;
                row.Cost = Convert.ToInt16(f.textBox2.Text);
                db.Numbers.Add(row);
                db.SaveChanges();
                LoadDate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count>0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = (int) dataGridView2[0, index].Value;
                Numbers row = db.Numbers.Find(id);
                fNumber f = new fNumber();
                f.textBox1.Text = row.Type_number;
                f.textBox2.Text = row.Cost.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    row.Type_number = f.textBox1.Text;
                    row.Cost = Convert.ToInt16(f.textBox2.Text);
                    db.Entry(row).State=System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    LoadDate();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Удалить запись", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int index = dataGridView2.SelectedRows[0].Index;
                    int id = (int)dataGridView2[0, index].Value;
                    Numbers row = db.Numbers.Find(id);
                    db.Numbers.Remove(row);
                    db.SaveChanges();
                    LoadDate();
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                    int index = dataGridView2.SelectedRows[0].Index;
                    int id = (int)dataGridView2[0, index].Value;
                    Numbers row = db.Numbers.Find(id);
                    listBox1.DataSource = row.Comforts.ToList();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                int index = dataGridView2.SelectedRows[0].Index;
                int id = (int)dataGridView2[0, index].Value;
                Numbers row = db.Numbers.Find(id);
                row.Comforts.Add(new Comforts() { Name = textBox1.Text });
                db.SaveChanges();
                listBox1.DataSource = row.Comforts.ToList();
                textBox1.Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                int id = (int)listBox1.SelectedValue;
                Comforts row = db.Comforts.Find(id);
                row.Name = textBox2.Text;
                db.SaveChanges();
            }
            if (dataGridView2.SelectedRows.Count > 0)
            {

                int index = dataGridView2.SelectedRows[0].Index;
                int id = (int)dataGridView2[0, index].Value;
                Numbers row = db.Numbers.Find(id);
                listBox1.DataSource = row.Comforts.ToList();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                int id = (int)listBox1.SelectedValue;
                Comforts row = db.Comforts.Find(id);
                textBox2.Text = row.Name;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ( listBox1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Удалить запись", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int id = (int)listBox1.SelectedValue;
                    Comforts row = db.Comforts.Find(id);
                    db.Comforts.Remove(row);
                    db.SaveChanges();
                }
                if (dataGridView2.SelectedRows.Count > 0)
                {

                    int index = dataGridView2.SelectedRows[0].Index;
                    int id = (int)dataGridView2[0, index].Value;
                    Numbers row = db.Numbers.Find(id);
                    listBox1.DataSource = row.Comforts.ToList();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fRegistration f = new fRegistration();
            Registrations row = new Registrations();
            if(f.ShowDialog()==DialogResult.OK)
            {
                row.Id_Client = (int)f.comboBox2.SelectedValue;
                row.Id_Number = (int)f.comboBox1.SelectedValue;
                row.DateInsert = Convert.ToDateTime(f.dateTimePicker1.Text);
                row.DateOut = Convert.ToDateTime(f.dateTimePicker2.Text);
                row.Cost = Convert.ToInt16(f.textBox1.Text);
                db.Registrations.Add(row);
                db.SaveChanges();
                LoadDate();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Удалить запись", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int index = dataGridView3.SelectedRows[0].Index;
                    int id = (int)dataGridView3[0, index].Value;
                    Registrations row = db.Registrations.Find(id);
                    db.Registrations.Remove(row);
                    db.SaveChanges();
                    LoadDate();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                int id = (int)dataGridView3[0, index].Value;
                Registrations row = db.Registrations.Find(id);
                fRegistration f = new fRegistration();
                f.comboBox2.SelectedValue = row.Id_Client;
                f.comboBox1.SelectedValue = row.Id_Number;
                f.dateTimePicker1.Text = row.DateInsert.ToString();
                f.dateTimePicker2.Text = row.DateOut.ToString();
                f.textBox1.Text = row.Cost.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    row.Id_Client = (int)f.comboBox2.SelectedValue;
                    row.Id_Number = (int)f.comboBox1.SelectedValue;
                    row.DateInsert = Convert.ToDateTime(f.dateTimePicker1.Text);
                    row.DateOut = Convert.ToDateTime(f.dateTimePicker2.Text);
                    row.Cost = Convert.ToInt16(f.textBox1.Text);
                    db.Entry(row).State=System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    LoadDate();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DateTime start=Convert.ToDateTime(dateTimePicker1.Text);
            DateTime end=Convert.ToDateTime(dateTimePicker2.Text);
           var list= db.Registrations.Where(p => p.DateInsert >=start  && p.DateInsert <=end ).ToList();
           List<Clients> listClient = new List<Clients>();
            foreach(var c in list)
            {
                listClient.Add(c.Clients);
            }
            dataGridView1.DataSource = listClient;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            f.reportViewer1.LocalReport.DataSources.Clear();
            f.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", db.ViewClient.ToList()));
            f.ShowDialog();
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            f.reportViewer1.LocalReport.ReportEmbeddedResource = "Motel.Report2.rdlc";
            f.reportViewer1.LocalReport.DataSources.Clear();
            viewTypeBindingSource.Filter = "[DateInsert]>='" + dateTimePicker3.Text + "' and [DateInsert]<='"+dateTimePicker4.Text+"'";
            f.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", viewTypeBindingSource));
            f.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Report f = new Report();
            f.reportViewer1.LocalReport.ReportEmbeddedResource = "Motel.Report2.rdlc";
            f.reportViewer1.LocalReport.DataSources.Clear();
            viewTypeBindingSource.Filter = "[Type_number]='"+comboBox1.Text+"'";
            f.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", viewTypeBindingSource));
            f.ShowDialog();
        }
    }
}
