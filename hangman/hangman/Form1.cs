namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SehirSec(); // Rastgele �ehir se�
            UpdateTahminDurumu(); // �izgi g�sterimi
        }
        List<string> turkiyeIlleri = new List<string>
        {
            "Adana", "Ad�yaman", "Afyonkarahisar", "A�r�", "Aksaray", "Amasya", "Ankara", "Antalya",
            "Ardahan", "Artvin", "Ayd�n", "Bal�kesir", "Bart�n", "Batman", "Bayburt", "Bilecik",
            "Bing�l", "Bitlis", "Bolu", "Burdur", "Bursa", "�anakkale", "�ank�r�", "�orum",
            "Denizli", "Diyarbak�r", "D�zce", "Edirne", "Elaz��", "Erzincan", "Erzurum", "Eski�ehir",
            "Gaziantep", "Giresun", "G�m��hane", "Hakkari", "Hatay", "I�d�r", "Isparta", "�stanbul",
            "�zmir", "Kahramanmara�", "Karab�k", "Karaman", "Kars", "Kastamonu", "Kayseri", "K�r�kkale",
            "K�rklareli", "K�r�ehir", "Kilis", "Kocaeli", "Konya", "K�tahya", "Malatya", "Manisa",
            "Mardin", "Mersin", "Mu�la", "Mu�", "Nev�ehir", "Ni�de", "Ordu", "Osmaniye", "Rize",
            "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "�anl�urfa", "��rnak", "Tekirda�",
            "Tokat", "Trabzon", "Tunceli", "U�ak", "Van", "Yalova", "Yozgat", "Zonguldak"
        };
        List<string> ipucuListesi = new List<string>
{
    "Kebap", // Adana
    "Nemrut Da��", // Ad�yaman
    "Sucuk", // Afyonkarahisar
    "Da�c�l�k", // A�r�
    "Tuz G�l�", // Aksaray
    "Elma", // Amasya
    "Ba�kent", // Ankara
    "Plajlar", // Antalya
    "Kafkas Festivali", // Ardahan
    "Karadeniz", // Artvin
    "Zeytin", // Ayd�n
    "Termal Su", // Bal�kesir
    "Amasra", // Bart�n
    "Hasankeyf", // Batman
    "Kale", // Bayburt
    "Osmanl�", // Bilecik
    "F�st�k", // Bing�l
    "Van Kedisi", // Bitlis
    "Yedig�ller", // Bolu
    "Burdur G�l�", // Burdur
    "�skender", // Bursa
    "Truva", // �anakkale
    "Yarenler", // �ank�r�
    "Hititler", // �orum
    "Pamukkale", // Denizli
    "Karacada� Pirinci", // Diyarbak�r
    "F�nd�k", // D�zce
    "Selimiye Camii", // Edirne
    "Harput Kalesi", // Elaz��
    "Ergan Da��", // Erzincan
    "�ifte Minareli Medrese", // Erzurum
    "L�leta��", // Eski�ehir
    "Baklava", // Gaziantep
    "Kiraz", // Giresun
    "Zigana Da��", // G�m��hane
    "Cilo Da��", // Hakkari
    "Antakya Mutfa��", // Hatay
    "Do�u Beyaz�t", // I�d�r
    "Lavanta", // Isparta
    "Bo�azi�i", // �stanbul
    "Efes Antik Kenti", // �zmir
    "Dondurma", // Kahramanmara�
    "Safran", // Karab�k
    "Tarihi Evler", // Karaman
    "Ani Harabeleri", // Kars
    "Ilgaz Da��", // Kastamonu
    "Past�rma", // Kayseri
    "Makine Kimya", // K�r�kkale
    "K�rklar An�t�", // K�rklareli
    "Ahilik", // K�r�ehir
    "K���k �ehir", // Kilis
    "Kartepe", // Kocaeli
    "Mevlana", // Konya
    "�ini", // K�tahya
    "Kay�s�", // Malatya
    "Mesir Macunu", // Manisa
    "Mardin Evleri", // Mardin
    "Tarsus �elalesi", // Mersin
    "�l�deniz", // Mu�la
    "Malazgirt", // Mu�
    "Kapadokya", // Nev�ehir
    "Ni�de Gazozu", // Ni�de
    "Boztepe", // Ordu
    "Harun Re�it Kalesi", // Osmaniye
    "Ayder Yaylas�", // Rize
    "Sapanca G�l�", // Sakarya
    "Samsunspor", // Samsun
    "Tillo", // Siirt
    "Boyabat Kalesi", // Sinop
    "Kangal", // Sivas
    "Bal�kl�g�l", // �anl�urfa
    "Cudi Da��", // ��rnak
    "�orlu", // Tekirda�
    "Ball�ca Ma�aras�", // Tokat
    "S�mela Manast�r�", // Trabzon
    "Munzur Da�lar�", // Tunceli
    "Ulubey Kanyonu", // U�ak
    "Akdamar Adas�", // Van
    "Termal Kapl�calar", // Yalova
    "�apano�lu Camii", // Yozgat
    "Kilim", // Zonguldak
};


        string secilenSehir;
        char[] tahminDurumu;
        int kalanHak = 6;
        private bool tamEkran = false; // Tam ekran modunun kontrol� i�in

        private void UpdateTahminDurumu()
        {
            meting�stergesi.Text = string.Join(" ", tahminDurumu); // �izgiler ile �ehir tahmini g�ster
        }
        private void SehirSec()
        {
            Random random = new Random();
            int index = random.Next(turkiyeIlleri.Count);
            secilenSehir = turkiyeIlleri[index].ToUpper();
            ipucubox.Text = ipucuListesi[index]; // �pucu box'�nda g�ster
            tahminDurumu = new string('_', secilenSehir.Length).ToCharArray();
            UpdateTahminDurumu();
        }


        private void HarfiIsaretle(char harf)
        {
            Label lblHarf = (Label)this.Controls.Find(harf.ToString(), true)[0];
            lblHarf.BackColor = Color.Blue; // Do�ru tahmin edilen harfi maviye �evir
        }

        private void SilAdamParcasi()
        {
            // Adam�n par�alar�n� silecek fonksiyon
            if (kalanHak == 4)
                solbacak.Visible = false; // �rne�in kafa resmi yok edilir
            else if (kalanHak == 3)
                sa�bacak.Visible = false;
            else if (kalanHak == 2)
                solkol.Visible = false;
            else if (kalanHak == 1)
                sa�kol.Visible = false;
            else if (kalanHak == 0)
                g�vde.Visible = false;
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
            string tahmin = tahminbox.Text.ToUpper(); // Tahmin edilen �ehri ya da harfi al
            tahminbox.Clear(); // Girdiyi temizle

            if (tahmin.Length == 1)
            {
                // E�er sadece bir harf girildiyse
                char harf = tahmin[0];
                bool harfDogruMu = false;

                for (int i = 0; i < secilenSehir.Length; i++)
                {
                    if (secilenSehir[i] == harf)
                    {
                        tahminDurumu[i] = harf; // Tahmin edilen harfi g�ncelle
                        harfDogruMu = true;
                        HarfiIsaretle(harf); // Harfi i�aretle
                    }
                }

                UpdateTahminDurumu(); // Harf g�sterimini g�ncelle

                if (!harfDogruMu)
                {
                    kalanHak--;
                    hak.Text = $"{kalanHak} tahmin hakk�n kald�";
                    SilAdamParcasi();

                    if (kalanHak == 0)
                    {
                        MessageBox.Show("Kaybettiniz! Do�ru cevap: " + secilenSehir);
                        OyunBitir();
                    }
                }
            }
            else if (turkiyeIlleri.Any(x => x.ToUpper() == tahmin)) // �ehir ismi kontrol�
            {
                // E�er �ehir ismi girildiyse
                if (tahmin.ToUpper() == secilenSehir)
                {
                    meting�stergesi.Text = secilenSehir;
                    MessageBox.Show("Tebrikler! �ehri do�ru tahmin ettiniz!");
                    OyunBitir();
                }
                else
                {
                    kalanHak--;
                    hak.Text = $"{kalanHak} tahmin hakk�n kald�";
                    SilAdamParcasi();

                    if (kalanHak == 0)
                    {
                        MessageBox.Show("Kaybettiniz! Do�ru cevap: " + secilenSehir);
                        OyunBitir();
                    }
                }
            }
            else
            {
                MessageBox.Show("Ge�ersiz giri�! Harf ya da �ehir ismi giriniz.");
            }

            // Kazanma kontrol�: tahminDurumu dizisinde �izgi (_ ) var m�?
            if (!tahminDurumu.Contains('_'))
            {
                MessageBox.Show("Tebrikler! �ehri do�ru tahmin ettiniz!");
                OyunBitir();
            }
        }

        // Oyun bitirme fonksiyonu
        private void OyunBitir()
        {
            DialogResult result = MessageBox.Show("Oyuna tekrar ba�lamak ister misiniz?", "Oyun Bitti", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                kalanHak = 6; // Haklar� s�f�rla
                SehirSec(); // Yeni �ehir se�
            }
            else
            {
                this.Close(); // Oyunu kapat
            }
        }

        private void meting�stergesi_TextChanged(object sender, EventArgs e)
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
            this.WindowState = FormWindowState.Minimized; // Formu simge durumuna k���lt
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!tamEkran)
            {
                // Tam ekran moduna ge�
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None; // Kenarl�klar� kald�r
                this.TopMost = true; // Formu en �stte tut
                tamEkran = true;
            }
            else
            {
                // Normal moduna geri d�n
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable; // Kenarl�klar� geri getir
                this.TopMost = false; // En �stte tutmay� kald�r
                tamEkran = false;
            }
        }
    }
}
