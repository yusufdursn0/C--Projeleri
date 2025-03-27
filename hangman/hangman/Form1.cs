namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SehirSec(); // Rastgele þehir seç
            UpdateTahminDurumu(); // Çizgi gösterimi
        }
        List<string> turkiyeIlleri = new List<string>
        {
            "Adana", "Adýyaman", "Afyonkarahisar", "Aðrý", "Aksaray", "Amasya", "Ankara", "Antalya",
            "Ardahan", "Artvin", "Aydýn", "Balýkesir", "Bartýn", "Batman", "Bayburt", "Bilecik",
            "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankýrý", "Çorum",
            "Denizli", "Diyarbakýr", "Düzce", "Edirne", "Elazýð", "Erzincan", "Erzurum", "Eskiþehir",
            "Gaziantep", "Giresun", "Gümüþhane", "Hakkari", "Hatay", "Iðdýr", "Isparta", "Ýstanbul",
            "Ýzmir", "Kahramanmaraþ", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kýrýkkale",
            "Kýrklareli", "Kýrþehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa",
            "Mardin", "Mersin", "Muðla", "Muþ", "Nevþehir", "Niðde", "Ordu", "Osmaniye", "Rize",
            "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Þanlýurfa", "Þýrnak", "Tekirdað",
            "Tokat", "Trabzon", "Tunceli", "Uþak", "Van", "Yalova", "Yozgat", "Zonguldak"
        };
        List<string> ipucuListesi = new List<string>
{
    "Kebap", // Adana
    "Nemrut Daðý", // Adýyaman
    "Sucuk", // Afyonkarahisar
    "Daðcýlýk", // Aðrý
    "Tuz Gölü", // Aksaray
    "Elma", // Amasya
    "Baþkent", // Ankara
    "Plajlar", // Antalya
    "Kafkas Festivali", // Ardahan
    "Karadeniz", // Artvin
    "Zeytin", // Aydýn
    "Termal Su", // Balýkesir
    "Amasra", // Bartýn
    "Hasankeyf", // Batman
    "Kale", // Bayburt
    "Osmanlý", // Bilecik
    "Fýstýk", // Bingöl
    "Van Kedisi", // Bitlis
    "Yedigöller", // Bolu
    "Burdur Gölü", // Burdur
    "Ýskender", // Bursa
    "Truva", // Çanakkale
    "Yarenler", // Çankýrý
    "Hititler", // Çorum
    "Pamukkale", // Denizli
    "Karacadað Pirinci", // Diyarbakýr
    "Fýndýk", // Düzce
    "Selimiye Camii", // Edirne
    "Harput Kalesi", // Elazýð
    "Ergan Daðý", // Erzincan
    "Çifte Minareli Medrese", // Erzurum
    "Lületaþý", // Eskiþehir
    "Baklava", // Gaziantep
    "Kiraz", // Giresun
    "Zigana Daðý", // Gümüþhane
    "Cilo Daðý", // Hakkari
    "Antakya Mutfaðý", // Hatay
    "Doðu Beyazýt", // Iðdýr
    "Lavanta", // Isparta
    "Boðaziçi", // Ýstanbul
    "Efes Antik Kenti", // Ýzmir
    "Dondurma", // Kahramanmaraþ
    "Safran", // Karabük
    "Tarihi Evler", // Karaman
    "Ani Harabeleri", // Kars
    "Ilgaz Daðý", // Kastamonu
    "Pastýrma", // Kayseri
    "Makine Kimya", // Kýrýkkale
    "Kýrklar Anýtý", // Kýrklareli
    "Ahilik", // Kýrþehir
    "Küçük Þehir", // Kilis
    "Kartepe", // Kocaeli
    "Mevlana", // Konya
    "Çini", // Kütahya
    "Kayýsý", // Malatya
    "Mesir Macunu", // Manisa
    "Mardin Evleri", // Mardin
    "Tarsus Þelalesi", // Mersin
    "Ölüdeniz", // Muðla
    "Malazgirt", // Muþ
    "Kapadokya", // Nevþehir
    "Niðde Gazozu", // Niðde
    "Boztepe", // Ordu
    "Harun Reþit Kalesi", // Osmaniye
    "Ayder Yaylasý", // Rize
    "Sapanca Gölü", // Sakarya
    "Samsunspor", // Samsun
    "Tillo", // Siirt
    "Boyabat Kalesi", // Sinop
    "Kangal", // Sivas
    "Balýklýgöl", // Þanlýurfa
    "Cudi Daðý", // Þýrnak
    "Çorlu", // Tekirdað
    "Ballýca Maðarasý", // Tokat
    "Sümela Manastýrý", // Trabzon
    "Munzur Daðlarý", // Tunceli
    "Ulubey Kanyonu", // Uþak
    "Akdamar Adasý", // Van
    "Termal Kaplýcalar", // Yalova
    "Çapanoðlu Camii", // Yozgat
    "Kilim", // Zonguldak
};


        string secilenSehir;
        char[] tahminDurumu;
        int kalanHak = 6;
        private bool tamEkran = false; // Tam ekran modunun kontrolü için

        private void UpdateTahminDurumu()
        {
            metingöstergesi.Text = string.Join(" ", tahminDurumu); // Çizgiler ile þehir tahmini göster
        }
        private void SehirSec()
        {
            Random random = new Random();
            int index = random.Next(turkiyeIlleri.Count);
            secilenSehir = turkiyeIlleri[index].ToUpper();
            ipucubox.Text = ipucuListesi[index]; // Ýpucu box'ýnda göster
            tahminDurumu = new string('_', secilenSehir.Length).ToCharArray();
            UpdateTahminDurumu();
        }


        private void HarfiIsaretle(char harf)
        {
            Label lblHarf = (Label)this.Controls.Find(harf.ToString(), true)[0];
            lblHarf.BackColor = Color.Blue; // Doðru tahmin edilen harfi maviye çevir
        }

        private void SilAdamParcasi()
        {
            // Adamýn parçalarýný silecek fonksiyon
            if (kalanHak == 4)
                solbacak.Visible = false; // Örneðin kafa resmi yok edilir
            else if (kalanHak == 3)
                saðbacak.Visible = false;
            else if (kalanHak == 2)
                solkol.Visible = false;
            else if (kalanHak == 1)
                saðkol.Visible = false;
            else if (kalanHak == 0)
                gövde.Visible = false;
        }

        
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void kafa_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tahmin = tahminbox.Text.ToUpper(); // Tahmin edilen þehri ya da harfi al
            tahminbox.Clear(); // Girdiyi temizle

            if (tahmin.Length == 1)
            {
                // Eðer sadece bir harf girildiyse
                char harf = tahmin[0];
                bool harfDogruMu = false;

                for (int i = 0; i < secilenSehir.Length; i++)
                {
                    if (secilenSehir[i] == harf)
                    {
                        tahminDurumu[i] = harf; // Tahmin edilen harfi güncelle
                        harfDogruMu = true;
                        HarfiIsaretle(harf); // Harfi iþaretle
                    }
                }

                UpdateTahminDurumu(); // Harf gösterimini güncelle

                if (!harfDogruMu)
                {
                    kalanHak--;
                    hak.Text = $"{kalanHak} tahmin hakkýn kaldý";
                    SilAdamParcasi();

                    if (kalanHak == 0)
                    {
                        MessageBox.Show("Kaybettiniz! Doðru cevap: " + secilenSehir);
                        OyunBitir();
                    }
                }
            }
            else if (turkiyeIlleri.Any(x => x.ToUpper() == tahmin)) // Þehir ismi kontrolü
            {
                // Eðer þehir ismi girildiyse
                if (tahmin.ToUpper() == secilenSehir)
                {
                    metingöstergesi.Text = secilenSehir;
                    MessageBox.Show("Tebrikler! Þehri doðru tahmin ettiniz!");
                    OyunBitir();
                }
                else
                {
                    kalanHak--;
                    hak.Text = $"{kalanHak} tahmin hakkýn kaldý";
                    SilAdamParcasi();

                    if (kalanHak == 0)
                    {
                        MessageBox.Show("Kaybettiniz! Doðru cevap: " + secilenSehir);
                        OyunBitir();
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçersiz giriþ! Harf ya da þehir ismi giriniz.");
            }

            // Kazanma kontrolü: tahminDurumu dizisinde çizgi (_ ) var mý?
            if (!tahminDurumu.Contains('_'))
            {
                MessageBox.Show("Tebrikler! Þehri doðru tahmin ettiniz!");
                OyunBitir();
            }
        }

        // Oyun bitirme fonksiyonu
        private void OyunBitir()
        {
            DialogResult result = MessageBox.Show("Oyuna tekrar baþlamak ister misiniz?", "Oyun Bitti", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                kalanHak = 6; // Haklarý sýfýrla
                SehirSec(); // Yeni þehir seç
            }
            else
            {
                this.Close(); // Oyunu kapat
            }
        }

        private void metingöstergesi_TextChanged(object sender, EventArgs e)
        {

        }

        private void tahminbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ipucubox_TextChanged(object sender, EventArgs e)
        {

        }

        private void kapat_Click(object sender, EventArgs e)
        {
            this.Close(); // Formu kapat
        }

        private void altaal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Formu simge durumuna küçült
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!tamEkran)
            {
                // Tam ekran moduna geç
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None; // Kenarlýklarý kaldýr
                this.TopMost = true; // Formu en üstte tut
                tamEkran = true;
            }
            else
            {
                // Normal moduna geri dön
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable; // Kenarlýklarý geri getir
                this.TopMost = false; // En üstte tutmayý kaldýr
                tamEkran = false;
            }
        }
    }
}
