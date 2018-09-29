namespace InventoryManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Add New Item");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Order Stock");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Receive Stock");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Sell Stock");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Transfer Stock");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Orders List");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Items", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiveStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToLocationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSuppliersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invetoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintoolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripNewItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLocations = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripReports = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripTbInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPoDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.stockTransactionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSuppliers = new System.Windows.Forms.ToolStripButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.SideBar = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.tvItems = new System.Windows.Forms.TreeView();
            this.gbFindItem = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.cbFindItem = new System.Windows.Forms.ComboBox();
            this.stockTransactionReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.MaintoolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.gbFindItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.locationsToolStripMenuItem,
            this.suppliersToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(927, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.orderStockToolStripMenuItem,
            this.receiveStockToolStripMenuItem,
            this.sellStockToolStripMenuItem,
            this.transferStockToolStripMenuItem,
            this.ordersListToolStripMenuItem,
            this.exitCloseToolStripMenuItem});
            this.inventoryToolStripMenuItem.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.newItemToolStripMenuItem.Text = "New Item........";
            this.newItemToolStripMenuItem.Click += new System.EventHandler(this.newItemToolStripMenuItem_Click);
            // 
            // orderStockToolStripMenuItem
            // 
            this.orderStockToolStripMenuItem.Name = "orderStockToolStripMenuItem";
            this.orderStockToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.orderStockToolStripMenuItem.Text = "Order Stock";
            this.orderStockToolStripMenuItem.Click += new System.EventHandler(this.orderStockToolStripMenuItem_Click);
            // 
            // receiveStockToolStripMenuItem
            // 
            this.receiveStockToolStripMenuItem.Name = "receiveStockToolStripMenuItem";
            this.receiveStockToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.receiveStockToolStripMenuItem.Text = "Receive Stock";
            this.receiveStockToolStripMenuItem.Click += new System.EventHandler(this.receiveStockToolStripMenuItem_Click);
            // 
            // sellStockToolStripMenuItem
            // 
            this.sellStockToolStripMenuItem.Name = "sellStockToolStripMenuItem";
            this.sellStockToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.sellStockToolStripMenuItem.Text = "Sell Stock";
            this.sellStockToolStripMenuItem.Click += new System.EventHandler(this.sellStockToolStripMenuItem_Click);
            // 
            // transferStockToolStripMenuItem
            // 
            this.transferStockToolStripMenuItem.Name = "transferStockToolStripMenuItem";
            this.transferStockToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.transferStockToolStripMenuItem.Text = "Transfer Stock";
            this.transferStockToolStripMenuItem.Click += new System.EventHandler(this.transferStockToolStripMenuItem_Click);
            // 
            // ordersListToolStripMenuItem
            // 
            this.ordersListToolStripMenuItem.Name = "ordersListToolStripMenuItem";
            this.ordersListToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.ordersListToolStripMenuItem.Text = "Orders List";
            this.ordersListToolStripMenuItem.Click += new System.EventHandler(this.ordersListToolStripMenuItem_Click);
            // 
            // exitCloseToolStripMenuItem
            // 
            this.exitCloseToolStripMenuItem.Name = "exitCloseToolStripMenuItem";
            this.exitCloseToolStripMenuItem.Size = new System.Drawing.Size(178, 30);
            this.exitCloseToolStripMenuItem.Text = "Exit (Close)";
            this.exitCloseToolStripMenuItem.Click += new System.EventHandler(this.exitCloseToolStripMenuItem_Click);
            // 
            // locationsToolStripMenuItem
            // 
            this.locationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLocationToolStripMenuItem,
            this.goToLocationListToolStripMenuItem});
            this.locationsToolStripMenuItem.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationsToolStripMenuItem.Name = "locationsToolStripMenuItem";
            this.locationsToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.locationsToolStripMenuItem.Text = "Locations";
            // 
            // newLocationToolStripMenuItem
            // 
            this.newLocationToolStripMenuItem.Name = "newLocationToolStripMenuItem";
            this.newLocationToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.newLocationToolStripMenuItem.Text = "New Location";
            this.newLocationToolStripMenuItem.Click += new System.EventHandler(this.newLocationToolStripMenuItem_Click);
            // 
            // goToLocationListToolStripMenuItem
            // 
            this.goToLocationListToolStripMenuItem.Name = "goToLocationListToolStripMenuItem";
            this.goToLocationListToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.goToLocationListToolStripMenuItem.Text = "Go to Location List";
            this.goToLocationListToolStripMenuItem.Click += new System.EventHandler(this.goToLocationListToolStripMenuItem_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSupplierToolStripMenuItem,
            this.OpenSuppliersListToolStripMenuItem});
            this.suppliersToolStripMenuItem.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // newSupplierToolStripMenuItem
            // 
            this.newSupplierToolStripMenuItem.Name = "newSupplierToolStripMenuItem";
            this.newSupplierToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
            this.newSupplierToolStripMenuItem.Text = "New Supplier";
            this.newSupplierToolStripMenuItem.Click += new System.EventHandler(this.newSupplierToolStripMenuItem_Click);
            // 
            // OpenSuppliersListToolStripMenuItem
            // 
            this.OpenSuppliersListToolStripMenuItem.Name = "OpenSuppliersListToolStripMenuItem";
            this.OpenSuppliersListToolStripMenuItem.Size = new System.Drawing.Size(209, 30);
            this.OpenSuppliersListToolStripMenuItem.Text = "Open Suppliers list";
            this.OpenSuppliersListToolStripMenuItem.Click += new System.EventHandler(this.OpenSuppliersListToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invetoryReportToolStripMenuItem,
            this.purchaseOrderReportToolStripMenuItem,
            this.stockTransactionReportToolStripMenuItem1});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // invetoryReportToolStripMenuItem
            // 
            this.invetoryReportToolStripMenuItem.Name = "invetoryReportToolStripMenuItem";
            this.invetoryReportToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.invetoryReportToolStripMenuItem.Text = "Invetory Report";
            this.invetoryReportToolStripMenuItem.Click += new System.EventHandler(this.invetoryReportToolStripMenuItem_Click);
            // 
            // purchaseOrderReportToolStripMenuItem
            // 
            this.purchaseOrderReportToolStripMenuItem.Name = "purchaseOrderReportToolStripMenuItem";
            this.purchaseOrderReportToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.purchaseOrderReportToolStripMenuItem.Text = "Purchase Order Report";
            this.purchaseOrderReportToolStripMenuItem.Click += new System.EventHandler(this.purchaseOrderReportToolStripMenuItem_Click);
            // 
            // MaintoolStrip
            // 
            this.MaintoolStrip.AutoSize = false;
            this.MaintoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewItem,
            this.toolStripSeparator1,
            this.toolStripLocations,
            this.toolStripSeparator2,
            this.toolStripReports,
            this.toolStripSeparator3,
            this.toolStripSuppliers});
            this.MaintoolStrip.Location = new System.Drawing.Point(0, 33);
            this.MaintoolStrip.Name = "MaintoolStrip";
            this.MaintoolStrip.Size = new System.Drawing.Size(927, 89);
            this.MaintoolStrip.TabIndex = 2;
            this.MaintoolStrip.Text = "toolStrip1";
            // 
            // toolStripNewItem
            // 
            this.toolStripNewItem.AutoSize = false;
            this.toolStripNewItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripNewItem.Image = global::InventoryManagementSystem.Properties.Resources.new_red_icon;
            this.toolStripNewItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripNewItem.Name = "toolStripNewItem";
            this.toolStripNewItem.Size = new System.Drawing.Size(80, 84);
            this.toolStripNewItem.Text = "New Item";
            this.toolStripNewItem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripNewItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripNewItem.Click += new System.EventHandler(this.toolStripNewItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 89);
            // 
            // toolStripLocations
            // 
            this.toolStripLocations.Image = global::InventoryManagementSystem.Properties.Resources.Location;
            this.toolStripLocations.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLocations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLocations.Name = "toolStripLocations";
            this.toolStripLocations.Size = new System.Drawing.Size(84, 86);
            this.toolStripLocations.Text = "Locations";
            this.toolStripLocations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLocations.Click += new System.EventHandler(this.toolStripLocations_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 89);
            // 
            // toolStripReports
            // 
            this.toolStripReports.AutoSize = false;
            this.toolStripReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTbInventory,
            this.toolStripPoDetails,
            this.stockTransactionReportToolStripMenuItem});
            this.toolStripReports.Image = global::InventoryManagementSystem.Properties.Resources.Reports;
            this.toolStripReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripReports.Name = "toolStripReports";
            this.toolStripReports.Size = new System.Drawing.Size(90, 86);
            this.toolStripReports.Text = "Reports";
            this.toolStripReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripReports.ButtonClick += new System.EventHandler(this.toolStripReports_ButtonClick);
            // 
            // toolStripTbInventory
            // 
            this.toolStripTbInventory.Name = "toolStripTbInventory";
            this.toolStripTbInventory.Size = new System.Drawing.Size(206, 22);
            this.toolStripTbInventory.Text = "Invetory Report";
            this.toolStripTbInventory.ToolTipText = "View Total available quantity of each item";
            this.toolStripTbInventory.Click += new System.EventHandler(this.toolStripTbInventory_Click);
            // 
            // toolStripPoDetails
            // 
            this.toolStripPoDetails.Name = "toolStripPoDetails";
            this.toolStripPoDetails.Size = new System.Drawing.Size(206, 22);
            this.toolStripPoDetails.Text = "Purchase Order Report";
            this.toolStripPoDetails.ToolTipText = "View PO detials to each supplier";
            this.toolStripPoDetails.Click += new System.EventHandler(this.toolStripPoDetails_Click);
            // 
            // stockTransactionReportToolStripMenuItem
            // 
            this.stockTransactionReportToolStripMenuItem.Name = "stockTransactionReportToolStripMenuItem";
            this.stockTransactionReportToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.stockTransactionReportToolStripMenuItem.Text = "Stock Transaction Report";
            this.stockTransactionReportToolStripMenuItem.Click += new System.EventHandler(this.stockTransactionReportToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 89);
            // 
            // toolStripSuppliers
            // 
            this.toolStripSuppliers.AutoSize = false;
            this.toolStripSuppliers.Image = global::InventoryManagementSystem.Properties.Resources.Suppliers;
            this.toolStripSuppliers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSuppliers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSuppliers.Name = "toolStripSuppliers";
            this.toolStripSuppliers.Size = new System.Drawing.Size(84, 81);
            this.toolStripSuppliers.Text = "Suppliers";
            this.toolStripSuppliers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripSuppliers.Click += new System.EventHandler(this.toolStripSuppliers_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.SideBar});
            this.shapeContainer1.Size = new System.Drawing.Size(927, 589);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // SideBar
            // 
            this.SideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.SideBar.BackColor = System.Drawing.Color.MistyRose;
            this.SideBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SideBar.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.SideBar.BorderColor = System.Drawing.Color.Chocolate;
            this.SideBar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.SideBar.BorderWidth = 2;
            this.SideBar.Location = new System.Drawing.Point(1, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(219, 586);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Kalinga", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvItems.Location = new System.Drawing.Point(227, 122);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(700, 467);
            this.dgvItems.TabIndex = 5;
            // 
            // tvItems
            // 
            this.tvItems.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.tvItems.BackColor = System.Drawing.Color.MistyRose;
            this.tvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvItems.Font = new System.Drawing.Font("Andalus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvItems.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tvItems.Location = new System.Drawing.Point(32, 135);
            this.tvItems.Name = "tvItems";
            treeNode8.Name = "AddNew";
            treeNode8.Text = "Add New Item";
            treeNode9.Name = "OrderStock";
            treeNode9.Text = "Order Stock";
            treeNode10.Name = "ReceiveStock";
            treeNode10.Text = "Receive Stock";
            treeNode11.Name = "SellStock";
            treeNode11.Text = "Sell Stock";
            treeNode12.Name = "TransferStock";
            treeNode12.Text = "Transfer Stock";
            treeNode13.Name = "OrdersList";
            treeNode13.Text = "Orders List";
            treeNode14.Name = "ItemTask";
            treeNode14.Text = "Items";
            treeNode14.ToolTipText = "Click to View Items Related Task";
            this.tvItems.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.tvItems.ShowLines = false;
            this.tvItems.ShowNodeToolTips = true;
            this.tvItems.Size = new System.Drawing.Size(165, 235);
            this.tvItems.TabIndex = 10;
            this.tvItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvItems_AfterSelect);
            // 
            // gbFindItem
            // 
            this.gbFindItem.BackColor = System.Drawing.Color.MistyRose;
            this.gbFindItem.Controls.Add(this.btnFind);
            this.gbFindItem.Controls.Add(this.cbFindItem);
            this.gbFindItem.Font = new System.Drawing.Font("Andalus", 12F);
            this.gbFindItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbFindItem.Location = new System.Drawing.Point(32, 376);
            this.gbFindItem.Name = "gbFindItem";
            this.gbFindItem.Size = new System.Drawing.Size(165, 185);
            this.gbFindItem.TabIndex = 14;
            this.gbFindItem.TabStop = false;
            this.gbFindItem.Text = "Find Item";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(46, 104);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 31);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbFindItem
            // 
            this.cbFindItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFindItem.FormattingEnabled = true;
            this.cbFindItem.Location = new System.Drawing.Point(6, 54);
            this.cbFindItem.Name = "cbFindItem";
            this.cbFindItem.Size = new System.Drawing.Size(153, 23);
            this.cbFindItem.TabIndex = 13;
            // 
            // stockTransactionReportToolStripMenuItem1
            // 
            this.stockTransactionReportToolStripMenuItem1.Name = "stockTransactionReportToolStripMenuItem1";
            this.stockTransactionReportToolStripMenuItem1.Size = new System.Drawing.Size(249, 30);
            this.stockTransactionReportToolStripMenuItem1.Text = "Stock Transaction Report";
            this.stockTransactionReportToolStripMenuItem1.Click += new System.EventHandler(this.stockTransactionReportToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 589);
            this.Controls.Add(this.gbFindItem);
            this.Controls.Add(this.tvItems);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.MaintoolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.shapeContainer1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MaintoolStrip.ResumeLayout(false);
            this.MaintoolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.gbFindItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersListToolStripMenuItem;
        private System.Windows.Forms.ToolStrip MaintoolStrip;
        private System.Windows.Forms.ToolStripButton toolStripNewItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripLocations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripSuppliers;
        private System.Windows.Forms.ToolStripMenuItem newLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToLocationListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenSuppliersListToolStripMenuItem;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape SideBar;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.TreeView tvItems;
        private System.Windows.Forms.GroupBox gbFindItem;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbFindItem;
        private System.Windows.Forms.ToolStripMenuItem invetoryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripReports;
        private System.Windows.Forms.ToolStripMenuItem toolStripTbInventory;
        private System.Windows.Forms.ToolStripMenuItem toolStripPoDetails;
        private System.Windows.Forms.ToolStripMenuItem exitCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockTransactionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockTransactionReportToolStripMenuItem1;


    }
}

