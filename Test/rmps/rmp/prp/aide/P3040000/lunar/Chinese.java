// Decompiled by Jad v1.5.8g. Copyright 2001 Pavel Kouznetsov.
// Jad home page: http://www.kpdus.com/jad.html
// Decompiler options: packimports(3) 
// Source File Name:   Chinese.java

package rmp.prp.aide.P3040000.lunar;

import rmp.prp.aide.P3040000.P3040000;
import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;
import cons.prp.aide.P3040000.ConstUI;
import cons.prp.aide.P3040000.LangRes;

// Referenced classes of package calendrica:
//            Date, BogusDateException, ChineseName, Gregorian, 
//            Location, ProtoDate

public class Chinese extends LunarDate
{
    public Chinese()
    {
    }

    public Chinese(long l)
    {
        super(l);
    }

    public Chinese(LunarDate date)
    {
        super(date);
    }

    public Chinese(long l, int i, int j, boolean flag, int k)
    {
        cycle = l;
        year = i;
        month = j;
        leapMonth = flag;
        day = k;
    }

    /*-
    (defun fixed-from-chinese (c-date)
      ;; TYPE chinese-date -> fixed-date
      ;; Fixed date of Chinese date (cycle year month leap
      ;; day).
      (let* ((cycle (chinese-cycle c-date))
             (year (chinese-year c-date))
             (month (chinese-month c-date))
             (leap (chinese-leap c-date))
             (day (chinese-day c-date))
             (g-year; Gregorian year at start of Chinese year
              (+ ( * (1- cycle) 60); years in prior cycles
                 (1- year)        ; prior years this cycle
                 ;; Gregorian year at start of calendar
                 (gregorian-year-from-fixed chinese-epoch)))
             (new-year (chinese-new-year g-year))
             (p; new moon before date--a month too early if
               ; there was prior leap month that year
              (chinese-new-moon-on-or-after
               (+ new-year ( * (1- month) 29))))
             (d (chinese-from-fixed p))
             (prior-new-moon
              (if  ; If the months match...
                  (and (= month (chinese-month d))
                       (equal leap (chinese-leap d)))
                  p; ...that's the right month
                ;; otherwise, there was a prior leap month that
                ;; year, so we want the next month
                (chinese-new-moon-on-or-after (1+ p)))))
        (+ prior-new-moon day -1)))
    -*/
    public static long toFixed(long l, int i, int j, boolean flag, int k)
    {
        long l1 = (long) Math.floor((double) EPOCH + ((double) ((l - 1L) * 60L + (long) (i - 1)) + 0.5D) * 365.242189D);
        long l2 = newYearOnOrBefore(l1);
        long l3 = newMoonOnOrAfter(l2 + (long) (29 * (j - 1)));
        Chinese chinese = new Chinese(l3);
        long l4 = j != chinese.month || flag != chinese.leapMonth ? newMoonOnOrAfter(l3 + 1L) : l3;
        return (l4 + (long) k) - 1L;
    }

    public long toFixed()
    {
        return toFixed(cycle, year, month, leapMonth, day);
    }

    /*-
    (defun chinese-from-fixed (date)
      ;; TYPE fixed-date -> chinese-date
      ;; Chinese date (cycle year month leap day) of fixed
      ;; date.
      (let* ((g-year (gregorian-year-from-fixed date))
             (s1; Prior solstice for most dates
              (major-solar-term-on-or-after
               (fixed-from-gregorian
                (gregorian-date december 15 (1- g-year)))))
             (s2; Following solstice for most dates--can be the
                ; prior solstice if the date is at the end of
                ; the Gregorian year, just after the solstice
              (major-solar-term-on-or-after
               (fixed-from-gregorian
                (gregorian-date december 15 g-year))))
             (m1     ; month after last 11th month
              (if (and (<= s1 date) (< date s2))
                  (chinese-new-moon-on-or-after (1+ s1))
                ;; Date is at end of the Gregorian year, just
                ;; after the solstice, so we need the solstice
                ;; of that year
                (chinese-new-moon-on-or-after (1+ s2))))
             (m2     ; next 11th month
              (if (and (<= s1 date) (< date s2))
                  (chinese-new-moon-before (1+ s2))
                ;; Date is at end of the Gregorian year, just
                ;; after the solstice, so we need the solstice
                ;; of the following year
                (chinese-new-moon-before
                 (1+ (major-solar-term-on-or-after
                      (fixed-from-gregorian
                       (gregorian-date
                        december 15 (1+ g-year))))))))
             (m      ; start of month containing date
              (chinese-new-moon-before (1+ date)))
             (leap-year; if there are 13 new moons (12 full
                       ; lunar months)
              (= (round (/ (- m2 m1) mean-synodic-month)) 12))
             (month  ; month number
              (adjusted-mod
               (-
                ;; ordinal position of month in year
                (round (/ (- m m1) mean-synodic-month))
                ;; minus 1 during or after a leap month
                (if (and leap-year (prior-leap-month? m1 m))
                    1
                  0))
               12))
             (leap-month    ; it's a leap month if...
              (and leap-year; ...there are 13 months
                   (no-major-solar-term? m); no major solar term
                   (not (prior-leap-month?; and no prior leap month
                         m1 (chinese-new-moon-before m)))))
             (elapsed-years ;  since the epoch
              (+ (- (gregorian-year-from-fixed date)
                    (gregorian-year-from-fixed chinese-epoch))
                 (if (or (< month 11)
                         (> date (fixed-from-gregorian
                                  (gregorian-date july 1 g-year))))
                     1 0)))
             (cycle (1+ (quotient (1- elapsed-years) 60)))
             (year (adjusted-mod elapsed-years 60))
             (day (1+ (- date m))))
        (chinese-date cycle year month leap-month day)))
    -*/
    public void fromFixed(long l)
    {
        long l1 = winterSolsticeOnOrBefore(l);
        long l2 = winterSolsticeOnOrBefore(l1 + 370L);
        long l3 = newMoonOnOrAfter(l1 + 1L);
        long l4 = newMoonBefore(l2 + 1L);
        long l5 = newMoonBefore(l + 1L);
        boolean flag = Math.round((double) (l4 - l3) / 29.530588853000001D) == 12L;
        month = (int) ProtoDate.adjustedMod(Math.round((double) (l5 - l3) / 29.530588853000001D) - (long) (!flag || !hasPriorLeapMonth(l3, l5) ? 0 : 1), 12L);
        leapMonth = flag && hasNoMajorSolarTerm(l5) && !hasPriorLeapMonth(l3, newMoonBefore(l5));
        long l6 = (long) Math.floor((1.5D - (double) month / 12D) + (double) (l - EPOCH) / 365.242189D);
        cycle = ProtoDate.quotient(l6 - 1L, 60D) + 1L;
        year = (int) ProtoDate.adjustedMod(l6, 60L);
        day = (int) ((l - l5) + 1L);
    }

    public void fromArray(int ai[])
    {
        cycle = ai[0];
        year = ai[1];
        month = ai[2];
        leapMonth = ai[3] != 0;
        day = ai[4];
    }

    public static double solarLongitudeOnOrAfter(long l, double d)
    {
        Location location = chineseLocation(l);
        double d1 = ProtoDate.solarLongitudeAfter(ProtoDate.universalFromStandard(l, location), d);
        return ProtoDate.standardFromUniversal(d1, location);
    }

    public static double midnightInChina(long l)
    {
        return ProtoDate.universalFromStandard(l, chineseLocation(l));
    }

    public static long winterSolsticeOnOrBefore(long l)
    {
        double d = ProtoDate.estimatePriorSolarLongitude(midnightInChina(l + 1L), ConstUI.WINTER);
        long l1;
        for (l1 = (long) (Math.floor(d) - 1.0D); ConstUI.WINTER > ProtoDate.solarLongitude(midnightInChina(l1 + 1L)); l1++)
            ;
        return l1;
    }

    public static long newYearInSui(long l)
    {
        long l1 = winterSolsticeOnOrBefore(l);
        long l2 = winterSolsticeOnOrBefore(l1 + 370L);
        long l3 = newMoonOnOrAfter(l1 + 1L);
        long l4 = newMoonOnOrAfter(l3 + 1L);
        long l5 = newMoonBefore(l2 + 1L);
        if (Math.round((double) (l5 - l3) / 29.530588853000001D) == 12L && (hasNoMajorSolarTerm(l3) || hasNoMajorSolarTerm(l4)))
            return newMoonOnOrAfter(l4 + 1L);
        else
            return l4;
    }

    public static long newYearOnOrBefore(long l)
    {
        long l1 = newYearInSui(l);
        if (l >= l1)
            return l1;
        else
            return newYearInSui(l - 180L);
    }

    public static int nameDifference(ChineseName chinesename, ChineseName chinesename1)
    {
        int i = chinesename1.stem - chinesename.stem;
        int j = chinesename1.branch - chinesename.branch;
        return 1 + ProtoDate.mod((i - 1) + 25 * (j - i), 60);
    }

    public static long dayNameOnOrBefore(ChineseName chinesename, long l)
    {
        return l - ProtoDate.mod(l + (long) nameDifference(chinesename, sexagesimalName(15L)), 60L);
    }

    /*-
    (defun current-major-solar-term (date)
      ;; TYPE fixed-date -> integer
      ;; Last Chinese major solar term (zhongqi) before fixed
      ;; date.
      (let ((s (solar-longitude
                (universal-from-local
                 (jd-from-moment date)
                 (chinese-time-zone date)))))
        (adjusted-mod (+ 2 (quotient s 30)) 12)))
    -*/
    public static int currentMajorSolarTerm(long l)
    {
        double d = ProtoDate.solarLongitude(ProtoDate.universalFromStandard(l, chineseLocation(l)));
        return (int) ProtoDate.adjustedMod(2L + ProtoDate.quotient(d, ProtoDate.deg(30D)), 12L);
    }

    /*-
    (defun major-solar-term-on-or-after (date)
      ;; TYPE fixed-date -> fixed-date
      ;; Fixed date (in Beijing) of the first Chinese major
      ;; solar term (zhongqi) on or after fixed date.  The
      ;; major terms begin when the sun's longitude is a
      ;; multiple of 30 degrees.
      (chinese-date-next-solar-longitude date 30))
    -*/
    public static double majorSolarTermOnOrAfter(long l)
    {
        double d = ProtoDate.mod(30D * Math.ceil(ProtoDate.solarLongitude(midnightInChina(l)) / 30D), 360D);
        return solarLongitudeOnOrAfter(l, d);
    }

    /*-
    (defun current-minor-solar-term (date)
      ;; TYPE fixed-date -> integer
      ;; Last Chinese minor solar term (jieqi) before date.
      (let* ((s (solar-longitude
                 (universal-from-local
                  (jd-from-moment date)
                  (chinese-time-zone date)))))
        (adjusted-mod (+ 3 (quotient (- s 15) 30)) 12)))
    -*/
    public static int currentMinorSolarTerm(long l)
    {
        double d = ProtoDate.solarLongitude(midnightInChina(l));
        return (int) ProtoDate.adjustedMod(3L + ProtoDate.quotient(d - ProtoDate.deg(15D), ProtoDate.deg(30D)), 12L);
    }

    /*-
    (defun minor-solar-term-on-or-after (date)
      ;; TYPE fixed-date -> fixed-date
      ;; Fixed date (in Beijing) of the first Chinese minor
      ;; solar term (jieqi) on or after fixed date.  The
      ;; minor terms begin when the sun's longitude is a
      ;; multiple of 30 degrees.
      (let* ((d (chinese-date-next-solar-longitude date 15))
             (s (solar-longitude
                 (universal-from-local
                  (jd-from-moment d)
                  (chinese-time-zone d)))))
        (if (= (mod (round s) 30) 0)
            (chinese-date-next-solar-longitude d 15)
          d)))
    -*/
    public static double minorSolarTermOnOrAfter(long l)
    {
        double d = ProtoDate.mod(30D * Math.ceil((ProtoDate.solarLongitude(midnightInChina(l)) - ProtoDate.deg(15D)) / 30D) + ProtoDate.deg(15D), 360D);
        return solarLongitudeOnOrAfter(l, d);
    }

    /*-
    (defun chinese-new-moon-before (date)
      ;; TYPE fixed-date -> fixed-date
      ;; Fixed date (Beijing) of first new moon before
      ;; fixed date.
      (fixed-from-jd
       (local-from-universal
        (new-moon-before
         (universal-from-local
          (jd-from-moment date)
          (chinese-time-zone date)))
        (chinese-time-zone date))))
    -*/
    public static long newMoonBefore(long l)
    {
        double d = ProtoDate.newMoonBefore(midnightInChina(l));
        return (long) Math.floor(ProtoDate.standardFromUniversal(d, chineseLocation(d)));
    }

    /*-
    (defun chinese-new-moon-on-or-after (date)
      ;; TYPE fixed-date -> fixed-date
      ;; Fixed date (Beijing) of first new moon on or after
      ;; fixed date.
      (fixed-from-jd
       (local-from-universal
        (new-moon-at-or-after
         (universal-from-local
          (jd-from-moment date)
          (chinese-time-zone date)))
        (chinese-time-zone date))))
    -*/
    public static long newMoonOnOrAfter(long l)
    {
        double d = ProtoDate.newMoonAfter(midnightInChina(l));
        return (long) Math.floor(ProtoDate.standardFromUniversal(d, chineseLocation(d)));
    }

    /*-
    (defun no-major-solar-term? (date)
      ;; TYPE fixed-date -> boolean
      ;; True if Chinese lunar month starting on date
      ;; has no major solar term.
      (= (current-major-solar-term date)
         (current-major-solar-term
          (chinese-new-moon-on-or-after (1+ date)))))
    -*/
    public static boolean hasNoMajorSolarTerm(long l)
    {
        return currentMajorSolarTerm(l) == currentMajorSolarTerm(newMoonOnOrAfter(l + 1L));
    }

    /*-
    (defun prior-leap-month? (m-prime m)
      ;; TYPE (fixed-date fixed-date) -> boolean
      ;; True if there is a Chinese leap month at or after lunar
      ;; month m-prime and at or before lunar month m.
      (and (>= m m-prime)
           (or (prior-leap-month? m-prime
                                  (chinese-new-moon-before m))
               (no-major-solar-term? m))))
    -*/
    public static boolean hasPriorLeapMonth(long l, long l1)
    {
        return l1 >= l && (hasNoMajorSolarTerm(l1) || hasPriorLeapMonth(l, newMoonBefore(l1)));
    }

    /*-
    (defun chinese-sexagesimal-name (n)
      ;; TYPE integer -> ({1--10} {1-12})
      ;; The n-th name of the Chinese sexagesimal cycle.
      (list (adjusted-mod n 10)
            (adjusted-mod n 12)))
    -*/
    public static ChineseName sexagesimalName(long l)
    {
        try
        {
            return new ChineseName((int) ProtoDate.adjustedMod(l, 10L), (int) ProtoDate.adjustedMod(l, 12L));
        }
        catch (Exception _ex)
        {
            return new ChineseName();
        }
    }

    /*-
    (defun chinese-name-of-year (y)
      ;; TYPE chinese-year -> ({1--10} {1-12})
      ;; Sexagesimal name for Chinese year y of any cycle.
      (chinese-sexagesimal-name y))
    -*/
    public static ChineseName nameOfYear(int i)
    {
        return sexagesimalName(i);
    }

    /*-
    (defun chinese-name-of-month (y m)
      ;; TYPE (chinese-year chinese-month) -> ({1--10} {1-12})
      ;; Sexagesimal name for Chinese month m in year y of any
      ;; cycle.
      (chinese-sexagesimal-name (+ ( * 12 y) m 44)))
    -*/
    public static ChineseName nameOfMonth(int i, int j)
    {
        long l = 12L * (long) (i - 1) + (long) (j - 1);
        return sexagesimalName(l + 15L);
    }

    /*-
    (defun chinese-name-of-day (date)
      ;; TYPE chinese-date -> ({1--10} {1-12})
      ;; Sexagesimal name for Chinese date.
      (chinese-sexagesimal-name
       (+ (fixed-from-chinese date) 15)))
    -*/
    public static ChineseName nameOfDay(long l)
    {
        return sexagesimalName(l + 15L);
    }

    public static final Location beijing(double d)
    {
        long l = Gregorian.yearFromFixed((long) Math.floor(d));
        return new Location("Beijing, China", ProtoDate.deg(39.549999999999997D), ProtoDate.angle(116D, 25D, 0.0D), ProtoDate.mt(43.5D), l >= 1929L ? 8D : 7.7611111111111111D);
    }

    public static final Location chineseLocation(double d)
    {
        return beijing(d);
    }

    public static final Location tokyo(double d)
    {
        long l = Gregorian.yearFromFixed((long) Math.floor(d));
        if (l < 1888L)
            return new Location("Tokyo, Japan", ProtoDate.deg(35.700000000000003D), ProtoDate.angle(139D, 46D, 0.0D), ProtoDate.mt(24D), 9.3177777777777777D);
        else
            return new Location("Tokyo, Japan", ProtoDate.deg(35D), ProtoDate.deg(135D), ProtoDate.mt(0.0D), 9D);
    }

    public static final Location japaneseLocation(double d)
    {
        return tokyo(d);
    }

    /*-
    (defun chinese-new-year (g-year)
      ;; TYPE gregorian-year -> fixed-date
      ;; Fixed date of Chinese New Year in Gregorian year.
      (let* ((s1; prior solstice
              (major-solar-term-on-or-after
               (fixed-from-gregorian
                (gregorian-date
                 december 15 (1- g-year)))))
             (s2; following solstice
              (major-solar-term-on-or-after
               (fixed-from-gregorian
                (gregorian-date december 15 g-year))))
             (m1 ; month after last 11th month--either 12 or
                 ; leap 11
              (chinese-new-moon-on-or-after (1+ s1)))
             (m2 ; month after m2--either 1 or leap 12
              (chinese-new-moon-on-or-after (1+ m1)))
             (m11 ; next 11th month
              (chinese-new-moon-before (1+ s2))))
        (if ; Either m1 or m2 is a leap month if there are 13
            ; new moons (12 full lunar months) and either m1 or
            ; m2 has no major solar term
            (and (= (round (/ (- m11 m1) mean-synodic-month)) 12)
                 (or (no-major-solar-term? m1)
                     (no-major-solar-term? m2)))
            (chinese-new-moon-on-or-after (1+ m2))
          m2)))
    -*/
    public static long newYear(long l)
    {
        return newYearOnOrBefore(Gregorian.toFixed(l, 7, 1));
    }

    /*-
    (defun dragon-festival (g-year)
      ;; TYPE gregorian-year -> fixed-date
      ;; Fixed date of the Dragon Festival occurring in
      ;; Gregorian year.
      (let* ((elapsed-years
              (1+ (- g-year
                     (gregorian-year-from-fixed
                      chinese-epoch))))
             (cycle (1+ (quotient (1- elapsed-years) 60)))
             (year (adjusted-mod elapsed-years 60)))
        (fixed-from-chinese (chinese-date cycle year 5 false 5))))
    -*/
    public static long dragonFestival(long l)
    {
        long l1 = (l - Gregorian.yearFromFixed(EPOCH)) + 1L;
        long l2 = ProtoDate.quotient(l1 - 1L, 60D) + 1L;
        int i = (int) ProtoDate.adjustedMod(l1, 60L);
        return toFixed(l2, i, 5, false, 5);
    }

    public static long qingMing(long l)
    {
        return (long) Math.floor(minorSolarTermOnOrAfter(Gregorian.toFixed(l, 3, 30)));
    }

    public static long age(Chinese chinese, long l) throws Exception
    {
        Chinese chinese1 = new Chinese(l);
        if (l >= chinese.toFixed())
            return 60L * (chinese1.cycle - chinese.cycle) + (long) (chinese1.year - chinese.year) + 1L;
        else
            throw new Exception();
    }

    protected String toStringFields()
    {
        return "cycle=" + cycle + ",year=" + year + ",month=" + month + ",leapMonth=" + leapMonth + ",day=" + day;
    }

    public String format()
    {
        ChineseName chinesename = nameOfYear(year);
        StringBuffer sb = new StringBuffer();
        sb.append(ProtoDate.nameFromNumber(chinesename.stem, yearStemNames));
        sb.append(ProtoDate.nameFromNumber(chinesename.branch, yearBranchNames));
        sb.append(P3040000.getMesg(LangRes.P3041103));

        sb.append(" ");

        if (leapMonth)
        {
            sb.append(P3040000.getMesg(LangRes.P3041120));
            sb.append(P3040000.getMesg(LangRes.P3041122));
            sb.append(P3040000.getMesg(LangRes.P3041121));
        }

        // 月份
        switch (month)
        {
            case ConstUI.JANUARY:
                sb.append(P3040000.getMesg(LangRes.P3041106));
                break;
            case ConstUI.FEBRUARY:
                sb.append(P3040000.getMesg(LangRes.P3041107));
                break;
            case ConstUI.MARCH:
                sb.append(P3040000.getMesg(LangRes.P3041108));
                break;
            case ConstUI.APRIL:
                sb.append(P3040000.getMesg(LangRes.P3041109));
                break;
            case ConstUI.MAY:
                sb.append(P3040000.getMesg(LangRes.P304110A));
                break;
            case ConstUI.JUNE:
                sb.append(P3040000.getMesg(LangRes.P304110B));
                break;
            case ConstUI.JULY:
                sb.append(P3040000.getMesg(LangRes.P304110C));
                break;
            case ConstUI.AUGUST:
                sb.append(P3040000.getMesg(LangRes.P304110D));
                break;
            case ConstUI.SEPTEMBER:
                sb.append(P3040000.getMesg(LangRes.P304110E));
                break;
            case ConstUI.OCTOBER:
                sb.append(P3040000.getMesg(LangRes.P304110F));
                break;
            case ConstUI.NOVEMBER:
                sb.append(P3040000.getMesg(LangRes.P3041110));
                break;
            case ConstUI.DECEMBER:
                sb.append(P3040000.getMesg(LangRes.P3041111));
                break;
        }
        sb.append(P3040000.getMesg(LangRes.P3041104));

        // 日期
        sb.append(" ");
        if (day == 10)
        {
            sb.append(P3040000.getMesg(LangRes.P3041112));
        }
        else
        {
            switch (day / 10)
            {
                case 0:
                    sb.append(P3040000.getMesg(LangRes.P3041112));
                    break;
                case 1:
                    sb.append(P3040000.getMesg(LangRes.P3041113));
                    break;
                case 2:
                    sb.append(P3040000.getMesg(LangRes.P3041114));
                    break;
                case 3:
                    sb.append(P3040000.getMesg(LangRes.P3041115));
                    break;
            }
        }

        switch (day % 10)
        {
            case 1:
                sb.append(P3040000.getMesg(LangRes.P3041116));
                break;
            case 2:
                sb.append(P3040000.getMesg(LangRes.P3041117));
                break;
            case 3:
                sb.append(P3040000.getMesg(LangRes.P3041118));
                break;
            case 4:
                sb.append(P3040000.getMesg(LangRes.P3041119));
                break;
            case 5:
                sb.append(P3040000.getMesg(LangRes.P304111A));
                break;
            case 6:
                sb.append(P3040000.getMesg(LangRes.P304111B));
                break;
            case 7:
                sb.append(P3040000.getMesg(LangRes.P304111C));
                break;
            case 8:
                sb.append(P3040000.getMesg(LangRes.P304111D));
                break;
            case 9:
                sb.append(P3040000.getMesg(LangRes.P304111E));
                break;
            case 0:
                sb.append(P3040000.getMesg(LangRes.P304111F));
                break;
        }

        return sb.toString();
    }

    public boolean equals(Object obj)
    {
        if (this == obj)
            return true;
        if (!(obj instanceof Chinese))
            return false;
        Chinese chinese = (Chinese) obj;
        return chinese.cycle == cycle && chinese.year == year && chinese.month == month && chinese.leapMonth == leapMonth && chinese.day == day;
    }

    public long cycle;
    public int year;
    public int month;
    public boolean leapMonth;
    public int day;
    public static final long EPOCH = Gregorian.toFixed(-2636L, 2, 15);
    public static final int DAY_NAME_EPOCH = 15;
    public static final int MONTH_NAME_EPOCH = 3;
    public static final String yearStemNames[] =
    { P3040000.getMesg(LangRes.P3041B01), P3040000.getMesg(LangRes.P3041B04), P3040000.getMesg(LangRes.P3041B07), P3040000.getMesg(LangRes.P3041B0A), P3040000.getMesg(LangRes.P3041B0D),
            P3040000.getMesg(LangRes.P3041B10), P3040000.getMesg(LangRes.P3041B13), P3040000.getMesg(LangRes.P3041B16), P3040000.getMesg(LangRes.P3041B19), P3040000.getMesg(LangRes.P3041B1C) };
    public static final String yearBranchNames[] =
    { P3040000.getMesg(LangRes.P3041B1F), P3040000.getMesg(LangRes.P3041B22), P3040000.getMesg(LangRes.P3041B25), P3040000.getMesg(LangRes.P3041B28), P3040000.getMesg(LangRes.P3041B2B),
            P3040000.getMesg(LangRes.P3041B2E), P3040000.getMesg(LangRes.P3041B31), P3040000.getMesg(LangRes.P3041B34), P3040000.getMesg(LangRes.P3041B37), P3040000.getMesg(LangRes.P3041B3A),
            P3040000.getMesg(LangRes.P3041B3D), P3040000.getMesg(LangRes.P3041B40) };

    /** serialVersionUID */
    private static final long serialVersionUID = 8443707750522695735L;
}
