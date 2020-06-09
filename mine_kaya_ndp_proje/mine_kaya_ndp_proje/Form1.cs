using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mine_kaya_ndp_proje
{
    public partial class Form1 : Form
    {
        bool oyun_sonlandi = false;


        public Form1()
        {
            this.CenterToScreen();
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //merminin formda hareketi
            mermi_zaman.Enabled = true; 
            mermi_zaman.Start();
            mermi_zaman.Interval = 1;

            //dusmanin formda random konuma eklenmesi
            dusman_zaman.Enabled = true;
            dusman_zaman.Stop();
            dusman_zaman.Interval = 1200;
            //dusmanin formda haraketi
            dusman_haraket_ettir.Enabled = true;
            dusman_haraket_ettir.Stop();
            dusman_haraket_ettir.Interval = 40;

            //mermi ve dusmanin formda carpismasi
            mermi_dusman_carpisdimi.Enabled = true;
            mermi_dusman_carpisdimi.Stop();
            mermi_dusman_carpisdimi.Interval = 10;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //klavyeden sol tusa tiklanmasi
            if (e.KeyCode == Keys.Left)
            {
                if (ucak.Left <= 0) //ucak formunun sag tarafindan cikarsa
                    ucak.Left = 0;
                else
                    ucak.Left -= 20;
            }

            //klavyeden sag tusa tiklanmasi
            else if (e.KeyCode == Keys.Right) 
            {
                if (ucak.Left > this.Width - (5 + ucak.Width))//ucak formunun sol tarafindan cikarsa
                    ucak.Left = this.Width-ucak.Width-4;
                else
                    ucak.Left += 20;
            }

            //klavyeden bosluk tusuna tiklanmasi
            else if(e.KeyCode==Keys.Space)
            {
                PictureBox mermi = new PictureBox();  //picturbox turunde mermi uretir
                mermi.Image = Properties.Resources.bullet_in_motion;  //mermi fotografini ekler
                mermi.SizeMode = PictureBoxSizeMode.StretchImage;  //merminin boyutunu picturebox boyuyuna uygun ayarlar
                mermi.SetBounds(ucak.Location.X + ucak.Width/2-7, ucak.Location.Y - 20, 15, 25);  //merminin konumunu belirler
                this.Controls.Add(mermi);  //kontrole ekler
                mermi.Visible = true; //mermiyi gorunur yapar
            }
            else if(e.KeyCode==Keys.Enter)  //klavyeden entere tiklanmasi
            {
                if(oyun_sonlandi==false) //oyunun basladiginda
                {
                    dusman_zaman.Start();  
                    dusman_haraket_ettir.Start();
                    mermi_dusman_carpisdimi.Start();
                }
                if(oyun_sonlandi==true)  //eger oyun sonlanmissa
                {
                    //formu yeniden baslatir
                    this.Refresh();
                    Refresh();
                    this.Hide();
                    Form1 yeniden_baslat = new Form1();
                    yeniden_baslat.Show();
                    oyun_sonlandi = false;
                }
            }
        }



        private void mermi_zaman_Tick(object sender, System.EventArgs e)
        {

            //kontrol icinden mermiyi bulmak icin
            foreach (Control mermi_bul in this.Controls)
            {
                if (mermi_bul.GetType() == typeof(PictureBox)) //kontrol icindeki nesnenin turu picturebox turundeyse
                {
                    PictureBox mermi = mermi_bul as PictureBox;
                    if (mermi.Height == 25)  //picture boxun yuksekligi 25 ise.( 25 yuksekligi mermi olusturma kisminda yani space tiklandiginda belirlenir)
                    {
                        if (mermi.Location.Y > 0) //merminin formdaki konumu formun ustunden cikdiysa konumunu eksiltir
                          mermi.Top -= 3;
                        
                        else //eger ciktiysa mermiyi siler
                          mermi.Dispose();
                        
                    }
                }
            }
        }

        private void dusman_zaman_Tick(object sender, System.EventArgs e)
        {
            Random konum = new Random();  //random bir konum belirler
            PictureBox dusman = new PictureBox();  //picturebox turunde bir nesne uretir
            dusman.Image = Properties.Resources.dusman_f15;  //dusman pictureboxunun fotografini ekler
            int locationX = konum.Next(10, this.Width - 97);  //random konum olusturur formun genisligini asmayacak sekilde
            dusman.SizeMode = PictureBoxSizeMode.StretchImage;//dusmanin boyutunu picturebox boyuyuna uygun ayarlar
            dusman.SetBounds(locationX, 10, 40, 40);  //dusmanin formdaki konumunu ayarlar
            this.Controls.Add(dusman);  //kontrole ekler
            dusman.Visible = true; //dusman pictureboxunu gorunur yapar
        }

        private void dusman_haraket_ettir_Tick(object sender, EventArgs e)
        { 
            foreach (Control dusman_bul in this.Controls)  //kontrol icinde dusman pictureboxunu bulur
            {
                if (dusman_bul.GetType() == typeof(PictureBox)) //kontrol icinde bulun dusmanin turur picturebox ise
                {
                    PictureBox dusman = dusman_bul as PictureBox;
                    if (dusman.Height == 40) //picture boxun yuksekligi 40 ise.( 40 yuksekligi mermi olusturma kisminda yani dusman_zaman timeri icinde  belirlenir)
                    {

                        //dusman ile ucak carpismissa
                        if (dusman.Location.Y >= ucak.Location.Y - 40 && dusman.Location.Y <= ucak.Location.Y + 40)
                        {
                            if (dusman.Location.X >= ucak.Location.X - 55 && dusman.Location.X <= ucak.Location.X + 55)
                            {
                                //tum timerleri durdurur ve oyunu bititrir
                                dusman_zaman.Stop();
                                dusman_haraket_ettir.Stop();
                                mermi_zaman.Stop();
                                mermi_dusman_carpisdimi.Stop();
                                oyun_sonlandi = true;
                                MessageBox.Show("Oyun Bitti!");
                            }
                        }

                        //dusman ucagi formdan cikmissa 
                        if (dusman.Location.Y >= this.Height - 95)
                        {
                            //tum timerleri durdurur ve oyunu bititrir
                            dusman_zaman.Stop();
                            dusman_haraket_ettir.Stop();
                            mermi_zaman.Stop();
                            mermi_dusman_carpisdimi.Stop();
                            oyun_sonlandi = true;
                            MessageBox.Show("Oyun Bitti!");
                        }
                        dusman.SetBounds(dusman.Location.X, dusman.Location.Y + 3, 40, 40); //eger bitmediyse dusman yukardan konumunu artirir
                    }
                }
            }
        }

        private void mermi_dusman_carpisdimi_Tick(object sender, EventArgs e)
        {
            mermi_dusman_carpis();
        }

        public bool mermi_dusman_carpis()
        {
            List<PictureBox> mermi_listesi = new List<PictureBox>(); 
            List<PictureBox> dusman_listesi = new List<PictureBox>();

            foreach (Control mermi_ve_ucak_bul in this.Controls)  //kontrolden dusman ve mermiyi bulur
            {
                if (mermi_ve_ucak_bul.GetType() == typeof(PictureBox))
                {
                    if (mermi_ve_ucak_bul.Height == 25) //mermiyi yukseklik degerine gore bulur
                    {
                        mermi_listesi.Add((PictureBox)mermi_ve_ucak_bul);
                    }
                    else if (mermi_ve_ucak_bul.Height == 40) //ucagi yukseklik degerine gore bulur
                    {
                        dusman_listesi.Add((PictureBox)mermi_ve_ucak_bul);
                    }
                }
            }
            for (int i = 0; i < dusman_listesi.Count; i++)  //tum dusman ucaklari icin uygular
            {
                for (int j = 0; j < mermi_listesi.Count; j++) //tum mermi icin uygular
                {
                    if (carpisdir(dusman_listesi[i], mermi_listesi[j])) //ucak ve merminin carpisdigini kontrol eder
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool carpisdir(PictureBox dusman, PictureBox mermi)
        {

            //ucag ve merminin carpisdigini kontrol eder
               if ((mermi.Location.Y >= dusman.Location.Y - 25 && mermi.Location.Y <= dusman.Location.Y + 35) && (mermi.Location.X >= dusman.Location.X - 20 && mermi.Location.X <= dusman.Location.X + 32))
                {
                
                //carpisdiysa ucak ve dusmani formdan kaldirir
                    mermi.Dispose();
                    dusman.Dispose();

                    return true;
                }
            
          
            return false;
        }

    }
}