using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autoskola
{
    public partial class FormJizdy : Form
    {
        //Pomocné globální proměné
        public static string[] jizdalist; //pole jednotlivých záznamů
        public static string text;

        public FormJizdy()
        {
            InitializeComponent();
            ZapsaniDoListboxu(this);
        }


        //----------------------Funkce komponent----------------------
        private void BtnVytvoritJizdu_Click(object sender, EventArgs e)
        //po zmáčknutí talčítka Vytvořit jídzu
        {
            FormVytvoritJizdu fvj = new FormVytvoritJizdu();
            if(fvj.ShowDialog() == DialogResult.OK)
            {
                Jizda j = new Jizda(FormVytvoritJizdu.datum, FormVytvoritJizdu.student, FormVytvoritJizdu.instrukt);
                if (j.Podminky()) //podmínky pro vyplnení všch polí
                {
                    j.ZapsatNovouJizdu();
                    ListViewItem item = new ListViewItem(j.ZformatovaniDatumu());
                    item.SubItems.Add(FormVytvoritJizdu.student);
                    item.BackColor = Color.LightGreen;
                    item.SubItems.Add(FormVytvoritJizdu.instrukt);
                    item.Selected = true;
                    lvSeznamJizd.Items.Add(item);
                }
            }
        }

        private void BtnUpravitJizdu_Click(object sender, EventArgs e)
        //po zmáčknutí tlačítka Upravit jízdu
        {
            if (lvSeznamJizd.SelectedItems.Count < 0)
            {
                MessageBox.Show("Nevybrali jste žádný termín", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem vybranyItem = lvSeznamJizd.SelectedItems[0];
            string[] radek = //vybraný zápis se splitne na 3 samostatný záznamy    
            {             
                vybranyItem.SubItems[0].Text,
                vybranyItem.SubItems[1].Text,
                vybranyItem.SubItems[2].Text 
            };

            string datumACas = radek[0];                //1. záznam Datumu a času
            string student = radek[1];                  //2. záznam jméno studenta
            string instruktor = radek[2];               //3. záznam jméno instruktora
            int[] pdt = { 
                int.Parse(radek[0].Split('.')[0]),               //den
                int.Parse(radek[0].Split('.')[1]),               //mesic
                int.Parse(radek[0].Split('.')[2].Split(' ')[0]), //rok
                int.Parse(radek[0].Split(' ')[1].Split(':')[0]), //hodina
                int.Parse(radek[0].Split(' ')[1].Split(':')[1])  //minuta
            }; 
            DateTime dt = new DateTime(pdt[2], pdt[1], pdt[0], pdt[3], pdt[4], 00); //vytvoří se DateTime proměná
            FormVytvoritJizdu fvj = new FormVytvoritJizdu(); 
            if (student != FormPrihlaseni.Hstudent)
            {//podmínka: uživatel smí upravovat jen svoje jízdy
                MessageBox.Show("K úpravě tohoto záznamu nemáte oprávnění!", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fvj.EditaceJizdyPrepis(dt, student, instruktor); //vepsání záznamu do textboxu/comboboxu  pro editaci
            fvj.PrejmenovaniBtn(1); //přejmenuje tlačítko na Upravit jízdu

            if (fvj.ShowDialog() == DialogResult.OK) //otevře FormVytvoritJizdu
            {
                string[] NovaJizda = fvj.PrepsaniJizdy();  //pole už editlého záznamu
                Jizda j = new Jizda(NovaJizda[0], NovaJizda[1], NovaJizda[2]); //vytvoření objektu s upravenými hodnotami
                ListViewItem item = j.EditaceJizdy(); //vrátí upravený záznam pro zapsání (př. "12.10.2024 12:35;Herbert;Daniel Pašík")
                item.Font = new Font(item.Font.FontFamily, 12);
                if (j.Podminky()) //podmínky pro vyplnení všch polí
                {
                    vybranyItem.SubItems[0] = item.SubItems[0]; //do vybraného záznamu přepíše hodnoty
                    vybranyItem.SubItems[1] = item.SubItems[1];
                    vybranyItem.SubItems[2] = item.SubItems[2];
                    lvSeznamJizd.Refresh();
                    vybranyItem.Selected = true;
                    ZapsatDoJizdyTXT();
                }
            }
            fvj.PrejmenovaniBtn(0); //přejmenuje tlačítko na zpátky na Vytvořit jízdu
        }


        private void BtnOdstranitJizdu_Click(object sender, EventArgs e)
        //po zmáčknutí tlačítka
        {
            if (lvSeznamJizd.SelectedItems.Count > 0)
            {
                lvSeznamJizd.Items.Remove(lvSeznamJizd.SelectedItems[0]);
                ZapsatDoJizdyTXT();
            }
        }




        //-------------------Ostatní funkce-----------------------



        public void ZapsatDoJizdyTXT()
        { //zapíše jízdy do jizdy.txt souboru z ListView lvSeznamJizd
            text = "";
            foreach (ListViewItem item in lvSeznamJizd.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    text += subItem.Text + ";";
                }
                text = text.Remove(text.Length - 1);
                text += Environment.NewLine;
            }
            if (!string.IsNullOrEmpty(text))
            {
                text = text.TrimEnd(Environment.NewLine.ToCharArray());
            }

            using (StreamWriter sw = new StreamWriter("jizdy.txt", false, Encoding.UTF8))
            {
                sw.Write(text);
                sw.Close();
            }
            Jizda.VycistHodnotyZJizdy();
        }
        public static void ZapsaniDoListboxu(FormJizdy formJizdy)
        //Funkce sloužící pro zapsání hodnot z jizdy.txt to list boxu
        {
            Jizda.VycistHodnotyZJizdy();
            if (text != "")
            {
                for (int i = 0; i < jizdalist.Length; i++)
                {
                    ListViewItem item = new ListViewItem(jizdalist[i].Split(';')[0]);
                    item.SubItems.Add(jizdalist[i].Split(';')[1]);
                    item.SubItems.Add(jizdalist[i].Split(';')[2]);
                    if (jizdalist[i].Split(';')[1] == FormPrihlaseni.Hstudent)
                    {
                        item.BackColor = Color.LightGreen;
                    }
                    formJizdy.lvSeznamJizd.Items.Add(item);
                }

            }
            formJizdy.lvSeznamJizd.Refresh();
        }
        /*public void ZapsaniHned(string datum, string student, string instrkutor)
        {
            lbxSeznamJizd.Items.Add(datum + ";" + student + ";" + instrkutor);
        }*/
        
    }
}