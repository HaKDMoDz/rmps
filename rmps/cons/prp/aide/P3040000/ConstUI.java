/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package cons.prp.aide.P3040000;

import java.awt.Color;

import javax.swing.BorderFactory;
import javax.swing.border.Border;

import rmp.prp.aide.P3040000.b.Location;
import rmp.prp.aide.P3040000.proto.ProtoDate;
import rmp.prp.aide.P3040000.solar.Gregorian;
import cons.SysCons;
import cons.id.PrpCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public interface ConstUI
{
    // ////////////////////////////////////////////////////////////////////////
    // 系统唯一标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件版本 */
    String VER_CODE = "V1.1.0.0";
    /** 软件首页 */
    String URL_SOFT = SysCons.HOMEPAGE + "soft/soft0001.aspx?sid=" + PrpCons.P3040000_S;
    /** 电子邮件 */
    String URL_MAIL = SysCons.MAILADDR;
    // ////////////////////////////////////////////////////////////////////////
    // 语言配置标记
    // ////////////////////////////////////////////////////////////////////////
    /** 软件语言资源标记 */
    String RES_NAME = "P3040000";
    /** 软件标题语言资源标记 */
    String RES_TITLE = "P3040000.title";
    /** 软件描述信息语言资源标记 */
    String RES_DESCRIPTION = "P3040000.description";
    /** 月历视图日期行数 */
    int DATE_ROWS = 6;
    /** 月历视图日期列数 */
    int DATE_COLS = 7;
    /** 日历视图标签个数 */
    int DATE_DAYS = DATE_ROWS * DATE_COLS;
    String CARD_LABL = "labldate";
    String CARD_SPIN = "spindate";
    String CARD_STEP = "step_";
    // ////////////////////////////////////////////////////////////////////////
    // 用户变量区域
    // ////////////////////////////////////////////////////////////////////////
    /** 年份变量 */
    String PARAM_Y_C = "n";
    String PARAM_Y_E = "y";
    /** 月份变量 */
    String PARAM_M_C = "u";
    String PARAM_M_E = "m";
    /** 日期变量 */
    String PARAM_D_C = "r";
    String PARAM_D_E = "d";
    /** 年周变量 */
    String PARAM_W_Y = "w";
    /** 月周变量 */
    String PARAM_W_M = "z";
    /** 每X年公式 */
    String FORMULA_Y_E = "y";
    String FORMULA_Y_N = "(y-{0})%{1}+y";
    /** 每X月公式 */
    String FORMULA_M_E = "m";
    String FORMULA_M_N = "(m+12-{0})%{1}+m";
    /** 每X日公式 */
    String FORMULA_D_E = "d";
    String FORMULA_D_N = "(d+12-{0})%{1}+d";
    String FORMULA_W_E = "d";
    String FORMULA_W_N = "(d+12-{0})%{1}+d";
    String FORMULA_Z_E = "d";
    String FORMULA_Z_N = "(d+12-{0})%{1}+d";
    // ////////////////////////////////////////////////////////////////////////
    // 向导操作步骤
    // ////////////////////////////////////////////////////////////////////////
    /** 起始页面 */
    int STEP_NOTE = 0;
    /** 起始时间 */
    int STEP_SDATE = STEP_NOTE + 1;
    /** 提示年份 */
    int STEP_FYEAR = STEP_SDATE + 1;
    /** 提示月份 */
    int STEP_FMONTH = STEP_FYEAR + 1;
    /** 提示日期 */
    int STEP_FDATE = STEP_FMONTH + 1;
    /** 提示月周 */
    int STEP_FWEEKOFMONTH = STEP_FDATE + 1;
    /** 提示年周 */
    int STEP_FWEEKOFYEAR = STEP_FWEEKOFMONTH + 1;
    /** 结束时间 */
    int STEP_EDATE = STEP_FWEEKOFYEAR + 1;
    /** 相关说明 */
    int STEP_DESP = STEP_EDATE + 1;
    /** 添加成功 */
    int STEP_END = STEP_DESP + 1;
    /** 默认背景颜色 */
    Color D_B_COLOR = new Color(211, 235, 161);
    /** 默认前景颜色 */
    Color D_F_COLOR = new Color(0, 0, 255);
    /** 选中背景颜色 */
    Color S_B_COLOR = new Color(252, 225, 164);
    /** 选中前景颜色 */
    Color S_F_COLOR = new Color(169, 10, 8);
    /** 标题背景颜色 */
    Color H_B_COLOR = new Color(189, 225, 111);
    /** 标签边框 */
    Border BORDER = BorderFactory.createLineBorder(new Color(222, 231, 235));
    /** 内嵌面板背景图像 */
    String PATH_BG = "bg.png";
    // ////////////////////////////////////////////////////////////////////////
    // 回调事件对象
    // ////////////////////////////////////////////////////////////////////////
    /**  */
    String BACK_K_TAILPANEL = "tailPanel";
    /**  */
    String BACK_V_DATEVIEW = "dateview";
    /**  */
    String BACK_V_MONTHVIEW = "monthview";
    String BACK_V_UPDATE = "updateview";
    // ////////////////////////////////////////////////////////////////////////
    // 多国日历常量
    // ////////////////////////////////////////////////////////////////////////
    // ec
    double[] EC_COEFF19TH =
    { -2.0000000000000002E-005D, 0.00029700000000000001D, 0.025184000000000002D, -0.18113299999999999D, 0.55303999999999998D, -0.86193799999999998D, 0.67706599999999995D, -0.212591D };
    double[] EC_COEFF18TH =
    { -9.0000000000000002E-006D, 0.0038440000000000002D, 0.083562999999999998D, 0.86573599999999995D, 4.8675750000000004D, 15.845535D, 31.332267000000002D, 38.291998999999997D, 28.316289000000001D,
            11.636203999999999D, 2.0437940000000001D };
    double[] EC_COEFF17TH =
    { 8.1187808419999996D, -0.005092142D, 0.0033361210000000001D, -2.6648400000000001E-005D };
    double[] EC_COEFF16TH =
    { 196.58332999999999D, -4.0674999999999999D, 0.021916700000000001D };
    // ob
    double[] OB_COEFFOBLIQUITY =
    { 0, ProtoDate.angle(0.0D, 0.0D, -46.814999999999998D), ProtoDate.angle(0.0D, 0.0D, -0.00059000000000000003D), ProtoDate.angle(0.0D, 0.0D, 0.0018129999999999999D) };
    // et
    double[] ET_COEFFLONGITUDE = ProtoDate.deg(new double[]
    { 280.46645000000001D, 36000.769829999997D, 0.0003032D });
    double[] ET_COEFFANOMALY = ProtoDate.deg(new double[]
    { 357.52910000000003D, 35999.050300000003D, -0.00015589999999999999D, -4.7999999999999996E-007D });
    double[] ET_COEFFECCENTRICITY = ProtoDate.deg(new double[]
    { 0.016708616999999999D, -4.2036999999999997E-005D, -1.236E-007D });
    // sl
    double[] SL_COEFFICIENTS =
    { 0x627ce, 0x2fa87, 0x1d289, 0x1b708, 3891, 2819, 1721, 660, 350, 334, 314, 268, 242, 234, 158, 132, 129, 114, 99, 93, 86, 78, 72, 68, 64, 46, 38, 37, 32, 29, 28, 27, 27, 25, 24, 21, 21, 20, 18,
            17, 14, 13, 13, 13, 12, 10, 10, 10, 10 };
    double[] SL_MULTIPLIERS =
    { 0.92878919999999998D, 35999.137695799996D, 35999.4089666D, 35998.728738500002D, 71998.202609999993D, 71998.440300000002D, 36000.357259999997D, 71997.481199999995D, 32964.467799999999D,
            -19.440999999999999D, 445267.11170000001D, 45036.883999999998D, 3.1008D, 22518.4434D, -19.9739D, 65928.934500000003D, 9038.0293000000001D, 3034.7683999999999D, 33718.148000000001D,
            3034.4479999999999D, -2280.7730000000001D, 29929.991999999998D, 31556.492999999999D, 149.58799999999999D, 9037.75D, 107997.405D, -4444.1760000000004D, 151.77099999999999D,
            67555.316000000006D, 31556.080000000002D, -4561.54D, 107996.70600000001D, 1221.655D, 62894.167000000001D, 31437.368999999999D, 14578.298000000001D, -31931.757000000001D,
            34777.243000000002D, 1221.999D, 62894.510999999999D, -4442.0389999999998D, 107997.909D, 119.066D, 16859.071D, -4.5780000000000003D, 26895.292000000001D, -39.127000000000002D, 12297.536D,
            90073.778000000006D };
    double[] SL_ADDENDS =
    { 270.54861D, 340.19128000000001D, 63.91854D, 331.26220000000001D, 317.84300000000002D, 86.631D, 240.05199999999999D, 310.25999999999999D, 247.22999999999999D, 260.87D, 297.81999999999999D,
            343.13999999999999D, 166.78999999999999D, 81.530000000000001D, 3.5D, 132.75D, 182.94999999999999D, 162.03D, 29.800000000000001D, 266.39999999999998D, 249.19999999999999D,
            157.59999999999999D, 257.80000000000001D, 185.09999999999999D, 69.900000000000006D, 8D, 197.09999999999999D, 250.40000000000001D, 65.299999999999997D, 162.69999999999999D, 341.5D,
            291.60000000000002D, 98.5D, 146.69999999999999D, 110D, 5.2000000000000002D, 342.60000000000002D, 230.90000000000001D, 256.10000000000002D, 45.299999999999997D, 242.90000000000001D,
            115.2D, 151.80000000000001D, 285.30000000000001D, 53.299999999999997D, 126.59999999999999D, 205.69999999999999D, 85.900000000000006D, 146.09999999999999D };
    // nu
    double[] NU_COEFFA = ProtoDate.deg(new double[]
    { 124.90000000000001D, -1934.134D, 0.0020630000000000002D });
    double[] NU_COEFFB = ProtoDate.deg(new double[]
    { 201.11000000000001D, 72001.537700000001D, 0.00056999999999999998D });
    // ll
    double[] LLON_COEFFMEANMOON = ProtoDate.deg(new double[]
    { 218.3164591D, 481267.88134235999D, -0.0013267999999999999D, 1.855835023689734E-006D, -1.5338834862103876E-008D });
    double[] LLON_COEFFELONGATION = ProtoDate.deg(new double[]
    { 297.85020420000001D, 445267.11151680001D, -0.0016299999999999999D, 1.8319447192361523E-006D, -8.8444699951355417E-009D });
    double[] LLON_COEFFSOLARANOMALY = ProtoDate.deg(new double[]
    { 357.52910919999999D, 35999.050290899999D, -0.00015359999999999999D, 4.0832993058391183E-008D });
    double[] LLON_COEFFLUNARANOMALY = ProtoDate.deg(new double[]
    { 134.96341140000001D, 477198.8676313D, 0.0089969999999999998D, 1.4347408140719379E-005D, -6.7971723762914631E-008D });
    double[] LLON_COEFFMOONNODE = ProtoDate.deg(new double[]
    { 93.272099299999994D, 483202.01752729999D, -0.0034028999999999999D, -2.8360748723766307E-007D, 1.1583324645839848E-009D });
    double[] LLON_COEFFCAPE =
    { 1.0D, -0.002516D, -7.4000000000000003E-006D };
    byte[] LLON_ARGSLUNARELONGATION =
    { 0, 2, 2, 0, 0, 0, 2, 2, 2, 2, 0, 1, 0, 2, 0, 0, 4, 0, 4, 2, 2, 1, 1, 2, 2, 4, 2, 0, 2, 2, 1, 2, 0, 0, 2, 2, 2, 4, 0, 3, 2, 4, 0, 2, 2, 2, 4, 0, 4, 1, 2, 0, 1, 3, 4, 2, 0, 1, 2 };
    byte[] LLON_ARGSSOLARANOMALY =
    { 0, 0, 0, 0, 1, 0, 0, -1, 0, -1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, -1, 0, 0, 0, 1, 0, -1, 0, -2, 1, 2, -2, 0, 0, -1, 0, 0, 1, -1, 2, 2, 1, -1, 0, 0, -1, 0, 1, 0, 1, 0, 0, -1, 2, 1, 0 };
    byte[] LLON_ARGSLUNARANOMALY =
    { 1, -1, 0, 2, 0, 0, -2, -1, 1, 0, -1, 0, 1, 0, 1, 1, -1, 3, -2, -1, 0, -1, 0, 1, 2, 0, -3, -2, -1, -2, 1, 0, 2, 0, -1, 1, 0, -1, 2, -1, 1, -2, -1, -1, -2, 0, 1, 4, 0, -2, 0, 2, 1, -2, -3, 2, 1,
            -1, 3 };
    byte[] LLON_ARGSMOONFROMNODE =
    { 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, -2, 2, -2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, -2, 2, 0, 2, 0, 0, 0, 0, 0, 0, -2, 0, 0, 0, 0, -2, -2, 0, 0, 0, 0, 0, 0, 0 };
    int[] LLON_SINECOEFFICIENTS =
    { 0x5ff586, 0x1370ab, 0xa0b8a, 0x34272, 0xfffd2ce4, 0xfffe4164, 58793, 57066, 53322, 45758, -40923, -34720, -30383, 15327, -12528, 10980, 10675, 10034, 8548, -7888, -6766, -5163, 4987, 4036,
            3994, 3861, 3665, -2689, -2602, 2390, -2348, 2236, -2120, -2069, 2048, -1773, -1595, 1215, -1110, -892, -810, 759, -713, -700, 691, 596, 549, 537, 520, -487, -399, -381, 351, -340, 330,
            327, -323, 299, 294 };
    // nm
    double[] NM_COEFFAPPROX =
    { 730125.59765000001D, 36524.908822833051D, 0.0001337D, -1.4999999999999999E-007D, 7.2999999999999996E-010D };
    double[] NM_COEFFCAPE =
    { 1.0D, -0.002516D, -7.4000000000000003E-006D };
    double[] NM_COEFFSOLARANOMALY = ProtoDate.deg(new double[]
    { 2.5533999999999999D, 35998.960422026496D, -2.1800000000000001E-005D, -1.1000000000000001E-007D });
    double[] NM_COEFFLUNARANOMALY = ProtoDate.deg(new double[]
    { 201.5643D, 477197.67640106793D, 0.0107438D, 1.239E-005D, -5.8000000000000003E-008D });
    double[] NM_COEFFMOONARGUMENT = ProtoDate.deg(new double[]
    { 160.71080000000001D, 483200.81131396897D, -0.0016341000000000001D, -2.2699999999999999E-006D, 1.0999999999999999E-008D });
    double[] NM_COEFFCAPOMEGA =
    { 124.77460000000001D, -1934.1313612299998D, 0.0020690999999999999D, 2.1500000000000002E-006D };
    byte[] NM_EFACTOR =
    { 0, 1, 0, 0, 1, 1, 2, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    byte[] NM_SOLARCOEFF =
    { 0, 1, 0, 0, -1, 1, 2, 0, 0, 1, 0, 1, 1, -1, 2, 0, 3, 1, 0, 1, -1, -1, 1, 0 };
    byte[] NM_LUNARCOEFF =
    { 1, 0, 2, 0, 1, 1, 0, 1, 1, 2, 3, 0, 0, 2, 1, 2, 0, 1, 2, 1, 1, 1, 3, 4 };
    byte[] NM_MOONCOEFF =
    { 0, 0, 0, 2, 0, 0, 0, -2, 2, 0, 0, 2, -2, 0, 0, -2, 0, -2, 2, 2, 2, -2, 0, 0 };
    double[] NM_SINECOEFF =
    { -0.40720000000000001D, 0.17241000000000001D, 0.016080000000000001D, 0.01039D, 0.0073899999999999999D, -0.0051399999999999996D, 0.0020799999999999998D, -0.0011100000000000001D,
            -0.00056999999999999998D, 0.00055999999999999995D, -0.00042000000000000002D, 0.00042000000000000002D, 0.00038000000000000002D, -0.00024000000000000001D, -6.9999999999999994E-005D,
            4.0000000000000003E-005D, 4.0000000000000003E-005D, 3.0000000000000001E-005D, 3.0000000000000001E-005D, -3.0000000000000001E-005D, 3.0000000000000001E-005D, -2.0000000000000002E-005D,
            -2.0000000000000002E-005D, 2.0000000000000002E-005D };
    double[] NM_ADDCONST =
    { 251.88D, 251.83000000000001D, 349.42000000000002D, 84.659999999999997D, 141.74000000000001D, 207.13999999999999D, 154.84D, 34.520000000000003D, 207.19D, 291.33999999999997D, 161.72D, 239.56D,
            331.55000000000001D };
    double[] NM_ADDCOEFF =
    { 0.016320999999999999D, 26.641886D, 36.412478D, 18.206239D, 53.303770999999998D, 2.453732D, 7.3068600000000004D, 27.261239D, 0.121824D, 1.844379D, 24.198153999999999D, 25.513099D,
            3.5925180000000001D };
    double[] NM_ADDFACTOR =
    { 0.000165D, 0.000164D, 0.000126D, 0.00011D, 6.2000000000000003E-005D, 6.0000000000000002E-005D, 5.5999999999999999E-005D, 4.6999999999999997E-005D, 4.1999999999999998E-005D,
            4.0000000000000003E-005D, 3.6999999999999998E-005D, 3.4999999999999997E-005D, 2.3E-005D };
    double[] NM_EXTRA = ProtoDate.deg(new double[]
    { 299.76999999999998D, 132.84758479999999D, -0.0091730000000000006D });
    // llat
    double[] LLAT_COEFFLONGITUDE = ProtoDate.deg(new double[]
    { 218.3164591D, 481267.88134235999D, -0.0013267999999999999D, 1.855835023689734E-006D, -1.5338834862103876E-008D });
    double[] LLAT_COEFFELONGATION = ProtoDate.deg(new double[]
    { 297.85020420000001D, 445267.11151680001D, -0.0016299999999999999D, 1.8319447192361523E-006D, -8.8444699951355417E-009D });
    double[] LLAT_COEFFSOLARANOMALY = ProtoDate.deg(new double[]
    { 357.52910919999999D, 35999.050290899999D, -0.00015359999999999999D, 4.0832993058391183E-008D });
    double[] LLAT_COEFFLUNARANOMALY = ProtoDate.deg(new double[]
    { 134.96341140000001D, 477198.8676313D, 0.0089969999999999998D, 1.4347408140719379E-005D, -6.7971723762914631E-008D });
    double[] LLAT_COEFFMOONNODE = ProtoDate.deg(new double[]
    { 93.272099299999994D, 483202.01752729999D, -0.0034028999999999999D, -2.8360748723766307E-007D, 1.1583324645839848E-009D });
    double[] LLAT_COEFFCAPE =
    { 1.0D, -0.002516D, -7.4000000000000003E-006D };
    byte[] LLAT_ARGSLUNARELONGATION =
    { 0, 0, 0, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0, 4, 0, 0, 0, 1, 0, 0, 0, 1, 0, 4, 4, 0, 4, 2, 2, 2, 2, 0, 2, 2, 2, 2, 4, 2, 2, 0, 2, 1, 1, 0, 2, 1, 2, 0, 4, 4, 1, 4, 1, 4, 2 };
    byte[] LLAT_ARGSSOLARANOMALY =
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 1, -1, -1, -1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 1, 1, 0, -1, -2, 0, 1, 1, 1, 1, 1, 0, -1, 1, 0, -1, 0, 0, 0, -1, -2 };
    byte[] LLAT_ARGSLUNARANOMALY =
    { 0, 1, 1, 0, -1, -1, 0, 2, 1, 2, 0, -2, 1, 0, -1, 0, -1, -1, -1, 0, 0, -1, 0, 1, 1, 0, 0, 3, 0, -1, 1, -2, 0, 2, 1, -2, 3, 2, -3, -1, 0, 0, 1, 0, 1, 1, 0, 0, -2, -1, 1, -2, 2, -2, -1, 1, 1, -2,
            0, 0 };
    byte[] LLAT_ARGSMOONNODE =
    { 1, 1, -1, -1, 1, -1, 1, 1, -1, -1, -1, -1, 1, -1, 1, 1, -1, -1, -1, 1, 3, 1, 1, 1, -1, -1, -1, 1, -1, 1, -3, 1, -3, -1, -1, 1, -1, 1, -1, 1, 1, 1, 1, -1, 3, -1, -1, 1, -1, -1, 1, -1, 1, -1, -1,
            -1, -1, -1, -1, 1 };
    int[] LLAT_SINECOEFFICIENTS =
    { 0x4e3fba, 0x4481a, 0x43cbd, 0x2a4b5, 55413, 46271, 32573, 17198, 9266, 8822, 8216, 4324, 4200, -3359, 2463, 2211, 2065, -1870, 1828, -1794, -1749, -1565, -1491, -1475, -1410, -1344, -1335,
            1107, 1021, 833, 777, 671, 607, 596, 491, -451, 439, 422, 421, -366, -351, 331, 315, 302, -283, -229, 223, 223, -220, -220, -185, 181, -177, 176, 166, -164, 132, -119, 115, 107 };
    // sfm
    double[] SFM_SIDEREALCOEFF = ProtoDate.deg(new double[]
    { 280.46061837000002D, 13185000.770053742D, 0.00038793299999999997D, 2.5833118057349522E-008D });
    // ////////////////////////////////////////////////////////////////////////
    // ////////////////////////////////////////////////////////////////////////

    /*-
    (defconstant january
    ;; TYPE standard-month
    ;; January on Julian/Gregorian calendar.
    1)

    (defconstant february
    ;; TYPE standard-month
    ;; February on Julian/Gregorian calendar.
    (1+ january))

    (defconstant march
    ;; TYPE standard-month
    ;; March on Julian/Gregorian calendar.
    (+ january 2))

    (defconstant april
    ;; TYPE standard-month
    ;; April on Julian/Gregorian calendar.
    (+ january 3))

    (defconstant may
    ;; TYPE standard-month
    ;; May on Julian/Gregorian calendar.
    (+ january 4))

    (defconstant june
    ;; TYPE standard-month
    ;; June on Julian/Gregorian calendar.
    (+ january 5))

    (defconstant july
    ;; TYPE standard-month
    ;; July on Julian/Gregorian calendar.
    (+ january 6))

    (defconstant august
    ;; TYPE standard-month
    ;; August on Julian/Gregorian calendar.
    (+ january 7))

    (defconstant september
    ;; TYPE standard-month
    ;; September on Julian/Gregorian calendar.
    (+ january 8))

    (defconstant october
    ;; TYPE standard-month
    ;; October on Julian/Gregorian calendar.
    (+ january 9))

    (defconstant november
    ;; TYPE standard-month
    ;; November on Julian/Gregorian calendar.
    (+ january 10))

    (defconstant december
    ;; TYPE standard-month
    ;; December on Julian/Gregorian calendar.
    (+ january 11))
    -*/
    int JANUARY = 1;
    int FEBRUARY = 2;
    int MARCH = 3;
    int APRIL = 4;
    int MAY = 5;
    int JUNE = 6;
    int JULY = 7;
    int AUGUST = 8;
    int SEPTEMBER = 9;
    int OCTOBER = 10;
    int NOVEMBER = 11;
    int DECEMBER = 12;

    /*-
    (defconstant sunday
    ;; TYPE day-of-week
    ;; Residue class for Sunday.
    0)

    (defconstant monday
    ;; TYPE day-of-week
    ;; Residue class for Monday.
    (1+ sunday))

    (defconstant tuesday
    ;; TYPE day-of-week
    ;; Residue class for Tuesday.
    (+ sunday 2))

    (defconstant wednesday
    ;; TYPE day-of-week
    ;; Residue class for Wednesday.
    (+ sunday 3))

    (defconstant thursday
    ;; TYPE day-of-week
    ;; Residue class for Thursday.
    (+ sunday 4))

    (defconstant friday
    ;; TYPE day-of-week
    ;; Residue class for Friday.
    (+ sunday 5))

    (defconstant saturday
    ;; TYPE day-of-week
    ;; Residue class for Saturday.
    (+ sunday 6))
    -*/
    int SUNDAY = 0;
    int MONDAY = 1;
    int TUESDAY = 2;
    int WEDNESDAY = 3;
    int THURSDAY = 4;
    int FRIDAY = 5;
    int SATURDAY = 6;
    double JD_EPOCH = -1721424.5D;
    long MJD_EPOCH = 0xa5ab0L;
    double J2000 = ProtoDate.hr(12D) + (double) Gregorian.toFixed(2000L, 1, 1);

    /*-
    (defconstant mean-tropical-year
    ;; TYPE real
    365.242199d0)
    -*/
    double MEAN_TROPICAL_YEAR = 365.242189D;
    /*-
    (defconstant mean-synodic-month
    ;; TYPE real
    29.530588853d0)
    -*/
    double MEAN_SYNODIC_MONTH = 29.530588853000001D;
    /*-
    (defconstant new
    ;; TYPE phase
    ;; Excess of lunar longitude over solar longitude at new
    ;; moon.
    0)
    -*/
    double NEW = ProtoDate.deg(0.0D);
    /*-
    (defconstant first-quarter
    ;; TYPE phase
    ;; Excess of lunar longitude over solar longitude at first
    ;; quarter moon.
    90)
    -*/
    double FIRST_QUARTER = ProtoDate.deg(90D);
    /*-
    (defconstant full
    ;; TYPE phase
    ;; Excess of lunar longitude over solar longitude at full
    ;; moon.
    180)
    -*/
    double FULL = ProtoDate.deg(180D);
    /*-
    (defconstant last-quarter
    ;; TYPE phase
    ;; Excess of lunar longitude over solar longitude at last
    ;; quarter moon.
    270)
    -*/
    double LAST_QUARTER = ProtoDate.deg(270D);
    double SPRING = ProtoDate.deg(0.0D);
    double SUMMER = ProtoDate.deg(90D);
    double AUTUMN = ProtoDate.deg(180D);
    double WINTER = ProtoDate.deg(270D);
    Location JERUSALEM = new Location("Jerusalem, Israel", ProtoDate.deg(31.800000000000001D), ProtoDate.deg(35.200000000000003D), ProtoDate.mt(800D), 2D);
}
