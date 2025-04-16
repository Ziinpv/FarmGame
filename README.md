# 🌾 Farm Game: Phiên bản 2 Người Chơi

Một trò chơi nông trại 2D co-op lấy cảm hứng từ *Stardew Valley*, nơi sự phối hợp giữa hai người là chìa khóa để xây dựng một trang trại thành công!

---

## 🎮 Giới thiệu

**Farm Game** là game mô phỏng nông trại 2D top-down dành cho **2 người chơi local co-op**. Cùng nhau trồng trọt, tưới nước, thu hoạch, chế biến sản phẩm và phục vụ khách hàng để đạt điểm số tối đa trong thời gian giới hạn!

> ✅ Hỗ trợ **2 người chơi cùng lúc trên một máy**  
> ✅ Thiết kế cho những phiên chơi ngắn, lặp lại nhiều lần  
> ✅ Phù hợp chơi với bạn bè, gia đình hoặc trong các buổi game party

---

## 🧑‍🌾 Tính năng chính

- 🌱 Gieo trồng và thu hoạch nhiều loại cây trồng
- 💧 Tưới nước và chăm sóc đất đai
- 🐄 Chế biến sữa
- 🧺 Giao hàng theo yêu cầu khách hàng
- ✨ Đồ họa 2D phong cách dễ thương, nhạc nền nhẹ nhàng
- 🎮 Điều khiển đơn giản (Người chơi 1: `WASD + E`, Người chơi 2: `IJKL + O`)

---

## 🗂️ Cấu trúc thư mục cơ bản (Unity)
📁 Thư mục | 🔍 Mô tả chức năng
Scripts/   | Chứa toàn bộ mã nguồn C# của game (MonoBehaviour, ScriptableObject, manager, logic...)
Scenes/    | Các scene của game (menu, gameplay, tutorial, v.v.)
Sprites/   | Ảnh 2D như nhân vật, cây trồng, icon UI, vật phẩm, v.v.
Assets/    | Chứa Assets của giống cây và cây trồng
Animation/ | Chứa Animator, animation clip (nhân vật, UI, vật thể...)
Resources/ | Các tài nguyên load bằng Resources.Load() (nên dùng ít, ưu tiên Addressables)
Tiles/     | Các tilemap và tileset dùng cho map dạng lưới (nếu có)
Sounds/    | Âm thanh: nhạc nền, hiệu ứng (SFX), âm UI...
Shader/    | Các file shader (.shader, .cginc) cho hiệu ứng đặc biệt
Prefabs/   | Lưu trữ các prefab có thể tái sử dụng (cây, nhân vật, item, UI...)
Font/      | Phông chữ dùng trong UI game (TextMeshPro, Legacy Text...)

---

## 📦 Asset sử dụng

| Tên Asset | Dùng để làm gì | Nguồn |
|-----------|----------------|--------|
| **Kenney Farming Kit** | Cây trồng, dụng cụ, UI cơ bản | [kenney.nl](https://kenney.nl/assets/farming-kit) |
| **Free 2D Character Pack** | Nhân vật, animation | Unity Asset Store |
| **Cartoon FX Free** | Hiệu ứng tưới nước, thu hoạch | Unity Asset Store |
| **TextMeshPro** | Hiển thị chữ rõ nét | Tích hợp sẵn trong Unity |
| **Brackeys Audio Manager** | Quản lý âm thanh | [GitHub](https://github.com/Brackeys/2D-Character-Controller) |
| **Cinemachine** | Camera mượt mà | Unity Package Manager |
| **Pixel UI Pack** | Giao diện đơn giản, dễ dùng | Unity Asset Store |

---

## 🎮 Điều khiển

| Hành động | Người chơi 1 | Người chơi 2 |
|----------|---------------|--------------|
| Di chuyển | W A S D       | E           |
| Tương tác | I J K L       | O           |

---

## 🚧 Tiến độ phát triển

- ✅ Cơ chế gieo trồng và tưới nước
- ✅ Hệ thống khách hàng cơ bản
- [x] Điều khiển hai người chơi độc lập  
- [x] Trồng cây, tưới nước và thu hoạch
- 🚧 Các xưởng chế biến
- 🚧 Lưu và tải dữ liệu game

---

👥 Nhóm phát triển
Thiết kế và lập trình:

🧑‍💻 Hoàng Long – MSSV: 2212407

👩‍💻 Nguyễn Thị Hoàng Phúc – MSSV: 2213795

Asset sử dụng từ: Kenney, Unity Asset Store, và các nguồn mở khác

Âm thanh lấy từ: freesound.org, incompetech.com

---

## ❤️ Lời cảm ơn

- Cảm ơn **Stardew Valley** đã truyền cảm hứng
- Cộng đồng Unity vì đã chia sẻ asset, kiến thức
- Những người bạn & tester đã hỗ trợ góp ý

---

> **Cùng nhau xây dựng trang trại mơ ước nào!**
