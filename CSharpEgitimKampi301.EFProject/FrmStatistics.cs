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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam Lokasyo Sayısı
            lblLocationCount.Text = db.Locations.Count().ToString();
            #endregion
            #region Toplam Kapasite Sayısı
            lblSumCapacity.Text = db.Locations.Sum(x=>x.LocationCapacity).ToString();
            #endregion
            #region Toplam Rehber Sayısı
            lblGuideCount.Text = db.Guides.Count().ToString();
            #endregion
            #region Ortalama Kapasite
            lblAvgCapacity.Text= db.Locations.Average(x => x.LocationCapacity).Value.ToString("F2");
            #endregion
            #region Ortalama Lokasyon Fiyatı
            lblAvgLocationPrice.Text = db.Locations.Average(x => x.LocationPrice).Value.ToString("F2")+"₺";
            #endregion
            #region Eklenen Son Ülke
            int lastCountryId = db.Locations.Max(x => x.LocationID);
            lblLastCountry.Text = db.Locations.Where(x => x.LocationID == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
            #endregion
            #region Uzungöl Kapasite Sayısı
            lblUzungolLocationCapacity.Text = db.Locations.Where(x => x.LocationCity == "Uzungöl").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            #endregion
            #region Türkiye Kapasite Tur Ortalaması
            lblTurkyCapacityAvg.Text = db.Locations.Where(x =>x.LocationCountry=="TÜRKİYE").Average(y=>y.LocationCapacity).ToString();
            #endregion
            #region Roma Gezi Rehberi
            var romeGuideId = db.Locations.Where(x=>x.LocationCity == "Roma").Select(y=>y.GuideID).FirstOrDefault();
            lblRomeGuideName.Text = db.Guides.Where(x=>x.GuideID == romeGuideId).Select(y=>y.GuideName + " "+ y.GuideSurname).FirstOrDefault().ToString() ;
            #endregion
            #region Enyüksek Kapasitiy Lokasyon
            var maxCapacity = db.Locations.Max(x => x.LocationCapacity);
            lblMaxLocationCapacity.Text=db.Locations.Where(x=>x.LocationCapacity == maxCapacity).Select(y=>y.LocationCity).FirstOrDefault().ToString();
            #endregion
            #region En Pahalı Lokasyon 
            var maxPrice = db.Locations.Max(x => x.LocationPrice);
            lblMaxPriceLocation.Text =db.Locations.Where(x=>x.LocationPrice==maxPrice).Select(y=>y.LocationCity).FirstOrDefault().ToString() ;
            #endregion
            #region Ayşegül Çınar Tur Sayısı
            var guideIdNameAysegulCınar = db.Guides.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideID).FirstOrDefault();
            lblAysegulCnarLocatiyonCount.Text=db.Locations.Where(x=> x.GuideID == guideIdNameAysegulCınar).Count().ToString();
            #endregion

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
