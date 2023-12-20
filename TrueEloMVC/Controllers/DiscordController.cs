using Discord.WebSocket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.AspNetCore.Mvc;
using TokenType = DSharpPlus.TokenType;

namespace TrueEloMVC.Controllers
{
    public class DiscordController : Controller
    {


            // Создайте экземпляр бота и инициализируйте его с вашим токеном
            private static DiscordClient bot = new DiscordClient(new DiscordConfiguration
            {
                Token = "MTE3NjIxMTUzMjU1NjgwNDExNw.GV_g0f.LE4mb-hf49MudXj7gHCNEbK-yC7s-Z8tIPaMQU",
                TokenType = TokenType.Bot
            });

            // Создайте переменную для хранения объекта сервера
            private static DiscordGuild guild;

            // Асинхронный метод для запуска бота
            public static async Task StartBotAsync()
            {
                // Подпишитесь на событие Ready бота
                bot.Ready += Bot_Ready;

                // Запустите бота
                await bot.ConnectAsync();
            }

            // Метод, который будет вызываться, когда бот будет готов
            private static async Task Bot_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
            {
                // Получите объект сервера по его идентификатору
                guild = await bot.GetGuildAsync(1176209709292851350); // замените на ваш идентификатор сервера
            }

            // Метод, который будет отображать вашу одностраничную веб-страницу
            public IActionResult Index()
            {
                return View();
            }

            // Метод, который будет вызываться по нажатию на кнопку для создания голосового канала
            [HttpPost]
            public async Task<IActionResult> CreateVoiceChannel(string channelName)
            {
                try
                {
                    // Проверьте, что имя канала не пустое
                    if (string.IsNullOrEmpty(channelName))
                    {
                        throw new ArgumentException("Имя канала не может быть пустым");
                    }

                    // Проверьте, что бот и сервер были успешно инициализированы
                    if (bot == null || guild == null)
                    {
                        throw new InvalidOperationException("Бот или сервер не были готовы");
                    }

                    // Создайте новый голосовой канал на сервере с заданным именем
                    await guild.CreateVoiceChannelAsync(channelName);

                    // Верните сообщение об успехе
                    return Content($"Голосовой канал {channelName} успешно создан");
                }
                catch (Exception ex)
                {
                    // Верните сообщение об ошибке
                    return Content($"Произошла ошибка при создании голосового канала: {ex.Message}");
                }
            }
        }
    }
