using System.Collections.Generic;

namespace QuanLyCuaHangGame.Data
{
    /// <summary>
    /// Nguồn dữ liệu phòng chung — được dùng bởi cả dlgRoom và frmComputer.
    /// Khi BLL/DAL hoàn thiện thì thay thế bằng gọi thật từ database.
    /// </summary>
    public static class RoomStore
    {
        // Mỗi phần tử: { Tên phòng, Tầng, Số máy, Trạng thái }
        public static List<string[]> Rooms { get; } = new List<string[]>
        {
            new[] { "Phòng A",   "1", "12 máy", "Hoạt động" },
            new[] { "Phòng B",   "1", "8 máy",  "Hoạt động" },
            new[] { "Phòng VIP", "2", "4 máy",  "Hoạt động" },
            new[] { "Phòng Mới", "2", "0 máy",  "Chưa kích hoạt" },
        };

        /// <summary>Lấy danh sách tên phòng để đưa vào ComboBox.</summary>
        public static string[] GetRoomNames()
        {
            var names = new string[Rooms.Count];
            for (int i = 0; i < Rooms.Count; i++)
                names[i] = Rooms[i][0];
            return names;
        }
    }
}
