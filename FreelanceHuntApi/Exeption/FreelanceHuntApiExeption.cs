using Newtonsoft.Json.Linq;
using System;

namespace FreelanceHuntApi.Exeption
{
    /// <summary>
    /// Базовый класс для всех исключений, выбрасываемых библиотекой.
    /// </summary>
    class FreelanceHuntApiExeption : Exception 
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int ErrorCode { get; internal set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса FreelanceHuntApiExeption
        /// </summary>
        public FreelanceHuntApiExeption()
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса FreelanceHuntApiExeption
        /// </summary>
        /// <param name="message">Описание исключения</param>
        public FreelanceHuntApiExeption(string message)
            : base(message)
        {
                
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса FreelanceHuntApiExeption
        /// </summary>
        /// <param name="response"> Ответ от сервера FreelanceHunt </param>
        public FreelanceHuntApiExeption(JObject response) : base(response["error"]["message"].ToObject<string>())
        {
            ErrorCode = response["error"]["code"].ToObject<int>();
        }
    }
}
