using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ClosedXML.Excel;
using FastReport;
using FastReport.Export.Pdf;
using C1_TiemTapHoa.Models;

namespace C1_TiemTapHoa
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bds = new();
        private readonly System.Windows.Forms.Timer _timerTimKiem = new() { Interval = 350 };
        private int? _currentMaHang = null;

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupEvents();
        }

        private void SetupDataGridView()
        {
            dgvHangHoa.AutoGenerateColumns = false;
            dgvHangHoa.Columns.Clear();
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaHang",
                HeaderText = "Mã hàng",
                DataPropertyName = "MaHang",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenHang",
                HeaderText = "Tên hàng",
                DataPropertyName = "TenHang",
                Width = 230
            });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLoaiHang",
                HeaderText = "Loại hàng",
                DataPropertyName = "LoaiHang",
                Width = 120
            });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDonVi",
                HeaderText = "Đơn vị",
                DataPropertyName = "DonVi",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGiaBan",
                HeaderText = "Giá bán",
                DataPropertyName = "GiaBan",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoLuongTon",
                HeaderText = "Số lượng tồn",
                DataPropertyName = "SoLuongTon",
                Width = 115,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });
            dgvHangHoa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayNhap",
                HeaderText = "Ngày nhập",
                DataPropertyName = "NgayNhap",
                Width = 115,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "dd/MM/yyyy"
                }
            });
            dgvHangHoa.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colConKinhDoanh",
                HeaderText = "Kinh doanh",
                DataPropertyName = "ConKinhDoanh",
                Width = 95
            });

            dgvHangHoa.ReadOnly = true;
            dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.MultiSelect = false;
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.DataSource = _bds;
        }

        private void SetupEvents()
        {
            _timerTimKiem.Tick += async (s, e) =>
            {
                _timerTimKiem.Stop();
                await LoadDataAsync();
            };

            txtTimKiem.TextChanged += (s, e) =>
            {
                _timerTimKiem.Stop();
                _timerTimKiem.Start();
            };

            cboLocLoaiHang.SelectedIndexChanged += async (s, e) => await LoadDataAsync();
            chkChiHienCKD.CheckedChanged += async (s, e) => await LoadDataAsync();

            dgvHangHoa.SelectionChanged += dgvHangHoa_SelectionChanged;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnXemBangGia.Click += btnXemBangGia_Click;
            btnXuatPdf.Click += btnXuatPdf_Click;
            btnXuatExcelLuoi.Click += btnXuatExcelLuoi_Click;
            btnXuatExcelTonKho.Click += btnXuatExcelTonKho_Click;
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            try
            {
                InitControls();
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động ứng dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitControls()
        {
            cboLoaiHang.Items.Clear();
            cboLoaiHang.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
            cboLoaiHang.SelectedIndex = 0;

            cboDonVi.Items.Clear();
            cboDonVi.Items.AddRange(new object[] { "Chai", "Gói", "Hộp", "Túi" });
            cboDonVi.SelectedIndex = 0;

            cboLocLoaiHang.Items.Clear();
            cboLocLoaiHang.Items.AddRange(new object[] { "Tất cả", "Đồ uống", "Thực phẩm khô", "Gia vị", "Đồ gia dụng" });
            cboLocLoaiHang.SelectedIndex = 0;

            nudGiaBan.Increment = 500;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
        }

        private async Task LoadDataAsync(int? selectMaHang = null)
        {
            try
            {
                using var db = new TiemTapHoaContext();
                var query = db.HangHoas.AsQueryable();

                string tuKhoa = txtTimKiem.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(h => h.TenHang != null && h.TenHang.ToLower().Contains(tuKhoa));
                }

                if (cboLocLoaiHang.SelectedIndex > 0 && cboLocLoaiHang.SelectedItem != null)
                {
                    string loai = cboLocLoaiHang.SelectedItem.ToString() ?? "";
                    query = query.Where(h => h.LoaiHang == loai);
                }

                if (chkChiHienCKD.Checked)
                {
                    query = query.Where(h => h.ConKinhDoanh == true);
                }

                var list = await query.OrderBy(h => h.MaHang).ToListAsync();
                _bds.DataSource = list;
                _bds.ResetBindings(false);

                tstlTimThay.Text = $"Tìm thấy {list.Count} mặt hàng";

                if (list.Count > 0)
                {
                    int index = 0;
                    if (selectMaHang.HasValue)
                    {
                        int found = list.FindIndex(h => h.MaHang == selectMaHang.Value);
                        if (found >= 0) index = found;
                    }

                    if (dgvHangHoa.Rows.Count > index)
                    {
                        dgvHangHoa.ClearSelection();
                        dgvHangHoa.Rows[index].Selected = true;
                        HienThiChiTiet(list[index]);
                    }
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiChiTiet(HangHoa hh)
        {
            _currentMaHang = hh.MaHang;
            txtTenHang.Text = hh.TenHang ?? "";

            if (!string.IsNullOrEmpty(hh.LoaiHang))
            {
                int idx = cboLoaiHang.FindStringExact(hh.LoaiHang);
                if (idx >= 0) cboLoaiHang.SelectedIndex = idx;
            }

            if (!string.IsNullOrEmpty(hh.DonVi))
            {
                int idx = cboDonVi.FindStringExact(hh.DonVi);
                if (idx >= 0) cboDonVi.SelectedIndex = idx;
            }

            nudGiaBan.Value = hh.GiaBan ?? 0;
            nudSoLuongTon.Value = hh.SoLuongTon ?? 0;
            dtpNgayNhap.Value = hh.NgayNhap ?? DateTime.Now;
            chkConKinhDoanh.Checked = (hh.ConKinhDoanh == true);
        }

        private void ClearInputs()
        {
            _currentMaHang = null;
            txtTenHang.Text = string.Empty;
            if (cboLoaiHang.Items.Count > 0) cboLoaiHang.SelectedIndex = 0;
            if (cboDonVi.Items.Count > 0) cboDonVi.SelectedIndex = 0;
            nudGiaBan.Value = 0;
            nudSoLuongTon.Value = 0;
            dtpNgayNhap.Value = DateTime.Now;
            chkConKinhDoanh.Checked = true;
        }

        private void dgvHangHoa_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvHangHoa.SelectedRows.Count > 0)
            {
                var row = dgvHangHoa.SelectedRows[0];
                if (row.DataBoundItem is HangHoa hh)
                {
                    HienThiChiTiet(hh);
                }
            }
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenHang.Text))
                {
                    MessageBox.Show("Tên hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenHang.Focus();
                    return;
                }

                if (nudGiaBan.Value <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudGiaBan.Focus();
                    return;
                }

                var hh = new HangHoa
                {
                    TenHang = txtTenHang.Text.Trim(),
                    LoaiHang = cboLoaiHang.SelectedItem?.ToString() ?? "",
                    DonVi = cboDonVi.SelectedItem?.ToString() ?? "",
                    GiaBan = nudGiaBan.Value,
                    SoLuongTon = (int)nudSoLuongTon.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    ConKinhDoanh = chkConKinhDoanh.Checked
                };

                using var db = new TiemTapHoaContext();
                db.HangHoas.Add(hh);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm hàng hóa mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(hh.MaHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!_currentMaHang.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn một hàng hóa để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenHang.Text))
                {
                    MessageBox.Show("Tên hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenHang.Focus();
                    return;
                }

                if (nudGiaBan.Value <= 0)
                {
                    MessageBox.Show("Giá bán phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudGiaBan.Focus();
                    return;
                }

                using var db = new TiemTapHoaContext();
                var hh = await db.HangHoas.FindAsync(_currentMaHang.Value);
                if (hh == null)
                {
                    MessageBox.Show("Không tìm thấy hàng hóa cần sửa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hh.TenHang = txtTenHang.Text.Trim();
                hh.LoaiHang = cboLoaiHang.SelectedItem?.ToString() ?? "";
                hh.DonVi = cboDonVi.SelectedItem?.ToString() ?? "";
                hh.GiaBan = nudGiaBan.Value;
                hh.SoLuongTon = (int)nudSoLuongTon.Value;
                hh.NgayNhap = dtpNgayNhap.Value;
                hh.ConKinhDoanh = chkConKinhDoanh.Checked;

                await db.SaveChangesAsync();
                MessageBox.Show("Cập nhật thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync(hh.MaHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!_currentMaHang.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn một hàng hóa để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hàng hóa '{txtTenHang.Text}' không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                using var db = new TiemTapHoaContext();
                var hh = await db.HangHoas.FindAsync(_currentMaHang.Value);
                if (hh != null)
                {
                    db.HangHoas.Remove(hh);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hàng hóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            ClearInputs();
            txtTimKiem.Text = string.Empty;
            cboLocLoaiHang.SelectedIndex = 0;
            chkChiHienCKD.Checked = false;
            await LoadDataAsync();
        }

        private async Task<(Report report, DataTable dt)?> PrepareReportBangGiaAsync()
        {
            using var db = new TiemTapHoaContext();
            var data = await db.HangHoas.Where(h => h.ConKinhDoanh == true).OrderBy(h => h.MaHang).ToListAsync();

            if (data.Count == 0)
            {
                MessageBox.Show("Không có mặt hàng nào đang kinh doanh để in bảng giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "BangGia.frx");
            if (!File.Exists(reportPath))
            {
                reportPath = Path.Combine(Application.StartupPath, "Reports", "BangGia.frx");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file mẫu report tại: {reportPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            var dt = new DataTable("HangHoa");
            dt.Columns.Add("MaHang", typeof(int));
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("DonVi", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));

            foreach (var item in data)
            {
                dt.Rows.Add(item.MaHang, item.TenHang ?? "", item.DonVi ?? "", item.GiaBan ?? 0);
            }

            var report = new Report();
            report.Load(reportPath);
            report.RegisterData(dt, "HangHoa");
            var ds = report.GetDataSource("HangHoa");
            if (ds != null) ds.Enabled = true;

            report.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
            return (report, dt);
        }

        private async void btnXemBangGia_Click(object? sender, EventArgs e)
        {
            try
            {
                var prep = await PrepareReportBangGiaAsync();
                if (prep == null) return;
                using var report = prep.Value.report;
                report.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem bảng giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXuatPdf_Click(object? sender, EventArgs e)
        {
            try
            {
                var prep = await PrepareReportBangGiaAsync();
                if (prep == null) return;
                using var report = prep.Value.report;

                using var sfd = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = "BangGia_TapHoaUTC2.pdf",
                    Title = "Chọn nơi lưu file Bảng giá PDF"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    report.Prepare();
                    using var pdfExport = new PDFExport();
                    report.Export(pdfExport, sfd.FileName);

                    var res = MessageBox.Show("Xuất file PDF thành công! Bạn có muốn mở file không?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcelLuoi_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvHangHoa.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "DanhSachHangHoa.xlsx",
                    Title = "Chọn nơi lưu file Excel"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("HangHoa");

                string[] headers = { "Mã hàng", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Ngày nhập", "Kinh doanh" };
                for (int col = 0; col < headers.Length; col++)
                {
                    var cell = ws.Cell(1, col + 1);
                    cell.Value = headers[col];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(235, 235, 235);
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                int row = 2;
                foreach (DataGridViewRow dgvRow in dgvHangHoa.Rows)
                {
                    if (dgvRow.DataBoundItem is HangHoa hh)
                    {
                        ws.Cell(row, 1).Value = hh.MaHang;
                        ws.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(row, 2).Value = hh.TenHang ?? "";

                        ws.Cell(row, 3).Value = hh.LoaiHang ?? "";

                        ws.Cell(row, 4).Value = hh.DonVi ?? "";
                        ws.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(row, 5).Value = hh.GiaBan ?? 0;
                        ws.Cell(row, 5).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        ws.Cell(row, 6).Value = hh.SoLuongTon ?? 0;
                        ws.Cell(row, 6).Style.NumberFormat.Format = "#,##0";
                        ws.Cell(row, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                        ws.Cell(row, 7).Value = hh.NgayNhap.HasValue ? hh.NgayNhap.Value.ToString("dd/MM/yyyy") : "";
                        ws.Cell(row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(row, 8).Value = (hh.ConKinhDoanh == true) ? "Còn bán" : "Ngừng bán";
                        ws.Cell(row, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        row++;
                    }
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                var res = MessageBox.Show("Xuất file Excel thành công! Bạn có muốn mở file không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File Excel đang được mở bởi một chương trình khác. Vui lòng đóng file rồi thử lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel từ lưới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXuatExcelTonKho_Click(object? sender, EventArgs e)
        {
            try
            {
                using var db = new TiemTapHoaContext();
                var data = await db.HangHoas.Where(h => h.ConKinhDoanh == true).OrderBy(h => h.MaHang).ToListAsync();

                if (data.Count == 0)
                {
                    MessageBox.Show("Không có mặt hàng còn kinh doanh nào để xuất tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "BaoCaoTonKho.xlsx",
                    Title = "Chọn nơi lưu file Báo cáo tồn kho"
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;

                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("TonKho");

                string[] headers = { "STT", "Tên hàng", "Loại hàng", "Đơn vị", "Giá bán", "Số lượng tồn", "Giá trị tồn" };
                for (int col = 0; col < headers.Length; col++)
                {
                    var cell = ws.Cell(1, col + 1);
                    cell.Value = headers[col];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.FromArgb(235, 235, 235);
                }

                ws.Range(1, 1, 1, 7).SetAutoFilter();
                ws.SheetView.FreezeRows(1);

                int row = 2;
                for (int i = 0; i < data.Count; i++)
                {
                    var hh = data[i];
                    ws.Cell(row, 1).Value = i + 1;
                    ws.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Cell(row, 2).Value = hh.TenHang ?? "";

                    ws.Cell(row, 3).Value = hh.LoaiHang ?? "";

                    ws.Cell(row, 4).Value = hh.DonVi ?? "";
                    ws.Cell(row, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Cell(row, 5).Value = hh.GiaBan ?? 0;
                    ws.Cell(row, 5).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    ws.Cell(row, 6).Value = hh.SoLuongTon ?? 0;
                    ws.Cell(row, 6).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    // Công thức Giá trị tồn = Giá bán * Số lượng tồn (cột E * cột F)
                    ws.Cell(row, 7).FormulaA1 = $"=E{row}*F{row}";
                    ws.Cell(row, 7).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    row++;
                }

                // Dòng "Tổng"
                ws.Cell(row, 1).Value = "Tổng";
                ws.Cell(row, 1).Style.Font.Bold = true;
                ws.Range(row, 1, row, 6).Merge();
                ws.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                // Công thức SUM cho cột Giá trị tồn (cột G)
                ws.Cell(row, 7).FormulaA1 = $"=SUM(G2:G{row - 1})";
                ws.Cell(row, 7).Style.Font.Bold = true;
                ws.Cell(row, 7).Style.NumberFormat.Format = "#,##0";
                ws.Cell(row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                ws.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                var res = MessageBox.Show("Xuất báo cáo tồn kho thành công! Bạn có muốn mở file không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File Excel đang được mở bởi một chương trình khác. Vui lòng đóng file rồi thử lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel tồn kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
