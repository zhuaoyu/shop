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
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
        }

        private void 登录_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {   netEntities1 db =new netEntities1();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var ym = textBox1.Text.Trim();
                var ma = textBox2.Text.Trim();
                var dl = (from p in db.list where p.yonghuming == ym && p.mima == ma select p).Count();
                if (dl!=0)
                {
                    商品列表 new1 = new 商品列表();
                    new1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
            else{
                MessageBox.Show("请输入用户名和密码");
            }
        }
    }
}
