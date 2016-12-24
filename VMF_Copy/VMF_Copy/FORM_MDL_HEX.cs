using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Collections;
using System.Media;

namespace VMF_Copy
{
    public partial class FORM_MDL_HEX : Form
    {
        private string MDLHex;
        private byte[] BData;
        public FORM_MDL_HEX(byte[] data)
        {
            InitializeComponent();
            BData = data;
            FCT_HEX_VIEW.Text = BitConverter.ToString(data).Replace('-', ' '); ;
        }



        private void FORM_MDL_HEX_Load(object sender, EventArgs e)
        {

        }

        private void FCT_HEX_VIEW_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                string ascii = "";
                string[] hexValuesSplit = FCT_HEX_VIEW.SelectedText.Split(' ');
                foreach (String hex in hexValuesSplit)
                {
                    int value = Convert.ToInt32(hex, 16);
                    //string stringValue = System.Char.ConvertFromUtf32(value);
                    ascii += (char)value;
                }

                FCTB_TO_ASCII.Text = ascii;
            }
            catch(Exception)
            {

            }
        }

        Style Zeros = new TextStyle(new SolidBrush(Color.FromArgb(36, 36, 36)), null, FontStyle.Regular);
        Style Unknown = new TextStyle(new SolidBrush(Color.FromArgb(97, 41, 41)), null, FontStyle.Bold);//255, 211, 211
        private void FCT_HEX_VIEW_Load(object sender, EventArgs e)
        {

        }

        private void FCT_HEX_VIEW_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                //clear style of changed range
                FCT_HEX_VIEW.Range.ClearStyle(Unknown);
                FCT_HEX_VIEW.Range.ClearStyle(Zeros);

                //comment highlighting
                FCT_HEX_VIEW.Range.SetStyle(Unknown, @"(\?\?)", RegexOptions.Multiline);
                FCT_HEX_VIEW.Range.SetStyle(Zeros, @"(00)|(FF)|(FD)", RegexOptions.Multiline);
                
            }
            catch(Exception)
            {

            }
        }

        private void FCT_HEX_VIEW_RegionChanged(object sender, EventArgs e)
        {
            try
            {
                //clear style of changed range
                FCT_HEX_VIEW.Range.ClearStyle(Unknown);
                FCT_HEX_VIEW.Range.ClearStyle(Zeros);

                //comment highlighting
                FCT_HEX_VIEW.Range.SetStyle(Unknown, @"(\?\?)", RegexOptions.Multiline);
                FCT_HEX_VIEW.Range.SetStyle(Zeros, @"(00)|(FF)|(FD)", RegexOptions.Multiline);
               
            }
            catch (Exception)
            {

            }
        }

        private void FCT_HEX_VIEW_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //clear style of changed range
                FCT_HEX_VIEW.Range.ClearStyle(Unknown);
                FCT_HEX_VIEW.Range.ClearStyle(Zeros);

                //comment highlighting
                FCT_HEX_VIEW.Range.SetStyle(Unknown, @"(\?\?)", RegexOptions.Multiline);
                FCT_HEX_VIEW.Range.SetStyle(Zeros, @"(00)|(FF)|(FD)", RegexOptions.Multiline);
                
            }
            catch (Exception)
            {

            }
        }

        private void B_FIND_MouseHover(object sender, EventArgs e)
        {

        }

        private void B_FIND_MouseEnter(object sender, EventArgs e)
        {
            //using (var snd = new SoundPlayer("tick.wav"))
            //{
            //    snd.Play();
            //}
        }

        private void B_STOP_Click(object sender, EventArgs e)
        {

        }
        Style FoundP = new TextStyle(new SolidBrush(Color.FromArgb(25, 25, 25)), new SolidBrush(Color.FromArgb(52, 155, 52)), FontStyle.Bold);
        int index = 0;
        private void B_FIND_Click(object sender, EventArgs e)
        {
            try
            {
                FCT_HEX_VIEW.Range.ClearStyle(FoundP);
                FCT_HEX_VIEW.Range.SetStyle(FoundP, @"(" + MDL_PATTAREN.PATTAREN[index] + ")", RegexOptions.Multiline);
                index++;
            }
            catch(Exception)
            {
                index = 0;
            }
        }

        private void B_NEXT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_ADD_Click(object sender, EventArgs e)
        {
            MDL_PATTAREN.Write(FCT_HEX_VIEW.SelectedText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            FCT_HEX_VIEW.Text = "";
            foreach (string pat in MDL_PATTAREN.PATTAREN)
            {
                FCT_HEX_VIEW.Text += count+" - " + pat + "\n";
                count++;
            }
        }
    }
}
