/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.irp;

import java.util.HashMap;

import rmp.irp.v.fetion.Fetion;
import rmp.irp.v.gtalk.GTalk;
import rmp.irp.v.jabber.Jabber;
import rmp.irp.v.live.Live;
import rmp.irp.v.meebo.Meebo;
import rmp.irp.v.qq.QQ;

import com.amonsoft.rmps.irp.b.IPresence;
import com.amonsoft.rmps.irp.v.IAccount;

import cons.irp.ConsEnv;

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
public class Irps
{
    private static HashMap<String, IAccount> accounts;
    private static java.awt.MenuItem irpsItem;

    public static void init(java.awt.Menu menu)
    {
        if (menu == null)
        {
            return;
        }

        main(null);

        irpsItem = new java.awt.MenuItem("Live");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Live();
                account.sign(IPresence.INIT);
                account.sign(IPresence.SIGN);
                accounts.put(ConsEnv.IM_LIVE, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("GTalk");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new GTalk();
                account.sign(IPresence.INIT);
                account.sign(IPresence.SIGN);
                accounts.put(ConsEnv.IM_GTALK, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("meebo");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Meebo();
                account.sign(IPresence.INIT);
                account.sign(IPresence.SIGN);
                accounts.put(ConsEnv.IM_MEEBO, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("jabber");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Jabber();
                account.sign(IPresence.INIT);
                account.sign(IPresence.SIGN);
                accounts.put(ConsEnv.IM_JABBER, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("Fetion");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new Fetion();
                account.sign(IPresence.INIT);
                account.sign(IPresence.SIGN);
                accounts.put(ConsEnv.IM_FETION, account);
            }
        });
        menu.add(irpsItem);

        irpsItem = new java.awt.MenuItem("QQ");
        irpsItem.addActionListener(new java.awt.event.ActionListener()
        {
            @Override
            public void actionPerformed(java.awt.event.ActionEvent evt)
            {
                IAccount account = new QQ();
                account.sign(IPresence.INIT);
                account.sign(IPresence.SIGN);
                accounts.put(ConsEnv.IM_QQ, account);
            }
        });
        menu.add(irpsItem);
    }

    /**
     * @param args
     *            the command line arguments
     */
    public static void main(String[] args)
    {
        // LogUtil.wInit("log");

        accounts = new HashMap<String, IAccount>();

        java.security.Security.addProvider(new cryptix.jce.provider.CryptixCrypto());
    }

    public static void exit(int status)
    {
        for (IAccount acc : accounts.values())
        {
            acc.sign(IPresence.DOWN);
        }
        System.exit(status);
    }

    public static void step(String account, int status)
    {
        IAccount acc = accounts.get(account);
        if (acc != null)
        {
            acc.sign(status);
        }
    }
}
