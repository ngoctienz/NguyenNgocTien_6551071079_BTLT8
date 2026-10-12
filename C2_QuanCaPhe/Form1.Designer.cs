namespace C2_QuanCaPhe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dgvCellStyleRight = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvCellStyleCenter = new DataGridViewCellStyle();
            grbTimKiem = new GroupBox();
            btnTim = new Button();
            txtTenMonTim = new TextBox();
            lblTenMonTim = new Label();
            cboHinhThucTim = new ComboBox();
            lblHinhThucTim = new Label();
            cboSoBanTim = new ComboBox();
            lblSoBanTim = new Label();
            lblGachNgang = new Label();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            lblDanhSachHD = new Label();
            dgvHoaDon = new DataGridView();
            lblTongDoanhThu = new Label();
            btnHoaDonMoi = new Button();
            btnSuaHoaDon = new Button();
            btnXoaHoaDon = new Button();
            lblChiTietHDTieuDe = new Label();
            dtpNgayLap = new DateTimePicker();
            lblSoBan = new Label();
            cboSoBan = new ComboBox();
            radTienMat = new RadioButton();
            radChuyenKhoan = new RadioButton();
            lblGhiChu = new Label();
            txtGhiChu = new TextBox();
            lblChonMon = new Label();
            cboMon = new ComboBox();
            lblSL = new Label();
            nudSoLuong = new NumericUpDown();
            btnThemMon = new Button();
            dgvChiTiet = new DataGridView();
            lblTongCong = new Label();
            btnSuaSL = new Button();
            btnXoaMon = new Button();
            btnXemHoaDon = new Button();
            btnXuatPdf = new Button();
            btnIn = new Button();
            grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // grbTimKiem
            // 
            grbTimKiem.Controls.Add(btnTim);
            grbTimKiem.Controls.Add(txtTenMonTim);
            grbTimKiem.Controls.Add(lblTenMonTim);
            grbTimKiem.Controls.Add(cboHinhThucTim);
            grbTimKiem.Controls.Add(lblHinhThucTim);
            grbTimKiem.Controls.Add(cboSoBanTim);
            grbTimKiem.Controls.Add(lblSoBanTim);
            grbTimKiem.Controls.Add(lblGachNgang);
            grbTimKiem.Controls.Add(dtpDenNgay);
            grbTimKiem.Controls.Add(lblDenNgay);
            grbTimKiem.Controls.Add(dtpTuNgay);
            grbTimKiem.Controls.Add(lblTuNgay);
            grbTimKiem.Location = new Point(16, 8);
            grbTimKiem.Name = "grbTimKiem";
            grbTimKiem.Size = new Size(1068, 85);
            grbTimKiem.TabIndex = 0;
            grbTimKiem.TabStop = false;
            grbTimKiem.Text = "Tìm kiếm hóa đơn";
            // 
            // btnTim
            // 
            btnTim.Location = new Point(965, 40);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(90, 30);
            btnTim.TabIndex = 11;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // txtTenMonTim
            // 
            txtTenMonTim.Location = new Point(765, 42);
            txtTenMonTim.Name = "txtTenMonTim";
            txtTenMonTim.Size = new Size(185, 27);
            txtTenMonTim.TabIndex = 10;
            // 
            // lblTenMonTim
            // 
            lblTenMonTim.AutoSize = true;
            lblTenMonTim.Location = new Point(765, 20);
            lblTenMonTim.Name = "lblTenMonTim";
            lblTenMonTim.Size = new Size(68, 20);
            lblTenMonTim.TabIndex = 9;
            lblTenMonTim.Text = "Tên món";
            // 
            // cboHinhThucTim
            // 
            cboHinhThucTim.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHinhThucTim.FormattingEnabled = true;
            cboHinhThucTim.Location = new Point(585, 42);
            cboHinhThucTim.Name = "cboHinhThucTim";
            cboHinhThucTim.Size = new Size(160, 28);
            cboHinhThucTim.TabIndex = 8;
            // 
            // lblHinhThucTim
            // 
            lblHinhThucTim.AutoSize = true;
            lblHinhThucTim.Location = new Point(585, 20);
            lblHinhThucTim.Name = "lblHinhThucTim";
            lblHinhThucTim.Size = new Size(72, 20);
            lblHinhThucTim.TabIndex = 7;
            lblHinhThucTim.Text = "Hình thức";
            // 
            // cboSoBanTim
            // 
            cboSoBanTim.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSoBanTim.FormattingEnabled = true;
            cboSoBanTim.Location = new Point(410, 42);
            cboSoBanTim.Name = "cboSoBanTim";
            cboSoBanTim.Size = new Size(155, 28);
            cboSoBanTim.TabIndex = 6;
            // 
            // lblSoBanTim
            // 
            lblSoBanTim.AutoSize = true;
            lblSoBanTim.Location = new Point(410, 20);
            lblSoBanTim.Name = "lblSoBanTim";
            lblSoBanTim.Size = new Size(55, 20);
            lblSoBanTim.TabIndex = 5;
            lblSoBanTim.Text = "Số bàn";
            // 
            // lblGachNgang
            // 
            lblGachNgang.AutoSize = true;
            lblGachNgang.Location = new Point(185, 45);
            lblGachNgang.Name = "lblGachNgang";
            lblGachNgang.Size = new Size(15, 20);
            lblGachNgang.TabIndex = 4;
            lblGachNgang.Text = "-";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(210, 42);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(165, 27);
            dtpDenNgay.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(210, 20);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(72, 20);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(15, 42);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(160, 27);
            dtpTuNgay.TabIndex = 1;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(15, 20);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(62, 20);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày";
            // 
            // lblDanhSachHD
            // 
            lblDanhSachHD.AutoSize = true;
            lblDanhSachHD.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDanhSachHD.Location = new Point(16, 105);
            lblDanhSachHD.Name = "lblDanhSachHD";
            lblDanhSachHD.Size = new Size(137, 20);
            lblDanhSachHD.TabIndex = 1;
            lblDanhSachHD.Text = "Danh sách hóa đơn";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.BackgroundColor = SystemColors.ControlDark;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(16, 130);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 30;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(495, 365);
            dgvHoaDon.TabIndex = 2;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            // 
            // lblTongDoanhThu
            // 
            lblTongDoanhThu.AutoSize = true;
            lblTongDoanhThu.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongDoanhThu.Location = new Point(16, 510);
            lblTongDoanhThu.Name = "lblTongDoanhThu";
            lblTongDoanhThu.Size = new Size(410, 31);
            lblTongDoanhThu.TabIndex = 3;
            lblTongDoanhThu.Text = "Tổng doanh thu đang hiển thị: 0 đ";
            // 
            // btnHoaDonMoi
            // 
            btnHoaDonMoi.Location = new Point(16, 558);
            btnHoaDonMoi.Name = "btnHoaDonMoi";
            btnHoaDonMoi.Size = new Size(110, 34);
            btnHoaDonMoi.TabIndex = 4;
            btnHoaDonMoi.Text = "Hóa đơn mới";
            btnHoaDonMoi.UseVisualStyleBackColor = true;
            btnHoaDonMoi.Click += btnHoaDonMoi_Click;
            // 
            // btnSuaHoaDon
            // 
            btnSuaHoaDon.Location = new Point(135, 558);
            btnSuaHoaDon.Name = "btnSuaHoaDon";
            btnSuaHoaDon.Size = new Size(110, 34);
            btnSuaHoaDon.TabIndex = 5;
            btnSuaHoaDon.Text = "Sửa hóa đơn";
            btnSuaHoaDon.UseVisualStyleBackColor = true;
            btnSuaHoaDon.Click += btnSuaHoaDon_Click;
            // 
            // btnXoaHoaDon
            // 
            btnXoaHoaDon.Location = new Point(255, 558);
            btnXoaHoaDon.Name = "btnXoaHoaDon";
            btnXoaHoaDon.Size = new Size(110, 34);
            btnXoaHoaDon.TabIndex = 6;
            btnXoaHoaDon.Text = "Xóa hóa đơn";
            btnXoaHoaDon.UseVisualStyleBackColor = true;
            btnXoaHoaDon.Click += btnXoaHoaDon_Click;
            // 
            // lblChiTietHDTieuDe
            // 
            lblChiTietHDTieuDe.AutoSize = true;
            lblChiTietHDTieuDe.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblChiTietHDTieuDe.Location = new Point(535, 105);
            lblChiTietHDTieuDe.Name = "lblChiTietHDTieuDe";
            lblChiTietHDTieuDe.Size = new Size(115, 20);
            lblChiTietHDTieuDe.TabIndex = 7;
            lblChiTietHDTieuDe.Text = "Chi tiết hóa đơn";
            // 
            // dtpNgayLap
            // 
            dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.Location = new Point(535, 130);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(170, 27);
            dtpNgayLap.TabIndex = 8;
            // 
            // lblSoBan
            // 
            lblSoBan.AutoSize = true;
            lblSoBan.Location = new Point(718, 133);
            lblSoBan.Name = "lblSoBan";
            lblSoBan.Size = new Size(58, 20);
            lblSoBan.TabIndex = 9;
            lblSoBan.Text = "Số bàn:";
            // 
            // cboSoBan
            // 
            cboSoBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSoBan.FormattingEnabled = true;
            cboSoBan.Location = new Point(780, 130);
            cboSoBan.Name = "cboSoBan";
            cboSoBan.Size = new Size(65, 28);
            cboSoBan.TabIndex = 10;
            // 
            // radTienMat
            // 
            radTienMat.AutoSize = true;
            radTienMat.Checked = true;
            radTienMat.Location = new Point(860, 131);
            radTienMat.Name = "radTienMat";
            radTienMat.Size = new Size(88, 24);
            radTienMat.TabIndex = 11;
            radTienMat.TabStop = true;
            radTienMat.Text = "Tiền mặt";
            radTienMat.UseVisualStyleBackColor = true;
            // 
            // radChuyenKhoan
            // 
            radChuyenKhoan.AutoSize = true;
            radChuyenKhoan.Location = new Point(955, 131);
            radChuyenKhoan.Name = "radChuyenKhoan";
            radChuyenKhoan.Size = new Size(123, 24);
            radChuyenKhoan.TabIndex = 12;
            radChuyenKhoan.Text = "Chuyển khoản";
            radChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(535, 168);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(61, 20);
            lblGhiChu.TabIndex = 13;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(620, 168);
            txtGhiChu.Multiline = true;
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.ScrollBars = ScrollBars.Vertical;
            txtGhiChu.Size = new Size(464, 55);
            txtGhiChu.TabIndex = 14;
            // 
            // lblChonMon
            // 
            lblChonMon.AutoSize = true;
            lblChonMon.Location = new Point(535, 235);
            lblChonMon.Name = "lblChonMon";
            lblChonMon.Size = new Size(80, 20);
            lblChonMon.TabIndex = 15;
            lblChonMon.Text = "Chọn món:";
            // 
            // cboMon
            // 
            cboMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMon.FormattingEnabled = true;
            cboMon.Location = new Point(620, 232);
            cboMon.Name = "cboMon";
            cboMon.Size = new Size(220, 28);
            cboMon.TabIndex = 16;
            // 
            // lblSL
            // 
            lblSL.AutoSize = true;
            lblSL.Location = new Point(850, 235);
            lblSL.Name = "lblSL";
            lblSL.Size = new Size(28, 20);
            lblSL.TabIndex = 17;
            lblSL.Text = "SL:";
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(885, 233);
            nudSoLuong.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(60, 27);
            nudSoLuong.TabIndex = 18;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemMon
            // 
            btnThemMon.Location = new Point(965, 230);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(95, 32);
            btnThemMon.TabIndex = 19;
            btnThemMon.Text = "Thêm món";
            btnThemMon.UseVisualStyleBackColor = true;
            btnThemMon.Click += btnThemMon_Click;
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.BackgroundColor = SystemColors.ControlDark;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Location = new Point(535, 272);
            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 30;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(549, 223);
            dgvChiTiet.TabIndex = 20;
            dgvChiTiet.SelectionChanged += dgvChiTiet_SelectionChanged;
            // 
            // lblTongCong
            // 
            lblTongCong.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongCong.Location = new Point(620, 505);
            lblTongCong.Name = "lblTongCong";
            lblTongCong.Size = new Size(464, 38);
            lblTongCong.TabIndex = 21;
            lblTongCong.Text = "Tổng cộng: 0 đ";
            lblTongCong.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSuaSL
            // 
            btnSuaSL.Location = new Point(405, 558);
            btnSuaSL.Name = "btnSuaSL";
            btnSuaSL.Size = new Size(110, 34);
            btnSuaSL.TabIndex = 22;
            btnSuaSL.Text = "Sửa SL";
            btnSuaSL.UseVisualStyleBackColor = true;
            btnSuaSL.Click += btnSuaSL_Click;
            // 
            // btnXoaMon
            // 
            btnXoaMon.Location = new Point(535, 558);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.Size = new Size(110, 34);
            btnXoaMon.TabIndex = 23;
            btnXoaMon.Text = "Xóa món";
            btnXoaMon.UseVisualStyleBackColor = true;
            btnXoaMon.Click += btnXoaMon_Click;
            // 
            // btnXemHoaDon
            // 
            btnXemHoaDon.Location = new Point(695, 558);
            btnXemHoaDon.Name = "btnXemHoaDon";
            btnXemHoaDon.Size = new Size(125, 34);
            btnXemHoaDon.TabIndex = 24;
            btnXemHoaDon.Text = "Xem hóa đơn";
            btnXemHoaDon.UseVisualStyleBackColor = true;
            btnXemHoaDon.Click += btnXemHoaDon_Click;
            // 
            // btnXuatPdf
            // 
            btnXuatPdf.Location = new Point(835, 558);
            btnXuatPdf.Name = "btnXuatPdf";
            btnXuatPdf.Size = new Size(115, 34);
            btnXuatPdf.TabIndex = 25;
            btnXuatPdf.Text = "Xuất PDF";
            btnXuatPdf.UseVisualStyleBackColor = true;
            btnXuatPdf.Click += btnXuatPdf_Click;
            // 
            // btnIn
            // 
            btnIn.Location = new Point(965, 558);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(95, 34);
            btnIn.TabIndex = 26;
            btnIn.Text = "In";
            btnIn.UseVisualStyleBackColor = true;
            btnIn.Click += btnIn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 612);
            Controls.Add(btnIn);
            Controls.Add(btnXuatPdf);
            Controls.Add(btnXemHoaDon);
            Controls.Add(btnXoaMon);
            Controls.Add(btnSuaSL);
            Controls.Add(lblTongCong);
            Controls.Add(dgvChiTiet);
            Controls.Add(btnThemMon);
            Controls.Add(nudSoLuong);
            Controls.Add(lblSL);
            Controls.Add(cboMon);
            Controls.Add(lblChonMon);
            Controls.Add(txtGhiChu);
            Controls.Add(lblGhiChu);
            Controls.Add(radChuyenKhoan);
            Controls.Add(radTienMat);
            Controls.Add(cboSoBan);
            Controls.Add(lblSoBan);
            Controls.Add(dtpNgayLap);
            Controls.Add(lblChiTietHDTieuDe);
            Controls.Add(btnXoaHoaDon);
            Controls.Add(btnSuaHoaDon);
            Controls.Add(btnHoaDonMoi);
            Controls.Add(lblTongDoanhThu);
            Controls.Add(dgvHoaDon);
            Controls.Add(lblDanhSachHD);
            Controls.Add(grbTimKiem);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quán cà phê Góc Phố - Quản lý hóa đơn";
            Load += Form1_Load;
            grbTimKiem.ResumeLayout(false);
            grbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grbTimKiem;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblGachNgang;
        private Label lblSoBanTim;
        private ComboBox cboSoBanTim;
        private Label lblHinhThucTim;
        private ComboBox cboHinhThucTim;
        private Label lblTenMonTim;
        private TextBox txtTenMonTim;
        private Button btnTim;
        private Label lblDanhSachHD;
        private DataGridView dgvHoaDon;
        private Label lblTongDoanhThu;
        private Button btnHoaDonMoi;
        private Button btnSuaHoaDon;
        private Button btnXoaHoaDon;
        private Label lblChiTietHDTieuDe;
        private DateTimePicker dtpNgayLap;
        private Label lblSoBan;
        private ComboBox cboSoBan;
        private RadioButton radTienMat;
        private RadioButton radChuyenKhoan;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Label lblChonMon;
        private ComboBox cboMon;
        private Label lblSL;
        private NumericUpDown nudSoLuong;
        private Button btnThemMon;
        private DataGridView dgvChiTiet;
        private Label lblTongCong;
        private Button btnSuaSL;
        private Button btnXoaMon;
        private Button btnXemHoaDon;
        private Button btnXuatPdf;
        private Button btnIn;
    }
}
