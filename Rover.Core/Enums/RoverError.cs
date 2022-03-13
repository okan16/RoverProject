using System.ComponentModel;

namespace Rover.Shared.Enums
{
    public enum RoverError
    {
        [Description("Girilen komutlar rover icin gecerli degildir! Sadece L,R veya M giriniz.")]
        WrongCommand,

        [Description("Gezilecek alan ile rover koordinatı arasında uyumsuzluk vardır.")]
        WrongRoverCoordinate,

        [Description("Rover icin girilen yer yon bilgisi yanlistir. Örnek: 1 2 N")]
        WringDirection
    }
}
