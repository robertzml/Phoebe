namespace Phoebe.FormClient
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenu = new DevExpress.XtraBars.Bar();
            this.menuCustomer = new DevExpress.XtraBars.BarSubItem();
            this.menuCustomerList = new DevExpress.XtraBars.BarButtonItem();
            this.menuCustomerDashboard = new DevExpress.XtraBars.BarButtonItem();
            this.menuContract = new DevExpress.XtraBars.BarSubItem();
            this.menuContractList = new DevExpress.XtraBars.BarButtonItem();
            this.menuCargo = new DevExpress.XtraBars.BarSubItem();
            this.menuCategory = new DevExpress.XtraBars.BarButtonItem();
            this.menuCargoList = new DevExpress.XtraBars.BarButtonItem();
            this.menuCargoStore = new DevExpress.XtraBars.BarButtonItem();
            this.menuStock = new DevExpress.XtraBars.BarSubItem();
            this.menuStockIn = new DevExpress.XtraBars.BarButtonItem();
            this.menuStockOut = new DevExpress.XtraBars.BarButtonItem();
            this.menuStockMove = new DevExpress.XtraBars.BarButtonItem();
            this.menuStore = new DevExpress.XtraBars.BarSubItem();
            this.menuStoreList = new DevExpress.XtraBars.BarButtonItem();
            this.menuStoreSnapshot = new DevExpress.XtraBars.BarButtonItem();
            this.menuStoreTrace = new DevExpress.XtraBars.BarButtonItem();
            this.menuIce = new DevExpress.XtraBars.BarSubItem();
            this.menuIceStock = new DevExpress.XtraBars.BarButtonItem();
            this.menuIceSell = new DevExpress.XtraBars.BarButtonItem();
            this.menuIceStore = new DevExpress.XtraBars.BarButtonItem();
            this.menuIceSaleRecord = new DevExpress.XtraBars.BarButtonItem();
            this.menuSettle = new DevExpress.XtraBars.BarSubItem();
            this.menuColdPrice = new DevExpress.XtraBars.BarButtonItem();
            this.menuSettlement = new DevExpress.XtraBars.BarButtonItem();
            this.menuSettleList = new DevExpress.XtraBars.BarButtonItem();
            this.menuPayment = new DevExpress.XtraBars.BarButtonItem();
            this.menuDebt = new DevExpress.XtraBars.BarButtonItem();
            this.menuReport = new DevExpress.XtraBars.BarSubItem();
            this.menuTotalStorageReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuStockFlowReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuDailyFeeReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuPeriodFeeReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuDailyStorageReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuStockInventoryReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuCustomerCargoReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuCustomerFeeReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuDebtReport = new DevExpress.XtraBars.BarButtonItem();
            this.menuUser = new DevExpress.XtraBars.BarSubItem();
            this.menuUserList = new DevExpress.XtraBars.BarButtonItem();
            this.menuUserGroupList = new DevExpress.XtraBars.BarButtonItem();
            this.menuChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.menuTest = new DevExpress.XtraBars.BarButtonItem();
            this.barMdiList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barUserName = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barCustomerList = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.tabMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.menuStoreCheck = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenu,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menuCustomer,
            this.barSubItem2,
            this.barCustomerList,
            this.barMdiList,
            this.menuUser,
            this.menuUserList,
            this.menuUserGroupList,
            this.menuChangePassword,
            this.barStaticItem1,
            this.barHeaderItem1,
            this.barUserName,
            this.barStaticItem2,
            this.menuCustomerList,
            this.menuContract,
            this.menuContractList,
            this.menuCargo,
            this.menuCategory,
            this.menuStock,
            this.menuStockIn,
            this.menuStore,
            this.menuStockOut,
            this.menuStockMove,
            this.menuStoreList,
            this.menuSettle,
            this.menuColdPrice,
            this.menuStoreSnapshot,
            this.menuStoreTrace,
            this.menuSettlement,
            this.menuCustomerDashboard,
            this.menuSettleList,
            this.menuPayment,
            this.menuCargoList,
            this.menuTest,
            this.menuDebt,
            this.menuCargoStore,
            this.menuIce,
            this.menuIceStore,
            this.menuReport,
            this.menuStockFlowReport,
            this.menuStockInventoryReport,
            this.menuIceStock,
            this.menuIceSell,
            this.menuIceSaleRecord,
            this.menuDailyFeeReport,
            this.menuDailyStorageReport,
            this.menuPeriodFeeReport,
            this.menuCustomerCargoReport,
            this.menuDebtReport,
            this.menuTotalStorageReport,
            this.menuCustomerFeeReport,
            this.menuStoreCheck});
            this.barManager1.MainMenu = this.mainMenu;
            this.barManager1.MaxItemId = 55;
            this.barManager1.StatusBar = this.bar3;
            // 
            // mainMenu
            // 
            this.mainMenu.BarName = "Main menu";
            this.mainMenu.DockCol = 0;
            this.mainMenu.DockRow = 0;
            this.mainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCustomer),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuContract),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCargo),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStock),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStore),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuIce),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuSettle),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiList)});
            this.mainMenu.OptionsBar.AllowQuickCustomization = false;
            this.mainMenu.OptionsBar.DrawDragBorder = false;
            this.mainMenu.OptionsBar.MultiLine = true;
            this.mainMenu.OptionsBar.UseWholeRow = true;
            this.mainMenu.Text = "Main menu";
            // 
            // menuCustomer
            // 
            this.menuCustomer.Caption = "客户管理";
            this.menuCustomer.Id = 0;
            this.menuCustomer.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCustomerList),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCustomerDashboard)});
            this.menuCustomer.Name = "menuCustomer";
            // 
            // menuCustomerList
            // 
            this.menuCustomerList.Caption = "客户列表";
            this.menuCustomerList.Id = 13;
            this.menuCustomerList.Name = "menuCustomerList";
            this.menuCustomerList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCustomerList_ItemClick);
            // 
            // menuCustomerDashboard
            // 
            this.menuCustomerDashboard.Caption = "客户综合";
            this.menuCustomerDashboard.Id = 29;
            this.menuCustomerDashboard.Name = "menuCustomerDashboard";
            this.menuCustomerDashboard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCustomerDashboard_ItemClick);
            // 
            // menuContract
            // 
            this.menuContract.Caption = "合同管理";
            this.menuContract.Id = 14;
            this.menuContract.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuContractList)});
            this.menuContract.Name = "menuContract";
            // 
            // menuContractList
            // 
            this.menuContractList.Caption = "合同列表";
            this.menuContractList.Id = 15;
            this.menuContractList.Name = "menuContractList";
            this.menuContractList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuContractList_ItemClick);
            // 
            // menuCargo
            // 
            this.menuCargo.Caption = "货品管理";
            this.menuCargo.Id = 16;
            this.menuCargo.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCategory),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCargoList),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCargoStore)});
            this.menuCargo.Name = "menuCargo";
            // 
            // menuCategory
            // 
            this.menuCategory.Caption = "类别管理";
            this.menuCategory.Id = 17;
            this.menuCategory.Name = "menuCategory";
            this.menuCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCategory_ItemClick);
            // 
            // menuCargoList
            // 
            this.menuCargoList.Caption = "货品列表";
            this.menuCargoList.Id = 32;
            this.menuCargoList.Name = "menuCargoList";
            this.menuCargoList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCargoList_ItemClick);
            // 
            // menuCargoStore
            // 
            this.menuCargoStore.Caption = "货品库存";
            this.menuCargoStore.Id = 36;
            this.menuCargoStore.Name = "menuCargoStore";
            this.menuCargoStore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCargoStore_ItemClick);
            // 
            // menuStock
            // 
            this.menuStock.Caption = "冷库租赁";
            this.menuStock.Id = 18;
            this.menuStock.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStockIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStockOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStockMove)});
            this.menuStock.Name = "menuStock";
            // 
            // menuStockIn
            // 
            this.menuStockIn.Caption = "货品入库";
            this.menuStockIn.Id = 19;
            this.menuStockIn.Name = "menuStockIn";
            this.menuStockIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStockIn_ItemClick);
            // 
            // menuStockOut
            // 
            this.menuStockOut.Caption = "货品出库";
            this.menuStockOut.Id = 21;
            this.menuStockOut.Name = "menuStockOut";
            this.menuStockOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStockOut_ItemClick);
            // 
            // menuStockMove
            // 
            this.menuStockMove.Caption = "货品移库";
            this.menuStockMove.Id = 22;
            this.menuStockMove.Name = "menuStockMove";
            this.menuStockMove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStockMove_ItemClick);
            // 
            // menuStore
            // 
            this.menuStore.Caption = "库存管理";
            this.menuStore.Id = 20;
            this.menuStore.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStoreList),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStoreSnapshot),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStoreTrace),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStoreCheck)});
            this.menuStore.Name = "menuStore";
            // 
            // menuStoreList
            // 
            this.menuStoreList.Caption = "库存记录";
            this.menuStoreList.Id = 23;
            this.menuStoreList.Name = "menuStoreList";
            this.menuStoreList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStoreList_ItemClick);
            // 
            // menuStoreSnapshot
            // 
            this.menuStoreSnapshot.Caption = "库存快照";
            this.menuStoreSnapshot.Id = 26;
            this.menuStoreSnapshot.Name = "menuStoreSnapshot";
            this.menuStoreSnapshot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStoreSnapshot_ItemClick);
            // 
            // menuStoreTrace
            // 
            this.menuStoreTrace.Caption = "库存追溯";
            this.menuStoreTrace.Id = 27;
            this.menuStoreTrace.Name = "menuStoreTrace";
            this.menuStoreTrace.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStoreTrace_ItemClick);
            // 
            // menuIce
            // 
            this.menuIce.Caption = "冰块管理";
            this.menuIce.Id = 37;
            this.menuIce.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuIceStock),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuIceSell),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuIceStore),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuIceSaleRecord)});
            this.menuIce.Name = "menuIce";
            // 
            // menuIceStock
            // 
            this.menuIceStock.Caption = "冰块操作";
            this.menuIceStock.Id = 44;
            this.menuIceStock.Name = "menuIceStock";
            this.menuIceStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuIceStock_ItemClick);
            // 
            // menuIceSell
            // 
            this.menuIceSell.Caption = "冰块销售";
            this.menuIceSell.Id = 45;
            this.menuIceSell.Name = "menuIceSell";
            this.menuIceSell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuIceSell_ItemClick);
            // 
            // menuIceStore
            // 
            this.menuIceStore.Caption = "冰块库存";
            this.menuIceStore.Id = 38;
            this.menuIceStore.Name = "menuIceStore";
            this.menuIceStore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuIceStore_ItemClick);
            // 
            // menuIceSaleRecord
            // 
            this.menuIceSaleRecord.Caption = "销售记录";
            this.menuIceSaleRecord.Id = 46;
            this.menuIceSaleRecord.Name = "menuIceSaleRecord";
            this.menuIceSaleRecord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuIceSaleRecord_ItemClick);
            // 
            // menuSettle
            // 
            this.menuSettle.Caption = "结算管理";
            this.menuSettle.Id = 24;
            this.menuSettle.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuColdPrice),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuSettlement),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuSettleList),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuPayment),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuDebt)});
            this.menuSettle.Name = "menuSettle";
            // 
            // menuColdPrice
            // 
            this.menuColdPrice.Caption = "冷藏费清单";
            this.menuColdPrice.Id = 25;
            this.menuColdPrice.Name = "menuColdPrice";
            this.menuColdPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuColdPrice_ItemClick);
            // 
            // menuSettlement
            // 
            this.menuSettlement.Caption = "费用结算";
            this.menuSettlement.Id = 28;
            this.menuSettlement.Name = "menuSettlement";
            this.menuSettlement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuSettlement_ItemClick);
            // 
            // menuSettleList
            // 
            this.menuSettleList.Caption = "结算记录";
            this.menuSettleList.Id = 30;
            this.menuSettleList.Name = "menuSettleList";
            this.menuSettleList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuSettleList_ItemClick);
            // 
            // menuPayment
            // 
            this.menuPayment.Caption = "缴费管理";
            this.menuPayment.Id = 31;
            this.menuPayment.Name = "menuPayment";
            this.menuPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuPayment_ItemClick);
            // 
            // menuDebt
            // 
            this.menuDebt.Caption = "实时欠费";
            this.menuDebt.Id = 35;
            this.menuDebt.Name = "menuDebt";
            this.menuDebt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuDebt_ItemClick);
            // 
            // menuReport
            // 
            this.menuReport.Caption = "报表管理";
            this.menuReport.Id = 41;
            this.menuReport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuTotalStorageReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStockFlowReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuDailyFeeReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuPeriodFeeReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuDailyStorageReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStockInventoryReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCustomerCargoReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuCustomerFeeReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuDebtReport)});
            this.menuReport.Name = "menuReport";
            // 
            // menuTotalStorageReport
            // 
            this.menuTotalStorageReport.Caption = "货品总报表";
            this.menuTotalStorageReport.Id = 52;
            this.menuTotalStorageReport.Name = "menuTotalStorageReport";
            this.menuTotalStorageReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuTotalStorageReport_ItemClick);
            // 
            // menuStockFlowReport
            // 
            this.menuStockFlowReport.Caption = "出入库报表";
            this.menuStockFlowReport.Id = 42;
            this.menuStockFlowReport.Name = "menuStockFlowReport";
            this.menuStockFlowReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStockFlowReport_ItemClick);
            // 
            // menuDailyFeeReport
            // 
            this.menuDailyFeeReport.Caption = "费用日报表";
            this.menuDailyFeeReport.Id = 47;
            this.menuDailyFeeReport.Name = "menuDailyFeeReport";
            this.menuDailyFeeReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuDailyFeeReport_ItemClick);
            // 
            // menuPeriodFeeReport
            // 
            this.menuPeriodFeeReport.Caption = "费用期报表";
            this.menuPeriodFeeReport.Id = 49;
            this.menuPeriodFeeReport.Name = "menuPeriodFeeReport";
            this.menuPeriodFeeReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuPeriodFeeReport_ItemClick);
            // 
            // menuDailyStorageReport
            // 
            this.menuDailyStorageReport.Caption = "库存日报表";
            this.menuDailyStorageReport.Id = 48;
            this.menuDailyStorageReport.Name = "menuDailyStorageReport";
            this.menuDailyStorageReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuDailyStorageReport_ItemClick);
            // 
            // menuStockInventoryReport
            // 
            this.menuStockInventoryReport.Caption = "库存盘点报表";
            this.menuStockInventoryReport.Id = 43;
            this.menuStockInventoryReport.Name = "menuStockInventoryReport";
            this.menuStockInventoryReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStockInventoryReport_ItemClick);
            // 
            // menuCustomerCargoReport
            // 
            this.menuCustomerCargoReport.Caption = "客户货品报表";
            this.menuCustomerCargoReport.Id = 50;
            this.menuCustomerCargoReport.Name = "menuCustomerCargoReport";
            this.menuCustomerCargoReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCustomerCargoReport_ItemClick);
            // 
            // menuCustomerFeeReport
            // 
            this.menuCustomerFeeReport.Caption = "客户费用报表";
            this.menuCustomerFeeReport.Id = 53;
            this.menuCustomerFeeReport.Name = "menuCustomerFeeReport";
            this.menuCustomerFeeReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuCustomerFeeReport_ItemClick);
            // 
            // menuDebtReport
            // 
            this.menuDebtReport.Caption = "实时欠费报表";
            this.menuDebtReport.Id = 51;
            this.menuDebtReport.Name = "menuDebtReport";
            this.menuDebtReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuDebtReport_ItemClick);
            // 
            // menuUser
            // 
            this.menuUser.Caption = "用户管理";
            this.menuUser.Id = 4;
            this.menuUser.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuUserList),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuUserGroupList),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuChangePassword, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuTest)});
            this.menuUser.Name = "menuUser";
            // 
            // menuUserList
            // 
            this.menuUserList.Caption = "用户列表";
            this.menuUserList.Id = 5;
            this.menuUserList.Name = "menuUserList";
            this.menuUserList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuUserList_ItemClick);
            // 
            // menuUserGroupList
            // 
            this.menuUserGroupList.Caption = "用户组列表";
            this.menuUserGroupList.Id = 6;
            this.menuUserGroupList.Name = "menuUserGroupList";
            this.menuUserGroupList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuUserGroupList_ItemClick);
            // 
            // menuChangePassword
            // 
            this.menuChangePassword.Caption = "修改密码";
            this.menuChangePassword.Id = 7;
            this.menuChangePassword.Name = "menuChangePassword";
            this.menuChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuChangePassword_ItemClick);
            // 
            // menuTest
            // 
            this.menuTest.Caption = "测试窗体";
            this.menuTest.Id = 34;
            this.menuTest.Name = "menuTest";
            this.menuTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuTest_ItemClick);
            // 
            // barMdiList
            // 
            this.barMdiList.Caption = "窗口";
            this.barMdiList.Id = 3;
            this.barMdiList.Name = "barMdiList";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barStaticItem1, "当前用户:"),
            new DevExpress.XtraBars.LinkPersistInfo(this.barUserName)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem1.Caption = "当前用户:";
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barUserName
            // 
            this.barUserName.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barUserName.Id = 11;
            this.barUserName.Name = "barUserName";
            this.barUserName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1186, 27);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 744);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1186, 30);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 27);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 717);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1186, 27);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 717);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "barSubItem2";
            this.barSubItem2.Id = 1;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barCustomerList
            // 
            this.barCustomerList.Id = 8;
            this.barCustomerList.Name = "barCustomerList";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "barHeaderItem1";
            this.barHeaderItem1.Id = 10;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 12;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabMdiManager
            // 
            this.tabMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabMdiManager.MdiParent = this;
            this.tabMdiManager.PinPageButtonShowMode = DevExpress.XtraTab.PinPageButtonShowMode.InActiveTabPageHeader;
            // 
            // menuStoreCheck
            // 
            this.menuStoreCheck.Caption = "库存检查";
            this.menuStoreCheck.Id = 54;
            this.menuStoreCheck.Name = "menuStoreCheck";
            this.menuStoreCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menuStoreCheck_ItemClick);
            // 
            // MainForm
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 774);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MainForm";
            this.Text = "华润冷链管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar mainMenu;
        private DevExpress.XtraBars.BarSubItem menuCustomer;
        private DevExpress.XtraBars.BarButtonItem barCustomerList;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdiManager;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiList;
        private DevExpress.XtraBars.BarSubItem menuUser;
        private DevExpress.XtraBars.BarButtonItem menuUserList;
        private DevExpress.XtraBars.BarButtonItem menuUserGroupList;
        private DevExpress.XtraBars.BarButtonItem menuChangePassword;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barUserName;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem menuCustomerList;
        private DevExpress.XtraBars.BarSubItem menuContract;
        private DevExpress.XtraBars.BarButtonItem menuContractList;
        private DevExpress.XtraBars.BarSubItem menuCargo;
        private DevExpress.XtraBars.BarButtonItem menuCategory;
        private DevExpress.XtraBars.BarSubItem menuStock;
        private DevExpress.XtraBars.BarButtonItem menuStockIn;
        private DevExpress.XtraBars.BarButtonItem menuStockOut;
        private DevExpress.XtraBars.BarButtonItem menuStockMove;
        private DevExpress.XtraBars.BarSubItem menuStore;
        private DevExpress.XtraBars.BarButtonItem menuStoreList;
        private DevExpress.XtraBars.BarSubItem menuSettle;
        private DevExpress.XtraBars.BarButtonItem menuColdPrice;
        private DevExpress.XtraBars.BarButtonItem menuStoreSnapshot;
        private DevExpress.XtraBars.BarButtonItem menuStoreTrace;
        private DevExpress.XtraBars.BarButtonItem menuSettlement;
        private DevExpress.XtraBars.BarButtonItem menuCustomerDashboard;
        private DevExpress.XtraBars.BarButtonItem menuSettleList;
        private DevExpress.XtraBars.BarButtonItem menuPayment;
        private DevExpress.XtraBars.BarButtonItem menuCargoList;
        private DevExpress.XtraBars.BarButtonItem menuTest;
        private DevExpress.XtraBars.BarButtonItem menuDebt;
        private DevExpress.XtraBars.BarButtonItem menuCargoStore;
        private DevExpress.XtraBars.BarSubItem menuIce;
        private DevExpress.XtraBars.BarButtonItem menuIceStore;
        private DevExpress.XtraBars.BarSubItem menuReport;
        private DevExpress.XtraBars.BarButtonItem menuStockFlowReport;
        private DevExpress.XtraBars.BarButtonItem menuStockInventoryReport;
        private DevExpress.XtraBars.BarButtonItem menuIceStock;
        private DevExpress.XtraBars.BarButtonItem menuIceSell;
        private DevExpress.XtraBars.BarButtonItem menuIceSaleRecord;
        private DevExpress.XtraBars.BarButtonItem menuDailyFeeReport;
        private DevExpress.XtraBars.BarButtonItem menuDailyStorageReport;
        private DevExpress.XtraBars.BarButtonItem menuPeriodFeeReport;
        private DevExpress.XtraBars.BarButtonItem menuCustomerCargoReport;
        private DevExpress.XtraBars.BarButtonItem menuDebtReport;
        private DevExpress.XtraBars.BarButtonItem menuTotalStorageReport;
        private DevExpress.XtraBars.BarButtonItem menuCustomerFeeReport;
        private DevExpress.XtraBars.BarButtonItem menuStoreCheck;
    }
}

