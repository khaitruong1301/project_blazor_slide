using System;
using System.Linq;

namespace blazor_soan_slide.Services.Utility;
class FunctionUtility
{
public static T MapToModel<T>(object source) where T : new()
{
    if (source == null) throw new ArgumentNullException(nameof(source));

    T result = new T();
    var sourceProperties = source.GetType().GetProperties();
    var targetProperties = typeof(T).GetProperties();

    foreach (var targetProp in targetProperties)
    {
        // So sánh dựa trên tên thuộc tính của model
        var sourceProp = sourceProperties.FirstOrDefault(p => 
            string.Equals(p.Name, targetProp.Name, StringComparison.OrdinalIgnoreCase));

        if (sourceProp != null)
        {
            var sourceValue = sourceProp.GetValue(source);

            // Chuyển đổi kiểu nếu cần
            if (sourceValue != null && targetProp.PropertyType != sourceProp.PropertyType)
            {
                try
                {
                    var convertedValue = Convert.ChangeType(sourceValue, targetProp.PropertyType);
                    targetProp.SetValue(result, convertedValue);
                }
                catch
                {
                    // Nếu chuyển đổi thất bại, tiếp tục mà không gán
                    continue;
                }
            }
            else
            {
                targetProp.SetValue(result, sourceValue);
            }
        }
    }

    return result;
}


    // // Sử dụng:
    // var apiResponse = new ApiResponse { Id = 1, Name = "Product A", Price = 100, Alias = "PA", Size = "M" };
    // var productModel = MapToModel<ProductModel>(apiResponse);

}