using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresCRUD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PostgresCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbAvailabilityController : ControllerBase
    {
        private readonly PostgreSqlContext _context;

        public DbAvailabilityController(PostgreSqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// возвращает json поток с данными о состоянии доступности БД
        /// </summary>
        [HttpGet]
        [Route("health")]
        public async Task<string> SendResultsToJson6(CancellationToken token)
        {
            var path = @".\DbStatus.json";
            var canConnect = (await _context.Database.CanConnectAsync()).ToString();
            var jsonData = "{ \n \"Status\": \"" + canConnect + "\" \n}";

            System.IO.File.WriteAllText(path, jsonData); // заполняет json

            return await System.IO.File.ReadAllTextAsync(@".\DbStatus.json", token); // возвращает json с данными о состоянии бд
        }
    }
}   
//#region Task 1
        ///// <summary>
        ///// Проверяем возможность подключениия к дб
        ///// </summary>
        ///// <returns>
        ///// true - если смог подключиться
        ///// false - если не смог подключить, достигается путем переименования в appsettingss.json ключа Database 
        ///// </returns>
        //[HttpGet]
        //[Route("Task1")]
        //public async Task<bool> CheckAviablity()
        //{
        //    var result = _context.Database.CanConnectAsync();
        //    return await result;
        //}

        ////[HttpGet]
        ////[Route("Task1")]
        ////public async Task<string> SendResultsToJson()
        ////{
        ////    var path = @".\DbStatus.json";
        ////    var result = _context.Database.CanConnectAsync();

        ////    result.ToString();

        ////    var jopa = await System.IO.File.WriteAllText(path, result);
        ////    //return null;

        ////    //return await System.IO.File.ReadAllTextAsync(@".\author.json", token);


        ////    return jopa;
        ////}

        ///// <summary>
        ///// записать в json обычный текст
        ///// </summary>
        //[HttpGet]
        //[Route("Task2")]
        //public void SendResultsToJson1()
        //{
        //    var path = @".\DbStatus.json";
        //    string t = "txt";
        //    System.IO.File.WriteAllText(path, t);

        //}
        ///// <summary>
        ///// Синхронно
        ///// </summary>
        //[HttpGet]
        //[Route("Task3")]
        //public void SendResultsToJson21()
        //{
        //    var path = @".\DbStatus.json";
        //    var result = _context.Database.CanConnect();

        //    string t = result.ToString();

        //    string tt = "{ \n \"Status\":  \"" + t + "\" \n}";
        //    System.IO.File.WriteAllText(path, tt);
        //}
        ///// <summary>
        ///// ассинхронно
        ///// </summary>
        //[HttpGet]
        //[Route("Task4")]
        //public async void SendResultsToJson4()
        //{
        //    var path = @".\DbStatus.json";
        //    var result = await _context.Database.CanConnectAsync();

        //    string t = result.ToString();

        //    string tt = "{ \n \"Status\":  \"" + t + "\" \n}";
        //    System.IO.File.WriteAllText(path, tt);
        //}

        ///// <summary>
        ///// отдаю json 
        ///// </summary>
        //[HttpGet]
        //[Route("Task5")]
        //public async Task<string> SendResultsToJson5(CancellationToken token)
        //{
        //    var path = @".\DbStatus.json";
        //    var result = await _context.Database.CanConnectAsync();

        //    string t = result.ToString();

        //    string tt = "{ \n \"Status\": \"" + t + "\" \n}";
        //    System.IO.File.WriteAllText(path, tt);

        //    return await System.IO.File.ReadAllTextAsync(@".\DbStatus.json", token);
        //}
        //#endregion

        ////[HttpGet]
        ////[Route("Task4")]
        ////public IActionResult SendResultsToJson2()
        ////{
        ////    var path = @".\DbStatus.json";

        ////    var result = _context.Database.CanConnectAsync();

        ////    string value = result.ToString();

        ////    var resultValue = @"{ Status: " + value + " }";

        ////    System.IO.File.WriteAllText(path, resultValue);

        ////    return Ok();
        ////}