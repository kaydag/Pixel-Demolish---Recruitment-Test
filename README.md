Pixel Demolish - Bài test intern

1. Hướng dẫn mở project và chạy:
   - Cách 1: APK
     + Cài file '.apk' vào thiết bị Android và chạy
   - Cách 2: Unity
     + Clone repo về và mở bằng Unity
     + Mở scene chính và nhấn Play
2. Các chức năng đã thực hiện:
   - Hệ thống object dạng pixel, mỗi pixel là một entity riêng
   - Object rơi dưới tác động của gravity
   - Pixel có máu và có thể bị phá hủy
   - Cưa gây damage liên tục khi va chạm
   - Tách object thành nhiều mảnh nhỏ khi bị phá
   - Pixel rơi xuống đây có xử lí logic (rơi coin và cộng thêm xp)
   - UI level và tiến trình hiển thị theo số xp tìm được
   - Các Upgrade của cưa
3. Kiến trúc code
  - Pixel
    + Đại diện cho một đơn vị nhỏ nhất
    + Quản lý health, damage, trạng thái sống/chết
  - PixelGroup
    + Quản lý toàn bộ pixel của một object
    + Xử lý logic tách nhóm (BFS)
  - Gear và Saw
    + Bánh răng và cưa quay gây damage khi va chạm
4. Những điều sẽ cải thiện nếu có thêm thời gian:
  - Áp dụng pooling cho việc instantite cho các object (pixel, pixelgroup)
  - Tối ưu hệ thống tách object
  - Thêm hiệu ứng (partical) và âm thanh
  - Hoàn thiện Level Editor
  - Cải thiện UI
