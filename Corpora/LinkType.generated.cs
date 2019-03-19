using System.Collections.Generic;

namespace Corpora
{
    public partial class LinkType
    {
        /// <summary>
        /// ADJF-ADJS
        /// </summary>
        /// <remarks> ID = 1 </remarks>
        public static LinkType ADJF_ADJS { get; private set; }

        /// <summary>
        /// ADJF-COMP
        /// </summary>
        /// <remarks> ID = 2 </remarks>
        public static LinkType ADJF_COMP { get; private set; }

        /// <summary>
        /// INFN-VERB
        /// </summary>
        /// <remarks> ID = 3 </remarks>
        public static LinkType INFN_VERB { get; private set; }

        /// <summary>
        /// INFN-PRTF
        /// </summary>
        /// <remarks> ID = 4 </remarks>
        public static LinkType INFN_PRTF { get; private set; }

        /// <summary>
        /// INFN-GRND
        /// </summary>
        /// <remarks> ID = 5 </remarks>
        public static LinkType INFN_GRND { get; private set; }

        /// <summary>
        /// PRTF-PRTS
        /// </summary>
        /// <remarks> ID = 6 </remarks>
        public static LinkType PRTF_PRTS { get; private set; }

        /// <summary>
        /// NAME-PATR
        /// </summary>
        /// <remarks> ID = 7 </remarks>
        public static LinkType NAME_PATR { get; private set; }

        /// <summary>
        /// PATR_MASC-PATR_FEMN
        /// </summary>
        /// <remarks> ID = 8 </remarks>
        public static LinkType PATR_MASC_PATR_FEMN { get; private set; }

        /// <summary>
        /// SURN_MASC-SURN_FEMN
        /// </summary>
        /// <remarks> ID = 9 </remarks>
        public static LinkType SURN_MASC_SURN_FEMN { get; private set; }

        /// <summary>
        /// SURN_MASC-SURN_PLUR
        /// </summary>
        /// <remarks> ID = 10 </remarks>
        public static LinkType SURN_MASC_SURN_PLUR { get; private set; }

        /// <summary>
        /// PERF-IMPF
        /// </summary>
        /// <remarks> ID = 11 </remarks>
        public static LinkType PERF_IMPF { get; private set; }

        /// <summary>
        /// ADJF-SUPR_ejsh
        /// </summary>
        /// <remarks> ID = 12 </remarks>
        public static LinkType ADJF_SUPR_ejsh { get; private set; }

        /// <summary>
        /// PATR_MASC_FORM-PATR_MASC_INFR
        /// </summary>
        /// <remarks> ID = 13 </remarks>
        public static LinkType PATR_MASC_FORM_PATR_MASC_INFR { get; private set; }

        /// <summary>
        /// PATR_FEMN_FORM-PATR_FEMN_INFR
        /// </summary>
        /// <remarks> ID = 14 </remarks>
        public static LinkType PATR_FEMN_FORM_PATR_FEMN_INFR { get; private set; }

        /// <summary>
        /// ADJF_eish-SUPR_nai_eish
        /// </summary>
        /// <remarks> ID = 15 </remarks>
        public static LinkType ADJF_eish_SUPR_nai_eish { get; private set; }

        /// <summary>
        /// ADJF-SUPR_ajsh
        /// </summary>
        /// <remarks> ID = 16 </remarks>
        public static LinkType ADJF_SUPR_ajsh { get; private set; }

        /// <summary>
        /// ADJF_aish-SUPR_nai_aish
        /// </summary>
        /// <remarks> ID = 17 </remarks>
        public static LinkType ADJF_aish_SUPR_nai_aish { get; private set; }

        /// <summary>
        /// ADJF-SUPR_suppl
        /// </summary>
        /// <remarks> ID = 18 </remarks>
        public static LinkType ADJF_SUPR_suppl { get; private set; }

        /// <summary>
        /// ADJF-SUPR_nai
        /// </summary>
        /// <remarks> ID = 19 </remarks>
        public static LinkType ADJF_SUPR_nai { get; private set; }

        /// <summary>
        /// ADJF-SUPR_slng
        /// </summary>
        /// <remarks> ID = 20 </remarks>
        public static LinkType ADJF_SUPR_slng { get; private set; }

        /// <summary>
        /// FULL-CONTRACTED
        /// </summary>
        /// <remarks> ID = 21 </remarks>
        public static LinkType FULL_CONTRACTED { get; private set; }

        /// <summary>
        /// NORM-ORPHOVAR
        /// </summary>
        /// <remarks> ID = 22 </remarks>
        public static LinkType NORM_ORPHOVAR { get; private set; }

        /// <summary>
        /// CARDINAL-ORDINAL
        /// </summary>
        /// <remarks> ID = 23 </remarks>
        public static LinkType CARDINAL_ORDINAL { get; private set; }

        /// <summary>
        /// SBST_MASC-SBST_FEMN
        /// </summary>
        /// <remarks> ID = 24 </remarks>
        public static LinkType SBST_MASC_SBST_FEMN { get; private set; }

        /// <summary>
        /// SBST_MASC-SBST_PLUR
        /// </summary>
        /// <remarks> ID = 25 </remarks>
        public static LinkType SBST_MASC_SBST_PLUR { get; private set; }

        /// <summary>
        /// ADVB-COMP
        /// </summary>
        /// <remarks> ID = 26 </remarks>
        public static LinkType ADVB_COMP { get; private set; }

        /// <summary>
        /// ADJF_TEXT-ADJF_NUMBER
        /// </summary>
        /// <remarks> ID = 27 </remarks>
        public static LinkType ADJF_TEXT_ADJF_NUMBER { get; private set; }

        /// <summary>
        /// статический конструктор
        /// </summary>
        static LinkType()
        {
            ADJF_ADJS = new LinkType(1, "ADJF-ADJS");
            ADJF_COMP = new LinkType(2, "ADJF-COMP");
            INFN_VERB = new LinkType(3, "INFN-VERB");
            INFN_PRTF = new LinkType(4, "INFN-PRTF");
            INFN_GRND = new LinkType(5, "INFN-GRND");
            PRTF_PRTS = new LinkType(6, "PRTF-PRTS");
            NAME_PATR = new LinkType(7, "NAME-PATR");
            PATR_MASC_PATR_FEMN = new LinkType(8, "PATR_MASC-PATR_FEMN");
            SURN_MASC_SURN_FEMN = new LinkType(9, "SURN_MASC-SURN_FEMN");
            SURN_MASC_SURN_PLUR = new LinkType(10, "SURN_MASC-SURN_PLUR");
            PERF_IMPF = new LinkType(11, "PERF-IMPF");
            ADJF_SUPR_ejsh = new LinkType(12, "ADJF-SUPR_ejsh");
            PATR_MASC_FORM_PATR_MASC_INFR = new LinkType(13, "PATR_MASC_FORM-PATR_MASC_INFR");
            PATR_FEMN_FORM_PATR_FEMN_INFR = new LinkType(14, "PATR_FEMN_FORM-PATR_FEMN_INFR");
            ADJF_eish_SUPR_nai_eish = new LinkType(15, "ADJF_eish-SUPR_nai_eish");
            ADJF_SUPR_ajsh = new LinkType(16, "ADJF-SUPR_ajsh");
            ADJF_aish_SUPR_nai_aish = new LinkType(17, "ADJF_aish-SUPR_nai_aish");
            ADJF_SUPR_suppl = new LinkType(18, "ADJF-SUPR_suppl");
            ADJF_SUPR_nai = new LinkType(19, "ADJF-SUPR_nai");
            ADJF_SUPR_slng = new LinkType(20, "ADJF-SUPR_slng");
            FULL_CONTRACTED = new LinkType(21, "FULL-CONTRACTED");
            NORM_ORPHOVAR = new LinkType(22, "NORM-ORPHOVAR");
            CARDINAL_ORDINAL = new LinkType(23, "CARDINAL-ORDINAL");
            SBST_MASC_SBST_FEMN = new LinkType(24, "SBST_MASC-SBST_FEMN");
            SBST_MASC_SBST_PLUR = new LinkType(25, "SBST_MASC-SBST_PLUR");
            ADVB_COMP = new LinkType(26, "ADVB-COMP");
            ADJF_TEXT_ADJF_NUMBER = new LinkType(27, "ADJF_TEXT-ADJF_NUMBER");
            
            // инициализируем коллекции
            _links = new List<LinkType>(27);
            _linksByID = new Dictionary<byte, LinkType>(27);
            
            // регистрируем типы связей
            {
                Register(ADJF_ADJS);
                Register(ADJF_COMP);
                Register(INFN_VERB);
                Register(INFN_PRTF);
                Register(INFN_GRND);
                Register(PRTF_PRTS);
                Register(NAME_PATR);
                Register(PATR_MASC_PATR_FEMN);
                Register(SURN_MASC_SURN_FEMN);
                Register(SURN_MASC_SURN_PLUR);
                Register(PERF_IMPF);
                Register(ADJF_SUPR_ejsh);
                Register(PATR_MASC_FORM_PATR_MASC_INFR);
                Register(PATR_FEMN_FORM_PATR_FEMN_INFR);
                Register(ADJF_eish_SUPR_nai_eish);
                Register(ADJF_SUPR_ajsh);
                Register(ADJF_aish_SUPR_nai_aish);
                Register(ADJF_SUPR_suppl);
                Register(ADJF_SUPR_nai);
                Register(ADJF_SUPR_slng);
                Register(FULL_CONTRACTED);
                Register(NORM_ORPHOVAR);
                Register(CARDINAL_ORDINAL);
                Register(SBST_MASC_SBST_FEMN);
                Register(SBST_MASC_SBST_PLUR);
                Register(ADVB_COMP);
                Register(ADJF_TEXT_ADJF_NUMBER);
            };
        }
    }
}
