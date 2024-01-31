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
                // Formda metin kutusunda yazan sitenin adý
                var doc = htmlWeb.Load(txtUri.Text);

                if (doc != null)
                {
                    var haber = new List<Haberler>(); //Bu satýrda neden List var bilmiyorum. (List ne iþe yarýyor bilmiyorum)

                    /* hblInbox ile bizim verdiðimiz isim
                    hblnbox sitedeki class ismi. Ýkisi ayný isimde deðil dikkat et. */
                    // NOTE:  Videoda alt satýrda (xpath:"//div[@class='hblnBox']") bu þekilde yazýyor fakat 
                    //  ChatGPT nin düzeltmesine xpath kullanmýyorsun.ben ömer sen kimsin alo paralel evrende miyiz?
                    HtmlNodeCollection hblInBox = doc.DocumentNode.SelectNodes("//div[@class='hblnBox']");

                    if (hblInBox != null)
                    {
                        foreach (var inbox in hblInBox)
                        {
                            try
                            {
                                // videodan farklý olarak aþaðýda bazý yerler "var" ile tanýmlandý.
                                // Ayrýca web sitesinin htmli deðiþmiþ yani ("./div[@class='hblnTime']") bu kýsýmlerý sen kendin bulup düzelt
                                var haberZamani = inbox.SelectSingleNode("./div[@class='hblnTime']").InnerText;
                                var haberResim = inbox.SelectSingleNode("./a/div[@class='hblnImage']/img").Attributes["src"].Value;
                                string haberTitle = inbox.SelectSingleNode("./a/span[@class='hblnContent']").InnerText;

                                haber.Add(new Haberler()
                                {
                                    Time = haberZamani,
                                    PictureUri = haberResim,
                                    Baslik = haberTitle
                                });

                                //lstNews formda oluþturduðumuz listbox ýn adý
                                lstNews.Items.Add(haberTitle);
                            }
                            catch (Exception innerException)
                            {
                                Console.WriteLine(innerException.StackTrace);
                                // Hata durumunda devam et
                            }
                        }

                        MessageBox.Show($"Haberler çekildi. Toplam haber sayýsý {haber.Count}");
                    }
                    else
                    {
                        MessageBox.Show("XPath ifadesine uygun eleman bulunamadý.");
                    }
                }
                else
                {
                    MessageBox.Show("Belirtilen URL'den HTML içeriði alýnamadý.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show($"Bir hata oluþtu: {ex.Message}");
            }
        }

    }
}
