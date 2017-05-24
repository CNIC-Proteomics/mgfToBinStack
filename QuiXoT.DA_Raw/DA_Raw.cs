using System;
using System.Collections.Generic;
using System.Text;
using QuiXoT.math;
using System.Collections;
using System.IO;
using System.Globalization;

namespace QuiXoT.DA_Raw
{
       
    public enum adquisitionMode
    {
        RetentionTime,
        position
    }
    public enum massUnits
    {
        amu,
        mmu,
        ppm,
    }
    public enum spectrumTypes
    {
        Full,
        ZoomScan,
        MSMS,
    }
    public enum spectrumPositions
    {
        previous,
        same,
        next
    }

    public class BinStackOptions 
    {

        public BinStackOptions()
        {
            useParentalMass = false;
            parentalMassUnits = massUnits.amu;
            individualRow = false;
            assignIntToFirstScan = false;
        }

        private spectrumTypes spectrumTypeVal;
        private adquisitionMode modeVal;
        private spectrumPositions spectrumPosVal;
        private float retentionTimeVal;
        private bool useParentalMassVal;
        private float parentalMassVal;
        private massUnits parentalMassUnitsVal;
        private bool individualRowVal;
        private bool assignIntToFirstScanVal;

        //mgf title parser options
        private char[] split_charsVal;
        private int scanFieldVal;


        public char[] split_chars
        {
            get { return split_charsVal; }
            set { split_charsVal = value; }
        }
        public int scanField
        {
            get { return scanFieldVal; }
            set { scanFieldVal = value; }
        }


        public spectrumTypes spectrumType
        {
            get { return spectrumTypeVal; }
            set { spectrumTypeVal = value; }
        }
        public adquisitionMode mode
        {
            get { return modeVal; }
            set { modeVal = value; }
        }
        public spectrumPositions spectrumPos
        {
            get { return spectrumPosVal; }
            set { spectrumPosVal = value; }
        }
        public float retentionTime
        {
            get { return retentionTimeVal; }
            set { retentionTimeVal = value; }
        }
        public bool useParentalMass
        {
            get { return useParentalMassVal; }
            set { useParentalMassVal = value; }
        }
        public float parentalMass
        {
            get { return parentalMassVal; }
            set { parentalMassVal = value; }
        }
        public massUnits parentalMassUnits
        {
            get { return parentalMassUnitsVal; }
            set { parentalMassUnitsVal = value; }
        }
        public bool individualRow
        {
            get { return individualRowVal; }
            set { individualRowVal = value; }
        }

        public bool assignIntToFirstScan
        {
            get { return assignIntToFirstScanVal; }
            set { assignIntToFirstScanVal = value; }
        }

    }
        

    public class DA_raw
    {



        public Comb.mzI[] extData;
        public string instrumentName;

        //private XCALIBURFILESLib.XRaw _Raw = new XCALIBURFILESLib.XRaw();
        //private XCALIBURFILESLib.XDetectorRead _Detector;
        //private XCALIBURFILESLib.XSpectra _Spectra;
        

        /// <summary>
        /// Reads a given set of selected scans of a given raw 
        /// </summary>
        /// <param name="filePath">(string) directory path of the mgfs</param>
        /// <param name="mgffile">(string) name of the mgf to open</param>
        /// <param name="scannumber">(int[]) set of MSMS id scans to read</param>
        /// <param name="parentMassList">(ooptional)list of parental masses</param>
        /// <param name="options">options selected to create the binStack</param>
        /// <returns>(Comb.mzI[][]) spectrum of each selected scan</returns>
        public Comb.mzI[][] ReadScanRaw(string filePath, 
                                        string mgffile, 
                                        int[] scannumber, 
                                        double[] parentMassList, 
                                        BinStackOptions options) // string specType, string spectrumPosition)
        {
            //int stepSearch;
            string titleID = "TITLE";
            string spectrumEndID = "END IONS";

            
            

            int scanPos = 0;
            char[] splitchar = new char[2];
            splitchar[0] = '\t';
            splitchar[1] = ' ';

            //Variables for parental mass limits
            double minMass = 0;
            double maxMass = 10000;


            ArrayList scannumber_al = new ArrayList(scannumber.GetLength(0));

            for (int i = 0; i < scannumber.GetLength(0); i++)
            {
                scannumber_al.Add((int)scannumber[i]);
            }
            scannumber_al.Sort();
            

            if (filePath == null || filePath.Length == 0)
                return null;
            if (mgffile == null || mgffile.Length == 0)
                return null;

            Comb.mzI[][] scansRaw = new Comb.mzI[scannumber.GetUpperBound(0) + 1][];

            //open the file
            FileInfo file = new FileInfo(filePath.ToString().Trim() + "\\" + mgffile.ToString().Trim());
          
            StreamReader sr = new StreamReader(File.OpenRead(file.FullName));

            string line = "";

            //read the file
            try
            {
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    if (line.ToUpper().Contains(titleID))
                    {
                        //obtain the scannumber of the current spectrum
                        int tentativeScanNumber = Mgfutils.getScanNumber(line, options.split_chars, options.scanField);

                        //Check wether the current spectrum is on the list 
                        int locScan = scannumber_al.BinarySearch(tentativeScanNumber);

                        //spectrum found! -->write the spectrum into the scansRaw array
                        if (locScan > -1)
                        {
                            //locate the position where the spectrum must be inserted at the scannumber array
                            for (int j = 0; j <= scannumber.GetLength(0); j++)
                            {
                                if (scannumber[j] == tentativeScanNumber)
                                {
                                    scanPos = j;
                                    break;
                                }
                            }


                            if (options.useParentalMass)
                            {
                                //Mass conversions (mz data in the raw file is expressed in amu)
                                switch (options.parentalMassUnits)
                                {
                                    case massUnits.amu:
                                        minMass = parentMassList[scanPos] - options.parentalMass / 2;
                                        maxMass = parentMassList[scanPos] + options.parentalMass / 2;
                                        break;
                                    case massUnits.mmu:
                                        // amu = mmu * 1e3
                                        minMass = parentMassList[scanPos] - options.parentalMass * 1000 / 2;
                                        maxMass = parentMassList[scanPos] + options.parentalMass * 1000 / 2;
                                        break;
                                    case massUnits.ppm:
                                        // amu = ppm * parentalMass * 1e-6
                                        minMass = parentMassList[scanPos] - options.parentalMass * parentMassList[scanPos] * 1e-6;
                                        maxMass = parentMassList[scanPos] - options.parentalMass * parentMassList[scanPos] * 1e-6;
                                        break;
                                }
                            }


                            //read the spectrum, and record it in a temporary ArrayList
                            ArrayList tempSpectrum = new ArrayList();
                            line = sr.ReadLine();
                            while (!line.Contains(spectrumEndID))
                            {
                                try 
                                {
                                    Comb.mzI ion = new Comb.mzI();
                                    string[] iontmp = line.Split(splitchar);

                                    if (options.useParentalMass)
                                    {
                                        if (ion.mz >= minMass && ion.mz <= maxMass)
                                        {
                                            ion.mz = double.Parse(iontmp[0], CultureInfo.InvariantCulture.NumberFormat);
                                            ion.I = double.Parse(iontmp[1], CultureInfo.InvariantCulture.NumberFormat);
                                        }
                                    }
                                    else 
                                    {
                                        ion.mz = double.Parse(iontmp[0],CultureInfo.InvariantCulture.NumberFormat);
                                        ion.I = double.Parse(iontmp[1], CultureInfo.InvariantCulture.NumberFormat);                                    
                                    }

                                    tempSpectrum.Add(ion);

                                }
                                catch 
                                { }


                                line = sr.ReadLine();
                            }

                            //record the spectrum into the correct array (scansRaw)
                            tempSpectrum.Sort();
                            Comb.mzI[] spectrum = new Comb.mzI[tempSpectrum.Count+1];
                            int counter = 1;
                            foreach (Comb.mzI ion in tempSpectrum)
                            {
                                spectrum[counter] = ion;
                                counter++;
                            }
                            scansRaw[scanPos] = (Comb.mzI[])spectrum.Clone();


                        }
                    }

                }

            }
            catch { }
            
        
            GC.Collect();
            return scansRaw;

        }
    }

}
