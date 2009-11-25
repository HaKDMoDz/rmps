/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.ui.text;

import java.awt.datatransfer.Clipboard;
import java.awt.datatransfer.ClipboardOwner;
import java.awt.datatransfer.Transferable;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;

import javax.swing.JTextArea;
import javax.swing.KeyStroke;

import rmp.face.WBean;
import rmp.util.LogUtil;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public class WTextArea extends JTextArea implements WBean, ClipboardOwner
{
    private javax.swing.undo.UndoManager undo;

    /**
     * 
     */
    public WTextArea()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.WRmps#wInit()
     */
    public boolean wInit()
    {
        undo = new javax.swing.undo.UndoManager();

        // Edit事件
        getDocument().addUndoableEditListener(new javax.swing.event.UndoableEditListener()
        {
            public void undoableEditHappened(javax.swing.event.UndoableEditEvent evt)
            {
                userEdit(evt);
            }
        });

        // Undo事件
        getActionMap().put("Undo", new javax.swing.AbstractAction("Undo")
        {
            private static final long serialVersionUID = -5602849557973977822L;

            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                undoActionPerformed(evt);
            }
        });
        getInputMap().put(KeyStroke.getKeyStroke(KeyEvent.VK_Z, InputEvent.CTRL_MASK), "Undo");

        // Redo事件
        getActionMap().put("Redo", new javax.swing.AbstractAction("Redo")
        {
            private static final long serialVersionUID = 7394562304958387152L;

            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                redoActionPerformed(evt);
            }
        });
        getInputMap().put(KeyStroke.getKeyStroke(KeyEvent.VK_R, InputEvent.CTRL_MASK), "Redo");
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.awt.datatransfer.ClipboardOwner#lostOwnership(java.awt.datatransfer.Clipboard,
     *      java.awt.datatransfer.Transferable)
     */
    @Override
    public void lostOwnership(Clipboard clipboard, Transferable contents)
    {
    }

    /**
     * @param evt
     */
    private void userEdit(javax.swing.event.UndoableEditEvent evt)
    {
        undo.addEdit(evt.getEdit());
    }

    /**
     * @param evt
     */
    private void undoActionPerformed(java.awt.event.ActionEvent evt)
    {
        try
        {
            if (undo.canUndo())
            {
                undo.undo();
            }
        }
        catch (javax.swing.undo.CannotUndoException exp)
        {
            LogUtil.exception(exp);
        }
    }

    /**
     * @param evt
     */
    private void redoActionPerformed(java.awt.event.ActionEvent evt)
    {
        try
        {
            if (undo.canRedo())
            {
                undo.redo();
            }
        }
        catch (javax.swing.undo.CannotRedoException exp)
        {
            LogUtil.exception(exp);
        }
    }
    /** serialVersionUID */
    private static final long serialVersionUID = -5369858175289599108L;
}
