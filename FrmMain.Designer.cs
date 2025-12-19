namespace QLTinhHinhDichBenh
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtMaDP;
        private System.Windows.Forms.TextBox txtTenDP;
        private System.Windows.Forms.TextBox txtSoCa;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label lblMaDP;
        private System.Windows.Forms.Label lblTenDP;
        private System.Windows.Forms.Label lblSoCa;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuChucNang;
        private System.Windows.Forms.ToolStripMenuItem mnuSort;
        private System.Windows.Forms.ToolStripMenuItem mnuNguyCo;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuChucNang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNguyCo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtMaDP = new System.Windows.Forms.TextBox();
            this.txtTenDP = new System.Windows.Forms.TextBox();
            this.txtSoCa = new System.Windows.Forms.TextBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.lblMaDP = new System.Windows.Forms.Label();
            this.lblTenDP = new System.Windows.Forms.Label();
            this.lblSoCa = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuChucNang});
            this.mnuChucNang.Text = "Chức năng";
            this.mnuChucNang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuSort, this.mnuNguyCo, this.mnuReport});

            this.mnuSort.Text = "Sắp xếp theo số ca nhiễm";
            this.mnuSort.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuSort.Click += new System.EventHandler(this.mnuSort_Click);

            this.mnuNguyCo.Text = "Các địa phương nhóm nguy cơ";
            this.mnuNguyCo.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuNguyCo.Click += new System.EventHandler(this.mnuNguyCo_Click);

            this.mnuReport.Text = "Xuất báo cáo";
            this.mnuReport.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            this.mnuReport.Click += new System.EventHandler(this.mnuReport_Click);

            this.dgv.Location = new System.Drawing.Point(12, 40);
            this.dgv.Size = new System.Drawing.Size(560, 200);
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);

            this.lblMaDP.Text = "Mã địa phương";
            this.lblMaDP.Location = new System.Drawing.Point(12, 260);
            this.txtMaDP.Location = new System.Drawing.Point(135, 256);

            this.lblTenDP.Text = "Tên địa phương";
            this.lblTenDP.Location = new System.Drawing.Point(12, 292);
            this.txtTenDP.Location = new System.Drawing.Point(135, 288);

            this.lblSoCa.Text = "Số ca nhiễm mới";
            this.lblSoCa.Location = new System.Drawing.Point(12, 324);
            this.txtSoCa.Location = new System.Drawing.Point(135, 320);

            this.lblTrangThai.Text = "Trạng thái";
            this.lblTrangThai.Location = new System.Drawing.Point(12, 356);
            this.cboTrangThai.Location = new System.Drawing.Point(135, 352);

            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(135, 392);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.Location = new System.Drawing.Point(228, 392);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblMaDP);
            this.Controls.Add(this.txtMaDP);
            this.Controls.Add(this.lblTenDP);
            this.Controls.Add(this.txtTenDP);
            this.Controls.Add(this.lblSoCa);
            this.Controls.Add(this.txtSoCa);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);

            this.MainMenuStrip = this.menuStrip1;
            this.Text = "Quản lý tình hình dịch bệnh";
            this.ClientSize = new System.Drawing.Size(820, 500);
        }
    }
}
