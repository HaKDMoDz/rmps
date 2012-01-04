/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.face;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 功能构件显示及事件处理接口，所有系统功能列表构件类必需实现此接口，以进行布局的 管理及构件的显示、事件的处理等。
 * <li>使用说明：</li>
 * <br />
 * 对于每一个系统构件类来说，其不需要继承自任何其它构件类，而仅需要实现此接口即可，
 * 在其构造器中提供一个构造器使用其参数为对FListPanel的引用，当显示指定的系统时， 仅需要对FListPanel的引用进行布局管理及构件的处理即可。
 * </ul>
 * @author Amon
 */
public interface WListShow extends WShow
{
}
