using AdaStore.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdaStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productos = new List<Product>()
            {
                new Product {
                    Id = 1,
                    Name = "Aspiradora y Mopeadora IROBOT 2 en 1 R1118 Negro",
                    Description = "Aspira el polvo y la suciedad de suelos y alfombras gracias a su cepillo en forma de V y su potente aspiración. Sus cepillos para esquinas y bordes limpian la suciedad a lo largo de paredes y esquinas. Su sistema mopeado utiliza múltiples modos de limpieza y un paño de microfibra con una textura especialmente diseñada. Aprende tus hábitos de limpieza y te sugiere horarios que se adaptan a ti. También te hace recomendaciones que tú no hubieras tenido en mente, como una limpieza extra durante la temporada de alergias.",
                    Price = 1599900,
                    Stock = 7
                },
                new Product {
                    Id = 2,
                    Name = "Consola XBOX Series X + 1 Control Inalámbrico + Paquete Forza Horizon 5",
                    Description = "Comienza tu aventura definitiva con el Bundle de Consola Xbox Series X y la Edición Premium de Forza Horizon 5. Explora los vibrantes y siempre cambiantes paisajes del mundo abierto de México en los mejores autos del mundo. Los juegos que se han optimizado para Xbox Series X|S usan toda la potencia de las nuevas consolas para ofrecer velocidades de fotogramas más altas y estables de hasta 120 FPS durante el juego.Compra ya la tuya!!",
                    Price = 3870000,
                    Stock =9
                },
                new Product {
                    Id = 3,
                    Name = "Minicomponente SAMSUNG MX-T40 300 Watts Negro Torre de Sonido",
                    Description = "La exclusiva Torre de Sonido Samsung MX-T40 tiene una potencia de salida de 300 vatios para que disfrutes de una experiencia de sonido bidireccional envolvente, adicional, cuenta con un panel de control que ofrece una resistencia a salpicaduras y con la aplicación Samsung Giga Party Audio podrás controlar las luces, crear listas de canciones, hacer mezclas con el ecualizador y colocar efectos tipo DJ  ¡Que comience la fiesta!",
                    Price = 449000,
                    Stock= 22
                },
                new Product {
                    Id = 4,
                    Name = "Computador Portátil HP 15.6\" Pulgadas ef2519la AMD Ryzen 5 - RAM 8GB - Disco SSD 512 GB - Plateado",
                    Description = "Portátil HP. Diseñado para mantener la productividad y estar entretenido en cualquier parte. Mira más, lleva menos gracias a su diseño fino y ligero, ideal para viajar. Mira más fotos, videos y proyectos en una pantalla con bisel y microbordes de 6,5 mm. Supera los días de mayor actividad gracias al rendimiento de su confiable procesador y conserva más de lo que amas con el abundante almacenamiento. La larga duración de la batería y la tecnología HP Fast Charge te permiten trabajar, ver contenido y permanecer conectado durante todo el día. ¡Cómpralo aquí!",
                    Price = 2119000,
                    Stock = 5
                },
                new Product {
                    Id = 5,
                    Name = "TV TCL 55\" Pulgadas 139 cm 55P735 4K-UHD LED Smart TV Google",
                    Description = "El TV 55P735 trae la mejor resolución y billones de colores gracias a su pantalla UltraHD 4K y HDR10 con certificación Dolby Vision/Atmos que elevan la experiencia audiovisual al siguiente nivel. Tambien, puedes disfrutar su conexión HDMI 2.1 y WiFi de doble banda, y de todos los beneficios de su nuevo sistema operativo Google TV con +8000 apps y +300 juegos disponibles en Google Play. Además, utiliza sus comandos de voz, con solo con decir \"Hey Google\" y sin necesidad de controles (función hands-free voice control).",
                    Price = 1859000,
                    Stock = 13
                },
                new Product {
                    Id = 6,
                    Name = "Freidora de Aire IMUSA 4.2 Litros Easy Fry Deluxe Digital 1510001752 Negro",
                    Description = "Freír, asar y hornear de una forma saludable nunca fue tan fácil como con tu IMUSA Easy Fry Deluxe 4,2L digital.| La freidora de aire usa un sistema para cocinar los alimentos circulando aire caliente alrededor de la comida y requiere muy poco o nada de aceite, esto te permite realizar recetas saludables y para toda la familia gracias a su capacidad de 4,2 litros donde puedes cocinar hasta 6 porciones a la vez. Su pantalla táctil digital hace más fácil la preparación de las recetas, para que disfrutes mucho más de tu tiempo en otras cosas, ¡lleva la tuya ahora!",
                    Price = 379000,
                    Stock = 32
                },
                new Product {
                    Id = 7,
                    Name = "Consola NINTENDO SWITCH con Joy Con Neon/Blue",
                    Description = "Juega con la familia en la pantalla de la tele, como en el parque o en casa de un amigo.",
                    Price = 1559000,
                    Stock = 15
                },
                new Product {
                    Id = 8,
                    Name = "Celular MOTOROLA G71 128GB 5G Azul",
                    Description = "La vida es un viaje. Vívela al máximo con el moto g71 5G. Con la carga TurboPower™ 30 y la batería de 5,000 mAh, la diversión nunca se detiene. Disfruta de películas, programas y videojuegos con colores nítidos en la pantalla OLED de 6.4\". Retrata el momento, de día o de noche, con el sistema multicámara de 50 MP. Sigue el viaje de tu vida. Sigue adelante con moto g.",
                    Price = 930000,
                    Stock = 11
                },
            };

            return Ok(productos);
        }
    }
}
