using Pisti.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Windows.Forms;

namespace Pisti
{
    public partial class pisti : Form
    {
        public string ilkoyuncu = "oyuncu";
        public int biter = 101;
        public pisti()
        {
            InitializeComponent();
        } 


        int[] dagıtılan = new int[52];
        int dagıtılansayac = 0, cıkmıssayac = 0, yersayac = 0;
        string[] cıkmıs = new string[52];
        string[] oyuncukazandıkları = new string[52];
        string[] bilgisayarkazandıkları = new string[52];
        string[] oyuncukartları = new string[4];
        string[] bilgisayarkartları = new string[4];
        string[] yer = new string[52];
        int bilgisayarpisti = 0, oyuncupisti = 0, tur = 0;
        int bilgisayarskor=0, oyuncuskor=0;
        int[] cıkanadet = new int[4];//bilgisayar sırası için gerekli
        int tursayac = 0;
        string sonalan = "oyuncu";
        string sonatılan = "";

        string[] kartlar = {
        "KARO A","KARO JİLET","KARO PAPAZ","KARO KIZ","KARO 10","KARO 9","KARO 8","KARO 7","KARO 6","KARO 5","KARO 4","KARO 3","KARO 2",
       "SİNEK A","SİNEK JİLET","SİNEK PAPAZ","SİNEK KIZ","SİNEK 10","SİNEK 9","SİNEK 8","SİNEK 7","SİNEK 6","SİNEK 5","SİNEK 4","SİNEK 3","SİNEK 2",
       "KUPA A","KUPA JİLET","KUPA PAPAZ","KUPA KIZ","KUPA 10","KUPA 9","KUPA 8","KUPA 7","KUPA 6","KUPA 5","KUPA 4","KUPA 3","KUPA 2",
       "MAÇA A","MAÇA JİLET","MAÇA PAPAZ","MAÇA KIZ","MAÇA 10","MAÇA 9","MAÇA 8","MAÇA 7","MAÇA 6","MAÇA 5","MAÇA 4","MAÇA 3","MAÇA 2"};




        private void destesonu()
        {
            puansayım();
            bilgisayarpisti = 0; dagıtılansayac = 0; 
            oyuncupisti = 0;  cıkmıssayac = 0;
            tur = 0; yersayac = 0; tursayac=0; tur = 0;
            Array.Clear(bilgisayarkazandıkları, 0, 52);
            Array.Clear(oyuncukazandıkları, 0, 52);
            for (int i = 0; i < 52; i++)
            {
                dagıtılan[i] = -1;
                cıkmıs[i] = "";
                yer[i] = "";
            }
            pictureBox1.BackgroundImage = Resources.yerbos;
            pictureBox3.BackgroundImage = Resources.yerbos;
            yerekoy();
            fotolarıekle();
            pictureBox4.Visible = true;
            label1.Visible = true;
            pictureBox1.Image = Resources.yerbos;
            pictureBox3.Image = Resources.yerbos;
            System.Threading.Thread.Sleep(1000);
            if (oyuncuskor>biter && bilgisayarskor > biter)
            {
                MessageBox.Show("OYUN UZADI !!", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                biter = biter + 50;
            }
            else
            {
                if (bilgisayarskor > biter)
                {
                    MessageBox.Show("MAALESEF KAYBETTİN!!", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                if (oyuncuskor>biter)
                {
                    MessageBox.Show("TEBRİKLER KAZANDIN!!", "SONUÇ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                
            } 
        }
        private void puansayım()
        {
            int bilskor = 0,oyunskor=0;
            int bilfazla =0;
            for (int i = 0; i < 52; i++)
            {
                if (bilgisayarkazandıkları[i]!="")
                {
                    bilfazla++;
                }
                if (bilgisayarkazandıkları[i] == null)
                {
                    break;
                }
                if (bilgisayarkazandıkları[i]=="KARO 10")
                {
                    bilskor += 3;
                }
                if (bilgisayarkazandıkları[i]=="SİNEK 2")
                {
                    bilskor += 2;
                }
                string eklenecek = "";
                if (bilgisayarkazandıkları[i][0] == 'S')
                {
                    eklenecek = bilgisayarkazandıkları[i].Substring(6);
                }
                else
                {
                    eklenecek = bilgisayarkazandıkları[i].Substring(5);
                }
                if (eklenecek=="A" || eklenecek=="JİLET")
                {
                    bilskor += 1;
                }
            }
            int toppuan = 13;
            if (bilfazla>26)
            {
                bilskor += 3;
            }
            else if (bilfazla==26)
            {
                toppuan = 10;
            }
            oyunskor = toppuan - bilskor;
            bilgisayarskor = (bilgisayarpisti * 10)+bilskor+bilgisayarskor;
            oyuncuskor = (oyuncupisti * 10) + oyunskor+oyuncuskor;
            label4.Text = bilgisayarskor.ToString();
            label6.Text=oyuncuskor.ToString();
        }

        private void bilgisayarkazanekle(string atılacak)
        {
            int say = 0;
            for (int i = 0; i < 52; i++)
            {

                if (bilgisayarkazandıkları[i] != "")
                {
                    break;
                }
                else
                {
                    say++;
                }
            }
            for (int i = 0; i < yersayac + 1; i++)
            {
                bilgisayarkazandıkları[say + i] = yer[i];

            }
            bilgisayarkazandıkları[say + yersayac] = atılacak;
        }
        private void oyuncukazanekle(string atılacak)
        {
            int say = 0;
            for (int i = 0; i < 52; i++)
            {
                if (oyuncukazandıkları[i] != "")
                {
                    break;
                }
                else
                {
                    say++;
                }
            }
            for (int i = 0; i < yersayac + 1; i++)
            {
                oyuncukazandıkları[say + i] = yer[i];

            }
            oyuncukazandıkları[say + yersayac] = atılacak;
        }

        private void dagıt()
        {
            tur++;//12 20 28 36 44 52
            if (tur==7)
            {
                if (yersayac>0)
                {
                    if (sonalan=="bilgisayar")
                    {
                        bilgisayarkazanekle(sonatılan);
                    }
                    else if(sonalan=="oyuncu")
                    {
                        oyuncukazanekle(sonatılan);
                    }
                }
                destesonu();
                tur++;
            }
            if (tur==6)
            {
                MessageBox.Show("BU TURUN SON 8 KAĞIDI", "SON EL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            int dongukır = 1;
            Random rnd = new Random();
            for (int i = 0;true; i++)
            {
                if (dongukır == 9)
                {
                    break;
                }
                else
                {
                    if (tur==6)
                    {
                        int[] eklenebilir = new int[8];
                        int sıra = 0;
                        for (int a = 0; a < 52; a++)
                        {
                            if (Array.IndexOf(dagıtılan,a)==-1)
                            {
                                eklenebilir[sıra]=a;
                                sıra++;
                            }
                        }
                        Random rnd2 = new Random();
                        for (int x = 0; true; x++)
                        {
                            if (dongukır == 9)
                            {
                                break;
                            }
                            int ekle = rnd2.Next(0, 8);
                            if (eklenebilir[ekle]!=-1)
                            {
                                dagıtılan[dagıtılansayac] = eklenebilir[ekle];
                                dagıtılansayac++;
                                if (dongukır <= 4)
                                {
                                    oyuncukartları[dongukır - 1] = kartlar[eklenebilir[ekle]];
                                }
                                else
                                {
                                    int a = dongukır - 4;
                                    bilgisayarkartları[a - 1] = kartlar[eklenebilir[ekle]];
                                }
                                eklenebilir[ekle] = -1;
                                dongukır++;
                            }
                        }
                        

                    }
                    else
                    {
                        bool eklenebilir = true;
                        int kagıt = rnd.Next(0, 52);
                        for (int x = 0; x < 52; x++)
                        {
                            if (dagıtılan[x] == kagıt)
                            {
                                eklenebilir = false;
                            }
                        }
                        if (eklenebilir == true)
                        {
                            dagıtılan[dagıtılansayac] = kagıt;
                            dagıtılansayac++;
                            if (dongukır <= 4)
                            {
                                oyuncukartları[dongukır - 1] = kartlar[kagıt];
                            }
                            else
                            {
                                int a = dongukır - 4;
                                bilgisayarkartları[a - 1] = kartlar[kagıt];
                            }
                            dongukır++;
                        }
                    }
                    
                }
            }
        }

        private void yerekoy()
        {
            Random rnd = new Random();
            int s = 0;
            for (int i = 0; i < 52; i++)
            {
                bool eklenebilir = true;
                int kagıt = rnd.Next(0, 52);
                for (int x = 0; x < 4; x++)
                {
                    if (dagıtılan[x] == kagıt)
                    {
                        eklenebilir = false;
                    }
                }
                if (eklenebilir == true)
                {
                    s++;
                    dagıtılan[dagıtılansayac] = kagıt;
                    dagıtılansayac++;
                    cıkmısekle(kartlar[kagıt]);
                    yer[yersayac] = kartlar[kagıt];
                    yersayac++;
                    ResourceManager rm = Resources.ResourceManager;
                    Bitmap myImage = (Bitmap)rm.GetObject(kartlar[kagıt]);
                    pictureBox4.Image = myImage;
                }
                if (s == 4)
                {
                    break;
                }
            }
        }


        private void cıkmısekle(string kart)
        {
            string eklenecek = "";
            if (kart[0] == 'S')
            {
                eklenecek = kart.Substring(6);
            }
            else
            {
                eklenecek = kart.Substring(5);
            }
            cıkmıs[cıkmıssayac] = eklenecek;
            cıkmıssayac++;
        }

        private void kart1_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            label1.Visible = false;
            cıkmısekle(oyuncukartları[0]);
            kartat(oyuncukartları[0], "oyuncu");
            pictureBox1.Image = kart1.BackgroundImage;
            bilgisayaroynayıs();
            kart1.Enabled = false;
            if (tursayac == 8 && ilkoyuncu== "oyuncu")
            {
                turdegis();
            }
            //bilgisayar kart atacak
        }
        private void kart2_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            label1.Visible = false;
            cıkmısekle(oyuncukartları[1]);
            kartat(oyuncukartları[1], "oyuncu");
            bilgisayaroynayıs();
            kart2.Enabled = false;
            if (tursayac == 8 && ilkoyuncu == "oyuncu")
            {
                turdegis();
            }
        }


        private void kart3_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            label1.Visible = false;
            cıkmısekle(oyuncukartları[2]);
            kartat(oyuncukartları[2], "oyuncu");
            bilgisayaroynayıs();
            kart3.Enabled = false;
            if (tursayac == 8 && ilkoyuncu == "oyuncu")
            {
                turdegis();
            }
        }

        private void kart4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            label1.Visible = false;
            cıkmısekle(oyuncukartları[3]);
            kartat(oyuncukartları[3], "oyuncu");
            bilgisayaroynayıs();
            kart4.Enabled = false;
            if (tursayac == 8 && ilkoyuncu == "oyuncu")
            {
                turdegis();
            }
        }

        private void fotolarıekle()
        {
            ResourceManager rm = Resources.ResourceManager;
            Bitmap myImage = (Bitmap)rm.GetObject(oyuncukartları[0]);
            kart1.BackgroundImage = myImage;
            Bitmap myImage2 = (Bitmap)rm.GetObject(oyuncukartları[1]);
            kart2.BackgroundImage = myImage2;
            Bitmap myImage3 = (Bitmap)rm.GetObject(oyuncukartları[2]);
            kart3.BackgroundImage = myImage3;
            Bitmap myImage4 = (Bitmap)rm.GetObject(oyuncukartları[3]);
            kart4.BackgroundImage = myImage4;
        }

        private void turdegis()
        {
            for (int i = 0; i < 4; i++)
            {
                oyuncukartları[i] = "";
                bilgisayarkartları[i] = "";
                cıkanadet[i] = 0;
            }
            dagıt();
            fotolarıekle();
            tursayac = 0;
            kart1.Enabled = true;
            kart2.Enabled = true;
            kart3.Enabled = true;
            kart4.Enabled = true;


            MessageBox.Show("Kartlar yeniden Dağıtılıyor");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void kartat(string atılacak, string atan)
        {
            sonatılan = atılacak;
            if (atan=="bilgisayar")
            {
                ResourceManager rm2 = Resources.ResourceManager;
                Bitmap myImage2 = (Bitmap)rm2.GetObject(atılacak);
                pictureBox3.Image = myImage2;
            }
            else
            {
                ResourceManager rm = Resources.ResourceManager;
                Bitmap myImage = (Bitmap)rm.GetObject(atılacak);
                pictureBox1.Image = myImage;
            }
            string yerdeki = "";
            if (yersayac != 0)
            {
                if (yer[yersayac - 1][0] == 'S')
                {
                    yerdeki = yer[yersayac - 1].Substring(6);
                }
                else
                {
                    yerdeki = yer[yersayac - 1].Substring(5);
                }
            }


            string atılacak2 = "";
            if (atılacak[0] == 'S')
            {
                atılacak2 = atılacak.Substring(6);
            }
            else
            {
                atılacak2 = atılacak.Substring(5);
            }
            if (yerdeki == atılacak2 || atılacak2 == "JİLET")
            {
                if (yersayac>0)
                {
                    if (atan == "bilgisayar")
                    {
                        sonalan = "bilgisayar";
                        MessageBox.Show("Bilgisayar Yeri ALDI", "Kim Aldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bilgisayarkazanekle(atılacak);
                        for (int i = 0; i < 52; i++)
                        {
                            yer[i] = "";
                        }
                        if (yersayac == 1)
                        {
                            if (atılacak2 == "JİLET" && yerdeki=="JİLET")
                            {
                                MessageBox.Show("Bilgisayar JİLETE PİŞTİ VURDU", "Kim Aldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bilgisayarpisti += 2;
                            }
                            else if (atılacak2!="JİLET")
                            {
                                MessageBox.Show("Bilgisayar PİŞTİ VURDU", "Kim Aldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bilgisayarpisti++;
                            }

                        }
                        yersayac = 0;
                    }
                    else if (atan == "oyuncu")
                    {
                        sonalan = "oyuncu";
                        MessageBox.Show("Sen Yeri ALDIN", "Kim Aldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oyuncukazanekle(atılacak);
                        for (int i = 0; i < 52; i++)
                        {
                            yer[i] = "";
                        }
                        
                        if (yersayac == 1)
                        {
                            if (atılacak2 == "JİLET" && yerdeki=="JİLET")
                            {
                                MessageBox.Show("SEN JİLETE PİŞTİ VURDUN", "Kim Aldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                oyuncupisti += 2;
                            }
                            else if (atılacak2 != "JİLET")
                            {
                                MessageBox.Show("SEN PİŞTİ VURDUN", "Kim Aldı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                oyuncupisti++;
                            }
                        }
                        yersayac = 0;
                    }
                }
                else
                {
                    yer[yersayac] = atılacak;
                    yersayac++;
                }
                if (yer[0] == "")
                {
                    ResourceManager rm = Resources.ResourceManager;
                    Bitmap myImage = (Bitmap)rm.GetObject("yerbos");
                    pictureBox1.Image = myImage;
                }
            }
            else
            {
                yer[yersayac] = atılacak;
                yersayac++;
            }
            tursayac++;
        }


        private void pisti_Load(object sender, EventArgs e)
        {

            yerekoy();
            dagıt();
            fotolarıekle();
            
        }



        private int cıkmıssay(string aranan)
        {
            int adet = 0;
            for (int i = 0; i < 52; i++)
            {
                if (cıkmıs[i] == aranan)
                {
                    adet++;
                }
            }

            return adet;
        }


        private int garantioyna()
        {
            for (int i = 0; i < 4; i++)
            {
                int max = cıkanadet.Max();
                for (int x = 0; x < 4; x++)
                {
                    if (cıkanadet[x] == max - i)
                    {
                        if (bilgisayarkartları[x] != "atıldı")
                        {
                            cıkmısekle(bilgisayarkartları[x]);
                            kartat(bilgisayarkartları[x], "bilgisayar");
                            bilgisayarkartları[x] = "atıldı";
                            if (tursayac == 8 && ilkoyuncu == "bilgisayar")
                            {
                                turdegis();
                            }
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }



        private int bilgisayaroynayıs()
        {
            string[] kartlarım = new string[4];


            for (int i = 0; i < 4; i++)
            {
                if (bilgisayarkartları[i] != "atıldı")
                {
                    if (bilgisayarkartları[i][0] == 'S')
                    {
                        kartlarım[i] = bilgisayarkartları[i].Substring(6);
                    }
                    else
                    {
                        kartlarım[i] = bilgisayarkartları[i].Substring(5);
                    }
                }
                else
                {
                    kartlarım[i] = "atıldı";
                }

            }

            for (int i = 0; i < 4; i++)
            {
                cıkanadet[i] = cıkmıssay(kartlarım[i]);
            }
            Random rnd = new Random();
            if (yersayac != 0)
            {
                string yerdeki = "";
                if (yer[yersayac - 1][0] == 'S')
                {
                    yerdeki = yer[yersayac - 1].Substring(6);
                }
                else
                {
                    yerdeki = yer[yersayac - 1].Substring(5);
                }

                for (int i = 0; i < 4; i++)
                {
                    if (kartlarım[i] == yerdeki && kartlarım[i] != "atıldı")
                    {
                        cıkmısekle(bilgisayarkartları[i]);
                        kartat(bilgisayarkartları[i], "bilgisayar");
                        bilgisayarkartları[i] = "atıldı";
                        if (tursayac == 8 && ilkoyuncu == "bilgisayar")
                        {
                            turdegis();
                        }
                        return 1;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (kartlarım[i] == "JİLET")
                    {
                        cıkmısekle(bilgisayarkartları[i]);
                        kartat(bilgisayarkartları[i], "bilgisayar");
                        bilgisayarkartları[i] = "atıldı";
                        if (tursayac == 8 && ilkoyuncu == "bilgisayar")
                        {
                            turdegis();
                        }
                        return 1;
                    }
                }
                int rastgele = rnd.Next(1, 11);
                if (rastgele < 8)//garanti oynayacaz
                {
                    int a = garantioyna();
                    if (a == 1)
                    {
                        if (tursayac == 8 && ilkoyuncu == "bilgisayar")
                        {
                            turdegis();
                        }
                        return 1;
                    }
                }
                else
                {
                    for (int i = 0; true; i++)
                    {
                        int rast = rnd.Next(0, 4);
                        if (bilgisayarkartları[rast] != "atıldı")
                        {
                            cıkmısekle(bilgisayarkartları[rast]);
                            kartat(bilgisayarkartları[rast], "bilgisayar");
                            bilgisayarkartları[rast] = "atıldı";
                            if (tursayac == 8 && ilkoyuncu == "bilgisayar")
                            {
                                turdegis();
                            }
                            return 1;
                        }
                    }
                } 
            }
            if (yersayac == 0)
            {
                int a = garantioyna();
                if (a == 1)
                {
                    if (tursayac == 8 && ilkoyuncu == "bilgisayar")
                    {
                        turdegis();
                    }
                    return 1;
                }
            }
            return 0;
        }
    }
}
