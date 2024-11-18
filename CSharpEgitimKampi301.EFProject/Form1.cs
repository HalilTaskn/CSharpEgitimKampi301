using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName =txtName.Text;
            guide.GuideSurname =txtSurName.Text;
            db.Guides.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var removeValue = db.Guides.Find(id);
            db.Guides.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi");
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtID.Text);
            var updateValue = db.Guides.Find(id);
            updateValue.GuideName =txtName.Text;
            updateValue.GuideSurname=txtSurName.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi");
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.Guides.Where(x=>x.GuideID==id).ToList();
            dataGridView1.DataSource = values;  
            
        }
    }
}
