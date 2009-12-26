/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.face;

import java.awt.Image;
import java.awt.Paint;

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
public interface WViewShow extends WShow
{
    /**
     * 设置背景的显示图像
     * 
     * @param image
     *            显示图像
     * @param layout
     *            图像显示方式
     * @return
     */
    Image setBackgroundImage(Image image, int layout);

    /**
     * 设置背景的渐变颜色
     * 
     * @param paint
     *            渐变颜色对象
     * @return
     */
    Paint setBackgroundPaint(Paint paint);
}
