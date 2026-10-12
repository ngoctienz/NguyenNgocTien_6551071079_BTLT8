namespace C1_TiemTapHoa
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
            grbThongTin = new GroupBox();
            chkConKinhDoanh = new CheckBox();
            dtpNgayNhap = new DateTimePicker();
            nudSoLuongTon = new NumericUpDown();
            cboDonVi = new ComboBox();
            cboLoaiHang = new ComboBox();
            nudGiaBan = new NumericUpDown();
            txtTenHang = new TextBox();
            lblNgayNhap = new Label();
            lblSLTon = new Label();
            lblGiaBan = new Label();
            lblDonVi = new Label();
            lblLoaiHang = new Label();
            lblTenHang = new Label();
            grbTimKiem = new GroupBox();
            chkChiHienCKD = new CheckBox();
            cboLocLoaiHang = new ComboBox();
            txtTimKiem = new TextBox();
            dgvHangHoa = new DataGridView();
            statusStrip1 = new StatusStrip();
            tstlTimThay = new ToolStripStatusLabel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnXemBangGia = new Button();
            btnXuatPdf = new Button();
            btnXuatExcelLuoi = new Button();
            btnXuatExcelTonKho = new Button();
            grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).BeginInit();
            grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grbThongTin
            // 
            grbThongTin.Controls.Add(chkConKinhDoanh);
            grbThongTin.Controls.Add(dtpNgayNhap);
            grbThongTin.Controls.Add(nudSoLuongTon);
            grbThongTin.Controls.Add(cboDonVi);
            grbThongTin.Controls.Add(cboLoaiHang);
            grbThongTin.Controls.Add(nudGiaBan);
            grbThongTin.Controls.Add(txtTenHang);
            grbThongTin.Controls.Add(lblNgayNhap);
            grbThongTin.Controls.Add(lblSLTon);
            grbThongTin.Controls.Add(lblGiaBan);
            grbThongTin.Controls.Add(lblDonVi);
            grbThongTin.Controls.Add(lblLoaiHang);
            grbThongTin.Controls.Add(lblTenHang);
            grbThongTin.Location = new Point(18, 12);
            grbThongTin.Name = "grbThongTin";
            grbThongTin.Size = new Size(600, 192);
            grbThongTin.TabIndex = 0;
            grbThongTin.TabStop = false;
            grbThongTin.Text = "Thông tin hàng hóa";
            // 
            // chkConKinhDoanh
            // 
            chkConKinhDoanh.AutoSize = true;
            chkConKinhDoanh.Checked = true;
            chkConKinhDoanh.CheckState = CheckState.Checked;
            chkConKinhDoanh.Location = new Point(402, 148);
            chkConKinhDoanh.Name = "chkConKinhDoanh";
            chkConKinhDoanh.Size = new Size(134, 24);
            chkConKinhDoanh.TabIndex = 6;
            chkConKinhDoanh.Text = "Còn kinh doanh";
            chkConKinhDoanh.UseVisualStyleBackColor = true;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(402, 105);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(180, 27);
            dtpNgayNhap.TabIndex = 4;
            // 
            // nudSoLuongTon
            // 
            nudSoLuongTon.Location = new Point(402, 65);
            nudSoLuongTon.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudSoLuongTon.Name = "nudSoLuongTon";
            nudSoLuongTon.Size = new Size(180, 27);
            nudSoLuongTon.TabIndex = 2;
            // 
            // cboDonVi
            // 
            cboDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDonVi.FormattingEnabled = true;
            cboDonVi.Location = new Point(96, 105);
            cboDonVi.Name = "cboDonVi";
            cboDonVi.Size = new Size(180, 28);
            cboDonVi.TabIndex = 3;
            // 
            // cboLoaiHang
            // 
            cboLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiHang.FormattingEnabled = true;
            cboLoaiHang.Location = new Point(96, 65);
            cboLoaiHang.Name = "cboLoaiHang";
            cboLoaiHang.Size = new Size(180, 28);
            cboLoaiHang.TabIndex = 1;
            // 
            // nudGiaBan
            // 
            nudGiaBan.Location = new Point(96, 145);
            nudGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudGiaBan.Name = "nudGiaBan";
            nudGiaBan.Size = new Size(180, 27);
            nudGiaBan.TabIndex = 5;
            nudGiaBan.ThousandsSeparator = true;
            nudGiaBan.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // txtTenHang
            // 
            txtTenHang.Location = new Point(96, 27);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(486, 27);
            txtTenHang.TabIndex = 0;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Location = new Point(296, 108);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(84, 20);
            lblNgayNhap.TabIndex = 5;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // lblSLTon
            // 
            lblSLTon.AutoSize = true;
            lblSLTon.Location = new Point(296, 68);
            lblSLTon.Name = "lblSLTon";
            lblSLTon.Size = new Size(98, 20);
            lblSLTon.TabIndex = 4;
            lblSLTon.Text = "Số lượng tồn:";
            // 
            // lblGiaBan
            // 
            lblGiaBan.AutoSize = true;
            lblGiaBan.Location = new Point(18, 148);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(63, 20);
            lblGiaBan.TabIndex = 3;
            lblGiaBan.Text = "Giá bán:";
            // 
            // lblDonVi
            // 
            lblDonVi.AutoSize = true;
            lblDonVi.Location = new Point(18, 108);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new Size(55, 20);
            lblDonVi.TabIndex = 2;
            lblDonVi.Text = "Đơn vị:";
            // 
            // lblLoaiHang
            // 
            lblLoaiHang.AutoSize = true;
            lblLoaiHang.Location = new Point(18, 68);
            lblLoaiHang.Name = "lblLoaiHang";
            lblLoaiHang.Size = new Size(77, 20);
            lblLoaiHang.TabIndex = 1;
            lblLoaiHang.Text = "Loại hàng:";
            // 
            // lblTenHang
            // 
            lblTenHang.AutoSize = true;
            lblTenHang.Location = new Point(18, 30);
            lblTenHang.Name = "lblTenHang";
            lblTenHang.Size = new Size(72, 20);
            lblTenHang.TabIndex = 0;
            lblTenHang.Text = "Tên hàng:";
            // 
            // grbTimKiem
            // 
            grbTimKiem.Controls.Add(chkChiHienCKD);
            grbTimKiem.Controls.Add(cboLocLoaiHang);
            grbTimKiem.Controls.Add(txtTimKiem);
            grbTimKiem.Location = new Point(630, 12);
            grbTimKiem.Name = "grbTimKiem";
            grbTimKiem.Size = new Size(392, 192);
            grbTimKiem.TabIndex = 1;
            grbTimKiem.TabStop = false;
            grbTimKiem.Text = "Tìm kiếm";
            // 
            // chkChiHienCKD
            // 
            chkChiHienCKD.AutoSize = true;
            chkChiHienCKD.Location = new Point(16, 110);
            chkChiHienCKD.Name = "chkChiHienCKD";
            chkChiHienCKD.Size = new Size(226, 24);
            chkChiHienCKD.TabIndex = 2;
            chkChiHienCKD.Text = "Chỉ hiện hàng còn kinh doanh";
            chkChiHienCKD.UseVisualStyleBackColor = true;
            // 
            // cboLocLoaiHang
            // 
            cboLocLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLoaiHang.FormattingEnabled = true;
            cboLocLoaiHang.Location = new Point(16, 65);
            cboLocLoaiHang.Name = "cboLocLoaiHang";
            cboLocLoaiHang.Size = new Size(360, 28);
            cboLocLoaiHang.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(16, 27);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(360, 27);
            txtTimKiem.TabIndex = 0;
            // 
            // dgvHangHoa
            // 
            dgvHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangHoa.Location = new Point(18, 218);
            dgvHangHoa.Name = "dgvHangHoa";
            dgvHangHoa.RowHeadersWidth = 51;
            dgvHangHoa.Size = new Size(1004, 255);
            dgvHangHoa.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tstlTimThay });
            statusStrip1.Location = new Point(0, 534);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1040, 26);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // tstlTimThay
            // 
            tstlTimThay.Name = "tstlTimThay";
            tstlTimThay.Size = new Size(145, 20);
            tstlTimThay.Text = "Tìm thấy 0 mặt hàng";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(18, 485);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 32);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(118, 485);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 32);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(218, 485);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 32);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(318, 485);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(95, 32);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnXemBangGia
            // 
            btnXemBangGia.Location = new Point(497, 485);
            btnXemBangGia.Name = "btnXemBangGia";
            btnXemBangGia.Size = new Size(115, 32);
            btnXemBangGia.TabIndex = 7;
            btnXemBangGia.Text = "Xem bảng giá";
            btnXemBangGia.UseVisualStyleBackColor = true;
            // 
            // btnXuatPdf
            // 
            btnXuatPdf.Location = new Point(622, 485);
            btnXuatPdf.Name = "btnXuatPdf";
            btnXuatPdf.Size = new Size(95, 32);
            btnXuatPdf.TabIndex = 8;
            btnXuatPdf.Text = "Xuất PDF";
            btnXuatPdf.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcelLuoi
            // 
            btnXuatExcelLuoi.Location = new Point(727, 485);
            btnXuatExcelLuoi.Name = "btnXuatExcelLuoi";
            btnXuatExcelLuoi.Size = new Size(135, 32);
            btnXuatExcelLuoi.TabIndex = 9;
            btnXuatExcelLuoi.Text = "Xuất Excel (lưới)";
            btnXuatExcelLuoi.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcelTonKho
            // 
            btnXuatExcelTonKho.Location = new Point(872, 485);
            btnXuatExcelTonKho.Name = "btnXuatExcelTonKho";
            btnXuatExcelTonKho.Size = new Size(150, 32);
            btnXuatExcelTonKho.TabIndex = 10;
            btnXuatExcelTonKho.Text = "Xuất Excel tồn kho";
            btnXuatExcelTonKho.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 560);
            Controls.Add(btnXuatExcelTonKho);
            Controls.Add(btnXuatExcelLuoi);
            Controls.Add(btnXuatPdf);
            Controls.Add(btnXemBangGia);
            Controls.Add(btnLamMoi);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(statusStrip1);
            Controls.Add(dgvHangHoa);
            Controls.Add(grbTimKiem);
            Controls.Add(grbThongTin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hàng hóa - Tạp hóa UTC2";
            Load += Form1_Load;
            grbThongTin.ResumeLayout(false);
            grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoLuongTon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGiaBan).EndInit();
            grbTimKiem.ResumeLayout(false);
            grbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHangHoa).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grbThongTin;
        private Label lblSLTon;
        private Label lblGiaBan;
        private Label lblDonVi;
        private Label lblLoaiHang;
        private Label lblTenHang;
        private GroupBox grbTimKiem;
        private TextBox txtTenHang;
        private Label lblNgayNhap;
        private DateTimePicker dtpNgayNhap;
        private NumericUpDown nudSoLuongTon;
        private ComboBox cboDonVi;
        private ComboBox cboLoaiHang;
        private NumericUpDown nudGiaBan;
        private TextBox txtTimKiem;
        private ComboBox cboLocLoaiHang;
        private CheckBox chkConKinhDoanh;
        private CheckBox chkChiHienCKD;
        private DataGridView dgvHangHoa;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tstlTimThay;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnXemBangGia;
        private Button btnXuatPdf;
        private Button btnXuatExcelLuoi;
        private Button btnXuatExcelTonKho;
    }
}
