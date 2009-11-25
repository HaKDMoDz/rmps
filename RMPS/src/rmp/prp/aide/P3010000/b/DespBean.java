/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3010000.b;

import java.sql.SQLException;

import javax.swing.DefaultComboBoxModel;
import javax.swing.JPanel;

import rmp.bean.K1SV2S;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P3010000.P3010000;
import rmp.prp.aide.P3010000.d.DA8000;
import rmp.prp.aide.P3010000.m.DespBaseData;
import rmp.util.LogUtil;
import rmp.util.MesgUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.CfgCons;
import cons.prp.aide.P3010000.ConstUI;
import cons.prp.aide.P3010000.LangRes;

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
public class DespBean extends JPanel
{
    private String despHash;
    /** 语言选择对象 */
    private K1SV2S kv_LangMeta;
    /** 语言下拉列表数据模型 */
    private DefaultComboBoxModel cm_LangList;

    /**
     * 
     */
    public DespBean()
    {
    }

    public boolean wInit()
    {
        ica();
        ita();

        return true;
    }

    private void ica()
    {
        cm_LangList = new DefaultComboBoxModel();
        cb_LangList = new javax.swing.JComboBox();
        cb_LangList.setModel(cm_LangList);

        cb_LangList.addItemListener(new java.awt.event.ItemListener()
        {
            @Override
            public void itemStateChanged(java.awt.event.ItemEvent evt)
            {
                cb_LangListItemStateChanged(evt);
            }
        });

        ta_ExtsDesp.addMouseListener(new java.awt.event.MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent evt)
            {
                ta_ExtsDespMouseClicked(evt);
            }
        });
    }

    private void ita()
    {
    }

    /**
     * 
     */
    public void setDefault()
    {
    }

    /**
     * 
     */
    public void readDespMeta(DBAccess dba, String despHash) throws SQLException
    {
        this.despHash = despHash;
        readDespMeta(dba);
    }

    /**
     * @param dba
     */
    private void readDespMeta(DBAccess dba) throws SQLException
    {
        K1SV2S kv = (K1SV2S) cb_LangList.getSelectedItem();

        String langHash = (kv != null) ? kv.getK() : RmpsUtil.getUserInfo().getCfg(CfgCons.CFG_LANG_ID);

        // 描述数据查询
        DespBaseData despMeta = DA8000.selectDespMetaInfo(dba, despHash, langHash);

        // 描述信息显示
        ta_ExtsDesp.setText(despMeta.isMetaExist() ? despMeta.getExtsDesp() : "");
    }

    /**
     * 语言下拉列表事件处理
     */
    private void cb_LangListItemStateChanged(java.awt.event.ItemEvent evt)
    {
        // 默认数据检测
        if (ConstUI.DEF_DESPHASH.equals(despHash))
        {
            return;
        }

        // 语言索引检测
        K1SV2S kvItem = (K1SV2S) cb_LangList.getSelectedItem();
        if (kvItem == null || kvItem == kv_LangMeta)
        {
            return;
        }
        kv_LangMeta = kvItem;

        // 数据库操作对象实例化
        DBAccess dba = new DBAccess();
        DespBaseData baseMeta = null;

        try
        {
            // 连接数据库
            if (!dba.wInit())
            {
                return;
            }

            // 数据查询
            baseMeta = DA8000.selectDespMetaInfo(dba, "", kv_LangMeta.getK());
        }
        catch (SQLException exp)
        {
            LogUtil.exception(exp);
            String mesg = StringUtil.format(LangRes.MESG_SELT_0007, LangRes.TITLE_DESPFORM, LangRes.MESG_INIT_0010);
            MesgUtil.showMessageDialog(P3010000.getForm(), mesg);
            return;
        }
        finally
        {
            dba.closeConnection();
        }

        // 描述信息显示
        ta_ExtsDesp.setText(baseMeta.isMetaExist() ? baseMeta.getExtsDesp() : "");
    }

    /**
     * @param evt
     */
    private void ta_ExtsDespMouseClicked(java.awt.event.MouseEvent evt)
    {
        if (evt.getClickCount() < 2)
        {
            return;
        }

        // 语言检测
        K1SV2S kvItem = (K1SV2S) cb_LangList.getSelectedItem();
        if (kvItem == null)
        {
            return;
        }

        // 默认值检测
        if (ConstUI.DEF_DESPHASH == "")
        {
            return;
        }

        // 后缀描述信息显示
        WItemForm.getInstance().wShowItem(ConstUI.PROP_ITEM_DESP).wViewData(kvItem.getK());
    }
    protected javax.swing.JComboBox cb_LangList;
    protected javax.swing.JTextArea ta_ExtsDesp;
    /**  */
    private static final long serialVersionUID = 3341192768189843944L;
}
