/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import java.awt.CardLayout;

import javax.swing.DefaultListModel;

import rmp.bean.K1SV2S;
import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.P3010000.i.WItem;
import rmp.prp.aide.P3010000.v.ItemAsoc;
import rmp.prp.aide.P3010000.v.ItemCorp;
import rmp.prp.aide.P3010000.v.ItemDesp;
import rmp.prp.aide.P3010000.v.ItemDocs;
import rmp.prp.aide.P3010000.v.ItemFile;
import rmp.prp.aide.P3010000.v.ItemIdio;
import rmp.prp.aide.P3010000.v.ItemMime;
import rmp.prp.aide.P3010000.v.ItemSoft;
import rmp.prp.aide.P30F0000.P30F0000;
import rmp.ui.form.DForm;
import cons.prp.aide.P3010000.ConstUI;

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
public class WItemForm extends DForm
{
    private static WItemForm ip_ItemForm;
    private java.util.HashMap<String, WItem> hm_ItemList;
    private CardLayout cl_ItemProp;
    private DefaultListModel lm_ItemList;

    /**
     * 
     */
    private WItemForm()
    {
        super((javax.swing.JFrame) P3010000.getForm());
    }

    public boolean wInit()
    {
        super.wInit();

        ica();
        ita();

        return true;
    }

    /**
     * @return
     */
    public static WItemForm getInstance()
    {
        if (ip_ItemForm == null)
        {
            ip_ItemForm = new WItemForm();
            ip_ItemForm.wInit();
        }
        return ip_ItemForm;
    }

    private void ica()
    {
    }

    /**
     * 
     */
    private void ita()
    {
    }

    /**
     * 
     */
    public void setDefault()
    {
        lm_ItemList.clear();
        pl_ItemProp.removeAll();
    }

    /**
     * @param kvItem
     */
    public WItem wShowItem(String hash)
    {
        K1SV2S kv = null;
        cl_ItemProp.show(pl_ItemProp, hash);
        for (int i = 0, j = lm_ItemList.size(); i < j; i += 1)
        {
            if (lm_ItemList.get(i).equals(hash))
            {
                kv = (K1SV2S) lm_ItemList.get(i);
                break;
            }
        }
        if (kv == null)
        {
            String t = null;
            if (ConstUI.PROP_ITEM_ASOC.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemAsoc p = new ItemAsoc();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_CORP.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemCorp p = new ItemCorp();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_DESP.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemDesp p = new ItemDesp();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_DOCS.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemDocs p = new ItemDocs();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_FILE.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemFile p = new ItemFile();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_IDIO.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemIdio p = new ItemIdio();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_MIME.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemMime p = new ItemMime();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }
            else if (ConstUI.PROP_ITEM_SOFT.equals(hash))
            {
                t = P30F0000.getMesg("");

                ItemSoft p = new ItemSoft();
                p.wInit();

                pl_ItemProp.add(hash, p);
                hm_ItemList.put(hash, p);
            }

            kv = new K1SV2S(hash, t, t);
            lm_ItemList.addElement(kv);
        }

        cl_ItemProp.show(pl_ItemProp, kv.getK());
        setTitle(kv.getV1());

        return hm_ItemList.get(hash);
    }

    /**
     * 选项列表用户选择事件
     */
    private void ls_ItemListH()
    {
        K1SV2S kvItem = (K1SV2S) ls_ItemList.getSelectedValue();
        if (kvItem == null)
        {
            return;
        }

        cl_ItemProp.show(pl_ItemProp, kvItem.getK());
        setTitle(kvItem.getV1());
    }
    private javax.swing.JList ls_ItemList;
    private javax.swing.JPanel pl_ItemProp;
    /**  */
    private static final long serialVersionUID = -7634751368497345418L;
}
