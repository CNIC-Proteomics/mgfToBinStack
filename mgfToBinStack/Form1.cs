using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using QuiXoT.DA_stackRAW;
using QuiXoT.DA_Raw;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace mgfToBinStack
{
    public partial class Form1 : Form
    {

        ArrayList spectrumTypesChoose;
        ArrayList specPositionsChoose;
        ArrayList massUnitsChoose;
        BinStackOptions options;
        string firstTitle;
        char[] split_chars;
        int scanField;
       
        public Form1()
        {
            InitializeComponent();

            this.Text = "mgfToBinStack v." + mgfToBinStack.Properties.Settings.Default.version;

            spectrumTypesChoose = new ArrayList();

            spectrumTypesChoose.Add(spectrumTypes.Full);
            spectrumTypesChoose.Add(spectrumTypes.MSMS);
            spectrumTypesChoose.Add(spectrumTypes.ZoomScan);

            foreach(spectrumTypes spectype in spectrumTypesChoose)
            {
                specTypeBox.Items.Add(spectype.ToString());
            }

            specPositionsChoose = new ArrayList();
            specPositionsChoose.Add(spectrumPositions.previous);
            specPositionsChoose.Add(spectrumPositions.same);
            specPositionsChoose.Add(spectrumPositions.next);

            foreach (spectrumPositions specPos in specPositionsChoose)
            {
                posBox.Items.Add(specPos.ToString());
            }

            massUnitsChoose = new ArrayList();
            massUnitsChoose.Add(massUnits.amu);
            massUnitsChoose.Add(massUnits.mmu);
            massUnitsChoose.Add(massUnits.ppm);

            foreach (massUnits mu in massUnitsChoose)
            {
                massUnitsCmb.Items.Add(mu.ToString());
            }
                        
        }
         
        private void parentalMassChb_CheckedChanged(object sender, EventArgs e)
        {
            if (parentalMassTxt.Enabled)
            {
                parentalMassTxt.Text = "";
                parentalMassTxt.Enabled = false;
            }
            else parentalMassTxt.Enabled = true;

            if (massUnitsCmb.Enabled) massUnitsCmb.Enabled = false;
            else massUnitsCmb.Enabled = true;


        }

        private void createBinStackBtn_Click(object sender, EventArgs e)
        {
            options = new BinStackOptions();

            if (quiXMLtxt.Text.Trim() == "")
            {
                MessageBox.Show("No QuiXML selected", "Error");
                return;
            }
            if (schemaTxt.Text.Trim() == "")
            {
                MessageBox.Show("No QuiXML schema selected", "Error");
                return;
            }

            if (specFolderTxt.Text.Trim() == "")
            {
                MessageBox.Show("No spectra folder selected", "Error");
                return;
            }
            //if (specTypeBox.Text.Trim() == "")
            //{
            //    MessageBox.Show("No spectrum type selected", "Error");
            //    return;
            //}

            //if (posBox.Text == "")
            //{
            //    MessageBox.Show("No spectrum position selected", "Error");
            //    return;
            //}

            if (parentalMassChb.Checked && parentalMassTxt.Text == "")
            {
                MessageBox.Show("No parental mass selected", "Error");
                return;
            }

          
            options.mode = adquisitionMode.position;
            
            //foreach (spectrumPositions sp in specPositionsChoose)
            //{
            //    if (posBox.Text == sp.ToString())
            //    {
            //        options.spectrumPos = sp;
            //        break;
            //    }
            //}
            options.spectrumPos = spectrumPositions.same;
          

            //foreach (spectrumTypes spt in spectrumTypesChoose)
            //{
            //    if (specTypeBox.Text == spt.ToString())
            //    {
            //        options.spectrumType = spt;
            //        break;
            //    }
            //}
            options.spectrumType = spectrumTypes.ZoomScan;



            if (parentalMassChb.Checked)
            {
                options.useParentalMass = true;

                foreach (massUnits mu in massUnitsChoose)
                {
                    if (massUnitsCmb.Text == mu.ToString())
                    {
                        options.parentalMassUnits = mu;
                        break;
                    }
                }
                try
                {
                    options.parentalMass = float.Parse(parentalMassTxt.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                }
                catch
                {
                    MessageBox.Show("Parental mass is not valid (not a number)", "Error");
                    return;
                }

            }

            int scannumber=0;
            bool tryScanNumber = int.TryParse(scanNumberResTxt.Text, out scannumber);

            if (!tryScanNumber) 
            {
                MessageBox.Show("Scan number is not an integer!", "Error");
                return;
            }

            options.individualRow = false;

            options.split_chars =(char[])split_chars.Clone();
            options.scanField = scanField;
             

            genStack(specFolderTxt.Text.Trim(), options);


        }


        private void genStack(string rawPath, 
                        BinStackOptions options)
        {
            Application.DoEvents();
            string schemaFile = schemaTxt.Text.Trim(); 
            try
            {
                this.statusLabel.Text = "Generating binaries stack... Creating index...";
                this.statusLabel.Visible = true;

                string idFileXml = this.quiXMLtxt.Text.Trim();
                string stackIndexFolder = idFileXml.Substring(0, idFileXml.LastIndexOf(@"\")) + "\\binStack\\";
                string stackIndexFile = stackIndexFolder + "index.idx";
                if (!Directory.Exists(stackIndexFolder))
                {
                    Directory.CreateDirectory(stackIndexFolder);
                }

                //scans by frame
                int scbyframe = 100;

                //calculate number of frames
                int inumFrames = binStack.countFrames(idFileXml, scbyframe);

                //MessageBox.Show(inumFrames.ToString());

                //generate index
                binStack[] stackIndex = binStack.genIndex(idFileXml, schemaFile, rawPath, scbyframe, options);

               

                //Dangerous thing: we swap the values of FirstScan and spectrumIndex at the binStack


                //generate and save frames
                for (int i = 1; i <= inumFrames; i++)
                {
                    Application.DoEvents();
                    this.statusLabel.Text = "Generating binaries stack... generating frame " + i.ToString() + "/" + inumFrames.ToString();
                    binFrame currFrame = binStack.genFrame(stackIndex, i, scbyframe, rawPath, options);
                    string frameFile = stackIndexFolder + currFrame.frame.ToString() + ".bfr";
                    FileStream qFr = new FileStream(frameFile, FileMode.Create, FileAccess.Write);
                    BinaryFormatter bFr = new BinaryFormatter();
                    bFr.Serialize(qFr, currFrame);
                    qFr.Close();
                }


                //Save index
                //WARNING: very dangerous change, but necessary to maintain old binstacks: in currFrame
                //         we swap the values of scanNumber by spectrumIndex (once we have obtained the desired
                //         spectrum, we use the unique index (spectrumIndex).
                for (int i = stackIndex.GetLowerBound(0); i <= stackIndex.GetUpperBound(0); i++)
                {
                    for (int j = stackIndex[i].scan.GetLowerBound(0); j <= stackIndex[i].scan.GetUpperBound(0); j++)
                    {
                        int scanNumber_t = stackIndex[i].scan[j].FirstScan;
                        stackIndex[i].scan[j].FirstScan = stackIndex[i].scan[j].spectrumIndex;

                        //this is not necessary, but I want to maintain the scanNumber elsewhere...
                        stackIndex[i].scan[j].spectrumIndex = scanNumber_t;
                    }
                }
 
                FileStream q = new FileStream(stackIndexFile, FileMode.Create, FileAccess.Write);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(q, stackIndex);
                q.Close();
                

            }
            catch
            {
                MessageBox.Show("Unable to generate binaries stack");
                this.statusLabel.Text = "";
                this.statusLabel.Visible = false;
                return;
            }

            this.statusLabel.Text = "";
            this.statusLabel.Visible = false;

            MessageBox.Show("BinStack successfully created!!");

        }

 

        #region drag&drops

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            quiXMLtxt.Text = files[0].ToString().Trim();

        }
        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a xml file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.GetUpperBound(0) == 0)
                {
                    char[] seps = new char[] { '.' };
                    string[] fileSplit = files[0].Split(seps);

                    if (fileSplit[fileSplit.GetUpperBound(0)] == "xml")
                    {
                        e.Effect = DragDropEffects.All;
                    }

                }

            }
        }
        private void quiXMLtxt_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            quiXMLtxt.Text = files[0].ToString().Trim();

        }
        private void quiXMLtxt_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a xml file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.GetUpperBound(0) == 0)
                {
                    char[] seps = new char[] { '.' };
                    string[] fileSplit = files[0].Split(seps);

                    if (fileSplit[fileSplit.GetUpperBound(0)] == "xml")
                    {
                        e.Effect = DragDropEffects.All;
                    }

                }

            }

        }

        private void schemaTxt_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            schemaTxt.Text = files[0].ToString().Trim();
            
        }

        private void schemaTxt_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a xml file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.GetUpperBound(0) == 0)
                {
                    char[] seps = new char[] { '.' };
                    string[] fileSplit = files[0].Split(seps);

                    if (fileSplit[fileSplit.GetUpperBound(0)] == "xsd")
                    {
                        e.Effect = DragDropEffects.All;
                    }
                }
            }

        }


        private void label2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            specFolderTxt.Text = files[0].ToString().Trim();

        }
        private void label2_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a xml file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.GetUpperBound(0) == 0)
                {
                    //Check wether the file is a folder and it contains RAW files

                    DirectoryInfo myDir = new DirectoryInfo(files[0]);

                    string myPath = "";

                    foreach (FileInfo file in myDir.GetFiles())
                    {
                        myPath = file.ToString();
                        string ext;
                        ext = Path.GetExtension(myPath);
                        if (ext.ToUpper() == ".MGF") e.Effect = DragDropEffects.All;
                        break;
                    }
                }
            }
        }
        private void specFolderTxt_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            specFolderTxt.Text = files[0].ToString().Trim();

        }
        private void specFolderTxt_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a xml file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.GetUpperBound(0) == 0)
                {
                    //Check wether the file is a folder and it contains RAW files

                    DirectoryInfo myDir = new DirectoryInfo(files[0]);

                    string myPath = "";

                    foreach (FileInfo file in myDir.GetFiles())
                    {
                        myPath = file.ToString();
                        string ext;
                        ext = Path.GetExtension(myPath);
                        if (ext.ToUpper() == ".MGF" || ext.ToUpper() == ".TXT") e.Effect = DragDropEffects.All;
                        break;
                    }
                }
            }

        }

        #endregion

        private void specFolderTxt_TextChanged(object sender, EventArgs e)
        {
            firstTitle = Mgfutils.getFirstTitle(this.specFolderTxt.Text.Trim());

            this.titleLbl.Text = firstTitle;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {   
                split_chars = splitCharsTxt.Text.Trim().ToCharArray();

                string[] fields = this.titleLbl.Text.Split(split_chars);

                this.scanFieldsBox.Items.Clear();
                foreach (string f in fields)
                {
                    this.scanFieldsBox.Items.Add(f);
                }

                char[] comma = new char[1];
                comma[0] = ',';

                string[] scanFieldsStr = this.scanFieldsTxt.Text.Split(comma,StringSplitOptions.RemoveEmptyEntries);
                

                  
            }
            catch 
            {
                this.scanNumberResTxt.Text = "No scan";
            }

            //Mgfutils.getScanNumber(firstTitle,

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void scanFieldsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox.SelectedIndexCollection selection = this.scanFieldsBox.SelectedIndices;

            //scanField = new int[selection.Count];
            for (int i = 0; i < selection.Count; i++)
            {
                scanField = (int)selection[i];
            }
            
            this.scanNumberResTxt.Text = Mgfutils.getScanNumber(firstTitle, split_chars, scanField).ToString();

        }

 


    }
}
