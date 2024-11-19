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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Locations.ToList();
            dataGridView1.DataSource = values;  
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guides.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideID,
            }).ToList();
            cmbRehber.DisplayMember = "FullName";
            cmbRehber.ValueMember = "GuideId";
            cmbRehber.DataSource= values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCapacity = byte.Parse(numCapaticy.Value.ToString());
            location.LocationCity = txtSehir.Text;
            location.LocationCountry = txtÜlke.Text;
            location.LocationPrice = decimal.Parse(textPrice.Text);
            location.DayNight = textNight.Text;
            location.GuideID = int.Parse(cmbRehber.SelectedValue.ToString());
            db.Locations.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var deletedValue = db.Locations.Find(id);
            db.Locations.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var updatedValue = db.Locations.Find(id);
            updatedValue.DayNight = textNight.Text;
            updatedValue.LocationPrice = decimal.Parse(textPrice.Text);
            updatedValue.LocationCapacity = byte.Parse(numCapaticy.Value.ToString());
            updatedValue.LocationCity=txtSehir.Text;
            updatedValue.LocationCountry = txtÜlke.Text;
            updatedValue.GuideID = int.Parse(cmbRehber.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme Gerçekleşti");
        }
    }
}
