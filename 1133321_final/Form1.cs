using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// 🌟 1. 換成全新的 WinForms 專用命名空間
using System.Data.SQLite;

namespace _1133321_final
{
    public partial class hotel : Form
    {
        // 🌟 2. 連線字串加上 Version=3，這是 System.Data.SQLite 的標準寫法
        private string connectionString = "Data Source=hotel_management.db;Version=3;";
        private string selectedRoomNumber = "";

        public hotel()
        {
            InitializeComponent();
            this.Load += new EventHandler(hotel_Load);
        }

        private void hotel_Load(object sender, EventArgs e)
        {
            dtpCheckOut.MinDate = DateTime.Today;
            
            InitializeDatabase();
            LoadRoomButtons();
        }

        #region 資料庫初始化
        private void InitializeDatabase()
        {
            // 🌟 3. 所有的 SqliteConnection 都改成 SQLiteConnection (L大寫)
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Rooms (
                        RoomNumber TEXT PRIMARY KEY,
                        Status TEXT NOT NULL,
                        CheckOutDate TEXT,
                        ServiceStatus TEXT,
                        GuestNotes TEXT
                    );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string checkEmptyQuery = "SELECT COUNT(*) FROM Rooms;";
                using (var command = new SQLiteCommand(checkEmptyQuery, connection))
                {
                    long count = (long)command.ExecuteScalar();
                    if (count == 0)
                    {
                        string[] initialRooms = { "101", "102", "103", "104", "105", "106" };

                        foreach (var room in initialRooms)
                        {
                            string insertQuery = @"
                                INSERT INTO Rooms (RoomNumber, Status, CheckOutDate, ServiceStatus, GuestNotes) 
                                VALUES (@RoomNum, '空房', '', '無指示', '');";

                            using (var insertCmd = new SQLiteCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@RoomNum", room);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 動態產生左側房間按鈕
        private void LoadRoomButtons()
        {
            tlpRooms.Controls.Clear();
            tlpRooms.RowStyles.Clear();
            tlpRooms.RowCount = 0;

            int currentColumnCount = tlpRooms.ColumnCount > 0 ? tlpRooms.ColumnCount : 2;
            int roomCount = 0;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT RoomNumber, Status, ServiceStatus FROM Rooms ORDER BY RoomNumber;";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string roomNum = reader["RoomNumber"].ToString();
                            string status = reader["Status"].ToString();
                            string service = reader["ServiceStatus"].ToString();

                            Button btnRoom = new Button();

                            string buttonText = $"{roomNum}\n({status})";
                            if (service == "請勿打擾 (DND)") buttonText += "\n🚫 DND";
                            else if (service == "請即打掃 (MUR)") buttonText += "\n🧹 需打掃";

                            btnRoom.Text = buttonText;
                            btnRoom.Dock = DockStyle.Fill;
                            btnRoom.Margin = new Padding(8);
                            btnRoom.MinimumSize = new Size(0, 90);
                            btnRoom.Font = new Font("Microsoft JhengHei", 10, FontStyle.Bold);
                            btnRoom.Tag = roomNum;

                            switch (status)
                            {
                                case "入住中": btnRoom.BackColor = Color.LightCoral; break;
                                case "待清潔": btnRoom.BackColor = Color.Khaki; break;
                                case "維修中": btnRoom.BackColor = Color.LightGray; break;
                                default: btnRoom.BackColor = Color.LightGreen; break;
                            }

                            btnRoom.Click += RoomButton_Click;

                            int row = roomCount / currentColumnCount;
                            int col = roomCount % currentColumnCount;

                            if (row >= tlpRooms.RowCount)
                            {
                                tlpRooms.RowCount++;
                                tlpRooms.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            }

                            tlpRooms.Controls.Add(btnRoom, col, row);
                            roomCount++;
                        }
                    }
                }
            }
        }
        #endregion

        #region 房間按鈕點擊事件
        private void RoomButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            selectedRoomNumber = clickedButton.Tag.ToString();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string selectRoomQuery = "SELECT * FROM Rooms WHERE RoomNumber = @RoomNum;";

                using (var command = new SQLiteCommand(selectRoomQuery, connection))
                {
                    command.Parameters.AddWithValue("@RoomNum", selectedRoomNumber);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblRoomNum.Text = reader["RoomNumber"].ToString();
                            cmbStatus.SelectedItem = reader["Status"].ToString();
                            txtNotes.Text = reader["GuestNotes"].ToString();

                            string service = reader["ServiceStatus"].ToString();
                            cmbService.SelectedItem = string.IsNullOrEmpty(service) ? "無指示" : service;

                            string dateStr = reader["CheckOutDate"].ToString();
                            if (DateTime.TryParse(dateStr, out DateTime parsedDate))
                            {
                                // 🌟 安全防護：如果資料庫裡存的日期比今天還早，就強制顯示今天，避免程式報錯
                                if (parsedDate < DateTime.Today)
                                {
                                    dtpCheckOut.Value = DateTime.Today;
                                }
                                else
                                {
                                    dtpCheckOut.Value = parsedDate;
                                }
                            }
                            else
                            {
                                dtpCheckOut.Value = DateTime.Today;
                            }
                            grpEdit.Enabled = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region UI 連動：房況狀態下拉選單變更事件
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem != null)
            {
                string currentStatus = cmbStatus.SelectedItem.ToString();

                if (currentStatus == "空房" || currentStatus == "維修中" || currentStatus == "待清潔")
                {
                    dtpCheckOut.Enabled = false;
                    cmbService.Enabled = false;
                    cmbService.SelectedItem = "無指示";
                }
                else
                {
                    dtpCheckOut.Enabled = true;
                    cmbService.Enabled = true;
                }
            }
        }
        #endregion

        #region 儲存修改按鈕事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRoomNumber)) return;

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("請選擇房況狀態！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateQuery = @"
                    UPDATE Rooms 
                    SET Status = @Status, 
                        CheckOutDate = @CheckOut, 
                        ServiceStatus = @Service, 
                        GuestNotes = @Notes 
                    WHERE RoomNumber = @RoomNum;";

                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@CheckOut", dtpCheckOut.Enabled ? dtpCheckOut.Value.ToShortDateString() : "");
                    command.Parameters.AddWithValue("@Service", cmbService.SelectedItem?.ToString() ?? "無指示");
                    command.Parameters.AddWithValue("@Notes", txtNotes.Text);
                    command.Parameters.AddWithValue("@RoomNum", selectedRoomNumber);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"房間 {selectedRoomNumber} 資料已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearEditArea();
            LoadRoomButtons();
        }
        #endregion

        #region 取消按鈕事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEditArea();
        }
        #endregion

        private void ClearEditArea()
        {
            selectedRoomNumber = "";
            lblRoomNum.Text = "-";
            cmbStatus.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            dtpCheckOut.Value = DateTime.Now;
            txtNotes.Clear();
            grpEdit.Enabled = false;
        }
    }
}