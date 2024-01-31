using System;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace htmlAgi
{
    public partial class Form1 : Form
    {
        HtmlWeb htmlWeb = new HtmlWeb();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            try
            {
                // Formda metin kutusunda yazan sitenin ad�
                var doc = htmlWeb.Load(txtUri.Text);

                if (doc != null)
                {
                    var haber = new List<Haberler>(); //Bu sat�rda neden List var bilmiyorum. (List ne i�e yar�yor bilmiyorum)

                    /* hblInbox ile bizim verdi�imiz isim
                    hblnbox sitedeki class ismi. �kisi ayn� isimde de�il dikkat et. */
                    // NOTE:  Videoda alt sat�rda (xpath:"//div[@class='hblnBox']") bu �ekilde yaz�yor fakat 
                    //  ChatGPT nin d�zeltmesine xpath kullanm�yorsun.ben �mer sen kimsin alo paralel evrende miyiz?
                    HtmlNodeCollection hblInBox = doc.DocumentNode.SelectNodes("//div[@class='hblnBox']");

                    if (hblInBox != null)
                    {
                        foreach (var inbox in hblInBox)
                        {
                            try
                            {
                                // videodan farkl� olarak a�a��da baz� yerler "var" ile tan�mland�.
                                // Ayr�ca web sitesinin htmli de�i�mi� yani ("./div[@class='hblnTime']") bu k�s�mler� sen kendin bulup d�zelt
                                var haberZamani = inbox.SelectSingleNode("./div[@class='hblnTime']").InnerText;
                                var haberResim = inbox.SelectSingleNode("./a/div[@class='hblnImage']/img").Attributes["src"].Value;
                                string haberTitle = inbox.SelectSingleNode("./a/span[@class='hblnContent']").InnerText;

                                haber.Add(new Haberler()
                                {
                                    Time = haberZamani,
                                    PictureUri = haberResim,
                                    Baslik = haberTitle
                                });

                                //lstNews formda olu�turdu�umuz listbox �n ad�
                                lstNews.Items.Add(haberTitle);
                            }
                            catch (Exception innerException)
                            {
                                Console.WriteLine(innerException.StackTrace);
                                // Hata durumunda devam et
                            }
                        }

                        MessageBox.Show($"Haberler �ekildi. Toplam haber say�s� {haber.Count}");
                    }
                    else
                    {
                        MessageBox.Show("XPath ifadesine uygun eleman bulunamad�.");
                    }
                }
                else
                {
                    MessageBox.Show("Belirtilen URL'den HTML i�eri�i al�namad�.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show($"Bir hata olu�tu: {ex.Message}");
            }
        }

    }
}
