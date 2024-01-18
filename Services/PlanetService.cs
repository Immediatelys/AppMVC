using App.Models;

namespace App.Services;

public class PlanetService : List<PlanetModel> 
{
    public PlanetService()
    {
        Add(new PlanetModel(){
            Id = 1,
            Name ="Mercury",
            VnName = "Sao Thủy",
            Content = "Sao Thủy (cách Mặt Trời khoảng 0,4 AU) là hành tinh gần Mặt Trời nhất và là hành tinh nhỏ nhất trong Hệ Mặt Trời (0,055 lần khối lượng Trái Đất). Sao Thủy không có vệ tinh tự nhiên, và nó chỉ có các đặc trưng địa chất bên cạnh các hố va chạm đó là các sườn và vách núi, có lẽ được hình thành trong giai đoạn co lại đầu tiên trong lịch sử của nó.[39] Sao Thủy hầu như không có khí quyển do các nguyên tử trong bầu khí quyển của nó đã bị gió Mặt Trời thổi bay ra ngoài không gian.[40] Hành tinh này có lõi sắt tương đối lớn và lớp phủ khá mỏng mà vẫn chưa được các nhà thiên văn giải thích được một cách đầy đủ. Có giả thuyết cho rằng lớp phủ bên ngoài đã bị tước đi sau 1 vụ va chạm khổng lồ, và quá trình bồi tụ vật chất của Sao Thủy bị ngăn chặn bởi năng lượng của Mặt Trời trẻ"
        });
        Add(new PlanetModel(){
            Id = 2,
            Name ="Venus",
            VnName = "Sao Kim",
            Content = "Đây là sao kim"
        });Add(new PlanetModel(){
            Id = 3,
            Name ="Earth",
            VnName = "Trái Đất",
            Content = "Đây là trái đất"
        });
    }
}