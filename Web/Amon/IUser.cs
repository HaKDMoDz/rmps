using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///IUser 的摘要说明
/// </summary>
public class IUser
{
    /// <summary>
    /// 默认联系方式
    /// </summary>
    public const int MAJOR_00 = 0;
    /// <summary>
    /// 一般联系方式
    /// </summary>
    public const int MAJOR_01 = 1;
    /// <summary>
    /// 重要联系方式
    /// </summary>
    public const int MAJOR_02 = 2;
    /// <summary>
    /// 备选联系方式
    /// </summary>
    public const int MAJOR_03 = 3;
    /// <summary>
    /// 首选联系方式
    /// </summary>
    public const int MAJOR_04 = 4;

    /// <summary>
    /// 游客
    /// </summary>
    public const int LEVEL_00 = 0;
    /// <summary>
    /// 匿名用户
    /// </summary>
    public const int LEVEL_01 = 1;
    /// <summary>
    /// 一般用户
    /// </summary>
    public const int LEVEL_02 = 2;
    /// <summary>
    /// 高级用户
    /// </summary>
    public const int LEVEL_03 = 3;
    /// <summary>
    /// 专用用户
    /// </summary>
    public const int LEVEL_04 = 4;
    /// <summary>
    /// 客服用户
    /// </summary>
    public const int LEVEL_05 = 5;
    /// <summary>
    /// 网站管理员
    /// </summary>
    public const int LEVEL_06 = 6;
    /// <summary>
    /// 数据库管理员
    /// </summary>
    public const int LEVEL_07 = 7;
    /// <summary>
    /// 超级用户
    /// </summary>
    public const int LEVEL_08 = 8;
    /// <summary>
    /// 系统管理员
    /// </summary>
    public const int LEVEL_09 = 9;

    /// <summary>
    /// 系统共用用户代码
    /// </summary>
    public const string AMON_CODE = "A0000000";
    /// <summary>
    /// 系统演示用户代码
    /// </summary>
    public const string DEMO_CODE = "A0000001";
    /// <summary>
    /// 系统测试用户代码
    /// </summary>
    public const string TEST_CODE = "A0000002";
}