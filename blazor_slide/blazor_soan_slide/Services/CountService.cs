using System;
public class CountService
{
    // Biến lưu trữ số lượng hiện tại
    public int Count { get; private set; }
    // Phương thức tăng số lượng
    public void Increase()
    {
        Count++;                
        NotifyStateChanged();   // Gọi NotifyStateChanged để thông báo state đã thay đổi
    }
    // Phương thức giảm số lượng
    public void Decrease()
    {
        if (Count > 0)         
        {
            Count--;           
            NotifyStateChanged(); // Gọi NotifyStateChanged để thông báo state đã thay đổi
        }
    }
    // Sự kiện OnChange sẽ được kích hoạt khi có sự thay đổi state
    public event Action OnChange;
    // Phương thức NotifyStateChanged sẽ kích hoạt sự kiện OnChange
    // Khi OnChange được kích hoạt, tất cả các component đăng ký với sự kiện này sẽ biết state đã thay đổi
    private void NotifyStateChanged() => OnChange?.Invoke();
}










// Giải thích dòng trên:
// - OnChange?.Invoke() là một cách viết ngắn gọn để kiểm tra nếu OnChange không null (đã có nơi đăng ký sự kiện)
// - Nếu OnChange không null, Invoke() sẽ kích hoạt sự kiện này, thông báo cho các component đã đăng ký

// private void NotifyStateChanged()
// {
//     // Kiểm tra nếu OnChange không null (đã có nơi đăng ký sự kiện) 
//     if (OnChange != null)
//     {
//         // Kích hoạt sự kiện OnChange để thông báo cho các component đã đăng ký
//         OnChange.Invoke();
//     }
// }


