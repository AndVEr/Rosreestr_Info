namespace Rosreestr_Info
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.stStrip = new System.Windows.Forms.StatusStrip();
            this.pb1 = new System.Windows.Forms.ToolStripProgressBar();
            this.stLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lvCadastral = new System.Windows.Forms.ListView();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportList = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastral = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rr_checked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.r3_checked = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnStartAll = new System.Windows.Forms.ToolStripButton();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.cntMenuLV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuGetInfoByCadastral = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.stStrip.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.cntMenuLV.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.AutoSize = true;
            this.pnlTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTop.Controls.Add(this.tsMain);
            this.pnlTop.Controls.Add(this.mnuMain);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1106, 63);
            this.pnlTop.TabIndex = 0;
            // 
            // stStrip
            // 
            this.stStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pb1,
            this.stLbl});
            this.stStrip.Location = new System.Drawing.Point(0, 608);
            this.stStrip.Name = "stStrip";
            this.stStrip.Size = new System.Drawing.Size(1106, 22);
            this.stStrip.TabIndex = 1;
            this.stStrip.Text = "statusStrip1";
            // 
            // pb1
            // 
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(300, 16);
            // 
            // stLbl
            // 
            this.stLbl.Name = "stLbl";
            this.stLbl.Size = new System.Drawing.Size(16, 17);
            this.stLbl.Text = "...";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lvCadastral);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 63);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(292, 545);
            this.pnlLeft.TabIndex = 2;
            // 
            // lvCadastral
            // 
            this.lvCadastral.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cadastral,
            this.rr_checked,
            this.r3_checked});
            this.lvCadastral.ContextMenuStrip = this.cntMenuLV;
            this.lvCadastral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCadastral.Location = new System.Drawing.Point(0, 0);
            this.lvCadastral.Name = "lvCadastral";
            this.lvCadastral.ShowItemToolTips = true;
            this.lvCadastral.Size = new System.Drawing.Size(292, 545);
            this.lvCadastral.TabIndex = 0;
            this.lvCadastral.UseCompatibleStateImageBehavior = false;
            this.lvCadastral.View = System.Windows.Forms.View.Details;
            this.lvCadastral.SelectedIndexChanged += new System.EventHandler(this.lvCadastral_SelectedIndexChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlLog);
            this.pnlMain.Controls.Add(this.pnlDetails);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(292, 63);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(814, 545);
            this.pnlMain.TabIndex = 3;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1106, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "mnuMain";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportList,
            this.toolStripSeparator1,
            this.mnuSaveData,
            this.toolStripSeparator2,
            this.mnuExitApp});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // mnuImportList
            // 
            this.mnuImportList.Name = "mnuImportList";
            this.mnuImportList.Size = new System.Drawing.Size(159, 22);
            this.mnuImportList.Text = "Импорт списка";
            this.mnuImportList.Click += new System.EventHandler(this.mnuImportList_Click);
            // 
            // cadastral
            // 
            this.cadastral.Text = "КН";
            this.cadastral.Width = 150;
            // 
            // rr_checked
            // 
            this.rr_checked.Text = "ЗпрРР";
            this.rr_checked.Width = 50;
            // 
            // r3_checked
            // 
            this.r3_checked.Text = "ЗпрR3";
            // 
            // pnlDetails
            // 
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDetails.Controls.Add(this.lvDetails);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(814, 289);
            this.pnlDetails.TabIndex = 0;
            // 
            // pnlLog
            // 
            this.pnlLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(0, 289);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(814, 256);
            this.pnlLog.TabIndex = 1;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuExitApp
            // 
            this.mnuExitApp.Name = "mnuExitApp";
            this.mnuExitApp.Size = new System.Drawing.Size(159, 22);
            this.mnuExitApp.Text = "Выход";
            this.mnuExitApp.Click += new System.EventHandler(this.mnuExitApp_Click);
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.btnStartAll,
            this.btnExport});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1106, 39);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnStartAll
            // 
            this.btnStartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartAll.Image = ((System.Drawing.Image)(resources.GetObject("btnStartAll.Image")));
            this.btnStartAll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(36, 36);
            this.btnStartAll.Text = "Проверить все (Росреестр)";
            // 
            // lvDetails
            // 
            this.lvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDetails.Location = new System.Drawing.Point(0, 0);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(810, 285);
            this.lvDetails.TabIndex = 0;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuSaveData
            // 
            this.mnuSaveData.Name = "mnuSaveData";
            this.mnuSaveData.Size = new System.Drawing.Size(159, 22);
            this.mnuSaveData.Text = "Сохранить";
            this.mnuSaveData.Click += new System.EventHandler(this.mnuSaveData_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(36, 36);
            this.btnOpen.Text = "Открыть файл с данными";
            this.btnOpen.ToolTipText = "Открыть файл с данными";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(36, 36);
            this.btnExport.Text = "Экспорт данных в Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cntMenuLV
            // 
            this.cntMenuLV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGetInfoByCadastral});
            this.cntMenuLV.Name = "cntMenuLV";
            this.cntMenuLV.Size = new System.Drawing.Size(224, 48);
            // 
            // mnuGetInfoByCadastral
            // 
            this.mnuGetInfoByCadastral.Name = "mnuGetInfoByCadastral";
            this.mnuGetInfoByCadastral.Size = new System.Drawing.Size(223, 22);
            this.mnuGetInfoByCadastral.Text = "Информация с Росреестра";
            this.mnuGetInfoByCadastral.Click += new System.EventHandler(this.mnuGetInfoByCadastral_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 630);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.stStrip);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочные сведения Росреестра";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.stStrip.ResumeLayout(false);
            this.stStrip.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.cntMenuLV.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.StatusStrip stStrip;
        private System.Windows.Forms.ToolStripProgressBar pb1;
        private System.Windows.Forms.ToolStripStatusLabel stLbl;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListView lvCadastral;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuImportList;
        private System.Windows.Forms.ColumnHeader cadastral;
        private System.Windows.Forms.ColumnHeader rr_checked;
        private System.Windows.Forms.ColumnHeader r3_checked;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExitApp;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnStartAll;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ContextMenuStrip cntMenuLV;
        private System.Windows.Forms.ToolStripMenuItem mnuGetInfoByCadastral;
    }
}

