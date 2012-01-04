/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.InputEvent;

import javax.swing.AbstractAction;
import javax.swing.JLabel;
import javax.swing.KeyStroke;

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
public class WLabel extends JLabel
{
    private KeyStroke mnemonicKey;
    static final String MNEMONIC_ACTION = "wMnemonicAction";

    /**
     * 
     */
    public WLabel()
    {
    }

    /**
     * @param mnemonic
     */
    public void setMnemonic(char mnemonic)
    {
        int vk = (int) mnemonic;
        if (vk >= 'a' && vk <= 'z')
        {
            vk -= ('a' - 'A');
        }
        setMnemonic(vk);
    }

    /**
     * @param mnemonic
     */
    public void setMnemonic(int mnemonic)
    {
        javax.swing.ActionMap aMap = getActionMap();
        if (aMap.get(MNEMONIC_ACTION) == null)
        {
            aMap.put(MNEMONIC_ACTION, new AbstractAction()
            {
                public void actionPerformed(ActionEvent evt)
                {
                    wActionPerformed(evt);
                }

                private static final long serialVersionUID = 7881709680364466655L;
            });
        }

        javax.swing.InputMap iMap = getInputMap(WHEN_IN_FOCUSED_WINDOW);
        if (mnemonicKey == null)
        {
            mnemonicKey = KeyStroke.getKeyStroke(mnemonic, InputEvent.ALT_MASK);
        }
        else
        {
            iMap.remove(mnemonicKey);
        }
        iMap.put(mnemonicKey, MNEMONIC_ACTION);
    }

    /**
     * @param l
     */
    public void addActionListener(ActionListener l)
    {
        listenerList.add(ActionListener.class, l);
    }

    /**
     * @param l
     */
    public void removeActionListener(ActionListener l)
    {
        listenerList.remove(ActionListener.class, l);
    }

    /**
     * @param evt
     */
    private void wActionPerformed(ActionEvent evt)
    {
        for (ActionListener al : listenerList.getListeners(ActionListener.class))
        {
            al.actionPerformed(evt);
        }
    }

    /** serialVersionUID */
    private static final long serialVersionUID = 4443006603494652878L;
}
