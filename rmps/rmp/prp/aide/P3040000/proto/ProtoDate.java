package rmp.prp.aide.P3040000.proto;

import java.io.Serializable;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.lunar.LunarDate;
import rmp.prp.aide.P3040000.solar.Gregorian;
import cons.prp.aide.P3040000.ConstUI;

public abstract class ProtoDate implements Cloneable, Serializable
{
    public ProtoDate()
    {
    }

    public ProtoDate(long l)
    {
        fromFixed(l);
    }

    public ProtoDate(LunarDate date)
    {
        fromDate(date);
    }

    /**
     * date conversion methods
     * 
     * @param l
     */
    public abstract void fromFixed(long l);

    public abstract void fromArray(int ai[]);

    protected abstract String toStringFields();

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#equals(java.lang.Object)
     */
    public abstract boolean equals(Object obj);

    /*
     * (non-Javadoc)
     * 
     * @see java.lang.Object#toString()
     */
    public String toString()
    {
        return getClass().getName() + "[" + toStringFields() + "]";
    }

    public String format()
    {
        return toString();
    }

    public void fromDate(LunarDate date)
    {
        convert(date, this);
    }

    public static double lunarPhase(double d)
    {
        return mod(lunarLongitude(d) - solarLongitude(d), 360D);
    }

    /*-
    (defun solar-longitude (jd)
      ;; TYPE julian-day-number -> angle
      ;; Longitude of sun on astronomical (julian) day number jd.
      ;; Adapted from "Planetary Programs and Tables from -4000
      ;; to +2800" by Pierre Bretagnon and Jean-Louis Simon,
      ;; Willmann-Bell, Inc., 1986.
      (let* ((c       ; Ephemeris time in Julian centuries
              (julian-centuries jd))
             (coefficients
              (list 403406 195207 119433 112392 3891 2819 1721 0
                    660 350 334 314 268 242 234 158 132 129 114
                    99 93 86 78 72 68 64 46 38 37 32 29 28 27 27
                    25 24 21 21 20 18 17 14 13 13 13 12 10 10 10
                    10))
             (multipliers
              (list 0.01621043d0 628.30348067d0 628.30821524d0
                    628.29634302d0 1256.605691d0 1256.60984d0
                    628.324766d0 0.00813d0 1256.5931d0
                    575.3385d0 -0.33931d0 7771.37715d0
                    786.04191d0 0.05412d0 393.02098d0 -0.34861d0
                    1150.67698d0 157.74337d0 52.9667d0
                    588.4927d0 52.9611d0 -39.807d0 522.3769d0
                    550.7647d0 2.6108d0 157.7385d0 1884.9103d0
                    -77.5655d0 2.6489d0 1179.0627d0 550.7575d0
                    -79.6139d0 1884.8981d0 21.3219d0 1097.7103d0
                    548.6856d0 254.4393d0 -557.3143d0 606.9774d0
                    21.3279d0 1097.7163d0 -77.5282d0 1884.9191d0
                    2.0781d0 294.2463d0 -0.0799d0 469.4114d0
                    -0.6829d0 214.6325d0 1572.084d0))
             (addends
              (list 4.721964d0 5.937458d0 1.115589d0 5.781616d0
                    5.5474d0 1.512d0 4.1897d0 1.163d0 5.415d0
                    4.315d0 4.553d0 5.198d0 5.989d0 2.911d0
                    1.423d0 0.061d0 2.317d0 3.193d0 2.828d0
                    0.52d0 4.65d0 4.35d0 2.75d0 4.5d0 3.23d0
                    1.22d0 0.14d0 3.44d0 4.37d0 1.14d0 2.84d0
                    5.96d0 5.09d0 1.72d0 2.56d0 1.92d0 0.09d0
                    5.98d0 4.03d0 4.47d0 0.79d0 4.24d0 2.01d0
                    2.65d0 4.98d0 0.93d0 2.21d0 3.59d0 1.5d0
                    2.55d0))
             (longitude
              (+ 4.9353929d0
                 ( * 628.33196168d0 c)
                 ( * 0.0000001d0
                    (sigma ((x coefficients)
                            (y addends)
                            (z multipliers))
                           ( * x (sin (+ y ( * z c)))))))))
        (radians-to-degrees
         (+ longitude (aberration c) (nutation c)))))
    -*/
    public static double solarLongitude(double d)
    {
        double d1 = julianCenturies(d);
        double d2 = 0.0D;
        for (int i = 0; i < ConstUI.SL_COEFFICIENTS.length; i++)
        {
            d2 += ConstUI.SL_COEFFICIENTS[i] * sinDegrees(ConstUI.SL_MULTIPLIERS[i] * d1 + ConstUI.SL_ADDENDS[i]);
        }

        double d3 = deg(282.77718340000001D) + 36000.769537439999D * d1 + 5.7295779513082322E-006D * d2;
        return mod(d3 + aberration(d) + nutation(d), 360D);
    }

    public static double solarLongitudeAfter(double d, double d1)
    {
        double d2 = 1.0000000000000001E-005D;
        double d3 = 365.242189D / deg(360D);
        double d4 = d + d3 * mod(d1 - solarLongitude(d), 360D);
        double d5 = Math.max(d, d4 - 5D);
        double d6 = d4 + 5D;
        double d7 = d5;
        double d8 = d6;
        double d9;
        for (d9 = (d8 + d7) / 2D; d8 - d7 > d2; d9 = (d8 + d7) / 2D)
            if (mod(solarLongitude(d9) - d1, 360D) < deg(180D))
                d8 = d9;
            else
                d7 = d9;

        return d9;
    }

    /*-
    (defun new-moon-before (jd)
      ;; TYPE julian-day-number -> julian-day-number
      ;; Astronomical (julian) day number of last new moon
      ;; before astronomical (julian) day number jd (in
      ;; Greenwich).  The fractional part is the time of day.
      (new-moon-at-or-after (- (new-moon-at-or-after jd) 45)))
    -*/
    public static double newMoonBefore(double d)
    {
        double d1 = nthNewMoon(0L);
        double d2 = lunarPhase(d);
        long l = Math.round((d - d1) / 29.530588853000001D - d2 / deg(360D));
        long l1;
        for (l1 = l - 1L; nthNewMoon(l1) < d; l1++)
            ;
        l1--;
        return nthNewMoon(l1);
    }

    /*-
    (defun lunar-longitude (u-time)
      ;; TYPE moment -> angle
      ;; Longitude of moon (in degrees) at u-time (Universal time).
      ;; Adapted from "Astronomical Algorithms" by Jean Meeus,
      ;; Willmann-Bell, Inc., 1991.
      (let* ((c (julian-centuries u-time))
             (mean-moon
              (degrees
               (poly c
                     (list 218.3164591d0 481267.88134236d0
                           -.0013268d0 1/538841 -1/65194000))))
             (elongation
              (degrees
               (poly c
                     (list 297.8502042d0 445267.1115168d0
                           -.00163d0 1/545868 -1/113065000))))
             (solar-anomaly
              (degrees
               (poly c
                     (list 357.5291092d0 35999.0502909d0
                           -.0001536d0 1/24490000))))
             (lunar-anomaly
              (degrees
               (poly c
                     (list 134.9634114d0 477198.8676313d0
                           0.008997d0 1/69699 -1/14712000))))
             (moon-from-node
              (degrees
               (poly c
                     (list 93.2720993d0 483202.0175273d0
                           -.0034029d0 -1/3526000 1/863310000))))
             (e (poly c (list 1 -0.002516d0 -0.0000074d0)))
             (args-lunar-elongation
              (list 0 2 2 0 0 0 2 2 2 2 0 1 0 2 0 0 4 0 4 2 2 1
                    1 2 2 4 2 0 2 2 1 2 0 0 2 2 2 4 0 3 2 4 0 2
                    2 2 4 0 4 1 2 0 1 3 4 2 0 1 2 2))
             (args-solar-anomaly
              (list 0 0 0 0 1 0 0 -1 0 -1 1 0 1 0 0 0 0 0 0 1 1
                    0 1 -1 0 0 0 1 0 -1 0 -2 1 2 -2 0 0 -1 0 0 1
                    -1 2 2 1 -1 0 0 -1 0 1 0 1 0 0 -1 2 1 0 0))
             (args-lunar-anomaly
              (list 1 -1 0 2 0 0 -2 -1 1 0 -1 0 1 0 1 1 -1 3 -2
                    -1 0 -1 0 1 2 0 -3 -2 -1 -2 1 0 2 0 -1 1 0
                    -1 2 -1 1 -2 -1 -1 -2 0 1 4 0 -2 0 2 1 -2 -3
                    2 1 -1 3 -1))
             (args-moon-from-node
              (list 0 0 0 0 0 2 0 0 0 0 0 0 0 -2 2 -2 0 0 0 0 0
                    0 0 0 0 0 0 0 2 0 0 0 0 0 0 -2 2 0 2 0 0 0 0
                    0 0 -2 0 0 0 0 -2 -2 0 0 0 0 0 0 0 -2))
             (sine-coefficients
              (list 6288774 1274027 658314 213618 -185116 -114332
                    58793 57066 53322 45758 -40923 -34720 -30383
                    15327 -12528 10980 10675 10034 8548 -7888
                    -6766 -5163 4987 4036 3994 3861 3665 -2689
                    -2602 2390 -2348 2236 -2120 -2069 2048 -1773
                    -1595 1215 -1110 -892 -810 759 -713 -700 691
                    596 549 537 520 -487 -399 -381 351 -340 330
                    327 -323 299 294 0))
             (longitude
              ( * 1/1000000
                 (sigma ((v sine-coefficients)
                         (w args-lunar-elongation)
                         (x args-solar-anomaly)
                         (y args-lunar-anomaly)
                         (z args-moon-from-node))
                        ( * v (expt e (abs x))
                           (sin-degrees
                            (+ ( * w elongation)
                               ( * x solar-anomaly)
                               ( * y lunar-anomaly)
                               ( * z moon-from-node)))))))
             (venus ( * 3958/1000000
                       (sin-degrees
                        (+ 119.75d0 ( * c 131.849d0)))))
             (jupiter ( * 318/1000000
                         (sin-degrees
                          (+ 53.09d0 ( * c 479264.29d0)))))
             (flat-earth
              ( * 1962/1000000
                 (sin-degrees (- mean-moon moon-from-node)))))
        (degrees (+ mean-moon longitude venus jupiter flat-earth
                    (radians-to-degrees (nutation c))))))
    -*/
    public static double lunarLongitude(double d)
    {
        double d1 = julianCenturies(d);
        double d2 = degrees(poly(d1, ConstUI.LLON_COEFFMEANMOON));
        double d3 = degrees(poly(d1, ConstUI.LLON_COEFFELONGATION));
        double d4 = degrees(poly(d1, ConstUI.LLON_COEFFSOLARANOMALY));
        double d5 = degrees(poly(d1, ConstUI.LLON_COEFFLUNARANOMALY));
        double d6 = degrees(poly(d1, ConstUI.LLON_COEFFMOONNODE));
        double d7 = poly(d1, ConstUI.LLON_COEFFCAPE);
        double d8 = 0.0D;
        for (int i = 0; i < ConstUI.LLON_ARGSLUNARELONGATION.length; i++)
        {
            double d9 = ConstUI.LLON_ARGSSOLARANOMALY[i];
            d8 += ConstUI.LLON_SINECOEFFICIENTS[i] * Math.pow(d7, Math.abs(d9))
                    * sinDegrees(ConstUI.LLON_ARGSLUNARELONGATION[i] * d3 + d9 * d4 + ConstUI.LLON_ARGSLUNARANOMALY[i] * d5 + ConstUI.LLON_ARGSMOONFROMNODE[i] * d6);
        }

        double d10 = (deg(1.0D) / 1000000D) * d8;
        double d11 = (deg(3958D) / 1000000D) * sinDegrees(119.75D + d1 * 131.84899999999999D);
        double d12 = (deg(318D) / 1000000D) * sinDegrees(53.090000000000003D + d1 * 479264.28999999998D);
        double d13 = (deg(1962D) / 1000000D) * sinDegrees(d2 - d6);
        return mod(d2 + d10 + d11 + d12 + d13 + nutation(d), 360D);
    }

    public static final void convert(LunarDate date, ProtoDate protodate)
    {
        protodate.fromFixed(date.toFixed());
    }

    public static final double currentMoment()
    {
        return (double) Gregorian.toFixed(1970L, 1, 1) + (double) System.currentTimeMillis() / 86400000D;
    }

    public static final long currentDate()
    {
        return (long) currentMoment();
    }

    /*-
    (defun gregorian-date-difference (g-date1 g-date2)
      ;; TYPE (gregorian-date gregorian-date) -> integer
      ;; Number of days from Gregorian date g-date1 until g-date2.
      (- (fixed-from-gregorian g-date2)
         (fixed-from-gregorian g-date1)))
    -*/
    public static final long difference(LunarDate date, LunarDate date1)
    {
        return date1.toFixed() - date.toFixed();
    }

    public static final long difference(long l, LunarDate date)
    {
        return date.toFixed() - l;
    }

    public static final long difference(LunarDate date, long l)
    {
        return l - date.toFixed();
    }

    public static final long difference(long l, long l1)
    {
        return l1 - l;
    }

    public static final double mod(double i, double j)
    {
        return i - j * Math.floor(i / j);
    }

    public static final int mod(int i, int j)
    {
        return (int) ((double) i - (double) j * Math.floor((double) i / (double) j));
    }

    public static final long mod(long l, long l1)
    {
        return (long) ((double) l - (double) l1 * Math.floor((double) l / (double) l1));
    }

    /*-
    (defun quotient (m n)
      ;; TYPE (real non-zero-real) -> integer
      ;; Whole part of m/n.
      (floor m n))
    -*/
    public static final long quotient(double d, double d1)
    {
        return (long) Math.floor(d / d1);
    }

    /*-
    (defun adjusted-mod (m n)
      ;; TYPE (integer positive-integer) -> positive-integer
      ;; Positive remainder of m/n with n instead of 0.
      (1+ (mod (1- m) n)))
    -*/
    public static final int adjustedMod(int i, int j)
    {
        return j + mod(i, -j);
    }

    public static final long adjustedMod(long l, long l1)
    {
        return l1 + mod(l, -l1);
    }

    public static final double adjustedMod(double d, double d1)
    {
        return d1 + mod(d, -d1);
    }

    /*-
    (defun day-of-week-from-fixed (date)
      ;; TYPE fixed-date -> day-of-week
      ;; The residue class of the day of the week of date.
      (mod date 7))
    -*/
    public static final long dayOfWeekFromFixed(long l)
    {
        return mod(l, 7L);
    }

    /*-
    (defun kday-on-or-before (date k)
      ;; TYPE (fixed-date weekday) -> fixed-date
      ;; Fixed date of the k-day on or before fixed date.
      ;; k=0 means Sunday, k=1 means Monday, and so on.
      (- date (day-of-week-from-fixed (- date k))))
    -*/
    public static final long kDayOnOrBefore(long l, int i)
    {
        return l - dayOfWeekFromFixed(l - (long) i);
    }

    /*-
    (defun kday-on-or-after (date k)
      ;; TYPE (fixed-date weekday) -> fixed-date
      ;; Fixed date of the k-day on or after fixed date.
      ;; k=0 means Sunday, k=1 means Monday, and so on.
      (kday-on-or-before (+ date 6) k))
    -*/
    public static final long kDayOnOrAfter(long l, int i)
    {
        return kDayOnOrBefore(l + 6L, i);
    }

    /*-
    (defun kday-nearest (date k)
      ;; TYPE (fixed-date weekday) -> fixed-date
      ;; Fixed date of the k-day nearest fixed date.  k=0
      ;; means Sunday, k=1 means Monday, and so on.
      (kday-on-or-before (+ date 3) k))
    -*/
    public static final long kDayNearest(long l, int i)
    {
        return kDayOnOrBefore(l + 3L, i);
    }

    /*-
    (defun kday-after (date k)
      ;; TYPE (fixed-date weekday) -> fixed-date
      ;; Fixed date of the k-day after fixed date.  k=0
      ;; means Sunday, k=1 means Monday, and so on.
      (kday-on-or-before (+ date 7) k))
    -*/
    public static final long kDayAfter(long l, int i)
    {
        return kDayOnOrBefore(l + 7L, i);
    }

    /*-
    (defun kday-before (date k)
      ;; TYPE (fixed-date weekday) -> fixed-date
      ;; Fixed date of the k-day before fixed date.  k=0
      ;; means Sunday, k=1 means Monday, and so on.
      (kday-on-or-before (1- date) k))
    -*/
    public static final long kDayBefore(long l, int i)
    {
        return kDayOnOrBefore(l - 1L, i);
    }

    /*-
    (defun nth-kday (n k date)
      ;; TYPE (integer weekday gregorian-date) -> fixed-date
      ;; Fixed date of n-th k-day after Gregorian date.  If
      ;; n>0, return the n-th k-day on or after date.
      ;; If n<0, return the n-th k-day on or before date.
      ;; A k-day of 0 means Sunday, 1 means Monday, and so on.
      (if (> n 0)
          (+ ( * 7 n)
             (kday-before (fixed-from-gregorian date) k))
        (+ ( * 7 n)
           (kday-after (fixed-from-gregorian date) k))))
    -*/
    public static final long nthKDay(int i, int j, long l)
    {
        if (i > 0)
            return kDayBefore(l, j) + (long) (7 * i);
        else
            return kDayAfter(l, j) + (long) (7 * i);
    }

    public static final long firstKDay(int i, long l)
    {
        return nthKDay(1, i, l);
    }

    public static final long lastKDay(int i, long l)
    {
        return nthKDay(-1, i, l);
    }

    public static final int signum(double d)
    {
        if (d < 0.0D)
            return -1;
        return d <= 0.0D ? 0 : 1;
    }

    public static final double square(double d)
    {
        return d * d;
    }

    /*-
    (defun poly (x a)
      ;; TYPE (real list-of-reals) -> real
      ;; Sum powers of x with coefficients (from order 0 up)
      ;; in list a.
      (if (equal a nil)
          0
        (+ (first a) ( * x (poly x (cdr a))))))
    -*/
    public static final double poly(double d, double ad[])
    {
        double d1 = ad[0];
        for (int i = 1; i < ad.length; i++)
            d1 += ad[i] * Math.pow(d, i);

        return d1;
    }

    public static final double hr(double d)
    {
        return d / 24D;
    }

    public static final double mt(double d)
    {
        return d;
    }

    public static final double deg(double d)
    {
        return d;
    }

    public static final double[] deg(double ad[])
    {
        return ad;
    }

    public static final double angle(double d, double d1, double d2)
    {
        return d + (d1 + d2 / 60D) / 60D;
    }

    /*-
    (defun degrees (theta)
      ;; TYPE real -> angle
      ;; Normalize angle theta to range 0-360 degrees.
      (mod theta 360))
    -*/
    public static final double degrees(double d)
    {
        return mod(d, 360D);
    }

    /*-
    (defun radians-to-degrees (theta)
      ;; TYPE radian -> angle
      ;; Convert angle theta from radians to degrees.
      (degrees (/ theta pi 1/180)))
    -*/
    public static final double radiansToDegrees(double d)
    {
        return degrees((d / 3.1415926535897931D) * 180D);
    }

    /*-
    (defun degrees-to-radians (theta)
      ;; TYPE real -> radian
      ;; Convert angle theta from degrees to radians.
      ( * (degrees theta) pi 1/180))
    -*/
    public static final double degreesToRadians(double d)
    {
        return (degrees(d) * 3.1415926535897931D) / 180D;
    }

    /*-
    (defun sin-degrees (theta)
      ;; TYPE angle -> amplitude
      ;; Sine of theta (given in degrees).
      (sin (degrees-to-radians theta)))
    -*/
    public static final double sinDegrees(double d)
    {
        return Math.sin(degreesToRadians(d));
    }

    /*-
    (defun cosine-degrees (theta)
      ;; TYPE angle -> amplitude
      ;; Cosine of theta (given in degrees).
      (cos (degrees-to-radians theta)))
    -*/
    public static final double cosDegrees(double d)
    {
        return Math.cos(degreesToRadians(d));
    }

    /*-
    (defun tangent-degrees (theta)
      ;; TYPE angle -> real
      ;; Tangent of theta (given in degrees).
      (tan (degrees-to-radians theta)))
    -*/
    public static final double tanDegrees(double d)
    {
        return Math.tan(degreesToRadians(d));
    }

    /*-
    (defun arctan-degrees (x quad)
      ;; TYPE (real quadrant) -> angle
      ;; Arctangent of x in degrees in quadrant quad.
      (let* ((deg (radians-to-degrees (atan x))))
        (if (or (= quad 1) (= quad 4))
            deg
          (+ deg 180))))
    -*/
    public static final double arcTanDegrees(double d, int i)
    {
        double d1 = radiansToDegrees(Math.atan(d));
        return mod(i != 1 && i != 4 ? d1 + deg(180D) : d1, 360D);
    }

    /*-
    (defun arcsin-degrees (x)
      ;; TYPE amplitude -> angle
      ;; Arcsine of x in degrees.
      (radians-to-degrees (asin x)))
    -*/
    public static final double arcSinDegrees(double d)
    {
        return radiansToDegrees(Math.asin(d));
    }

    /*-
    (defun arccos-degrees (x)
      ;; TYPE amplitude -> angle
      ;; Arccosine of x in degrees.
      (radians-to-degrees (acos x)))
    -*/
    public static final double arcCosDegrees(double d)
    {
        return radiansToDegrees(Math.acos(d));
    }

    public static final double standardFromUniversal(double d, Location location)
    {
        return d + location.zone / 24D;
    }

    public static final double universalFromStandard(double d, Location location)
    {
        return d - location.zone / 24D;
    }

    /*-
    (defun local-from-universal (u-time zone)
      ;; TYPE (moment real-minute) -> moment
      ;; Local time from u-time in universal time at time-zone
      ;; zone.
      (+ u-time (/ zone 24d0 60d0)))
    -*/
    public static final double localFromUniversal(double d, Location location)
    {
        return d + location.longitude / deg(360D);
    }

    /*-
    (defun universal-from-local (l-time zone)
      ;; TYPE (moment real-minute) -> moment
      ;; Universal time from l-time in local time at time-zone
      ;; zone.
      (- l-time (/ zone 24d0 60d0)))
    -*/
    public static final double universalFromLocal(double d, Location location)
    {
        return d - location.longitude / deg(360D);
    }

    /*-
    (defun standard-from-local (l-time offset)
      ;; TYPE (moment real-minute) -> moment
      ;; Standard time from local l-time at distance
      ;; offset (in minutes) from time zone.
      (- l-time (/ offset 24d0 60d0)))
    -*/
    public static final double standardFromLocal(double d, Location location)
    {
        return standardFromUniversal(universalFromLocal(d, location), location);
    }

    /*-
    (defun local-from-standard (s-time offset)
      ;; TYPE (moment real-minute) -> moment
      ;; Local time from standard s-time at distance
      ;; offset (in minutes) from time zone.
      (+ s-time (/ offset 24d0 60d0)))
    -*/
    public static final double localFromStandard(double d, Location location)
    {
        return localFromUniversal(universalFromStandard(d, location), location);
    }

    public static final double midday(long l, Location location)
    {
        return standardFromLocal(localFromApparent((double) l + hr(12D)), location);
    }

    public static final double midnight(long l, Location location)
    {
        return standardFromLocal(localFromApparent(l), location);
    }

    /*-
    (defun moment-from-jd (jd)
      ;; TYPE julian-day-number -> moment
      ;; Fixed time of astronomical (julian) day number jd.
      (+ jd jd-start))
    -*/
    public static final double momentFromJD(double d)
    {
        return d + -1721424.5D;
    }

    /*-
    (defun jd-from-moment (moment)
      ;; TYPE moment -> julian-day-number
      ;; Astronomical (julian) day number of fixed moment moment.
      (- moment jd-start))
    -*/
    public static final double jdFromMoment(double d)
    {
        return d - -1721424.5D;
    }

    /*-
    (defun fixed-from-jd (jd)
      ;; TYPE julian-day-number -> fixed-date
      ;; Fixed date of astronomical (julian) day number jd.
      (floor (moment-from-jd jd)))
    -*/
    public static final long fixedFromJD(double d)
    {
        return (long) Math.floor(momentFromJD(d));
    }

    public static final double jdFromFixed(long l)
    {
        return jdFromMoment(l);
    }

    public static final long fixedFromMJD(double d)
    {
        return (long) Math.floor(d + 678576D);
    }

    public static final double mjdFromFixed(long l)
    {
        return (double) (l - 0xa5ab0L);
    }

    public static final double direction(Location location, Location location1)
    {
        double d = location.latitude;
        double d1 = location1.latitude;
        double d2 = location.longitude;
        double d3 = location1.longitude;
        double d4 = cosDegrees(d) * tanDegrees(d1) - sinDegrees(d) * cosDegrees(d2 - d3);
        if (d4 == 0.0D)
            return 0.0D;
        else
            return mod(arcTanDegrees(sinDegrees(d3 - d2) / d4, d4 >= 0.0D ? 1 : 2), 360D);
    }

    /*-
    (defun julian-centuries (moment)
      ;; TYPE moment -> moment
      ;; Julian centuries since j2000 at Universal time.
      (/ (- (ephemeris-from-universal moment) j2000)
         36525d0))
    -*/
    public static final double julianCenturies(double d)
    {
        return (dynamicalFromUniversal(d) - ConstUI.J2000) / 36525D;
    }

    public static final double obliquity(double d)
    {
        double d1 = julianCenturies(d);
        return angle(23D, 26D, 21.448D) + poly(d1, ConstUI.OB_COEFFOBLIQUITY);
    }

    public static final double momentFromDepression(double d, Location location, double d1) throws Exception
    {
        double d2 = location.latitude;
        double d3 = universalFromLocal(d, location);
        double d4 = arcSinDegrees(sinDegrees(obliquity(d3)) * sinDegrees(solarLongitude(d3)));
        boolean flag = mod(d, 1.0D) < 0.5D;
        double d5 = tanDegrees(d2) * tanDegrees(d4) + sinDegrees(d1) / (cosDegrees(d4) * cosDegrees(d2));
        double d6 = mod(0.5D + arcSinDegrees(d5) / deg(360D), 1.0D) - 0.5D;
        if (Math.abs(d5) > 1.0D)
            throw new Exception();
        else
            return localFromApparent(Math.floor(d) + (flag ? 0.25D - d6 : 0.75D + d6));
    }

    public static final double dawn(long l, Location location, double d) throws Exception
    {
        double d1;
        try
        {
            d1 = momentFromDepression((double) l + 0.25D, location, d);
        }
        catch (Exception _ex)
        {
            d1 = l;
        }
        double d2 = momentFromDepression(d1, location, d);
        return standardFromLocal(d2, location);
    }

    public static final double dusk(long l, Location location, double d) throws Exception
    {
        double d1;
        try
        {
            d1 = momentFromDepression((double) l + 0.75D, location, d);
        }
        catch (Exception _ex)
        {
            d1 = (double) l + 0.98999999999999999D;
        }
        double d2 = momentFromDepression(d1, location, d);
        return standardFromLocal(d2, location);
    }

    /*-
    (defun sunrise (date latitude longitude)
      ;; TYPE (fixed-date angle angle) -> moment
      ;; Local time (fraction of day) of sunrise at latitude,
      ;; longitude (in nonpolar regions) for fixed date.
      (solar-moment date latitude longitude -0.25d0))
    -*/
    public static final double sunrise(long l, Location location) throws Exception
    {
        double d = Math.max(0.0D, location.elevation);
        double d1 = mt(6372000D);
        double d2 = arcCosDegrees(d1 / (d1 + d));
        double d3 = angle(0.0D, 50D, 0.0D) + d2;
        return dawn(l, location, d3);
    }

    /*-
    (defun sunset (date latitude longitude)
      ;; TYPE (fixed-date angle angle) -> moment
      ;; Local time (fraction of day) of sunset at latitude,
      ;; longitude (in nonpolar regions) for fixed date.
      (solar-moment date latitude longitude 0.25d0))
    -*/
    public static final double sunset(long l, Location location) throws Exception
    {
        double d = Math.max(0.0D, location.elevation);
        double d1 = mt(6372000D);
        double d2 = arcCosDegrees(d1 / (d1 + d));
        double d3 = angle(0.0D, 50D, 0.0D) + d2;
        return dusk(l, location, d3);
    }

    public static final double temporalHour(long l, Location location) throws Exception
    {
        return (sunset(l, location) - sunrise(l, location)) / 12D;
    }

    public static final double standardFromSundial(long l, double d, Location location) throws Exception
    {
        double d1 = temporalHour(l, location);
        return sunrise(l, location) + (d < 6D || d > 18D ? (d - 6D) * (0.083333333333333329D - d1) : (d - 6D) * d1);
    }

    /*-
    (defun universal-from-ephemeris (jd)
      ;; TYPE julian-day-number -> julian-day-number
      ;; Universal time from Ephemeris time.
      (- jd (ephemeris-correction (moment-from-jd jd))))
    -*/
    public static final double universalFromEphemeris(double jd)
    {
        return jd - ephemerisCorrection(momentFromJD(jd));
    }

    /*-
    (defun ephemeris-from-universal (jd)
      ;; TYPE julian-day-number -> julian-day-number
      ;; Ephemeris time at Universal time.
      (+ jd (ephemeris-correction (moment-from-jd jd))))
    -*/
    public static final double ephemerisFromUniversal(double jd)
    {
        return jd + ephemerisCorrection(momentFromJD(jd));
    }

    public static final double universalFromDynamical(double d)
    {
        return d - ephemerisCorrection(d);
    }

    public static final double dynamicalFromUniversal(double d)
    {
        return d + ephemerisCorrection(d);
    }

    /*-
    (defun ephemeris-correction (moment)
      ;; TYPE moment -> fraction-of-day
      ;; Ephemeris Time minus Universal Time (in days) for
      ;; fixed time.  Adapted from "Astronomical Algorithms"
      ;; by Jean Meeus, Willmann-Bell, Inc., 1991.
      (let* ((year (gregorian-year-from-fixed moment))
             (theta (/ (gregorian-date-difference
                        (gregorian-date january 1 1900)
                        (gregorian-date july 1 year))
                       36525d0))
             (coeff-19th
              (list -0.00002d0 0.000297d0 0.025184d0
                    -0.181133d0 0.553040d0 -0.861938d0
                    0.677066d0 -0.212591d0))
             (coeff-18th
              (list -0.000009d0 0.003844d0 0.083563d0
                    0.865736d0 4.867575d0 15.845535d0
                    31.332267d0 38.291999d0 28.316289d0
                    11.636204d0 2.043794d0)))
        (cond ((<= 1988 year 2019)
               (/ (- year 1933) 24d0 60d0 60d0))
              ((<= 1900 year 1987)
               (poly theta coeff-19th))
              ((<= 1800 year 1899)
               (poly theta coeff-18th))
              ((<= 1620 year 1799)
               (/ (poly (- year 1600)
                        (list 196.58333d0 -4.0675d0 0.0219167d0))
                  24d0 60d0 60d0))
              (t (let* ((x (+ 0.5d0
                              (gregorian-date-difference
                               (gregorian-date january 1 1810)
                               (gregorian-date january 1 year)))))
                   (/ (- (/ ( * x x) 41048480d0) 15)
                      24d0 60d0 60d0))))))
    -*/
    public static final double ephemerisCorrection(double d)
    {
        long l = Gregorian.yearFromFixed((long) Math.floor(d));
        double d1 = (double) difference(Gregorian.toFixed(1900L, 1, 1), Gregorian.toFixed(l, 7, 1)) / 36525D;
        double d2;
        if (l >= 1988L && l <= 2019L)
            d2 = (double) (l - 1933L) / 86400D;
        else if (l >= 1900L && l <= 1987L)
            d2 = poly(d1, ConstUI.EC_COEFF19TH);
        else if (l >= 1800L && l <= 1899L)
            d2 = poly(d1, ConstUI.EC_COEFF18TH);
        else if (l >= 1700L && l <= 1799L)
            d2 = poly(l - 1700L, ConstUI.EC_COEFF17TH) / 86400D;
        else if (l >= 1620L && l <= 1699L)
        {
            d2 = poly(l - 1600L, ConstUI.EC_COEFF16TH) / 86400D;
        }
        else
        {
            double d3 = hr(12D) + (double) difference(Gregorian.toFixed(1810L, 1, 1), Gregorian.toFixed(l, 1, 1));
            return ((d3 * d3) / 41048480D - 15D) / 86400D;
        }
        return d2;
    }

    /*-
    (defun equation-of-time (jd)
      ;; TYPE moment -> fraction-of-day
      ;; Equation of time (in days) for julian day number jd.
      ;; Adapted from "Astronomical Algorithms" by Jean Meeus,
      ;; Willmann-Bell, Inc., 1991.
      (let* ((c (/ (- jd j2000) 36525d0))
             (longitude
              (poly c
                    (list 280.46645d0 36000.76983d0 0.0003032d0)))
             (anomaly
              (poly c
                    (list 357.52910d0 35999.05030d0
                          -0.0001559d0 -0.00000048d0)))
             (inclination
              (poly c
                    (list 23.43929111d0 -0.013004167d0
                          -0.00000016389d0 0.0000005036d0)))
             (eccentricity
              (poly c
                    (list 0.016708617d0 -0.000042037d0
                          -0.0000001236d0)))
             (y (expt (tangent-degrees (/ inclination 2)) 2)))
        (/ (+ ( * y (sin-degrees ( * 2 longitude)))
              ( * -2 eccentricity (sin-degrees anomaly))
              ( * 4 eccentricity y (sin-degrees anomaly)
                 (cosine-degrees ( * 2 longitude)))
              ( * -0.5 y y (sin-degrees ( * 4 longitude)))
              ( * -1.25 eccentricity eccentricity
                 (sin-degrees ( * 2 anomaly))))
           2 pi)))
    -*/
    public static final double equationOfTime(double d)
    {
        double d1 = julianCenturies(d);
        double d2 = poly(d1, ConstUI.ET_COEFFLONGITUDE);
        double d3 = poly(d1, ConstUI.ET_COEFFANOMALY);
        double d4 = poly(d1, ConstUI.ET_COEFFECCENTRICITY);
        double d5 = obliquity(d);
        double d6 = square(tanDegrees(d5 / 2D));
        double d7 = 0.15915494309189535D * (d6 * sinDegrees(2D * d2) + -2D * d4 * sinDegrees(d3) + 4D * d4 * d6 * sinDegrees(d3) * cosDegrees(2D * d2) + -0.5D * d6 * d6 * sinDegrees(4D * d2) + -1.25D
                * d4 * d4 * sinDegrees(2D * d3));
        return (double) signum(d7) * Math.min(Math.abs(d7), hr(12D));
    }

    /*-
    (defun local-from-apparent (moment)
      ;; TYPE moment -> moment
      ;; Local time from sundial time.
      (- moment (equation-of-time moment)))
    -*/
    public static final double localFromApparent(double d)
    {
        return d - equationOfTime(d);
    }

    /*-
    (defun apparent-from-local (moment)
      ;; TYPE moment -> moment
      ;; Sundial time at local time.
      (+ moment (equation-of-time moment)))
    -*/
    public static final double apparentFromLocal(double d)
    {
        return d + equationOfTime(d);
    }

    /*-
    (defun nutation (c)
      ;; TYPE julian-centuries -> radian
      ;; Longitudinal nutation in radians at c Julian centuries.
      (let* ((A (poly c (list 124.90d0 -1934.134d0 0.002063d0)))
             (B (poly c (list 201.11d0 72001.5377d0 0.00057d0))))
        (+ ( * -.0000834d0 (sin-degrees A))
           ( * -.0000064d0 (sin-degrees B)))))
    -*/
    public static final double nutation(double d)
    {
        double d1 = julianCenturies(d);
        double d2 = poly(d1, ConstUI.NU_COEFFA);
        double d3 = poly(d1, ConstUI.NU_COEFFB);
        return deg(-0.0047780000000000001D) * sinDegrees(d2) + deg(-0.00036670000000000002D) * sinDegrees(d3);
    }

    /*-
    (defun aberration (c)
      ;; TYPE julian-centuries -> radian
      ;; Aberration in radians at c Julian centuries.
      (- ( * 0.0000017d0 (cosine-degrees
                         (+ 177.63d0 ( * 35999.01848d0 c))))
         0.0000973d0))
    -*/
    public static final double aberration(double d)
    {
        double d1 = julianCenturies(d);
        return deg(9.7399999999999996E-005D) * cosDegrees(deg(177.63D) + deg(35999.018479999999D) * d1) - deg(0.0055750000000000001D);
    }

    /*-
    (defun date-next-solar-longitude (jd l)
      ;; TYPE (julian-day-number angle) -> julian-day-number
      ;; Julian day number of the first date at or after julian
      ;; day number jd (in Greenwich) when the solar longitude
      ;; will be a multiple of l degrees; l must be a proper
      ;; divisor of 360.
      (let* ((next (double-float
                    (degrees
                     ( * l (ceiling (/ (solar-longitude jd)
                                      l)))))))
        (binary-search
         start jd
         end   (+ jd ( * (/ l 360) 400d0))
         x     (if (= next 0); Discontinuity at next=0
                   ;; Then test for drop in longitude
                   (>= l (solar-longitude x))
                 ;; Else test if we are past the desired
                 ;; longitude
                 (>= (solar-longitude x) next))
         (>= 0.00001d0 (- end start)))))
    -*/
    public static final double dateNextSolarLongitude(double jd, double l)
    {
        double next = degrees(l * Math.ceil(solarLongitude(jd) / l));
        double lo = jd, hi = jd + l / 360 * 400, x = (hi + lo) / 2;
        while (hi - lo > 0.00001)
        {
            if (next == 0 ? l >= solarLongitude(x) : solarLongitude(x) >= next)
                hi = x;
            else
                lo = x;

            x = (hi + lo) / 2;
        }
        return x;
    }

    /*-
    (defun lunar-solar-angle (jd)
      ;; TYPE julian-day-number -> phase
      ;; Lunar phase, as an angle in degrees, at astronomical
      ;; (julian) day number jd.  An angle of 0 means a new
      ;; moon, 90 degrees means the first quarter, 180 means a
      ;; full moon, and 270 degrees means the last quarter.
      (degrees (- (lunar-longitude jd)
                  (solar-longitude jd))))
    -*/
    public static final double lunarSolarAngle(double jd)
    {
        return degrees(lunarLongitude(jd) - solarLongitude(jd));
    }

    public static final double nthNewMoon(long l)
    {
        double d = l - 24724L;
        double d1 = d / 1236.8499999999999D;
        double d2 = poly(d1, ConstUI.NM_COEFFAPPROX);
        double d3 = poly(d1, ConstUI.NM_COEFFCAPE);
        double d4 = poly(d1, ConstUI.NM_COEFFSOLARANOMALY);
        double d5 = poly(d1, ConstUI.NM_COEFFLUNARANOMALY);
        double d6 = poly(d1, ConstUI.NM_COEFFMOONARGUMENT);
        double d7 = poly(d1, ConstUI.NM_COEFFCAPOMEGA);
        double d8 = -0.00017000000000000001D * sinDegrees(d7);
        for (int i = 0; i < ConstUI.NM_SINECOEFF.length; i++)
            d8 += ConstUI.NM_SINECOEFF[i] * Math.pow(d3, ConstUI.NM_EFACTOR[i]) * sinDegrees(ConstUI.NM_SOLARCOEFF[i] * d4 + ConstUI.NM_LUNARCOEFF[i] * d5 + ConstUI.NM_MOONCOEFF[i] * d6);

        double d9 = 0.0D;
        for (int j = 0; j < ConstUI.NM_ADDCONST.length; j++)
            d9 += ConstUI.NM_ADDFACTOR[j] * sinDegrees(ConstUI.NM_ADDCONST[j] + ConstUI.NM_ADDCOEFF[j] * d);

        double d10 = 0.00032499999999999999D * sinDegrees(poly(d1, ConstUI.NM_EXTRA));
        return universalFromDynamical(d2 + d8 + d10 + d9);
    }

    public static final double newMoonAfter(double d)
    {
        double d1 = nthNewMoon(0L);
        double d2 = lunarPhase(d);
        long l = Math.round((d - d1) / 29.530588853000001D - d2 / deg(360D));
        long l1;
        for (l1 = l; nthNewMoon(l1) < d; l1++)
            ;
        return nthNewMoon(l1);
    }

    public static final double lunarPhaseBefore(double d, double d1)
    {
        double d2 = 1.0000000000000001E-005D;
        double d3 = d - 0.082029413480555563D * mod(lunarPhase(d) - d1, deg(360D));
        double d4 = d3 - 2D;
        double d5 = Math.min(d, d3 + 2D);
        double d6 = d4;
        double d7 = d5;
        double d8;
        for (d8 = (d7 + d6) / 2D; d7 - d6 > d2; d8 = (d7 + d6) / 2D)
            if (mod(lunarPhase(d8) - d1, 360D) < deg(180D))
                d7 = d8;
            else
                d6 = d8;

        return d8;
    }

    public static final double lunarPhaseAfter(double d, double d1)
    {
        double d2 = 1.0000000000000001E-005D;
        double d3 = d + 0.082029413480555563D * mod(d1 - lunarPhase(d), deg(360D));
        double d4 = Math.max(d, d3 - 2D);
        double d5 = d3 + 2D;
        double d6 = d4;
        double d7 = d5;
        double d8;
        for (d8 = (d7 + d6) / 2D; d7 - d6 > d2; d8 = (d7 + d6) / 2D)
            if (mod(lunarPhase(d8) - d1, 360D) < deg(180D))
                d7 = d8;
            else
                d6 = d8;

        return d8;
    }

    public static final double lunarLatitude(double d)
    {
        double d1 = julianCenturies(d);
        double d2 = degrees(poly(d1, ConstUI.LLAT_COEFFLONGITUDE));
        double d3 = degrees(poly(d1, ConstUI.LLAT_COEFFELONGATION));
        double d4 = degrees(poly(d1, ConstUI.LLAT_COEFFSOLARANOMALY));
        double d5 = degrees(poly(d1, ConstUI.LLAT_COEFFLUNARANOMALY));
        double d6 = degrees(poly(d1, ConstUI.LLAT_COEFFMOONNODE));
        double d7 = poly(d1, ConstUI.LLAT_COEFFCAPE);
        double d8 = 0.0D;
        for (int i = 0; i < ConstUI.LLAT_ARGSLUNARELONGATION.length; i++)
        {
            double d9 = ConstUI.LLAT_ARGSSOLARANOMALY[i];
            d8 += ConstUI.LLAT_SINECOEFFICIENTS[i] * Math.pow(d7, Math.abs(d9))
                    * sinDegrees(ConstUI.LLAT_ARGSLUNARELONGATION[i] * d3 + d9 * d4 + ConstUI.LLAT_ARGSLUNARANOMALY[i] * d5 + ConstUI.LLAT_ARGSMOONNODE[i] * d6);
        }

        d8 *= deg(1.0D) / 1000000D;
        double d10 = (deg(175D) / 1000000D) * (sinDegrees(deg(119.75D) + d1 * 131.84899999999999D + d6) + sinDegrees((deg(119.75D) + d1 * 131.84899999999999D) - d6));
        double d11 = (deg(-2235D) / 1000000D) * sinDegrees(d2) + (deg(127D) / 1000000D) * sinDegrees(d2 - d5) + (deg(-115D) / 1000000D) * sinDegrees(d2 + d5);
        double d12 = (deg(382D) / 1000000D) * sinDegrees(deg(313.44999999999999D) + d1 * deg(481266.484D));
        return mod(d8 + d10 + d11 + d12, 360D);
    }

    public static final double lunarAltitude(double d, Location location)
    {
        double d1 = location.latitude;
        double d2 = location.longitude;
        double d3 = obliquity(d);
        double d4 = lunarLongitude(d);
        double d5 = lunarLatitude(d);
        double d6 = arcTanDegrees((sinDegrees(d4) * cosDegrees(d3) - tanDegrees(d5) * sinDegrees(d3)) / cosDegrees(d4), (int) quotient(d4, deg(90D)) + 1);
        double d7 = arcSinDegrees(sinDegrees(d5) * cosDegrees(d3) + cosDegrees(d5) * sinDegrees(d3) * sinDegrees(d4));
        double d8 = siderealFromMoment(d);
        double d9 = mod((d8 + d2) - d6, 360D);
        double d10 = arcSinDegrees(sinDegrees(d1) * sinDegrees(d7) + cosDegrees(d1) * cosDegrees(d7) * cosDegrees(d9));
        return mod(d10 + deg(180D), 360D) - deg(180D);
    }

    public static final double estimatePriorSolarLongitude(double d, double d1)
    {
        double d2 = 365.242189D / deg(360D);
        double d3 = d - d2 * mod(solarLongitude(d) - d1, 360D);
        double d4 = mod((solarLongitude(d3) - d1) + deg(180D), 360D) - deg(180D);
        return Math.min(d, d3 - d2 * d4);
    }

    public static final boolean visibleCrescent(long l, Location location) throws Exception
    {
        double d = universalFromStandard(dusk(l - 1L, location, deg(4.5D)), location);
        double d1 = lunarPhase(d);
        double d2 = lunarAltitude(d, location);
        double d3 = arcCosDegrees(cosDegrees(lunarLatitude(d)) * cosDegrees(d1));
        return ConstUI.NEW < d1 && d1 < ConstUI.FIRST_QUARTER && deg(10.6D) <= d3 && d3 <= deg(90D) && d2 > deg(4.0999999999999996D);
    }

    public static final long phasisOnOrBefore(long l, Location location) throws Exception
    {
        long l1 = (long) ((double) l - Math.floor((lunarPhase(l) / deg(360D)) * 29.530588853000001D));
        long l2 = l - l1 > 3L || visibleCrescent(l, location) ? l1 - 2L : l1 - 30L;
        long l3;
        for (l3 = l2; !visibleCrescent(l3, location); l3++)
            ;
        return l3;
    }

    public static final double siderealFromMoment(double d)
    {
        double d1 = (d - ConstUI.J2000) / 36525D;
        return mod(poly(d1, ConstUI.SFM_SIDEREALCOEFF), 360D);
    }

    public static final String nameFromNumber(long l, String as[])
    {
        return as[(int) adjustedMod(l, as.length) - 1];
    }

    public static final String nameFromDayOfWeek(long l, String as[])
    {
        return nameFromNumber(l + 1L, as);
    }

    public static final String nameFromMonth(long l, String as[])
    {
        return nameFromNumber(l, as);
    }
}
