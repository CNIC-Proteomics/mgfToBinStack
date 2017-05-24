using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace QuiXoT.math
{

    public class Comb
    {
        /// <summary>
        /// Structure for (I vs m/z) data. 
        /// </summary>
        [Serializable]
        public struct mzI : IComparable
        {
            private Double mzVal;
            private Double IVal;

            public mzI(double mzValue, double IValue)
            {
                mzVal = mzValue;
                IVal = IValue;
            }

            public double mz
            {
                get
                {
                    return mzVal;
                }
                set
                {
                    mzVal = value;
                }
            }

            public double I
            {
                get
                {
                    return IVal;
                }
                set
                {
                    IVal = value;
                }
            }

            public override string ToString()
            {
                return (String.Format("{0}, {1}", mzVal, IVal));
            }



            #region Miembros de IComparable

            public int CompareTo(object obj)
            {
                Comb.mzI r = (Comb.mzI)obj;
                return this.mz.CompareTo(r.mz);
            }

            #endregion
        }

    }
}
