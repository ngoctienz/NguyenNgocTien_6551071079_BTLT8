using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FastReport;
using FastReport.Export.Pdf;
using C2_QuanCaPhe.Models;

namespace C2_QuanCaPhe
{
    public partial class Form1 : Form
    {
        private List<Mon> _danhSachMon = new();
        private int? _currentMaHd = null;

        public Form1()
        {
            InitializeComponent();
            SetupDataGridViews();
        }

        private void SetupDataGridViews()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaHD",
                HeaderText = "Mã HD",
                DataPropertyName = "MaHdHienThi",
                Width = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayLap",
                HeaderText = "Ngày lập",
                DataPropertyName = "NgayLapHienThi",
                Width = 135
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoBan",
                HeaderText = "Số bàn",
                DataPropertyName = "SoBan",
                Width = 65,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colHinhThucTT",
                HeaderText = "Hình thức TT",
                DataPropertyName = "HinhThucTt",
                Width = 100
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTongTien",
                HeaderText = "Tổng tiền",
                DataPropertyName = "TongTienHienThi",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                DataPropertyName = "STT",
                Width = 45,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenMon",
                HeaderText = "Tên món",
                DataPropertyName = "TenMon",
                Width = 160
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSL",
                HeaderText = "SL",
                DataPropertyName = "SoLuong",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                HeaderText = "Đơn giá",
                DataPropertyName = "DonGiaHienThi",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThanhTien",
                HeaderText = "Thành tiền",
                DataPropertyName = "ThanhTienHienThi",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                InitSearchControls();
                InitInvoiceInputs();
                await LoadMonAsync();
                await LoadDanhSachHoaDonAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động ứng dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitSearchControls()
        {
            dtpTuNgay.Value = new DateTime(2026, 10, 1);
            dtpDenNgay.Value = new DateTime(2026, 10, 11);

            cboSoBanTim.Items.Clear();
            cboSoBanTim.Items.Add("Tất cả");
            for (int i = 1; i <= 10; i++)
            {
                cboSoBanTim.Items.Add(i.ToString());
            }
            cboSoBanTim.SelectedIndex = 0;

            cboHinhThucTim.Items.Clear();
            cboHinhThucTim.Items.Add("Tất cả");
            cboHinhThucTim.Items.Add("Tiền mặt");
            cboHinhThucTim.Items.Add("Chuyển khoản");
            cboHinhThucTim.SelectedIndex = 0;
        }

        private void InitInvoiceInputs()
        {
            cboSoBan.Items.Clear();
            for (int i = 1; i <= 10; i++)
            {
                cboSoBan.Items.Add(i.ToString());
            }
            cboSoBan.SelectedIndex = 0;
            dtpNgayLap.Value = DateTime.Now;
            radTienMat.Checked = true;
            nudSoLuong.Value = 1;
        }

        private async Task LoadMonAsync()
        {
            using var db = new QuanCaPheContext();
            _danhSachMon = await db.Mons.OrderBy(m => m.MaMon).ToListAsync();
            cboMon.DataSource = _danhSachMon;
            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "MaMon";
        }

        private async Task LoadDanhSachHoaDonAsync(int? selectMaHd = null)
        {
            try
            {
                using var db = new QuanCaPheContext();
                var query = db.HoaDons
                    .Include(h => h.ChiTietHoaDons)
                        .ThenInclude(ct => ct.MaMonNavigation)
                    .AsQueryable();

                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(h => h.NgayLap >= tuNgay && h.NgayLap <= denNgay);

                if (cboSoBanTim.SelectedIndex > 0 && int.TryParse(cboSoBanTim.SelectedItem?.ToString(), out int soBan))
                {
                    query = query.Where(h => h.SoBan == soBan);
                }

                if (cboHinhThucTim.SelectedIndex > 0)
                {
                    string hinhThuc = cboHinhThucTim.SelectedItem?.ToString() ?? "";
                    query = query.Where(h => h.HinhThucTt == hinhThuc);
                }

                string tenMonTim = txtTenMonTim.Text.Trim().ToLower();
                if (!string.IsNullOrEmpty(tenMonTim))
                {
                    query = query.Where(h => h.ChiTietHoaDons.Any(ct => ct.MaMonNavigation.TenMon.ToLower().Contains(tenMonTim)));
                }

                var listHd = await query.OrderBy(h => h.MaHd).ToListAsync();

                var displayList = listHd.Select(h =>
                {
                    decimal tongTien = h.ChiTietHoaDons.Sum(ct => ct.SoLuong * ct.DonGia);
                    return new HoaDonViewModel
                    {
                        MaHd = h.MaHd,
                        MaHdHienThi = $"HD{h.MaHd:D6}",
                        NgayLap = h.NgayLap,
                        NgayLapHienThi = h.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                        SoBan = h.SoBan,
                        HinhThucTt = h.HinhThucTt,
                        TongTien = tongTien,
                        TongTienHienThi = tongTien.ToString("N0")
                    };
                }).ToList();

                dgvHoaDon.DataSource = displayList;

                decimal tongDoanhThu = displayList.Sum(x => x.TongTien);
                lblTongDoanhThu.Text = $"Tổng doanh thu đang hiển thị: {tongDoanhThu:N0} đ";

                if (displayList.Count > 0)
                {
                    int targetIndex = 0;
                    if (selectMaHd.HasValue)
                    {
                        int foundIndex = displayList.FindIndex(x => x.MaHd == selectMaHd.Value);
                        if (foundIndex >= 0) targetIndex = foundIndex;
                    }
                    dgvHoaDon.ClearSelection();
                    dgvHoaDon.Rows[targetIndex].Selected = true;
                    await LoadChiTietHoaDonAsync(displayList[targetIndex].MaHd);
                }
                else
                {
                    ClearChiTiet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadChiTietHoaDonAsync(int maHd)
        {
            try
            {
                _currentMaHd = maHd;
                using var db = new QuanCaPheContext();
                var hd = await db.HoaDons
                    .Include(h => h.ChiTietHoaDons)
                        .ThenInclude(ct => ct.MaMonNavigation)
                    .FirstOrDefaultAsync(h => h.MaHd == maHd);

                if (hd == null)
                {
                    ClearChiTiet();
                    return;
                }

                lblChiTietHDTieuDe.Text = $"Chi tiết hóa đơn HD{hd.MaHd:D6}";
                dtpNgayLap.Value = hd.NgayLap;
                cboSoBan.SelectedItem = hd.SoBan.ToString();
                if (hd.HinhThucTt == "Tiền mặt") radTienMat.Checked = true;
                else radChuyenKhoan.Checked = true;
                txtGhiChu.Text = hd.GhiChu ?? "";

                int stt = 1;
                var displayChiTiet = hd.ChiTietHoaDons.OrderBy(ct => ct.MaCt).Select(ct => new ChiTietViewModel
                {
                    MaCt = ct.MaCt,
                    STT = stt++,
                    MaMon = ct.MaMon,
                    TenMon = ct.MaMonNavigation.TenMon,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia,
                    DonGiaHienThi = ct.DonGia.ToString("N0"),
                    ThanhTien = ct.SoLuong * ct.DonGia,
                    ThanhTienHienThi = (ct.SoLuong * ct.DonGia).ToString("N0")
                }).ToList();

                dgvChiTiet.DataSource = displayChiTiet;

                decimal tongCong = displayChiTiet.Sum(x => x.ThanhTien);
                lblTongCong.Text = $"Tổng cộng: {tongCong:N0} đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearChiTiet()
        {
            _currentMaHd = null;
            lblChiTietHDTieuDe.Text = "Chi tiết hóa đơn";
            txtGhiChu.Text = "";
            dgvChiTiet.DataSource = null;
            lblTongCong.Text = "Tổng cộng: 0 đ";
        }

        private async void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                var selected = dgvHoaDon.SelectedRows[0].DataBoundItem as HoaDonViewModel;
                if (selected != null && selected.MaHd != _currentMaHd)
                {
                    await LoadChiTietHoaDonAsync(selected.MaHd);
                }
            }
        }

        private void dgvChiTiet_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTiet.SelectedRows.Count > 0)
            {
                var selected = dgvChiTiet.SelectedRows[0].DataBoundItem as ChiTietViewModel;
                if (selected != null)
                {
                    cboMon.SelectedValue = selected.MaMon;
                    if (selected.SoLuong >= nudSoLuong.Minimum && selected.SoLuong <= nudSoLuong.Maximum)
                    {
                        nudSoLuong.Value = selected.SoLuong;
                    }
                }
            }
        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            await LoadDanhSachHoaDonAsync();
        }

        private async void btnHoaDonMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cboSoBan.SelectedItem?.ToString(), out int soBan))
                {
                    MessageBox.Show("Vui lòng chọn số bàn hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hinhThuc = radTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";
                string? ghiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                var newHd = new HoaDon
                {
                    NgayLap = dtpNgayLap.Value,
                    SoBan = soBan,
                    HinhThucTt = hinhThuc,
                    GhiChu = ghiChu
                };

                using var db = new QuanCaPheContext();
                db.HoaDons.Add(newHd);
                await db.SaveChangesAsync();

                MessageBox.Show($"Đã tạo hóa đơn mới HD{newHd.MaHd:D6} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDanhSachHoaDonAsync(newHd.MaHd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_currentMaHd.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(cboSoBan.SelectedItem?.ToString(), out int soBan))
                {
                    MessageBox.Show("Vui lòng chọn số bàn hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var db = new QuanCaPheContext();
                var hd = await db.HoaDons.FindAsync(_currentMaHd.Value);
                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hd.NgayLap = dtpNgayLap.Value;
                hd.SoBan = soBan;
                hd.HinhThucTt = radTienMat.Checked ? "Tiền mặt" : "Chuyển khoản";
                hd.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                await db.SaveChangesAsync();
                MessageBox.Show($"Đã cập nhật thông tin hóa đơn HD{hd.MaHd:D6} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDanhSachHoaDonAsync(hd.MaHd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_currentMaHd.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maHd = _currentMaHd.Value;
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn HD{maHd:D6} và toàn bộ món của hóa đơn này không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                using var db = new QuanCaPheContext();
                var hd = await db.HoaDons.Include(h => h.ChiTietHoaDons).FirstOrDefaultAsync(h => h.MaHd == maHd);
                if (hd != null)
                {
                    db.ChiTietHoaDons.RemoveRange(hd.ChiTietHoaDons);
                    db.HoaDons.Remove(hd);
                    await db.SaveChangesAsync();
                    MessageBox.Show($"Đã xóa hóa đơn HD{maHd:D6} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDanhSachHoaDonAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_currentMaHd.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn hoặc tạo hóa đơn trước khi thêm món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboMon.SelectedValue == null || !int.TryParse(cboMon.SelectedValue.ToString(), out int maMon))
                {
                    MessageBox.Show("Vui lòng chọn món cần thêm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soLuong = (int)nudSoLuong.Value;
                int maHd = _currentMaHd.Value;

                using var db = new QuanCaPheContext();
                var mon = await db.Mons.FindAsync(maMon);
                if (mon == null)
                {
                    MessageBox.Show("Không tìm thấy món đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ct = await db.ChiTietHoaDons.FirstOrDefaultAsync(x => x.MaHd == maHd && x.MaMon == maMon);
                if (ct != null)
                {
                    ct.SoLuong += soLuong;
                }
                else
                {
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaHd = maHd,
                        MaMon = maMon,
                        SoLuong = soLuong,
                        DonGia = mon.DonGia
                    });
                }

                await db.SaveChangesAsync();
                await LoadChiTietHoaDonAsync(maHd);
                await CapNhatTongTienTrenLuoiTraiAsync(maHd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaSL_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTiet.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn món cần sửa số lượng trong bảng chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCt = dgvChiTiet.SelectedRows[0].DataBoundItem as ChiTietViewModel;
                if (selectedCt == null) return;

                int soLuongMoi = (int)nudSoLuong.Value;
                if (soLuongMoi == selectedCt.SoLuong)
                {
                    using var prompt = new Form
                    {
                        Width = 320,
                        Height = 170,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        Text = "Sửa số lượng món",
                        StartPosition = FormStartPosition.CenterParent,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };
                    var lblPrompt = new Label { Left = 20, Top = 20, Width = 260, Text = $"Nhập số lượng mới cho '{selectedCt.TenMon}':" };
                    var nudPrompt = new NumericUpDown { Left = 20, Top = 48, Width = 120, Minimum = 1, Maximum = 50, Value = selectedCt.SoLuong };
                    var btnOk = new Button { Text = "Đồng ý", Left = 80, Width = 85, Top = 85, DialogResult = DialogResult.OK };
                    var btnCancel = new Button { Text = "Hủy", Left = 175, Width = 85, Top = 85, DialogResult = DialogResult.Cancel };
                    prompt.Controls.AddRange(new Control[] { lblPrompt, nudPrompt, btnOk, btnCancel });
                    prompt.AcceptButton = btnOk;
                    prompt.CancelButton = btnCancel;

                    if (prompt.ShowDialog(this) == DialogResult.OK)
                    {
                        soLuongMoi = (int)nudPrompt.Value;
                    }
                    else
                    {
                        return;
                    }
                }

                using var db = new QuanCaPheContext();
                var ctInDb = await db.ChiTietHoaDons.FindAsync(selectedCt.MaCt);
                if (ctInDb != null)
                {
                    ctInDb.SoLuong = soLuongMoi;
                    await db.SaveChangesAsync();

                    if (_currentMaHd.HasValue)
                    {
                        await LoadChiTietHoaDonAsync(_currentMaHd.Value);
                        await CapNhatTongTienTrenLuoiTraiAsync(_currentMaHd.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa số lượng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTiet.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa trong bảng chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCt = dgvChiTiet.SelectedRows[0].DataBoundItem as ChiTietViewModel;
                if (selectedCt == null) return;

                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa món '{selectedCt.TenMon}' khỏi hóa đơn này không?",
                    "Xác nhận xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                using var db = new QuanCaPheContext();
                var ctInDb = await db.ChiTietHoaDons.FindAsync(selectedCt.MaCt);
                if (ctInDb != null)
                {
                    db.ChiTietHoaDons.Remove(ctInDb);
                    await db.SaveChangesAsync();

                    if (_currentMaHd.HasValue)
                    {
                        await LoadChiTietHoaDonAsync(_currentMaHd.Value);
                        await CapNhatTongTienTrenLuoiTraiAsync(_currentMaHd.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CapNhatTongTienTrenLuoiTraiAsync(int maHd)
        {
            using var db = new QuanCaPheContext();
            var hd = await db.HoaDons.Include(h => h.ChiTietHoaDons).FirstOrDefaultAsync(h => h.MaHd == maHd);
            if (hd == null) return;

            decimal tongMoi = hd.ChiTietHoaDons.Sum(ct => ct.SoLuong * ct.DonGia);

            if (dgvHoaDon.DataSource is List<HoaDonViewModel> list)
            {
                var item = list.FirstOrDefault(x => x.MaHd == maHd);
                if (item != null)
                {
                    item.TongTien = tongMoi;
                    item.TongTienHienThi = tongMoi.ToString("N0");
                    dgvHoaDon.Refresh();

                    decimal tongDoanhThu = list.Sum(x => x.TongTien);
                    lblTongDoanhThu.Text = $"Tổng doanh thu đang hiển thị: {tongDoanhThu:N0} đ";
                }
            }
        }

        private async Task<(Report report, HoaDon hd, List<ChiTietIn> danhSachIn)?> PrepareReportAsync()
        {
            if (!_currentMaHd.HasValue)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in hoặc xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            int maHd = _currentMaHd.Value;
            using var db = new QuanCaPheContext();
            var hd = await db.HoaDons
                .Include(h => h.ChiTietHoaDons)
                    .ThenInclude(ct => ct.MaMonNavigation)
                .FirstOrDefaultAsync(h => h.MaHd == maHd);

            if (hd == null || hd.ChiTietHoaDons.Count == 0)
            {
                MessageBox.Show("Hóa đơn này chưa có món nào, không thể in hóa đơn trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "HoaDon.frx");
            if (!File.Exists(reportPath))
            {
                reportPath = Path.Combine(Application.StartupPath, "Reports", "HoaDon.frx");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file mẫu report tại: {reportPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            int stt = 1;
            var danhSachIn = hd.ChiTietHoaDons.OrderBy(ct => ct.MaCt).Select(ct => new ChiTietIn
            {
                STT = stt++,
                TenMon = ct.MaMonNavigation.TenMon,
                SoLuong = ct.SoLuong,
                DonGia = ct.DonGia,
                ThanhTien = ct.SoLuong * ct.DonGia
            }).ToList();

            var report = new Report();
            report.Load(reportPath);
            report.RegisterData(danhSachIn, "ChiTiet");
            var ds = report.GetDataSource("ChiTiet");
            if (ds != null) ds.Enabled = true;

            report.SetParameterValue("TenQuan", "QUÁN CÀ PHÊ GÓC PHỐ");
            report.SetParameterValue("SoHD", $"HD{hd.MaHd:D6}");
            report.SetParameterValue("NgayLap", hd.NgayLap.ToString("dd/MM/yyyy HH:mm"));
            report.SetParameterValue("SoBan", hd.SoBan.ToString());
            report.SetParameterValue("HinhThucTT", hd.HinhThucTt);

            return (report, hd, danhSachIn);
        }

        private async void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                var prep = await PrepareReportAsync();
                if (prep == null) return;
                using var report = prep.Value.report;
                report.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXuatPdf_Click(object sender, EventArgs e)
        {
            try
            {
                var prep = await PrepareReportAsync();
                if (prep == null) return;
                using var report = prep.Value.report;
                var hd = prep.Value.hd;

                using var sfd = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    FileName = $"HoaDon_HD{hd.MaHd:D6}.pdf",
                    Title = "Chọn nơi lưu file hóa đơn PDF"
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

        private async void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                var prep = await PrepareReportAsync();
                if (prep == null) return;
                using var report = prep.Value.report;
                report.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class HoaDonViewModel
        {
            public int MaHd { get; set; }
            public string MaHdHienThi { get; set; } = "";
            public DateTime NgayLap { get; set; }
            public string NgayLapHienThi { get; set; } = "";
            public int SoBan { get; set; }
            public string HinhThucTt { get; set; } = "";
            public decimal TongTien { get; set; }
            public string TongTienHienThi { get; set; } = "";
        }

        public class ChiTietViewModel
        {
            public int MaCt { get; set; }
            public int STT { get; set; }
            public int MaMon { get; set; }
            public string TenMon { get; set; } = "";
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public string DonGiaHienThi { get; set; } = "";
            public decimal ThanhTien { get; set; }
            public string ThanhTienHienThi { get; set; } = "";
        }
    }
}
