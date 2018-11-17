using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFix
{
    class PreprocessComparer<TInit, TComp> : IComparer<TInit>
    {
        //Constructors
        public PreprocessComparer(Preprocess P, Comparison<TComp> C, Comparison<TComp> AltC)
        {
            this.P = P;
            this.C = C;
            this.AltC = AltC;
        }
        public PreprocessComparer(Preprocess P, Comparison<TComp> C)
        {
            this.P = P;
            AltC = this.C = C;
        }

        //Fields
        Preprocess P;
        Comparison<TComp> C, AltC;

        //Delegates
        public delegate TComp Preprocess(TInit obj);

        //Properties
        public bool IfUseAlternative { get; set; } = false;

        //Methods
        public int Compare(TInit x, TInit y) =>
            (IfUseAlternative ? AltC : C)(P(x), P(y));

    }
}
