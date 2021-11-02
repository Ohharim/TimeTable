using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Time Table";

            dataGridView1.DataSource = DataManager.Plans;
            dataGridView1.CellClick += dataGridView1_CellClick;

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        //private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //}

       

        private void button1_Click(object sender, EventArgs e) //추가
        {
            try
            {

                Plan plan = new Plan()
                {
                    Date = dateTimePicker1.Value.ToString(),
                    Cont = richTextBox1.Text

                };
                DataManager.Plans.Add(plan);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Plans;
                DataManager.Save();

                MessageBox.Show(dateTimePicker1.Text + "\n일정 추가 완료");
            }
            catch(Exception ex) { }
        }

        //private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    Plan plan = dataGridView1.CurrentRow.DataBoundItem as Plan;
        //    richTextBox1.Text = plan.Cont;
        //    dateTimePicker1.Text = plan.Date;
        //}

        ////private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        //{

        //}
       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
          
            DateTime dt1 = dateTimePicker1.Value;
            dt1.ToString();

        }

        private void button3_Click(object sender, EventArgs e) //삭제

        {
            try
            {
                //Plan plan = DataManager.Plans.Single((x) => x.Cont == richTextBox1.Text);
                //DataManager.Plans.Remove(plan);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[i].Index);
                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);

                    }
                }

                DataTable dt = dataGridView1.DataSource as DataTable;
                //dt.Rows.Remove(dt.Rows[0]);

                //foreach(DataGridViewRow item in this.dataGridView1.SelectedRows)
                //{
                //    dataGridView1.Rows.Remove(item.plan);
                //}
                

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Plans;
                DataManager.Save();

               MessageBox.Show("삭제 완료");
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Plan plan = dataGridView1.CurrentRow.DataBoundItem as Plan;
                richTextBox1.Text = plan.Cont;
                dateTimePicker1.Text = plan.Date;
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e) //수정
        {
            try
            {
                Plan plan = DataManager.Plans.Single((x) => x.Date == dateTimePicker1.Text);
                plan.Date = dateTimePicker1.Text;
                plan.Cont = richTextBox1.Text;
              
                //DataGridViewRow dtRow = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                //for(int i = 0;i < ; i ++)
                //{
                //    dtRow.Cells[i].Value = richTextBox1.Text;

                //}


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Plans;
                DataManager.Save();
            }
            catch (Exception exception) { }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if(dgv.Columns[e.ColumnIndex].Name=="Date"&&dgv["Cont", e.RowIndex].Value ==null)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
