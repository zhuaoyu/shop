using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam032
{
    public partial class 新增 : Form
    {
        public 新增()
        {
            InitializeComponent();
        }
        private string spid;
        private string mode;
        public void value(string spid, string mode)
        {
            this.spid = spid;
            this.mode = mode;
        }
        private void 新增_Load(object sender, EventArgs e)
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
            if (mode == "update")
            {
                string a1= spid.ToString();
                sp new1 = db.sp.SingleOrDefault(a => a.spid ==a1);
                label5.Text = new1.spid;
                textBox1.Text = new1.spname;
                comboBox1.SelectedValue = new1.spgysid;
                comboBox2.SelectedValue = new1.spzlid;
            }
            if (spid == "0")
            {
                label5.Text = "自动生成";
                button1.Text = "新增";
            }
            else
            {
                button1.Text = "修改";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            netEntities1 db = new netEntities1();
            sp new1 = new sp();
            new1.spzlid = Convert.ToString(comboBox2.SelectedValue);
            new1.spgysid = Convert.ToString(comboBox1.SelectedValue);
            if (mode == "insert")
            {
                  string a = DateTime.Now.Ticks.ToString();
                   a = a.Substring(a.Length - 7);
                  new1.spid = a ;
                db.sp.Add(new1);
            }
            if (mode == "update")
            {

                new1.spid = label5.Text;
                db.Entry<sp>(new1).State = EntityState.Modified;
            }
                  
            new1.spname = textBox1.Text;
            db.SaveChanges();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            

        }
    }
}
