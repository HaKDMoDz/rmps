/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.awt.AWTException;
import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.Robot;
import java.awt.image.BufferedImage;
import java.awt.image.ImageObserver;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;

import net.sf.image4j.codec.ico.ICODecoder;
import net.sf.image4j.codec.ico.ICOEncoder;
import net.sf.image4j.codec.ico.ICOImage;
import rmp.bean.FilesFilter;

import com.amonsoft.util.CharUtil;
import com.amonsoft.util.LogUtil;

import cons.EnvCons;
import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public final class ImageUtil
{
    /**
     * 平铺显示
     */
    public static final int LAYOUT_TILE = 0;
    /**
     * 缩放显示
     */
    public static final int LAYOUT_SCALE = 1;
    /**
     * 定点显示
     */
    public static final int LAYOUT_POINT = 2;
    /**
     * 居中显示
     */
    public static final int LAYOUT_CENTER = 3;

    private ImageUtil()
    {
    }

    /**
     * @param path
     * @return
     */
    public static BufferedImage readImage(String path)
    {
        LogUtil.log("图像文件读取：" + path);

        File imageFile = new File(path);
        if (imageFile == null || !imageFile.exists() || !imageFile.isFile() || !imageFile.canRead())
        {
            LogUtil.log("图像文件读取：图像文件不存在！");
            return null;
        }

        BufferedImage bi = null;
        try
        {
            FileInputStream fis = new FileInputStream(imageFile);
            bi = ImageIO.read(fis);
            fis.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return bi;
    }

    /**
     * 截取屏幕指定区域的图像
     * 
     * @param rect
     * @return
     * @throws AWTException
     */
    public static BufferedImage getScreenImage(Rectangle rect) throws AWTException
    {
        return new Robot().createScreenCapture(rect);
    }

    /**
     * 读取系统中默认的PNG格式的图像文件，并以图像原大小返回
     * 
     * @param iconFile
     *            待读取的图像文件
     * @param widh
     *            返回图像的宽度
     * @param high
     *            返回图像的高度
     * @param scal
     *            是否保持图像的纵横比，true:保持；false:不保持
     * @return
     * @throws IOException
     */
    public static BufferedImage readPngImage(String filePath) throws IOException
    {
        File iconFile = new File(filePath);
        // 参数为空判断
        if (!iconFile.exists())
        {
            LogUtil.log("图像文件读取：文件不存在 － " + filePath);
            return null;
        }
        // 文件可读性判断
        if (!iconFile.isFile() || !iconFile.canRead())
        {
            return null;
        }

        LogUtil.log("图像文件读取：文件路径 － " + filePath);

        // 读取图像文件
        FileInputStream fis = new FileInputStream(iconFile);
        BufferedImage bi = ImageIO.read(fis);
        fis.close();
        fis = null;

        return bi;
    }

    /**
     * 读取JAR包中的图像信息
     * 
     * @param path
     *            相对于Jar包的路径信息
     * @return
     * @throws IOException
     */
    public static BufferedImage readJarImage(String path, String name) throws IOException
    {
        // 读取语言资源
        InputStream inStream = null;
        BufferedImage bi = null;
        try
        {
            // 首先读取Jar内部语言资源
            inStream = getResourceAsStream(path, name);
            // 读取图像
            bi = ImageIO.read(inStream);
        }
        finally
        {
            if (inStream != null)
            {
                inStream.close();
            }
        }

        return bi;
    }

    /**
     * 读取外部的图像文件，此方法主要用于用户使用文件打开对话框选择外部图像时。
     * 
     * @param filePath
     * @return
     * @throws IOException
     */
    public static Image readExtImage(String filePath) throws IOException
    {
        // 参数为空判断
        if (!CharUtil.isValidate(filePath))
        {
            return null;
        }

        // Ico文件读取
        if (filePath.endsWith("ico"))
        {
            return readIcoImage(filePath, 48);
        }

        // 其它文件读取
        // return Jimi.getImage(filePath);
        return null;
    }

    /**
     * 读取指定的Ico图像文件，并返回与需求大小最相近且不大于需求大小的图像。
     * 
     * @param fileName
     *            Ico图像文件路径。
     * @param defSize
     *            用户需求大小，返回的图像大小与此大小相近但不大于此大小。
     * @return 缓冲图像
     * @throws IOException
     *             文件存取异常
     */
    public static BufferedImage readIcoImage(String fileName, int defSize) throws IOException
    {

        // 读取指定图标文件的所有图像数据，并以图像列表的格式返回。
        List<ICOImage> icoList = ICODecoder.readExt(new File(fileName));

        // 当前图标文件中的图像贞数
        int icoSize = icoList.size();
        if (icoSize == 0)
        {
            return new BufferedImage(defSize, defSize, BufferedImage.TYPE_INT_ARGB);
        }

        // 只有一贞图像时，直接返回第一贞图像
        if (icoSize == 1)
        {
            return icoList.get(0).getImage();
        }

        // 查询与用户需求大小最相近的图像。
        int ms = defSize;
        int cp = 0;
        ICOImage icoImg = null;
        ICOImage tmpImg;
        for (int i = 0; i < icoSize; i += 1)
        {
            tmpImg = icoList.get(i);

            // 取宽度最小的图像。
            int t = tmpImg.getWidth() - defSize;
            if (Math.abs(t) <= Math.abs(ms))
            {
                ms = t;

                // 取色深最大的图像。
                t = tmpImg.getColourDepth();
                if (t > cp)
                {
                    icoImg = tmpImg;
                    cp = t;
                }
            }
        }

        // 图像大于需求图像大小时，进行缩放处理。
        BufferedImage bufImg = icoImg.getImage();
        if (ms > 0)
        {
            BufferedImage img = new BufferedImage(defSize, defSize, BufferedImage.TYPE_INT_ARGB);
            img.createGraphics().drawImage(bufImg, 0, 0, defSize, defSize, null);
            bufImg = img;
        }

        return bufImg;
    }

    /**
     * 保存外部图像到系统，外部图像可以任何Jimi支持的格式，并默认以PNG格式图像保存
     * 
     * @param srcFile
     * @param dstPath
     * @param fileName
     * @return
     * @throws IOException
     */
    public static boolean saveExtImage(String srcFile, String dstPath, String fileName) throws IOException
    {
        LogUtil.log("图像保存：（" + srcFile + " --> " + dstPath + " / " + fileName + "）");

        // Ico图像文件处理方式
        if (srcFile.toLowerCase().endsWith(".ico"))
        {
            return saveIcoImage(srcFile, dstPath, fileName);
        }

        // 其它图像处理方式
        ImageIcon icon = null;// new ImageIcon(Jimi.getImage(srcFile));
        int w = icon.getIconWidth();
        int h = icon.getIconHeight();
        // 求宽高中的最大值
        int m = w > h ? w : h;
        // 计算与8的倍数最相近的图像尺寸
        int d = (m >> 3) << 3;
        // 图像需要进行缩放处理
        BufferedImage bufImg = ImageUtil.scaleImage(icon.getImage(), d, d, true);
        String fullName = fileName + CharUtil.lPad(Integer.toHexString(d), 4, '0') + SysCons.EXTS_ICON;

        // 图像存储
        boolean b = ImageIO.write(bufImg, SysCons.FILE_IMAGETYPE, new File(dstPath, fullName));
        if (!b)
        {
            return false;
        }

        // 保存默认大小图像（48*48）
        final int SIZE0048 = 48;
        if (d != SIZE0048)
        {
            bufImg = ImageUtil.scaleImage(bufImg, SIZE0048, SIZE0048, true);
            fullName = fileName + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON;
            b = ImageIO.write(bufImg, SysCons.FILE_IMAGETYPE, new File(dstPath, fullName));
        }

        // 保存默认大小图像（128*128）
        final int SIZE0128 = 128;
        if (d != SIZE0128)
        {
            bufImg = ImageUtil.scaleImage(bufImg, SIZE0128, SIZE0128, true);
            fullName = fileName + SysCons.ICON_SIZE_0128 + SysCons.EXTS_ICON;
            b = ImageIO.write(bufImg, SysCons.FILE_IMAGETYPE, new File(dstPath, fullName));
        }

        return b;
    }

    /**
     * @param srcFile
     * @param dstPath
     * @param fileName
     * @throws IOException
     */
    public static boolean saveIcoImage(String srcFile, String dstPath, String fileName) throws IOException
    {
        // 读取Ico图像列表
        List<ICOImage> icoList = ICODecoder.readExt(new File(srcFile));

        final int SIZE0048 = 48;
        final int SIZE0128 = 128;

        ICOImage ico0048 = null;
        ICOImage ico0128 = null;
        ICOImage curIco;
        String tmpName;
        int cp = 0;
        int cz0048 = 0;
        int cz0128 = 0;
        int sz0048 = 256;
        int sz0128 = 256;
        boolean b = false;

        for (int i = 0, j = icoList.size(); i < j; i += 1)
        {
            curIco = icoList.get(i);
            if (curIco.getColourDepth() >= cp)
            {
                // 当前图像颜色位数深度
                cp = curIco.getColourDepth();
                // 当前图像大小
                cz0048 = curIco.getWidth();
                cz0128 = cz0048;
                // 图像文件名称组成
                tmpName = fileName + CharUtil.lPad(Integer.toHexString(cz0048), 4, '0') + SysCons.EXTS_ICON;

                // 图像文件保存
                b = ImageIO.write(curIco.getImage(), SysCons.FILE_IMAGETYPE, new File(dstPath, tmpName));
                if (!b)
                {
                    return false;
                }

                // 引用与默认图像最相近的图像
                cz0048 -= SIZE0048;
                if (Math.abs(cz0048) <= Math.abs(sz0048))
                {
                    sz0048 = cz0048;
                    ico0048 = curIco;
                }
                cz0128 -= SIZE0128;
                if (Math.abs(cz0128) <= Math.abs(sz0128))
                {
                    sz0128 = cz0128;
                    ico0128 = curIco;
                }
            }
        }

        // 保存默认大小图像（48*48）
        if (sz0048 != 0 && ico0048 != null)
        {
            BufferedImage bufImg = ImageUtil.scaleImage(ico0048.getImage(), SIZE0048, SIZE0048, true);
            tmpName = fileName + SysCons.ICON_SIZE_0048 + SysCons.EXTS_ICON;
            b = ImageIO.write(bufImg, SysCons.FILE_IMAGETYPE, new File(dstPath, tmpName));
        }
        // 保存默认大小图像（128*128）
        if (sz0128 != 0 && ico0128 != null)
        {
            BufferedImage bufImg = ImageUtil.scaleImage(ico0128.getImage(), SIZE0128, SIZE0128, true);
            tmpName = fileName + SysCons.ICON_SIZE_0128 + SysCons.EXTS_ICON;
            b = ImageIO.write(bufImg, SysCons.FILE_IMAGETYPE, new File(dstPath, tmpName));
        }
        return b;
    }

    /**
     * 保存指定的图像到指定的文件中去。
     * 
     * @param image
     *            待保存的图像数据
     * @param iconFile
     *            目标图像文件
     * @return 图像是否保存成功，成功返回true，失败返回false
     * @throws IOException
     */
    public static boolean savePngImage(BufferedImage image, File iconFile) throws IOException
    {
        // 参数合法性判断
        if (image == null || iconFile == null)
        {
            return false;
        }

        // 创建新文件
        if (!iconFile.exists())
        {
            iconFile.createNewFile();
        }

        // 文件属性判断
        if (!iconFile.isFile())
        {
            return false;
        }

        LogUtil.log("图像文件存储： 文件路径 - " + iconFile.getPath());

        // 保存图像到文件中
        ImageIO.write(image, SysCons.FILE_IMAGETYPE, iconFile);
        return true;
    }

    /**
     * @param pngPath
     * @param pngName
     * @return
     */
    public static boolean exptIcoImage(String pngPath, String pngName, File icoFile)
    {
        // 文件名过滤器
        FilesFilter filter = new FilesFilter();
        filter.setTextInclude(new String[]
        { pngName });
        filter.setInclude(true);

        // 符合指定条件的文件列表
        File[] fileList = new File(pngPath).listFiles(filter);

        try
        {
            // 图像列表
            List<BufferedImage> lbi = new ArrayList<BufferedImage>(fileList.length);

            // 循环读取图像文件
            FileInputStream fis;
            for (int i = 0, j = fileList.length; i < j; i += 1)
            {
                // 文件夹过滤
                if (!fileList[i].isFile())
                {
                    continue;
                }

                // 图像文件内容读取
                fis = new FileInputStream(fileList[i]);
                lbi.add(ImageIO.read(fis));
                fis.close();
                fis = null;
            }

            // 输出图像
            FileOutputStream fos = new FileOutputStream(icoFile);
            ICOEncoder.write(lbi, fos);
            fos.close();
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        return true;
    }

    /**
     * 图像缩放处理
     * 
     * @param image
     *            待进行缩放处理的图像
     * @param widh
     *            目标图像宽度
     * @param high
     *            目标图像高度
     * @param scal
     *            是否保持纵横比，true保持，false不保持
     * @return
     */
    public static BufferedImage scaleImage(Image image, int widh, int high, boolean scal)
    {
        if (image == null)
        {
            return null;
        }

        // 图像原有宽高
        int imgWidh = image.getWidth(null);
        int imgHigh = image.getHeight(null);

        // 图像绽放处理
        if ((imgWidh > widh || imgHigh > high) && scal)
        {
            // 最大宽度缩放比例计算
            double scalW = (double) widh / imgWidh;
            double scalH = (double) high / imgHigh;
            double scale = (scalW <= scalH ? scalW : scalH);

            // 新的图像宽高计算
            imgWidh = (int) (imgWidh * scale);
            imgHigh = (int) (imgHigh * scale);
        }

        // 缓冲图像
        BufferedImage bufImg = new BufferedImage(widh, high, BufferedImage.TYPE_INT_ARGB);

        // 二维绘制对象
        Graphics2D g2d = bufImg.createGraphics();

        // 透明色
        Color argb = new Color(0, 0, 0, 0);

        // 绘制背景
        g2d.setPaint(argb);
        g2d.fillRect(0, 0, widh, high);

        // 图像缩放绘制
        g2d.drawImage(image, (widh - imgWidh) >> 1, (high - imgHigh) >> 1, imgWidh, imgHigh, null);

        return bufImg;
    }

    /**
     * 按指定的绘制方式绘制图像到绘制面板中去。
     * 
     * @param g2d
     * @param image
     * @param gx
     * @param gy
     * @param gw
     * @param gh
     * @param io
     * @param type
     * @return
     */
    public static boolean drawImage(Graphics2D g2d, Image image, int gx, int gy, int gw, int gh, ImageObserver io, int type)
    {
        boolean drawOk = false;

        switch (type)
        {
            // 平铺显示
            case ImageUtil.LAYOUT_TILE:
                drawOk = drawImageA(g2d, image, gx, gy, gw, gh, io);
                break;
            // 定点显示
            case ImageUtil.LAYOUT_POINT:
                drawOk = drawImageB(g2d, image, gx, gy, gw, gh, io);
                break;
            default:
                break;
        }
        return drawOk;
    }

    /**
     * 平铺绘制
     * 
     * @param g2d
     * @param image
     * @param gx
     * @param gy
     * @param gw
     * @param gh
     * @param io
     * @return
     */
    private static boolean drawImageA(Graphics2D g2d, Image image, int gx, int gy, int gw, int gh, ImageObserver io)
    {
        // 原图像大小信息取得
        int imgW = image.getWidth(io);
        int imgH = image.getHeight(io);

        int cx = gx;
        int cy = gy;
        while (cy <= gh)
        {
            while (cx <= gw)
            {
                g2d.drawImage(image, cx, cy, imgW, imgH, io);
                cx += imgW;
            }
            cx = gx;
            cy += imgH;
        }

        return true;
    }

    /**
     * 原图像大小绘制到指定的位置
     * 
     * @param g2d
     * @param image
     * @param gx
     * @param gy
     * @param gw
     * @param gh
     * @param io
     * @return
     */
    private static boolean drawImageB(Graphics2D g2d, Image image, int gx, int gy, int gw, int gh, ImageObserver io)
    {
        return g2d.drawImage(image, gx, gy, null);
    }

    /**
     * @param path
     * @param name
     * @return
     */
    public static URL getResource(String path, String name)
    {
        StringBuffer sb = new StringBuffer();
        sb.append(EnvCons.FOLDER0_SKIN).append(path).append(EnvCons.COMN_SP_FILE).append(name);
        LogUtil.log("系统语言资源加载：" + sb.toString());
        return FileUtil.class.getResource(sb.toString());
    }

    /**
     * @param path
     * @param name
     * @return
     */
    public static InputStream getResourceAsStream(String path, String name)
    {
        StringBuffer sb = new StringBuffer();
        sb.append(EnvCons.FOLDER0_SKIN).append(path).append(EnvCons.COMN_SP_FILE).append(name);
        LogUtil.log("系统语言资源加载：" + sb.toString());
        return FileUtil.class.getResourceAsStream(sb.toString());
    }
}
