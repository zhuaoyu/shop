using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam032
{
    public partial class 商品列表 : Form
    {
        public 商品列表()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    

        private void 商品列表_Load(object sender, EventArgs e)
        {
            netEntities1 db = new netEntities1();
            var gys = from p in db.gys select p;
            comboBox1.ValueMember = "gysid";
            comboBox1.DisplayMember = "gysname";
            comboBox1.DataSource = gys.ToList();
            var zl = from p in db.zl select p;
            comboBox2.ValueMember = "zlid";
            comboBox2.DisplayMember = "zlname";
            comboBox2.DataSource = zl.ToList();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            netEntities1 db = new netEntities1();
            var result = from a in db.sp select a;
            if (comboBox1.SelectedIndex != 0)
            {
                string gysid = Convert.ToString(comboBox1.SelectedValue);
                result = from a in result where a.spgysid == gysid select a;
            }
            if (comboBox2.SelectedIndex != 0)
            {
                string zlid = Convert.ToString(comboBox2.SelectedValue);
                result = from a in result where a.spzlid == zlid select a;
            }
            if (textBox1.Text != "")
            {
                result = from a in result where a.spid.Contains(textBox1.Text) select a;
            }
            if (textBox2.Text != "")
            {
                result = from a in result where a.spname.Contains(textBox2.Text) select a;
            }
            dataGridView1.DataSource = (from a in result select new { a.spid,a.spname,a.spgysid,a.spzlid}).ToList();
                                      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            netEntities1 db = new netEntities1();
            新增 new1 = new 新增();
            new1.value("0", "insert");
            new1.ShowDialog();
            var sj = from a in db.sp select new { a.spid, a.spname, a.spgysid, a.spzlid };
            dataGridView1.DataSource = sj.ToList();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["spid"].Value.ToString();
                 
                新增 new1 = new 新增();
                new1.value(id, "update");
                new1.ShowDialog();
                netEntities1 db = new netEntities1();
                var sj = from a in db.sp select new {a.spid,a.spname,a.spgysid,a.spzlid };
                dataGridView1.DataSource = sj.ToList();
            }
            else
            {
                MessageBox.Show("请先选择行！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            netEntities1 db = new netEntities1();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["spid"].Value.ToString();
                sp new1 = db.sp.SingleOrDefault(a => a.spid == id);
                db.sp.Remove(new1);
                db.SaveChanges();
                MessageBox.Show("删除成功！");
                var sj = from a in db.sp select new { a.spid, a.spname, a.spgysid, a.spzlid };
                dataGridView1.DataSource = sj.ToList();
            }
            else
            {
                MessageBox.Show("请先选择行！");
            }
        }
    }
}
