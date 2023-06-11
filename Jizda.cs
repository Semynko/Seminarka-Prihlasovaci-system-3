using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Autoskola
{
    internal class Jizda
    {
        //public static string radek;
        private string datum;
        //private string zformatovanyDatum;
        private string student;
        private string instruktor;
        public Jizda(string dat, string stud, string inst)
        {
            datum = dat;
            student = stud;
            instruktor = inst;
        }


        public string ZformatovaniDatumu()
        //Funkce pro upravení datumu před zapsáním
        //Upraví "01.01.2023 08:30:30" na "01.01.2023 08:30"
        {
            string[] pomocna = datum.Split(':');
            string[] pomo2 = pomocna[0].Split(' ');
            if (pomo2[1].Length == 2)
            {
                return datum = $"{pomocna[0] + ":" + pomocna[1]}";
            }
            else
            {
                return datum = $"{pomo2[0]} 0{pomo2[1]}:{pomocna[1]}";
            }
        }

        public bool Podminky() //Podmínky _ funkce zjisťující zda uživatel neudělal chybu při zadávání hodnot
        {
            if(instruktor == "")
            {
                MessageBox.Show("Nevybrali jste žádného instruktora", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                string edat = ZformatovaniDatumu();
                string[] t = edat.Split(' '); //rozdělí "8.12.2022 14:25" na "8.12.2022" & "14:25"
                string[] d = t[1].Split(':'); //rozdělí "14:25" na "14" & "25"
                for (int i = 0; i < FormJizdy.jizdalist.Length; i++)//projde všechny záznamy jídzdy
                {
                    if (FormVytvoritJizdu.instrukt == instruktor)
                    {
                        if (FormVytvoritJizdu.datum == datum)
                        {
                            //if (FormVytvoritJizdu.datum)
                            MessageBox.Show("prblm");
                        }
                    }
                }
                return true;
            }
        }

        public ListViewItem EditaceJizdy()
        {
            Jizda j = new Jizda(datum, student, instruktor);
            string zformaDat = j.ZformatovaniDatumu();
            ListViewItem item = new ListViewItem(zformaDat);
            item.SubItems.Add(student);
            if (student == FormPrihlaseni.Hstudent)
            {
                item.BackColor = Color.LightGreen;
            }
            item.SubItems.Add(instruktor);
            return item;
        }

        public void ZapsatNovouJizdu()
        //Funkce na zapsání nově naplánované jízdy do souboru
        //a do listboxu (dodělat)
        {
            Jizda j = new Jizda(datum, student, instruktor);
            string FDatum = j.ZformatovaniDatumu();
            Jizda.VycistHodnotyZJizdy();
            using (StreamWriter sw = new StreamWriter("jizdy.txt", false, Encoding.UTF8))
            {
                if (FormJizdy.text == "")
                {
                    sw.Write($"{FDatum};{student};{instruktor}");
                }
                else
                {
                    sw.Write(FormJizdy.text + Environment.NewLine + $"{FDatum};{student};{instruktor}");
                }
            }
            VycistHodnotyZJizdy();
        }

        public static void VycistHodnotyZJizdy()
        //Funkce pro načtení jizda.txt textu do "string text" a "string[] jizda"
        {
            using (StreamReader sr = new StreamReader("jizdy.txt"))
            {
                FormJizdy.text = sr.ReadToEnd();
                FormJizdy.jizdalist = FormJizdy.text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }
        }


    }
}
