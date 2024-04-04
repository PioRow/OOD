using OOD.Objects;
using OOD.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD.Iterators
{
    public class NewsGenerator
    {
        private int mCount;
        private int rCount;
        private int mCurr;
        private int rCurr;
        private List<IReportable> reportables;
        private List<IMediaVisitor> medias;
        public NewsGenerator(List<IReportable> rep,List<IMediaVisitor> meida)
        {
            reportables = rep;
            medias = meida;
            mCount=medias.Count;
            rCount=rep.Count;
            mCurr = rCurr = 0;
        }
        public string? GenerateNextNews()
        {
            if (mCurr == mCount)
                return null;
            string ret= reportables[rCurr].accept(medias[mCurr]);
            rCurr++;
            if(rCurr == rCount)
            {
                mCurr++;
                rCurr = 0;
            }
            return ret;
        }
    }
}
