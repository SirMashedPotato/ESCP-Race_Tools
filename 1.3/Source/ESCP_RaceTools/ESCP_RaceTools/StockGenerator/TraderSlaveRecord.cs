using System;
using System.Xml;
using Verse;
using RimWorld;

namespace ESCP_RaceTools
{
    public class TraderSlaveRecord
    {
        public void LoadDataFromXmlCustom(XmlNode xmlRoot)
        {
            DirectXmlCrossRefLoader.RegisterObjectWantsCrossRef(this, "slave", xmlRoot, null, null);
            this.commonality = ParseHelper.FromString<float>(xmlRoot.FirstChild.Value);
        }

        public PawnKindDef slave;

        public float commonality;
    }
}
