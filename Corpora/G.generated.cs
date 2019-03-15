using System.Collections.Generic;

namespace Corpora
{
    public static partial class G
    {
        /// <summary>
        /// Часть речи
        /// </summary>
        /// <remarks> ID = 1 </remarks>
        public static Grammeme POST { get; private set; }

        /// <summary>
        /// Имя существительное
        /// </summary>
        /// <remarks> ID = 2 </remarks>
        public static Grammeme NOUN { get; private set; }

        /// <summary>
        /// Имя прилагательное (полное)
        /// </summary>
        /// <remarks> ID = 3 </remarks>
        public static Grammeme ADJF { get; private set; }

        /// <summary>
        /// Имя прилагательное (краткое)
        /// </summary>
        /// <remarks> ID = 4 </remarks>
        public static Grammeme ADJS { get; private set; }

        /// <summary>
        /// Компаратив
        /// </summary>
        /// <remarks> ID = 5 </remarks>
        public static Grammeme COMP { get; private set; }

        /// <summary>
        /// Глагол (личная форма)
        /// </summary>
        /// <remarks> ID = 6 </remarks>
        public static Grammeme VERB { get; private set; }

        /// <summary>
        /// Глагол (инфинитив)
        /// </summary>
        /// <remarks> ID = 7 </remarks>
        public static Grammeme INFN { get; private set; }

        /// <summary>
        /// Причастие (полное)
        /// </summary>
        /// <remarks> ID = 8 </remarks>
        public static Grammeme PRTF { get; private set; }

        /// <summary>
        /// Причастие (краткое)
        /// </summary>
        /// <remarks> ID = 9 </remarks>
        public static Grammeme PRTS { get; private set; }

        /// <summary>
        /// Деепричастие
        /// </summary>
        /// <remarks> ID = 10 </remarks>
        public static Grammeme GRND { get; private set; }

        /// <summary>
        /// Числительное
        /// </summary>
        /// <remarks> ID = 11 </remarks>
        public static Grammeme NUMR { get; private set; }

        /// <summary>
        /// Наречие
        /// </summary>
        /// <remarks> ID = 12 </remarks>
        public static Grammeme ADVB { get; private set; }

        /// <summary>
        /// Местоимение-существительное
        /// </summary>
        /// <remarks> ID = 13 </remarks>
        public static Grammeme NPRO { get; private set; }

        /// <summary>
        /// Предикатив
        /// </summary>
        /// <remarks> ID = 14 </remarks>
        public static Grammeme PRED { get; private set; }

        /// <summary>
        /// Предлог
        /// </summary>
        /// <remarks> ID = 15 </remarks>
        public static Grammeme PREP { get; private set; }

        /// <summary>
        /// Союз
        /// </summary>
        /// <remarks> ID = 16 </remarks>
        public static Grammeme CONJ { get; private set; }

        /// <summary>
        /// Частица
        /// </summary>
        /// <remarks> ID = 17 </remarks>
        public static Grammeme PRCL { get; private set; }

        /// <summary>
        /// Междометие
        /// </summary>
        /// <remarks> ID = 18 </remarks>
        public static Grammeme INTJ { get; private set; }

        /// <summary>
        /// Категория одушевлённости
        /// </summary>
        /// <remarks> ID = 19 </remarks>
        public static Grammeme ANim { get; private set; }

        /// <summary>
        /// Одушевлённое
        /// </summary>
        /// <remarks> ID = 20 </remarks>
        public static Grammeme anim { get; private set; }

        /// <summary>
        /// Неодушевлённое
        /// </summary>
        /// <remarks> ID = 21 </remarks>
        public static Grammeme inan { get; private set; }

        /// <summary>
        /// Род / род не выражен
        /// </summary>
        /// <remarks> ID = 22 </remarks>
        public static Grammeme GNdr { get; private set; }

        /// <summary>
        /// Мужской род
        /// </summary>
        /// <remarks> ID = 23 </remarks>
        public static Grammeme masc { get; private set; }

        /// <summary>
        /// Женский род
        /// </summary>
        /// <remarks> ID = 24 </remarks>
        public static Grammeme femn { get; private set; }

        /// <summary>
        /// Средний род
        /// </summary>
        /// <remarks> ID = 25 </remarks>
        public static Grammeme neut { get; private set; }

        /// <summary>
        /// Общий род (м/ж)
        /// </summary>
        /// <remarks> ID = 26 </remarks>
        public static Grammeme ms_f { get; private set; }

        /// <summary>
        /// Число
        /// </summary>
        /// <remarks> ID = 27 </remarks>
        public static Grammeme NMbr { get; private set; }

        /// <summary>
        /// Единственное число
        /// </summary>
        /// <remarks> ID = 28 </remarks>
        public static Grammeme sing { get; private set; }

        /// <summary>
        /// Множественное число
        /// </summary>
        /// <remarks> ID = 29 </remarks>
        public static Grammeme plur { get; private set; }

        /// <summary>
        /// Singularia tantum
        /// </summary>
        /// <remarks> ID = 30 </remarks>
        public static Grammeme Sgtm { get; private set; }

        /// <summary>
        /// Pluralia tantum
        /// </summary>
        /// <remarks> ID = 31 </remarks>
        public static Grammeme Pltm { get; private set; }

        /// <summary>
        /// Неизменяемое
        /// </summary>
        /// <remarks> ID = 32 </remarks>
        public static Grammeme Fixd { get; private set; }

        /// <summary>
        /// Категория падежа
        /// </summary>
        /// <remarks> ID = 33 </remarks>
        public static Grammeme CAse { get; private set; }

        /// <summary>
        /// Именительный падеж
        /// </summary>
        /// <remarks> ID = 34 </remarks>
        public static Grammeme nomn { get; private set; }

        /// <summary>
        /// Родительный падеж
        /// </summary>
        /// <remarks> ID = 35 </remarks>
        public static Grammeme gent { get; private set; }

        /// <summary>
        /// Дательный падеж
        /// </summary>
        /// <remarks> ID = 36 </remarks>
        public static Grammeme datv { get; private set; }

        /// <summary>
        /// Винительный падеж
        /// </summary>
        /// <remarks> ID = 37 </remarks>
        public static Grammeme accs { get; private set; }

        /// <summary>
        /// Творительный падеж
        /// </summary>
        /// <remarks> ID = 38 </remarks>
        public static Grammeme ablt { get; private set; }

        /// <summary>
        /// Предложный падеж
        /// </summary>
        /// <remarks> ID = 39 </remarks>
        public static Grammeme loct { get; private set; }

        /// <summary>
        /// Звательный падеж
        /// </summary>
        /// <remarks> ID = 40 </remarks>
        public static Grammeme voct { get; private set; }

        /// <summary>
        /// Первый родительный падеж
        /// </summary>
        /// <remarks> ID = 41 </remarks>
        public static Grammeme gen1 { get; private set; }

        /// <summary>
        /// Второй родительный (частичный) падеж
        /// </summary>
        /// <remarks> ID = 42 </remarks>
        public static Grammeme gen2 { get; private set; }

        /// <summary>
        /// Второй винительный падеж
        /// </summary>
        /// <remarks> ID = 43 </remarks>
        public static Grammeme acc2 { get; private set; }

        /// <summary>
        /// Первый предложный падеж
        /// </summary>
        /// <remarks> ID = 44 </remarks>
        public static Grammeme loc1 { get; private set; }

        /// <summary>
        /// Второй предложный (местный) падеж
        /// </summary>
        /// <remarks> ID = 45 </remarks>
        public static Grammeme loc2 { get; private set; }

        /// <summary>
        /// Аббревиатура
        /// </summary>
        /// <remarks> ID = 46 </remarks>
        public static Grammeme Abbr { get; private set; }

        /// <summary>
        /// Имя
        /// </summary>
        /// <remarks> ID = 47 </remarks>
        public static Grammeme Name { get; private set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <remarks> ID = 48 </remarks>
        public static Grammeme Surn { get; private set; }

        /// <summary>
        /// Отчество
        /// </summary>
        /// <remarks> ID = 49 </remarks>
        public static Grammeme Patr { get; private set; }

        /// <summary>
        /// Топоним
        /// </summary>
        /// <remarks> ID = 50 </remarks>
        public static Grammeme Geox { get; private set; }

        /// <summary>
        /// Организация
        /// </summary>
        /// <remarks> ID = 51 </remarks>
        public static Grammeme Orgn { get; private set; }

        /// <summary>
        /// Торговая марка
        /// </summary>
        /// <remarks> ID = 52 </remarks>
        public static Grammeme Trad { get; private set; }

        /// <summary>
        /// Возможна субстантивация
        /// </summary>
        /// <remarks> ID = 53 </remarks>
        public static Grammeme Subx { get; private set; }

        /// <summary>
        /// Превосходная степень
        /// </summary>
        /// <remarks> ID = 54 </remarks>
        public static Grammeme Supr { get; private set; }

        /// <summary>
        /// Качественное
        /// </summary>
        /// <remarks> ID = 55 </remarks>
        public static Grammeme Qual { get; private set; }

        /// <summary>
        /// Местоименное
        /// </summary>
        /// <remarks> ID = 56 </remarks>
        public static Grammeme Apro { get; private set; }

        /// <summary>
        /// Порядковое
        /// </summary>
        /// <remarks> ID = 57 </remarks>
        public static Grammeme Anum { get; private set; }

        /// <summary>
        /// Притяжательное
        /// </summary>
        /// <remarks> ID = 58 </remarks>
        public static Grammeme Poss { get; private set; }

        /// <summary>
        /// Форма на -ею
        /// </summary>
        /// <remarks> ID = 59 </remarks>
        public static Grammeme V_ey { get; private set; }

        /// <summary>
        /// Форма на -ою
        /// </summary>
        /// <remarks> ID = 60 </remarks>
        public static Grammeme V_oy { get; private set; }

        /// <summary>
        /// Сравнительная степень на по-
        /// </summary>
        /// <remarks> ID = 61 </remarks>
        public static Grammeme Cmp2 { get; private set; }

        /// <summary>
        /// Форма компаратива на -ей
        /// </summary>
        /// <remarks> ID = 62 </remarks>
        public static Grammeme V_ej { get; private set; }

        /// <summary>
        /// Категория вида
        /// </summary>
        /// <remarks> ID = 63 </remarks>
        public static Grammeme ASpc { get; private set; }

        /// <summary>
        /// Совершенный вид
        /// </summary>
        /// <remarks> ID = 64 </remarks>
        public static Grammeme perf { get; private set; }

        /// <summary>
        /// Несовершенный вид
        /// </summary>
        /// <remarks> ID = 65 </remarks>
        public static Grammeme impf { get; private set; }

        /// <summary>
        /// Категория переходности
        /// </summary>
        /// <remarks> ID = 66 </remarks>
        public static Grammeme TRns { get; private set; }

        /// <summary>
        /// Переходный
        /// </summary>
        /// <remarks> ID = 67 </remarks>
        public static Grammeme tran { get; private set; }

        /// <summary>
        /// Непереходный
        /// </summary>
        /// <remarks> ID = 68 </remarks>
        public static Grammeme intr { get; private set; }

        /// <summary>
        /// Безличный
        /// </summary>
        /// <remarks> ID = 69 </remarks>
        public static Grammeme Impe { get; private set; }

        /// <summary>
        /// Возможно безличное употребление
        /// </summary>
        /// <remarks> ID = 70 </remarks>
        public static Grammeme Impx { get; private set; }

        /// <summary>
        /// Многократный
        /// </summary>
        /// <remarks> ID = 71 </remarks>
        public static Grammeme Mult { get; private set; }

        /// <summary>
        /// Возвратный
        /// </summary>
        /// <remarks> ID = 72 </remarks>
        public static Grammeme Refl { get; private set; }

        /// <summary>
        /// Категория лица
        /// </summary>
        /// <remarks> ID = 73 </remarks>
        public static Grammeme PErs { get; private set; }

        /// <summary>
        /// 1 лицо
        /// </summary>
        /// <remarks> ID = 74 </remarks>
        public static Grammeme per1 { get; private set; }

        /// <summary>
        /// 2 лицо
        /// </summary>
        /// <remarks> ID = 75 </remarks>
        public static Grammeme per2 { get; private set; }

        /// <summary>
        /// 3 лицо
        /// </summary>
        /// <remarks> ID = 76 </remarks>
        public static Grammeme per3 { get; private set; }

        /// <summary>
        /// Категория времени
        /// </summary>
        /// <remarks> ID = 77 </remarks>
        public static Grammeme TEns { get; private set; }

        /// <summary>
        /// Настоящее время
        /// </summary>
        /// <remarks> ID = 78 </remarks>
        public static Grammeme pres { get; private set; }

        /// <summary>
        /// Прошедшее время
        /// </summary>
        /// <remarks> ID = 79 </remarks>
        public static Grammeme past { get; private set; }

        /// <summary>
        /// Будущее время
        /// </summary>
        /// <remarks> ID = 80 </remarks>
        public static Grammeme futr { get; private set; }

        /// <summary>
        /// Категория наклонения
        /// </summary>
        /// <remarks> ID = 81 </remarks>
        public static Grammeme MOod { get; private set; }

        /// <summary>
        /// Изъявительное наклонение
        /// </summary>
        /// <remarks> ID = 82 </remarks>
        public static Grammeme indc { get; private set; }

        /// <summary>
        /// Повелительное наклонение
        /// </summary>
        /// <remarks> ID = 83 </remarks>
        public static Grammeme impr { get; private set; }

        /// <summary>
        /// Категория совместности
        /// </summary>
        /// <remarks> ID = 84 </remarks>
        public static Grammeme INvl { get; private set; }

        /// <summary>
        /// Говорящий включён (идем, идемте)
        /// </summary>
        /// <remarks> ID = 85 </remarks>
        public static Grammeme incl { get; private set; }

        /// <summary>
        /// Говорящий не включён в действие (иди, идите)
        /// </summary>
        /// <remarks> ID = 86 </remarks>
        public static Grammeme excl { get; private set; }

        /// <summary>
        /// Категория залога
        /// </summary>
        /// <remarks> ID = 87 </remarks>
        public static Grammeme VOic { get; private set; }

        /// <summary>
        /// Действительный залог
        /// </summary>
        /// <remarks> ID = 88 </remarks>
        public static Grammeme actv { get; private set; }

        /// <summary>
        /// Страдательный залог
        /// </summary>
        /// <remarks> ID = 89 </remarks>
        public static Grammeme pssv { get; private set; }

        /// <summary>
        /// Разговорное
        /// </summary>
        /// <remarks> ID = 90 </remarks>
        public static Grammeme Infr { get; private set; }

        /// <summary>
        /// Жаргонное
        /// </summary>
        /// <remarks> ID = 91 </remarks>
        public static Grammeme Slng { get; private set; }

        /// <summary>
        /// Устаревшее
        /// </summary>
        /// <remarks> ID = 92 </remarks>
        public static Grammeme Arch { get; private set; }

        /// <summary>
        /// Литературный вариант
        /// </summary>
        /// <remarks> ID = 93 </remarks>
        public static Grammeme Litr { get; private set; }

        /// <summary>
        /// Опечатка
        /// </summary>
        /// <remarks> ID = 94 </remarks>
        public static Grammeme Erro { get; private set; }

        /// <summary>
        /// Искажение
        /// </summary>
        /// <remarks> ID = 95 </remarks>
        public static Grammeme Dist { get; private set; }

        /// <summary>
        /// Вопросительное
        /// </summary>
        /// <remarks> ID = 96 </remarks>
        public static Grammeme Ques { get; private set; }

        /// <summary>
        /// Указательное
        /// </summary>
        /// <remarks> ID = 97 </remarks>
        public static Grammeme Dmns { get; private set; }

        /// <summary>
        /// Вводное слово
        /// </summary>
        /// <remarks> ID = 98 </remarks>
        public static Grammeme Prnt { get; private set; }

        /// <summary>
        /// Форма на -ье
        /// </summary>
        /// <remarks> ID = 99 </remarks>
        public static Grammeme V_be { get; private set; }

        /// <summary>
        /// Форма на -енен
        /// </summary>
        /// <remarks> ID = 100 </remarks>
        public static Grammeme V_en { get; private set; }

        /// <summary>
        /// Форма на -и- (веселие, твердостию); отчество с -ие
        /// </summary>
        /// <remarks> ID = 101 </remarks>
        public static Grammeme V_ie { get; private set; }

        /// <summary>
        /// Форма на -ьи
        /// </summary>
        /// <remarks> ID = 102 </remarks>
        public static Grammeme V_bi { get; private set; }

        /// <summary>
        /// Деепричастие от глагола несовершенного вида
        /// </summary>
        /// <remarks> ID = 103 </remarks>
        public static Grammeme Fimp { get; private set; }

        /// <summary>
        /// Может выступать в роли предикатива
        /// </summary>
        /// <remarks> ID = 104 </remarks>
        public static Grammeme Prdx { get; private set; }

        /// <summary>
        /// Счётная форма
        /// </summary>
        /// <remarks> ID = 105 </remarks>
        public static Grammeme Coun { get; private set; }

        /// <summary>
        /// Собирательное числительное
        /// </summary>
        /// <remarks> ID = 106 </remarks>
        public static Grammeme Coll { get; private set; }

        /// <summary>
        /// Деепричастие на -ши
        /// </summary>
        /// <remarks> ID = 107 </remarks>
        public static Grammeme V_sh { get; private set; }

        /// <summary>
        /// Форма после предлога
        /// </summary>
        /// <remarks> ID = 108 </remarks>
        public static Grammeme Af_p { get; private set; }

        /// <summary>
        /// Может использоваться как одуш. / неодуш.
        /// </summary>
        /// <remarks> ID = 109 </remarks>
        public static Grammeme Inmx { get; private set; }

        /// <summary>
        /// Вариант предлога ( со, подо, ...)
        /// </summary>
        /// <remarks> ID = 110 </remarks>
        public static Grammeme Vpre { get; private set; }

        /// <summary>
        /// Анафорическое (местоимение)
        /// </summary>
        /// <remarks> ID = 111 </remarks>
        public static Grammeme Anph { get; private set; }

        /// <summary>
        /// Инициал
        /// </summary>
        /// <remarks> ID = 112 </remarks>
        public static Grammeme Init { get; private set; }

        /// <summary>
        /// Может выступать в роли прилагательного
        /// </summary>
        /// <remarks> ID = 113 </remarks>
        public static Grammeme Adjx { get; private set; }

        /// <summary>
        /// Общий род (м/ж/с)
        /// </summary>
        /// <remarks> ID = 114 </remarks>
        public static Grammeme Ms_f { get; private set; }

        /// <summary>
        /// Гипотетическая форма слова (победю, асфальтовее)
        /// </summary>
        /// <remarks> ID = 115 </remarks>
        public static Grammeme Hypo { get; private set; }

        /// <summary>
        /// статический конструктор
        /// </summary>
        static G()
        {
            POST = new Grammeme(1, "POST", "ЧР", "Часть речи");
            NOUN = new Grammeme(2, "NOUN", "СУЩ", "Имя существительное", POST);
            ADJF = new Grammeme(3, "ADJF", "ПРИЛ", "Имя прилагательное (полное)", POST);
            ADJS = new Grammeme(4, "ADJS", "КР_ПРИЛ", "Имя прилагательное (краткое)", POST);
            COMP = new Grammeme(5, "COMP", "КОМП", "Компаратив", POST);
            VERB = new Grammeme(6, "VERB", "ГЛ", "Глагол (личная форма)", POST);
            INFN = new Grammeme(7, "INFN", "ИНФ", "Глагол (инфинитив)", POST);
            PRTF = new Grammeme(8, "PRTF", "ПРИЧ", "Причастие (полное)", POST);
            PRTS = new Grammeme(9, "PRTS", "КР_ПРИЧ", "Причастие (краткое)", POST);
            GRND = new Grammeme(10, "GRND", "ДЕЕПР", "Деепричастие", POST);
            NUMR = new Grammeme(11, "NUMR", "ЧИСЛ", "Числительное", POST);
            ADVB = new Grammeme(12, "ADVB", "Н", "Наречие", POST);
            NPRO = new Grammeme(13, "NPRO", "МС", "Местоимение-существительное", POST);
            PRED = new Grammeme(14, "PRED", "ПРЕДК", "Предикатив", POST);
            PREP = new Grammeme(15, "PREP", "ПР", "Предлог", POST);
            CONJ = new Grammeme(16, "CONJ", "СОЮЗ", "Союз", POST);
            PRCL = new Grammeme(17, "PRCL", "ЧАСТ", "Частица", POST);
            INTJ = new Grammeme(18, "INTJ", "МЕЖД", "Междометие", POST);
            ANim = new Grammeme(19, "ANim", "Од-неод", "Категория одушевлённости");
            anim = new Grammeme(20, "anim", "од", "Одушевлённое", ANim);
            inan = new Grammeme(21, "inan", "неод", "Неодушевлённое", ANim);
            GNdr = new Grammeme(22, "GNdr", "хр", "Род / род не выражен");
            masc = new Grammeme(23, "masc", "мр", "Мужской род");
            femn = new Grammeme(24, "femn", "жр", "Женский род");
            neut = new Grammeme(25, "neut", "ср", "Средний род", GNdr);
            ms_f = new Grammeme(26, "ms-f", "мж", "Общий род (м/ж)", GNdr);
            NMbr = new Grammeme(27, "NMbr", "Число", "Число");
            sing = new Grammeme(28, "sing", "ед", "Единственное число", NMbr);
            plur = new Grammeme(29, "plur", "мн", "Множественное число", NMbr);
            Sgtm = new Grammeme(30, "Sgtm", "sg", "Singularia tantum");
            Pltm = new Grammeme(31, "Pltm", "pl", "Pluralia tantum");
            Fixd = new Grammeme(32, "Fixd", "0", "Неизменяемое");
            CAse = new Grammeme(33, "CAse", "Падеж", "Категория падежа");
            nomn = new Grammeme(34, "nomn", "им", "Именительный падеж", CAse);
            gent = new Grammeme(35, "gent", "рд", "Родительный падеж", CAse);
            datv = new Grammeme(36, "datv", "дт", "Дательный падеж", CAse);
            accs = new Grammeme(37, "accs", "вн", "Винительный падеж", CAse);
            ablt = new Grammeme(38, "ablt", "тв", "Творительный падеж", CAse);
            loct = new Grammeme(39, "loct", "пр", "Предложный падеж", CAse);
            voct = new Grammeme(40, "voct", "зв", "Звательный падеж", nomn);
            gen1 = new Grammeme(41, "gen1", "рд1", "Первый родительный падеж", gent);
            gen2 = new Grammeme(42, "gen2", "рд2", "Второй родительный (частичный) падеж", gent);
            acc2 = new Grammeme(43, "acc2", "вн2", "Второй винительный падеж", accs);
            loc1 = new Grammeme(44, "loc1", "пр1", "Первый предложный падеж", loct);
            loc2 = new Grammeme(45, "loc2", "пр2", "Второй предложный (местный) падеж", loct);
            Abbr = new Grammeme(46, "Abbr", "аббр", "Аббревиатура");
            Name = new Grammeme(47, "Name", "имя", "Имя");
            Surn = new Grammeme(48, "Surn", "фам", "Фамилия");
            Patr = new Grammeme(49, "Patr", "отч", "Отчество");
            Geox = new Grammeme(50, "Geox", "гео", "Топоним");
            Orgn = new Grammeme(51, "Orgn", "орг", "Организация");
            Trad = new Grammeme(52, "Trad", "tm", "Торговая марка");
            Subx = new Grammeme(53, "Subx", "субст?", "Возможна субстантивация");
            Supr = new Grammeme(54, "Supr", "превосх", "Превосходная степень");
            Qual = new Grammeme(55, "Qual", "кач", "Качественное");
            Apro = new Grammeme(56, "Apro", "мест-п", "Местоименное");
            Anum = new Grammeme(57, "Anum", "числ-п", "Порядковое");
            Poss = new Grammeme(58, "Poss", "притяж", "Притяжательное");
            V_ey = new Grammeme(59, "V-ey", "*ею", "Форма на -ею");
            V_oy = new Grammeme(60, "V-oy", "*ою", "Форма на -ою");
            Cmp2 = new Grammeme(61, "Cmp2", "сравн2", "Сравнительная степень на по-");
            V_ej = new Grammeme(62, "V-ej", "*ей", "Форма компаратива на -ей");
            ASpc = new Grammeme(63, "ASpc", "Вид", "Категория вида");
            perf = new Grammeme(64, "perf", "сов", "Совершенный вид", ASpc);
            impf = new Grammeme(65, "impf", "несов", "Несовершенный вид", ASpc);
            TRns = new Grammeme(66, "TRns", "Перех", "Категория переходности");
            tran = new Grammeme(67, "tran", "перех", "Переходный", TRns);
            intr = new Grammeme(68, "intr", "неперех", "Непереходный", TRns);
            Impe = new Grammeme(69, "Impe", "безл", "Безличный");
            Impx = new Grammeme(70, "Impx", "безл?", "Возможно безличное употребление");
            Mult = new Grammeme(71, "Mult", "мног", "Многократный");
            Refl = new Grammeme(72, "Refl", "возвр", "Возвратный");
            PErs = new Grammeme(73, "PErs", "Лицо", "Категория лица");
            per1 = new Grammeme(74, "1per", "1л", "1 лицо", PErs);
            per2 = new Grammeme(75, "2per", "2л", "2 лицо", PErs);
            per3 = new Grammeme(76, "3per", "3л", "3 лицо", PErs);
            TEns = new Grammeme(77, "TEns", "Время", "Категория времени");
            pres = new Grammeme(78, "pres", "наст", "Настоящее время", TEns);
            past = new Grammeme(79, "past", "прош", "Прошедшее время", TEns);
            futr = new Grammeme(80, "futr", "буд", "Будущее время", TEns);
            MOod = new Grammeme(81, "MOod", "Накл", "Категория наклонения");
            indc = new Grammeme(82, "indc", "изъяв", "Изъявительное наклонение", MOod);
            impr = new Grammeme(83, "impr", "повел", "Повелительное наклонение", MOod);
            INvl = new Grammeme(84, "INvl", "Совм", "Категория совместности");
            incl = new Grammeme(85, "incl", "вкл", "Говорящий включён (идем, идемте)", INvl);
            excl = new Grammeme(86, "excl", "выкл", "Говорящий не включён в действие (иди, идите)", INvl);
            VOic = new Grammeme(87, "VOic", "Залог", "Категория залога");
            actv = new Grammeme(88, "actv", "действ", "Действительный залог", VOic);
            pssv = new Grammeme(89, "pssv", "страд", "Страдательный залог", VOic);
            Infr = new Grammeme(90, "Infr", "разг", "Разговорное");
            Slng = new Grammeme(91, "Slng", "жарг", "Жаргонное");
            Arch = new Grammeme(92, "Arch", "арх", "Устаревшее");
            Litr = new Grammeme(93, "Litr", "лит", "Литературный вариант");
            Erro = new Grammeme(94, "Erro", "опеч", "Опечатка");
            Dist = new Grammeme(95, "Dist", "искаж", "Искажение");
            Ques = new Grammeme(96, "Ques", "вопр", "Вопросительное");
            Dmns = new Grammeme(97, "Dmns", "указ", "Указательное");
            Prnt = new Grammeme(98, "Prnt", "вводн", "Вводное слово");
            V_be = new Grammeme(99, "V-be", "*ье", "Форма на -ье");
            V_en = new Grammeme(100, "V-en", "*енен", "Форма на -енен");
            V_ie = new Grammeme(101, "V-ie", "*ие", "Форма на -и- (веселие, твердостию); отчество с -ие");
            V_bi = new Grammeme(102, "V-bi", "*ьи", "Форма на -ьи");
            Fimp = new Grammeme(103, "Fimp", "*несов", "Деепричастие от глагола несовершенного вида");
            Prdx = new Grammeme(104, "Prdx", "предк?", "Может выступать в роли предикатива");
            Coun = new Grammeme(105, "Coun", "счетн", "Счётная форма");
            Coll = new Grammeme(106, "Coll", "собир", "Собирательное числительное");
            V_sh = new Grammeme(107, "V-sh", "*ши", "Деепричастие на -ши");
            Af_p = new Grammeme(108, "Af-p", "*предл", "Форма после предлога");
            Inmx = new Grammeme(109, "Inmx", "не/одуш?", "Может использоваться как одуш. / неодуш.");
            Vpre = new Grammeme(110, "Vpre", "в_предл", "Вариант предлога ( со, подо, ...)");
            Anph = new Grammeme(111, "Anph", "анаф", "Анафорическое (местоимение)");
            Init = new Grammeme(112, "Init", "иниц", "Инициал");
            Adjx = new Grammeme(113, "Adjx", "прил?", "Может выступать в роли прилагательного");
            Ms_f = new Grammeme(114, "Ms-f", "ор", "Общий род (м/ж/с)");
            Hypo = new Grammeme(115, "Hypo", "гипот", "Гипотетическая форма слова (победю, асфальтовее)");
            
            // инициализируем коллекции
            _grammemes = new List<Grammeme>(115);
            _grammemesByID = new Dictionary<byte, Grammeme>(115);
            _grammemesByName = new Dictionary<string, Grammeme>(115);
            
            // регистрируем граммемы
            {
                Register(POST);
                Register(NOUN);
                Register(ADJF);
                Register(ADJS);
                Register(COMP);
                Register(VERB);
                Register(INFN);
                Register(PRTF);
                Register(PRTS);
                Register(GRND);
                Register(NUMR);
                Register(ADVB);
                Register(NPRO);
                Register(PRED);
                Register(PREP);
                Register(CONJ);
                Register(PRCL);
                Register(INTJ);
                Register(ANim);
                Register(anim);
                Register(inan);
                Register(GNdr);
                Register(masc);
                Register(femn);
                Register(neut);
                Register(ms_f);
                Register(NMbr);
                Register(sing);
                Register(plur);
                Register(Sgtm);
                Register(Pltm);
                Register(Fixd);
                Register(CAse);
                Register(nomn);
                Register(gent);
                Register(datv);
                Register(accs);
                Register(ablt);
                Register(loct);
                Register(voct);
                Register(gen1);
                Register(gen2);
                Register(acc2);
                Register(loc1);
                Register(loc2);
                Register(Abbr);
                Register(Name);
                Register(Surn);
                Register(Patr);
                Register(Geox);
                Register(Orgn);
                Register(Trad);
                Register(Subx);
                Register(Supr);
                Register(Qual);
                Register(Apro);
                Register(Anum);
                Register(Poss);
                Register(V_ey);
                Register(V_oy);
                Register(Cmp2);
                Register(V_ej);
                Register(ASpc);
                Register(perf);
                Register(impf);
                Register(TRns);
                Register(tran);
                Register(intr);
                Register(Impe);
                Register(Impx);
                Register(Mult);
                Register(Refl);
                Register(PErs);
                Register(per1);
                Register(per2);
                Register(per3);
                Register(TEns);
                Register(pres);
                Register(past);
                Register(futr);
                Register(MOod);
                Register(indc);
                Register(impr);
                Register(INvl);
                Register(incl);
                Register(excl);
                Register(VOic);
                Register(actv);
                Register(pssv);
                Register(Infr);
                Register(Slng);
                Register(Arch);
                Register(Litr);
                Register(Erro);
                Register(Dist);
                Register(Ques);
                Register(Dmns);
                Register(Prnt);
                Register(V_be);
                Register(V_en);
                Register(V_ie);
                Register(V_bi);
                Register(Fimp);
                Register(Prdx);
                Register(Coun);
                Register(Coll);
                Register(V_sh);
                Register(Af_p);
                Register(Inmx);
                Register(Vpre);
                Register(Anph);
                Register(Init);
                Register(Adjx);
                Register(Ms_f);
                Register(Hypo);
            };
        }
    }
}
