/*
 * FileName:       UserKeys.java
 * CreateDate:     2008-3-1 下午02:59:30
 * ProjectName:    RMPS
 * Compiler:       JDK1.6.0_01
 * CopyRight:      Amon (C) 2007 Winshine ( Amonsoft@gmail.com / http://www.amonsoft.cn ).
 * Description:    
 */

package rmp.prp.aide.P30F0000.m;

import java.security.InvalidKeyException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SecretKey;

import rmp.prp.aide.P30F0000.P30F0000;
import rmp.prp.aide.P30F0000.t.Util;
import rmp.user.UserInfo;
import rmp.util.CheckUtil;
import rmp.util.LogUtil;
import rmp.util.RmpsUtil;
import rmp.util.StringUtil;
import cons.prp.aide.P30F0000.ConstUI;
import cons.prp.aide.P30F0000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br>
 * 根据用户输入口令计算用户数据安全密钥
 * <li>使用说明：</li>
 * <br>
 * </ul>
 * <p>
 * 版本： RMPS V1.0.0.0
 * </p>
 * <p>
 * 作者： Amon
 * </p>
 * <p>
 * 日期： 2008-3-1 下午02:59:30
 * </p>
 * <p>
 * 团队： WinShine开发团队
 * </p>
 */
public final class UserKeys implements SecretKey
{
    private String userName;
    private String userPwds;
    private String userSalt;
    /** 用户口令加密口令 */
    private byte[] keys;
    /** 用户口令配置密文取值空间 */
    private char[] mask;

    /**
     * @param name
     * @param pwds
     */
    public UserKeys(String name, String pwds)
    {
        this(name, pwds, pwds);
    }

    /**
     * @param name
     * @param pwds
     * @param salt
     */
    public UserKeys(String name, String pwds, String salt)
    {
        this.userName = name;
        this.userPwds = pwds;
        this.userSalt = salt;
    }

    /**
     * @return
     */
    public boolean wInit()
    {
        return true;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getAlgorithm()
     */
    @ Override
    public String getAlgorithm()
    {
        return ConstUI.NAME_CIPHER;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getEncoded()
     */
    @ Override
    public byte[] getEncoded()
    {
        return keys;
    }

    /*
     * (non-Javadoc)
     * 
     * @see java.security.Key#getFormat()
     */
    @ Override
    public String getFormat()
    {
        return "RAW";
    }

    /**
     * @param pwds
     */
    public void setPwds(String pwds)
    {
        this.userPwds = pwds;
    }

    /**
     * 
     */
    char[] getCharacter()
    {
        return mask;
    }

    /**
     * 用户登录
     */
    final boolean signIn() throws Exception
    {
        try
        {
            UserInfo ui = RmpsUtil.getUserInfo();

            // 用户登录身份认证
            String text = ui.getCfg(ConstUI.CFG_USER);
            if (!CheckUtil.isValidate(text))
            {
                throw new Exception(P30F0000.getMesg(LangRes.P30F6A08));
            }
            byte[] temp = signInDigest();
            if (!text.equals(StringUtil.bytesToString(temp, true)))
            {
                throw new Exception(P30F0000.getMesg(LangRes.P30F6A09));
            }

            // 获取用户配置密文
            keys = cipherDigest();

            text = ui.getCfg(ConstUI.CFG_INFO);
            temp = StringUtil.stringToBytes(text, true);

            // 解密用户配置密文获得解密数据
            Cipher aes = Cipher.getInstance(ConstUI.NAME_CIPHER);
            aes.init(Cipher.DECRYPT_MODE, this);
            temp = aes.doFinal(temp);
            System.arraycopy(temp, 16, keys, 0, temp.length - 16);
            mask = new String(temp, 0, 16).toCharArray();
            userPwds = "";
        }
        catch(NoSuchAlgorithmException exp)
        {
            LogUtil.exception(exp);
            throw new Exception(P30F0000.getMesg(LangRes.P30F6A0A));
        }
        catch(NoSuchPaddingException exp)
        {
            LogUtil.exception(exp);
            throw new Exception(P30F0000.getMesg(LangRes.P30F6A0B));
        }
        catch(InvalidKeyException exp)
        {
            LogUtil.exception(exp);
            throw new Exception(P30F0000.getMesg(LangRes.P30F6A0C));
        }
        catch(IllegalBlockSizeException exp)
        {
            LogUtil.exception(exp);
            throw new Exception(P30F0000.getMesg(LangRes.P30F6A0D));
        }
        return true;
    }

    /**
     * 用户注册
     */
    final boolean signUp() throws Exception
    {
        try
        {
            UserInfo ui = RmpsUtil.getUserInfo();

            // 摘要用户登录信息
            byte[] temp = signInDigest();
            ui.setCfg(ConstUI.CFG_USER, StringUtil.bytesToString(temp, true));

            // 摘要用户加密信息
            keys = cipherDigest();

            // 生成加密密钥及字符空间
            byte[] t = new byte[32];
            mask = Util.generateDataChar();
            temp = new String(mask).getBytes();// 字符空间
            System.arraycopy(temp, 0, t, 0, temp.length);
            temp = Util.generateDataKeys();// 加密密钥
            System.arraycopy(temp, 0, t, 16, temp.length);

            // 加密安全数据
            Cipher aes = Cipher.getInstance(ConstUI.NAME_CIPHER);
            aes.init(Cipher.ENCRYPT_MODE, this);
            keys = temp;
            temp = aes.doFinal(t);
            ui.setCfg(ConstUI.CFG_INFO, StringUtil.bytesToString(temp, true));
        }
        catch(NoSuchAlgorithmException e)
        {
            throw new Exception(P30F0000.getMesg(LangRes.P30F6A0A));
        }
        return true;
    }

    /**
     * @throws Exception
     */
    final boolean signPwd(String oldPwds, String newPwds) throws Exception
    {
        try
        {
            UserInfo ui = RmpsUtil.getUserInfo();

            // 已有口令校验
            userPwds = oldPwds;
            byte[] temp = signInDigest();
            if (!StringUtil.bytesToString(temp, true).equals(ui.getCfg(ConstUI.CFG_USER)))
            {
                return false;
            }

            // 摘要用户登录信息
            userPwds = newPwds;
            userSalt = newPwds;
            temp = signInDigest();
            ui.setCfg(ConstUI.CFG_USER, StringUtil.bytesToString(temp, true));

            // 生成加密密钥及字符空间
            byte[] t = new byte[32];
            temp = new String(mask).getBytes();
            System.arraycopy(temp, 0, t, 0, temp.length);
            System.arraycopy(keys, 0, t, 16, keys.length);

            // 摘要用户加密信息
            temp = keys;
            keys = cipherDigest();

            // 加密安全数据
            Cipher aes = Cipher.getInstance(ConstUI.NAME_CIPHER);
            aes.init(Cipher.ENCRYPT_MODE, this);
            keys = aes.doFinal(t);
            ui.setCfg(ConstUI.CFG_INFO, StringUtil.bytesToString(keys, true));

            // 恢复原有数据加密口令
            keys = temp;
        }
        catch(NoSuchAlgorithmException e)
        {
            throw new Exception(P30F0000.getMesg(LangRes.P30F6A0A));
        }
        return true;
    }

    /**
     * 用户登录验证摘要
     * 
     * @param md
     * @return
     * @throws NoSuchAlgorithmException
     */
    private final byte[] signInDigest() throws NoSuchAlgorithmException
    {
        MessageDigest md = MessageDigest.getInstance(ConstUI.NAME_DIGEST);
        return md.digest((userName + '@' + userPwds + '/' + userSalt).getBytes());
    }

    /**
     * 用户数据加密摘要，用于生成适用于AES密码算法的密钥。<br>
     * 此处使用MD5进行摘要，是考虑到已使用SHA-512进行身份认证的前提。
     * 
     * @param md
     * @return
     * @throws NoSuchAlgorithmException
     */
    private final byte[] cipherDigest() throws NoSuchAlgorithmException
    {
        MessageDigest md = MessageDigest.getInstance("MD5");
        return md.digest((userName + "@" + userPwds + "/Amonsoft.cn").getBytes());
    }

    /** serialVersionUID */
    private static final long serialVersionUID = 6528915918320327673L;
}
