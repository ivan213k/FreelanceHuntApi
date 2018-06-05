using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceHuntApi.Exeption
{
    /// <summary>
    ///  Исключение, которое выбрасывается в случае, если параметр принимал
    /// недействительное значение.
    /// </summary>
    class InvalidParameterException : FreelanceHuntApiExeption
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        public InvalidParameterException()
        {
           
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message"> Описание исключения. </param>
        public InvalidParameterException(string message) : base(message: message)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message"> Описание исключения. </param>
        /// <param name="code"> Код ошибки, полученный от сервера FreelanceHunt. </param>
        public InvalidParameterException(string message, int code) 
            : base(message: message)
        {
            ErrorCode = code;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения</param>
        /// <param name="code">Код ошибки, полученный от сервера FreelanceHunt</param>
        /// <param name="paramName">имя некорректного параметра</param>
        public InvalidParameterException(string message, int code, string paramName)
           : base(message: message)
        {
            ErrorCode = code;
            ParametrName = paramName;
        }

        /// <summary>
        /// имя некорректного параметра
        /// </summary>
        public string ParametrName { get; internal set; }
    }
}
