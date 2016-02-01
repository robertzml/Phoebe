using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    {
        #region System
        /// <summary>
        /// 成功
        /// </summary>
        [Display(Name = "成功")]
        Success = 0,

        /// <summary>
        /// 错误
        /// </summary>
        [Display(Name = "错误")]
        Error = 1,

        /// <summary>
        /// 异常
        /// </summary>
        [Display(Name = "异常")]
        Exception = 2,

        /// <summary>
        /// 未实现程序
        /// </summary>
        [Display(Name = "未实现程序")]
        NotImplement = 3,

        /// <summary>
        /// 对象已删除
        /// </summary>
        [Display(Name = "对象已删除")]
        ObjectDeleted = 4,

        /// <summary>
        /// 对象未找到
        /// </summary>
        [Display(Name = "对象未找到")]
        ObjectNotFound = 5,

        /// <summary>
        /// 数据库写入失败
        /// </summary>
        [Display(Name = "数据库写入失败")]
        DatabaseWriteError = 6,

        /// <summary>
        /// 权限不够
        /// </summary>
        [Display(Name = "权限不够")]
        NoPrivilege = 7,

        /// <summary>
        /// 编号重复
        /// </summary>
        [Display(Name = "编号重复")]
        DuplicateNumber = 8,
        #endregion //System

        #region User
        /// <summary>
        /// 用户名称重复
        /// </summary>
        [Display(Name = "用户名称重复")]
        DuplicateUserName = 11,

        /// <summary>
        /// 密码错误
        /// </summary>
        [Display(Name = "密码错误")]
        WrongPassword = 12,

        /// <summary>
        /// 用户不存在
        /// </summary>
        [Display(Name = "用户不存在")]
        UserNotExist = 13,

        /// <summary>
        /// 用户已禁用
        /// </summary>
        [Display(Name = "用户已禁用")]
        UserDisabled = 14,
        #endregion //User

        #region Contract
        /// <summary>
        /// 合同编号重复
        /// </summary>
        [Display(Name = "编号重复")]
        ContractDuplicateNumber = 21,

        /// <summary>
        /// 合同有货品未出库
        /// </summary>
        [Display(Name = "有货品未出库")]
        ContractHasCargo = 22,
        #endregion //Contract

        #region Warehosue & Tray
        /// <summary>
        /// 仓库级别超出
        /// </summary>
        [Display(Name = "仓库级别超出")]
        WarehouseLevelOverflow = 30,

        /// <summary>
        /// 仓库不能为空
        /// </summary>
        [Display(Name = "仓库不能为空")]
        WarehouseCannotBeEmpty = 31,

        /// <summary>
        /// 托盘使用中
        /// </summary>
        [Display(Name = "托盘使用中")]
        TrayInUse = 35,
        #endregion//Warehouse & Tray

        #region Cargo
        /// <summary>
        /// 货品未找到
        /// </summary>
        [Display(Name = "货品未找到")]
        CargoNotFound = 40,

        /// <summary>
        /// 货品无法结算
        /// </summary>
        [Display(Name = "货品无法结算")]
        CargoCannotSettled = 41,
        #endregion //Cargo

        #region Stock
        /// <summary>
        /// 库存未找到
        /// </summary>
        [Display(Name = "库存未找到")]
        StockNotFound = 50,

        /// <summary>
        /// 出库数量超出
        /// </summary>
        [Display(Name = "出库数量超出")]
        StockOutCountOverflow = 51,
        #endregion //Stock
    }
}
